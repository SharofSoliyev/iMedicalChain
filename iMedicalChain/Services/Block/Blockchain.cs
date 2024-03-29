﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AmberPOW
{
    static class Blockchain
    {

        public static List<Block> blockchain = new List<Block>();
        static int difficulity = 2;
        public static void AddBlock(string dat = "saliyev", string prvHash = "") 
        {
            int nonce = 0; 
            string timestamp = Convert.ToString(DateTime.Now);
            while (true)
            {

                string newHash = getHash(timestamp, dat, prvHash, nonce); 

                if (newHash.StartsWith(String.Concat(Enumerable.Repeat("0", difficulity))))
                {
                    Console.WriteLine("Found!!! {0}, nonce - {1}", newHash, nonce);
                    blockchain.Add(new Block(timestamp, dat, newHash, nonce));

                    break;
                }
                else 
                {
                    nonce++;
                }
            }

        }

        public static void EDIT(int block, string data)
        {
            blockchain[block].data = data;
        }

        public static void Verification()
        {
            for (int i = 1; i != blockchain.Count; i++)
            {
                string verHash = getHash(blockchain[i].timestamp, blockchain[i].data, blockchain[i - 1].hash, blockchain[i].nonce);
                if(verHash == blockchain[i].hash)
                {
                    Console.WriteLine("Block {0} - OK", i);
                }
                else
                {
                    Console.WriteLine("Wrong block");
                    return;
                }
                
            }
            Console.WriteLine("All blocks are confirmed");
        }

        static BinaryFormatter formatter = new BinaryFormatter();

        static string getHash(string ts, string dat, string prvHash, int nonce)
        { 

            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(ts + dat + prvHash + nonce))
                    .Select(item => item.ToString("x2"))); ;
            }
        }

    }
}

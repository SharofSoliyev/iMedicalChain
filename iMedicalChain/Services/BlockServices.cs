using iMedicalChain.Core;
using iMedicalChain.Data;
using iMedicalChain.Models;
using iMedicalChain.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace iMedicalChain.Services
{
    public interface IBlockServices
    {
        public Task<bool> AddBlock(string dat, string prvHash);
        public List<Verification> Verification();
        public List<string> GetAllBlocks();


    }
    public  class BlockServices : IBlockServices
    {
        private readonly IRepository<Block> _repository;
       
        public BlockServices(IRepository<Block> repository )
        {
            this._repository = repository;
        }
        public static int difficulity = 2;
        public  async Task<bool> AddBlock(string dat = "", string prvHash = "")
        {

            int nonce = 0; 
            string timestamp = Convert.ToString(DateTime.Now);
           
            while (true)
            {

                string newHash = Hash.getHash(timestamp, dat, prvHash, nonce); //Вычисляем хэш, дополнительно передавая число сложности

                if (newHash.StartsWith(String.Concat(Enumerable.Repeat("0", difficulity))))
                {

                    var Block = new Block ()
                    { timestamp= timestamp,data= dat, hash= newHash,nonce= nonce};

                      Connection.PostTextInfoMessage(timestamp + " " + dat + " " + newHash + " " + nonce + " ");
                     await  _repository.AddAsync(Block);
                


                    break;
                }
                else 
                {
                    nonce++;
                }
            }
            return true;
        }
        public List<Verification> Verification()
        {
            List<Verification> verifications = new List<Verification>();
            var blockchain = _repository.GetAll().ToList();
            for (int i = 1; i != blockchain.Count; i++)
            {
                var verif = new Verification();
                string verHash =Hash.getHash(blockchain[i].timestamp, blockchain[i].data, blockchain[i - 1].hash, blockchain[i].nonce);
                if (verHash == blockchain[i].hash)
                {
                    verif.Id = blockchain[i].Id;
                    verif.Status = "OK";
                }
                else
                {
                    verif.Id = blockchain[i].Id;
                    verif.Status = "DANGER!!!";
                }
                verifications.Add(verif);
            }
            return verifications;
        }

        public List<string> GetAllBlocks ()
        {
            List<string> strings = new List<string>();
            var blockains = _repository.GetAll().ToList();

            foreach(var blc in blockains)
            {
                string format = String.Format("{0}, {1}, {2}, {3}", blc, blc.data, blc.hash, blc.timestamp);
                strings.Add(format);
            }
            return strings;

        }


    }
}

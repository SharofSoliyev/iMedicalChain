using iMedicalChain.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace iMedicalChain.Core
{
    public class Patient : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirhtDay { get; set; }

        public string Adress { get; set; }

        public string PasspordSeriaAndNumber { get; set; }

        public string PINFL { get; set; }

        public string PhoneNumber { get; set; }

    }
}

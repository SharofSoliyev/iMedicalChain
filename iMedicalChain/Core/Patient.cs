using iMedicalChain.Core.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iMedicalChain.Core
{
    public class Patient : Entity
    {
        [DisplayName("Ism")]
        public string FirstName { get; set; }
        
        [DisplayName("Familya")]
        public string LastName { get; set; }

        [DisplayName("Tug'ilgan kun")]

        public DateTime BirhtDay { get; set; }

        [DisplayName("Yashash manzili")]

        public string Adress { get; set; }

        [DisplayName("Passport seriya va raqami")]

        public string PasspordSeriaAndNumber { get; set; }

        [DisplayName("PINFL")]

        public string PINFL { get; set; }

        [DisplayName("Telefon raqam")]

        public string PhoneNumber { get; set; }

    }
}

using iMedicalChain.Core.Entities;
using System;
using System.ComponentModel;

namespace iMedicalChain.Core
{
    public class User : Entity
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

        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}

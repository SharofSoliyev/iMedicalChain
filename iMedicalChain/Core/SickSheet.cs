using iMedicalChain.Core.Entities;
using System;

namespace iMedicalChain.Core
{
    public class SickSheet : Entity
    {
        public string Name { get; set; }

        public DateTime RegistrDay { get; set; }

        public decimal Weight { get; set; }
        public decimal Heigt { get; set; }

    }
}

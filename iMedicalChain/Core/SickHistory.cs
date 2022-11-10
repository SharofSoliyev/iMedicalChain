using iMedicalChain.Core.Entities;
using iMedicalChain.Models;
using System;
using System.ComponentModel;

namespace iMedicalChain.Core
{
    public class SickHistory :Entity
    {


        [DisplayName("Shifoxona nomi")]
        public string HospitalName { get; set; }

        [DisplayName("Kasalning kelgan vaqti")]
        public DateTime TimeToCome { get; set; }

        [DisplayName("Kasal boshlangan vaqt")]
        public DateTime SickDefinedTime { get; set; }

        [DisplayName("Yuborilgan Shifoxona nomi")]
        public string GetHospitalName { get; set; }

        [DisplayName("Yuborgan muassasa diagnozi")]

        public string DiagnozGetHospitalName { get; set; }

        [DisplayName("Qabulxonada qo'yilgan diagnoz")]

        public string DiagnozinReception { get; set; }

        [DisplayName("Klinik diagnoz")]

        public string ClinicalDiagnoz { get; set; }

        [DisplayName("Hulosaviy diagnoz")]

        public string FinalDiagnoz { get; set; }

        [DisplayName("Asosiy diagnoz")]

        public string MainDiagnoz { get; set; }

        [DisplayName("Asosiy kasallik asorati")]

        public string MainSickResult { get; set; }

        [DisplayName("Shikoyatlar")]

        public string Complaints { get; set; }

        [DisplayName("Anamnesis morbi")]

        public string AnamnesisMorbi { get; set; }

        [DisplayName("Anamnesis vitae")]

        public string  AnamnesisVitae { get; set; }
       
    }
}

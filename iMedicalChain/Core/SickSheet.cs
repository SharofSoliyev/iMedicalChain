using iMedicalChain.Core.Entities;
using System;

namespace iMedicalChain.Core
{
    public class SickSheet : Entity
    {

    public int DoctorsId { get; set; }
    public Doctors Doctors { get; set; }
     public int PatientId { get; set; }
    public Patient Patient { get; set; }
     
     public int SickHistoryId { get; set; }
     
     public SickHistory SickHistory { get; set; }

    }
}

using iMedicalChain.Core.Entities;

namespace iMedicalChain.Core
{
    public class ChainUsers : Entity
    {
        public int UserId { get; set; }
        public float Longituda { get; set; }
        public float Laptituda { get; set;}

        public long LastSync { get; set; }

        public string AllBlock { get; set; }
    }
}

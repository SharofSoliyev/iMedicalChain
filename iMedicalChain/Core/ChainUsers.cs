using iMedicalChain.Core.Entities;

namespace iMedicalChain.Core
{
    public class ChainUsers : Entity
    {
        public int UserId { get; set; }
        public long Longituda { get; set; }
        public long Laptituda { get; set;}

        public long LastSync { get; set; }

        public string AllBlock { get; set; }
    }
}

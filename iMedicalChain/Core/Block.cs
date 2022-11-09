using iMedicalChain.Core.Entities;

namespace iMedicalChain.Core
{
    public class Block : Entity
    {
        public string timestamp { get; set; }
        public string data { get; set; }
        public string hash { get; set; }
        public int nonce { get; set; }
    }
}

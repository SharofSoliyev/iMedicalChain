using iMedicalChain.Core.Entities;

namespace iMedicalChain.Core
{
    public class User : Entity
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Username { get; set; }

    }
}

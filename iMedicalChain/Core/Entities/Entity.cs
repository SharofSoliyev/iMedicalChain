using iMedicalChain.Core.Entities.Base;
using System;

namespace iMedicalChain.Core.Entities
{
    public class Entity : EntityBase<int>
    {
        public DateTime? createdAt { get; set;   } = DateTime.Now;
        public DateTime? updatedAt { get; set; } = DateTime.Now;
        }
}

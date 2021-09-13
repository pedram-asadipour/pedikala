using System;

namespace _01_Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public EntityBase()
        {
            // Id = 1;
            CreationDate = DateTime.Now;
        }
    }
}
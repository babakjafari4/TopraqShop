using System;

namespace TopraqShop.Framework.Base.Domain
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public byte Status { get; set; }
    }
}
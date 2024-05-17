using System;

namespace CatalogueManagement.Interfaces
{
    public interface IBaseItemData
    {
        public ItemCodeId CodeId { get; }
        public Guid Id { get; }
        public string Name { get; }
    }
}
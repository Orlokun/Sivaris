namespace CatalogueManagement.Interfaces
{
    public interface IItemData : IExchangeable, IBaseItemData
    {
        public string IconPath { get; }
        public string Description { get; }
    }
}
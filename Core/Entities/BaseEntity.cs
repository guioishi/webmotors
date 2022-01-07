namespace Core.Entities
{
    public interface IBaseEntity
    {
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    }
}
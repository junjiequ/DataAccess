namespace DataAccess
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
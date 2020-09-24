namespace MSmile.Db.Infrastructure
{
    /// <summary>
    /// Interface for entities with id.
    /// </summary>
    public interface IEntityWithId : IEntity
    {
        /// <summary>
        /// Id.
        /// </summary>
        long Id { get; set; }
    }
}

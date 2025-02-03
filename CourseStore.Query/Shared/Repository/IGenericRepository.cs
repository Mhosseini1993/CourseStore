namespace CourseStore.Query.Shared.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseReadModel
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}

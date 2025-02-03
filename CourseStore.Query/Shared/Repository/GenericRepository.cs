using MongoDB.Driver;

namespace CourseStore.Query.Shared.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseReadModel
    {

        protected readonly IMongoCollection<TEntity> _collection;
        public GenericRepository(IMongoClient client)
        {
            var _db = client.GetDatabase("CourseStroreDB");
            _collection=_db.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            var res = await _collection.FindAsync(ef => true);
            return res.ToList();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            var res = await _collection.FindAsync(ef => ef.Id==id);
            return await res.FirstOrDefaultAsync();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(ef => ef.Id==entity.Id, entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _collection.DeleteOneAsync(ef => ef.Id==id);
        }
    }
}

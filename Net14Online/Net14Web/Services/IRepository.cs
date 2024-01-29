using Net14Web.DbStuff.Models;

namespace Net14Web.Services
{
    public interface IRepository<T> where T : BaseModel
    {
        public Task<T?>? GetById(int id);

        public Task DeleteById(int id);

        public Task<List<T>> GetAllAsync();

        public Task UpdateAsync(T entity);

        public Task AddAsync(T entity);
    }
}

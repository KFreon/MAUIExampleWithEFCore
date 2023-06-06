using MAUIExampleDB;
using Microsoft.EntityFrameworkCore;

namespace MAUIExampleWithEFCore.Services
{
    public interface IMyService
    {
        Task<MyModel[]> GetThings();
        Task AddModel(MyModel model);
    }

    public class MyService : IMyService
    {
        private readonly IRepo repo;

        public MyService(IRepo repo)
        {
            this.repo = repo;
        }

        public async Task<MyModel[]> GetThings()
        {
            return await repo.Models.ToArrayAsync();
        }

        public async Task AddModel(MyModel model)
        {
            await repo.Models.AddAsync(model);
            await repo.SaveChangesAsync();
        }
    }
}

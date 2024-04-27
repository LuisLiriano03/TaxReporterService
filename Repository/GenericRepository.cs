using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaxReporter.DBContext;
using TaxReporter.Repository.Contract;

namespace TaxReporter.Repository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly TaxReporterDbContext _dbContext;

        public GenericRepository(TaxReporterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel> GetEverythingAsync(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await _dbContext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch
            {
                throw new InvalidOperationException("Sorry, there are no available data.");
            }

        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw new InvalidOperationException("Sorry, there was an error while creating the data.");

            }

        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new InvalidOperationException("Sorry, there was an error while updating the data.");
            }

        }

        public async Task<bool> DeleteAsync(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new InvalidOperationException("Sorry, there was an error while removing the data.");
            }

        }


        public async Task<IQueryable<TModel>> VerifyDataExistenceAsync(Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel> ModelQuery = filter == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filter);
                return ModelQuery;
            }
            catch
            {
                throw new InvalidOperationException("Sorry, there was an error while validating the data existence.");
            }

        }

    }

}

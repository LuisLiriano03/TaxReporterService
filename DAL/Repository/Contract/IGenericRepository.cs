using System.Linq.Expressions;

namespace TaxReporter.DAL.Repository.Contract
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> GetEverythingAsync(Expression<Func<TModel, bool>> filter);
        Task<TModel> CreateAsync(TModel model);
        Task<bool> UpdateAsync(TModel model);
        Task<bool> DeleteAsync(TModel model);
        Task<IQueryable<TModel>> VerifyDataExistenceAsync(Expression<Func<TModel, bool>> filter = null);

    }

}

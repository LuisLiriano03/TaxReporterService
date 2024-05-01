using AutoMapper;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Rol;
using TaxReporter.Entities;
using TaxReporter.Exceptions.Rol;
using TaxReporter.Repository.Contract;

namespace TaxReporter.Services
{
    public class RolService : IRolService
    {
        public readonly IGenericRepository<Rol> _rolRepository;
        public readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<List<GetRol>> GetListAsycn()
        {
            try
            {
                var listRols = await _rolRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetRol>>(listRols.ToList());

            }
            catch
            {
                throw new GetRolFailedException();
            }

        }

    }

}

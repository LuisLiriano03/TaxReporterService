using AutoMapper;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Menu;
using TaxReporter.Entities;
using TaxReporter.Exceptions.Menu;
using TaxReporter.Repository.Contract;

namespace TaxReporter.Services
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<UserInfo> _userRepository;
        private readonly IGenericRepository<MenuRol> _menuRolRepository;
        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IGenericRepository<UserInfo> userRepositorio, 
            IGenericRepository<MenuRol> menuRolRepositorio, 
            IGenericRepository<Menu> menuRepositorio, 
            IMapper mapper)
        {
            _userRepository = userRepositorio;
            _menuRolRepository = menuRolRepositorio;
            _menuRepository = menuRepositorio;
            _mapper = mapper;
        }

        public async Task<List<GetMenu>> GetListAsycn(int userId)
        {
            IQueryable<UserInfo> tbUser = await _userRepository.VerifyDataExistenceAsync(u => u.UserId == userId);

            string userExists = !tbUser.Any() ? throw new GetMenuFailedException() : null;

            IQueryable<MenuRol> tbMenuRol = await _menuRolRepository.VerifyDataExistenceAsync();
            IQueryable<Menu> tbMenu = await _menuRepository.VerifyDataExistenceAsync();

            try
            {
                IQueryable<Menu> tbResult = (from u in tbUser
                                                join mr in tbMenuRol on u.RolId equals mr.RolId
                                                join m in tbMenu on mr.MenuId equals m.MenuId
                                                select m).AsQueryable();

                var menuList = tbResult.ToList();

                return _mapper.Map<List<GetMenu>>(menuList);
            }
            catch
            {
                throw new GetMenuErrorException();
            }

        }

    }

}

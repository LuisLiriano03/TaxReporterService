using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaxReporter.Contracts;
using TaxReporter.DTOs.User;
using TaxReporter.Entities;
using TaxReporter.Repository.Contract;

namespace TaxReporter.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserInfo> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<UserInfo> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<List<GetUser>> GetAsync()
        {
            try
            {
                var queryUsuario = await _userRepository.VerifyDataExistenceAsync();
                var listaUsuario = queryUsuario.Include(rol => rol.Rol).ToList();

                return _mapper.Map<List<GetUser>>(listaUsuario);
            }
            catch
            {
                throw;
            }


        }

        public async Task<bool> UpdateAsync(UpdateUser model)
        {
            try
            {
                var userModel = _mapper.Map<UserInfo>(model);
                var userFound = await _userRepository.GetEverythingAsync(u => u.UserId == userModel.UserId);

                if (userFound == null)
                    throw new TaskCanceledException("Error");

                userFound.IdentificationCard = userModel.IdentificationCard;
                userFound.FullName = userModel.FullName;
                userFound.Age = userModel.Age;
                userFound.PhoneNumber = userModel.PhoneNumber;
                userFound.Email = userModel.Email;
                userFound.UserPassword = userModel.UserPassword;
                userFound.RolId = userModel.RolId;
                userFound.JobTitle = userModel.JobTitle;
                userFound.IsActive = userModel.IsActive;

                bool response = await _userRepository.UpdateAsync(userFound);

                if (!response)
                    throw new TaskCanceledException("Error");

                return response;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var userFound = await _userRepository.GetEverythingAsync(u => u.UserId == id);

                if (userFound == null)
                    throw new TaskCanceledException("Error");

                bool response = await _userRepository.DeleteAsync(userFound);

                if (!response)
                    throw new TaskCanceledException("Error");

                return response;
            }
            catch
            {
                throw;
            }
        }

        
    }

}

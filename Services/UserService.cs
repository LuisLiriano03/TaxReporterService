using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaxReporter.Contracts;
using TaxReporter.DTOs.User;
using TaxReporter.Entities;
using TaxReporter.Exceptions.User;
using TaxReporter.Repository.Contract;
using TaxReporter.Validators.User;

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
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery.Include(rol => rol.Rol).ToList();

                return _mapper.Map<List<GetUser>>(listUser);
            }
            catch
            {
                throw new GetUsersFailedException();
            }

        }

        public async Task<bool> UpdateAsync(UpdateUser model)
        {
            try
            {
                var validator = new UpdateUserValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var userModel = _mapper.Map<UserInfo>(model);

                var userFound = await _userRepository.GetEverythingAsync(u => u.UserId == userModel.UserId);

                var userToUpdate = userFound ?? throw new UserNotFoundException();

                userToUpdate.IdentificationCard = userModel.IdentificationCard;
                userToUpdate.FullName = userModel.FullName;
                userToUpdate.Age = userModel.Age;
                userToUpdate.PhoneNumber = userModel.PhoneNumber;
                userToUpdate.Email = userModel.Email;
                userToUpdate.UserPassword = userModel.UserPassword;
                userToUpdate.RolId = userModel.RolId;
                userToUpdate.JobTitle = userModel.JobTitle;
                userToUpdate.IsActive = userModel.IsActive;

                bool response = await _userRepository.UpdateAsync(userToUpdate);

                bool isUpdateSuccessful = !response ? throw new UpdateUserFailedException() : response;

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

                var userDelete = userFound ?? throw new UserNotFoundException();

                bool response = await _userRepository.DeleteAsync(userFound);

                var isDeleteSuccessful = response ? response : throw new DeleteUserFailedException();

                return response;
            }
            catch
            {
                throw new DeleteUserErrorFailedException();
            }

        }
        
    }

}

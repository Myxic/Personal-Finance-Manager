using System;
using Personal_Finance_Manager.Data.Interfaces;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Services.Impentation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User>();
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModel> GetUserById(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return MapUserToModel(user);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(MapUserToModel);
        }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            var user = MapModelToUser(userModel);
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return MapUserToModel(user);
        }

        public async Task<UserModel> UpdateUser(string userId, UserModel userModel)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null)
                throw new FileNotFoundException("User not found");

            MapModelToUser(userModel, existingUser);
            await _unitOfWork.SaveChangesAsync();
            return MapUserToModel(existingUser);
        }

        public async Task DeleteUser(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new FileNotFoundException("User not found");

            await _userRepository.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        private UserModel MapUserToModel(User user)
        {
            return new UserModel
            {
                UserId = user.ID,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                EmailAddress = user.EmailAddress
            };
        }

        private User MapModelToUser(UserModel userModel, User existingUser = null)
        {
            if (existingUser == null)
                existingUser = new User();

            existingUser.ID = userModel.UserId;
            existingUser.UserName = userModel.UserName;
            existingUser.FirstName = userModel.FirstName;
            existingUser.LastName = userModel.LastName;
            existingUser.DOB = userModel.DOB;
            existingUser.EmailAddress = userModel.EmailAddress;

            return existingUser;
        }
    }

}


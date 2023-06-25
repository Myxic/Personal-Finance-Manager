using System;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;

namespace Personal_Finance_Manager.Services.Interface
{
    public interface IUserService
    {
        Task<UserModel> GetUserById(string userId);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> CreateUser(UserModel userModel);
        Task<UserModel> UpdateUser(string userId, UserModel userModel);
        Task DeleteUser(string userId);
    }


}


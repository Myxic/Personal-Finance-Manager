using System;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;

namespace Personal_Finance_Manager.Services.Interface
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> GetGoalsByUserId(string userId);
        Task<Goal> GetGoalById(int goalId);
        Task<Goal> AddGoal(GoalModel goalModel);
        Task<Goal> UpdateGoal(GoalModel goalModel);
        Task DeleteGoal(int goalId);
    }


}


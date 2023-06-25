using System;
using Personal_Finance_Manager.Data.Interfaces;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Services.Impentation
{
    public class GoalService : IGoalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Goal> _goalRepository;

        public GoalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _goalRepository = _unitOfWork.GetRepository<Goal>();
        }

        public async Task<IEnumerable<Goal>> GetGoalsByUserId(string userId)
        {
            return await _goalRepository.GetByAsync(g => g.UserId == userId);
        }

        public async Task<Goal> GetGoalById(int goalId)
        {
            return await _goalRepository.GetByIdAsync(goalId);
        }

        public async Task<Goal> AddGoal(GoalModel goalModel)
        {
            var goal = new Goal
            {
                UserId = goalModel.UserId,
                GoalName = goalModel.GoalName,
                TargetAmount = goalModel.TargetAmount,
                CurrentAmountSaved = goalModel.CurrentAmountSaved,
                TargetDate = goalModel.TargetDate,
                CategoryId = goalModel.CategoryId
            };

            await _goalRepository.AddAsync(goal);
            await _unitOfWork.SaveChangesAsync();

            return goal;
        }

        public async Task<Goal> UpdateGoal(GoalModel goalModel)
        {
            var goal = await _goalRepository.GetByIdAsync(goalModel.GoalID);
            if (goal == null)
            {
                throw new FileNotFoundException("Goal not found");
            }

            goal.UserId = goalModel.UserId;
            goal.GoalName = goalModel.GoalName;
            goal.TargetAmount = goalModel.TargetAmount;
            goal.CurrentAmountSaved = goalModel.CurrentAmountSaved;
            goal.TargetDate = goalModel.TargetDate;
            goal.CategoryId = goalModel.CategoryId;

            await _unitOfWork.SaveChangesAsync();

            return goal;
        }

        public async Task DeleteGoal(int goalId)
        {
            var goal = await _goalRepository.GetByIdAsync(goalId);
            if (goal != null)
            {
                await _goalRepository.DeleteAsync(goal);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                throw new FileNotFoundException("Goal not found");
            }
        }
    }


}


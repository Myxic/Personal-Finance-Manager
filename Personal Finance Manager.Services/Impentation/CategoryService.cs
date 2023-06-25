using System;
using Personal_Finance_Manager.Data.Interfaces;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Services.Impentation
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(MapCategoryToModel);
        }

        public async Task<CategoryModel> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            return MapCategoryToModel(category);
        }

        public async Task<CategoryModel> CreateCategory(CategoryModel categoryModel)
        {
            var category = MapModelToCategory(categoryModel);
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return MapCategoryToModel(category);
        }

        public async Task<CategoryModel> UpdateCategory(int categoryId, CategoryModel categoryModel)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new FileNotFoundException("Category not found");
            }

            category.CategoryName = categoryModel.Name;
            category.Description = categoryModel.Description;

            await _unitOfWork.SaveChangesAsync();

            return MapCategoryToModel(category);
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new FileNotFoundException("Category not found");
            }

            await _categoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        private CategoryModel MapCategoryToModel(Category category)
        {
            return new CategoryModel
            {
                CategoryId = category.CategoryID,
                Name = category.CategoryName,
                Description = category.Description
            };
        }

        private Category MapModelToCategory(CategoryModel categoryModel)
        {
            return new Category
            {
                CategoryID = categoryModel.CategoryId,
                CategoryName = categoryModel.Name,
                Description = categoryModel.Description
            };
        }
    }

}


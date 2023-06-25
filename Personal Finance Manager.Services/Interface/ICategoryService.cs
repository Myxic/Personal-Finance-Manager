using System;
using Personal_Finance_Manager.Model.Enitities;

namespace Personal_Finance_Manager.Services.Interface
{
    public interface ICategoryService
    {
        public interface ICategoryService
        {
            Task<IEnumerable<CategoryModel>> GetCategories();
            Task<CategoryModel> GetCategoryById(int categoryId);
            Task<CategoryModel> CreateCategory(CategoryModel categoryModel);
            Task<CategoryModel> UpdateCategory(int categoryId, CategoryModel categoryModel);
            Task DeleteCategory(int categoryId);
        }

    }

}


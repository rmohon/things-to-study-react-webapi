using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsToStudyAPI.Data;
using ThingsToStudyAPI.Models;

namespace ThingsToStudyAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RepositoryContext _dbcontext;

        public CategoryRepository(RepositoryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable GetCategories()
        {
            return _dbcontext.Categories.ToList();
        }

        public void AddCategory(CategoryModel cat)
        {
            Category ct = new Category();

            ct.CategoryID = cat.CatID;
            ct.CategoryName = cat.CatName;

            _dbcontext.Categories.Add(ct);
            _dbcontext.SaveChanges();
        }

        public void UpdateCategory(CategoryModel cat)
        {
            Category category = _dbcontext.Categories.Single(ct => ct.CategoryID == cat.CatID);

            category.CategoryID = cat.CatID;
            category.CategoryName = cat.CatName;
            
            _dbcontext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _dbcontext.Categories.Remove(_dbcontext.Categories.Where(catID => catID.CategoryID == id).SingleOrDefault());
            _dbcontext.SaveChanges();
        }
    }
}
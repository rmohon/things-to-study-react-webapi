using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ThingsToStudyAPI.Models;

namespace ThingsToStudyAPI.Data
{
    public interface ICategoryRepository
    {
        IEnumerable GetCategories();

        void AddCategory(CategoryModel category);

        void UpdateCategory(CategoryModel category);

        void DeleteCategory(int id);
    }
}
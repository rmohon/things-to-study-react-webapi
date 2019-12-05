using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsToStudyAPI.Data;
using ThingsToStudyAPI.Models;

namespace ThingsToStudyAPI.Repository
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly RepositoryContext _dbcontext;

        public TechnologyRepository(RepositoryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable GetTechnologies()
        {
            return _dbcontext.Technologies.ToList();
        }

        public void AddTechnology(TechnologyModel tech)
        {
            Technology technology = new Technology();

            technology.TechID = tech.TechID;
            technology.TechName = tech.TechName;
            technology.Category = tech.CatName;
            technology.TechDescription = tech.TechDes;
            technology.TechURL = tech.TechURL.ToString();

            _dbcontext.Technologies.Add(technology);
            _dbcontext.SaveChanges();
        }

        public void UpdateTechnology(TechnologyModel tech)
        {
            Technology technology = _dbcontext.Technologies.First(t => t.TechID == tech.TechID);

            technology.TechID = tech.TechID;
            technology.TechName = tech.TechName;
            technology.Category = tech.CatName;
            technology.TechDescription = tech.TechDes;
            technology.TechURL = tech.TechURL.ToString();

            _dbcontext.SaveChanges();
        }

        public void DeleteTechnology(int id)
        {
            _dbcontext.Technologies.Remove(_dbcontext.Technologies.Where(tech => tech.TechID == id).SingleOrDefault());
            _dbcontext.SaveChanges();
        }
    }
}
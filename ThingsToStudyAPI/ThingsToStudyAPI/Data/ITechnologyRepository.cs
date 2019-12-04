using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsToStudyAPI.Models;

namespace ThingsToStudyAPI.Data
{
    public interface ITechnologyRepository
    {
        IEnumerable GetTechnologies();

        void AddTechnology(TechnologyModel tech);

        void UpdateTechnology(TechnologyModel tech);

        void DeleteTechnology(int id);
    }
}
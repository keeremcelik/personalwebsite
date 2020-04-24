using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface IProjectRepository
    {
        Project GetById(int projectId);
        IQueryable<Project> GetAll();
        void AddProject(Project project);
        void DeleteProject(int projectId);
        void SaveProject(Project project);
    }
}

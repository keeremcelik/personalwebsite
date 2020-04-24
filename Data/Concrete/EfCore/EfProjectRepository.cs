using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfProjectRepository : IProjectRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfProjectRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public void DeleteProject(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public IQueryable<Project> GetAll()
        {
            return _context.Projects;
        }

        public Project GetById(int projectId)
        {
            return _context.Projects.FirstOrDefault(p => p.ProjectId==projectId);

        }

        public void SaveProject(Project project)
        {
            if (project.ProjectId == 0)
            {
                _context.Projects.Add(project);
            }
            else
            {
                var data = GetById(project.ProjectId);
                if (data != null)
                {
                    data.Type = project.Type;
                    data.Name = project.Name;
                    data.SefUrl = project.SefUrl;
                    data.Content = project.Content;
                    data.CoverImage = project.CoverImage;
                    data.Image = project.Image;
                    data.Date = DateTime.Now;
                    data.infrastructure = project.infrastructure;
                    data.Keywords = project.Keywords;
                    data.Status = project.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}
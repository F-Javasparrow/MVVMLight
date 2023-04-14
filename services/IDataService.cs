using MVVMLight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight.services
{
    public interface IDataService
    {
        public List<Project> GetAllProjects();
        public List<Project> GetProjects(string fileName);
    }
}

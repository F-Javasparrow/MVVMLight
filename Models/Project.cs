using System;
using System.Collections.Generic;

namespace MVVMLight.Models
{
    [Serializable]
    public class Project
    {
        public Project(string projectName, List<Setting> settings)
        {
            this.ProjectName = projectName;
            this.Settings = settings;
        }

        public List<Setting> GetSettings()
        {
            return Settings;
        }

        public string ProjectName { get; set; }
        private List<Setting> Settings { get; set; }
        public Setting ServerName { get; set; }
        public Setting ServerPort { get; set; }
    }
}

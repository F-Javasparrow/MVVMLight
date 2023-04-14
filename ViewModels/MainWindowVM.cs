using MVVMLight.Models;
using MVVMLight.services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;

namespace MVVMLight.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        public MainWindowVM()
        {
            projects = new List<Project>();
            Projects = new XmlDataService().GetAllProjects();

            if(SelectedProject == null)
            {
                SelectedProject = projects[0];
                SettingList = SelectedProject.GetSettings();
            }
        }

        private Project selectedProject;
        public Project SelectedProject
        {
            get => selectedProject;
            set
            {
                selectedProject = value;
                SettingList = SelectedProject.GetSettings();
                this.RaisePropertyChanged(nameof(SelectedProject));
            }
        }

        private List<Project> projects;
        public List<Project> Projects
        {
            get => projects;
            set
            {
                projects = value;
                this.RaisePropertyChanged(nameof(Projects));
            }
        }

        private List<Setting> settingList;

        public List<Setting> SettingList
        {
            get => settingList;
            set
            {
                settingList = value;
                this.RaisePropertyChanged(nameof(SettingList));
            }
        }

        
    }
}

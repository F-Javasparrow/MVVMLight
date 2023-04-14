using MVVMLight.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Markup;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MVVMLight.services
{
    public class XmlDataService : IDataService
    {
        public List<Project> GetAllProjects()
        {
            string xmlFileName = Path.Combine(Environment.CurrentDirectory, @"Data\Projects.xml");

            return GetProjects(xmlFileName);
        }

        public List<Project> GetProjects(string fileName)
        {
            List<Project> projectList = new List<Project>();

            XDocument xDoc = XDocument.Load(fileName);
            var projects = xDoc.Descendants("Project").ToArray();

            foreach ( var p in projects )
            {
                string projectName = "";
                List<Setting> settingList = new List<Setting>();

                foreach (var e in p.Elements())
                {
                    Setting setting = new Setting();
                    if (ParseSetting(e, out setting))
                    {
                        settingList.Add(setting);
                    }
                    if (e.Name.ToString() == "ProjectName")
                    {
                        projectName = e.Value;
                    }
                }

                projectList.Add(new Project(projectName, settingList));
            }

            return projectList;
        }

        public void SaveProjects(List<Project> projects)
        {
            var serializer = new XmlSerializer(typeof(List<Project>));
            var files = new FileStream(@"Data\Projects.xml", FileMode.Create);
            serializer.Serialize(files, projects);
            files.Close();
        }

        private bool ParseSetting(XElement? element, out Setting setting)
        {
            setting = new Setting();

            if (element != null && element.Name.ToString() == "Setting")
            {
                if(element.Attribute("Type").Value == "Str")
                {
                    setting.SettingName = element.Attribute("Name").Value;
                    setting.SettingValue = element.Attribute("Value").Value;
                }
                return true;
            }

            return false;
        }
    }
}

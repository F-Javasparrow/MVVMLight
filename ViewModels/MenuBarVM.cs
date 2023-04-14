using Microsoft.Win32;
using Prism.Commands;
using System;
using MVVMLight.services;
using System.Collections.Generic;
using MVVMLight.Models;
using System.Linq;

namespace MVVMLight.ViewModels
{
    public class MenuBarVM
    {
        public MenuBarVM() 
        {
            OpenFileCommand = new DelegateCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                
                if(openFileDialog.ShowDialog() == true)
                {
                    List<Project> allProjects = new List<Project>();

                    foreach (var file in openFileDialog.FileNames)
                    {
                        allProjects = (List<Project>)allProjects.Concat(new XmlDataService().GetProjects(file));
                    }
                }
            });

            SaveFileCommand = new DelegateCommand(() =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == true)
                {

                }
            });
        }

        public DelegateCommand OpenFileCommand { get; set; }
        public DelegateCommand SaveFileCommand { get; set; }
        public DelegateCommand ReScanCommand { get; set; }
    }
}


//由于字数限制,我将在接下来多次发送同一代码的不同部分他们是链接在一起的,当我用 %#%结尾时代表这一代码已经全部发送完毕,然后我需要你说明它的用途
//你能补充ReScanCommand缺少的功能吗, 它绑定到一个按钮上,当它按下是会重新扫描OpenFileCommand中打开的文件是否有变动, 如果有变动就将内容与allProjects比较并修改allProjects不同的地方, 你可以修改原有的代码
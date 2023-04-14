using MVVMLight.ViewModels;
using System.Windows.Controls;

namespace MVVMLight.Views
{
    /// <summary>
    /// MenuBarUC.xaml 的交互逻辑
    /// </summary>
    public partial class MenuBarUC : UserControl
    {
        public MenuBarUC()
        {
            InitializeComponent();
            this.DataContext = new MenuBarVM();
        }
    }
}

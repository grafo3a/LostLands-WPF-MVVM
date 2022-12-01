using Caliburn.Micro;
using LostLands_WPF_MVVM.ViewModels;
using System.Windows;

namespace LostLands_WPF_MVVM;


internal class Bootstrapper : BootstrapperBase
{
    public Bootstrapper()
    {
        Initialize();
    }


    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        //base.OnStartup(sender, e);
        DisplayRootViewForAsync<ShellViewModel>();
    }
}

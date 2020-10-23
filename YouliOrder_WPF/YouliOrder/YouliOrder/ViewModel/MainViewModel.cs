using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using YouliOrder.View;

namespace YouliOrder.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Modules = new List<Module>();
            Modules.Add(new Module() { Name = "�ͻ��µ�" });
            Modules.Add(new Module() { Name = "��������" });
            Modules.Add(new Module() { Name = "�����ӵ�" });

            Page = new Page1();
            OpenCommand = new RelayCommand<string>(t => OpenPage(t)); //������Ӧ
        }

        private void OpenPage(string Name)
        {
            switch(Name)
            {
                case "�ͻ��µ�":  Page = new Page1(); 
                    break;
                case "��������": Page = new Page2(); 
                    break;
                case "�����ӵ�": Page = new Page3();
                    break;

            }
        }

        public List<Module> Modules { get; set; }

        public RelayCommand<string> OpenCommand { get; set; }
        private object page;
        public object Page
        {
            get
            {
                return page;
            }
            set { page = value;RaisePropertyChanged(); }
        }
    }
}
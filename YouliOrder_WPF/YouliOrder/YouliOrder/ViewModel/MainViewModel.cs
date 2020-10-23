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
            Modules.Add(new Module() { Name = "客户下单" });
            Modules.Add(new Module() { Name = "订单汇总" });
            Modules.Add(new Module() { Name = "工厂接单" });

            Page = new Page1();
            OpenCommand = new RelayCommand<string>(t => OpenPage(t)); //按键响应
        }

        private void OpenPage(string Name)
        {
            switch(Name)
            {
                case "客户下单":  Page = new Page1(); 
                    break;
                case "订单汇总": Page = new Page2(); 
                    break;
                case "工厂接单": Page = new Page3();
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
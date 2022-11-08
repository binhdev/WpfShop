﻿using FontAwesome.Sharp;
using System.Windows;
using System.Windows.Input;

namespace WpfShop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        public ICommand ShowProductViewCommand { get; }
        public ICommand ShowCategoryViewCommand { get; }
        public ICommand ShowOrderViewCommand { get; }

        public MainViewModel()
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);
            ShowProductViewCommand = new ViewModelCommand(ExecuteShowProductViewCommand);
            ShowCategoryViewCommand = new ViewModelCommand(ExecuteShowCategoryViewCommand);
            ShowOrderViewCommand = new ViewModelCommand(ExecuteShowOrderViewCommand);
            //Default view
            ExecuteShowHomeViewCommand(null);

        }
        private void ExecuteShowUserViewCommand(object obj)
        {
            CurrentChildView = new UserViewModel();
            Caption = "Users";
            Icon = IconChar.User;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
        private void ExecuteShowProductViewCommand(object obj)
        {
            CurrentChildView = new ProductViewModel();
            Caption = "Products";
            Icon = IconChar.ShoppingBag;
        }
        private void ExecuteShowCategoryViewCommand(object obj)
        {
            CurrentChildView = new CategoryViewModel();
            Caption = "Categories";
            Icon = IconChar.Box;
        }
        private void ExecuteShowOrderViewCommand(object obj)
        {
            CurrentChildView = new OrderViewModel();
            Caption = "Orders";
            Icon = IconChar.Truck;
        }
    }
}

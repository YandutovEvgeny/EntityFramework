using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestaurantEntity.Models;
using RestaurantEntity.Views;

namespace RestaurantEntity.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string _login;
        string _pass;
        DataBaseRestaurant _restaurant;

        public LoginViewModel()
        {
            Login = "";
            Pass = "";
            _restaurant = new DataBaseRestaurant();
        }

        public Commands RegistrationClick
        {
            get
            {
                return new Commands(new Action(() =>
                {
                    RegistrationView registration = new RegistrationView();
                    registration.ShowDialog();
                }));
            }
        }
        public Commands LoginClick
        {
            get
            {
                return new Commands(new Action(() =>
                {
                    User user = _restaurant.CheckLogin(_login, _pass);
                    if (user != null)
                    {
                        RestMenu restMenu = new RestMenu();
                        restMenu.Show();
                    }
                }), 
                new Func<bool>(() => { return _login != "" && _pass != ""; }));
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                Notify("Login");
            }
        }

        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                Notify("Pass");
            }
        }
    }
}

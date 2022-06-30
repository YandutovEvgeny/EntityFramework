using RestaurantEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantEntity.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string _login;
        string _pass;
        string _name;
        DataBaseRestaurant _restaurant;

        public RegistrationViewModel()
        {
            Login = "";
            Pass = "";
            Name = "";
            _restaurant = new DataBaseRestaurant();
        }

        public Commands RegClick
        {
            get
            {
                //obj - параметр, котороый мы биндим в RegistrationView
                return new Commands(new Action<object>((obj) =>
                {
                    _restaurant.NewUser(new User()
                    {
                        Login = _login,
                        Pass = _pass,
                        Name = _name
                    });
                    Window window = (Window)obj;
                    window.Close();
                }));
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
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }
    }
}

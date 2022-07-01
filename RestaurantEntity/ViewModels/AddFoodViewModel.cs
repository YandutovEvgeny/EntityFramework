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
    class AddFoodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        Menu _menu;
        UserContext _context;

        public AddFoodViewModel()
        {
            _menu = new Menu();
        }

        public Menu AddMenu
        {
            get { return _menu; }
            set
            {
                _menu = value;
                Notify("AddMenu");
            }
        }

        public Commands AddButtonClick
        {
            get
            {
                return new Commands(
                    new Action<object>((obj) =>
                    {
                        _context = new UserContext();
                        _context.RestaurantMenu.Add(_menu);
                        _context.SaveChanges();
                        Window window = (Window)obj;
                        window.Close();
                    }),
                    new Func<bool>(() =>
                    {
                        return _menu.Name != "" && _menu.Photo != "" && _menu.Price != 0;
                    }));
            }
        }
    }
}

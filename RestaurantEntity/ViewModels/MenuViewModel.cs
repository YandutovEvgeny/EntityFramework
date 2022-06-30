using RestaurantEntity.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.ViewModels
{
    class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //В MVVM нельзя использовать чистый List, поэтому:
        ObservableCollection<string> _categories;
        UserContext _context;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MenuViewModel()
        {
            _context = new UserContext();
            _categories = new ObservableCollection<string>();
            foreach(Category category in _context.Categories)
            {
                Categories.Add(category.Name);
            }
            Notify("Categories");
        }

        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                Notify("Categories");
            }
        }
    }
}

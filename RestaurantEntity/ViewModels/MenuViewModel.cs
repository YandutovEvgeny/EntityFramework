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

        //В MVVM не стоит использовать чистый List при биндинге, поэтому:
        ObservableCollection<string> _categories;
        ObservableCollection<string> _menuNames;
        List<Menu> _menu;
        UserContext _context;
        string _selectedCategory;
        int _selectedId;
        string _name;
        int _price;
        string _url;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MenuViewModel()
        {
            _context = new UserContext();
            _categories = new ObservableCollection<string>();
            _menuNames = new ObservableCollection<string>();
            _menu = new List<Menu>();

            Categories.Add("нет");
            foreach(Category category in _context.Categories)
            {
                Categories.Add(category.Name);
            }
            SelectedCategory = "нет";
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
        public ObservableCollection<string> MenuNames
        {
            get { return _menuNames; }
            set
            {
                _menuNames = value;
                Notify("MenuNames");
            }
        }
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (_selectedCategory != "нет")
                {
                    Category category = (from i in _context.Categories
                                         where i.Name == _selectedCategory
                                         select i).FirstOrDefault();
                    _menu = (from x in _context.RestaurantMenu
                             where x.Category.Id == category.Id
                             select x).ToList();
                }
                else 
                    _menu = _context.RestaurantMenu.ToList();
                
                SelectedId = 0;
                MenuNames.Clear();
                foreach(Menu menu in _menu)
                {
                    _menuNames.Add(menu.Name);
                }
                Notify("SelectedCategory");
            }
        }
        public int SelectedId
        {
            get { return _selectedId; }
            set
            {
                _selectedId = value;
                if (_selectedId != -1)
                {
                    Name = _menu[_selectedId].Name;
                    Price = _menu[_selectedId].Price;
                    Url = _menu[_selectedId].Photo; 
                }
                Notify("SelectedId");
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
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                Notify("Price");
            }
        }
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                Notify("Url");
            }
        }

        public Commands AddClick
        {
            get 
            {
                return new Commands(new Action(() =>
                {
                    AddFood addFood = new AddFood();
                    addFood.ShowDialog();
                    _selectedCategory = "нет";
                }));
            }
        }
    }
}

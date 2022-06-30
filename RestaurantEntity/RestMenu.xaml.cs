using RestaurantEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantEntity
{
    /// <summary>
    /// Interaction logic for RestMenu.xaml
    /// </summary>
    public partial class RestMenu : Window
    {
        public RestMenu()
        {
            InitializeComponent();
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category() { Name = "Десерты" };
            UserContext context = new UserContext();
            context.Categories.Add(category);
            context.SaveChanges();

            Models.Menu menu = new Models.Menu()
            {
                Category = category, 
                Name = "Медовик", 
                Photo = "https://avatars.mds.yandex.net/i?id=afb5eb62df6d757f824aa14aca127b38-5916170-images-thumbs&n=13", 
                Price = 50 
            };
            context.RestaurantMenu.Add(menu);
            context.SaveChanges();
        }*/
    }
}

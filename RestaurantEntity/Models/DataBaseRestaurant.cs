using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Models
{
    class DataBaseRestaurant
    {
        UserContext context;
        public DataBaseRestaurant()
        {
            context = new UserContext();
        }
        public User CheckLogin(string login, string pass)
        {
            User _user = (from user in context.Users
                          where user.Login == login && user.Pass == pass
                          select user).FirstOrDefault();
            return _user;
        }
    }
}

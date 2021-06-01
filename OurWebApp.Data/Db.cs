using System;
using System.Collections.Generic;

namespace OurWebApp.Data
{
    public class Db
    {
        public static List<Dessert> Desserts
        {
            get
            {
                return new List<Dessert>
                {
                    new Dessert{Title= "Ice Cream", Price = 6.05m},
                    new Dessert{Title= "Froyo", Price = 5.05m}
                };
            }
        }
    }
}

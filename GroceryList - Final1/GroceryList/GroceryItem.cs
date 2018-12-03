using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GroceryList.Shared
{
    public class GroceryItem
    {
        public GroceryItem()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }


    }
}
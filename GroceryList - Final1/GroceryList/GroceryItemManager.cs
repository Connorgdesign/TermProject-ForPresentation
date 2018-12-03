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
    public class GroceryItemManager
    {
        static GroceryItemManager()
        {
        }

        public static GroceryItem GetGrocery(int id)
        {
            return GroceryListRepository.GetGrocery(id);
        }

        public static IList<GroceryItem> GetGroceries()
        {
            return new List<GroceryItem>(GroceryListRepository.GetGroceries());
        }

        public static int SaveGrocery(GroceryItem item)
        {
            return GroceryListRepository.SaveGrocery(item);
        }

        public static int DeleteGrocery(int id)
        {
            return GroceryListRepository.DeleteGrocery(id);
        }

        internal static GroceryListAdapter GetGrocery()
        {
            throw new NotImplementedException();
        }
    }
}
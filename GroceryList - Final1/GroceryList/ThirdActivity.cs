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
    [Activity(Label = "ThirdActivity")]
    public class ThirdActivity : Activity
    {
        GroceryListAdapter groceryList;
        IList<GroceryItem> groceries;
        TextView numberOfItems;
        TextView beverageNumber;
        TextView dairyNumber;
        TextView vegetablesNumber;
        TextView fruitNumber;
        TextView meatNumber;
        Button clearList;
        TextView totalPrice;
        ListView taskListView;
        string imageName;
        int number;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Third);

            numberOfItems = FindViewById<TextView>(Resource.Id.numberOfItems);
            beverageNumber = FindViewById<TextView>(Resource.Id.beverageNumber);
            dairyNumber = FindViewById<TextView>(Resource.Id.dairyNumber);
            vegetablesNumber = FindViewById<TextView>(Resource.Id.vegetablesNumber);
            fruitNumber = FindViewById<TextView>(Resource.Id.fruitNumber);
            meatNumber = FindViewById<TextView>(Resource.Id.meatNumber);
            totalPrice = FindViewById<TextView>(Resource.Id.totalPrice);

            clearList = FindViewById<Button>(Resource.Id.clearList);

            groceries = GroceryItemManager.GetGroceries();

            number = groceries.Count;
            numberOfItems.Text = number.ToString();
            //Toast.MakeText(this, number.ToString(), ToastLength.Long).Show();
            groceryList = new GroceryListAdapter(this, groceries);

            List<string> beverages = new List<string>();
            List<string> dairy = new List<string>();
            List<string> vegetables = new List<string>();
            List<string> fruit = new List<string>();
            List<string> meat = new List<string>();
            List<int> prices = new List<int>();

            string[] array = new string[groceries.Count];
            int i = 0;
            foreach (GroceryItem a in groceries)
            {
                prices.Add(groceries[i].Price);

                if (groceries[i].Type == "Beverages")
                {
                    beverages.Add(groceries[i].Name);

                }
                else if (groceries[i].Type == "Dairy")
                {

                    dairy.Add(groceries[i].Name);

                }
                else if (groceries[i].Type == "Vegetables")
                {
                    vegetables.Add(groceries[i].Name);

                }
                else if (groceries[i].Type == "Fruit")
                {
                    fruit.Add(groceries[i].Name);

                }
                else if (groceries[i].Type == "Meat")
                {
                    meat.Add(groceries[i].Name);

                }
                else
                {
                    array[i] = groceries[i].Type;
                }

                i++;
            }

            int t = 0;
            foreach (int price in prices)
            {
                t = t + price;
            }
            string p = t.ToString();
            p = "$" + p;
            beverageNumber.Text = beverages.Count.ToString();
            dairyNumber.Text = dairy.Count.ToString();
            vegetablesNumber.Text = vegetables.Count.ToString();
            fruitNumber.Text = fruit.Count.ToString();
            meatNumber.Text = meat.Count.ToString();
            totalPrice.Text = p.ToString();

           

            //Hook up our adapter to our ListView

            clearList.Click += delegate {


                foreach (GroceryItem a in groceries)
                {
                    GroceryItemManager.DeleteGrocery(a.ID);
                }
                numberOfItems.Text = "0";
                beverageNumber.Text = "0";
                dairyNumber.Text = "0";
                vegetablesNumber.Text = "0";
                fruitNumber.Text = "0";
                meatNumber.Text = "0";
                totalPrice.Text = "$0";

                Toast.MakeText(this, "All items have been removed", ToastLength.Long).Show();


            };



        }
    }
}
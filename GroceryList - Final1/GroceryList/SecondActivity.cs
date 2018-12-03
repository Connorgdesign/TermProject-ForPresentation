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
using Mono.Data.Sqlite;
using SQLite;
using GroceryList.Shared;
using System.IO;
using static Android.Widget.AdapterView;

namespace GroceryList
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        ImageView type;
        GroceryListAdapter groceryList;
        GroceryItem grocery;
        IList<GroceryItem> groceries;
        TextView noListItemText;
        GroceryItemManager g;
        GroceryItem m;
        ListView taskListView;
        string imageName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Second);




            taskListView = FindViewById<ListView>(Resource.Id.TaskList);

            //type = FindViewById<ImageView>(Resource.Id.typeImage);

            groceries = GroceryItemManager.GetGroceries();

            noListItemText = FindViewById<TextView>(Resource.Id.noListItemText);

            taskListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                var test = groceries[e.Position];
                var b = test.Price.ToString();
                b = "$" + b;
                
                Toast.MakeText(this, b.ToString(), ToastLength.Long).Show();
            };

            if (groceries.Count > 0)
            {
                noListItemText.Text = "Grocery List Items";
            }
            else
            {
                noListItemText.Text = "Your grocery list is empty";
            }

            groceryList = new GroceryListAdapter(this, groceries);
            /*int id = groceries[1].ID;
            //var type = groceries[id].Type;
            grocery = GroceryItemManager.GetGrocery(id);


            string[] array = new string[groceries.Count];
            int i = 0;
            foreach (GroceryItem a in groceries)
            {
                array[i] = groceries[i].Type;
                i++;
            }*/

            //Toast.MakeText(this, array[2].ToString(), ToastLength.Long).Show();

            // create our adapter
            groceryList = new GroceryListAdapter(this, groceries);






            //Hook up our adapter to our ListView
            taskListView.Adapter = groceryList;
        }


    }
}
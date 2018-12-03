using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using GroceryList.Shared;
using Android.Content;
using System;

namespace GroceryList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        GroceryListAdapter groceryList;
        IList<GroceryItem> groceries;

        Button addGroceryButton;
        TextView t;
        Button viewListButton;
        Button moreButton;
        ListView taskListView;
        EditText itemName;
        EditText itemPrice;
        GroceryItem grocery = new GroceryItem();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

         


            addGroceryButton = FindViewById<Button>(Resource.Id.enterItemButton);
            viewListButton = FindViewById<Button>(Resource.Id.viewButton);
            moreButton = FindViewById<Button>(Resource.Id.moreButton);
            itemName = FindViewById<EditText>(Resource.Id.groceryItemEdit);
            itemPrice = FindViewById<EditText>(Resource.Id.priceItemEdit);
      
 

            string[] types = { "Beverages", "Dairy", "Meat", "Vegetables", "Fruit" };

            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, types);

            var tideSpinner = FindViewById<Spinner>(Resource.Id.spinner1);
            tideSpinner.Adapter = adapter;

            // Event handler for selected spinner item
            string selectedType = "";
            tideSpinner.ItemSelected += delegate (object sender, AdapterView.ItemSelectedEventArgs e) {
                Spinner spinner = (Spinner)sender;
                selectedType = (string)spinner.GetItemAtPosition(e.Position);
            };

            viewListButton.Click += delegate {
                var second = new Intent(this, typeof(SecondActivity));
                StartActivity(second);
            };



            addGroceryButton.Click += delegate {
                //var second = new Intent(this, typeof(SecondActivity));

                if (itemName.Text == "" || itemPrice.Text == "")
                {
                    Toast.MakeText(this, "Please fill out all the fields", ToastLength.Long).Show();
                }
                else
                {
                    grocery.Name = itemName.Text;
                    grocery.Type = selectedType;
                    grocery.Price = int.Parse(itemPrice.Text);
                    GroceryItemManager.SaveGrocery(grocery);
                    //Finish();
                    //get the date in a string format that matches the database
                    Toast.MakeText(this, "Grocery Item " + itemName.Text + " was entered", ToastLength.Long).Show();
                    // StartActivity(second);
                }
            };

            moreButton.Click += delegate {
                var third = new Intent(this, typeof(ThirdActivity));
                StartActivity(third);
            };

        }

    }
}
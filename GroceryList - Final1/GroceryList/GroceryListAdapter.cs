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
using GroceryList.Shared;
using Java.Lang;

namespace GroceryList
{
    public class GroceryListAdapter : BaseAdapter<GroceryItem>, ISectionIndexer
    {
        Activity context = null;
        IList<GroceryItem> groceries = new List<GroceryItem>();

        public GroceryListAdapter(Activity context, IList<GroceryItem> groceries) : base()
        {
            this.context = context;
            this.groceries = groceries;
        }

        public override GroceryItem this[int position]
        {
            get { return groceries[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return groceries.Count; }
        }

        public string Countt
        {
            get { return groceries[1].Type; }
        }

        public string GetItemType(int position) {
            var item = groceries[position];
            return item.Type;
        }

     
        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {

            var item = groceries[position];

            View view = convertView;
            if (view == null) 
                view = context.LayoutInflater.Inflate(Resource.Layout.List_Item, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Name;
            return view;

            
        }

        public int GetPositionForSection(int sectionIndex)
        {
            throw new NotImplementedException();
        }

        public int GetSectionForPosition(int position)
        {
            throw new NotImplementedException();
        }

        public Java.Lang.Object[] GetSections()
        {
            throw new NotImplementedException();
        }
    }
}
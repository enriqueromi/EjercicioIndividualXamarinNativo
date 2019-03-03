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
using static App1.ActivitiLista;

namespace App1.Adapters
{
    class ListAdapters : BaseAdapter<Post>
    {
        private Activity context;
        private IRepositoryPost newPosts;

        public ListAdapters(Activity context, IRepositoryPost newPosts)
        {
            this.context = context;
            this.newPosts = newPosts;
        }

        public override Post this[int position] => newPosts.listaPost[position];

        public override int Count => newPosts.listaPost.Count;

        public override long GetItemId(int position)
        {
            return this[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];
            if(convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ListPostRow, null);
            }
            convertView.FindViewById<TextView>(Resource.Id.userId).Text = item.userId.ToString();
            convertView.FindViewById<TextView>(Resource.Id.title).Text = item.title;

            return convertView;
        }
    }
}
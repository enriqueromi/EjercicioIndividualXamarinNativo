using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Adapters;
using Newtonsoft.Json;

namespace App1
{
    [Activity(Label = "ActivitiLista", MainLauncher = true , Theme = "@style/AppTheme.NoActionBar")]
    public class ActivitiLista : Activity
    {
      
        private ListView listView;
        private Post listaPost;


        private void conexionLista()
        {
            
            listaPost = new Post();

            listView = FindViewById<ListView>(Resource.Id.listView1);

            listView.Adapter = new ListAdapters(this,listaPost);

            listView.ItemClick += SelectList;
        }
        

        private void SelectList(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MostrarLista));
            var id = (int)e.Id;
            intent.PutExtra(MostrarLista.key_id, id);
            StartActivity(intent);

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListPost);

            conexionLista();


        }
    }
}
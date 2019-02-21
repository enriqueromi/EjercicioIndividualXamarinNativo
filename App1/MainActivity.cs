using System;
using System.Collections.ObjectModel;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public class Post
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }

            public override string ToString()
            {
                return userId + " " + title;
            }

        }

        private const String url = "https://jsonplaceholder.typicode.com/posts";
        private List<Post> listaPost;
        private HttpClient HttpClient = new HttpClient();
        private ListView listView;
        
        


        private async void conexionJson()
        {
            
            var contenidoJson = await HttpClient.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Post>>(contenidoJson);
            listaPost = new List<Post>(post);

            listView = FindViewById<ListView>(Resource.Id.listView1);
            
            listView.Adapter = new ArrayAdapter<Post>(this, Android.Resource.Layout.SimpleListItem1, listaPost);

            listView.ItemClick += SelectList;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            conexionJson();

            SetContentView(Resource.Layout.activity_main);

            PrepareActionBar();

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            
        }

        private void PrepareActionBar()
        {
            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnResume()
        {
            base.OnResume();


        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        private void SelectList(object sender, AdapterView.ItemClickEventArgs args)
        {
            SetContentView(Resource.Layout.ContenidoPost);
        }


        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}


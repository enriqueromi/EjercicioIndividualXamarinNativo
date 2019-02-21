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
        public ActivitiLista()
        {
            conexionJson();
        }
      
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

        public Post GetPostById(int id)
        {
            
            return listaPost.FirstOrDefault(x => x.id == id);
        }

    
        private async void conexionJson()
        {

            var contenidoJson = await HttpClient.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Post>>(contenidoJson);
            listaPost = new List<Post>(post);

            listView = FindViewById<ListView>(Resource.Id.listView1);

            listView.Adapter = new ListAdapters(this,listaPost);

            listView.ItemClick += SelectList;
        }
        

        private void SelectList(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            var id = (int)e.Id;
            intent.PutExtra(MainActivity.key_id, id);
            StartActivity(intent);

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListPost);

            conexionJson();


        }
    }
}
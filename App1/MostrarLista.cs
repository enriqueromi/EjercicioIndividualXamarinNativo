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
using Android.Content;
using static App1.ActivitiLista;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MostrarLista : AppCompatActivity
    {
        internal const string key_id = "key_id";

        //Vuelvo a instanciar aquí o en su defecto creo un Repository post estatico para toda la app.
        private IRepositoryPost repositoryPost;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListPost);

            var id = Intent.Extras.GetInt(key_id);
            repositoryPost = new RepositoryPosts();

            var postlista = new Post();
            var post = repositoryPost.GetPostById(id);

            var titulo = FindViewById<TextView>(Resource.Id.tituloPost);
            var contenido = FindViewById<TextView>(Resource.Id.ContenidoPost);

            titulo.Text = post.title.ToString();
            contenido.Text = post.body.ToString();
            
        }


	}
}


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
using Newtonsoft.Json;

namespace App1
{
    //Es aquí donde debes implementar el repositorio
    public class RepositoryPosts : IRepositoryPost
    {
        private const String url = "https://jsonplaceholder.typicode.com/posts";
        public List<Post> listaPost { get; set; }
        private HttpClient HttpClient = new HttpClient();

        public RepositoryPosts()
        {
            conexionJson();
           
        }

        public Post GetPostById(int id)
        {
            return listaPost.SingleOrDefault(x => x.id == id);
        }

        public List<Post> ListPost()
        {
            conexionJson();
            return listaPost;
        }

        
        //Problema no ejecuta este metodo
        public  async void conexionJson()
        {
            var contenidoJson = await HttpClient.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Post>>(contenidoJson);
            listaPost = new List<Post>(post);
        }
    }
}
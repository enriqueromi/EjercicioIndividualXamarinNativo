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
    public class Post 
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        private const String url = "https://jsonplaceholder.typicode.com/posts";
        public List<Post> listaPost { get; set; }
        private HttpClient HttpClient = new HttpClient();



        //Esto se que se tiene que poner en el repositorio
        public Post()
        {
            conexionJson();
        }

        private async void conexionJson()
        {
            var contenidoJson = await HttpClient.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Post>>(contenidoJson);
            listaPost = new List<Post>(post);
        }

        public Post GetPostById(int id)
        {

            return listaPost.FirstOrDefault(x => x.id == id);
        }
    }
}
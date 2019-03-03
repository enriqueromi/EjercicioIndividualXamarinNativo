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

namespace App1
{
    //Es aquí donde debes implementar el repositorio
    public class RepositoryPosts : IRepositoryPost
    {
        public string url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Post> listaPost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Post GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> Post()
        {
            throw new NotImplementedException();
        }
    }
}
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

namespace App1
{
    interface IRepositoryPost 
    {
        String url { get; set; }
        List<Post> listaPost { get; set; }

        //El repositorio debe ser agnostico de como se obtienen los datos. Por lo que no debemos exponer un httpclient. Puede que se obtengan 
        //de otro lugar.
        //HttpClient httpClient { get; set; }

        List<Post> Post();

         Post GetPostById(int id);

    }
}
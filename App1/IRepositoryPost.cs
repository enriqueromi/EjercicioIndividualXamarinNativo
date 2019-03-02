﻿using System;
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
        HttpClient httpClient { get; set; }

        List<Post> Post();

         Post GetPostById(int id);

    }
}
﻿using EloBuddy.SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindred
{
    class Program
    {
        static void Main(string[] args)
        {
            Addon ad = new Addon();
            Loading.OnLoadingComplete += ad.Load;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers.Resources
{
    public class ServerOnlineResource
    {
        public bool ServerUp { get; set; }
        public long Time { get; set; }
    }
}
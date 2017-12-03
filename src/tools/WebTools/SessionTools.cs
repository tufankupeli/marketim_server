using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace WebTools
{
    public class SessionTools
    {
        private SessionTools()
        {
        }

        public static object GetSessionValue(string key){

            HttpContext.Session.GetInt32("test")

            return 5;
        }

    }
}

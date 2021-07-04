using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backend.Tools
{
    public class WebApiClass
    {
        static async Task Main(string[] args) 
        {
            var url = "https://api.toka.com.mx/candidato/api/login/authenticate";

            using (var http = new HttpClient()) 
            {
                var key = new keysClass() { Username = "ucand0021", Password = "yNDVARG80sr@dDPc2yCT!" };

            }
            
            
            }

        }

    }
}

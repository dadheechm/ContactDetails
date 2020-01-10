using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Management.Common.Consumable
{
    public class WebAddress
    {

        public WebAddress()
        {
        }
        public static string GetWebAddress()
        {
            return System.Configuration.ConfigurationManager.AppSettings["BaseURL"].ToString();
        }

    }

   
}

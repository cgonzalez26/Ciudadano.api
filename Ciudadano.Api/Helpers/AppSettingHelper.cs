using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ciudadano.Api.Helpers
{
    public class AppSettingHelper
    {
        private static AppSettingHelper _instance;
        private readonly IConfiguration _configuration;

        public AppSettingHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static AppSettingHelper Instance(IConfiguration configuration) => _instance ?? (_instance = new AppSettingHelper(configuration));

        public string GetGlobalChannel()
        {
            return _configuration["Google:Fcm:GlobalChannel"];
        }

        public string GetWebAppChannel()
        {
            return _configuration["Google:Fcm:WebAppChannel"];
        }

        public string GetMobileAppChannel()
        {
            return _configuration["Google:Fcm:MobileAppChannel"];
        }
    }
}

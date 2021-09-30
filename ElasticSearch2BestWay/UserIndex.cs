using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch2BestWay
{
    public class UserIndex
    {
        private readonly IElasticClient _userclient;
        private readonly IElasticClient _testclient;

        public UserIndex(IElasticClient userclient, IElasticClient testclient)
        {
            //Uri localhost = new Uri("http://localhost:9200");
            //var setting = new ConnectionSettings(localhost);

            #region configuration
            var setting = new ConnectionSettings();
            setting.DefaultIndex("users");
            var _userclient = new ElasticClient(setting);

            var settingTest = new ConnectionSettings();
            settingTest.DefaultIndex("test");
            var _testclient = new ElasticClient(setting);

            #endregion

        }

        public async Task GetRecords() { 
            
        }
        
    }
}

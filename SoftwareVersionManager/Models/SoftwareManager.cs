using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareVersionManager.Models
{
    public class SoftwareManager
    {
        public static IEnumerable<Software> GetAllSoftware()
        {
            return new List<Software>
            {
                new Software("MS Word", "13.2.1."),
                new Software("AngularJS","1.7.1"),
                new Software("Angular","8.1.13"),
                new Software("React","0.0.5"),
                new Software("Vue.js","2.6"),
                new Software("Visual Studio","2017.0.1"),
                new Software("Visual Studio","2019.1"),
                new Software("Visual Studio Code", "1.35"),
                new Software("Blazor","0.7")
            };
        }
    }
}

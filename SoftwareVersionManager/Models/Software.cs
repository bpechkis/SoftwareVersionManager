using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareVersionManager.Models
{
    public class Software
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public SoftwareVersion ParsedVersion { get; private set; }

        public Software(string name, string unparsedVersion)
        {
            this.Name = name;
            this.Version = unparsedVersion;
            this.ParsedVersion = new SoftwareVersion(unparsedVersion);
        }
        
    }

    //public class SoftwareVersion
    //{
    //    public int MajorVersion { get; private set; }
    //    public int MinorVersion { get; private set; }
    //    public int Patch { get; private set; }

    //    public SoftwareVersion(string unparseVersion)
    //    {
    //        ParseVersion(unparseVersion);
    //    }

    //    private void ParseVersion(string unparseVersion)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public static class SoftwareManager
    //{
    //    public static IEnumerable<Software> GetAllSoftware()
    //    {
    //        return new List<Software>
    //        {
    //            new Software
    //            {
    //                Name = "MS Word",
    //                Version = "13.2.1."
    //            },
    //            new Software
    //            {
    //                Name = "AngularJS",
    //                Version = "1.7.1"
    //            },
    //            new Software
    //            {
    //                Name = "Angular",
    //                Version = "8.1.13"
    //            },
    //            new Software
    //            {
    //                Name = "React",
    //                Version = "0.0.5"
    //            },
    //            new Software
    //            {
    //                Name = "Vue.js",
    //                Version = "2.6"
    //            },
    //            new Software
    //            {
    //                Name = "Visual Studio",
    //                Version = "2017.0.1"
    //            },
    //            new Software
    //            {
    //                Name = "Visual Studio",
    //                Version = "2019.1"
    //            },
    //            new Software
    //            {
    //                Name = "Visual Studio Code",
    //                Version = "1.35"
    //            },
    //            new Software
    //            {
    //                Name = "Blazor",
    //                Version = "0.7"
    //            }
    //        };
    //    }
    //}
}

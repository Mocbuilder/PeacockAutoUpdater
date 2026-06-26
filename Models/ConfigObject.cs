using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeacockAutoUpdater.Models
{
    public class ConfigObject
    {
        public string PeacockRootFolder { get; set; }
        public string PeacockGithubURL { get; set; }
        public string LastPeacockVersion { get; set; }
        public string TempPath { get; set; }
        public bool PreserveData { get; set; }

        public ConfigObject(string peacockRootFolder, string peacockGithubURL, string lastPeacockVersion, string tempPath, bool preserveData)
        {
            PeacockRootFolder = peacockRootFolder;
            PeacockGithubURL = peacockGithubURL;
            LastPeacockVersion = lastPeacockVersion;
            TempPath = tempPath;
            PreserveData = preserveData;
        }
    }
}

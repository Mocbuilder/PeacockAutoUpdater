using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PeacockAutoUpdater.Models
{
    public class GitHubReleaseObject
    {
        [JsonPropertyName("tag_name")]
        public string TagName { get; set; }

        [JsonPropertyName("zipball_url")]
        public string ZipballUrl { get; set; }
    }
}

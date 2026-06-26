using PeacockAutoUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace PeacockAutoUpdater.Services
{
    public class HTTPService
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task<(bool, string)> GetLatestRelease(string githubURL, string lastVersion, string outputPath)
        {
            try
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("PeacockAutoUpdater");
                var release = await client.GetFromJsonAsync<GitHubRelease>(githubURL);

                if (release == null)
                {
                    return (false, "No release found. Something probably went wrong.");
                }

                if (release.TagName != lastVersion)
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(release.ZipballUrl);
                    await File.WriteAllBytesAsync(outputPath, fileBytes);
                    return (true, "");
                }
                else
                {
                    return (false, "Peacock is already on the latest version.");
                }
            }
            catch (Exception ex)
            {
                return(false, ex.Message);
            }
        }
    }
}

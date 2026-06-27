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

        public async Task<(GithubResultType, string)> GetLatestRelease(string githubURL, string lastVersion, string outputPath, bool noDownload)
        {
            try
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("PeacockAutoUpdater");
                var release = await client.GetFromJsonAsync<GitHubReleaseObject>(githubURL);

                if (release == null)
                {
                    return (GithubResultType.Error, "No release found. Something probably went wrong.");
                }

                if (release.TagName != lastVersion && !noDownload)
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(release.ZipballUrl);
                    await File.WriteAllBytesAsync(outputPath, fileBytes);
                    return (GithubResultType.NewerVersion, release.TagName.Substring(1));
                }
                else
                {
                    return (GithubResultType.SameVersion, "Peacock is already on the latest version.");
                }
            }
            catch (Exception ex)
            {
                return(GithubResultType.Error, ex.Message);
            }
        }
    }
}

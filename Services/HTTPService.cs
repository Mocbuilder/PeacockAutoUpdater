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
                    //find the asset that ends with .zip but doesn't have "-linux" in the name 'cause the others are useless for this purpose
                    var windowsAsset = release.Assets.FirstOrDefault(a =>
                        a.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) &&
                        !a.Name.Contains("-linux", StringComparison.OrdinalIgnoreCase));

                    if (windowsAsset == null)
                    {
                        return (GithubResultType.Error, "Could not find the Windows release asset (.zip).");
                    }

                    byte[] fileBytes = await client.GetByteArrayAsync(windowsAsset.BrowserDownloadUrl);

                    Directory.CreateDirectory(outputPath);
                    await File.WriteAllBytesAsync(Path.Combine(outputPath, "update.zip"), fileBytes);

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

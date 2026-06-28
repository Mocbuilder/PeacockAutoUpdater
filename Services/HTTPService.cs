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

        public async Task<(GithubResultType, string)> GetLatestRelease(ConfigService configService, bool noDownload)
        {
            try
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("PeacockAutoUpdater");
                var release = await client.GetFromJsonAsync<GitHubReleaseObject>(configService._config.PeacockGithubURL);

                if (release == null)
                {
                    return (GithubResultType.Error, "No release found. Something probably went wrong.");
                }

                if (release.TagName != configService._config.LastPeacockVersion && !noDownload)
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

                    Directory.CreateDirectory(configService._config.TempPath);
                    await File.WriteAllBytesAsync(Path.Combine(configService._config.TempPath, "update.zip"), fileBytes);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace PeacockAutoUpdater.Services
{
    public class UpdateService
    {
        private ConfigService _configService;
        private bool _preserveData = true;

        public UpdateService(ConfigService configService, bool preserveData) 
        {
            _configService = configService;
            _preserveData = preserveData;
        }

        public void UpdatePeacock()
        {
            if (_configService._config == null)
            {
                throw new Exception("Config was not initialised.");
            }

            if (_preserveData)
            {
                CopyUserDataToTemp();
            }

            //at the very end restore data
            if (_preserveData)
            {
                RestoreUserDataFromTemp();
            }

            //at the very end, delete temp path since it isnt needed anymore for now
            Directory.Delete(_configService._config.TempPath);
        }

        private void CopyUserDataToTemp()
        {
            if(_configService._config == null)
            {
                throw new Exception("Config was not initialised.");
            }

            var foldersToCopy = new[] { "contractSessions", "userdata", "Plugins" };

            string sourceRoot = _configService._config.PeacockRootFolder;
            string targetRoot = Path.Combine(_configService._config.TempPath, "dataBackup");

            foreach (var folder in foldersToCopy)
            {
                string sourcePath = Path.Combine(sourceRoot, folder);
                string targetPath = Path.Combine(targetRoot, folder);

                if (!Directory.Exists(sourcePath))
                {
                    throw new Exception("The Peacock Root folder does not exist!");
                }

                FileSystem.CopyDirectory(
                    sourcePath,
                    targetPath,
                    UIOption.OnlyErrorDialogs,
                    UICancelOption.ThrowException
                );
            }
        }

        private void RestoreUserDataFromTemp()
        {
            if (_configService._config == null)
            {
                throw new Exception("Config was not initialised.");
            }

            string sourcePath = Path.Combine(_configService._config.TempPath, "dataBackup");
            string targetPath = _configService._config.PeacockRootFolder;

            if (!Directory.Exists(sourcePath))
            {
                throw new Exception("The Peacock Root folder does not exist!");
            }

            FileSystem.CopyDirectory(
                sourcePath,
                targetPath,
                UIOption.OnlyErrorDialogs,
                UICancelOption.ThrowException
            );

            Directory.Delete(sourcePath, true);
        }
    }
}

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeacockAutoUpdater.Services
{
    public class UpdateService
    {
        private ConfigService _configService;
        private bool _preserveData = true;

        public UpdateService(ConfigService configService) 
        {
            _configService = configService;
        }

        public void UpdatePeacock(bool preserveData)
        {
            _preserveData = preserveData;

            if (_configService._config == null)
            {
                throw new Exception("Config was not initialised.");
            }

            if (_preserveData)
            {
                CopyUserDataToTemp();
            }

            CopyUpdateToSource();

            //at the end restore data
            if (_preserveData)
            {
                RestoreUserDataFromTemp();
            }

            //at the very end, delete temp path since it isnt needed anymore for now
            Directory.Delete(_configService._config.TempPath, true);
        }

        private void CopyUpdateToSource()
        {
            if (_configService._config == null)
            {
                throw new Exception("Config was not initialised.");
            }

            DeleteOldVersion();

            string zipPath = Path.Combine(_configService._config.TempPath, "update.zip");
            string extractionStagePath = Path.Combine(_configService._config.TempPath, "extract");
            string finalDestinationPath = _configService._config.PeacockRootFolder;

            ZipFile.ExtractToDirectory(zipPath, extractionStagePath);

            string[] topLevelDirectories = Directory.GetDirectories(extractionStagePath);

            if (topLevelDirectories.Length > 0)
            {
                string githubWrappedFolder = topLevelDirectories[0]; //this is the Peacock-vxxx folder

                foreach (string file in Directory.GetFiles(githubWrappedFolder))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(finalDestinationPath, fileName);
                    File.Move(file, destFile, overwrite: true);
                }

                foreach (string dir in Directory.GetDirectories(githubWrappedFolder))
                {
                    string dirName = Path.GetFileName(dir);
                    string destDir = Path.Combine(finalDestinationPath, dirName);

                    Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(
                        dir,
                        destDir,
                        Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs
                    );
                }
            }

            //clean up the temporary staging folder
            Directory.Delete(extractionStagePath, recursive: true);
        }

        private void DeleteOldVersion()
        {
            if (_configService._config == null)
            {
                throw new Exception("Config was not initialised.");
            }

            string peacockRootFolder = _configService._config.PeacockRootFolder;
            foreach (string file in Directory.GetFiles(peacockRootFolder))
            {
                File.Delete(file);
            }
            foreach (string dir in Directory.GetDirectories(peacockRootFolder))
            {
                Directory.Delete(dir, recursive: true);
            }
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

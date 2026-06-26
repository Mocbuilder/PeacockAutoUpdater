using PeacockAutoUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PeacockAutoUpdater.Services
{
    public class ConfigService
    {
        public ConfigObject? _config { get; set; }

        public ConfigService()
        {
            CheckIfConfigExist();
        }

        private bool CheckIfConfigExist()
        {
            if (File.Exists("config.json"))
            {
                string json = File.ReadAllText("config.json");
                _config = JsonSerializer.Deserialize<ConfigObject>(json);
                return true;
            }
            else
            {
                var assembly = Assembly.GetExecutingAssembly();
                string resourceName = "Shorthand.NET.config.json";

                using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                        throw new FileNotFoundException($"Could not find embedded resource: {resourceName}");

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string jsonText = reader.ReadToEnd();
                        _config = JsonSerializer.Deserialize<ConfigObject>(jsonText);
                    }
                }

                SaveConfig();
                return false;
            }
        }

        private void SaveConfig()
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(_config, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("config.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving config: {ex.Message}");
            }
        }

        //These should probably be combined into a modular function at some point
        public void SetLastPeacockVersion(string value)
        {
            if (_config == null)
            {
                throw new InvalidOperationException("Configuration has not been initialized.");
            }
            
            _config.LastPeacockVersion = value;

            SaveConfig();
        }

        public bool SetPeacockRootFolder(string value)
        {
            if (_config == null)
            {
                throw new InvalidOperationException("Configuration has not been initialized.");
            }

            if (!Path.Exists(value))
            {
                return false;
            }

            _config.PeacockRootFolder = value;

            SaveConfig();
            return true;
        }

        public bool SetPreserveData(bool value)
        {
            if (_config == null)
            {
                throw new InvalidOperationException("Configuration has not been initialized.");
            }

            _config.PreserveData = value;

            SaveConfig();
            return true;
        }
    }
}
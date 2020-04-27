using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FPSUnlock
{
    public class Config
    {
        public static string MainFolder = "404Mods\\FPSUnlock";
        public static string ModConfig = "config.json";

        public static Config CFG;

        public int TargetedFPS = 90;
        public int TabbedOutFPS = 30;

        public static void SaveConfig()
        {
            if (CFG != null)
                File.WriteAllText(MainFolder + "//" + ModConfig, JsonConvert.SerializeObject(CFG, Formatting.Indented));
        }

        public static void LoadConfig()
        {
            Directory.CreateDirectory(MainFolder);

            if (!File.Exists(MainFolder + "//" + ModConfig))
            {
                CFG = new Config();
                SaveConfig();

            }
            else
            {
                CFG = JsonConvert.DeserializeObject<Config>(File.ReadAllText(MainFolder + "//" + ModConfig));
                if (CFG == null)
                    CFG = new Config();
                SaveConfig();
            }
            
        }
    }
}

using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FPSUnlock
{
    public static class BuildInfo
    {
        public const string Name = "FPS Unlock"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "404#0004"; // Author of the Mod.  (Set as null if none)
        public const string Company = "I am not a company -Kappa-"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.2.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://github.com/l-404-l"; // Download Link for the Mod.  (Set as null if none)
    }
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            Config.LoadConfig();
            Application.targetFrameRate = Config.CFG.TargetedFPS;

            //New Age - Delegates lol // thanks for the help khan understanding this.
            Il2CppSystem.Delegate test = (Il2CppSystem.Action<bool>)new Action<bool>(x =>
            {
                if (x)
                { // Tabbed in
                    Application.targetFrameRate = Config.CFG.TargetedFPS;
                }
                else
                { // Tabbed out
                    Application.targetFrameRate = Config.CFG.TabbedOutFPS;
                }
            });

            //Insane how long this line is LOL;
            Application.focusChanged = Il2CppSystem.Delegate.Combine(Application.focusChanged, test).Cast<Il2CppSystem.Action<bool>>();

        }

        public override void OnUpdate()
        {
            Console.WriteLine(Application.targetFrameRate);
        }
    }
}

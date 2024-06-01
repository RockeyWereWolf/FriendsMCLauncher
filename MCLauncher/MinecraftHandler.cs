using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Downloader;
using CmlLib.Utils;
using CmlLib.Core.Installer.Forge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCLauncherTest;
using System.ComponentModel;

namespace MCLauncher
{
    public class MinecraftHandler
    {
        static MinecraftPath path = new MinecraftPath("./RoTN");
        public static CMLauncher launcher = new CMLauncher(path);
        public static MForge forge = new MForge(launcher);

        static string mineVer = ModpackParser.GetMineVer();
        static string forgeVer = ModpackParser.GetForgeVer();
        static string versionName;

        public static event ProgressChangedEventHandler? ProgressChanged;
        public static event EventHandler<DownloadFileChangedEventArgs>? FileChanged;

        static MinecraftHandler()
        {
            launcher.ProgressChanged += OnProgressChanged;
            forge.ProgressChanged += OnProgressChanged;
        }

        private static void OnProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(sender, e);
        }

        private static void OnFileChanged(object? sender, DownloadFileChangedEventArgs e)
        {
            FileChanged?.Invoke(sender, e);
        }

        public static async Task InstallForge()
        {
            versionName = await forge.Install(mineVer, forgeVer);
        }

        public static async Task LaunchMinecraft(string nick, int ram)
        {
            var process = await launcher.CreateProcessAsync(versionName, new MLaunchOption
            {
                MaximumRamMb = ram,
                Session = MSession.GetOfflineSession(nick),
                ServerIp = "207.127.88.183",
                ServerPort = 25565
            });

            process.Start();
        }
    }

}

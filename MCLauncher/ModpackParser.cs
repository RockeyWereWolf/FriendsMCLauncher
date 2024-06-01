using Newtonsoft.Json;
using CurseForge.APIClient;


namespace MCLauncherTest;

public class ModpackParser
{
    public class ModFile
    {
        public int projectID { get; set; }
        public int fileID { get; set; }
    }
    public static string GetMineVer()
    {
        using StreamReader r = new StreamReader("manifest.json");
        string manifestJson = r.ReadToEnd();
        var manifest = JsonConvert.DeserializeObject<Dictionary<object, object>>(manifestJson);
        var mineInfoJson = JsonConvert.SerializeObject(manifest.First().Value);
        var mineInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(mineInfoJson);
        return mineInfo.First().Value.ToString();
    }

    public static string GetForgeVer()
    {
        using StreamReader r = new StreamReader("manifest.json");
        string manifestJson = r.ReadToEnd();
        var manifest = JsonConvert.DeserializeObject<Dictionary<object, object>>(manifestJson);
        var mineInfoJson = JsonConvert.SerializeObject(manifest.First().Value);
        var mineInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(mineInfoJson);
        var modLoaderString = mineInfo["modLoaders"].ToString();
        modLoaderString = modLoaderString.Replace('[', ' ');
        modLoaderString = modLoaderString.Replace(']', ' ');
        var modLoaderInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(modLoaderString);
        return modLoaderInfo.First().Value.Remove(0, 6);
    }

    public static List<ModFile> GetModFiles()
    {
        using StreamReader r = new StreamReader("manifest.json");
        string manifestJson = r.ReadToEnd();
        var manifest = JsonConvert.DeserializeObject<Dictionary<string, object>>(manifestJson);
        var files = manifest["files"].ToString();
        return JsonConvert.DeserializeObject<List<ModFile>>(files);
    }

    public static async Task DownloadModsAsync(IProgress<int> progress)
    {
        List<string> urls = new List<string>();
        var cfApiClient = new ApiClient("$2a$10$bL4bIL5pUWqfcO7KQtnMReakwtfHbNKh6v1uTpKlzhwoueEJQnPnm");
        var modList = GetModFiles();

        int totalMods = modList.Count;
        int downloadedMods = 0;

        foreach (var mod in modList)
        {
            var modFileDownloadUrl = await cfApiClient.GetModFileDownloadUrlAsync(mod.projectID, mod.fileID);
            urls.Add(modFileDownloadUrl.Data);
        }

        foreach (var url in urls)
        {
            var httpClient = new HttpClient();
            using var stream = await httpClient.GetStreamAsync(url);
            Directory.CreateDirectory("RoTN\\mods\\");
            using var fileStream = new FileStream("RoTN\\mods\\" + Path.GetFileName(url), FileMode.CreateNew);
            await stream.CopyToAsync(fileStream);

            downloadedMods++;
            progress.Report(downloadedMods * 100 / totalMods);
        }
    }

    public static void OverrideModPack(IProgress<int> progress)
    {
        var allDirectories = Directory.GetDirectories("overrides", "*", SearchOption.AllDirectories);
        foreach (string dir in allDirectories)
        {
            string dirToCreate = dir.Replace("overrides", "RoTN");
            Directory.CreateDirectory(dirToCreate);
        }

        var allFiles = Directory.GetFiles("overrides", "*.*", SearchOption.AllDirectories);
        int totalFiles = allFiles.Length;
        int copiedFiles = 0;

        foreach (string newPath in allFiles)
        {
            Console.WriteLine("Copying " + newPath);
            File.Copy(newPath, newPath.Replace("overrides", "RoTN"), true);

            copiedFiles++;
            progress.Report(copiedFiles * 100 / totalFiles);
        }
    }
}

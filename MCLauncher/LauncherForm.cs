using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Downloader;
using CmlLib.Core.Installer.Forge;
using MCLauncherTest;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MCLauncher;

public partial class LauncherForm : Form
{
    static GCMemoryInfo gcMemoryInfo = GC.GetGCMemoryInfo();
    static long installedMemory = gcMemoryInfo.TotalAvailableMemoryBytes;
    // it will give the size of memory in GB
    static double physicalMemory = (double)installedMemory / 1073741824.0;

    [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.dll", EntryPoint = "SendMessage")]
    private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

    private const int cGrip = 16;
    private const int cCaption = 32;

    protected override void WndProc(ref Message m)
    {
        const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
        const int resizeAreaSize = 10;

        // Resize/WM_NCHITTEST values
        const int HTCLIENT = 1; //Represents the client area of the window
        const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
        const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
        const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
        const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
        const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
        const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
        const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
        const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
        ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
        if (m.Msg == WM_NCHITTEST)
        { //If the windows m is WM_NCHITTEST
            base.WndProc(ref m);
            if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
            {
                if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                {
                    Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                    Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                    if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                    {
                        if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                            m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                        else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                            m.Result = (IntPtr)HTTOP; //Resize vertically up
                        else //Resize diagonally to the right
                            m.Result = (IntPtr)HTTOPRIGHT;
                    }
                    else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                    {
                        if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                            m.Result = (IntPtr)HTLEFT;
                        else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                            m.Result = (IntPtr)HTRIGHT;
                    }
                    else
                    {
                        if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                            m.Result = (IntPtr)HTBOTTOM;
                        else //Resize diagonally to the right
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                    }
                }
            }
            return;
        }
        base.WndProc(ref m);
    }

    public LauncherForm()
    {
        InitializeComponent();

        this.SetStyle(ControlStyles.ResizeRedraw, true);

        for (int i = 1; i <= Double.Round(physicalMemory); i *= 2)
        {
            if (i < 4)
                continue;
            crownComboBox1.Items.Add(i*1024);
        }

        headerLabel1.Text = $"RAM(оператива в MБ): ";
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void airButton1_Click(object sender, EventArgs e)
    {

    }

    private void TopPanel_MouseDown(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, 0x112, 0xf012, 0);
    }

    private void crownComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        headerLabel1.Text = $"RAM(оператива в MБ): {crownComboBox1.Items[crownComboBox1.SelectedIndex]}";
    }

    private Task ProcessData(List<string> list, IProgress<ProgressReport> progress)
    {
        int index = 1;
        int totalProcess = list.Count;
        var progressReport = new ProgressReport();
        return Task.Run(() =>
        {
            for (int i = 0; i < totalProcess; i++)
            {
                progressReport.PercentComplete = index++ * 100 / totalProcess;
                progress.Report(progressReport);
                Thread.Sleep(100);
            }
        });
    }

    private async void foreverButton1_MouseClick(object sender, MouseEventArgs e)
    {
        if (crownComboBox1.SelectedItem == null)
        {
            headerLabel1.Text = $"RAM(оператива в МБ): ТЫ НЕ ВЫБРАЛ СУКА!!!!!";
            return;
        }

        bigLabel1.Text = $"Начинаем взлом жопы {dreamTextBox1.Text}";

        // Create progress instances for ModpackParser
        var modDownloadProgress = new Progress<int>(percent =>
        {
            bigLabel1.Text = $"Скачиваем трояны: {percent}%";
            progressBar1.Value = percent;
        });

        var overrideProgress = new Progress<int>(percent =>
        {
            bigLabel1.Text = $"Переписываем реестр: {percent}%";
            progressBar1.Value = percent;
        });

        // Subscribe to events
        MinecraftHandler.ProgressChanged += progressChanged;
        MinecraftHandler.

        //MinecraftHandler.FileChanged += fileChanged;

        // Install Forge
        await MinecraftHandler.InstallForge();

        // Download Mods
        await ModpackParser.DownloadModsAsync(modDownloadProgress);

        // Override Mod Pack
        ModpackParser.OverrideModPack(overrideProgress);

        // Launch Minecraft with the given nickname and RAM
        await MinecraftHandler.LaunchMinecraft(dreamTextBox1.Text, Convert.ToInt32(crownComboBox1.SelectedItem));

        bigLabel1.Text = "Взломано!";
    }

    private void progressChanged(object? sender, ProgressChangedEventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() =>
            {
                bigLabel1.Text = $"Взламываем фаервол {e.ProgressPercentage}%";
                progressBar1.Value = e.ProgressPercentage;
            }));
        }
        else
        {
            bigLabel1.Text = $"Взламываем фаервол {e.ProgressPercentage}%";
            progressBar1.Value = e.ProgressPercentage;
        }
    }

    //private void fileChanged(object? sender, DownloadFileChangedEventArgs e)
    //{
    //    if (InvokeRequired)
    //    {
    //        Invoke(new Action(() =>
    //        {
    //            Console.WriteLine($"[{e.FileKind}] {e.FileName} - {e.ProgressedFileCount}/{e.TotalFileCount}");
    //        }));
    //    }
    //    else
    //    {
    //        Console.WriteLine($"[{e.FileKind}] {e.FileName} - {e.ProgressedFileCount}/{e.TotalFileCount}");
    //    }
    //}
}

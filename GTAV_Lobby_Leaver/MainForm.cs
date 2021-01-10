using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;

namespace GTA_V_Lobby_Leaver
{
    public partial class MainForm : Form
    {
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        private const string executableName = "GTA5";
        private readonly System.Windows.Forms.Timer leaveTimer = new System.Windows.Forms.Timer();
        private TimeSpan runTime;
        private int processId = 0;
        private int leaveTimerTick = 0;
        private int language = 0; // 0 = german | 1 = english
        private string runTimeFinal = "";
        private bool processRunning = false;
        

        private readonly KeyHook keyHook = new KeyHook();

        public MainForm()
            => InitializeComponent();
        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckStatus();
            leaveTimer.Interval = 1000;
            leaveTimer.Tick += new EventHandler(LeaveTimerTick);

            keyHook.KeyDown += new KeyHook.KeyboardHookCallback(KeyboardHook_KeyDown);
            keyHook.Install();

            CreateContextMenu();

            if (!checkStatusWorker.IsBusy)
                checkStatusWorker.RunWorkerAsync();
        }
        private void MainForm_Shown(object sender, EventArgs e)
            => panel5.Focus();
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            keyHook.KeyDown -= new KeyHook.KeyboardHookCallback(KeyboardHook_KeyDown);
            keyHook.Uninstall();
        }

        private void ButtonLeave_Click(object sender, EventArgs e)
        {
            ButtonLeave.Enabled = false;
            ButtonLeave.BackColor = Color.FromArgb(215, 200, 200);
            ButtonStartStop.Enabled = false;
            ButtonStartStop.BackColor = Color.FromArgb(215, 200, 200);
            LeaveLobby();
        }
        private void ButtonStartStop_Click(object sender, EventArgs e)
        {
            if (!processRunning)
            {
                const string regKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432NODE\Valve\Steam";
                if (Registry.GetValue(regKey, "InstallPath", null) is string path)
                {
                    path += @"\";
                    using (Process process = new Process())
                    {
                        process.StartInfo.WorkingDirectory = path;
                        process.StartInfo.FileName = "Steam.exe";
                        process.StartInfo.Arguments = "-applaunch 271590";
                        process.Start();
                    }
                    panel5.Focus();
                }
                else
                {
                    panel5.Focus();
                    switch (language)
                    {
                        case 0: { MessageBox.Show(this, "Steam kann nicht gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);  break; }
                        case 1: { MessageBox.Show(this, "Steam cannot be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  break; }
                    }

                }
            }
            else if (processRunning)
            {
                Process process = Process.GetProcessById(processId);
                if (process != null)
                {
                    DialogResult r = MessageBox.Show(this, "Bist du sicher, dass du den Prozess beenden willst?", "Prozess beenden", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (r == DialogResult.Yes)
                    {
                        try { process.Kill(); }
                        catch
                        {
                            panel5.Focus();
                            MessageBox.Show(this, "Prozess kann nicht beendet werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                panel5.Focus();
            }
        }
        
        private void CheckStatus()
        {
            Process[] processes = Process.GetProcessesByName(executableName);
            if (processes.Length > 0)
            {
                foreach (Process process in processes)
                {
                    processId = process.Id;
                    try
                    {
                        runTime = DateTime.Now - process.StartTime;
                        runTimeFinal = runTime.ToString().Remove(runTime.ToString().IndexOf('.'), runTime.ToString().Length - runTime.ToString().IndexOf('.'));
                    }
                    catch { return; }
                }
            }
            else { processId = 0; }
            if (processId > 0)
            {
                if (!processRunning)
                {
                    processRunning = true;
                    switch (language)
                    {
                        case 0: 
                            {
                                label1.Text = "Status: GTA V ist gestartet";
                                label1.Location = new Point(61, 1);
                                ButtonStartStop.Text = "Prozess beenden";
                                break;
                            }
                        case 1:
                            {
                                label1.Text = "Status: GTA V is running";
                                label1.Location = new Point(64, 1);
                                ButtonStartStop.Text = "Stop process";
                                break;
                            }
                    }
                    label1.ForeColor = Color.FromArgb(80, 80, 80);
                    panel5.BackColor = Color.LightGreen;
                    label3.Text = "PID: " + processId;
                    ButtonLeave.Enabled = true;
                    ButtonLeave.BackColor = Color.SteelBlue;
                }

                switch (language)
                {
                    case 0: { label4.Text = "Laufzeit: " + runTimeFinal;  break; }
                    case 1: { label4.Text = "Runtime: " + runTimeFinal;  break; }
                }
            }
            else
            {
                if (processRunning)
                {
                    processRunning = false;
                    switch (language)
                    {
                        case 0:
                            {
                                label1.Text = "Status: GTA V ist nicht gestartet";
                                label1.Location = new Point(45, 1);
                                ButtonStartStop.Text = "Prozess starten";
                                label4.Text = "Laufzeit: 00:00:00";
                                break;
                            }
                        case 1:
                            {
                                label1.Text = "Status: GTA V is not running";
                                label1.Location = new Point(54, 1);
                                ButtonStartStop.Text = "Start process";
                                label4.Text = "Runtime: 00:00:00";
                                break;
                            }
                    }
                    label1.ForeColor = Color.White;
                    panel5.BackColor = Color.IndianRed;
                    label3.Text = "PID: 0";
                    ButtonLeave.BackColor = Color.FromArgb(215, 200, 200);
                    ButtonLeave.Enabled = false;
                    progressBar1.Value = 0;
                }
            }
        }
        private void LeaveLobby()
        {
            if (processRunning)
            {
                SuspendProcess(processId);
                switch (language)
                {
                    case 0: { ButtonLeave.Text = "Bitte warten (0)"; break; }
                    case 1: { ButtonLeave.Text = "Please wait (0)"; break; }
                }
                if (progressBar1.Value != 0) { progressBar1.Value = 0; }
                leaveTimer.Start();
                panel5.Focus();
            }
            else 
            { 
                switch (language)
                {
                    case 0: { MessageBox.Show(this, "Oooops! Etwas ist schief gelaufen. Starte das Spiel und Programm neu.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); break; }
                    case 1: { MessageBox.Show(this, "Wooops! Something went wrong. Restart the game and program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break; }
                }
            }
        }
        private void CreateContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem("Switch to English");
            menuItem.Click += SwitchLanguage;
            contextMenu.MenuItems.Add(menuItem);
            panel2.ContextMenu = contextMenu;
        }

        private void SwitchLanguage(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            switch (language)
            {
                case 0: 
                    { 
                        language = 1;
                        menuItem.Text = "Wechsle Sprache zu Deutsch";

                        if (!processRunning)
                        {
                            label1.Text = "Status: GTA V is not running";
                            label1.Location = new Point(54, 1);
                            label4.Text = "Runtime: 00:00:00";
                        }
                            
                        else
                        {
                            label1.Text = "Status: GTA V is running";
                            label1.Location = new Point(64, 1);
                            label4.Text = "Runtime: " + runTimeFinal;
                        }

                        label5.Text = "Process";
                        ButtonStartStop.Text = "Start process";
                        if (leaveTimer.Enabled)
                            ButtonLeave.Text = $"Please wait ({leaveTimerTick})";
                        else
                            ButtonLeave.Text = "Leave Lobby (F6)";
                        break; 
                    }
                case 1: 
                    {
                        language = 0;
                        menuItem.Text = "Switch language to English";

                        if (!processRunning)
                        {
                            label1.Text = "Status: GTA V ist nicht gestartet";
                            label1.Location = new Point(45, 1);
                            label4.Text = "Laufzeit: 00:00:00";
                        }
                            
                        else
                        {
                            label1.Text = "Status: GTA V ist gestartet";
                            label1.Location = new Point(61, 1);
                            label4.Text = "Laufzeit: " + runTimeFinal;
                        }

                        label5.Text = "Prozess";
                        ButtonStartStop.Text = "Prozess starten";
                        if (leaveTimer.Enabled)
                            ButtonLeave.Text = $"Bitte warten ({leaveTimerTick})";
                        else
                            ButtonLeave.Text = "Lobby verlassen (F6)";
                        break; 
                    }
            }
        }

        private void CheckStatusWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        CheckStatus();
                    });
                }
            }
        }
        private void LeaveTimerTick(object sender, EventArgs e)
        {
            leaveTimerTick++;
            if (progressBar1.Value != 7) { progressBar1.Value++; }
            switch (language)
            {
                case 0: { ButtonLeave.Text = $"Bitte warten ({leaveTimerTick})"; break; }
                case 1: { ButtonLeave.Text = $"Please wait ({leaveTimerTick})"; break; }
            }
            if (processId > 0)
            {
                if (leaveTimerTick == 8)
                {
                    ResumeProcess(processId);
                    leaveTimerTick = 0;
                    switch (language)
                    {
                        case 0: { ButtonLeave.Text = "Lobby verlassen (F6)"; break; }
                        case 1: { ButtonLeave.Text = "Leave Lobby (F6)"; break; }
                    }
                    ButtonLeave.Enabled = true;
                    ButtonLeave.BackColor = Color.SteelBlue;
                    ButtonStartStop.Enabled = true;
                    ButtonStartStop.BackColor = Color.SteelBlue;
                    panel5.Focus();
                    leaveTimer.Stop();
                }
            }
            else
            {
                leaveTimerTick = 0;
                switch (language)
                {
                    case 0: { MessageBox.Show(this, "Oooops! Etwas ist schief gelaufen. Starte das Spiel und Programm neu.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); break; }
                    case 1: { MessageBox.Show(this, "Wooops! Something went wrong. Restart the game and program.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); break; }
                }    
                panel5.Focus();
                leaveTimer.Stop();
            }
        }

        private static void SuspendProcess(int pid)
        {
            var process = Process.GetProcessById(pid);
            if (process.ProcessName == string.Empty) { return; }

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);
                if (pOpenThread == IntPtr.Zero) { continue; }
                SuspendThread(pOpenThread);
                CloseHandle(pOpenThread);
            }
        }
        private static void ResumeProcess(int pid)
        {
            var process = Process.GetProcessById(pid);
            if (process.ProcessName == string.Empty) { return; }

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);
                if (pOpenThread == IntPtr.Zero) { continue; }
                int suspendCount;
                do { suspendCount = ResumeThread(pOpenThread); }
                while (suspendCount > 0);
                CloseHandle(pOpenThread);
            }
        }

        private void KeyboardHook_KeyDown(KeyHook.VKeys key)
        {
            switch (key)
            {
                case KeyHook.VKeys.KEY_F6:
                    {
                        if (ButtonLeave.Enabled)
                        {
                            ButtonLeave.Enabled = false;
                            ButtonLeave.BackColor = Color.FromArgb(215, 200, 200);
                            ButtonStartStop.Enabled = false;
                            ButtonStartStop.BackColor = Color.FromArgb(215, 200, 200);
                            LeaveLobby();
                        }
                        break;
                    }
            }
        }
    }
}

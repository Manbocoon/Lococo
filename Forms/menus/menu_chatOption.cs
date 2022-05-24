using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Microsoft.Win32;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;

namespace Lococo.Forms.menus
{
    public partial class menu_chatOption : UserControl
    {
        #region Win32 API
        [DllImport("user32")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(int parent, int childAfter, string className, string windowName);
        [DllImport("user32")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        #endregion


        #region Global Variables
        private string selected_acc=null, selected_char = null;
        private string gamePath = null;
        private bool game_launched = false;

        private Thread stateThread;
        #endregion







        #region 쓰레드에 사용될 함수들

        // 동기화 기능을 이용 가능한지 주기적으로 검사하는 쓰레드
        private void checkState()
        {
            while (true)
            {
                getGamePathFromRegistry();

                if (gameInstalled() && !gameRunning())
                {
                    getAccountList();
                }


         

                Thread.Sleep(2500);
            }
        }



        #endregion




        #region 동기화 기능을 이용 가능한지 판별하는 함수들
        // 레지스트리에서 로스트아크 경로를 가져오는 함수
        private void getGamePathFromRegistry()
        {
            // 기본 경로: C:\Program Files (x86)\Smilegate\Games\LOSTARK
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\SGUP\Apps\45", false);

            if (key != null)
            {
                gamePath = (string)key.GetValue("GamePath", null);
                key.Close();
            }

            else
            {
                int backupControls_top = title_backup.Top;

                for (int i=0; i<this.Controls.Count; ++i)
                {
                    Control current_control = this.Controls[i];

                    if (current_control.Top > backupControls_top)
                        current_control.Enabled = false;
                }
            }
        }

        // 로스트아크가 설치되어있는지 확인하는 함수
        private bool gameInstalled()
        {
            // 로스트아크가 설치되어 있는지 확인
            string lostark_exe = gamePath + @"\Binaries\Win64\LOSTARK.exe";
            if (!File.Exists(lostark_exe))
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    state_label.Text = "! 로스트아크를 설치해야 이용 가능합니다.";
                    state_label.ForeColor = Color.FromArgb(255, 81, 36);

                    for (ushort index = 0; index < this.Controls.Count; ++index)
                    {
                        Control control = this.Controls[index];

                        control.Enabled = false;
                        if (control is Label && !(control is LinkLabel))
                            control.Enabled = true;

                    }
                });

                return false;
            }

            // 설치되어 있다면 개인설정 폴더는 존재하는지 확인
            else
            {
                string lostark_config = gamePath + @"\EFGame\Config\private";
                string[] account_dirs = new string[0];

                if (!Directory.Exists(lostark_config))
                    Directory.CreateDirectory(lostark_config);

                else
                    account_dirs = Directory.GetDirectories(lostark_config);

                if (account_dirs.Length == 0)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        state_label.Text = "! 이 PC에서 로스트아크를 플레이한 적이 없습니다.";
                        state_label.ForeColor = Color.FromArgb(255, 81, 36);

                        backup_pc.Enabled = false;

                        game_launched = false;
                    });

                    return false;
                }

                else
                    game_launched = true;
            }

            return true;
        }

        // 로스트아크가 구동중인지 확인하는 함수
        private bool gameRunning()
        {
            StringBuilder appTitle = new StringBuilder(null, 100);
            IntPtr lostarkHwnd = FindWindow("EFLaunchUnrealUWindowsClient", null);
            GetWindowText(lostarkHwnd, appTitle, 100);

            if (appTitle.ToString().StartsWith("LOST ARK"))
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    state_label.Text = "! 로스트아크를 종료해야 이용 가능합니다.";
                    state_label.ForeColor = Color.FromArgb(255, 81, 36);

                    backup_pc.Enabled = false;
                    apply_pc.Enabled = false;
                });

                return true;
            }

            else
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    state_label.Text = "✔ 이용 가능한 상태입니다.";
                    state_label.ForeColor = Color.FromArgb(0, 174, 219);

                    for (ushort index = 0; index < this.Controls.Count; ++index)
                    {
                        Control control = this.Controls[index];

                        if (!control.Text.EndsWith("초 남음"))
                            control.Enabled = true;
                    }
                });
            }

            return false;
        }
        #endregion


        #region PC에 설치된 로스트아크 계정들의 정보를 가져오는 함수들

        // 계정 폴더들을 가져오는 함수
        private List<string> account_list = new List<string>();
        private bool getAccountList()
        {
            string config_path = gamePath + @"\EFGame\Config\private";

            if (!Directory.Exists(config_path))
                return false;


            account_list.Clear();
            foreach (string dirs in Directory.GetDirectories(config_path))
            {
                // 계정 파일이 없다면 없는 계정으로 처리
                if (File.Exists(dirs + @"\AccountOption.xml"))
                {
                    string last_folderName = dirs.Remove(0, dirs.LastIndexOf('\\') + 1);

                    account_list.Add(last_folderName);
                }
            }

            this.Invoke((MethodInvoker)delegate ()
            { charCount_label.Text = account_list.Count.ToString() + "개의 계정이 감지되었습니다."; });

            if (account_list.Count == 0)
                return false;

            return true;
        }


        // 특정 계정의 캐릭터들을 가져오는 함수
        private List<string> char_list = new List<string>();
        private bool getCharList(string account_dirName)
        {
            string account_path = gamePath + @"\EFGame\Config\private\" + account_dirName + @"\AccountOption.xml";

            // 계정 파일이 존재하지 않으면 실패처리
            char_list.Clear();
            if (!File.Exists(account_path))
                return false;

            // 파일 한줄씩 읽어 캐릭터명 가져오기
            string[] file_data = File.ReadAllLines(account_path, Encoding.UTF8);
            foreach(string current_line in file_data)
            {
                if (current_line.EndsWith("</CharacterName>"))
                {
                    string char_name = current_line.Remove(0, current_line.IndexOf('_') + 1);
                    char_name = char_name.Substring(0, char_name.IndexOf('<'));

                    char_list.Add(char_name);
                }

                else if (current_line.EndsWith("</SkillBookOption>"))
                    break;
            }


            return true;
        }


        // AccountOption.xml 파일에서 XML 인식 불가능하도록 하는 16진수 문자 제거 함수
        private void removeHexCharFromXML(string file_path)
        {
            string file_data = File.ReadAllText(file_path, Encoding.UTF8);
            string replaces = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
     
            string new_file = Regex.Replace(file_data, replaces, "", RegexOptions.Compiled);

            try
            {
                File.WriteAllText(file_path, new_file, Encoding.UTF8);
            }

            catch (Exception)
            {
                MessageBox.Show("XML 파일의 16진수 문자를 제거하던 도중 오류가 발생했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion


        #region 계정설정 백업/복구 함수

        // 필요없는 폴더는 비우고 새로 생성하는 함수
        private void createEmptyDirs()
        {
            Directory.CreateDirectory(Program.path + "\\db");
            Directory.CreateDirectory(Program.path + "\\db\\backup");

            if (Directory.Exists(Program.path + "\\db\\backup\\temp"))
            {
                Directory.Delete(Program.path + "\\db\\backup\\temp", true);
            }

            Directory.CreateDirectory(Program.path + "\\db\\backup\\temp");
            Directory.CreateDirectory(Program.path + "\\db\\backup\\temp\\Config");
            Directory.CreateDirectory(Program.path + "\\db\\backup\\temp\\Customizing");

            Directory.CreateDirectory(gamePath + "\\EFGame\\Config");
            Directory.CreateDirectory(gamePath + "\\EFGame\\Customizing");
        }



        // 백업 함수
        private void backupAccountOptions(string file_path, bool open_explorer)
        {
            createEmptyDirs();

            _File.CopyDirectory(gamePath + "\\EFGame\\Config", Program.path + "\\db\\backup\\temp\\Config");
            _File.CopyDirectory(gamePath + "\\EFGame\\Customizing", Program.path + "\\db\\backup\\temp\\Customizing");

            ZipFile.CreateFromDirectory(Program.path + "\\db\\backup\\temp", file_path, CompressionLevel.Optimal, false);
            

            // 탐색기로 백업된 파일 선택해주기
            if (open_explorer)
            {
                _File.SelectFileWithExplorer(file_path);
            }


            Program.ShowMsgbox("게임 설정과 커스터마이징 파일을 백업했습니다.", "알림", false);
        }

        private void applyAccountOptions(string zip_path)
        {
            try
            {
                createEmptyDirs();

                ZipFile.ExtractToDirectory(zip_path, Program.path + "\\db\\backup\\temp");
                _File.CopyDirectory(Program.path + "\\db\\backup\\temp\\Config", gamePath + "\\EFGame\\Config");
                _File.CopyDirectory(Program.path + "\\db\\backup\\temp\\Customizing", gamePath + "\\EFGame\\Customizing");
            }

            catch (Exception)
            {
                Program.ShowMsgbox("불러오기 도중 오류가 발생하여 실패했습니다.", "알림",  false);
                return;
            }

            Program.ShowMsgbox("게임 설정과 커스터마이징 파일을 불러왔습니다.", "알림",  false);
        }
        #endregion




        public menu_chatOption()
        {
            InitializeComponent();
        }


        private void menu_chatOption_Load(object sender, EventArgs e)
        {
            getGamePathFromRegistry();
            getAccountList();

            // 채팅설정 동기화 기능을 이용할 수 있는지 검사하는 쓰레드 실행
            stateThread = new Thread(checkState);
            stateThread.IsBackground = true;
            stateThread.Start();
        }




        #region Event Handlers - 백업/불러오기
        private void backup_pc_Click(object sender, EventArgs e)
        {
            string dest_path = Program.path + @"\db\backup\" + DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + "_Backup.zip";

            backupAccountOptions(dest_path, true);
        }

        private void apply_pc_Click(object sender, EventArgs e)
        {
            DialogResult user_input;

            openFile.Filter = "압축 파일 (*.zip)|*.zip";
            openFile.InitialDirectory = Program.path + "\\db\\backup";
            user_input = openFile.ShowDialog();

            if (user_input == DialogResult.Cancel)
            {
                Program.ShowMsgbox("불러오기를 취소하였습니다.", "알림", false);
                return;
            }


            applyAccountOptions(openFile.FileName);
        }

        #endregion


        private void open_lostark_Click(object sender, EventArgs e)
        {
            Process explorer = new Process();
            explorer.StartInfo.FileName = "explorer.exe";
            explorer.StartInfo.Arguments = gamePath + @"\EFGame";
            explorer.StartInfo.UseShellExecute = true;
            explorer.StartInfo.Verb = "runas";

            explorer.Start();
        }

    }
}

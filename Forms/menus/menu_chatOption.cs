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
        private menu_chatOption_server menu_server;
        private menu_chatOption_setChar menu_setChar;
        private messageForm messageForm = new messageForm();

        private string selected_acc=null, selected_char = null;
        private string gamePath = null;
        private string appPath = Application.StartupPath;
        private bool game_launched = false;

        private Thread stateThread;
        #endregion




        #region App Functions
        private bool showMsgbox(string message, string caption, int width, int height, bool yesNo)
        {
            messageForm.Dispose();
            messageForm = new messageForm();

            bool result = false;

            messageForm.msg = message;
            messageForm.cap = caption;
            messageForm.width = width;
            messageForm.height = height;
            messageForm.yesNo = yesNo;

            messageForm.ShowDialog();

            if (messageForm.dialogResult == 1)
                result = true;

            return result;
        }

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
            gamePath = (string)key.GetValue("GamePath", null);
            key.Close();
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

                        set_mainChar.Enabled = false;
                        synchro.Enabled = false;
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

                    set_mainChar.Enabled = false;
                    synchro.Enabled = false;
                    backup_pc.Enabled = false;
                    backup_server.Enabled = false;
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
            bool wrong_char = false;
     
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
        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);


            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }

            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        // 필요없는 폴더는 비우고 새로 생성하는 함수
        private void createEmptyDirs()
        {
            if (!Directory.Exists(appPath + @"\db\backup"))
                Directory.CreateDirectory(appPath + @"\db\backup");

            if (Directory.Exists(appPath + @"\db\backup\temp"))
                Directory.Delete(appPath + @"\db\backup\temp", true);

            Directory.CreateDirectory(appPath + @"\db\backup\temp");
            Directory.CreateDirectory(appPath + @"\db\backup\temp\Config");

            if (!Directory.Exists(gamePath + @"\EFGame\Config"))
                Directory.CreateDirectory(gamePath + @"\EFGame\Config");
        }



        // 백업 함수
        private void backupAccountOptions(string file_path, bool open_explorer)
        {
       
                createEmptyDirs();

                ZipFile.CreateFromDirectory(gamePath + @"\EFGame\Config", file_path, CompressionLevel.Optimal, false);


                // 탐색기로 백업된 파일 선택해주기
                if (open_explorer)
                {
                    Process explorer = new Process();
                    explorer.StartInfo.FileName = "explorer.exe";
                    explorer.StartInfo.Arguments = "/select, \"" + file_path + "\"";
                    explorer.StartInfo.UseShellExecute = true;
                    explorer.StartInfo.Verb = "runas";
                    explorer.Start();
                }
            

            showMsgbox("백업 완료했습니다.", "알림", 325, 175, false);
        }

        private void applyAccountOptions(string zip_path)
        {
            try
            {
                createEmptyDirs();

                ZipFile.ExtractToDirectory(zip_path, appPath + @"\db\backup\temp\Config");
                CopyFolder(appPath + @"\db\backup\temp\Config", gamePath + @"\EFGame\Config");
            }

            catch (Exception)
            {
                showMsgbox("불러오기 도중 오류가 발생하여 실패했습니다.", "알림", 350, 175, false);
                return;
            }

            showMsgbox("불러오기 완료했습니다.", "알림", 325, 175, false);
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



        #region Event Handlers - 동기화
        private void set_mainChar_Click(object sender, EventArgs e)
        {
            menu_setChar = new menu_chatOption_setChar();
            
            for (byte index=0; index<account_list.Count; ++index)           
                menu_setChar.account_list_value[index] = account_list[index];

            menu_setChar.gamePath = gamePath;
            menu_setChar.ShowDialog();

            if (menu_setChar.selected_char != null && menu_setChar.selected_char.Length > 1)
            {
                selected_acc = menu_setChar.selected_acc;
                selected_char = menu_setChar.selected_char;
                state_setChar.Text = "✔ 설정된 대표캐릭터: " + selected_char;
                state_setChar.ForeColor = Color.FromArgb(0, 174, 219);
            }

            menu_setChar.Dispose();
            GC.Collect();
            GC.WaitForFullGCComplete();
        }

        private void synchro_Click(object sender, EventArgs e)
        {
            if (state_setChar.ForeColor != Color.FromArgb(0, 174, 219))
            {
                showMsgbox("대표 캐릭터를 지정한 후 동기화를 시도해주세요.", "알림", 350, 180, false);
                return;
            }


            if (showMsgbox("설정된 대표캐릭터의 채팅창 설정으로 모든 계정의 캐릭터들이 동일하게 동기화됩니다.\r\n한번 선택하면 되돌릴 수 없으므로 백업해두시는 것을 권장합니다.\r\n\r\n정말 진행하시겠습니까?", "알림", 550, 250, true))
            {
                string account_filePath = gamePath + @"\EFGame\Config\private\" + selected_acc + @"\AccountOption.xml";

                // 인식 불가능토록 하는 16진수 문자 제거
                removeHexCharFromXML(account_filePath);

                // XML 로드
                XmlNode uiOption = null;
                XmlDocument acc_doc = new XmlDocument();
                acc_doc.Load(account_filePath);

                // 캐릭터를 찾은 후 UI노드 복제
                XmlNodeList group_items = acc_doc.SelectNodes("AccountUserOption/PCOptions/ListGroupItem");
                foreach (XmlNode group_item in group_items)
                {
                    XmlNode char_name = group_item.SelectSingleNode("CharacterName");

                    if (char_name.InnerText.Length > 5)
                    {
                        // 내가 찾던 캐릭터의 닉네임이라면 UI설정 복제
                        if (selected_char == char_name.InnerText.Remove(0, 5))
                        {
                            uiOption = group_item.SelectSingleNode("UIOption").Clone();
                            break;
                        }
                    }
                }

                // 모든 계정의 캐릭터들에게 복제한 UI설정 덮어씌우기
                List<string> char_names = new List<string>();
                foreach (string acc_name in account_list)
                {
                    account_filePath = gamePath + @"\EFGame\Config\private\" + acc_name + @"\AccountOption.xml";

                    removeHexCharFromXML(account_filePath);

                    acc_doc = new XmlDocument();
                    acc_doc.Load(account_filePath);

                    // 한 파일의 모든 캐릭터에 UIOption 덮어씌우기
                    group_items = acc_doc.SelectNodes("AccountUserOption/PCOptions/ListGroupItem");
                    foreach (XmlNode group_item in group_items)
                    {
                        XmlNode char_name = group_item.SelectSingleNode("CharacterName");

                        // 닉네임이 입력되어있는 진짜 노드에만 덮어씌우기
                        if (char_name.InnerText.Length > 5)
                        {
                            char_names.Add(char_name.InnerText.Remove(0, 5));

                            XmlNode uiOption_original = group_item.SelectSingleNode("UIOption");
                            group_item.InsertBefore(group_item.OwnerDocument.ImportNode(uiOption, true), uiOption_original);
                            group_item.RemoveChild(uiOption_original);
                        }
                    }

                    using (var writer = new XmlTextWriter(account_filePath, new UTF8Encoding(false)))
                    {
                        writer.Formatting = Formatting.Indented;
                        acc_doc.Save(writer);
                    }

                }

                
                string char_msg = null;
                foreach (string name in char_names)
                    char_msg += '\n' + name;
                
                showMsgbox("모든 계정의 캐릭터들에게 설정이 동기화되었습니다.\r\n적용된 캐릭터 개수: " + char_names.Count + "개\r\n\r\n" + char_msg, "알림", 550, 700, false);
            }
        }


        #endregion

        #region Event Handlers - 백업/불러오기
        private void backup_pc_Click(object sender, EventArgs e)
        {
            string dest_path = appPath + @"\db\backup\" + DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + "_Backup.zip";

            backupAccountOptions(dest_path,  true);
        }

        private void apply_pc_Click(object sender, EventArgs e)
        {
            DialogResult user_input;

            openFile.Filter = "압축 파일 (*.zip)|*.zip";
            openFile.InitialDirectory = appPath + @"\db\backup";
            user_input = openFile.ShowDialog();

            if (user_input == DialogResult.Cancel)
            {
                showMsgbox("불러오기를 취소하였습니다.", "알림", 250, 180, false);
                return;
            }


            applyAccountOptions(openFile.FileName);
        }

        private void backup_server_Click(object sender, EventArgs e)
        {
            string result = null;

            using (var server = new Functions.server())
            {
                try
                {
                    result = server.getServerState();

                    if (!result.Contains("정상"))
                    {
                        showMsgbox("서버가 닫혀 있습니다.", "알림", 250, 175, false);
                        return;
                    }
                }

                catch (Exception)
                {
                    showMsgbox("현재 서버가 작동하지 않습니다.", "알림", 250, 175, false);
                    return;
                }
            }
            


            menu_server = new menu_chatOption_server();
            menu_server.gamePath = gamePath;
            menu_server.game_launched = game_launched;
            menu_server.ShowDialog();


            menu_server.Dispose();
            GC.Collect();
            GC.WaitForFullGCComplete();
        }

        #endregion

        private void check_serverState_Click(object sender, EventArgs e)
        {
            using (var server = new Functions.server())
            {

                string result = server.getServerState();


                showMsgbox(server.getServerState(), "알림", 300, 250, false);
            }
        }

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

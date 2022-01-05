using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Xml;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading;

namespace Lococo.Forms.menus
{
    public partial class menu_chatOption_server : Form
    {
        #region API
        [DllImport("winmm.dll", SetLastError = true)] private static extern int waveOutSetVolume(IntPtr device, uint volume);

        [DllImport("user32")]
        public static extern Int32 GetCursorPos(out POINT pt);

        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }
        #endregion

        #region Global Variables
        private messageForm messageForm = new messageForm();

        private string appPath = Application.StartupPath;
        public string gamePath { get; set; }
        public bool game_launched { get; set; }

        public int width { get; set; } = 610;
        public int height { get; set; } = 300;
        private bool dragging = false;
        private POINT startPoint, currentPoint;
        private int form_left, form_top;
        // 0 = No
        // 1 = Yes, OK
        #endregion


        #region UI/Sound
        public menu_chatOption_server()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams crp = base.CreateParams;
                crp.ClassStyle = 0x00020000;
                return crp;
            }
        }


        private void messageForm_Load(object sender, EventArgs e)
        {
            // UI 구성
            using (var img = new Functions.loadImage())
            {
                close_top.Image = img.loadImageFromFile(Application.StartupPath + "\\db\\images\\close_top.db");
                top_logo.Image = img.loadImageFromFile(Application.StartupPath + "\\db\\images\\top_logo.db");
            }
            
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - (width/2);
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - (height/2);
            this.Width = this.width;
            this.Height = this.height;

            title_panel.Width = this.width;
            close_top.Left = this.width - 35;

            waveOutSetVolume(IntPtr.Zero, (uint)0x69786978);

            if (File.Exists(Application.StartupPath + "\\db\\sounds\\Messagebox.db"))
            {
                SoundPlayer sound = new SoundPlayer(Application.StartupPath + "\\db\\sounds\\Messagebox.db");
                sound.Play();
                sound.Dispose();
            }

            using (var shadowClass = new Functions.UI.dropShadow())
            {
                shadowClass.top = 1;

                shadowClass.ApplyShadows(this);
            }

            // 한번도 로스트아크를 실행하지 않았던 PC라면 백업 불가능
            if (!game_launched)
                upload.Enabled = false;

            // 바로 종료했을 때 오류를 방지하기 위해 값 대입
            disableThread = new Thread(() => disableServerProcesses(3));
        }

        private void close_top_MouseEnter(object sender, EventArgs e)
        {
            close_top.BackColor = Color.FromArgb(180, 35, 35);
        }

        private void close_top_MouseLeave(object sender, EventArgs e)
        {
            close_top.BackColor = Color.FromArgb(25, 25, 25);
        }
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

        private bool validatePassword()
        {
            string text = password.Text;


            // 영어와 숫자만 사용되었는지 검사
            foreach (char ch in text)
            {
                bool passed = false;

                // 영어 소문자인지 검사
                if (0x61 <= ch && ch <= 0x7A)
                    passed = true;

                // 숫자인지 검사
                else if (0x30 <= ch && ch <= 0x39)
                    passed = true;


                // 둘 중 하나도 합격하지 못하면 실패처리
                if (!passed)
                    return false;
            }


            return true;
        }

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
        #endregion

        #region move Form with Dragging
        private void title_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dragging)
            {
                dragging = true;

                GetCursorPos(out startPoint);

                form_left = this.Left;
                form_top = this.Top;
            }
        }

        private void title_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                GetCursorPos(out currentPoint);

                this.Left = form_left + currentPoint.x - startPoint.x;
                this.Top = form_top + currentPoint.y - startPoint.y;
            }
        }


        private void title_panel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }









        #endregion





        #region 백업/불러오기 쿨타임 함수
        // 서버의 과부하를 막기 위해 일정 시간의 쿨타임 적용
        private Thread disableThread;

        // 쓰레드용 함수
        private void disableServerProcesses(byte duration)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                upload.Enabled = false;
                download.Enabled = false;
                extend_date.Enabled = false;
            });

            for (byte second=0; second<duration; ++second)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    upload.Text = "백업 ..." + (duration - second).ToString() + "초 남음";
                    download.Text = "불러오기 ... " + (duration - second).ToString() + "초 남음";
                    extend_date.Text = "유효기간 연장 ... " + (duration - second).ToString() + "초 남음";
                });

                Thread.Sleep(1000);
            }

            this.Invoke((MethodInvoker)delegate ()
            {
                upload.Enabled = true;
                download.Enabled = true;
                extend_date.Enabled = true;

                upload.Text = "백업";
                download.Text = "불러오기";
                extend_date.Text = "유효기간 연장";
            });

            return;
        }

        #endregion



        #region 계정설정 백업/복구 함수
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
        #endregion





        private void close_top_Click(object sender, EventArgs e)
        {
            if (disableThread.IsAlive)
                disableThread.Abort();

            this.Close();
        }



        #region Event Handlers - Upload / Download / Extend
        private void upload_Click(object sender, EventArgs e)
        {
            // 유효성 검사
            if (password.Text == null || password.TextLength < 6)
            {
                showMsgbox("비밀번호는 6자리 이상으로 지어주세요.", "알림", 320, 180, false);
                return;
            }

            if (!validatePassword())
            {
                showMsgbox("비밀번호에는 영어와 숫자만 사용해주세요.", "알림", 320, 180, false);
                return;
            }

            // 이미 존재하는 비밀번호인지 검사
            using (var server = new Functions.server())
            {
                if (server.checkFileExists(password.Text + ".lcc"))
                {
                    if (!showMsgbox("이미 존재하는 비밀번호입니다.\r\n\r\n새로 백업하시겠습니까?", "질문", 350, 225, true))
                    {
                        disableThread = new Thread(() => disableServerProcesses(3));
                        disableThread.IsBackground = true;
                        disableThread.Start();
                        return;
                    }
                }
            }



            // 현재 설정폴더를 가져와서 암호화
            string filePath = appPath + @"\db\backup\temp\" + password.Text + ".zip";

            if (File.Exists(filePath))
                File.Delete(filePath);

            createEmptyDirs();

            ZipFile.CreateFromDirectory(gamePath + @"\EFGame\Config", filePath, CompressionLevel.Optimal, false);
            
            using (var encrypter = new Functions.protectFile())           
                encrypter.encryptFile(filePath, Path.ChangeExtension(filePath, "lcc"));

            File.Delete(filePath);
            filePath = Path.ChangeExtension(filePath, "lcc");



            // 서버에 업로드 후 로컬파일 삭제
            using (var server = new Functions.server())
            {
                server.UploadFile(filePath);
                File.Delete(filePath);
            }

            showMsgbox("모든 설정이 서버에 백업되었습니다. 자신의 비밀번호를 잊지 말아주세요!\r\n\r\n비밀번호: " + password.Text + "\r\n유효기간: 28일", "알림", 575, 270, false);
            disableThread = new Thread(() => disableServerProcesses(15));
            disableThread.IsBackground = true;
            disableThread.Start();
        }



        private void download_Click(object sender, EventArgs e)
        {
            // 유효성 검사
            if (password.Text == null || password.TextLength < 6)
            {
                showMsgbox("비밀번호는 6자리 이상으로 지어주세요.", "알림", 320, 180, false);
                return;
            }

            if (!validatePassword())
            {
                showMsgbox("비밀번호에는 영어 소문자와 숫자만 사용해주세요.", "알림", 320, 180, false);
                return;
            }


            // 존재하는 비밀번호인지 검사
            using (var server = new Functions.server())
            {
                if (!server.checkFileExists(password.Text + ".lcc"))
                {
                    showMsgbox("존재하지 않는 비밀번호입니다.", "알림", 350, 175, false);
                    disableThread = new Thread(() => disableServerProcesses(3));
                    disableThread.IsBackground = true;
                    disableThread.Start();
                    return;
                }
            }




            // 존재한다면 다운받은 후 적용 시작
            string filePath = appPath + @"\db\backup\temp\" + password.Text + ".lcc";
            DateTime last_modified = DateTime.Now;

            createEmptyDirs();

            // 다운로드
            using (var server = new Functions.server())
                server.DownloadFile(password.Text + ".lcc", filePath);

            // 마지막 수정시간 가져오기
            last_modified = File.GetLastWriteTime(filePath);

            // 복호화
            using (var encrypter = new Functions.protectFile())
                encrypter.decryptFile(filePath, Path.ChangeExtension(filePath, ".zip"));

            // 다운받은 암호화파일은 삭제
            if (File.Exists(filePath))
                File.Delete(filePath);

            // 압축풀고 로스트아크 폴더에 옮기기
            filePath = Path.ChangeExtension(filePath, ".zip");
            ZipFile.ExtractToDirectory(filePath, appPath + @"\db\backup\temp\Config");
            CopyFolder(appPath + @"\db\backup\temp\Config", gamePath + @"\EFGame\Config");

            File.Delete(filePath);


            last_modified = last_modified.AddDays(28);
            TimeSpan remaining_time = (last_modified - DateTime.Now);
            showMsgbox("모든 설정을 불러왔습니다!\r\n모든 설정은 유효기간이 지나면 서버에서 자동삭제될 수 있으므로 28일이 지나기 전, 연장해주세요.\r\n\r\n유효기간: " + last_modified.ToString() + " 까지\r\n남은 시간: " + remaining_time.Days.ToString() + "일 " + remaining_time.Hours.ToString() + "시간 " + remaining_time.Minutes.ToString() + "분", "알림", 575, 270, false);
            disableThread = new Thread(() => disableServerProcesses(15));
            disableThread.IsBackground = true;
            disableThread.Start();
        }


        private void extend_date_Click(object sender, EventArgs e)
        {
            // 유효성 검사
            if (password.Text == null || password.TextLength < 6)
            {
                showMsgbox("비밀번호는 6자리 이상으로 지어주세요.", "알림", 320, 180, false);
                return;
            }

            if (!validatePassword())
            {
                showMsgbox("비밀번호에는 영어 소문자와 숫자만 사용해주세요.", "알림", 320, 180, false);
                return;
            }


            // 존재하는 비밀번호인지 검사
            using (var server = new Functions.server())
            {
                if (!server.checkFileExists(password.Text + ".lcc"))
                {
                    showMsgbox("존재하지 않는 비밀번호입니다.", "알림", 350, 175, false);
                    disableThread = new Thread(() => disableServerProcesses(3));
                    disableThread.IsBackground = true;
                    disableThread.Start();
                    return;
                }
            }


            createEmptyDirs();

            // 존재한다면 재업로드하여 유효기간 연장
            string file_path = appPath + @"\db\backup\temp\" + password.Text + ".lcc";
            using (var server = new Functions.server())
            {
                server.DownloadFile(password.Text + ".lcc", file_path);
                server.UploadFile(file_path);
                File.Delete(file_path);
            }

            showMsgbox("유효기간이 다시 연장되었습니다!\r\n\r\n비밀번호: " + password.Text + "\r\n유효기간: 28일", "알림", 575, 270, false);
            disableThread = new Thread(() => disableServerProcesses(15));
            disableThread.IsBackground = true;
            disableThread.Start();
        }


        #endregion


    }
}

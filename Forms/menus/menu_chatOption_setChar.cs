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
using System.Text.RegularExpressions;

namespace Lococo.Forms.menus
{
    public partial class menu_chatOption_setChar : Form
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
        public string[] account_list_value { get; set; } = new string[200];
        public string selected_char { get; set; }
        public string selected_acc { get; set; }

        public int width { get; set; } = 750;
        public int height { get; set; } = 450;
        private bool dragging = false;
        private POINT startPoint, currentPoint;
        private int form_left, form_top;
        // 0 = No
        // 1 = Yes, OK
        #endregion


        #region UI/Sound
        public menu_chatOption_setChar()
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
            // 계정폴더 목록 넘겨받기
            account_list.Clear();
            for (byte index=0; index<account_list_value.Length; ++index)            
                account_list.Add(account_list_value[index]);


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

            if (System.IO.File.Exists(Application.StartupPath + "\\db\\sounds\\Messagebox.db"))
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

            addHoverTooltip();
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

        private void addHoverTooltip()
        {
            main_char.MouseHover += (object sen, EventArgs evt) =>
            {
                toolTip.ToolTipTitle = "대표캐릭터 검색";
                toolTip.SetToolTip(main_char, "PC에서 대표캐릭터를 검색할 수 있도록\r\n자신의 로스트아크 닉네임에 포함된 단어(2글자 이상)를 입력해주세요.");
            };
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



        #region PC에 설치된 로스트아크 계정들의 정보를 가져오는 함수들
        // 특정 계정의 캐릭터들을 가져오는 함수
        private List<string> account_list = new List<string>();
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
            foreach (string current_line in file_data)
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



        private void close_top_Click(object sender, EventArgs e)
        {
            this.Close();
        }







        #region Event Handlers - About Searching/Selecting Character

        private void main_char_Click(object sender, EventArgs e)
        {
            main_char.SelectAll();
        }

        private void main_char_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchChar_Click(searchChar, new EventArgs());
            }
        }

        private void searchChar_Click(object sender, EventArgs e)
        {
            if (main_char.TextLength < 2)
            {
                showMsgbox("단어를 2글자 이상 입력해주세요.", "알림", 325, 175, false);
                return;
            }

            // 잔존 캐릭터 라벨 제거
            for (ushort index=0; index<this.Controls.Count; ++index)
            {
                Control control = this.Controls[index];

                if (control.Name.StartsWith("charCard"))
                {
                    control.MouseEnter -= charCard_MouseEnter;
                    control.MouseLeave -= charCard_MouseLeave;
                    control.Click -= charCard_MouseLeave;

                    control.Dispose();
                    --index;
                }
            }
            


            // 캐릭터 카드 추가
            this.SuspendLayout();

            int searched_chars = 0;
            int label_x = 20, label_y = 150, label_width = 150, label_height = 40, label_aperture = 5, label_index=0;
            for (ushort acc_index=0; acc_index<account_list.Count; ++acc_index)
            {
                getCharList(account_list[acc_index]);
                
                for (ushort char_index=0; char_index<char_list.Count; ++char_index)
                {
                    if (char_list[char_index].Contains(main_char.Text))
                    {
                        Label char_card = new Label()
                        {
                            Name = "charCard_" + account_list[acc_index] + "_" + char_index + "_" + label_index,
                            BackColor = Color.FromArgb(22, 22, 22),
                            ForeColor = Color.LightGray,
                            Font = new Font("맑은 고딕", 9, FontStyle.Bold),
                            AutoSize = false,
                            Left = label_x,
                            Top = label_y,
                            Width = label_width,
                            Height = label_height,
                            Text = char_list[char_index],
                            TextAlign = ContentAlignment.MiddleCenter,
                            Cursor = Cursors.Hand
                        };

                        char_card.MouseEnter += (object sen, EventArgs evt) =>
                        {
                            charCard_MouseEnter(sen, evt);
                        };

                        char_card.MouseLeave += (object sen, EventArgs evt) =>
                        {
                            charCard_MouseLeave(sen, evt);
                        };

                        char_card.Click += (object sen, EventArgs evt) =>
                        {
                            charCard_Click(sen, evt);
                        };

                        this.Controls.Add(char_card);

                        ++label_index;
                        ++searched_chars;
                        label_x += label_width + label_aperture;

                        if (label_x + label_width > this.Width - (label_aperture*2))
                        {
                            label_x = 20;
                            label_y += label_height + label_aperture;
                        }
                    }
                }
            }

            this.ResumeLayout();


            if (searched_chars > 0)          
                state_label.Text = "↓ " + searched_chars + "개의 캐릭터가 검색되었습니다. 대표 캐릭터를 하나 클릭해주세요.";

            else
                state_label.Text = "↓ 검색된 캐릭터가 없습니다. 다른 단어로 검색해보세요.";
            
        }
        #endregion



        #region Event Handlers - Highlighting Character Cards Label
        Color charCard_default = Color.FromArgb(22, 22, 22);
        Color charCard_OnMouse = Color.FromArgb(33, 33, 33);

        private void charCard_MouseEnter(object sender, EventArgs evt)
        {
            Label control = (Label)sender;

            control.BackColor = charCard_OnMouse;
        }

        private void charCard_MouseLeave(object sender, EventArgs evt)
        {
            Label control = (Label)sender;

            control.BackColor = charCard_default;
        }

        private void charCard_Click(object sender, EventArgs evt)
        {
            Control control = (Control)sender;

            // 컨트롤에 적어둔 것을 이용해 계정폴더명 가져오기
            string account_dirName = control.Name.Remove(0, control.Name.IndexOf('_') + 1);
            account_dirName = account_dirName.Substring(0, account_dirName.IndexOf('_'));
            string account_filePath = gamePath + @"\EFGame\Config\private\" + account_dirName + @"\AccountOption.xml";

            // 파일을 읽어서 채팅설정 정보 가져오기
            List<string> tab_name = new List<string>();
            string chatAlpha=null, chatFontSize = null;
            int chatTab_count = 0;
            string[] file_data;


            File.Copy(gamePath + @"\EFGame\Config\private\" + account_dirName + @"\AccountOption.xml", appPath + @"\temp_accOption.xml", true);
            removeHexCharFromXML(appPath + @"\temp_accOption.xml");

            XmlDocument acc_doc = new XmlDocument();
            acc_doc.Load(appPath + "\\temp_accOption.xml");
            File.Delete(appPath + @"\temp_accOption.xml");

            XmlNode big_item = acc_doc.SelectSingleNode("AccountUserOption/PCOptions");
            XmlNodeList char_list = big_item.SelectNodes("ListGroupItem");

            foreach (XmlNode group_item in char_list)
            {
                XmlNode char_name = group_item.SelectSingleNode("CharacterName");

                if (char_name.InnerText.Length < 6)
                    continue;

                // Name_ 5글자를 제거하고 내가 누른 캐릭터와 비교해 이름이 같다면
                if (char_name.InnerText.Remove(0, 5) == control.Text)
                {
                    // 채팅창 투명도와 폰트 크기 가져오기
                    XmlNodeList chat_options = group_item.SelectNodes("UIOption/ChatOption");

                    foreach (XmlNode chat_option in chat_options)
                    {
                        if (chat_option.Attributes[0].Value == "ChatDefaultUIAlpha")
                            chatAlpha = chat_option.InnerText;

                        else if (chat_option.Attributes[0].Value == "ChatDefaultFontSize")
                            chatFontSize = chat_option.InnerText;                      
                    }


                    // 채팅창 크기와 탭 정보 가져오기
                    XmlNodeList chat_tabs = group_item.SelectNodes("UIOption/ChatTabOption/ListGroupItem");
                    XmlNode tabNode;
                    
                    chatTab_count = chat_tabs.Count;
   

                    foreach (XmlNode chat_tab in chat_tabs)
                    {
                        tabNode = chat_tab.SelectSingleNode("TabName");
                        tab_name.Add(tabNode.InnerText);
                    }

                }
            }


            string tabMsg = null;
            for (int index=0; index<chatTab_count; ++index)
                tabMsg += "\r\n탭" + (index + 1).ToString() + " 이름: " + tab_name[index];
            

            if (showMsgbox("\"" + control.Text + "\" 캐릭터를 선택하시겠습니까?\r\n↓ 이 캐릭터의 채팅설정 ↓\r\n\r\n채팅창 투명도: " + chatAlpha.Substring(0, chatAlpha.IndexOf('.')) + "%\r\n채팅창 글씨 크기: " + chatFontSize.Substring(0, chatFontSize.IndexOf('.')) + "\r\n\r\n탭 개수: " + chatTab_count + tabMsg, "알림", 550, 800, true))
            {
                selected_acc = account_dirName;
                selected_char = control.Text;
                this.Close();
            }    
        }
        #endregion

    }
}

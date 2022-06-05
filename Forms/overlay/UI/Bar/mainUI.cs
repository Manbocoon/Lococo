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
using System.Threading;
using System.IO;





namespace Lococo.Forms.overlay.UI.Bar
{
    /// <summary>
    /// 모든 오버레이의 상단 바
    /// </summary>
    public partial class mainUI : Form
    {

        #region Global Variables
        public object SettingsForm { get; set; }
        public slider SliderForm { get; set; }

        #endregion


        public mainUI()
        {
            InitializeComponent();
        }

        #region Form - Hide from Alt+Tab Switcher / Show Shadow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.ExStyle |= 0x80;

                return Params;
            }
        }
        #endregion






        #region Event Handlers - Buttons
        private readonly Color Button_DefaultBackColor = Color.FromArgb(22, 22, 22);
        private readonly Color Button_ActivatedBackColor = Color.FromArgb(255, 81, 36);

        /// <summary>
        /// 특정 설정버튼이 켜져 있는지 확인합니다.
        /// </summary>
        private bool IsOpened(Button _button)
        {
            bool result = false;
            Color Button_ActivatedBackColor = Color.FromArgb(255, 81, 36);

            if (_button.BackColor == Button_ActivatedBackColor)
            {
                result = true;
            }

            return result;
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            if (lockButton.Image == null)
            {
                lockButton.Image = Properties.Resources.unlock;
                return;
            }

            lockButton.Image.Dispose();
            bool opened = IsOpened(lockButton);
            if (!opened)
            {
                lockButton.Image = Properties.Resources._lock;
                lockButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                lockButton.Image = Properties.Resources.unlock;
                lockButton.BackColor = Button_DefaultBackColor;
            }

            _public.SetClickable(Owner, opened);
        }

        private void opacityButton_Click(object sender, EventArgs e)
        {
            if (!IsOpened(opacityButton))
            {
                SliderForm = new slider();
                SliderForm.start_value = _public.GetOpacity(Owner);
                SliderForm.Location = new Point(this.Right + 5, this.Top);
                SliderForm.Opacity = Opacity;
                SliderForm.Show(Owner);

                if (Program.IsActivated(Owner))               
                    ((dynamic)Owner).SliderForm = SliderForm;
                
                opacityButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                if (Program.IsActivated(SliderForm))
                {
                    SliderForm.Dispose();

                    opacityButton.BackColor = Button_DefaultBackColor;
                }
            }
        }



        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (!IsOpened(settingsButton))
            {
                if (Owner is o_browser)
                {
                    SettingsForm = new s_browser();
                }

                else if (Owner is o_image)
                {
                    SettingsForm = new s_image();
                }
                                 
                ((Form)SettingsForm).Location = new Point(Owner.Right + 5, Owner.Top);
                ((Form)SettingsForm).Opacity = Opacity;
                ((Form)SettingsForm).Show(Owner);

                settingsButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                if (Program.IsActivated(SettingsForm))
                {
                    ((Form)SettingsForm).Dispose();
                }

                settingsButton.BackColor = Button_DefaultBackColor;
            }


        }

        private void favoritesButton_Click(object sender, EventArgs e)
        {
            if (!IsOpened(favoritesButton))
            {
                fav_menu.Show(settingsButton.PointToScreen(new Point(settingsButton.Width, 0)));

                favoritesButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                fav_menu.Close();

                favoritesButton.BackColor = Button_DefaultBackColor;
            }



        }
        #endregion



        #region Event Handlers - Form
        private void mainUI_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            this.WindowState = FormWindowState.Normal;

            this.Opacity = Owner.Owner.Opacity;

            // 잠금설정 버튼의 저장된 설정 적용
            if (!_public.GetClickable(Owner))
            {
                lockButton.Image = Properties.Resources._lock;
                lockButton.BackColor = Button_ActivatedBackColor;
            }

            else
            {
                lockButton.Image = Properties.Resources.unlock;
                lockButton.BackColor = Button_DefaultBackColor;
            }  

            fav_menu.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
            fav_menu.ForeColor = Color.White;

            using (var config = new Config.overlay())
            {
                config.ReadFavorites();

                foreach (string favName in config.favorites)
                {
                    ushort itemIndex = 0;

                    ToolStripItem menuItem = new ToolStripMenuItem()
                    {
                        Name = "favItem_" + itemIndex,
                        Font = fav_menu.Font,
                        Text = favName
                    };

                    fav_menu.Items.Add(menuItem);
                    ++itemIndex;
                }
            }
        }


        private void mainUI_Move(object sender, EventArgs e)
        {
            if (IsOpened(favoritesButton))
            {
                fav_menu.Show(settingsButton.PointToScreen(new Point(settingsButton.Width, 0)));
            }
        }




        #endregion


        #region Functions - Favorites

        /// <summary>
        /// 즐겨찾기 메뉴(fav_menu)의 현재 선택된 항목의 인덱스 번호를 불러옵니다. 선택된 항목이 없다면 -1을 반환합니다.
        /// </summary>
        /// <param name="DrawCheckMark">현재 선택된 항목에 체크 표시를 그릴 것인지 결정합니다.</param>
        private int GetMenuItemSelectedIndex(bool DrawCheckMark)
        {
            int selectedItemIndex = -1;

            for (int i = 0; i < fav_menu.Items.Count; ++i)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)fav_menu.Items[i];

                if (item.Selected)
                {
                    item.BackColor = Color.FromArgb(50, 50, 50);

                    if (DrawCheckMark)
                    {
                        Bitmap selectMark = new Bitmap(20, 20);

                        using (Graphics drawer = Graphics.FromImage(selectMark))                       
                            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 81, 36)))                         
                                drawer.FillRectangle(brush, 0, 0, selectMark.Width, selectMark.Height);
                            
                        item.Image = selectMark;
                    }

                    selectedItemIndex = i;
                }

                else
                {
                    item.BackColor = Color.FromArgb(22, 22, 22);
                    item.Image = null;
                }
            }

            GC.Collect(0);

            return selectedItemIndex;
        }

        /// <summary>
        /// 유저가 직접 추가한 즐겨찾기의 첫 순번을 가져옵니다.
        /// </summary>
        private int GetMenuItemStartIndex()
        {
            int startIndex = 4;

            try
            {
                startIndex = fav_menu.Items.IndexOf(fav_divLine) + 1;
            }

            catch (Exception)
            {

            }

            return startIndex;
        }

        private void fav_menu_Click(object sender, EventArgs e)
        {
            int selected_index = GetMenuItemSelectedIndex(true);
            int start_index = GetMenuItemStartIndex();
            int end_index = fav_menu.Items.Count - 1;

            if (!Program.IsActivated(ParentForm))
                return;

            if (selected_index < start_index)
            {
                switch (selected_index)
                {
                    case 0:
                        break;

                    case 1:
                        break;

                    case 2:
                        break;
                }


                return;
            }


            if (ParentForm is o_browser)
            {
                using (var config = new Config.overlay())
                {
                    config.Owner = (o_browser)Owner;

                    config.ReadFavorite(fav_menu.Items[selected_index].Text);
                    config.ApplySettings();
                }
            }

            else if (ParentForm is o_image_sizer)
            {

            }
        }

        #endregion

    }


    public class MenuColorTable : ProfessionalColorTable
    {

        private Color dark_orange = Color.FromArgb(255, 81, 36);
        private Color darker_orange = Color.FromArgb(100, 30, 5);
        private Color lococo_backColor = Color.FromArgb(22, 22, 22);


        public override Color MenuItemSelected => darker_orange;

        public override Color MenuItemBorder => dark_orange;

        public override Color MenuBorder => dark_orange;


        public override Color ImageMarginGradientBegin => lococo_backColor;
        public override Color ImageMarginGradientMiddle => lococo_backColor;
        public override Color ImageMarginGradientEnd => lococo_backColor;
        public override Color ToolStripDropDownBackground => lococo_backColor;

        public override Color CheckBackground => Color.FromArgb(50, 50, 50);
        public override Color CheckSelectedBackground => Color.FromArgb(50, 50, 50);
        public override Color CheckPressedBackground => Color.FromArgb(50, 50, 50);
    }


}

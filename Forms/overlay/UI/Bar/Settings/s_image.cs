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
using System.Windows.Media.Imaging;



namespace Lococo.Forms.overlay.UI.Bar
{
    public partial class s_image : Form
    {
        #region Global Variables
        public o_image ParentForm { get; set; }

        private byte opacityUI_value = 80;
        public byte opacityUI
        {
            get
            {
                Invoke((MethodInvoker)delegate
                {
                    opacityUI_value = (byte)(this.Opacity * 100);
                });

                return opacityUI_value;
            }

            set
            {
                opacityUI_value = value;

                if (IsHandleCreated)
                {
                    Opacity = (double)value / 100;
                }
            }
        }
        #endregion





        public s_image()
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


 

        private void LoadSettings()
        {
            file_path.Text = ParentForm.imgPath;

            original.Checked = ParentForm.useOriginalSize;
            ratio.Checked = ParentForm.SizerForm.keepRatio;
        }



        private void s_image_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;

            this.WindowState = FormWindowState.Normal;

            if (Program.IsActivated(ParentForm) && Program.IsActivated(ParentForm.SizerForm))
            {
                ParentForm.SizerForm.ChildForm = this;

                LoadSettings();
            }
        }



        private void browse_file_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "오버레이할 이미지 불러오기";
                fileDialog.InitialDirectory = Program.Path;
                fileDialog.Filter = "이미지 파일 (*.png, *.jpg, *.bmp)|*.png;*.jpg;*.bmp";
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;

                DialogResult user_input = fileDialog.ShowDialog();
                if (user_input == DialogResult.Cancel)
                {
                    return;
                }

                if (!Imaging.IsSupportedImage(fileDialog.FileName))
                {
                    Program.ShowMsgbox("존재하지 않는 파일이거나, 지원되지 않는 이미지입니다.", "실패", false);
                    return;
                }

                file_path.Text = fileDialog.FileName;
            }
        }

        private void update_file_Click(object sender, EventArgs e)
        {
            if (Program.IsActivated(ParentForm))
            {
                ParentForm.imgPath = file_path.Text;

                if (original.Checked)
                {
                    Size img_original = Imaging.GetImageSize(file_path.Text);

                    ParentForm.updateImage(file_path.Text, ParentForm.opacity, img_original.Width, img_original.Height);
                }

                else
                {
                    ParentForm.updateImage(file_path.Text, ParentForm.opacity, ParentForm.SizerForm.Width, ParentForm.SizerForm.Height);
                }
            }

        }



        private void label_ratio_Click(object sender, EventArgs e)
        {
            ratio.Checked = !ratio.Checked;
            ratio_Click(ratio, new EventArgs());
        }

        private void ratio_Click(object sender, EventArgs e)
        {
            if (!Program.IsActivated(ParentForm))
            {
                return;
            }

            ParentForm.SizerForm.keepRatio = ratio.Checked;
            
            if (ratio.Checked && !original.Checked)
            {
                ParentForm.SizerForm.CorrectFormRatio(true);
                ParentForm.SizerForm.ResizeImage();
            }

        }

        private void label_original_Click(object sender, EventArgs e)
        {
            original.Checked = !original.Checked;
            original_Click(original, new EventArgs());
        }

        private void original_Click(object sender, EventArgs e)
        {
            if (!Program.IsActivated(ParentForm))
            {
                return;
            }

            ParentForm.useOriginalSize = original.Checked;
        }
    }
}

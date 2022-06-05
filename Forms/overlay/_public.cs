using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lococo.Forms.overlay
{
    /// <summary>
    /// 모든 오버레이 창이 동일하게 사용할 메서드들을 모아놓은 정적 객체입니다.
    /// </summary>
    public static class _public
    {

        /// <summary>
        /// 오버레이 창의 자식 창들의 위치를 부모 창 근처로 옮깁니다. ChildBar, ChildForm, SliderForm
        /// </summary>
        public static void PlaceChilds(object ParentForm)
        {
            if (!Program.IsActivated(ParentForm))
                return;

            Form parentForm = (Form)ParentForm;
            string property_name = "Location";
            string[] child_names = new string[] { "ChildBar", "SliderForm", "SettingsForm" };
            object[] child_forms = new object[3];

            for (int i=0; i<child_names.Length; ++i)         
                child_forms[i] = Program.GetProperty(ParentForm, child_names[i]);


            Form bar = (Form)child_forms[0];
            if (!Program.IsActivated(bar))
                return;

            Point[] child_locs = new Point[] 
            {
                new Point { X = parentForm.Left, Y = parentForm.Top - bar.Height },
                new Point { X = bar.Right + 5, Y = bar.Top },
                new Point { X = parentForm.Right + 5, Y = parentForm.Top }
            };


            for (int i = 0; i < child_names.Length; ++i)
            {
                if (Program.IsActivated(child_forms[i]))
                    Program.SetProperty(child_forms[i], property_name, child_locs[i]);
            }
            
        }

        /// <summary>
        /// 오버레이 창 위에 소형 설정 바를 생성하여 표시합니다.
        /// </summary>
        public static void ShowChildBar(object ParentForm)
        {
            string property_name = "ChildBar";

            if (!Program.IsActivated(ParentForm))
                return;

            if (!Program.IsValidProperty(ParentForm, property_name))
                return;

            Form parentForm = (Form)ParentForm;
            var childBar = new UI.Bar.mainUI();

            Program.SetProperty(ParentForm, property_name, childBar);

            childBar.Location = new Point(parentForm.Left, parentForm.Top - childBar.Height);
            childBar.Show(parentForm);
        }

        /// <summary>
        /// 오버레이 UI 창들의 불투명도를 설정합니다.
        /// </summary>
        public static void SetChildOpacity(object ParentForm, float opacity)
        {
            if (!Program.IsActivated(ParentForm))
                return;

            string[] overlays = new string[] { "overlayForm_browser", "overlayForm_image", "overlayForm_text" };
            string[] childs = new string[] { "ChildBar", "SettingsForm", "SliderForm" };
            string property_name = "Opacity";
            foreach (string overlay_name in overlays)
            {
                var overlay_form = Program.GetProperty(ParentForm, overlay_name);

                if (!Program.IsActivated(overlay_form))
                    continue;

                foreach (string child_name in childs)
                {
                    var child_form = Program.GetProperty(overlay_form, child_name);

                    if (Program.IsActivated(child_form))
                        Program.SetProperty(child_form, property_name, opacity);
                }
          
            }
        }


        #region Settings - Clickable
        /// <summary>
        /// 오버레이 창의 잠금(클릭 불가) 설정 값을 변경합니다.
        /// </summary>
        public static void SetClickable(object ParentForm, bool clickable)
        {
            if (Program.IsValidProperty(ParentForm, "clickable"))
                Program.SetProperty(ParentForm, "clickable", clickable);
        }

        /// <summary>
        /// 오버레이 창의 잠금(클릭 불가) 설정 값을 읽습니다.
        /// </summary>
        public static bool GetClickable(object ParentForm)
        {
            bool clickable = true;

            if (Program.IsValidProperty(ParentForm, "clickable"))
                clickable = (bool)Program.GetProperty(ParentForm, "clickable");

            return clickable;
        }
        #endregion


        #region Settings - Opacity
        /// <summary>
        /// 오버레이 창의 불투명도 값을 읽습니다.
        /// </summary>
        public static byte GetOpacity(object ParentForm)
        {
            byte opacity = 80;

            if (Program.IsValidProperty(ParentForm, "opacity"))
                opacity = (byte)Program.GetProperty(ParentForm, "opacity");

            return opacity;
        }

        /// <summary>
        /// 오버레이 창의 불투명도 값을 설정합니다.
        /// </summary>
        public static void SetOpacity(object ParentForm, byte opacity)
        {
            if (Program.IsValidProperty(ParentForm, "opacity"))
                Program.SetProperty(ParentForm, "opacity", opacity);
        }
        #endregion



    }
}

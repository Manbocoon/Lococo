// Custom UI - Slider Control
// Referenced the code from here ▼
// https://stackoverflow.com/questions/70465326/how-to-draw-a-custom-slider-control


using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Lococo.Functions.UI
{
    /// <summary>
    /// 윈도우 기본 스크롤바가 너무 못생겨서 만든 사용자 정의 컨트롤
    /// </summary>
    public partial class Slider : Control
    {
        private float _radius;
        private PointF _thumbPos;
        private SizeF _barSize;
        private PointF _barPos;

        public event EventHandler ValueChanged;

        public Slider()
        {
            // This reduces flicker
            DoubleBuffered = true;
            this.Size = new Size(250, 20);
        }

        private int _min = 0;
        public int Min
        {
            get => _min;
            set
            {
                _min = value;
                RecalculateParameters();
            }
        }

        private int _max = 100;
        public int Max
        {
            get => _max;
            set
            {
                _max = value;
                RecalculateParameters();
            }
        }

        private int _value = 30;
        public int Value
        {
            get => Min + _uiValue;
            set
            {
                _value = value;
                _uiValue = value - Min;
                ValueChanged?.Invoke(this, EventArgs.Empty);
                RecalculateParameters();
            }
        }

        private int _SmallestChange = 1;
        public int SmallestChange
        {
            get => _SmallestChange;
            set => _SmallestChange = value;
        }

        private int _uiValue = 30;
        private int uiValue
        {
            get => _uiValue;

            set
            {
                _uiValue = value;
                ValueChanged?.Invoke(this, EventArgs.Empty);
                RecalculateParameters();
            }
        }

        private Color _backColor = Color.DimGray;
        public Color BarBackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                this.Invalidate();
            }
        }

        private Color _barColor = Color.FromArgb(0, 145, 0);
        public Color BarForeColor
        {
            get => _barColor;
            set
            {
                _barColor = value;
                this.Invalidate();
            }
        }

        private Color _boxColor = Color.FromArgb(0, 55, 0);
        public Color BoxColor
        {
            get => _boxColor;
            set
            {
                _boxColor = value;
                this.Invalidate();
            }
        }

        private bool _useBox = true;
        public bool UseBox
        {
            get => _useBox;
            set
            {
                _useBox = value;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            SizeF clickBox = new SizeF(0.7f * _radius, 1.5f * _barSize.Height);

            if (Enabled)
            {
                e.Graphics.FillRectangle(new SolidBrush(_backColor), _barPos.X, _barPos.Y, _barSize.Width, _barSize.Height);
                e.Graphics.FillRectangle(new SolidBrush(_barColor), _barPos.X, _barPos.Y, _thumbPos.X - _barPos.X, _barSize.Height);

                if (_useBox)
                    e.Graphics.FillRectangle(new SolidBrush(_boxColor), _thumbPos.X, _barPos.Y - (0.25f * _barSize.Height), clickBox.Width, clickBox.Height);

            }

            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), _barPos.X, _barPos.Y, _barSize.Width, _barSize.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(160, 160, 160)), _barPos.X, _barPos.Y, _thumbPos.X - _barPos.X, _barSize.Height);

                if (_useBox)
                    e.Graphics.FillRectangle(new SolidBrush(Color.DimGray), _thumbPos.X, _barPos.Y - (0.25f * _barSize.Height), clickBox.Width, clickBox.Height);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RecalculateParameters();
        }

        private void RecalculateParameters()
        {
            _radius = 0.5f * ClientSize.Height;
            _barSize = new SizeF(ClientSize.Width - 2f * _radius, 0.5f * ClientSize.Height);
            _barPos = new PointF(_radius, (ClientSize.Height - _barSize.Height) / 2);
            _thumbPos = new PointF(_barSize.Width / (Max - Min) * uiValue + _barPos.X, _barPos.Y + 0.5f * _barSize.Height);
            Invalidate();
        }

        bool _moving = false;
        SizeF _delta;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // 마우스 누르자마자 즉시 값 변경
            if (_useBox)
            {
                _moving = true;
                OnMouseMove(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_useBox)
            {
                SizeF clickBox = new SizeF(0.7f * _radius, 1.5f * _barSize.Height);

                if (e.Location.X >= _thumbPos.X - clickBox.Width && e.Location.X <= _thumbPos.X + clickBox.Width)
                    this.Cursor = Cursors.SizeWE;
                else
                    this.Cursor = Cursors.Default;



                if (_moving)
                {
                    float thumbX = e.Location.X - _delta.Width;

                    if (thumbX < _barPos.X)
                        thumbX = _barPos.X;

                    else if (thumbX > _barPos.X + _barSize.Width)
                        thumbX = _barPos.X + _barSize.Width;

                    _uiValue = (int)((thumbX - _barPos.X) * (Max - Min) / _barSize.Width);
                    uiValue = _uiValue - (_uiValue % _SmallestChange);

                    this.Cursor = Cursors.SizeWE;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _moving = false;
        }

    }
}

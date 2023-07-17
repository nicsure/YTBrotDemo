using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTBrotDemo
{
    internal class ZoomGuide : Control
    {
        private readonly Panel left = new(), right = new(), top = new(), bottom = new();
        private Control? parent = null;

        public ZoomGuide() : base()
        {
            ParentChanged += ZoomGuide_ParentChanged;
            VisibleChanged += ZoomGuide_VisibleChanged;
        }

        private void ZoomGuide_VisibleChanged(object? sender, EventArgs e)
        {
            top.Visible = bottom.Visible = left.Visible = right.Visible = Visible;
        }

        private void ZoomGuide_ParentChanged(object? sender, EventArgs e)
        {
            if (parent != null)
            {
                parent.Controls.Remove(left);
                parent.Controls.Remove(right);
                parent.Controls.Remove(top);
                parent.Controls.Remove(bottom);
            }
            parent = Parent;
            parent.Controls.Add(left);
            parent.Controls.Add(right);
            parent.Controls.Add(top);
            parent.Controls.Add(bottom);
            left.Width = right.Width = 1;
            top.Height = bottom.Height = 1;
            top.BringToFront();
            bottom.BringToFront();
            left.BringToFront();
            right.BringToFront();
            top.BackColor = bottom.BackColor = left.BackColor = right.BackColor = Color.White;
        }

        public void Update(double scale) => Update(Left, Top, scale);

        public void Update(int x, int y, double scale)
        {
            if (parent != null)
            {
                Left = x;
                Top = y;
                double zw = parent.Width / scale;
                double zh = parent.Height / scale;
                top.Width = bottom.Width = (int)zw;
                left.Height = right.Height = (int)zh;
                int hw = (int)(zw / 2.0);
                int hh = (int)(zh / 2.0);
                left.Left = bottom.Left = top.Left = x - hw;
                left.Top = right.Top = top.Top = y - hh;
                right.Left = x + hw;
                bottom.Top = y + hh;
            }
        }
    }
}

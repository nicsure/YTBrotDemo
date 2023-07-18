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
        private Control? parent = null;
        private readonly List<Panel> panels = new() { new(), new(), new(), new() };

        public ZoomGuide() : base()
        {
            ParentChanged += ZoomGuide_ParentChanged;
            VisibleChanged += ZoomGuide_VisibleChanged;
        }

        private void ZoomGuide_VisibleChanged(object? sender, EventArgs e)
        {
            panels.ForEach(panel => panel.Visible = Visible);
        }

        private void ZoomGuide_ParentChanged(object? sender, EventArgs e)
        {
            panels.ForEach(panel => {
                parent?.Controls.Remove(panel);
                Parent.Controls.Add(panel);
                panel.Width = panel.Height = 2;
                panel.BringToFront();
                panel.BackColor = Color.White;
            });
            parent = Parent;
        }

        public void Update(int x, int y, double scale)
        {
            if (parent != null)
            {
                Left = x;
                Top = y;
                double zw = parent.Width / scale;
                double zh = parent.Height / scale;
                int hw = (int)(zw / 2.0);
                int hh = (int)(zh / 2.0);
                panels[2].Width = panels[3].Width = (int)zw;
                panels[0].Height = panels[1].Height = (int)zh;
                panels[0].Left = panels[3].Left = panels[2].Left = x - hw;
                panels[0].Top = panels[1].Top = panels[2].Top = y - hh;
                panels[1].Left = x + hw;
                panels[3].Top = y + hh;
            }
        }
    }
}

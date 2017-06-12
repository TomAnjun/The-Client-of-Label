using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShengXinSolution.Client.LablePrintSystemV2
{
    class TabControlAnjun : TabControl
    {
        Image backImage;
        public TabControlAnjun()
        {
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(55, 66);
            backImage = new Bitmap(this.GetType(), "shadow.png");
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);
            base.UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                //绘制边框线，方便调试
                //e.Graphics.DrawRectangle(Pens.Red,this.GetTabRect(i));
                if (this.SelectedIndex == i)
                {
                    e.Graphics.DrawImage(backImage, this.GetTabRect(i));
                }
                //Calculate text position
                Rectangle bounds = this.GetTabRect(i);
                PointF textPoint = new PointF();
                SizeF textSize = TextRenderer.MeasureText(this.TabPages[i].Text, this.Font);

                //注意要加上每个标签的左偏移量x
                textPoint.X = bounds.X + (bounds.Width - textSize.Width) / 2;
                textPoint.Y = bounds.Bottom - textSize.Height - this.Padding.Y;

                //Draw highlights
                e.Graphics.DrawString(
                    this.TabPages[i].Text,
                    this.Font,
                    SystemBrushes.ControlLightLight,
                    textPoint.X,
                    textPoint.Y);

                //绘制正常文字
                textPoint.Y--;
                e.Graphics.DrawString(
                    this.TabPages[i].Text,
                    this.Font,
                    SystemBrushes.ControlText,
                    textPoint.X,
                    textPoint.Y);

                //绘制图标
                if (this.ImageList != null)
                {
                    int index = this.TabPages[i].ImageIndex;
                    string key = this.TabPages[i].ImageKey;
                    Image icon = new Bitmap(1, 1);

                    if (index > -1)
                    {
                        icon = this.ImageList.Images[index];
                    }
                    if (!string.IsNullOrEmpty(key))
                    {
                        icon = this.ImageList.Images[key];
                    }
                    e.Graphics.DrawImage(
                        icon,
                        bounds.X + (bounds.Width - icon.Width) / 2,
                        bounds.Top + this.Padding.Y);
                }
            }
        }
    }
}

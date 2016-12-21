using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace howto_generic_treenode
{
    class CircleNode : IDrawable
    {
        // The string we will draw.
        public string Name;
        public bool _down;

        // Constructor.
        public CircleNode(string new_name,bool down)
        {
            Name = new_name;
            _down = down;
        }

        // Return the size of the string plus a 10 pixel margin.
        public SizeF GetSize(Graphics gr, Font font)
        {
            return gr.MeasureString(Name, font) + new SizeF(10, 10);
        }

        public bool GetDir()
        {
            return _down;
        }

        // Draw the object centered at (x, y).
        void IDrawable.Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font)
        {
            // Fill and draw an ellipse at our location.
            SizeF my_size = GetSize(gr, font);
            RectangleF rect = new RectangleF(
                x - my_size.Width / 2,
                y - my_size.Height / 2,
                my_size.Width, my_size.Height);
            gr.FillEllipse(bg_brush, rect);
            gr.DrawEllipse(pen, rect);

            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(Name, font, text_brush, x, y, string_format);
            }
        }
    }
}

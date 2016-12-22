using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;

namespace howto_generic_treenode
{
    class TreeNode<T> where T : IDrawable
    {   
        // The data.
        public T Data;

        // Child nodes in the tree.
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        // The node's center after arranging.
        private PointF Center;

        // Drawing properties.
        public Font MyFont = null;
        public Pen MyPen = Pens.Black;
        public Brush FontBrush = Brushes.Black;
        public Brush BgBrush = Brushes.White;

        // Constructor.
        public TreeNode(T new_data)
            : this(new_data, new Font("Times New Roman", 12))
        {
            Data = new_data;
        }
        public TreeNode(T new_data, Font fg_font)
        {
            Data = new_data;
            MyFont = fg_font;
        }

        // Add a TreeNode to out Children list.
        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        // Arrange the node and its children in the allowed area.
        // Set xmin to indicate the right edge of our subtree.
        // Set ymin to indicate the bottom edge of our subtree.

        public void Arrange(Graphics gr, ref IDictionary<int, float> levw, int level, int maxlvl,int xshift,int yshift)
        {
            // See how big this node is.
            SizeF my_size = Data.GetSize(gr, MyFont);
            if (!levw.ContainsKey(level))
                levw[level] = 30;
            // Recursively arrange our children,
            // allowing room for this node.
            foreach (TreeNode<T> child in Children)
            {
                if (child.Data.GetDir())
                {
                    child.Arrange(gr, ref levw, level + 1, maxlvl, xshift, yshift);
                }
                else
                {
                    child.Arrange(gr, ref levw, level - 1, maxlvl, xshift, yshift);
                }
            }
            //  MessageBox.Show(level.ToString(), "",
            // MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (!Data.GetDir())
            {
                levw[level] += my_size.Width * (level - maxlvl);
                Center = new PointF(levw[level] + my_size.Width / 2+xshift/3, (level - maxlvl) * 50 + 20+yshift/3);
                levw[level] += my_size.Width + 30;
                levw[level] += my_size.Width * (level - maxlvl);
            }
            else
            {
                levw[level] += my_size.Width * (-maxlvl);
                Center = new PointF(levw[level] + my_size.Width / 2+xshift/3, (level - maxlvl) * 50 + 20+yshift/3);
                levw[level] += my_size.Width;
            }
        }

        // Draw the subtree rooted at this node
        // with the given upper left corner.
        public void DrawTree(Graphics gr, ref IDictionary<int, float> levw, int level, int maxlvl, int xshift, int yshift)
        {
            // Arrange the tree.
            Arrange(gr, ref levw, level, maxlvl, xshift, yshift);

            // Draw the tree.
            DrawTree(gr);
        }

        // Draw the subtree rooted at this node.
        public void DrawTree(Graphics gr)
        {
            // Draw the links.
            DrawSubtreeLinks(gr);

            // Draw the nodes.
            DrawSubtreeNodes(gr);
        }

        // Draw the links for the subtree rooted at this node.
        private void DrawSubtreeLinks(Graphics gr)
        {
            foreach (TreeNode<T> child in Children)
            {
                // Draw the link between this node this child.
                gr.DrawLine(MyPen, Center, child.Center);

                // Recursively make the child draw its subtree nodes.
                child.DrawSubtreeLinks(gr);
            }
        }

        // Draw the nodes for the subtree rooted at this node.
        private void DrawSubtreeNodes(Graphics gr)
        {
            // Draw this node.
            Data.Draw(Center.X, Center.Y, gr, MyPen, BgBrush, FontBrush, MyFont);

            // Recursively make the child draw its subtree nodes.
            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeNodes(gr);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace howto_generic_treenode
{
    class TreeNode<T> where T : IDrawable
    {   
        // The data.
        public T Data;

        // Child nodes in the tree.
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        // Space to skip horizontally between siblings
        // and vertically between generations.
        private const float Hoffset = 5;
        private const float Voffset = 10;

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

        public void Arrange(Graphics gr, ref float xdmin, ref float xumin, ref float ydmin, ref float yumin)
        {
            // See how big this node is.
            SizeF my_size = Data.GetSize(gr, MyFont);

            // Recursively arrange our children,
            // allowing room for this node.
            float xd = xdmin;
            float xu = xumin;
            float biggest_ydmin = ydmin + my_size.Height;
            float subtree_ydmin = ydmin + my_size.Height + Voffset;

            float biggest_yumin = yumin - my_size.Height;
            float subtree_yumin = yumin - my_size.Height - Voffset;
            
            foreach (TreeNode<T> child in Children)
            {
                // Arrange this child's subtree.
                float child_ydmin = subtree_ydmin;
                float child_yumin = subtree_yumin;
                if (Data.GetDir())
                    child.Arrange(gr, ref xd, ref xu, ref child_ydmin, ref child_yumin);
                else
                    child.Arrange(gr, ref xd, ref xu, ref child_ydmin, ref child_yumin);

                // See if this increases the biggest ymin value.
                if (Data.GetDir())
                    if (biggest_ydmin < child_ydmin) biggest_ydmin = child_ydmin;
                else
                    if (biggest_yumin < child_yumin) biggest_yumin = child_yumin;
                // Allow room before the next sibling.
                if (Data.GetDir())
                    xd += Hoffset;
                else
                    xu+= Hoffset;

            }

            // Remove the spacing after the last child.
            if (Children.Count > 0)
                if (Data.GetDir())
                    xd-= Hoffset;
                else
                    xu -= Hoffset;

            // See if this node is wider than the subtree under it.
            float subtree_width;

            if (Data.GetDir())
                subtree_width = xd - xdmin;
            else
                subtree_width = xu - xumin;

            if (my_size.Width > subtree_width)
            {
                // Center the subtree under this node.
                // Make the children rearrange themselves
                // moved to center their subtrees.
                if (Data.GetDir())
                    xd = xdmin + (my_size.Width - subtree_width) / 2;
                else
                    xu = xumin + (my_size.Width - subtree_width) / 2;

                foreach (TreeNode<T> child in Children)
                {
                    // Arrange this child's subtree.
                    if (Data.GetDir())
                        child.Arrange(gr, ref xd, ref xu, ref subtree_ydmin, ref subtree_yumin);
                    else
                        child.Arrange(gr, ref xd, ref xu, ref subtree_ydmin, ref subtree_yumin);
                    // Allow room before the next sibling.
                    if (Data.GetDir())
                        xd += Hoffset;
                    else
                        xu += Hoffset;
                }

                // The subtree's width is this node's width.
                subtree_width = my_size.Width;
            }

            // Set this node's center position.
            if (Data.GetDir())
                Center = new PointF(xdmin + subtree_width / 2, ydmin + my_size.Height / 2);
            else
                Center = new PointF(xumin + subtree_width / 2, yumin - my_size.Height / 2);

            // Increase xmin to allow room for
            // the subtree before returning.
            if (Data.GetDir())
                xdmin += subtree_width;
            else
                xumin += subtree_width;

            // Set the return value for ymin.
            ydmin = biggest_ydmin;
            yumin = biggest_yumin;
        }

        // Draw the subtree rooted at this node
        // with the given upper left corner.
        public void DrawTree(Graphics gr, ref float xd, ref float xu, float yd, float yu)
        {
            // Arrange the tree.
            Arrange(gr, ref xd,ref xu, ref yd,ref yu);

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

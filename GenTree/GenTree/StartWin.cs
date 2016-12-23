using Data;
using DatabaseModel.Model;
using howto_generic_treenode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenTree
{
    public partial class StartWin : Form
    {
        public Int32 DrawingPersonCode{get; private set;}

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        // The root node.
        private TreeNode<CircleNode> root = null;

        int maxlvl;

        int xshift=0;
        int yshift=0;

        int xglshift = 0;
        int yglshift = 0;

        IModel model;

        public StartWin()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();

            model = new Model();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void newRelativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm(model);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
            DrawTree();
            this.Refresh();
        }

        private void AddPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm(model);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                form.Close();
            }
            if (form.DialogResult == DialogResult.OK && null != form.ReturnValue) 
            {
                DrawingPersonCode = form.ReturnValue.Code;
                findRelationsToolStripMenuItem.Enabled = true;
                root = new TreeNode<CircleNode>(new CircleNode(form.ReturnValue.ToString(), false));
                DrawTree();
                form.Close();
            }
            this.Refresh();
        }

        private void FindRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm relatFindForm = new FindForm(model);
            relatFindForm.ShowDialog();
            if (null == relatFindForm.ReturnValue)
                return;

            Int32 codeToFind = relatFindForm.ReturnValue.Code;

            MessageBox.Show( model.FindRelations(DrawingPersonCode, codeToFind), "Определение родства", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ArrangeTree()
        {
            xshift = 0;
            yshift = 0;
            using (Graphics gr = this.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                IDictionary<int, float> levw=new Dictionary<int, float>();
                root.Arrange(gr, ref levw,0, maxlvl,0,0);
            }

            // Redraw.
            this.Refresh();
        }
        private void DrawTree()
        {
            if (null == root)
                return;

            root.Children.Clear();

            IDictionary<Int32, Person> temp = model.BuildTree(DrawingPersonCode);//здесь и далее 1 - код челвека для которого рисуем, потом изменить

            maxlvl = 0;
            genTreelistBox.DataSource = CountNodesLevels(DrawingPersonCode, temp);

            genTreelistBox.SelectedIndex = -1;
            do
            {
                genTreelistBox.SelectedIndex++;
            } while (genTreelistBox.SelectedItem.GetHashCode() != DrawingPersonCode);

            AddParentToTree(root, temp[DrawingPersonCode], temp);

            AddChildrenToTree(root, temp[DrawingPersonCode], temp);

            ArrangeTree();
        }
    
        private void CountNodesLevelsUp(Int32 code, IDictionary<Int32, Person> personsCollection, IList<TreeNodeLine> ret, Int32 level = 0)
        {
            Person currentPerson = personsCollection[code];
            ret.Add(new TreeNodeLine(currentPerson, level));
            if (level < maxlvl)
                maxlvl = level;
            foreach (Person iter in personsCollection.Values)
                if (iter.Code == currentPerson.Mother || iter.Code == currentPerson.Father)
                {
                    CountNodesLevelsUp(iter.Code, personsCollection, ret, level - 1);
                }
        }
        private void CountNodesLevelsDown(Int32 code, IDictionary<Int32, Person> personsCollection, IList<TreeNodeLine> ret, Int32 level = 0)
        {
            Person currentPerson = personsCollection[code];
            foreach (Person iter in personsCollection.Values)
                if (iter.Mother == currentPerson.Code || iter.Father == currentPerson.Code)
                {
                    ret.Add(new TreeNodeLine(iter, level + 1));
                    CountNodesLevelsDown(iter.Code, personsCollection, ret, level + 1);
                }
        }
        private IList<TreeNodeLine> CountNodesLevels(Int32 code, IDictionary<Int32, Person> personsCollection)
        {
            List<TreeNodeLine> ret = new List<TreeNodeLine>();

            CountNodesLevelsUp(code, personsCollection, ret);
            CountNodesLevelsDown(code, personsCollection, ret);

            ret.Sort();
            return ret;
        }

        private void AddParentToTree(TreeNode<CircleNode> root, Person me, IDictionary<Int32, Person> temp)
        {
            if (temp.ContainsKey(me.Mother) && null != temp[me.Mother])
            {
                TreeNode<CircleNode> t = new TreeNode<CircleNode>(new CircleNode(temp[me.Mother].ToString(), false));
                root.AddChild(t);
                AddParentToTree(t, temp[me.Mother], temp);
            }
            if (temp.ContainsKey(me.Father) && null != temp[me.Father])
            {
                TreeNode<CircleNode> t = new TreeNode<CircleNode>(new CircleNode(temp[me.Father].ToString(), false));
                root.AddChild(t);
                AddParentToTree(t, temp[me.Father], temp);
            }
        }
        private void AddChildrenToTree(TreeNode<CircleNode> root, Person me, IDictionary<Int32, Person> temp)
        {
            IList<Person> childs = model.GetPeopleByParentCode(me.Code);
            foreach (Person p in childs)
            {
                TreeNode<CircleNode> t = new TreeNode<CircleNode>(new CircleNode(temp[p.Code].ToString(), true));
                root.AddChild(t);
                AddChildrenToTree(t,temp[p.Code],temp);
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            if (null != root)
                root.DrawTree(e.Graphics);
        }

        private void preViewButton_Click(object sender, EventArgs e)
        {
            if (null != genTreelistBox.SelectedItem)
            {
                AddForm preViewForm = new AddForm(((TreeNodeLine)genTreelistBox.SelectedItem).PersonData, model);
                preViewForm.Enabled = true;
                preViewForm.ShowDialog();
                if (preViewForm.DialogResult == DialogResult.OK)
                    DrawTree();
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            xshift = e.X;
            yshift = e.Y;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (null == root)
                return;

            using (Graphics gr = this.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                IDictionary<int, float> levw = new Dictionary<int, float>();
                xglshift += e.X - xshift;
                yglshift+= e.Y - yshift;
                root.Arrange(gr, ref levw, 0, maxlvl, xglshift, yglshift);
            }

            // Redraw.
            this.Refresh();
        }

        private void goToButton_Click(object sender, EventArgs e)
        {
            if (null != genTreelistBox.SelectedItem)
            {
                Person drawingPerson=((TreeNodeLine)genTreelistBox.SelectedItem).PersonData;
                DrawingPersonCode = drawingPerson.Code;
                root = new TreeNode<CircleNode>(new CircleNode(drawingPerson.ToString(), false));
                DrawTree();
            }
        }
    }
}

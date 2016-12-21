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

        private void новыйРодственникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm(model);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
            this.Refresh();
        }

        private void человекаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm(model);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                form.Close();
            }
            if (form.DialogResult == DialogResult.OK)
            {
                DrawingPersonCode = form.ReturnValue.Code;
                findRelationsToolStripMenuItem.Enabled = true;
                root = new TreeNode<CircleNode>(new CircleNode(form.ReturnValue.ToString(), true));
                DrawTree();
                form.Close();
            }
            this.Refresh();
        }

        private void определитьРодствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm relatFindForm = new FindForm(model);
            relatFindForm.ShowDialog();
            Int32 codeToFind = relatFindForm.ReturnValue.Code;

            IDictionary<Int32, Person> cur = model.BuildTree(DrawingPersonCode);

            if (cur.ContainsKey(codeToFind))
            {
                MessageBox.Show("Кровное родство", "Определение родства", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IDictionary<Int32, Person> toFind = model.BuildTree(codeToFind);
            foreach (Int32 keyTofind in toFind.Keys)
                if (cur.ContainsKey(keyTofind)) 
                {
                    MessageBox.Show("Некровное родство", "Определение родства", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            MessageBox.Show("Родства нет", "Определение родства", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // The root node.
        private TreeNode<CircleNode> root = null;

        private void ArrangeTree()
        {
            using (Graphics gr = this.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xdmin = 0,xumin=0, ydmin = 0, yumin = 0;
                root.Arrange(gr, ref xdmin, ref xumin, ref ydmin, ref yumin);

                // Arrange the tree again to center it.
                xdmin = (this.ClientSize.Width - xdmin) / 4;
                xumin = (this.ClientSize.Width - xumin) / 4;
                ydmin = (this.ClientSize.Height - ydmin) / 3;
                yumin = (this.ClientSize.Height - yumin) / 3;
                root.Arrange(gr, ref xdmin, ref xumin, ref ydmin, ref yumin);
            }

            // Redraw.
            this.Refresh();
        }
        private void DrawTree()
        {
            IDictionary<Int32, Person> temp = model.BuildTree(DrawingPersonCode);//здесь и далее 1 - код челвека для которого рисуем, потом изменить
            // TreeNode<CircleNode> a_node =
            //         new TreeNode<CircleNode>(new CircleNode("отец",false));
            // TreeNode<CircleNode> b_node =
            //     new TreeNode<CircleNode>(new CircleNode("мать",false));

            AddParentToTree(root, temp[DrawingPersonCode], temp);

            ArrangeTree();

            //IList<TreeNodeLine> tableSource = new List<TreeNodeLine>();

//             foreach (Person person in temp.Values)
//                 tableSource.Add(new TreeNodeLine(person, 973)); //973 - уровень родственника

            genTreelistBox.DataSource = CountNodesLevels(DrawingPersonCode, temp);

            genTreelistBox.SelectedIndex = -1;
            do
            {
                genTreelistBox.SelectedIndex++;
            } while (genTreelistBox.SelectedItem.GetHashCode() != DrawingPersonCode);
        }
    
        private void CountNodesLevelsUp(Int32 code, IDictionary<Int32, Person> personsCollection, IList<TreeNodeLine> ret, Int32 level = 0)
        {
            Person currentPerson = personsCollection[code];
            ret.Add(new TreeNodeLine(currentPerson, level));
            foreach (Person iter in personsCollection.Values)
                if (iter.Code==currentPerson.Mother|| iter.Code==currentPerson.Father)
                    CountNodesLevelsUp(iter.Code, personsCollection, ret, level - 1);
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
        private void StartWin_Load(object sender, EventArgs e)
        {
            //DrawTree();
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            if (null != root)
                root.DrawTree(e.Graphics);
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
//            ArrangeTree();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (null != genTreelistBox.SelectedItem)
            {
                AddForm preViewForm = new AddForm(((TreeNodeLine)genTreelistBox.SelectedItem).PersonData);
                preViewForm.Show();
            }
        }
    }
}

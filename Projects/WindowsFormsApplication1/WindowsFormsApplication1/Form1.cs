using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
           
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowColor = true;
            DialogResult DR = this.colorDialog1.ShowDialog();
            if (DR == DialogResult.OK)
            {
                this.textBox1.ForeColor = this.colorDialog1.Color;


            }
            
    }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowColor = true;
            DialogResult dr = this.fontDialog1.ShowDialog();
            if(dr==DialogResult.OK){
                
                this.textBox1.Font = this.fontDialog1.Font;
                this.textBox1.ForeColor = this.fontDialog1.Color;

            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                wordWrapToolStripMenuItem.Checked = false;
                this.textBox1.WordWrap = false;
            }
            else if (wordWrapToolStripMenuItem.Checked==false){
                wordWrapToolStripMenuItem.Checked = true;
            this.textBox1.WordWrap=true;
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.wordWrapToolStripMenuItem.Checked = true;
            this.textBox1.WordWrap = true;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title =openFileDialog1.FileName;
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Browse Text Files";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK) {
                string fname = openFileDialog1.FileName;
                textBox1.Text = System.IO.File.ReadAllText(fname);
                
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "all (*.txt) |*.txt|All files(*.*)|*.*";
            openFileDialog1.DefaultExt = "txt";
            DialogResult Dr = this.saveFileDialog1.ShowDialog();
            
            if(Dr==DialogResult.OK){
            string fname=saveFileDialog1.FileName;
            System.IO.File.WriteAllText(fname, this.textBox1.Text);

            }
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "all (*.txt) |*.txt|All files(*.*)|*.*";
            openFileDialog1.DefaultExt = "txt";

            if (textBox1.Text == "")
            {
                DialogResult dr = this.saveFileDialog1.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    string fname = saveFileDialog1.FileName;
                    System.IO.File.WriteAllText(fname, this.textBox1.Text);


                }
            }
            else if (textBox1.Text == "Text")
            {
                string fname = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(fname, this.textBox1.Text);
            }

        }
        
    }
}
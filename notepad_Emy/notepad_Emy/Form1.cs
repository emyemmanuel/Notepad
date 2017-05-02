using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace notepad_Emy
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        int flag = 0;
        string name;

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //will work only in rich text box
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            SaveFileDialog savedialog = new SaveFileDialog();
            //savedialog.Title = "Save";
            savedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            savedialog.Filter="Text documents (*.txt)|*.txt|All Files|*.*";
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                flag = 1;
                sw = new StreamWriter(savedialog.FileName);
                name = savedialog.FileName;
                sw.WriteLine(textBox1.Text);
                sw.Flush();
                sw.Close();
            }
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sr;
            OpenFileDialog opendialog = new OpenFileDialog();
             opendialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            opendialog.Filter = "Text documents (*.txt)|*.txt|All Files|*.*";
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                flag = 1;
                name=opendialog.FileName;
                sr = new StreamReader(opendialog.FileName);
                textBox1.Text=sr.ReadToEnd();
                sr.Close();
            }
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontdialog = new FontDialog();
            fontdialog.ShowDialog();
            textBox1.Font = fontdialog.Font;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("do you want to save changes", "NotepaD_EMY", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (result == DialogResult.OK)
            //{
            //    saveToolStripMenuItem_Click(sender, e);

            //}
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                DialogResult result = MessageBox.Show("do you want to save changes", "NotepaD_EMY", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result==DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    
                }
                if (result == DialogResult.Cancel)
                {
                    textBox1.Focus();
                    e.Cancel = true;

                }
                
        }
       
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
         
            else
            {
                StreamWriter sw;
                SaveFileDialog savedialog = new SaveFileDialog();
                sw = new StreamWriter(name);
                sw.WriteLine(textBox1.Text);
                sw.Flush();
                sw.Close();
            }
         }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("do you want to save changes", "NotepaD_EMY", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                saveToolStripMenuItem_Click(sender, e);
                
            }
            Form1 f = new Form1();
            flag = 0;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}


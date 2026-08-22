using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Windowscalendar
{
    public partial class Form1 : Form
    {
        public static String[] cards = { };
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void  exitToolStripMenuItem_Click_1(object sender, EventArgs e)

        {
            Application.Exit();
        }

        private void addCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Resize(ref cards, cards.Length + 1);
            cards[cards.Length - 1] = textBox2.Text;
            listBox1.Items.Add(textBox1.Text);

        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String s = "";
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Trim() != "")
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    s = s + listBox1.Items[i].ToString() + "\x02" + cards[i] + "\x01";

                }
                File.WriteAllText(saveFileDialog1.FileName, s);
            }
        }

        private void  newToolStripMenuItem_Click_1(object sender, EventArgs e)

        {
            String s = "";
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Trim() != "")
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    s = s + listBox1.Items[i].ToString() + "\x02" + cards[i] + "\x01";

                }
                File.WriteAllText(saveFileDialog1.FileName, "s");
            }
            textBox2.Text = "";
            textBox1.Text = "";
            listBox1.Items.Clear();
            Array.Resize(ref cards, 0);
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            String[] s = { };
            String[] ss = { };
            int counter = 0;
            listBox1.Items.Clear();
            Array.Resize(ref cards, 0);

            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Trim() != "")
            {
                s = File.ReadAllText(openFileDialog1.FileName).Trim().Split('\x01');
                Array.Resize(ref cards, s.Length - 1);

                MessageBox.Show(cards.Length.ToString());
                foreach (var s2 in s)
                {
                    ss = s2.Split('\x02');
                    if (ss.Length > 1)
                    {
                        listBox1.Items.Add(ss[0]);
                        cards[counter] = ss[1];

                    }
                    counter = counter + 1;

                }


            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
            textBox2.Text = cards[listBox1.SelectedIndex];
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String s = "";
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Trim() != "")
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    s = s + listBox1.Items[i].ToString() + "\x02" + cards[i] + "\x01";

                }
                File.WriteAllText(saveFileDialog1.FileName, "s");
            }
            textBox2.Text = "";
            textBox1.Text = "";
            listBox1.Items.Clear();
            Array.Resize(ref cards, 0);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text= monthCalendar1.SelectionStart.ToString();
        }

        
    }
}

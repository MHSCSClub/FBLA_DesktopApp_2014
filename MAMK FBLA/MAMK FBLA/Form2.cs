using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace MAMK_FBLA
{
    public partial class Form2 : Form
    {
        string file;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadConf();
            //loadType();
        }
        private void loadType()
        {
            //Load conferences
            file = "TYPE.txt";
            string filePath = @".\data\" + file;
            StreamReader sr = new StreamReader(filePath);
            var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                lines.Add(Line);
                Row++;
                //Console.WriteLine(Row);
            }
            foreach (string[] rowArray in lines)
            {
                Type.Items.Add(rowArray[1]);
            }
        }
        private void loadConf()
        {
            //Load conferences
            file = "CONFERENCES.txt";
            string filePath = @".\data\" + file;
            StreamReader sr = new StreamReader(filePath);
            var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                lines.Add(Line);
                Row++;
                //Console.WriteLine(Row);
            }
            foreach (string[] rowArray in lines)
            {
                Conf.Items.Add(rowArray[1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conf = Conf.Text;
            string type = Type.Text;
            string first = First.Text;
            string last = Last.Text;
            string chap = Chap.Text;
            string writeToFile = conf + ',';//...
            //TODO: write to file
            Close();
        }
    }
}

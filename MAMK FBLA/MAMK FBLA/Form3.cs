using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;



namespace MAMK_FBLA
{
    public partial class Form3 : Form
    {
   
        string file;
        public Form3(string fName)
        {
            file = fName;
            InitializeComponent();
        }
        private void InitializeDataGridView()
        {
            /*
            // Create an unbound DataGridView by declaring a column count.
            dataGridView1.ColumnCount = 4;
            dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView1.Columns.Add("A","A");
            dataGridView1.Columns.Add("A","A");
            dataGridView1.Columns.Add("A","A");
            dataGridView1.Columns.Add("A","A");


            string filePath = @".\data\"+file;
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
                dataGridView1.Rows.Add(rowArray);
            }
             */
        }



        private void InitializeContextMenu()
        {
            // Create the menu item.
            ToolStripMenuItem getRecipe = new ToolStripMenuItem("Search for recipe", null,
                new System.EventHandler(ShortcutMenuClick));

            // Add the menu item to the shortcut menu.
            ContextMenuStrip recipeMenu = new ContextMenuStrip();
            recipeMenu.Items.Add(getRecipe);

            // Set the shortcut menu for the first column.
            dataGridView1.Columns[0].ContextMenuStrip = recipeMenu;
            dataGridView1.MouseDown += new MouseEventHandler(dataGridView1_MouseDown);
        }

        private DataGridViewCell clickedCell;

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // If the user right-clicks a cell, store it for use by the shortcut menu. 
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell =
                        dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                }
            }
        }

        private void ShortcutMenuClick(object sender, System.EventArgs e)
        {
            if (clickedCell != null)
            {
                //Retrieve the recipe name. 
                string recipeName = (string)clickedCell.Value;

                //Search for the recipe.
                System.Diagnostics.Process.Start(
                    "http://search.msn.com/results.aspx?q=" + recipeName);
                //null);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
             InitializeDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Resize the height of the column headers. 
            dataGridView1.AutoResizeColumnHeadersHeight();

            // Resize all the row heights to fit the contents of all non-header cells.
            dataGridView1.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented!!!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }



      
    }
}

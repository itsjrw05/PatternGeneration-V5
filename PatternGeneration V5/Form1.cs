using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternGeneration_V5
{
    public partial class Form1 : Form
    {
        SaveFileDialog saveFileDialog;

        int xSize;
        int ySize;

        int colors;

        int xSizeValue;
        int ySizeValue;

        int colorsValue;

        int startValue;
        int indexValue;

        List<int> colorsValueList = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            xSize = Int32.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ySize = Int32.Parse(textBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            colors = Int32.Parse(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors; i++)
            {
                for (int j = 0; j < colors - 1; j++)
                {
                    Generate();
                }
            }
        }

        private void Generate()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int x = 0; x < xSize; x++)
            {
                dataGridView1.Columns.Add("Column" + x, "Column" + x);
            }

            for (int y = 0; y < ySize - 1; y++)
            {
                dataGridView1.Rows.Add();
            }

            colorsValue = colorsValue + startValue;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = colorsValue;

                    colorsValue = colorsValue + 1;

                    if (colorsValue >= colors)
                    {
                        colorsValue = 0;
                    }
                }
            }

            startValue = startValue + 1;

            if (startValue >= colors)
            {
                startValue = 0;
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    CreateArray(i, j);
                    RemoveArray(i, j);
                    ImplementArray(i, j);
                }
            }

            indexValue = indexValue + 1;

            if (indexValue >= 0)
            {
                indexValue = 0;
            }

            //Verify();
            //Save();
        }

        private void CreateArray(int i, int j)
        {
            colorsValueList.Clear();

            for (int k = 0; k < colors; k++)
            {
                colorsValueList.Add(k);
            }
        }

        private void RemoveArray(int i, int j)
        {
            colorsValueList.Remove((int)dataGridView1.Rows[Math.Min(ySize - 2, Math.Max(0, j + 1))].Cells[i].Value);
            colorsValueList.Remove((int)dataGridView1.Rows[Math.Min(ySize - 2, Math.Max(0, j - 1))].Cells[i].Value);
            colorsValueList.Remove((int)dataGridView1.Rows[j].Cells[Math.Min(xSize - 2, Math.Max(0, i + 1))].Value);
            colorsValueList.Remove((int)dataGridView1.Rows[j].Cells[Math.Min(xSize - 2, Math.Max(0, i - 1))].Value);
        }

        private void ImplementArray(int i, int j)
        {
            dataGridView1.Rows[j].Cells[i].Value = colorsValueList[indexValue];
        }

        private void Verify()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (dataGridView1.Rows[Math.Min(ySize - 1, Math.Max(0, j + 1))].Cells[i].Value != dataGridView1.Rows[j].Cells[i].Value)
                    {
                        if (dataGridView1.Rows[Math.Min(ySize - 1, Math.Max(0, j - 1))].Cells[i].Value != dataGridView1.Rows[j].Cells[i].Value)
                        {
                            if (dataGridView1.Rows[j].Cells[Math.Min(xSize - 1, Math.Max(0, i + 1))].Value != dataGridView1.Rows[j].Cells[i].Value)
                            {
                                if (dataGridView1.Rows[j].Cells[Math.Min(xSize - 1, Math.Max(0, i - 1))].Value != dataGridView1.Rows[j].Cells[i].Value)
                                {

                                }
                                else
                                {
                                    Generate();
                                }
                            }
                            else
                            {
                                Generate();
                            }
                        }
                        else
                        {
                            Generate();
                        }
                    }
                    else
                    {
                        Generate();
                    }
                }
            }
        }

        private void Save()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}

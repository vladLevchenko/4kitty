using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
	public partial class Form1 : Form
	{
		double somefunc(double[][] MatrixA, double[] MatrixB, double[][] MatrixD, double[] X, int i, double ver)
		{

			double MultRes1, MultRes2;
			MultRes1 = MultRes2 = 0;
			for (int j = 0; j < MatrixA.Length; j++)
			{
				MultRes1 += MatrixA[j][i] * X[j];
				MultRes2 += Math.Pow(X[j], 2) * MatrixD[j][i];

			}

			return -MatrixB[i] + MultRes1 + ver * Math.Sqrt(MultRes2);
		}



		public Form1()
		{
			InitializeComponent();

			radioButton1.Checked = true;

			this.dataGridView1.RowHeadersWidth = 150;
			this.dataGridView1.Rows.Add(4);
			this.dataGridView1.Rows[1].HeaderCell.Value = "Токарный станок";
			this.dataGridView1.Rows[2].HeaderCell.Value = "Фрезельный станок";
			this.dataGridView1.Rows[3].HeaderCell.Value = "Строгальный станок";
			for (int i = 0; i < 2; i++)
			{
				this.dataGridView1[i * 2, 0].Value = "E";
				this.dataGridView1[i * 2 + 1, 0].Value = "D";

			}
			this.dataGridView1[0, 1].Value = "0.4";
			this.dataGridView1[1, 1].Value = "0.2";
			this.dataGridView1[2, 1].Value = "0.5";
			this.dataGridView1[3, 1].Value = "0.2";

			this.dataGridView1[0, 2].Value = "0.3";
			this.dataGridView1[1, 2].Value = "0.15";
			this.dataGridView1[2, 2].Value = "0";
			this.dataGridView1[3, 2].Value = "0";


			this.dataGridView1[0, 3].Value = "0.5";
			this.dataGridView1[1, 3].Value = "0.3";
			this.dataGridView1[2, 3].Value = "0.9";
			this.dataGridView1[3, 3].Value = "0.45";

			this.dataGridView2.RowHeadersWidth = 150;
			this.dataGridView2.Rows.Add(1);
			this.dataGridView2.Rows[0].HeaderCell.Value = "Прибыль";

			this.dataGridView2[0, 0].Value = "30";
			this.dataGridView2[1, 0].Value = "40";
			this.dataGridView2[2, 0].Value = "20";

			List<string> vegetables = new List<string> { "0.9", "0.85", "0.75", "0.7", "0.65" };

			comboBox1.DataSource = vegetables;
			this.dataGridView3.RowHeadersWidth = 150;
			this.dataGridView3.Rows.Add(4);
			this.dataGridView3.Rows[1].HeaderCell.Value = "Токарный станок";
			this.dataGridView3.Rows[2].HeaderCell.Value = "Фрезельный станок";
			this.dataGridView3.Rows[3].HeaderCell.Value = "Строгальный станок";
			for (int i = 0; i < 3; i++)
			{
				this.dataGridView3[i * 2, 0].Value = "E";
				this.dataGridView3[i * 2 + 1, 0].Value = "D";
			}
			this.dataGridView3[0, 1].Value = "0.6";
			this.dataGridView3[1, 1].Value = "0.3";
			this.dataGridView3[2, 1].Value = "0.5";
			this.dataGridView3[3, 1].Value = "0.2";
			this.dataGridView3[4, 1].Value = "1";
			this.dataGridView3[5, 1].Value = "0.5";

			this.dataGridView3[0, 2].Value = "0.4";
			this.dataGridView3[1, 2].Value = "0.4";
			this.dataGridView3[2, 2].Value = "0.6";
			this.dataGridView3[3, 2].Value = "0.1";
			this.dataGridView3[4, 2].Value = "0.4";
			this.dataGridView3[5, 2].Value = "0.2";

			this.dataGridView3[0, 2].Value = "0.9";
			this.dataGridView3[1, 2].Value = "0.3";
			this.dataGridView3[2, 2].Value = "0.8";
			this.dataGridView3[3, 2].Value = "0.5";
			this.dataGridView3[4, 2].Value = "0.5";
			this.dataGridView3[5, 2].Value = "0.3";

			this.dataGridView4.RowHeadersWidth = 150;
			this.dataGridView4.Rows.Add(4);
			this.dataGridView4.Rows[1].HeaderCell.Value = "Токарный станок";
			this.dataGridView4.Rows[2].HeaderCell.Value = "Фрезельный станок";
			this.dataGridView4.Rows[3].HeaderCell.Value = "Строгальный станок";
			for (int i = 0; i < 2; i++)
			{
				this.dataGridView4[i * 2, 0].Value = "E";
				this.dataGridView4[i * 2 + 1, 0].Value = "D";
			}
			this.dataGridView4[0, 1].Value = "0.8";
			this.dataGridView4[1, 1].Value = "0.3";
			this.dataGridView4[2, 1].Value = "0";
			this.dataGridView4[3, 1].Value = "0";

			this.dataGridView4[0, 2].Value = "0.2";
			this.dataGridView4[1, 2].Value = "0.2";
			this.dataGridView4[2, 2].Value = "1";
			this.dataGridView4[3, 2].Value = "0.5";

			this.dataGridView4[0, 3].Value = "0";
			this.dataGridView4[1, 3].Value = "0";
			this.dataGridView4[2, 3].Value = "1.5";
			this.dataGridView4[3, 3].Value = "0.8";

			this.dataGridView5.RowHeadersWidth = 150;
			this.dataGridView5.Rows.Add(3);
			this.dataGridView5.Rows[0].HeaderCell.Value = "Токарный станок";
			this.dataGridView5.Rows[1].HeaderCell.Value = "Фрезельный станок";
			this.dataGridView5.Rows[2].HeaderCell.Value = "Строгальный станок";


			this.dataGridView5[0, 0].Value = "400";
			this.dataGridView5[0, 1].Value = "300";
			this.dataGridView5[0, 2].Value = "500";
		}

		
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{


		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			double ver;
			string pr = comboBox1.Text;
			switch (pr)
			{
				//  case "0.95": ver = 0.65788; break;
				case "0.9": ver = 0.63188; break;
				case "0.85": ver = 0.60468; break;
				case "0.8": ver = 0.57628; break;
				case "0.75": ver = 0.54674; break;
				case "0.7": ver = 0.51607; break;
				case "0.65": ver = 0.4843; break;
				case "0.6": ver = 0.4515; break;
				default: ver = 0.45149; break;
			}

			//double[][][] matr_a = new double[3][][];

			//matr_a[0] = new double[this.dataGridView1.ColumnCount / 2][];
			//matr_a[1] = new double[this.dataGridView3.ColumnCount / 2][];
			//matr_a[2] = new double[this.dataGridView4.ColumnCount / 2][];

			//for (int i = 0; i < matr_a.Length; i++)
			//{
			//    for (int j = 0; j < matr_a[i].Length; i++)
			//    {
			//        matr_a[i][j] = new double[this.dataGridView1.RowCount - 1];
			//    }
			//}

			//for (int i = 0; i < matr_a[0].Length; i++)
			//{
			//    for (int j = 0; j < matr_a[0][i].Length; i++)
			//    {
			//        matr_a[0][i][j] = Double.Parse(this.dataGridView1[i * 2, j + 1].Value.ToString());
			//    }
			//}

			//for (int i = 0; i < matr_a[1].Length; i++)
			//{
			//    for (int j = 0; j < matr_a[1][i].Length; i++)
			//    {
			//        matr_a[1][i][j] = Double.Parse(this.dataGridView2[i * 2, j + 1].Value.ToString());
			//    }
			//}

			//for (int i = 0; i < matr_a[2].Length; i++)
			//{
			//    for (int j = 0; j < matr_a[2][i].Length; i++)
			//    {
			//        matr_a[2][i][j] = Double.Parse(this.dataGridView3[i * 2, j + 1].Value.ToString());
			//    }
			//}

			//double[][][] matr_d = new double[3][][];

			//matr_d[0] = new double[this.dataGridView1.ColumnCount / 2][];
			//matr_d[1] = new double[this.dataGridView3.ColumnCount / 2][];
			//matr_d[2] = new double[this.dataGridView4.ColumnCount / 2][];

			//for (int i = 0; i < matr_d.Length; i++)
			//{
			//    for (int j = 0; j < matr_d[i].Length; i++)
			//    {
			//        matr_d[i][j] = new double[this.dataGridView1.RowCount - 1];
			//    }
			//}

			//for (int i = 0; i < matr_d[0].Length; i++)
			//{
			//    for (int j = 0; j < matr_d[0][i].Length; i++)
			//    {
			//        matr_d[0][i][j] = Double.Parse(this.dataGridView1[i * 2 + 1, j + 1].Value.ToString());
			//    }
			//}

			//for (int i = 0; i < matr_d[1].Length; i++)
			//{
			//    for (int j = 0; j < matr_d[1][i].Length; i++)
			//    {
			//        matr_d[1][i][j] = Double.Parse(this.dataGridView2[i * 2 + 1, j + 1].Value.ToString());
			//    }
			//}

			//for (int i = 0; i < matr_d[2].Length; i++)
			//{
			//    for (int j = 0; j < matr_d[2][i].Length; i++)
			//    {
			//        matr_d[2][i][j] = Double.Parse(this.dataGridView3[i * 2 + 1, j + 1].Value.ToString());
			//    }
			//}

			//int n = 0;
			//int m = this.dataGridView1.RowCount - 1;
			//for (int i = 0; i < matr_a.Length; i++)
			//{
			//    n += matr_a[i].Length;
			//}

			//double[][] MatrixA = new double[n][];
			//double[][] MatrixD = new double[n][];
			//double[] MatrixB = new double[m];
			//double[] MatrixC = new double[m];

			//for (int i = 0; i < n; i++)
			//{
			//    MatrixA[i] = new double[m];
			//    MatrixD[i] = new double[m];
			//}

			//for (int i = 0; i < m; i++)
			//{
			//    MatrixC[i] = Double.Parse(dataGridView2[i, 0].Value.ToString());
			//    MatrixC[i] = Double.Parse(dataGridView5[0, i].Value.ToString());
			//}

			//for (int i = 0; i < matr_a.Length; i++)
			//{
			//    int k = 0;
			//    for (int j = 0; j < i; j++)
			//    {
			//        k += matr_a[j].Length;
			//    }
			//    for (int j = 0; j < matr_a[i].Length; j++)
			//    {
			//        for (int q = 0; q < matr_a[i][j].Length; q++)
			//        {
			//            MatrixA[k + j][q] = matr_a[i][j][q];
			//            MatrixD[k + j][q] = matr_d[i][j][q];
			//        }
			//    }
			//}

			int n = 7;
			int m = 3;
			double[][] MatrixA = new double[][]{new double[]{ 0.4, 0.8, 0.6 }, new double[] { 0.5, 0, 0.9},
				new double[] { 0.6, 0.4, 0.9}, new double[] { 0.5, 0.6, 0.8}, new double[] { 1, 0.4, 0.5},
				new double[] { 0.8, 0.2, 0}, new double[] { 0, 1, 1.5} };
			double[][] MatrixD = new double[][]{new double[]{ 0.2, 0.5, 0.3 }, new double[] { 0.2, 0, 0.45},
				new double[] { 0.3, 0.4, 0.3}, new double[] { 0.2, 0.1, 0.5}, new double[] { 0.5, 0.2, 0.3},
				new double[] { 0.3, 2, 0}, new double[] { 0, 0.5, 0.8} };
			double[] MatrixB = new double[] { 400, 300, 500 };
			double[] MatrixC = new double[] { 30, 40, 20 };

			double r = 1.5;// Convert.ToDouble(textBox1.Text);
			int b = 2;//  Convert.ToInt16(textBox2.Text);
			int p = 2;//  Convert.ToInt16(textBox3.Text);

			mefunc f = new mefunc();
			double[] x = new double[MatrixA.Length];
			try
			{
				if (radioButton1.Checked)
					x = f.func1(MatrixC, MatrixA, MatrixB, MatrixD, r, b, p, ver);
				else
					x = f.func2(MatrixC, MatrixA, MatrixB, MatrixD, r, b, p, ver);
				double sum = 0;
				double[] X = new double[m];
				for (int i = 0; i < x.Length; i++)
				{
					x[i] = Convert.ToInt32(x[i]);
				}
				X[0] = x[0] + x[1];
				X[1] = x[2] + x[3] + x[4];
				X[2] = x[5] + x[6];

				if (radioButton1.Checked)
				{
					for (int i = 0; i < X.Length; i++)
					{
						sum += MatrixC[i] * X[i];
					}
				}
				else
				{
					for (int i = 0; i < X.Length; i++)
					{
						sum += MatrixC[i] * X[i];
					}
				}
				richTextBox1.Text =
				"x1 = " + X[0].ToString() + ";\n" +
				" 1-м методом=" + x[0].ToString() + ";\n" +
				" 2-м методом=" + x[1].ToString() + ";\n" +
				"x2 = " + X[1].ToString() + ";\n" +
				" 1-м методом=" + x[4].ToString() + ";\n" +
				" 2-м методом=" + x[5].ToString() + ";\n" +
				" 3-м методом=" + x[6].ToString() + ";\n" +
				"x3 = " + X[2].ToString() + ";" +
				" 1-м методом=" + x[5].ToString() + ";\n" +
				" 2-м методом=" + x[6].ToString() + ";\n";
				textBox4.Text = sum.ToString();
				textBox6.Text = somefunc(MatrixA, MatrixB, MatrixD, x, 0, ver).ToString();
				textBox7.Text = somefunc(MatrixA, MatrixB, MatrixD, x, 1, ver).ToString();
				textBox8.Text = somefunc(MatrixA, MatrixB, MatrixD, x, 2, ver).ToString();
			}
			catch (Exception)
			{
				MessageBox.Show("Слишком большой шаг", "Ошибка");


			}
		}
	}

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace Coursework
{
	public class grad
	{
		double GetNorm(double[] x)
		{
			double res = 0;
			for (int i = 0; i < x.Length; i++)
			{
				res += Math.Pow(x[i], 2);
			}
			res = Math.Pow(res, 0.5);
			return res;
		}

		double[] GetDelta(double[] v1, double[] v2)
		{
			double[] res = new double[v1.Length];
			for (int i = 0; i < res.Length; i++)
			{
				res[i] = v1[i] - v2[i];
			}
			return res;
		}


		double FunctionF1(double[][] MatrixA, double[] lumbda, double[] MatrixB, double[] MatrixC, double[][] MatrixD, int[] MatrixJ, double r, int p, double ver)
		{
			//  p = 2;
			double MultRes3, MultRes4;
			double[] X = new double[3];
			X[0] = lumbda[0] + lumbda[1];
			X[1] = lumbda[2] + lumbda[3] + lumbda[4];
			X[2] = lumbda[5] + lumbda[6];
			MultRes3 = MultRes4 = 0;
			for (int i = 0; i < MatrixA.Length + MatrixA[0].Length; i++)
			{
				MatrixJ[i] = 1;
			}
			for (int i = 0; i < MatrixA[0].Length; i++)
			{
				double MultRes1, MultRes2;
				MultRes1 = MultRes2 = MultRes4 = 0;
				for (int j = 0; j < MatrixA.Length; j++)
				{
					MultRes1 += MatrixA[j][i] * lumbda[j];
					MultRes2 += Math.Pow(lumbda[j], 2) * MatrixD[j][i];
				}
				if (Math.Max(0, (-MatrixB[i] + MultRes1 + ver * Math.Sqrt(MultRes2))) != 0)
				{
					MultRes3 += Math.Pow(((-MatrixB[i] + MultRes1 + ver * Math.Sqrt(MultRes2))), p);
				}
				else
					MultRes3 += 0;

			}

			for (int j = 0; j < X.Length; j++)
			{
				MultRes4 += MatrixC[j] * X[j];
			}
			//for (int j = 0; j < X.Length; j++)
			//{
			//    MultRes4 -= X[j];
			//}
			//MultRes3 += Math.Pow(Math.Max(0, -(X[1] - 100)), p);
			double MultRes5 = 0;
			for (int i = 0; i < MatrixA.Length; i++)
			{
				if (Math.Max(0, -lumbda[i]) != 0)
				{
					MultRes5 += Math.Pow(-lumbda[i], p);
				}
			}

			//MultRes5 += Math.Pow(Math.Abs(X[1] - 2 * X[0]), p);
			//MultRes5 += Math.Pow(Math.Abs(X[0] - X[2]), p);
			double MultALumbda = MultRes4 - r * (MultRes3 + MultRes5);
			return MultALumbda;

		}

		public double[] GradientMethod1(double[][] MatrixA, double[] MatrixB, double[] MatrixC, double[][] MatrixD, int[] MatrixJ, double r, int p, double[] X, double ver)
		{
			//  p = 2;
			double eps = 0.001;
			int l = 0;
			double[] PrevLumbda = new double[MatrixA.Length];
			double[] CalcLumbda = new double[PrevLumbda.Length];
			double[] f = new double[100];
			for (int i = 0; i < PrevLumbda.Length; i++)
				PrevLumbda[i] = X[i];
			for (int i = 0; i < CalcLumbda.Length; i++)
				CalcLumbda[i] = X[i];
			double CurrF = FunctionF1(MatrixA, PrevLumbda, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver);
			double alfa = 100;
			double h = 1;
			// p = 2;
			double PrevF = FunctionF1(MatrixA, PrevLumbda, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver);
			double[] AntiGrad = new double[MatrixA.Length];

			int iter = 0;

			do
			{

				iter++;
				for (int w = 0; w < CalcLumbda.Length; w++)
					PrevLumbda[w] = CalcLumbda[w];
				PrevF = CurrF;
				for (int i = 0; i < AntiGrad.Length; i++)
				{
					double[] CurrLumbdaPlusH = new double[PrevLumbda.Length];
					double[] CurrLumbdaMinusH = new double[PrevLumbda.Length];
					for (int q = 0; q < CurrLumbdaPlusH.Length; q++)
					{
						if (q == i)
						{
							CurrLumbdaPlusH[q] = PrevLumbda[q] + h;
							CurrLumbdaMinusH[q] = PrevLumbda[q] - h;
						}
						else
						{
							CurrLumbdaPlusH[q] = PrevLumbda[q];
							CurrLumbdaMinusH[q] = PrevLumbda[q];
						}
					}
					AntiGrad[i] = (FunctionF1(MatrixA, CurrLumbdaPlusH, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver) - FunctionF1(MatrixA, CurrLumbdaMinusH, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver)) / (2.0 * h);
				}

				//  int t = 0;
				do
				{

					alfa = alfa / 2.0;

					for (int k = 0; k < CalcLumbda.Length; k++)
					{
						CalcLumbda[k] = PrevLumbda[k] + alfa * AntiGrad[k];
					}
					CurrF = FunctionF1(MatrixA, CalcLumbda, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver);
					//   MessageBox.Show(CurrF.ToString, "Ошибка");
				}
				while (CurrF < PrevF);
				alfa = 100;
				for (int k = 0; k < CalcLumbda.Length; k++)
				{

					CalcLumbda[k] = Convert.ToInt32(CalcLumbda[k]);


				}

			}
			while ((GetNorm(GetDelta(CalcLumbda, PrevLumbda)) > eps));


			return CalcLumbda;
		}

		double FunctionF2(double[][] MatrixA, double[] lumbda, double[] MatrixB, double[] MatrixC, double[][] MatrixD, int[] MatrixJ, double r, int p, double ver)
		{
			double MultALumbda;
			double MultRes3, MultRes4;
			double[] X = new double[3];
			X[0] = lumbda[0] + lumbda[1];
			X[1] = lumbda[2] + lumbda[3] + lumbda[4];
			X[2] = lumbda[5] + lumbda[6];
			MultRes3 = MultRes4 = 0;
			for (int i = 0; i < MatrixA.Length + MatrixA[0].Length; i++)
			{
				MatrixJ[i] = 1;
			}
			for (int i = 0; i < MatrixA[0].Length; i++)
			{
				double MultRes1, MultRes2;
				MultRes1 = MultRes2 = MultRes4 = 0;
				for (int j = 0; j < MatrixA.Length; j++)
				{
					MultRes1 += MatrixA[j][i] * lumbda[j];
					MultRes2 += Math.Pow(lumbda[j], 2) * MatrixD[j][i];
				}
				if (Math.Max(0, -(-MatrixB[i] + MultRes1 + ver * Math.Sqrt(MultRes2))) != 0)
				{
					MultRes3 += Math.Pow(-((-MatrixB[i] + MultRes1 + ver * Math.Sqrt(MultRes2))), p);
				}



			}

			for (int j = 0; j < X.Length; j++)
			{
				MultRes4 -= X[j];
			}
			double MultRes5 = 0;

			for (int i = 0; i < MatrixA.Length; i++)
			{
				if (Math.Max(0, lumbda[i]) != 0)
				{
					MultRes5 += Math.Pow(lumbda[i], p);
				}
			}


			MultRes5 += Math.Pow(Math.Abs(X[1] - 2 * X[0]), p);
			MultRes5 += Math.Pow(Math.Abs(X[0] - X[2]), p);
			MultALumbda = MultRes4 - r * (MultRes3 + MultRes5);
			return MultALumbda;
		}

		public double[] GradientMethod2(double[][] MatrixA, double[] MatrixB, double[] MatrixC, double[][] MatrixD, int[] MatrixJ, double r, int p, double[] X, double ver)
		{
			double eps = 0.001;
			int l = 0;
			double[] PrevLumbda = new double[MatrixA.Length];
			double[] CalcLumbda = new double[PrevLumbda.Length];
			double[] f = new double[100];
			for (int i = 0; i < PrevLumbda.Length; i++)
				PrevLumbda[i] = X[i];
			for (int i = 0; i < CalcLumbda.Length; i++)
				CalcLumbda[i] = X[i];
			double CurrF = FunctionF2(MatrixA, PrevLumbda, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver);
			double alfa = 100;
			double h = 1;

			double PrevF = FunctionF2(MatrixA, PrevLumbda, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver);
			double[] AntiGrad = new double[MatrixA.Length];

			int iter = 0;

			do
			{

				iter++;
				for (int w = 0; w < CalcLumbda.Length; w++)
					PrevLumbda[w] = CalcLumbda[w];
				PrevF = CurrF;
				for (int i = 0; i < AntiGrad.Length; i++)
				{
					double[] CurrLumbdaPlusH = new double[PrevLumbda.Length];
					double[] CurrLumbdaMinusH = new double[PrevLumbda.Length];
					for (int q = 0; q < CurrLumbdaPlusH.Length; q++)
					{
						if (q == i)
						{
							CurrLumbdaPlusH[q] = PrevLumbda[q] + h;
							CurrLumbdaMinusH[q] = PrevLumbda[q] - h;
						}
						else
						{
							CurrLumbdaPlusH[q] = PrevLumbda[q];
							CurrLumbdaMinusH[q] = PrevLumbda[q];
						}
					}
					AntiGrad[i] = (FunctionF2(MatrixA, CurrLumbdaPlusH, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver)
						- FunctionF2(MatrixA, CurrLumbdaMinusH, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver)) / (2.0 * h);
				}


				do
				{
					alfa = alfa / 2.0;

					for (int k = 0; k < CalcLumbda.Length; k++)
					{
						CalcLumbda[k] = PrevLumbda[k] + alfa * AntiGrad[k];
					}
					CurrF = FunctionF2(MatrixA, CalcLumbda, MatrixB, MatrixC, MatrixD, MatrixJ, r, p, ver);
				}
				while (CurrF < PrevF);
				alfa = 100;
				for (int k = 0; k < CalcLumbda.Length; k++)
				{
					CalcLumbda[k] = Convert.ToInt32(CalcLumbda[k]);
				}
			}
			while ((GetNorm(GetDelta(CalcLumbda, PrevLumbda)) > eps));


			return CalcLumbda;
		}
	}
}


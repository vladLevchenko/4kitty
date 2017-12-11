using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
	public class mefunc
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
		public double[] func1(double[] MatrixC, double[][] MatrixA, double[] MatrixB, double[][] MatrixD, double r, int b, int p, double ver)
		{
			double a;
			grad m = new grad();
			double[] X = new double[MatrixA.Length];
			int[] J;
			J = new int[MatrixA[0].Length + X.Length];

			a = 0; int mul = 1;
			Random ran = new Random();
			int l = 0;


			for (int i = 0; i < MatrixA.Length; i++)
			{
				X[i] = 100;
			}
			do
			{
				r = b * r;
				a = 0;
				l++;


				X = m.GradientMethod1(MatrixA, MatrixB, MatrixC, MatrixD, J, r, p, X, ver);

				for (int i = 0; i < MatrixA[0].Length; i++)
				{
					J[i] = (0 > somefunc(MatrixA, MatrixB, MatrixD, X, i, ver) ? 0 : 1);
				}
				for (int i = 0; i < X.Length; i++)
				{
					J[MatrixA[0].Length + i] = (0 > (-X[i]) ? 0 : 1);
				}
				double MultRes3, MultRes4;
				MultRes3 = MultRes4 = 0;
				for (int i = 0; i < MatrixA[0].Length; i++)
				{
					MultRes3 += J[i] * Math.Pow(somefunc(MatrixA, MatrixB, MatrixD, X, i, ver), p);

				}

				double MultRes5 = 0;
				for (int i = 0; i < MatrixA.Length; i++)
				{
					MultRes5 += J[MatrixA[0].Length + i] * Math.Pow(X[i], p);

				}
				a = MultRes3 + MultRes5;




			}
			while ((r * a > 0.1 && l < 300));// || (l == 0));
			return X;
		}

		public double[] func2(double[] MatrixC, double[][] MatrixA, double[] MatrixB, double[][] MatrixD, double r, int b, int p, double ver)
		{
			double a;
			grad m = new grad();
			double[] X = new double[MatrixA.Length];
			int[] J;
			J = new int[MatrixA[0].Length + X.Length];

			a = 0; int mul = 1;
			Random ran = new Random();
			int l = 0;


			for (int i = 0; i < MatrixA.Length; i++)
			{
				X[i] = 100;
			}
			do
			{
				r = b * r;
				a = 0;
				l++;

				X = m.GradientMethod2(MatrixA, MatrixB, MatrixC, MatrixD, J, r, p, X, ver);
				for (int i = 0; i < MatrixA.Length; i++)
				{
					X[i] = Convert.ToInt32(X[i]);
				}
				for (int i = 0; i < MatrixA[0].Length; i++)
				{
					J[i] = (0 > somefunc(MatrixA, MatrixB, MatrixD, X, i, ver) ? 0 : 1);
				}
				for (int i = 0; i < X.Length; i++)
				{
					J[MatrixA[0].Length + i] = (0 > (-X[i]) ? 0 : 1);
				}
				double MultRes3, MultRes4;
				MultRes3 = MultRes4 = 0;
				for (int i = 0; i < MatrixA[0].Length; i++)
				{
					MultRes3 += J[i] * Math.Pow(somefunc(MatrixA, MatrixB, MatrixD, X, i, ver), p);

				}

				double MultRes5 = 0;
				for (int i = 0; i < MatrixA.Length; i++)
				{
					MultRes5 += J[MatrixA[0].Length + i] * Math.Pow(X[i], p);

				}
				MultRes5 += Math.Pow(Math.Abs(X[1] - 2 * X[0]), p);
				MultRes5 += Math.Pow(Math.Abs(X[0] - X[2]), p);
				a = MultRes3 + MultRes5;

			}
			while (r * a > 0.1 && l < 300);
			return X;
		}

	}
}

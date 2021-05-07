using System;
using System.Text;

namespace Matrix
{
    public class MatrixClass<T> // adding a restriction
        where T : struct
    {

        int Ncol, Nrow;
        T[,] mas;

        public MatrixClass(int row, int col)
        {
            //adding cheking of a type
            if (typeof(T) != typeof(int) && typeof(T) != typeof(double) && typeof(T) != typeof(float))
            {
                throw new ArgumentException($"<T> can be only int, double, float for MatrixClass<T>");
            }
            // if N < 0 throw an exception
            IsNatural(col);
            IsNatural(row);
            this.Ncol = col;
            this.Nrow = row;
            this.mas = new T[row, col];
            // this.mas = this.Generate(generate, N);
        }

        public T this[int row, int col]//индексатор
        {
            // a full body can be changed to =>
            get => mas[row, col];
            set => mas[row, col] = value;
        }

        public T[,] Generate(Func<int, int, T[,]> generate, int row, int col)
        {
            this.mas = generate(row, col);
            return this.mas;
        }

        private bool IsNatural(int value)
        {
            return (value > 0) ? true : throw new ArgumentException("Value can't be equal to 0 or less value");
        }

        public static MatrixClass<T> operator +(MatrixClass<T> one, MatrixClass<T> two)
        {
            if (one.Ncol!=two.Ncol || one.Nrow!=two.Nrow)
            {
                throw new ArgumentException("Matrices can't be sum. The number of columns and rows of the first matrix must be equal to the number of columns and rows of the second");
            }

            MatrixClass<T> mat = new MatrixClass<T>(one.Ncol, one.Nrow);
            for (int i = 0; i < one.Nrow; i++)
            {
                for (int j = 0; j < one.Ncol; j++)
                {
                    mat[i, j] = (dynamic)one[i, j] + two[i, j];
                }
            }
            return mat;
        }

        public static MatrixClass<T> operator *(MatrixClass<T> one, MatrixClass<T> two)
        {

            MatrixClass<T> mat = new MatrixClass<T>(one.Ncol, one.Nrow);

            for (int i = 0; i < one.Nrow; i++)
            {
                for (int j = 0; j < two.Ncol; j++)
                {
                    mat[i, j] = (dynamic)0;
                    for (int k = 0; k < two.Nrow; k++)
                    {
                        mat[i, j] += (dynamic)one[i, k] * two[k, j];
                    }
                }
            }

            return mat;
        }

        //using this.N instead of matrix.N (No argument)
        public string Print()
        {
            string outmas = null;

            for (int i = 0; i < this.Nrow; i++)
            {
                bool f = false;
                for (int j = 0; j < this.Ncol; j++)
                {
                    if (f)
                    {
                        outmas += " ";
                    }
                    outmas += (Convert.ToString(this[i, j]));
                    f = true;
                }
                outmas += "\n";

            }


            return outmas;
        }

    }
}

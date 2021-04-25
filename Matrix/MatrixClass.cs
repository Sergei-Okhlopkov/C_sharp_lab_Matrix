using System;
using System.Text;

namespace Matrix
{
    public class MatrixClass<T> // adding a restriction
        where T : struct
    {

        int N;
        T[,] mas;
        
        public MatrixClass(int N)
        {
            //adding cheking of a type
            if (typeof(T) != typeof(int) && typeof(T) != typeof(double) && typeof(T) != typeof(float))
            {
                throw new ArgumentException($"<T> can be only int, double, float for MatrixClass<T>");
            }
            // if N < 0 throw an exception
            IsNatural(N);
            this.N = N;
            this.mas = new T[N, N];
           // this.mas = this.Generate(generate, N);
        }

        public T this[int i, int j]//индексатор
        {
            // a full body can be changed to =>
            get => mas[i, j];
            set => mas[i, j] = value;
        }

        public T[,] Generate(Func<int, int, T[,]> generate, int N)
        {
            this.mas = generate(N, N);
            return this.mas;
        }
      
        private bool IsNatural(int value)
        {
            return (value > 0) ? true : throw new ArgumentException("Value can't be equal to 0 or less value");
        }

        public static MatrixClass<T> operator +(MatrixClass<T> one, MatrixClass<T> two)
        {
            MatrixClass<T> mat = new MatrixClass<T>(one.N);
            for (int i = 0; i < mat.N; i++)
            {
                for (int j = 0; j < mat.N; j++)
                {
                    mat[i, j] = (dynamic)one[i, j] + two[i, j];
                }
            }
            return mat;
        }

        public static MatrixClass<T> operator *(MatrixClass<T> one, MatrixClass<T> two)
        {

            MatrixClass<T> mat = new MatrixClass<T>(one.N);

            for (int i = 0; i < mat.N; i++)
            {
                for (int j = 0; j < mat.N; j++)
                {
                    mat[i, j] = (dynamic)0;
                    for (int k = 0; k < mat.N; k++)
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

            for (int i = 0; i < this.N; i++)
            {
                bool f = false;
                for (int j = 0; j < this.N; j++)
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

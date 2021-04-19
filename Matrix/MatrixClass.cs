using System;

namespace Matrix
{
    public class MatrixClass<T>
    {

        int N;
        T[,] mas;

        Func<int, int, T[,]> generate = Fill;//делегат

        public MatrixClass(int N)
        {
            this.N = N;
            this.mas = new T[N, N];
            this.mas = this.Generate(generate, N);//используем делегат тут
        }

        public T this[int i, int j]//индексатор
        {
            get
            {
                return mas[i, j];
            }

            set
            {
                mas[i, j] = value;
            }
        }

        public T[,] Generate(Func<int, int, T[,]> generate, int N)
        {
            this.mas = generate(N, N);
            return this.mas;
        }
        public static T[,] Fill(int i, int j)
        {
            T[,] cMas = new T[i, j];
            var rand = new Random();
            for (int l = 0; l < i; l++)
            {
                for (int m = 0; m < j; m++)
                {
                    cMas[l, m] = (dynamic)rand.Next(-11, 11);
                }
            }
            return cMas;
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

        public string Print(MatrixClass<T> matrix)
        {
            string outmas = null;

            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix.N; j++)
                {
                    outmas += Convert.ToString(matrix[i, j]) + " ";
                }
                outmas+="\n";
            }


            return outmas;
        }

    }
}

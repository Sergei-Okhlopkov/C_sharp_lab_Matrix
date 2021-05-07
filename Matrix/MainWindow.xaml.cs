using System;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Diagnostics;

namespace Matrix
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        MatrixClass<int> A;
        MatrixClass<int> B;
        MatrixClass<int> S;
        Stopwatch sw = new Stopwatch();
        static Random rand = new Random();
        int row1;
        int row2;
        int col1;
        int col2;

        Func<int, int, int[,]> generate = (i, j) =>
        {
            int[,] cMas = new int[i, j];

            for (int l = 0; l < i; l++)
            {
                for (int m = 0; m < j; m++)
                {
                    cMas[l, m] = (dynamic)rand.Next(-15, 11);
                }
            }
            return cMas;
        };//делегат



        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            Gen();
        }

        //public -> private
        private void Gen()
        {


            row1 = Convert.ToInt32(firstMatrixRows.Text);
            row2 = Convert.ToInt32(seckondMatrixRows.Text);
            col1 = Convert.ToInt32(firstMatrixColumns.Text);
            col2 = Convert.ToInt32(secondMatrixColumns.Text);



            A = new MatrixClass<int>(row1, col1);
            A.Generate(generate, row1, col1);
            txtMatrixA.Text = A.Print();
            B = new MatrixClass<int>(row2, col2);
            B.Generate(generate, row2, col2);
            txtMatrixB.Text = B.Print();



        }

        private void btnSum_Click(object sender, RoutedEventArgs e)
        {
            if (col1 != col2 || row1 != row2)
            {
                MessageBox.Show("Columns and rows are not right!");
                throw new ArgumentException("Matrices can't be summed. The number of columns and rows of the first matrix must be equal to the number of columns and rows of the second");
               // return;

            }

            sw.Start();

            Sum();

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:0000}",
           ts.Seconds,
            ts.Milliseconds);
            txtTime.Text = elapsedTime;
            sw.Reset();
        }

        public void Sum()
        {
            S = A + B;
            txtMatrixS.Text = S.Print();
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            if (col1 != row2)
            {
                MessageBox.Show("Columns from matrix 1 are not shure to rows from matrix 2!!!");
                return;

            }


            sw.Start();

            Multiplication();

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00000}",
           ts.Seconds,
            ts.Milliseconds / 10);
            txtTime.Text = elapsedTime;
            sw.Reset();
        }

        public void Multiplication()
        {
            S = A * B;
            txtMatrixS.Text = S.Print();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile(txtMatrixS.Text);
        }

        private void SaveToFile(string text)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Comma-Separated Values|*.csv";
            saveFileDialog1.Title = "Сохраняем csv файл";
            saveFileDialog1.ShowDialog();


            if (saveFileDialog1.FileName != "")
            {
                using (var writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.Write(text);
                }
            }
        }
    }
}

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

        Func<int, int, int[,]> generate = MatrixClass<int>.Fill;//делегат

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            Gen();
        }

        //public -> private
        private void Gen()
        {
            if (txtSizeMatrix.Text == string.Empty) // adding cheking for empty text
            {
                MessageBox.Show("There are not any values here");
            }
            else
            {
                int N = Convert.ToInt32(txtSizeMatrix.Text);

                A = new MatrixClass<int>(N);
                A.Generate(generate,N);
                txtMatrixA.Text = A.Print();
                B = new MatrixClass<int>(N);
                B.Generate(generate, N);
                txtMatrixB.Text = B.Print();
            }
            

        }

        private void btnSum_Click(object sender, RoutedEventArgs e)
        {
            
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
            sw.Start();

            Multiplication();

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}",
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

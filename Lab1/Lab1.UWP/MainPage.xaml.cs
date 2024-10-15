using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

namespace Lab1.UWP
{
    public sealed partial class MainPage : WindowsPage
    {
        private TextBox[,] matrixTextBoxes = new TextBox[8, 8];

        public MainPage()
        {
            this.InitializeComponent();
            CreateMatrixGrid();
        }

        private void CreateMatrixGrid()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    TextBox textBox = new TextBox
                    {
                        Width = 40,
                        Height = 30,
                        Text = "0", 
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    MatrixGrid.Children.Add(textBox);

                    Grid.SetRow(textBox, row);
                    Grid.SetColumn(textBox, col);

                    matrixTextBoxes[row, col] = textBox;
                }
            }
        }

        private void OnFillRandomClicked(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    int randomValue = random.Next(1, 11);
                    matrixTextBoxes[row, col].Text = randomValue.ToString();
                }
            }
        }

        private void OnCalculateSumsClicked(object sender, RoutedEventArgs e)
        {
            int[] columnSums = new int[8];

            for (int col = 0; col < 8; col++)
            {
                int sum = 0;
                for (int row = 0; row < 8; row++)
                {
                    if (int.TryParse(matrixTextBoxes[row, col].Text, out int value))
                    {
                        sum += value;
                    }
                    else
                    {
                        matrixTextBoxes[row, col].Text = "0";
                    }
                }
                columnSums[col] = sum;
            }

            ResultListBox.Items.Clear();

            for (int i = 0; i < columnSums.Length; i++)
            {
                ResultListBox.Items.Add($"Сумма столбца {i + 1}: {columnSums[i]}");
            }
        }
    }
}

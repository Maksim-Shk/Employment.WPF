using OxyPlot;
using OxyPlot.Series;
using System.Windows;

namespace Employment.WPF
{
    public partial class ZedGraphWindow : Window
    {
        public ZedGraphWindow()
        {
            InitializeComponent();
            SetUpModel();
        }

        double[] xValues1 = { 1, 2, 3, 4, 5 };
        double[] yValues1 = { 1, 4, 9, 16, 25 };

        double[] xValues2 = { 1, 2, 3, 4, 5 };
        double[] yValues2 = { 5, 8, 11, 14, 17 };

        double[] xValues3 = { 1, 2, 3, 4, 5 };
        double[] yValues3 = { 10, 12, 14, 16, 18 };

        double[] xValues4 = { 1, 2, 3, 4, 5 };
        double[] yValues4 = { 1, 2, 3, 4, 5 };

        double[] xValues5 = { 1, 2, 3, 4, 5 };
        double[] yValues5 = { 5, 6, 7, 8, 9 };

        double[] xValues6 = { 1, 2, 3, 4, 5 };
        double[] yValues6 = { 10, 11, 12, 13, 14 };

        private void SetUpModel()
        {
            var plotModel = new PlotModel { Title = "Пример с множествами точек" };

            AddSeriesToPlot(plotModel, xValues1, yValues1, OxyColors.Red);
            AddSeriesToPlot(plotModel, xValues2, yValues2, OxyColors.Blue);
            AddSeriesToPlot(plotModel, xValues3, yValues3, OxyColors.Green);
            AddSeriesToPlot(plotModel, xValues4, yValues4, OxyColors.Yellow);
            AddSeriesToPlot(plotModel, xValues5, yValues5, OxyColors.Purple);
            AddSeriesToPlot(plotModel, xValues6, yValues6, OxyColors.Orange);

            plotView.Model = plotModel;
        }

        private void AddSeriesToPlot(PlotModel plotModel, double[] xValues, double[] yValues, OxyColor color)
        {
            var scatterSeries = new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerFill = color
            };

            for (int i = 0; i < xValues.Length; i++)
            {
                scatterSeries.Points.Add(new ScatterPoint(xValues[i], yValues[i]));
            }

            plotModel.Series.Add(scatterSeries);
        }

    }
}
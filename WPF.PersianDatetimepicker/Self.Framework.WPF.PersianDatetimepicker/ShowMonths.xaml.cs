using System.Globalization;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace Self.Framework.WPF.PersianDatetimepicker
{
    /// <summary>
    /// Interaction logic for ShowMonths.xaml
    /// </summary>
    public partial class ShowMonths : UserControl
    {
        public DateTime? SelectedDate { get; set; }

        private DateTime _currentDate = DateTime.Now;

        private PersianCalendar persianCalendar = new PersianCalendar();

        public delegate void ShowDateToLable();

        public ShowDateToLable ApplyDate { get; set; }

        public ShowMonths()
        {
            InitializeComponent();

            ShowYear();

            this.DataContext = this;
        }

        private void ClearList()
        {
            SelectedDate = null;

            for (int level = 1; level < 13; level++)
            {
                var nemeBorder = $"Border_{level}";

                var border = MainGrid.FindName(nemeBorder) as Border;

                border.Style = (Style)FindResource("BorderDayDate");

                var nemeButton = $"Button_{level}";

                var button = MainGrid.FindName(nemeButton) as Button;

                button.Style = (Style)FindResource("ButtonTransparent");
            }
        }

        private void SelectCurrentMont()
        {
            ClearList();

            var year = persianCalendar.GetYear(_currentDate);

            var yearCurrent = persianCalendar.GetYear(DateTime.Now);

            if (yearCurrent == year)
            {
                var month = persianCalendar.GetMonth(_currentDate);

                var nemeBorder = $"Border_{month}";

                var border = MainGrid.FindName(nemeBorder) as Border;

                border.Style = (Style)FindResource("BorderCurrentDay");
            }
        }

        private void ShowYear()
        {
            var year = persianCalendar.GetYear(_currentDate);

            DisplayDate.Content = year;

            SelectCurrentMont();
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentDate = _currentDate.AddYears(1);
            ShowYear();
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentDate = _currentDate.AddYears(-1);
            ShowYear();
        }

        private void Level_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;

            var split = button.Name.Split('_');

            var year = persianCalendar.GetYear(_currentDate);

            var day = persianCalendar.GetDayOfMonth(_currentDate);

            SelectedDate = new DateTime(year, Convert.ToInt32(split[1]), day, persianCalendar);

            if (ApplyDate != null)
            {
                ApplyDate.Invoke();
            }
        }
    }
}

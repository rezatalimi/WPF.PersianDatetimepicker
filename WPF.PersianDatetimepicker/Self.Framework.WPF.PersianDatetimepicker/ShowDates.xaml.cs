using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Self.Framework.WPF.PersianDatetimepicker
{
    /// <summary>
    /// Interaction logic for ShowDates.xaml
    /// </summary>
    public partial class ShowDates : UserControl
    {
        public DateTime? SelectedDate { get; set; }

        private DateTime _currentDate = DateTime.Now;

        private PersianCalendar persianCalendar = new PersianCalendar();

        public delegate void ShowDateToLable();

        public ShowDateToLable ApplyDate { get; set; }

        public ShowDates()
        {
            InitializeComponent();

            ShowMonth();

            this.DataContext = this;
        }

        private void ClearList()
        {
            SelectedDate = null;

            for (int level = 1; level < 7; level++)
            {
                for (int buttonNumber = 1; buttonNumber < 8; buttonNumber++)
                {
                    var nemeBorder = $"Border_{level}_{buttonNumber}";

                    var border = MainGrid.FindName(nemeBorder) as Border;

                    border.Style = (Style)FindResource("BorderDayDate");

                    var nemeButton = $"Button_{level}_{buttonNumber}";

                    var button = MainGrid.FindName(nemeButton) as Button;

                    button.IsEnabled = true;

                    button.Style = (Style)FindResource("ButtonTransparent");

                    button.Content = null;
                }
            }
        }

        private void FillListDays()
        {
            ClearList();

            var year = persianCalendar.GetYear(_currentDate);

            var month = persianCalendar.GetMonth(_currentDate);

            var monthNow = persianCalendar.GetMonth(DateTime.Now);

            var dayNow = persianCalendar.GetDayOfMonth(DateTime.Now);

            DateTime startDate = new DateTime(year, month, 1, persianCalendar);

            var dayOfWeek = PersianDaysOfWeek.GetDayOfWeek(startDate.DayOfWeek);

            for (int level = 1; level < 7; level++)
            {
                var startDay = level == 1 ? dayOfWeek.Number : 1;

                for (int buttonNumber = startDay; buttonNumber < 8; buttonNumber++)
                {
                    var neme = $"Button_{level}_{buttonNumber}";

                    var button = MainGrid.FindName(neme) as Button;

                    var day = persianCalendar.GetDayOfMonth(startDate);

                    var stackPanel = new StackPanel();

                    stackPanel.Children.Add(new Label
                    {
                        Content = day,
                        Style =
                        (Style)FindResource("LabelDateContent")
                    });

                    stackPanel.Children.Add(new Label 
                    { Content = (year + "-" + month + "-" + day).ToString(), Visibility = Visibility.Hidden });

                    button.Content = stackPanel;

                    var monthStartDate = persianCalendar.GetMonth(startDate);

                    if (month != monthStartDate)
                    {
                        button.IsEnabled = false;

                        button.Style = (Style)FindResource("ButtonOtherMobthDaies");
                    }

                    if (monthNow == monthStartDate && day == dayNow)
                    {
                        var nemeBorder = $"Border_{level}_{buttonNumber}";

                        var border = MainGrid.FindName(nemeBorder) as Border;

                        border.Style = (Style)FindResource("BorderCurrentDay");
                    }

                    startDate = startDate.AddDays(1);
                }
            }

            DateTime previousDate = new DateTime(year, month, 1, persianCalendar);

            for (int buttonNumber = 7; buttonNumber > 0; buttonNumber--)
            {
                var neme = $"Button_1_{buttonNumber}";

                var button = MainGrid.FindName(neme) as Button;

                if (button.Content == null)
                {
                    previousDate = previousDate.AddDays(-1);

                    var day = persianCalendar.GetDayOfMonth(previousDate);

                    button.Content = day;

                    button.IsEnabled = false;

                    button.Style = (Style)FindResource("ButtonOtherMobthDaies");
                }
            }
        }

        private void ShowMonth()
        {
            var year = persianCalendar.GetYear(_currentDate);

            var month = persianCalendar.GetMonth(_currentDate);

            DisplayDate.Content = year + " - " + PersianMonths.GetMonthByNumber(month);

            FillListDays();
        }

        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            ShowMonth();
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            ShowMonth();
        }

        private void Level_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;

            var stackPanel = button.Content as StackPanel;

            var lable = stackPanel.Children.OfType<Label>().LastOrDefault();

            var split = lable.Content.ToString().Split('-');

            SelectedDate = new DateTime(
                Convert.ToInt32(split[0]), 
                Convert.ToInt32(split[1]), 
                Convert.ToInt32(split[2]), persianCalendar);

            if(ApplyDate != null)
            {
                ApplyDate.Invoke();
            }
        }

        private void GoToDay_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentDate = DateTime.Now;
            ShowMonth();
        }
    }
}

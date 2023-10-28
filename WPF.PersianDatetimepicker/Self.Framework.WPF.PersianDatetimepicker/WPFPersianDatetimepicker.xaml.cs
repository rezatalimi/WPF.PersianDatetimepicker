using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Self.Framework.WPF.PersianDatetimepicker
{
    /// <summary>
    /// Interaction logic for WPFPersianDatetimepicker.xaml
    /// </summary>
    public partial class WPFPersianDatetimepicker : UserControl
    {
        public event EventHandler<EventArgs> SelectedDateChanged;

        public DateTime? SelectedDate { get; private set; }

        public bool ShowOnlyMonth { get; set; }

        private ShowDates showDaysDate;

        private ShowMonths showMonths;

        private PersianCalendar persianCalendar = new PersianCalendar();

        public WPFPersianDatetimepicker()
        {
            InitializeComponent();

            showDaysDate = new ShowDates();

            showDaysDate.ApplyDate = new ShowDates.ShowDateToLable(ChangeDaysDateLable);

            showMonths = new ShowMonths();

            showMonths.ApplyDate = new ShowMonths.ShowDateToLable(ChangeMonthDateLable);

            DatePopup.HorizontalOffset = DatePopup.HorizontalOffset - 70;

            Clear();

            DataContext = this;
        }

        public void Clear()
        {
            SelectedDate = null;
            Title.Text = "تاریخی انتخاب نشده";
            Title.Style = (Style)FindResource("TextBlockSelectDate");
        }

        public void SetSelectedDate(DateTime dateTime)
        {
            SelectedDate = dateTime;

            if (ShowOnlyMonth)
            {
                ChangeMonthDateLable();
            }
            else
            {
                ChangeDaysDateLable();
            }
        }

        private void ShowDatePopup_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DatePopup.IsOpen = false;

            DatePopup.Child = ShowOnlyMonth == true ? showMonths : showDaysDate;

            DatePopup.Width = ShowOnlyMonth == true ? 200 : 230;

            DatePopup.IsOpen = true;
        }

        private void DatePopup_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DatePopup.IsOpen = false;
        }

        private void ChangeDaysDateLable()
        {
            if (showDaysDate.SelectedDate.HasValue)
            {
                SelectedDate = showDaysDate.SelectedDate;

                var year = persianCalendar.GetYear(showDaysDate.SelectedDate.Value);

                var month = persianCalendar.GetMonth(showDaysDate.SelectedDate.Value);

                var day = persianCalendar.GetDayOfMonth(showDaysDate.SelectedDate.Value);

                Title.Text = year + " - " + month + " - " + day;

                Title.Style = (Style)FindResource("SelectDateNumber");

                DatePopup.IsOpen = false;

                if (SelectedDateChanged != null)
                {
                    SelectedDateChanged(this, new EventArgs());
                }
            }
        }

        private void ChangeMonthDateLable()
        {
            if (showMonths.SelectedDate.HasValue)
            {
                SelectedDate = showMonths.SelectedDate;

                var year = persianCalendar.GetYear(showMonths.SelectedDate.Value);

                var month = persianCalendar.GetMonth(showMonths.SelectedDate.Value);

                var monthName = PersianMonths.GetMonthByNumber(month);

                Title.Width = 120;

                Title.Text = year + " - " + month + " ( " + monthName + " ) ";

                Title.Style = (Style)FindResource("SelectDateNumber");

                DatePopup.IsOpen = false;

                if (SelectedDateChanged != null)
                {
                    SelectedDateChanged(this, new EventArgs());
                }
            }
        }
    }
}

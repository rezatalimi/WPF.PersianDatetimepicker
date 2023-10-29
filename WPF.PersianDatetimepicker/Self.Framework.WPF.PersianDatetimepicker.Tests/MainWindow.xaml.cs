using System.Windows;

namespace Self.Framework.WPF.PersianDatetimepicker.Tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PersianDatetimepicker.Clear();
        }

        private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PersianDatetimepicker.SetSelectedDate(DatePicker.SelectedDate.Value);
        }
    }
}

namespace Self.Framework.WPF.PersianDatetimepicker
{
    public class PersianMonths
    {
        public static PersianMonth Farvardin { get; private set; } = new PersianMonth(1, "فروردین");
        public static PersianMonth Ordibehesht { get; private set; } = new PersianMonth(2, "اردیبهشت");
        public static PersianMonth Khordad { get; private set; } = new PersianMonth(3, "خرداد");
        public static PersianMonth Tir { get; private set; } = new PersianMonth(4, "تیر");
        public static PersianMonth Mordad { get; private set; } = new PersianMonth(5, "مرداد");
        public static PersianMonth Shahrivar { get; private set; } = new PersianMonth(6, "شهریور");
        public static PersianMonth Mehr { get; private set; } = new PersianMonth(7, "مهر");
        public static PersianMonth Aban { get; private set; } = new PersianMonth(8, "آبان");
        public static PersianMonth Azar { get; private set; } = new PersianMonth(9, "آذر");
        public static PersianMonth Dey { get; private set; } = new PersianMonth(10, "دی");
        public static PersianMonth Bahman { get; private set; } = new PersianMonth(11, "بهمن");
        public static PersianMonth Esfand { get; private set; } = new PersianMonth(12, "اسفند");

        public static List<PersianMonth> Months = new List<PersianMonth>
        {
            Farvardin,Ordibehesht,Khordad,Tir,Mordad,Shahrivar,Mehr,Aban,Azar,Dey,Bahman,Esfand
        };

        public static string GetMonthByNumber(int number)
        {
            var month = Months.FirstOrDefault(x => x.Number == number);

            return month != null ? month.Name : string.Empty;
        }
    }

    public class PersianMonth
    {
        public PersianMonth(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public int Number { get; set; }
        public string Name { get; set; }
    }
}

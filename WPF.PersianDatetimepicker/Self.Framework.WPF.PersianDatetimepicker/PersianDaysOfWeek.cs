namespace Self.Framework.WPF.PersianDatetimepicker
{
    public class PersianDaysOfWeek
    {
        public static PersianDayOfWeek Shanbe { get; private set; } = new PersianDayOfWeek(1, "شنبه", "ش");
        public static PersianDayOfWeek Yekshanbe { get; private set; } = new PersianDayOfWeek(2, "یک شنبه", "ی");
        public static PersianDayOfWeek Doshanbe { get; private set; } = new PersianDayOfWeek(3, "دو شنبه", "ی");
        public static PersianDayOfWeek SeShanbe { get; private set; } = new PersianDayOfWeek(4, "سه شنبه", "ی");
        public static PersianDayOfWeek ChaahaarShanbe { get; private set; } = new PersianDayOfWeek(5, "چهار شنبه", "ی");
        public static PersianDayOfWeek PanjShanbe { get; private set; } = new PersianDayOfWeek(6, "پنج شنبه", "ی");
        public static PersianDayOfWeek Jome { get; private set; } = new PersianDayOfWeek(7, "جمعه", "ی");

        public static List<PersianDayOfWeek> DaysOfWeek = new List<PersianDayOfWeek>
        {
            Shanbe, Yekshanbe, Doshanbe, SeShanbe, ChaahaarShanbe, PanjShanbe, Jome
        };

        public static PersianDayOfWeek GetDayOfWeek(DayOfWeek dayOfWeekEnum)
        {
            PersianDayOfWeek result = Shanbe;

            switch (dayOfWeekEnum)
            {
                case DayOfWeek.Sunday:
                    result = Yekshanbe;
                    break;
                case DayOfWeek.Monday:
                    result = Doshanbe;
                    break;
                case DayOfWeek.Tuesday:
                    result = SeShanbe;
                    break;
                case DayOfWeek.Wednesday:
                    result = ChaahaarShanbe;
                    break;
                case DayOfWeek.Thursday:
                    result = PanjShanbe;
                    break;
                case DayOfWeek.Friday:
                    result = Jome;
                    break;
                case DayOfWeek.Saturday:
                    result = Shanbe;
                    break;
            }

            return result;
        }
    }

    public class PersianDayOfWeek
    {
        public PersianDayOfWeek(int number, string name, string perfix)
        {
            Number = number;
            Name = name;
            Perfix = perfix;
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public string Perfix { get; set; }
    }
}

namespace Self.Framework.WPF.PersianDatetimepicker
{
    public class PersianDaysOfWeek
    {
        public static PersianDayOfWeek Shanbe { get;private set; } = new PersianDayOfWeek(1,"شنبه","ش");
        public static PersianDayOfWeek YekSahnbe { get;private set; } = new PersianDayOfWeek(2,"یک شنبه","ی");
        public static PersianDayOfWeek DoSahnbe { get;private set; } = new PersianDayOfWeek(3,"دو شنبه","ی");
        public static PersianDayOfWeek SeSahnbe { get;private set; } = new PersianDayOfWeek(4,"سه شنبه","ی");
        public static PersianDayOfWeek CheharSahnbe { get;private set; } = new PersianDayOfWeek(5,"چهار شنبه","ی");
        public static PersianDayOfWeek PanjSahnbe { get;private set; } = new PersianDayOfWeek(6,"پنج شنبه","ی");
        public static PersianDayOfWeek Jome { get;private set; } = new PersianDayOfWeek(7,"جمعه","ی");

        public static List<PersianDayOfWeek> DaysOfWeek = new List<PersianDayOfWeek>
        {
            Shanbe, YekSahnbe, DoSahnbe, SeSahnbe, CheharSahnbe, PanjSahnbe, Jome
        };

        public static PersianDayOfWeek GetDayOfWeek(DayOfWeek dayOfWeekEnum)
        {
            PersianDayOfWeek result = PersianDaysOfWeek.Shanbe;

            switch (dayOfWeekEnum)
            {
                case DayOfWeek.Sunday:
                    result = PersianDaysOfWeek.YekSahnbe;
                    break;
                case DayOfWeek.Monday:
                    result = PersianDaysOfWeek.DoSahnbe;
                    break;
                case DayOfWeek.Tuesday:
                    result = PersianDaysOfWeek.SeSahnbe;
                    break;
                case DayOfWeek.Wednesday:
                    result = PersianDaysOfWeek.CheharSahnbe;
                    break;
                case DayOfWeek.Thursday:
                    result = PersianDaysOfWeek.PanjSahnbe;
                    break;
                case DayOfWeek.Friday:
                    result = PersianDaysOfWeek.Jome;
                    break;
                case DayOfWeek.Saturday:
                    result = PersianDaysOfWeek.Shanbe;
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

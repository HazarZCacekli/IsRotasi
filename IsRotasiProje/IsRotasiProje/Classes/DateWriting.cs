namespace IsRotasiProje.Classes
{
    public class DateWriting
    {
        public static string DateWrite(DateTime? tarih)
        {

            return tarih.Value.Day.ToString() + "/" + tarih.Value.Month.ToString() + "/" + tarih.Value.Year.ToString() + "-" + tarih.Value.Hour.ToString() + ":" + tarih.Value.Minute.ToString();
        }

    }
}

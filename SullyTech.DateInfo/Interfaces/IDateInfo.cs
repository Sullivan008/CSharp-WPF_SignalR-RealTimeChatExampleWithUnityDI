namespace SullyTech.DateInfo.Interfaces
{
    public interface IDateInfo
    {
        public DateTimeOffset ConvertToDateTimeOffset(DateTime value, TimeZoneInfo? timeZoneInfo = null);

        public DateTimeOffset ConvertToDateTimeOffset(string value);

        public DateOnly ConvertToDateOnly(DateTime value);

        public DateOnly ConvertToDateOnly(DateTimeOffset value);

        public DateOnly ConvertToDateOnly(string value);
    }
}

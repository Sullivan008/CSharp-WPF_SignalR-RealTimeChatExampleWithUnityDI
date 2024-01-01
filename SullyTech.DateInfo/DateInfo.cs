using SullyTech.DateInfo.Interfaces;

namespace SullyTech.DateInfo;

public sealed class DateInfo : IDateInfo
{
    private static readonly TimeZoneInfo CentralEuropeanStandardTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

    public DateTimeOffset Now => DateTimeOffset.Now;

    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    public DateTimeOffset ConvertToDateTimeOffset(DateTime value, TimeZoneInfo? timeZoneInfo = null)
    {
        Guard.Guard.ThrowIfNull(value);

        if (timeZoneInfo is null)
        {
            return new DateTimeOffset(value, CentralEuropeanStandardTimeZoneInfo.GetUtcOffset(value));
        }

        return new DateTimeOffset(value, timeZoneInfo.GetUtcOffset(value));
    }

    public DateTimeOffset ConvertToDateTimeOffset(string value)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(value);

        return DateTimeOffset.Parse(value);
    }

    public DateOnly ConvertToDateOnly(DateTime value)
    {
        Guard.Guard.ThrowIfNull(value);

        return DateOnly.FromDateTime(value);
    }

    public DateOnly ConvertToDateOnly(DateTimeOffset value)
    {
        Guard.Guard.ThrowIfNull(value);

        return DateOnly.FromDateTime(value.DateTime);
    }

    public DateOnly ConvertToDateOnly(string value)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(value);

        return DateOnly.Parse(value);
    }
}
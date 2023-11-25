using SullyTech.DateInfo.Interfaces;

namespace SullyTech.DateInfo;

public sealed class DateInfo : IDateInfo
{
    private static readonly TimeZoneInfo CentralEuropeanStandardTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

    public DateTimeOffset Now => DateTimeOffset.Now;

    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    public DateTimeOffset ConvertToDateTimeOffset(DateTime value, TimeZoneInfo? timeZoneInfo = null)
    {
        Guard.Guard.ThrowIfNull(value, nameof(value));

        if (timeZoneInfo == null)
        {
            return new DateTimeOffset(value, CentralEuropeanStandardTimeZoneInfo.BaseUtcOffset);
        }

        return new DateTimeOffset(value, timeZoneInfo.BaseUtcOffset);
    }

    public DateTimeOffset ConvertToDateTimeOffset(DateOnly value, TimeZoneInfo? timeZoneInfo = null)
    {
        Guard.Guard.ThrowIfNull(value, nameof(value));

        if (timeZoneInfo == null)
        {
            return new DateTimeOffset(value.ToDateTime(TimeOnly.MinValue), CentralEuropeanStandardTimeZoneInfo.BaseUtcOffset);
        }

        return new DateTimeOffset(value.ToDateTime(TimeOnly.MinValue), timeZoneInfo.BaseUtcOffset);
    }

    public DateTimeOffset ConvertToDateTimeOffset(string value)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

        return DateTimeOffset.Parse(value);
    }

    public DateOnly ConvertToDateOnly(DateTime value)
    {
        Guard.Guard.ThrowIfNull(value, nameof(value));

        return DateOnly.FromDateTime(value);
    }

    public DateOnly ConvertToDateOnly(DateTimeOffset value)
    {
        Guard.Guard.ThrowIfNull(value, nameof(value));

        return DateOnly.FromDateTime(value.DateTime);
    }

    public DateOnly ConvertToDateOnly(string value)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

        return DateOnly.Parse(value);
    }
}
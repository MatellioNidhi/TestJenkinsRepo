using System;
using System.Globalization;


namespace Inseego.Utilities.Extensions
{
    /// <summary>
    /// This class contains various extension methods for time zone conversions of dates.
    /// The main methods to use would be:
    ///     .ToDatabaseTime(TimeZoneInfo userTimeZoneInfo) : DateTime
    ///     .ToUserTime(TimeZoneInfo userTimeZoneInfo) : DateTime
    ///     .ToUserTime(int mTime, TimeZoneInfo userTimeZoneInfo) : DateTime
    ///     .NowUser(TimeZoneInfo userTimeZoneInfo) : DateTime
    /// </summary>
    internal static class DateExtensions
    {
        private const string DateTimeFormat = "{0}-{1}-{2}T{3}:{4}:{5}Z";

        /// <summary> /// To the iso8601 date. /// </summary>
        ///The date.
        /// <returns></returns>
        public static string ToIso8601Date(this DateTime date)
        {
            return string.Format(
                DateTimeFormat,
                date.Year,
                PadLeft(date.Month),
                PadLeft(date.Day),
                PadLeft(date.Hour),
                PadLeft(date.Minute),
                PadLeft(date.Second));
        }

        /// <summary> /// Froms the iso8601 date. /// </summary>
        ///The date.
        /// <returns></returns>
        public static DateTime FromIso8601Date(this string date)
        {
            return DateTime.ParseExact(date.Replace("T", " "), "u", CultureInfo.InvariantCulture);
        }

        private static string PadLeft(int number)
        {
            if (number < 10)
            {
                return string.Format("0{0}", number);
            }

            return number.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets now for a specific time zone.
        /// </summary>
        /// <param name="timeZoneInfo">The time zone to convert now to.</param>
        public static DateTime Now(this DateTime date, TimeZoneInfo timeZoneInfo = null)
        {
            if (timeZoneInfo == null)
            {
                return DateTime.Now;
            }
            else
            {
                return TimeZoneInfo.ConvertTime(DateTime./*ignore*/Now, timeZoneInfo);
            }
        }

        /// <summary>
        /// Gets now for a specific user.
        /// </summary>
        /// <param name="timeZoneInfo">The user's time zone.</param>
        public static DateTime NowUser(this DateTime date, TimeZoneInfo userTimeZoneInfo)
        {
            if (userTimeZoneInfo == null)
            {
                throw new ArgumentException("The user's time zone info must be supplied.", "userTimeZoneInfo");
            }

            return date.Now(userTimeZoneInfo);
        }

        /// <summary>
        /// Converts a DateTime in a specific time zone to a Unix Epoch / MTime value
        /// i.e. when storing a date from user input to the database.
        /// Most dates are stored as these values in the database.
        /// </summary>
        /// <param name="timeZoneInfo">The time zone of the date which needs to be converted.</param>
        public static int ToMtime(this DateTime date, TimeZoneInfo timeZoneInfo = null)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcDate = date.ToUniversalTime(timeZoneInfo);
            TimeSpan unixTimeSpan = utcDate - unixEpoch;

            return (int)unixTimeSpan.TotalSeconds;
        }

        /// <summary>
        /// Converts a Unix Epoch / MTime value to a DateTime in the specified time zone.
        /// Example: Will convert 1388534400 to Wed, 01 Jan 2014 02:00:00 GMT+2 if the time zone info is South Africa Standard Time.
        /// </summary>
        /// <param name="mTime">The value to convert.</param>
        /// <param name="timeZoneInfo">The target time zone for the result.</param>
        public static DateTime FromMTime(this DateTime date, int mTime, TimeZoneInfo timeZoneInfo = null)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime calculatedDate = unixEpoch.AddSeconds(mTime);
            return calculatedDate.ToLocalTime(timeZoneInfo);
        }

        /// <summary>
        /// Convert a user's date to universal time a.k.a. UTC 
        /// i.e. when storing a date from user input to the database.
        /// All dates stored in the database should be UTC.
        /// Example: Wed, 01 Jan 2014 02:00:00 GMT+2 will be converted to Wed, 01 Jan 2014 00:00:00 GMT if the time zone info is South Africa Standard Time.
        /// <param name="localDateTime">The user's date i.e. the user's date input. This is the date according to the user's time zone.</param>
        /// <param name="timeZoneInfo">The user's time zone info.</param>
        /// </summary>
        public static DateTime ToDatabaseTime(this DateTime userDateTime, TimeZoneInfo userTimeZoneInfo)
        {
            if (userTimeZoneInfo == null)
            {
                throw new ArgumentException("The user's time zone info must be supplied.", "userTimeZoneInfo");
            }

            return userDateTime.ToUniversalTime(userTimeZoneInfo);
        }

        /// <summary>
        /// Convert a database date to a user's time zone specific date. This method assumes the database date is UTC.
        /// i.e. convert a UTC date, usually from the database, to
        /// a date in the user's specific time zone for display.
        /// Example: Wed, 01 Jan 2014 00:00:00 GMT will be converted to Wed, 01 Jan 2014 02:00:00 GMT+2 if the time zone info is South Africa Standard Time.
        /// <param name="timeZoneInfo">The time zone to convert the UTC date to i.e. the user's time zone.</param>
        /// </summary>
        public static DateTime ToUserTime(this DateTime dbDate, TimeZoneInfo userTimeZoneInfo)
        {
            if (userTimeZoneInfo == null)
            {
                throw new ArgumentException("The user's time zone info must be supplied.", "userTimeZoneInfo");
            }

            return dbDate.ToLocalTime(userTimeZoneInfo);
        }

        /// <summary>
        /// Converts a Unix Epoch / MTime value to the user's DateTime.
        /// Example: Will convert 1388534400 to Wed, 01 Jan 2014 02:00:00 GMT+2 if the time zone info is South Africa Standard Time.
        /// </summary>
        /// <param name="mTime">The value to convert.</param>
        /// <param name="userTimeZoneInfo">The target time zone for the result.</param>
        public static DateTime ToUserTime(this DateTime date, int mTime, TimeZoneInfo userTimeZoneInfo)
        {
            if (userTimeZoneInfo == null)
            {
                throw new ArgumentException("The user's time zone info must be supplied.", "userTimeZoneInfo");
            }

            return date.FromMTime(mTime, userTimeZoneInfo);
        }

        /// <summary>
        /// Convert a UTC date to a time zone specific date
        /// i.e. convert a UTC date, usually from the database, to
        /// a date in the user's specific time zone for display.
        /// Example: Wed, 01 Jan 2014 00:00:00 GMT will be converted to Wed, 01 Jan 2014 02:00:00 GMT+2 if the time zone info is South Africa Standard Time.
        /// <param name="timeZoneInfo">The time zone to convert the UTC date to i.e. the user's time zone.</param>
        /// </summary>
        public static DateTime ToLocalTime(this DateTime utcDate, TimeZoneInfo timeZoneInfo = null)
        {
            if (timeZoneInfo == null)
            {
                return utcDate.ToLocalTime();
            }
            else
            {
                utcDate = DateTime.SpecifyKind(utcDate, DateTimeKind.Utc);
                return TimeZoneInfo.ConvertTime(utcDate, TimeZoneInfo.Utc, timeZoneInfo);
            }
        }

        /// <summary>
        /// Convert a local date to universal time a.k.a. UTC 
        /// i.e. when storing a date from user input to the database.
        /// All dates stored in the database should be UTC.
        /// Example: Wed, 01 Jan 2014 02:00:00 GMT+2 will be converted to Wed, 01 Jan 2014 00:00:00 GMT if the time zone info is South Africa Standard Time.
        /// <param name="localDateTime">The local date i.e. the user's date input.  This is the date according to the user's time zone.</param>
        /// <param name="timeZoneInfo">The time zone info of the localDateTime parameter i.e. the user's time zone.</param>
        /// </summary>
        public static DateTime ToUniversalTime(this DateTime localDateTime, TimeZoneInfo timeZoneInfo = null)
        {
            if (timeZoneInfo == null)
            {
                return localDateTime.ToUniversalTime();
            }

            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTime(localDateTime, timeZoneInfo, TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Calculates an end of day DateTime from the current Date
        /// i.e. when obtaining data for a entire day as range from the database.
        /// <param name="date">The current date.</param>
        /// </summary>
        public static DateTime EndOfDay(this DateTime date)
        {
            return date.AddDays(1).AddMilliseconds(-1);
        }

        
    }

}

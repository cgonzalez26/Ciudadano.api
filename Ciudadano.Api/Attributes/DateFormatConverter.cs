using Newtonsoft.Json.Converters;

namespace Ciudadano.Api.Attributes
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}

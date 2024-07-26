using System.Globalization;

namespace Little_Conqueror.Helpers.Extensions;

public static class FloatExtension
{
    public static string ToURIString(this float val)
    {
        return val.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
    }
}
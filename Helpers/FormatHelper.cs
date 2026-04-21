namespace DistroHub.Web.Helpers;

public static class FormatHelper
{
    public static string FormatSize(decimal? sizeMb)
    {
        if (sizeMb == null || sizeMb <= 0)
            return "—";

        var gb = sizeMb.Value / 1024m;

        return $"{gb:F1} GB";
    }
}

using MudBlazor;

namespace Dom.App;

public static class Configuration
{
    public const string HttpClientName = "DomApp";

    public static string BackendUrl { get; set; } = "";

    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Comfortaa", "sans-serif"]
            }
        },
        PaletteLight = new PaletteLight
        {
            Primary = new MudBlazor.Utilities.MudColor("#118df0"),
            Secondary = Colors.Indigo.Darken3,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = new MudBlazor.Utilities.MudColor("#118df0"),
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.LightBlue.Lighten4

        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.LightBlue.Accent3,
            Secondary = Colors.LightBlue.Darken3,
            AppbarBackground = Colors.LightBlue.Accent3,
            AppbarText = Colors.Shades.Black
        }
    };
}

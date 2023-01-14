using System.Windows.Media;

namespace WPFMVVMTemplate.Themes
{
    public class DefThemes
    {
        private static ColorSchema? _dark;
        public static ColorSchema Dark
        {
            get
            {
                if (_dark == null)
                {
                    _dark = new ColorSchema()
                    {
                        SchemaName = "Dark",

                        WindowTitleBarColor = Color.FromRgb(18, 18, 18),
                        WindowBackgroundColor = Color.FromRgb(26, 26, 26),

                        PanelBackgroundColor = Color.FromRgb(31, 31, 31),
                        PanelBorderColor = Color.FromRgb(61, 61, 61),
                        PanelBorderHoverColor = Color.FromRgb(54, 54, 54),
                        PanelBorderPressedColor = Color.FromRgb(48, 48, 48),

                        ForegroundColor = Color.FromRgb(255, 255, 255),
                        ForegroundHoverColor = Color.FromRgb(217, 217, 217),
                        ForegroundPressedColor = Color.FromRgb(178, 178, 178),
                        ForegroundDisabledColor = Color.FromRgb(153, 153, 153),

                        ThemeColor = Color.FromRgb(240, 131, 0),
                        ThemeHoverColor = Color.FromRgb(219, 120, 0),
                        ThemePressedColor = Color.FromRgb(194, 107, 0),
                        ThemeDisabledColor = Color.FromRgb(163, 90, 0),
                        ThemeForegroundColor = Color.FromRgb(0, 0, 0),
                        ThemeForegroundDisabledColor = Color.FromRgb(13, 13, 13),

                        DeleteColor = Color.FromRgb(189, 32, 32),
                        DeleteHoverColor = Color.FromRgb(166, 28, 28),
                        DeletePressedColor = Color.FromRgb(138, 23, 23),
                        DeleteDisabledColor = Color.FromRgb(112, 19, 19),
                        DeleteForegroundColor = Color.FromRgb(0, 0, 0),
                        DeleteForegroundDisabledColor = Color.FromRgb(13, 13, 13)
                    };
                }

                return _dark;
            }
        }

        private static ColorSchema? _light;
        public static ColorSchema Light
        {
            get
            {
                if (_light == null)
                {
                    _light = new ColorSchema()
                    {
                        SchemaName = "Light",

                        WindowTitleBarColor = Color.FromRgb(235, 235, 235),
                        WindowBackgroundColor = Color.FromRgb(247, 247, 247),

                        PanelBackgroundColor = Color.FromRgb(230, 230, 230),
                        PanelBorderColor = Color.FromRgb(215, 215, 215),
                        PanelBorderHoverColor = Color.FromRgb(206, 206, 206),
                        PanelBorderPressedColor = Color.FromRgb(195, 195, 195),

                        ForegroundColor = Color.FromRgb(0, 0, 0),
                        ForegroundHoverColor = Color.FromRgb(48, 48, 48),
                        ForegroundPressedColor = Color.FromRgb(77, 77, 77),
                        ForegroundDisabledColor = Color.FromRgb(102, 102, 102),

                        ThemeColor = Color.FromRgb(80, 161, 242),
                        ThemeHoverColor = Color.FromRgb(76, 153, 230),
                        ThemePressedColor = Color.FromRgb(72, 144, 217),
                        ThemeDisabledColor = Color.FromRgb(59, 118, 178),
                        ThemeForegroundColor = Color.FromRgb(0, 0, 0),
                        ThemeForegroundDisabledColor = Color.FromRgb(13, 13, 13),

                        DeleteColor = Color.FromRgb(189, 32, 32),
                        DeleteHoverColor = Color.FromRgb(166, 28, 28),
                        DeletePressedColor = Color.FromRgb(138, 23, 23),
                        DeleteDisabledColor = Color.FromRgb(112, 19, 19),
                        DeleteForegroundColor = Color.FromRgb(0, 0, 0),
                        DeleteForegroundDisabledColor = Color.FromRgb(13, 13, 13)
                    };
                }

                return _light;
            }
        }
    }
}
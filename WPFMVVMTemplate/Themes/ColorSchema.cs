using System.Windows.Media;

namespace WPFMVVMTemplate.Themes
{
    public class ColorSchema
    {
        public string SchemaName { get; set; } = "SchemaName";

        public Color WindowTitleBarColor { get; set; }
        public Color WindowBackgroundColor { get; set; }

        public Color PanelBackgroundColor { get; set; }
        public Color PanelBorderColor { get; set; }
        public Color PanelBorderHoverColor { get; set; }
        public Color PanelBorderPressedColor { get; set; }

        public Color ForegroundColor { get; set; }
        public Color ForegroundHoverColor { get; set; }
        public Color ForegroundPressedColor { get; set; }
        public Color ForegroundDisabledColor { get; set; }

        public Color ThemeColor { get; set; }
        public Color ThemeHoverColor { get; set; }
        public Color ThemePressedColor { get; set; }
        public Color ThemeDisabledColor { get; set; }
        public Color ThemeForegroundColor { get; set; }
        public Color ThemeForegroundDisabledColor { get; set; }

        public Color DeleteColor { get; set; }
        public Color DeleteHoverColor { get; set; }
        public Color DeletePressedColor { get; set; }
        public Color DeleteDisabledColor { get; set; }
        public Color DeleteForegroundColor { get; set; }
        public Color DeleteForegroundDisabledColor { get; set; }
    }
}
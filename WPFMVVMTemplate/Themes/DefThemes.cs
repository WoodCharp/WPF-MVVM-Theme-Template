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
                if(_dark == null)
                {
                    _dark = new ColorSchema()
                    {
                        WindowTitleBarColor = Color.FromRgb(18, 18, 18),
                        WindowBackgroundColor = Color.FromRgb(26, 26, 26),

                        ForegroundColor = Color.FromRgb(255, 255, 255),
                        ForegroundHoverColor = Color.FromRgb(217, 217, 217),
                        ForegroundPressedColor = Color.FromRgb(178, 178, 178),
                        ForegroundDisabledColor = Color.FromRgb(153, 153, 153)
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
                        WindowTitleBarColor = Color.FromRgb(225, 225, 225),
                        WindowBackgroundColor = Color.FromRgb(247, 247, 247),

                        ForegroundColor = Color.FromRgb(0, 0, 0),
                        ForegroundHoverColor = Color.FromRgb(48, 48, 48),
                        ForegroundPressedColor = Color.FromRgb(77, 77, 77),
                        ForegroundDisabledColor = Color.FromRgb(102, 102, 102)
                    };
                }

                return _light;
            }
        }
    }
}
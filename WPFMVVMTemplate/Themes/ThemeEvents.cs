using System;

namespace WPFMVVMTemplate.Themes
{
    public class ThemeEventArgs : EventArgs
    {
        public ColorSchema ColorSchema { get; }

        public ThemeEventArgs(ColorSchema colorSchema)
        {
            ColorSchema = colorSchema;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFMVVMTemplate
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void MouseDragWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;

                var point = Mouse.GetPosition(null);

                Top = point.Y;
                Left = point.X - (Width / 2);

            }
            else if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Normal) DragMove();
        }
    }
}
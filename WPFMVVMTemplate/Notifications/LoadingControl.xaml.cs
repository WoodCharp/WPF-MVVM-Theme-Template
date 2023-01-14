using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WPFMVVMTemplate.Notifications
{
    public partial class LoadingControl : UserControl
    {
        private DoubleAnimation _showBgAnim;
        private DoubleAnimation _showImgAnim;
        private DoubleAnimation _hideBgAnim;

        private DoubleAnimation _ellOpacityShowAnim;
        private DoubleAnimation _ellOpacityHideAnim;

        private Geometry _geometry;
        private PathGeometry _pathGeometry;

        private MatrixTransform _ell1MT;
        private MatrixTransform _ell2MT;
        private MatrixTransform _ell3MT;
        private MatrixAnimationUsingPath _ell1MAUP;
        private MatrixAnimationUsingPath _ell2MAUP;
        private MatrixAnimationUsingPath _ell3MAUP;
        private Storyboard _ell1S;
        private Storyboard _ell2S;
        private Storyboard _ell3S;

        public LoadingControl()
        {
            InitializeComponent();

            _showBgAnim = new DoubleAnimation();
            _showBgAnim.AccelerationRatio = 0.9;
            _showBgAnim.DecelerationRatio = 0.1;
            _showBgAnim.Duration = TimeSpan.FromMilliseconds(250);
            _showBgAnim.RepeatBehavior = new RepeatBehavior(1.0);
            _showBgAnim.AutoReverse = false;
            _showBgAnim.To = 1;

            _hideBgAnim = new DoubleAnimation();
            _hideBgAnim.AccelerationRatio = 0.9;
            _hideBgAnim.DecelerationRatio = 0.1;
            _hideBgAnim.Duration = TimeSpan.FromMilliseconds(250);
            _hideBgAnim.RepeatBehavior = new RepeatBehavior(1.0);
            _hideBgAnim.AutoReverse = false;
            _hideBgAnim.To = 0;

            _showImgAnim = new DoubleAnimation();
            _showImgAnim.AccelerationRatio = 0.7;
            _showImgAnim.DecelerationRatio = 0.3;
            _showImgAnim.Duration = TimeSpan.FromMilliseconds(500);
            _showImgAnim.RepeatBehavior = new RepeatBehavior(1.0);
            _showImgAnim.AutoReverse = false;
            _showImgAnim.To = 0.15;
            _showImgAnim.BeginTime = TimeSpan.FromMilliseconds(250);

            _ellOpacityShowAnim = new DoubleAnimation();
            _ellOpacityShowAnim.BeginTime = TimeSpan.FromMilliseconds(700);
            _ellOpacityShowAnim.Duration = TimeSpan.FromMilliseconds(175);
            _ellOpacityShowAnim.RepeatBehavior = new RepeatBehavior(1.0);
            _ellOpacityShowAnim.AutoReverse = false;
            _ellOpacityShowAnim.To = 1;

            _ellOpacityHideAnim = new DoubleAnimation();
            _ellOpacityHideAnim.Duration = TimeSpan.FromMilliseconds(175);
            _ellOpacityHideAnim.RepeatBehavior = new RepeatBehavior(1.0);
            _ellOpacityHideAnim.AutoReverse = false;
            _ellOpacityHideAnim.To = 0;

            _geometry = Geometry.Parse("M-80,0a80,2.5 0 1,0 160,0a80,2.5 0 1,0 -160,0");
            _pathGeometry = new PathGeometry();
            _pathGeometry.AddGeometry(_geometry);
            _pathGeometry.Freeze();

            _ell1MT = new MatrixTransform();
            ell1.RenderTransform = _ell1MT;
            this.RegisterName("Ell1MT", _ell1MT);

            _ell2MT = new MatrixTransform();
            ell2.RenderTransform = _ell2MT;
            this.RegisterName("Ell2MT", _ell2MT);

            _ell3MT = new MatrixTransform();
            ell3.RenderTransform = _ell3MT;
            this.RegisterName("Ell3MT", _ell3MT);

            _ell1MAUP = new MatrixAnimationUsingPath();
            _ell1MAUP.PathGeometry = _pathGeometry;

            _ell1MAUP.IsOffsetCumulative = true;
            _ell1MAUP.Duration = TimeSpan.FromMilliseconds(1500);
            _ell1MAUP.RepeatBehavior = RepeatBehavior.Forever;
            _ell1MAUP.DecelerationRatio = 0.7;
            _ell1MAUP.AccelerationRatio = 0.3;

            _ell2MAUP = new MatrixAnimationUsingPath();
            _ell2MAUP.PathGeometry = _pathGeometry;

            _ell2MAUP.IsOffsetCumulative = true;
            _ell2MAUP.BeginTime = TimeSpan.FromMilliseconds(120);
            _ell2MAUP.Duration = TimeSpan.FromMilliseconds(1500);
            _ell2MAUP.RepeatBehavior = RepeatBehavior.Forever;
            _ell2MAUP.DecelerationRatio = 0.7;
            _ell2MAUP.AccelerationRatio = 0.3;

            _ell3MAUP = new MatrixAnimationUsingPath();
            _ell3MAUP.PathGeometry = _pathGeometry;

            _ell3MAUP.IsOffsetCumulative = true;
            _ell3MAUP.BeginTime = TimeSpan.FromMilliseconds(240);
            _ell3MAUP.Duration = TimeSpan.FromMilliseconds(1500);
            _ell3MAUP.RepeatBehavior = RepeatBehavior.Forever;
            _ell3MAUP.DecelerationRatio = 0.7;
            _ell3MAUP.AccelerationRatio = 0.3;

            Storyboard.SetTargetName(_ell1MAUP, "Ell1MT");
            Storyboard.SetTargetProperty(_ell1MAUP,
                new PropertyPath(MatrixTransform.MatrixProperty));

            Storyboard.SetTargetName(_ell2MAUP, "Ell2MT");
            Storyboard.SetTargetProperty(_ell2MAUP,
                new PropertyPath(MatrixTransform.MatrixProperty));

            Storyboard.SetTargetName(_ell3MAUP, "Ell3MT");
            Storyboard.SetTargetProperty(_ell3MAUP,
                new PropertyPath(MatrixTransform.MatrixProperty));

            _ell1S = new Storyboard();
            _ell1S.Children.Add(_ell1MAUP);

            _ell2S = new Storyboard();
            _ell2S.Children.Add(_ell2MAUP);

            _ell3S = new Storyboard();
            _ell3S.Children.Add(_ell3MAUP);
        }

        public async Task<bool> Show(bool showSpinner)
        {
            Visibility = Visibility.Visible;

            bg.BeginAnimation(OpacityProperty, _showBgAnim);
            img.BeginAnimation(OpacityProperty, _showImgAnim);

            if (showSpinner)
            {
                await Task.Delay(500);

                ell1.BeginAnimation(OpacityProperty, _ellOpacityShowAnim);
                ell2.BeginAnimation(OpacityProperty, _ellOpacityShowAnim);
                ell3.BeginAnimation(OpacityProperty, _ellOpacityShowAnim);
                _ell1S.Begin(this);
                _ell2S.Begin(this);
                _ell3S.Begin(this);
            }

            return true;
        }

        public async Task<bool> Hide()
        {
            ell1.BeginAnimation(OpacityProperty, _ellOpacityHideAnim);
            ell2.BeginAnimation(OpacityProperty, _ellOpacityHideAnim);
            ell3.BeginAnimation(OpacityProperty, _ellOpacityHideAnim);
            await Task.Delay(175);

            _ell1S.Stop();
            _ell2S.Stop();
            _ell3S.Stop();

            bg.BeginAnimation(OpacityProperty, _hideBgAnim);
            img.BeginAnimation(OpacityProperty, _hideBgAnim);
            await Task.Delay(250);
            Visibility = Visibility.Collapsed;
            return true;
        }
    }
}
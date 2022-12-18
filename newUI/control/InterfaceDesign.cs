using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Anim

{
    class InterfaceDesign : Window
    {
        private TimeSpan duration { get; set; } = TimeSpan.FromSeconds(0.660);
        private QuarticEase ease { get; set; } = new QuarticEase { EasingMode = EasingMode.EaseInOut };

        public InterfaceDesign(TimeSpan? timeSpan = null, QuarticEase easingFunction = null)
        {
            if (timeSpan != null)
            {
                duration = (TimeSpan)timeSpan;
            }

            if (easingFunction != null)
            {
                ease = easingFunction;
            }
        }

        public IEasingFunction CreateQuarticAnimation()
        {
            return new QuarticEase { EasingMode = EasingMode.EaseInOut };
        }

        public Task DoDoubleAnimation(DependencyObject Object, double From, double To, PropertyPath Property, IEasingFunction Animation, int Duration)
        {
            var sb = new Storyboard();
            var anim = new DoubleAnimation()
            {
                From = From,
                To = To,
                Duration = new Duration(TimeSpan.FromMilliseconds(Duration)),
                EasingFunction = Animation,
            };

            Storyboard.SetTarget(anim, Object);
            Storyboard.SetTargetProperty(anim, Property);
            sb.Children.Add(anim);
            sb.Begin();
            return Task.CompletedTask;
        }

        public void FadeIn(DependencyObject element)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(fadeAnimation, element);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(OpacityProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeAnimation);
            storyboard.Begin();
        }

        public void FadeOut(DependencyObject element)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(fadeAnimation, element);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(OpacityProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeAnimation);
            storyboard.Begin();
        }

        public void Shift(DependencyObject element, Thickness from, Thickness to)
        {
            ThicknessAnimation shiftAnimation = new ThicknessAnimation()
            {
                From = from,
                To = to,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(shiftAnimation, element);
            Storyboard.SetTargetProperty(shiftAnimation, new PropertyPath(MarginProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(shiftAnimation);
            storyboard.Begin();
        }

        public void ShiftWindow(Window window, double leftFrom, double topFrom, double leftTo, double topTo)
        {
            DoubleAnimation leftAnimation = new DoubleAnimation()
            {
                From = leftFrom,
                To = leftTo,
                Duration = duration,
                EasingFunction = ease
            };

            DoubleAnimation topAnimation = new DoubleAnimation()
            {
                From = topFrom,
                To = topTo,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(leftAnimation, window);
            Storyboard.SetTargetProperty(leftAnimation, new PropertyPath(LeftProperty));

            Storyboard.SetTarget(topAnimation, window);
            Storyboard.SetTargetProperty(topAnimation, new PropertyPath(TopProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(leftAnimation);
            storyboard.Children.Add(topAnimation);
            storyboard.FillBehavior = FillBehavior.Stop;
            storyboard.Begin();
        }

        public void Resize(DependencyObject element, double height, double width)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation()
            {
                From = (double)element.GetValue(ActualHeightProperty),
                To = height,
                Duration = duration,
                EasingFunction = ease
            };

            DoubleAnimation widthAnimation = new DoubleAnimation()
            {
                From = (double)element.GetValue(ActualWidthProperty),
                To = width,
                Duration = duration,
                EasingFunction = ease
            };


            Storyboard.SetTarget(heightAnimation, element);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(HeightProperty));

            Storyboard.SetTarget(widthAnimation, element);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(heightAnimation);
            storyboard.Children.Add(widthAnimation);
            storyboard.Begin();
        }
    }
}
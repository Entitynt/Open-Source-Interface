using Anim;
using ICSharpCode.AvalonEdit;
using newUI.control;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace newUI
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly InterfaceDesign design;
        private bool editoropened = true;
        private bool settingsopened = false;
        private bool scripthubopened = false;
        public MainWindow()
        {
            design = new InterfaceDesign();
            InitializeComponent();
            Main.Opacity = 0;

            effect1.Opacity = 0;
            effect11.Opacity = 0;
            effect22.Opacity = 0;
            effect2.Opacity = 0;
            effect33.Opacity = 0;
            effect3.Opacity = 0;
            tabeditor.Items.Add(maketab("Untitled" + ".lua"));
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseApplication_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }

        private void MinimizeApplication_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void MaxApplication_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                MaxApplication.Content = "\xE922";
            }
            else if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                MaxApplication.Content = "\xE923";
            }
        }

        private async void OnLoaded(object sender, RoutedEventArgs e) //anim & tab control 
        {
            await Task.Delay(1000);

            design.FadeIn(Main);

            design.FadeIn(effect1);
            design.FadeIn(effect11);
            design.Resize(effect11, 4, 14);
            editoropened = true;
        }

        public TabItem maketab(string tabcontrolheadername)
        {
            Color col = (Color)ColorConverter.ConvertFromString("Transparent");
            Color col2 = (Color)ColorConverter.ConvertFromString("#FF5F5C6C");
            TextEditor textEditors = new TextEditor();
            textEditors.FontFamily = new FontFamily("Segoe UI");
            textEditors.ShowLineNumbers = true;
            textEditors.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            textEditors.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            textEditors.Background = new SolidColorBrush(col);
            textEditors.Foreground = new SolidColorBrush(col2);
            textEditors.Margin = new Thickness(0, 2, 0, 0);
            TabItem tabitembaba = new TabItem()
            {
                Header = tabcontrolheadername,
                Content = textEditors,
                FontSize = 14,
                FontFamily = new FontFamily("Segoe UI"),
                Style = TryFindResource("TabItemStyle1") as Style,
            };
            tabitembaba.Loaded += delegate (object s, RoutedEventArgs e)
            {
                if (tabeditor.Items.Count > 1)
                {
                    tabitembaba.GetTemplateItem<Button>("RemoveTabButton").Click += delegate (object r, RoutedEventArgs f)
                    {
                        this.tabeditor.Items.Remove(tabitembaba);


                    };

                }
                else
                {
                    //returning
                }


            };

            tabitembaba.IsSelected = true;
            return tabitembaba;
        }

        private void tabopen_Click(object sender, RoutedEventArgs e)
        {
            tabeditor.Items.Add(maketab("Untitled" + ".lua"));
        }

        private void ExecuteEditor_click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearEditor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenEditor_click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveEditor_click(object sender, RoutedEventArgs e)
        {

        }

        private void Attach_click(object sender, RoutedEventArgs e)
        {

        }

        private void EditorOpen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (editoropened == false)
            {
                design.FadeIn(effect1);
                design.FadeIn(effect11);
                design.Resize(effect11, 4, 14);
                editoropened = true;
                if (scripthubopened == true)
                {
                    design.FadeOut(effect2);
                    design.FadeOut(effect22);
                    design.Resize(effect22, 4, 3);
                    scripthubopened = false;
                }
                if (settingsopened == true)
                {

                    design.FadeOut(effect3);
                    design.FadeOut(effect33);
                    design.Resize(effect33, 4, 3);
                    settingsopened = false;
                }
            }
        }

        private void exitpath1_Copy1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (scripthubopened == false)
            {
                design.FadeIn(effect2);
                design.FadeIn(effect22);
                design.Resize(effect22, 4, 14);
                scripthubopened = true;
                if (editoropened == true)
                {
                    design.FadeOut(effect1);
                    design.FadeOut(effect11);
                    design.Resize(effect11, 4, 3);
                    editoropened = false;
                }
                if (settingsopened == true)
                {

                    design.FadeOut(effect3);
                    design.FadeOut(effect33);
                    design.Resize(effect33, 4, 3);
                    settingsopened = false;
                }
            }
        }

        private void path3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (settingsopened == false)
            {
                design.FadeIn(effect3);
                design.FadeIn(effect33);
                design.Resize(effect33, 4, 14);
                settingsopened = true;
                if (editoropened == true)
                {
                    design.FadeOut(effect1);
                    design.FadeOut(effect11);
                    design.Resize(effect11, 4, 3);
                    editoropened = false;
                }
                if (scripthubopened == true)
                {

                    design.FadeOut(effect2);
                    design.FadeOut(effect22);
                    design.Resize(effect22, 4, 3);
                    scripthubopened = false;
                }
            }
        }

        private void path2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (settingsopened == false)
            {
                design.FadeIn(effect3);
                design.FadeIn(effect33);
                design.Resize(effect33, 4, 14);
                settingsopened = true;
                if (editoropened == true)
                {
                    design.FadeOut(effect1);
                    design.FadeOut(effect11);
                    design.Resize(effect11, 4, 3);
                    editoropened = false;
                }
                if (scripthubopened == true)
                {

                    design.FadeOut(effect2);
                    design.FadeOut(effect22);
                    design.Resize(effect22, 4, 3);
                    scripthubopened = false;
                }
            }
        }
    }
}

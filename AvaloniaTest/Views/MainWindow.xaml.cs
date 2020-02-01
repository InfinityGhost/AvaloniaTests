using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;

namespace AvaloniaTest.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var themes = this.Find<ComboBox>("Themes");
            themes.SelectionChanged += UpdateTheme;

            void UpdateTheme(object sender, SelectionChangedEventArgs e)
            {
                switch(themes.SelectedIndex)
                {
                    case 0:
                        App.Current.UpdateAccent(LightTheme);
                        break;
                    case 1:
                        App.Current.UpdateAccent(DarkTheme);
                        break;
                }
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private static readonly StyleInclude LightTheme = new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
        {
            Source = new Uri("resm:Avalonia.Themes.Default.Accents.BaseLight.xaml?assembly=Avalonia.Themes.Default")
        };

        private static readonly StyleInclude DarkTheme = new StyleInclude(new Uri("resm:Styles?assembly=ControlCatalog"))
        {
            Source = new Uri("resm:Avalonia.Themes.Default.Accents.BaseDark.xaml?assembly=Avalonia.Themes.Default")
        };
    }
}
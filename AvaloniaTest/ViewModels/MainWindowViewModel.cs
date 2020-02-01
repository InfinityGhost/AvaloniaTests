using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Styling;
using AvaloniaTest.Views;
using ReactiveUI;

namespace AvaloniaTest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Slider slider = new Slider
            {
                Name = "Test",
                Value = 5,
                Minimum = 0,
                Maximum = 10
            };
            TextBox textbox = new TextBox
            {
                Text = "some words"
            };
            Grid parent = new Grid
            {
                ColumnDefinitions = new ColumnDefinitions
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(125, GridUnitType.Pixel)
                },
                Children = 
                {
                    slider,
                    textbox
                }
            };
            for (int i = 0; i < parent.Children.Count; i++)
                Grid.SetColumn((Control)parent.Children[i], i);

            IControl[] controls = new IControl[]
            {
                parent
            };
            TestControls = new ObservableCollection<IControl>(controls);
        }

        private ObservableCollection<IControl> _testControls;
        public ObservableCollection<IControl> TestControls
        {
            set => this.RaiseAndSetIfChanged(ref _testControls, value);
            get => _testControls;
        }
    }
}

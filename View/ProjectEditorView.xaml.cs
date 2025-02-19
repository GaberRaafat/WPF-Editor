using System;
using System.Windows;
using System.Windows.Controls;
using Editor.ViewModel;

namespace Editor.View
{
    public partial class ProjectEditorView : UserControl
    {
        public MainViewModel EditorViewModel
        {
            get => (MainViewModel)GetValue(EditorViewModelProperty);
            set => SetValue(EditorViewModelProperty, value);
        }

        public static readonly DependencyProperty EditorViewModelProperty =
            DependencyProperty.Register(
                "EditorViewModel",
                typeof(MainViewModel),
                typeof(ProjectEditorView),
                new PropertyMetadata(null, OnEditorViewModelChanged));

        private static void OnEditorViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ProjectEditorView view && e.NewValue is MainViewModel viewModel)
            {
                if(viewModel != null) view.DataContext = viewModel; // Always update the DataContext
            }
        }

        public ProjectEditorView()
        {
            InitializeComponent();
        }
    }
}

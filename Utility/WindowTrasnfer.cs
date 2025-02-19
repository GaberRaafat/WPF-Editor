using Editor.View;
using Editor.ViewModel;
using System;
using System.Windows;

namespace Editor.Utility
{
    public class WindowTrasnfer
    {
        public static void Show(object viewModel)
        {
            Window window;
            if (viewModel is MainViewModel)
            {
                window = new MainWindow();
            }

            else if (viewModel is ProjectSummaryViewModel)
            {
                window = new ProjectSummaryView();
            }

           

            else if (viewModel is AddProjectViewModel)
            {
                window = new AddProjectView();
            }

            else if (viewModel is SignupviewModel)
            {
                window = new SignUpView();
            }

            else if (viewModel is LogInViewModel)
            {
                window = new LogInView();
            }

            else if (viewModel is AddCircleViewModel)
            {
                window = new AddCircleView();
            }
            else if (viewModel is AddLineViewModel)
            {
                window = new AddLineView();
            }
            else if (viewModel is AddRectangleViewModel)
            {
                window = new AddRectangleView();
            }

            else if (viewModel is AddPolygonViewModel)
            {
                window = new AddPolygonView();
            }

            else return;
            window.DataContext = viewModel;

            window.Show();
        }

        public static void ShowDialog(object viewModel)
        {
            Window window;
            if (viewModel is MainViewModel)
            {
                window = new MainWindow();
            }
            else if (viewModel is ProjectSummaryViewModel)
            {
                window = new ProjectSummaryView();
            }
            else if (viewModel is AddProjectViewModel)
            {
                window = new AddProjectView();
            }
            else if (viewModel is SignupviewModel)
            {
                window = new SignUpView();
            }
            else if (viewModel is LogInViewModel)
            {
                window = new LogInView();
            }
            else if (viewModel is AddCircleViewModel)
            {
                window = new AddCircleView();
            }
            else if (viewModel is AddLineViewModel)
            {
                window = new AddLineView();
            }
            else if (viewModel is AddRectangleViewModel)
            {
                window = new AddRectangleView();
            }

            else if (viewModel is AddPolygonViewModel)
            {
                window = new AddPolygonView();
            }

            else return;
            window.DataContext = viewModel;

            window.ShowDialog();
        }

      
    }
}

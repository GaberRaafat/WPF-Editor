using System;
using System.Windows;
using Editor.ViewModel;

namespace Editor.View
{
    public partial class AddPolygonView : Window
    {
        public AddPolygonView()
        {
            InitializeComponent();
            this.DataContext = new AddPolygonViewModel(); 
        }

       
    }
}
using Editor.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Editor.Utility
{
    public static class ShapesManager
    {
        public static List<Shape> LoadShapes()
        {
            var shapes = new List<Shape>();
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Open Shapes"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var json = File.ReadAllText(openFileDialog.FileName);
                shapes = JsonConvert.DeserializeObject<List<Shape>>(json, new ShapeConverter()) ?? new List<Shape>();
                return shapes;
            }

            return new List<Shape>();
        }



        public static void SaveShapes(List<Shape> shapes)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Export Devices Data",
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var json = JsonConvert.SerializeObject(shapes, Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Shapes Saved successfully.","Success");
            }
        }

    }
}

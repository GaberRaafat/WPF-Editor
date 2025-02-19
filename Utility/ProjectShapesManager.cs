using Editor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Editor.Utility
{
    public static class ProjectShapesManager
    {

        public static List<Shape> GetProjectShapes(Guid ProjectId)
        {
            var projectPath = GetProjectPath(ProjectId);

            if (File.Exists(projectPath))
            {
                var json = File.ReadAllText(projectPath);
                return JsonConvert.DeserializeObject<List<Shape>>(json, new ShapeConverter()) ?? new List<Shape>();
            }
            else
            {
                File.WriteAllText(projectPath, string.Empty);
                return new List<Shape>();
            }
        }

        public static void SaveProjectShapes(Guid ProjectId, List<Shape> projectShapes)
        {
            var json = JsonConvert.SerializeObject(projectShapes, Formatting.Indented);
            File.WriteAllText(GetProjectPath(ProjectId), json);
        }

        public static string GetProjectPath(Guid ProjectId)
        {

            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var allProjectFolder = Path.Combine(localAppData, "Editor");

            if (!Directory.Exists(allProjectFolder))
            {
                Directory.CreateDirectory(allProjectFolder);
            }
            return Path.Combine(allProjectFolder, ProjectId.ToString() + ".json");
        }
    }
}

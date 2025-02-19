using Editor.Model.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Editor.View
{
    public class ProjectTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProjectsSummaryTemplate { get; set; }
        public DataTemplate ProjectEditorTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Project project)
            {
                return project.Name == "Projects Summary" ? ProjectsSummaryTemplate : ProjectEditorTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}

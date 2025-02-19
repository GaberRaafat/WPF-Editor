using Editor.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace Editor.Utility
{
    public class ShapeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Shape);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var shapeType = DetermineShapeType(jsonObject);

            var shape = (Shape)Activator.CreateInstance(shapeType);
            serializer.Populate(jsonObject.CreateReader(), shape);

            return shape;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        private Type DetermineShapeType(JObject jsonObject)
        {
            if (jsonObject.ContainsKey("Radius1") && jsonObject.ContainsKey("Radius2"))
            {
                return typeof(Circle);
            }
            if (jsonObject.ContainsKey("X1") && jsonObject.ContainsKey("Y1"))
            {
                return typeof(Line);
            }
            if (jsonObject.ContainsKey("Width") && jsonObject.ContainsKey("Height"))
            {
                return typeof(Rectangle);
            }
            if (jsonObject.ContainsKey("Points"))
            {
                return typeof(Polygon);
            }

            throw new InvalidOperationException("Unknown shape type.");
        }
    }
}
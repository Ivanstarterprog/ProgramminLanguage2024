using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProgrammingLanguage2024.Libraries
{
    static public class ColorConfig
    {
        public static Color GetColor(string colorName)
        {
            string fileName = "colors.json";
            Dictionary<string, Dictionary<string, byte>> colors = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, byte>>>(colorName);
            if (colors.ContainsKey(colorName)){
                return Color.FromRgb(
                    colors[colorName]["R"],
                    colors[colorName]["G"],
                    colors[colorName]["B"]
                    );
            }
            return Color.FromRgb(
                colors["Red"]["R"],
                colors["Red"]["G"],
                colors["Red"]["B"]);
        }
    }
}

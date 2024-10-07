using System.Text;

namespace Assets.Project.Scripts.Utils
{
    public static class StringHelper
    {
        public static string GetColorString(ColorId id)
        {
            StringBuilder result = new StringBuilder();

            result.Append("#");

            switch (id) 
            {
                case ColorId.White: result.Append("FFFFFF"); break;
                case ColorId.Grey: result.Append("A0A09F"); break;

                default: result.Append("000000"); break;
            }

            return result.ToString();
        }
    }
}

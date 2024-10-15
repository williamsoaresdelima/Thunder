using System.ComponentModel;
using System.Reflection;

namespace TaskList.Data.Entities.Enum.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumValue)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Type T must be an enum!");

            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
        }
    }
}

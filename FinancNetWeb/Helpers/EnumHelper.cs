using System.ComponentModel;
using System.Reflection;

namespace FinancNetWeb.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }
            return value.ToString();
        }
    }
}

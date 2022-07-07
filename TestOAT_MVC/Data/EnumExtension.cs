using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TestOAT_MVC.Data
{
    public static class EnumExtension
    {
        //Enum extension
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                    .First().GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}

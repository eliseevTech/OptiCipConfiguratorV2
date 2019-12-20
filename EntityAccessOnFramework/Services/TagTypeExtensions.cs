using static EntityAccessOnFramework.Services.TagManager;

namespace EntityAccessOnFramework.Services
{
    public static class TagTypeExtensions
    {
        /// <summary>
        /// Переводим тип тега в строку
        /// </summary>
        public static string ToStrings(this TagType tagType)
        {
            if (tagType == TagType.analog)
            {
                return "ANA";
            }
            return "DIG";
        }

        /// <summary>
        /// Проверяем является ли тег сигналом digital
        /// </summary>
        public static bool IsDigital(string type)
        {
            if (type == "DIG")
            {
                return true;
            }
            return false;
        }
    }
}

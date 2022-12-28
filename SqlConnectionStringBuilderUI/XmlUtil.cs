using System.Text;

namespace SqlConnectionStringBuilderUI
{
    public static class XmlUtil
    {
        public static string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var sb = new StringBuilder(value);

            // replace literal values with entities
            sb.Replace("&", "&amp;");
            sb.Replace("'", "&apos;");
            sb.Replace("\"", "&quot;");
            sb.Replace(">", "&gt;");
            sb.Replace("<", "&lt;");

            return sb.ToString();
        }

        public static string Unescape(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var sb = new StringBuilder(value);

            // replace entities with literal values
            sb.Replace("&apos;", "'");
            sb.Replace("&quot;", "\"");
            sb.Replace("&gt;", ">");
            sb.Replace("&lt;", "<");
            sb.Replace("&amp;", "&");

            return sb.ToString();
        }
    }
}

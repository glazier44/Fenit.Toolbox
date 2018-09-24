namespace Fenit.Core.Web
{
    public class VersionInfoHelper
    {
        public static string GetVersion(int major, int minor, int release, int rev)
        {
            return $"{major}.{minor}.{release}.{rev:0000}";
        }
    }
}
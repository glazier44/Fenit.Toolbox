namespace Fenit.Core.Web
{
    public class VersionInfoHelper
    {
        public static string GetVersion(int major, int minor, int release, int rev)
        {
            return string.Format("{0}.{1}.{2}.{3:0000}", major, minor, release, rev);
        }
    }
}
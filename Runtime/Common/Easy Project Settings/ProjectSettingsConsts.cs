namespace Hertzole.ALE
{
    public static class ProjectSettingsConsts
    {
#if UNITY_EDITOR
        // Don't change this
        public const string ROOT_FOLDER = "ProjectSettings/Packages/" + PACKAGE_NAME;
#endif

        // Change this
        public const string PACKAGE_NAME = "se.hertzole.ale";
    }
}

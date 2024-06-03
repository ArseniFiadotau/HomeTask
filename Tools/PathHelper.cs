namespace Tools
{
    public static class PathHelper
    {
        public static DirectoryInfo GetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.EnumerateFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            if (directory == null)
                throw new DirectoryNotFoundException("Solution directory was not found");

            return directory;
        }

    }
}

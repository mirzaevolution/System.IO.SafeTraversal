namespace System.IO.SafeTraversal
{
    public class SafeTraversalDirectorySearchOptions
    {
        public SearchDirectoryByNameOption DirectoryNameOption { get; set; } = null;
        public SearchDirectoryByRegularExpressionOption RegularExpressionOption { get; set; } = null;
        public SearchDirectoryByDateOption DateOption { get; set; } = null;
        public FileAttributes DirectoryAttributes { get; set; } = 0;
    }
}

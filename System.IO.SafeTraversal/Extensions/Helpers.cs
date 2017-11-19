using System.Collections.Generic;

namespace System.IO.SafeTraversal
{
    /// <summary>
    /// Helpers class for System.IO.SafeTraversal
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Find all parents all the way up to the root (ie: C:\ or D:\) from current path.
        /// </summary>
        /// <param name="path">Valid path. If path is not found, DirectoryNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of DirectoryInfo representing all parents. Null if current path is a root.</returns>
        public static IEnumerable<DirectoryInfo> FindParents(this DirectoryInfo path)
        {

            if (!path.Exists)
                throw new DirectoryNotFoundException();
            while (path.Parent != null)
            {
                yield return new DirectoryInfo(path.Parent.Name);
                path = path.Parent;
            }
        }
        /// <summary>
        /// Find all parents all the way up to the root (ie: C:\ or D:\) from current path.
        /// </summary>
        /// <param name="file">Valid file location. If file is not found, FileNotFoundException will be thrown.</param>
        /// <returns>IEnumerable of DirectoryInfo representing all parents.</returns>
        public static IEnumerable<DirectoryInfo> FindParents(this FileInfo file)
        {

            if (!file.Exists)
                throw new FileNotFoundException();
            DirectoryInfo path = new DirectoryInfo(Path.GetDirectoryName(file.FullName));
            yield return new DirectoryInfo(path.Name);
            while (path.Parent != null)
            {
                yield return new DirectoryInfo(path.Parent.Name);
                path = path.Parent;
            }
        }
    }
}

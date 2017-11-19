using System.Collections.Generic;
using System.Linq;
namespace System.IO.SafeTraversal.Core
{
    public partial class SafeTraversal
    {
        #region Top Level Traversals
        private static IEnumerable<FileInfo> ExTopLevelFilesTraversal(DirectoryInfo path)
        {
            FileInfo[] files = null;
            try
            {
                files = path.GetFiles();
            }
            catch
            {
                files = null;

            }
            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    yield return files[i];
                }
            }
        }
        private static IEnumerable<FileInfo> ExTopLevelFilesTraversal(DirectoryInfo path, Func<FileInfo, bool> filter)
        {
            IEnumerable<FileInfo> files = null;
            try
            {
                files = path.GetFiles().Where(x =>
                {
                    //why? it prevents exception being thrown inside filter
                    bool success = true;
                    try
                    {
                        success = filter(x);
                    }
                    catch { success = false; }
                    return success;
                });
            }
            catch
            {
                files = null;

            }
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    yield return file;
                }
            }
        }
       

        private static IEnumerable<string> ExTopLevelFilesTraversal(string path)
        {
            string[] files = null;
            try
            {
                files = Directory.GetFiles(path);
            }
            catch
            {
                files = null;

            }
            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    yield return files[i];
                }
            }
        }
        private static IEnumerable<string> ExTopLevelFilesTraversal(string path, Func<FileInfo, bool> filter)
        {
            IEnumerable<string> files = null;
            try
            {
                files = new DirectoryInfo(path)
                    .GetFiles()
                    .Where(x =>
                    {
                        //why? it prevents exception being thrown inside filter
                        bool success = true;
                        try
                        {
                            success = filter(x);
                        }
                        catch { success = false; }
                        return success;
                    })
                    .Select(x => x.FullName);
            }
            catch
            {
                files = null;

            }
            if (files != null)
            {
                foreach (string file in files)
                {
                    yield return file;
                }
            }
        }
       

        private static IEnumerable<DirectoryInfo> ExTopLevelDirectoriesTraversal(DirectoryInfo path)
        {
            DirectoryInfo[] dirs = null;
            try
            {
                dirs = path.GetDirectories();
            }
            catch
            {
                dirs = null;

            }
            if (dirs != null)
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    yield return dirs[i];
                }
            }
        }
        private static IEnumerable<DirectoryInfo> ExTopLevelDirectoriesTraversal(DirectoryInfo path, Func<DirectoryInfo, bool> filter)
        {
            IEnumerable<DirectoryInfo> dirs = null;
            try
            {
                dirs = path
                    .GetDirectories()
                    .Where(x =>
                    {
                        //why? it prevents exception being thrown inside filter
                        bool success = true;
                        try
                        {
                            success = filter(x);
                        }
                        catch { success = false; }
                        return success;
                    });
            }
            catch
            {
                dirs = null;

            }
            if (dirs != null)
            {
                foreach (DirectoryInfo dir in dirs)
                {
                    yield return dir;
                }
            }
        }
        private static IEnumerable<string> ExTopLevelDirectoriesTraversal(string path)
        {
            string[] dirs = null;
            try
            {
                dirs = Directory.GetDirectories(path);
            }
            catch
            {
                dirs = null;

            }
            if (dirs != null)
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    yield return dirs[i];
                }
            }
        }
        private static IEnumerable<string> ExTopLevelDirectoriesTraversal(string path, Func<DirectoryInfo, bool> filter)
        {
            IEnumerable<string> dirs = null;
            try
            {
                dirs = new DirectoryInfo(path)
                    .GetDirectories(path)
                    .Where(x =>
                    {
                        //why? it prevents exception being thrown inside filter
                        bool success = true;
                        try
                        {
                            success = filter(x);
                        }
                        catch { success = false; }
                        return success;
                    })
                    .Select(x => x.FullName);
            }
            catch
            {
                dirs = null;

            }
            if (dirs != null)
            {
                foreach (string dir in dirs)
                {
                    yield return dir;
                }
            }
        }
        #endregion

        #region All Directories Level Traversals
        private static IEnumerable<FileInfo> ExTraverseFilesCore(DirectoryInfo path)
        {
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();
            directories.Enqueue(path);
            while (directories.Count > 0)
            {
                DirectoryInfo currentDir = directories.Dequeue();
                FileInfo[] files = null;
                try
                {
                    files = currentDir.GetFiles();
                }
                catch
                {
                    files = null;

                }

                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
                DirectoryInfo[] dirs = null;
                try
                {
                    dirs = currentDir.GetDirectories();
                }
                catch
                {
                    dirs = null;

                }
                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        directories.Enqueue(dirs[i]);
                    }
                }
            }
        }
        private static IEnumerable<FileInfo> ExTraverseFilesCore(DirectoryInfo path, Func<FileInfo, bool> filter)
        {
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();
            directories.Enqueue(path);
            while (directories.Count > 0)
            {
                DirectoryInfo currentDir = directories.Dequeue();
                IEnumerable<FileInfo> files = null;
                try
                {
                    files = currentDir
                        .GetFiles()
                        .Where(x =>
                        {
                            //why? it prevents exception being thrown inside filter
                            bool success = true;
                            try
                            {
                                success = filter(x);
                            }
                            catch { success = false; }
                            return success;
                        });
                }
                catch
                {
                    files = null;

                }
                if (files != null)
                {
                    foreach (FileInfo file in files)
                    {
                        yield return file;
                    }
                }
                DirectoryInfo[] dirs = null;
                try
                {
                    dirs = currentDir.GetDirectories();
                }
                catch
                {
                    dirs = null;

                }
                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        directories.Enqueue(dirs[i]);
                    }
                }
            }
        }
       
        private static IEnumerable<string> ExTraverseFilesCore(string path)
        {
            Queue<string> directories = new Queue<string>();
            directories.Enqueue(path);
            while (directories.Count > 0)
            {
                string currentDir = directories.Dequeue();
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch
                {
                    files = null;

                }

                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
                string[] dirs = null;
                try
                {
                    dirs = Directory.GetDirectories(currentDir);
                }
                catch
                {
                    dirs = null;

                }

                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        directories.Enqueue(dirs[i]);
                    }
                }
            }
        }
        private static IEnumerable<string> ExTraverseFilesCore(string path, Func<FileInfo, bool> filter)
        {
            Queue<string> directories = new Queue<string>();
            directories.Enqueue(path);
            while (directories.Count > 0)
            {
                string currentDir = directories.Dequeue();
                IEnumerable<string> files = null;
                try
                {
                    files = new DirectoryInfo(currentDir)
                        .GetFiles()
                        .Where(x =>
                        {
                            //why? it prevents exception being thrown inside filter
                            bool success = true;
                            try
                            {
                                success = filter(x);
                            }
                            catch { success = false; }
                            return success;
                        })
                        .Select(x => x.FullName);
                }
                catch
                {
                    files = null;

                }

                if (files != null)
                {
                    foreach (string file in files)
                    {
                        yield return file;
                    }
                }
                string[] dirs = null;
                try
                {
                    dirs = Directory.GetDirectories(currentDir);
                }
                catch
                {
                    dirs = null;

                }

                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        directories.Enqueue(dirs[i]);
                    }
                }
            }
        }
       
        private static IEnumerable<DirectoryInfo> ExTraverseDirectoriesCore(DirectoryInfo path)
        {
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();
            directories.Enqueue(path);
            while (directories.Count > 0)
            {
                DirectoryInfo currentDir = directories.Dequeue();
                DirectoryInfo[] dirs = null;
                try
                {
                    dirs = currentDir.GetDirectories();
                }
                catch
                {
                    dirs = null;

                }

                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        directories.Enqueue(dirs[i]);
                        yield return dirs[i];
                    }
                }
            }
        }
        private static IEnumerable<DirectoryInfo> ExTraverseDirectoriesCore(DirectoryInfo path, Func<DirectoryInfo, bool> filter)
        {
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();
            directories.Enqueue(path);
            while (directories.Count > 0)
            {
                DirectoryInfo currentDir = directories.Dequeue();
                DirectoryInfo[] dirs = null;
                try
                {
                    dirs = currentDir.GetDirectories();
                }
                catch
                {
                    dirs = null;
                }
                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        bool found = true;
                        try
                        {
                            found = filter(dirs[i]); //to prevent malicious injection
                        }
                        catch { found = false; }
                        if (found)
                            yield return dirs[i];

                        directories.Enqueue(dirs[i]);
                    }
                }
            }
        }
        private static IEnumerable<string> ExTraverseDirectoriesCore(string path)
        {
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();
            directories.Enqueue(new DirectoryInfo(path));
            while (directories.Count > 0)
            {
                DirectoryInfo currentDir = directories.Dequeue();
                DirectoryInfo[] dirs = null;
                try
                {
                    dirs = currentDir.GetDirectories();
                }
                catch
                {
                    dirs = null;

                }

                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        directories.Enqueue(dirs[i]);
                        yield return dirs[i].FullName;
                    }
                }
            }
        }
        private static IEnumerable<string> ExTraverseDirectoriesCore(string path, Func<DirectoryInfo, bool> filter)
        {
            Queue<DirectoryInfo> directories = new Queue<DirectoryInfo>();
            directories.Enqueue(new DirectoryInfo(path));
            while (directories.Count > 0)
            {
                DirectoryInfo currentDir = directories.Dequeue();
                DirectoryInfo[] dirs = null;
                try
                {
                    dirs = currentDir.GetDirectories();
                }
                catch
                {
                    dirs = null;
                }
                if (dirs != null)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        bool found = true;
                        try
                        {
                            found = filter(dirs[i]); //to prevent malicious injection
                        }
                        catch { found = false; }
                        if (found)
                            yield return dirs[i].FullName;

                        directories.Enqueue(dirs[i]);
                    }
                }
            }
        }

        #endregion
    }
}

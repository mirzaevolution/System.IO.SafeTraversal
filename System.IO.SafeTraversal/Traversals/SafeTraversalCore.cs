using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO.SafeTraversal
{
    public partial class SafeTraversal
    {
        #region FILE_SCANNING

        #region NO_LOGGING
        private void TraverseFilesCoreNoLogging( DirectoryInfo directoryInfo,
                                                 List<FileInfo> files, 
                                                 SearchOption searchOption,  
                                                 Func<FileInfo,bool> filter )
        {
            switch(searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    try
                    {
                        if (filter != null)
                        {
                            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                            {
                                try
                                {
                                    if (filter(fileInfo))
                                        files.Add(fileInfo);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                            {
                                files.Add(fileInfo);
                            }
                        }
                    }
                    catch { }
                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
                                {
                                    try
                                    {
                                        if (filter(fileInfo))
                                        {
                                            files.Add(fileInfo);
                                        }
                                    }
                                    catch { }
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
                                }
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            bool scanSubDir = false;
                            try
                            {
                                foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
                                {

                                    files.Add(fileInfo);
                                }
                                scanSubDir = true;
                            }
                            catch { scanSubDir = false; }

                            if (scanSubDir)
                            {
                                foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                                {
                                    queueDirectoryInfo.Enqueue(subDirInfo);
                                }
                            }
                        }
                    }
                    break;
            }


         
        }

        private void TraverseDirectoriesCoreNoLogging( DirectoryInfo directoryInfo,
                                                       List<DirectoryInfo> directories,
                                                       SearchOption searchOption,
                                                       Func<DirectoryInfo, bool> filter )
        {
            switch (searchOption)
            {
                case SearchOption.TopDirectoryOnly:
                    try
                    {
                        if (filter != null)
                        {
                            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                            {
                                try
                                {

                                    if (filter(dirInfo))
                                        directories.Add(dirInfo);
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                            {
                                directories.Add(dirInfo);
                            }
                        }
                    }
                    catch { }
                    break;
                case SearchOption.AllDirectories:
                    Queue<DirectoryInfo> queueDirectoryInfo = new Queue<DirectoryInfo>();
                    queueDirectoryInfo.Enqueue(directoryInfo);
                    if (filter != null)
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();

                            try
                            {
                                
                                if (filter(currentDirectoryInfo))
                                    directories.Add(currentDirectoryInfo);
                            }
                            catch { }

                            foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                            {
                                queueDirectoryInfo.Enqueue(subDirInfo);
                            }
                        }
                    }
                    else
                    {
                        while (queueDirectoryInfo.Count > 0)
                        {
                            DirectoryInfo currentDirectoryInfo = queueDirectoryInfo.Dequeue();
                            directories.Add(currentDirectoryInfo);

                            foreach (DirectoryInfo subDirInfo in currentDirectoryInfo.GetDirectories())
                            {
                                queueDirectoryInfo.Enqueue(subDirInfo);
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

        #region WITH_LOGGING
        #endregion

        #endregion
        #region DIR_SCANNING
        #endregion
    }
}

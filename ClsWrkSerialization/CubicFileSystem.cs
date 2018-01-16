using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace ClsWrkSerialization
{
   public class CubicFileSystem
   {
       private static FileStream _fileStream; // for read or write operations
       private static string _pathString = @"C:\CubicFile\Cubic1";
       private static readonly string FileName = "file.txt";

        // Life cycle no: 1
        public static void CreateFileDirectory()
       {
           try
           {
                Directory.CreateDirectory(_pathString);
              
                // Use Combine again to add the file name to the path.
                _pathString = Path.Combine(_pathString, FileName);

                // Verify the path that you have constructed.
                Console.WriteLine("Path to my file: {0}\n", _pathString);

                // Check that the file doesn't already exist. If it doesn't exist, create
                // the file and write integers 0 - 99 to it.
                if (!File.Exists(_pathString))
                {
                    using (_fileStream = File.Create(_pathString))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            _fileStream.WriteByte(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File \"{0}\" already exists.", FileName);
                }

                // Read and display the data from your file.
               
                    byte[] readBuffer = File.ReadAllBytes(_pathString);
                    foreach (byte b in readBuffer)
                    {
                        Console.Write(b + " ");
                    }
                    Console.WriteLine();
               
            }
           catch (Exception e)
           {
               Console.WriteLine(e);
           }
           
        }
       public static void DeleteFileDirectory()
       {
            // Delete a file by using File class static method...
           if (File.Exists(_pathString))
           {
               // Use a try block to catch IOExceptions, to
               // handle the case of the file already being
               // opened by another process.
               try
               {
                   File.Delete(_pathString);
                   Console.WriteLine("Check file path after deleting:" + _pathString);
               }
               catch (IOException e)
               {
                   Console.WriteLine(e.Message);
               }
           }
           // Delete a directory and all subdirectories with Directory static method...
           if (Directory.Exists(_pathString))
           {
               try
               {
                   Directory.Delete(_pathString, true);
                   Console.WriteLine("Check Directory path after deleting:" + _pathString);

                }

                catch (IOException e)
               {
                   Console.WriteLine(e.Message);
               }
           }

        }

      public static long GetDirectorySize()
       {
           // 1.
           // Get array of all file names.

           string path = @"C:\CubicFile\";
           string[] a = Directory.GetFiles(path, "*.*");

           // 2.
           // Calculate total bytes of all files in a loop.
           long b = 0;
           foreach (string name in a)
           {
               // 3.
               // Use FileInfo to get length of each file.
               FileInfo info = new FileInfo(name);
               b += info.Length;
           }
           // 4.
           // Return total size
           return b;
       }

    }
}

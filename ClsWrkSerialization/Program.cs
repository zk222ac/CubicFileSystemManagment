using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsWrkSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Step 1: 
            // Create File .............
            CubicFileSystem.CreateFileDirectory();

            // Step 2: 
            // Total count file Size Directory .............
            var length = CubicFileSystem.GetDirectorySize();
            Console.WriteLine("Length of file :" + length);

            // Step 3: 
            // Delete File .............
            CubicFileSystem.DeleteFileDirectory();
            
           


            Console.ReadKey();



        }
    }
}

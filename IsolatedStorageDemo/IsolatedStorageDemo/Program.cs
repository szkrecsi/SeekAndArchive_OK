using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStore);
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs");
            userWriter.Close();

            string[] files = userStore.GetFileNames("UserSettings.set");
            if (files.Length == 0)
            {
                Console.WriteLine("Hasn't found any file");
            } else { 
                userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStore);
                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine("{0}", contents);
            }
        }
    }
}

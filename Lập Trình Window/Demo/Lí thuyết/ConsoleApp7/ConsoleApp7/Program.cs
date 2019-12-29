using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp7.ReplaceAction;

namespace ConsoleApp7
{
    static class StringExtension
    {
        public static bool IsEmpty(this string line)
        {
            return line.Length == 0;
        }

        public static string DynamicSize(this long sizeInBytes)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            var currentIndex = 0;
            long remaining = 0;
            var number = sizeInBytes;

            while (number > 1024)
            {
                remaining = number % 1024;
                number /= 1024;
                currentIndex++;
            }

            if (remaining > 999)
            {
                remaining /= 10;
            }
            
            return $"{number}.{remaining} {units[currentIndex]}";
        }
    }

    delegate string StringProcessor (
        string origin, StringProcessorArgs args);
    class StringProcessorArgs { }

    interface Action
    {
        string Name { get; }
        StringProcessor Processor { get;}
        StringProcessorArgs Args { get; set; }
    }

    class ReplaceAction : Action
    {
        public string Name => "The seeker";

        public StringProcessor Processor => replace;
        public StringProcessorArgs Args { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        static string replace(
            string origin, StringProcessorArgs args)
        {
            var myArgs = args as ReplaceStringProcessorArgs;
            var needle = myArgs.Needle;
            var hammer = myArgs.Hammer;

            return origin.Replace(needle, hammer);
        }

        public class ReplaceStringProcessorArgs: 
            StringProcessorArgs
        {
            public string Needle { get; set; }
            public string Hammer { get; set; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string headers = String.Format("{0, 10} {1, 10} {2, 10} {3, 10}",
                "City", "Year", "Population", "Change");
            Console.WriteLine(headers);

            string haystack = "The quick brown fox jumps over the lazy dog";
            string needle = "brown";

            if (haystack.Contains(needle))
            {
                Console.WriteLine("Found");
            }

            int position = haystack.IndexOf(needle);
            int reversePos = haystack.LastIndexOf(needle);

            //bool isEmpty = StringExtension.IsEmpty(haystack);
            bool isEmpty = haystack.IsEmpty();
            string number = "149";
            //try
            //{

            //    int value = int.Parse(number);

            //    Console.Write(value + 14);
            //} catch (Exception ex)
            //{
            //    Console.WriteLine(
            //        "There is an error occur when trying to convert string {0} into number: {1}", number, ex.Message);
            //}
            int value = 0;
            bool result = int.TryParse(number, out value);

            if (result == true)
            {
                Console.Write(value + 14);
            } else
            {
                Console.WriteLine(
                    "Cannot perform operation. Please check input.");
            }

            string alteredString = haystack.Remove(3, 10);
            Console.WriteLine(alteredString);

            string replaced = haystack.Replace("w", "m");
            Console.WriteLine(replaced);

            string file1 = "unsplash - Anatoly - 1920x1080.jpg";
            string file2 = "unsplash - Nguyen Viet Hung - 1920x1080.jpg";
            string file3 = "unsplash - Thang Soi - 1920x1080.jpg";

            var dewatermark = new ReplaceAction();
            var dewatermarkArgs = new ReplaceStringProcessorArgs()
            {
                Needle = "unsplash",
                Hammer = "vuatrom"
            };

            var final = dewatermark.Processor(file1, dewatermarkArgs);

            var changeRes = new ReplaceAction();
            var changeResArgs = new ReplaceStringProcessorArgs()
            {
                Needle = "1920x1080",
                Hammer = "1366x768"
            };

            final = changeRes.Processor(final, changeResArgs);

            Console.WriteLine(final);

            //// File system
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives) {
                Console.WriteLine(drive.Name);
                Console.WriteLine(drive.VolumeLabel);
                Console.WriteLine(drive.TotalSize.DynamicSize());

                var directory = new DirectoryInfo(drive.Name);
                var childFolders = directory.EnumerateDirectories();

                foreach(var folder in childFolders)
                {
                    Console.WriteLine(folder.Name);
                }

                var childFiles = directory.EnumerateFiles();

                foreach(var file in childFiles)
                {
                    Console.WriteLine(file.Name);
                }
            }

            
        }
    }
}

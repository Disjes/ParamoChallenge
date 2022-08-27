using System;
using System.IO;

namespace Sat.Recruitment.Api.Utils
{
    public static class IOManager
    {
        private static readonly string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
        public static StreamReader CreateStreamReader()
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
        
        public static StreamWriter CreateStreamWriter()
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamWriter writer = new StreamWriter(fileStream);
            return writer;
        }
    }
}

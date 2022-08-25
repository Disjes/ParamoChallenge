using System;
using System.IO;

namespace Sat.Recruitment.Api.Utils
{
    public static class IOManager
    {
        public static StreamReader CreateStreamReader()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
        
        public static StreamWriter CreateStreamWriter()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamWriter writer = new StreamWriter(fileStream);
            return writer;
        }
    }
}

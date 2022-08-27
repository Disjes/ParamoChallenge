using System;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Utils
{
    public static class IOHelpers
    {
        private static readonly string path = $"{Directory.GetCurrentDirectory()}/Files/Users.txt";

        //Helper method to leave file as initial state
        public static async Task EmptyFile()
        {
            await using var writer = File.AppendText(path);
            writer.AutoFlush = true;
            await writer.WriteLineAsync("Franco,Franco.Perez@gmail.com,+534645213542,Alvear y Colombres,Premium,112234");
            await writer.WriteLineAsync($"{Environment.NewLine}Agustina,Agustina@gmail.com,+534645213542,Garay y Otra Calle,SuperUser,112234");
        }
    }
}

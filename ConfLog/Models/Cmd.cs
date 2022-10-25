using System.Diagnostics;
namespace ConfLog.Models
{
    public class Cmd
    {
        static string path = string.Join("\\", System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\').Take(System.Reflection.Assembly.GetExecutingAssembly().Location.Split('\\').Length - 4)) + "\\wwwroot\\download\\";
        public Cmd() { }
        public static void CdLibrary()
        {
            ProcessStartInfo psi;

            psi = new ProcessStartInfo("cmd", $@"/k dotnet build ");
            Console.WriteLine(path);
            psi.WorkingDirectory = $@"{path}\\Logging\\";
            Process.Start(psi);


        }


    }
}

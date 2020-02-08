using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Win32;

namespace ssv
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\meoiswa\ssv"))
                {
                    var input = (string)key.GetValue("Input", "CABLE Output");
                    var outputA = (string)key.GetValue("OutputA", "HP 32 Display");
                    var outputB = (string)key.GetValue("OutputB", "Headphones");
                    var ssvPath = (string)key.GetValue("SoundVolumeViewPath", "SoundVolumeView.exe");

                    var toggle = Boolean.Parse((string)key.GetValue("Toggle", false));

                    using (Process myProcess = new Process())
                    {
                        myProcess.StartInfo.UseShellExecute = false;

                        myProcess.StartInfo.FileName = ssvPath;
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.StartInfo.Arguments = $"/RunAsAdmin /SetPlaybackThroughDevice \"{input}\" \"{(toggle ? outputA : outputB)}\"";
                        myProcess.Start();
                    }

                    key.SetValue("Toggle", !toggle);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

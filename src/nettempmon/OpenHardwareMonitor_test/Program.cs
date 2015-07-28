using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;

using System.Timers;

namespace OpenHardwareMonitor_test
{
    class Program
    {
        static Computer cp;
        static Timer mainTImer;
        
        static void Main(string[] args)
        {
            cp = new Computer();
            cp.Open();
            cp.CPUEnabled = true;

            mainTImer = new Timer(1000);
            mainTImer.Elapsed += new ElapsedEventHandler(ShowCPUInfo);
            mainTImer.Enabled = true;
                    
            
            Console.ReadLine();
        }

        public static void ShowCPUInfo(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            
            foreach (var item in cp.Hardware)
            {
                if (item.HardwareType == HardwareType.CPU)
                {
                    Console.WriteLine("Processor : {0}", item.Name);
                    item.Update();
                    foreach (var sensor in item.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)  Console.WriteLine("CPU temperature is {0}", sensor.Value);      
                      
                    }
                }

            }
        }


    }
}

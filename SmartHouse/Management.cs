using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class Management
    {
        public void Start()
        {
            List<string> availableCommands = new List<string>();
            IDictionary<string, Device> devices = new Dictionary<string, Device>();
            while (true)
            {
                Console.Clear();
                if (devices.Count == 0)
                {
                    Console.WriteLine("You have no devices yet");
                }
                else
                {
                    foreach (var device in devices)
                    {
                        Console.WriteLine("Name: " + device.Key + "\n" + device.Value);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Enter the command: ");
                string[] commands = Console.ReadLine().ToLower().Split(' ');
                if (commands[0] == "exit")
                {
                    return;
                }
                if (commands.Length != 3)
                {
                    Help();
                }
                
                switch (commands[0])
                {
                    case "add":
                        if (!devices.ContainsKey(commands[2]))
                        {
                            if (commands[1] == "fridge")
                            {
                                Fridge f = new Fridge();
                                devices.Add(commands[2], f);
                                continue;
                            }
                            else if (commands[1] == "garage")
                            {
                                Garage g = new Garage();
                                devices.Add(commands[2], g);
                                continue;
                            }
                            else if (commands[1] == "camera")
                            {
                                Camera c = new Camera();
                                devices.Add(commands[2], c);
                                continue;
                            }
                            else if (commands[1] == "airconditioner")
                            {
                                AirConditioner a = new AirConditioner();
                                devices.Add(commands[2], a);
                                continue;
                            }
                            else if (commands[1] == "tv")
                            {
                                TV t = new TV();
                                devices.Add(commands[2], t);
                                continue;
                            }
                            else
                            {
                                Help();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Device with name \'{0}\' already exists. " +
                                              "Press <Enter> to continue", commands[1]);
                            Console.ReadLine();
                            continue;
                        }
                        break;
                    case "del":
                        if (devices.Count != 0)
                        {
                            devices.Remove(commands[2]);
                        }
                        else
                        {
                            Console.WriteLine("You have nothing to delete");
                            continue;
                        }
                        break;
                }
            }
        }

        private void Help()
        {
            
        }

    }
}

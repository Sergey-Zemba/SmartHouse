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
        IDictionary<string, Device> devices = new Dictionary<string, Device>();
        public void Start()
        {
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
                if (commands.Length != 3 && commands.Length != 2)
                {
                    Help();
                }
                
                switch (commands[0])
                {
                    case "add":
                        if (commands.Length != 3)
                        {
                            Help();
                        }
                        if (!devices.ContainsKey(commands[2]))
                        {
                            if (commands[1] == "fridge")
                            {
                                Fridge f = new Fridge();
                                devices.Add(commands[2], f);
                                Start();
                            }
                            else if (commands[1] == "garage")
                            {
                                Garage g = new Garage();
                                devices.Add(commands[2], g);
                                Start();
                            }
                            else if (commands[1] == "camera")
                            {
                                Camera c = new Camera();
                                devices.Add(commands[2], c);
                                Start();
                            }
                            else if (commands[1] == "airconditioner")
                            {
                                AirConditioner a = new AirConditioner();
                                devices.Add(commands[2], a);
                                Start();
                            }
                            else if (commands[1] == "tv")
                            {
                                TV t = new TV();
                                devices.Add(commands[2], t);
                                Start();
                            }
                            else
                            {
                                Console.WriteLine(commands[1] + " is not a device. " +
                                                  "Press <Enter> to continue");
                                Console.ReadLine();

                                Help();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Device with name \'{0}\' already exists. " +
                                              "Press <Enter> to continue", commands[2]);
                            Console.ReadLine();
                            Start();
                        }
                        break;
                    case "del":
                        if (commands.Length != 2)
                        {
                            Help();
                        }
                        if (isValid(commands[1]))
                        {
                            if (devices.Count != 0)
                            {
                                devices.Remove(commands[1]);
                            }
                            else
                            {
                                Console.WriteLine("You have nothing to delete");
                                Start();
                            }
                        }
                        break;
                    case "on":
                        if (commands.Length != 2)
                        {
                            Help();
                        }
                        if (isValid(commands[1]))
                        {
                            devices[commands[1]].On();
                        }
                        break;
                    case "off":
                        if (commands.Length != 2)
                        {
                            Help();
                        }
                        if (isValid(commands[1]))
                        {
                            devices[commands[1]].On();
                        }
                        break;
                    case "open":
                        if (commands.Length != 2)
                        {
                            Help();
                        }
                        if (isValid(commands[1]))
                        {
                            if (devices[commands[1]] is IOpenable)
                            {
                                (devices[commands[1]] as IOpenable).Open();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'open\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[2]].GetType().Name, commands[2]);
                                Console.ReadLine();
                                Start();
                            }
                        }
                        break;
                    case "close":
                        if (commands.Length != 2)
                        {
                            Help();
                        }
                        if (isValid(commands[1]))
                        {
                            if (devices[commands[1]] is IOpenable)
                            {
                                (devices[commands[1]] as IOpenable).Close();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'close\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[2]].GetType().Name, commands[2]);
                                Console.ReadLine();
                                Start();
                            }
                        }
                        break;
                }
            }
        }

        private bool isValid(string key)
        {
            if (!devices.ContainsKey(key) || devices.Count == 0)
            {
                Console.WriteLine("You don't have device with name \'{0}\'. " +
                                   "Press <Enter> to continue", key);
                Console.ReadLine();
                Start();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Help()
        {
            Console.WriteLine("Available commands");
            Console.WriteLine("\tadd device name");
            Console.WriteLine("\tdel name");
            Console.WriteLine("\ton name");
            Console.WriteLine("\toff name");
            Console.WriteLine("\topen name");
            Console.WriteLine("\tclose name");
            Console.WriteLine("\texit");
            Console.WriteLine("Press <Enter> to continue");
            Console.ReadLine();
            Start();
        }

    }
}

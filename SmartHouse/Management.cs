using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Devices;
using SmartHouse.Interfaces;

namespace SmartHouse
{
    internal class Management
    {
        private DeviceFactory factory;
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
                Console.WriteLine("Type in the command or press <Enter> for help: ");
                string[] commands = Console.ReadLine().ToLower().Split(' ');

                if (commands.Length != 3 && commands.Length != 2 & commands.Length != 1)
                {
                    Help();
                    continue;
                }

                switch (commands[0])
                {
                    case "add":
                        if (commands.Length != 3)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1].Contains("samsung"))
                        {
                            factory = new SamsungFactory();
                        }
                        if (commands[1].Contains("panasonic"))
                        {
                            factory = new PanasonicFactory();
                        }
                        if (!devices.ContainsKey(commands[2]))
                        {
                            if (commands[1] == "fridge")
                            {
                                Fridge f = new Fridge();
                                devices.Add(commands[2], f);

                            }
                            else if (commands[1] == "garage")
                            {
                                Garage g = new Garage();
                                devices.Add(commands[2], g);

                            }
                            else if (commands[1] == "camera")
                            {
                                Camera c = new Camera();
                                devices.Add(commands[2], c);

                            }
                            else if (commands[1] == "airconditioner")
                            {
                                AirConditioner a = new AirConditioner();
                                devices.Add(commands[2], a);

                            }
                            else if (commands[1] == "tv")
                            {
                                TV t = new TV();
                                devices.Add(commands[2], t);

                            }
                            else if (commands[1] == "samsungstereo")
                            {

                                SamsungStereoSystem s = (SamsungStereoSystem)factory.MakeStereoSystem();
                                devices.Add(commands[2], s);

                            }
                            else if (commands[1] == "panasonicstereo")
                            {
                                PanasonicStereoSystem p = (PanasonicStereoSystem)factory.MakeStereoSystem();
                                devices.Add(commands[2], p);

                            }
                            else if (commands[1] == "samsungspeakers")
                            {
                                SamsungLoudspeakers sl = (SamsungLoudspeakers)factory.MakeLoudspeakers();
                                devices.Add(commands[2], sl);

                            }
                            else if (commands[1] == "panasonicspeakers")
                            {
                                PanasonicLoudspeakers pl = (PanasonicLoudspeakers)factory.MakeLoudspeakers();
                                devices.Add(commands[2], pl);

                            }
                            else
                            {
                                Console.WriteLine(commands[1] + " is not a device. " +
                                                  "Press <Enter> to continue");
                                Console.ReadLine();

                                Help();
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Device with name \'{0}\' already exists. " +
                                              "Press <Enter> to continue", commands[2]);
                            Console.ReadLine();

                        }
                        break;
                    case "del":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            devices.Clear();
                            Console.WriteLine("All devices was removed");
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            devices.Remove(commands[1]);
                        }
                        break;
                    case "on":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                device.Value.On();
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            devices[commands[1]].On();
                        }
                        break;
                    case "off":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                device.Value.Off();
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            devices[commands[1]].On();
                        }
                        break;
                    case "open":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is IOpenable)
                                {
                                    (device.Value as IOpenable).Open();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is IOpenable)
                            {
                                (devices[commands[1]] as IOpenable).Open();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'open\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "close":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is IOpenable)
                                {
                                    (device.Value as IOpenable).Close();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is IOpenable)
                            {
                                (devices[commands[1]] as IOpenable).Close();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'close\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "addvolume":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is IVolumeable)
                                {
                                    (device.Value as IVolumeable).AddVolume();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is IVolumeable)
                            {
                                (devices[commands[1]] as IVolumeable).AddVolume();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'addvolume\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "decvolume":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is IVolumeable)
                                {
                                    (device.Value as IVolumeable).DecreaseVolume();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is IVolumeable)
                            {
                                (devices[commands[1]] as IVolumeable).DecreaseVolume();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'decvolume\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "mute":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is IVolumeable)
                                {
                                    (device.Value as IVolumeable).Mute();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is IVolumeable)
                            {
                                (devices[commands[1]] as IVolumeable).Mute();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'mute\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "startrec":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is IRecording)
                                {
                                    (device.Value as IRecording).StartRecording();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is IRecording)
                            {
                                (devices[commands[1]] as IRecording).StartRecording();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'startrec\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "stoprec":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is IRecording)
                                {
                                    (device.Value as IRecording).StopRecording();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is IRecording)
                            {
                                (devices[commands[1]] as IRecording).StopRecording();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'stoprec\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "addtemp":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is ITemperature)
                                {
                                    (device.Value as ITemperature).AddTemperture();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is ITemperature)
                            {
                                (devices[commands[1]] as ITemperature).AddTemperture();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'addtemp\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "dectemp":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (commands[1] == "all")
                        {
                            foreach (var device in devices)
                            {
                                if (device.Value is ITemperature)
                                {
                                    (device.Value as ITemperature).DecreaseTemperature();
                                }
                            }
                        }
                        if (isValid(commands[1]) && commands[1] != "all")
                        {
                            if (devices[commands[1]] is ITemperature)
                            {
                                (devices[commands[1]] as ITemperature).DecreaseTemperature();
                            }
                            else
                            {
                                Console.WriteLine("You can't apply command \'dectemp\' to {0} {1}. " +
                                                  "Press <Enter> to continue", devices[commands[1]].GetType().Name, commands[1]);
                                Console.ReadLine();

                            }
                        }
                        break;
                    case "exit":
                        if (commands.Length != 1)
                        {
                            Help();
                        }
                        return;
                    default:
                        Help();
                        continue;
                        break;
                }
            }
        }

        private bool isValid(string key)
        {
            if (devices.Count == 0)
            {
                Console.WriteLine("You don't have any device. " +
                                   "Press <Enter> to continue");
                Console.ReadLine();

                return false;
            }
            else if (!devices.ContainsKey(key) && key != "all")
            {
                Console.WriteLine("You don't have device with name \'{0}\'. " +
                                   "Press <Enter> to continue", key);
                Console.ReadLine();

                return false;
            }

            else
            {
                return true;
            }
        }

        private void Help()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("\tadd device name");
            Console.WriteLine("\tdel name");
            Console.WriteLine("\ton name");
            Console.WriteLine("\toff name");
            Console.WriteLine("\topen name");
            Console.WriteLine("\tclose name");
            Console.WriteLine("\taddvolume name");
            Console.WriteLine("\tdecvolume name");
            Console.WriteLine("\tmute name");
            Console.WriteLine("\tstartrec name");
            Console.WriteLine("\tstoprec name");
            Console.WriteLine("\tdel all");
            Console.WriteLine("\ton all");
            Console.WriteLine("\toff all");
            Console.WriteLine("\topen all");
            Console.WriteLine("\tclose all");
            Console.WriteLine("\taddvolume all");
            Console.WriteLine("\tdecvolume all");
            Console.WriteLine("\tmute all");
            Console.WriteLine("\tstartrec all");
            Console.WriteLine("\tstoprec all");
            Console.WriteLine("\texit");
            Console.WriteLine();
            Console.WriteLine("Availavle devices:");
            Console.WriteLine("\tairconditioner");
            Console.WriteLine("\tcamera");
            Console.WriteLine("\tfridge");
            Console.WriteLine("\tgarage");
            Console.WriteLine("\ttv");
            Console.WriteLine("\tsamsungstereo");
            Console.WriteLine("\tpanasonicstereo");
            Console.WriteLine("\tsamsungspeakers");
            Console.WriteLine("\tpanasonicspeakers");
            Console.WriteLine("Press <Enter> to continue");
            Console.ReadLine();

        }


    }
}

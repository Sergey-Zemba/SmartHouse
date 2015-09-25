using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class Management
    {
        private List<Device> deviceList = new List<Device>();

        public void Start()
        {
            Console.Clear();
            ShowItems();
            Console.WriteLine();
            Console.WriteLine("Input action to do:\n1 - Add device\n2 - Remove device\n3 - Manage the device\ne - Exit");
            string str = Console.ReadLine();
            switch (str)
            {

                case "1":
                    AddDevice();
                    break;
                case "2":
                    RemoveDevice();
                    break;
                case "3":
                    ManageDevice();
                    break;
                case "e":
                    break;
                default:
                    Start();
                    break;
            }
        }

        private void ShowItems()
        {
            Console.Clear();
            if (deviceList.Count == 0)
            {
                Console.WriteLine("You haven't any devices");
            }
            else
            {
                for (int i = 0; i < deviceList.Count; i++)
                {
                    Console.WriteLine((i + 1) + " " + deviceList[i]);
                }
            }

        }

        private void AddDevice()
        {
            Console.Clear();
            Console.WriteLine("Please choose type of device you want to add:\n1 - Fridge\n2 - TV\n3 - Garage\n" +
                              "4 - AirConditioner\n5 - Camera\nr - return");
            string str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    deviceList.Add(new Fridge());
                    Console.WriteLine("New fridge was succesfully added");
                    System.Threading.Thread.Sleep(1000);
                    AddDevice();
                    break;
                case "2":
                    deviceList.Add(new TV());
                    Console.WriteLine("New TV was succesfully added");
                    System.Threading.Thread.Sleep(1000);
                    AddDevice();
                    break;
                case "3":
                    deviceList.Add(new Garage());
                    Console.WriteLine("New garage was succesfully added");
                    System.Threading.Thread.Sleep(1000);
                    AddDevice();
                    break;
                case "4":
                    deviceList.Add(new AirConditioner());
                    Console.WriteLine("New air conditioner was succesfully added");
                    System.Threading.Thread.Sleep(1000);
                    AddDevice();
                    break;
                case "5":
                    deviceList.Add(new Camera());
                    Console.WriteLine("New camera was succesfully added");
                    System.Threading.Thread.Sleep(1000);
                    AddDevice();
                    break;
                case "r":
                    Start();
                    break;
                default:
                    Console.WriteLine("You can enter only numbers from 1-5. Press any key");
                    Console.ReadKey();
                    AddDevice();
                    break;
            }


        }

        private void RemoveDevice()
        {
            ShowItems();
            Console.WriteLine();
            if (deviceList.Count > 0)
            {
                Console.WriteLine("Please enter the number of device to remove or \'r\' to return: ");
                string str = Console.ReadLine();
                if (str == "r")
                {
                    Start();
                }
                try
                {
                    int i = Int32.Parse(str);
                    if (i > 0 && i <= deviceList.Count)
                    {
                        String name = deviceList[i - 1].GetType().Name;
                        deviceList.RemoveAt(i - 1);
                        Console.WriteLine("The " + name + " number " + i + " was succesfully removed." +
                                          "\nPress any key to continue");
                        Console.ReadLine();
                        RemoveDevice();

                    }
                    else if (i <= 0)
                    {
                        Console.WriteLine("The number of device can't be less or equal 0! Press any key to continue:");
                        Console.ReadKey();
                        RemoveDevice();
                    }
                    else
                    {
                        Console.WriteLine("The number you entered is too large! Press any key to continue");
                        Console.ReadKey();
                        RemoveDevice();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You can type only number! Press any key to continue:");
                    Console.ReadKey();
                    RemoveDevice();

                }

            }
            else
            {
                Console.WriteLine("You have nothing to remove. Press any key to return:");
                Console.ReadKey();
                Start();
            }
        }

        private void ManageDevice()
        {
            ShowItems();
            Console.WriteLine();
            if (deviceList.Count > 0)
            {
                Console.WriteLine("Please enter the number of device to manage or \'r\' to return: ");
                string str = Console.ReadLine();
                if (str == "r")
                {
                    Start();
                }
                try
                {
                    int i = Int32.Parse(str);
                    if (i > 0 && i <= deviceList.Count)
                    {
                        Console.WriteLine(deviceList[i - 1]);
                        if (deviceList[i - 1] is IOpenable)
                        {
                            IOpenableActions(deviceList[i - 1], i);
                        }
                        else
                        {
                            DeviceActions(deviceList[i - 1], i);
                        }

                    }
                    else if (i <= 0)
                    {
                        Console.WriteLine("The number of device can't be less or equal 0! Press any key to continue:");
                        Console.ReadKey();
                        ManageDevice();
                    }
                    else
                    {
                        Console.WriteLine("The number you entered is too large! Press any key to continue");
                        Console.ReadKey();
                        ManageDevice();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You can type only number! Press any key to continue:");
                    Console.ReadKey();
                    ManageDevice();

                }

            }
            else
            {
                Console.WriteLine("You have nothing to manage. Press any key to return:");
                Console.ReadKey();
                Start();
            }
        }

        private void DeviceActions(Device device, int i)
        {

            Console.WriteLine("Please enter the action to do or \'r\' to return:\n1 - On\n2 - Off");
            string command = Console.ReadLine();
            if (command == "r")
            {
                ManageDevice();
            }

            switch (command)
            {
                case "1":
                    On(device, i);
                    break;
                case "2":
                    Off(device, i);
                    break;
                default:
                    Console.WriteLine("You entered a wrong command. Press any key to continue:");
                    Console.ReadKey();
                    ManageDevice();
                    break;
            }
        }
        private void IOpenableActions(Device device, int i)
        {

            Console.WriteLine("Please enter the action to do or \'r\' to return:\n1 - On\n2 - Off\n3 - Open\n4 - Close");
            string command = Console.ReadLine();
            if (command == "r")
            {
                ManageDevice();
            }

            switch (command)
            {
                case "1":
                    On(device, i);
                    break;
                case "2":
                    Off(device, i);
                    break;
                case "3":
                    Open(device, i);
                    break;
                case "4":
                    Close(device, i);
                    break;
                default:
                    Console.WriteLine("You entered a wrong command. Press any key to continue:");
                    Console.ReadKey();
                    ManageDevice();
                    break;
            }
        }

        private void On(Device device, int i)
        {
            SwitchState state = device.SwitchState;
            if (state == SwitchState.On)
            {
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " is already on");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
            else
            {
                device.On();
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " was succesfully switched on");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
        }

        private void Off(Device device, int i)
        {
            SwitchState state = device.SwitchState;
            if (state == SwitchState.Off)
            {
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " is already off");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
            else
            {
                device.Off();
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " was succesfully switched off");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
        }

        private void Open(Device device, int i)
        {
            OpenState state = (device as IOpenable).OpenState;
            if (state == OpenState.Open)
            {
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " is already opened");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
            else
            {
                (device as IOpenable).Open();
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " was succesfully opened");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
        }
        private void Close(Device device, int i)
        {
            OpenState state = (device as IOpenable).OpenState;
            if (state == OpenState.Close)
            {
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " is already closed");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
            else
            {
                (device as IOpenable).Close();
                Console.Clear();
                Console.WriteLine("The " + device.GetType().Name + " number " + i + " was succesfully closed");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                ManageDevice();
            }
        }
    }
}

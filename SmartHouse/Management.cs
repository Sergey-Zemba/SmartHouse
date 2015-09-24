using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Management
    {
        List<Device> deviceList = new List<Device>();

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Input action to do:\n1 - Show items\n2 - Add device\n3 - Remove device\ne - Exit");
            string str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    ShowItems();
                    break;
                case "2":
                    AddDevice();
                    break;
                case "3":
                    RemoveDevice();
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
            Console.WriteLine("Type \'r\' to return");
            string str = Console.ReadLine();
            if (str == "r")
            {
                Start();
            }
            else
            {
                ShowItems();
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
                    AddDevice();
                    break;
            }


        }

        private void RemoveDevice()
        {
            deviceList.RemoveAt(0);
            Start();
        }

    }
}

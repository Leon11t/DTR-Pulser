using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace DTR_Pulser_v2{
    class Program
    {  
        static SerialPort _serialPort;

        static void Main(string[] args)
        {
            Console.WriteLine("************************************");
            Console.WriteLine("* DTR Pulser v2                    *");
            Console.WriteLine("* Author: Kornuta Taras            *");
            Console.WriteLine("* E-mail: taraskornuta@gmail.com   *");
            Console.WriteLine("* Web: digiua.com                  *");
            Console.WriteLine("************************************\n");
            Console.WriteLine(" Enter \"help\" for info");
            _serialPort = new SerialPort();
            string portName = "COM2";

            if (args.Length != 0)
            {
                if (args[0] == "help")
                    Console.WriteLine("\n Enter only a Port Name-for choosing a port\n\n If port not choosed, default is COM2\n");

                if (args[0] == "COM0")
                    portName = "COM0";

                if (args[0] == "COM1")
                    portName = "COM1";

                if (args[0] == "COM2")
                    portName = "COM2";

                if (args[0] == "COM3")
                    portName = "COM3";

                if (args[0] == "COM4")
                    portName = "COM4";

                if (args[0] == "COM5")
                    portName = "COM5";

                if (args[0] == "COM6")
                    portName = "COM6";

                if (args[0] == "COM7")
                    portName = "COM7";

                if (args[0] == "COM8")
                    portName = "COM8";

                if (args[0] == "COM9")
                    portName = "COM9";

            }
            try
            {
                _serialPort.PortName = portName;
                _serialPort.Open();
                _serialPort.DtrEnable = true;
                _serialPort.Close();


                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
            }
            catch (Exception)
            {
                Console.WriteLine("\n ERROR: No ports is Open or Invalid port!");
            }


        }


    }
      
}


using Microsoft.Owin.Hosting;
using System;

namespace APIHoster
{
    class Program
    {
        public object SQLiteConnection { get; private set; }
        public static int port = 5556;

        static void Main(string[] args)
        {
            Console.WriteLine("CSB Unlimited - Web API Host");
            Console.WriteLine("(c) CSB Unlimited 2017\n");
            Console.WriteLine("-----------------------------------------------\n");
            
            Console.WriteLine("Please wait. Web Service is Starting...");

            int tries = 0;
            AppStart:
            
            try
            {
                using (WebApp.Start<Startup>("http://localhost:" + port.ToString()))
                {
                    Console.WriteLine("Web API Service is Running...\n");
                    Console.WriteLine(@"URL - http://localhost:" + port.ToString() + "/api/user/\n\tGET, GET(id), PUT(User), DELETE(id) avaiable\n");
                    Console.WriteLine("Web API Tracking Started...\n");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("Only accept and return - application/json.\n");
                    Console.WriteLine("Example JSON Return :\n {\"Id\":1,\"FirstName\":\"Chathuranga\",\"LastName\":\"Basnayake\",\"Gender\":\"Male\",\"Mobile\":\"0778511690\"}\n");
                    Console.WriteLine("-----------------------------------------------\n");
                    do
                    {
                        Console.WriteLine("Enter 'q' to Stop Web API Service.\n");
                    } while (!(Console.ReadLine().ToLower()).Equals("q"));
                    Console.WriteLine("-----------------------------------------------\n");
                }
            }
            catch
            {
                Console.WriteLine("Failed to start Web API Service in Port {0}.", port);
                if (tries == 10)
                {
                    Console.Write("Facing some issues while starting Web API Service.\nDo you want to try again? (Yes - y | No - anything else) : ");

                    if (Console.ReadLine().ToLower().Equals("y"))
                        tries = 0;
                }
                if (tries < 10)
                {
                    tries++;
                    port++;
                    Console.WriteLine("Port Changed to {0}. And Trying again...", port);
                    Console.WriteLine();
                    goto AppStart;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Web API Service Stopped...");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TcpBinding.Contracts;

namespace TcpBinding.Client {
    class Program {
        static void Main(string[] args) {
            try {
                var option = (args.Length == 0) ? "1" : args[0];
                Console.WriteLine("press any key to enter.");
                string uri = "net.tcp://localhost:4345/ProductService";
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                binding.SendTimeout = new TimeSpan(0, 10, 0);
                binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
                binding.CloseTimeout = new TimeSpan(0, 10, 0);
                binding.OpenTimeout = new TimeSpan(0, 10, 0);

                var channel = new ChannelFactory<IProductService>(binding);
                var endPoint = new EndpointAddress(uri);
                var proxy = channel.CreateChannel(endPoint);
                switch (option) {
                    case "1":
                        proxy?.GetStrings().ToList().ForEach(p => Console.WriteLine(p));
                        break;
                    case "2":
                        // timeout test
                        proxy?.GetStringsTakesLong().ToList().ForEach(p => Console.WriteLine(p));
                        break;
                    case "3":
                        try {
                            // fail test
                            proxy?.FailRequest().ToList().ForEach(p => Console.WriteLine(p));
                        }
                        catch (Exception exc) {
                            try {
                                proxy?.GetStrings().ToList().ForEach(p => Console.WriteLine(p));
                                Console.WriteLine("sysem finishe ok!!!!!!");
                            }
                            catch (Exception exc1) {
                                System.Diagnostics.Debug.WriteLine(exc1.Message);
                                Console.WriteLine(exc.Message);
                            }
                        }
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
            }
            catch (Exception exc) {
                Console.WriteLine(string.Format("error occurred: {0]", exc.Message));
            }
        }
    }
}

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
                ////proxy?.GetStrings().ToList().ForEach(p => Console.WriteLine(p));
                proxy?.GetStringsTakesLong().ToList().ForEach(p => Console.WriteLine(p));
                Console.ReadLine();
            }
            catch (Exception exc) {
                Console.WriteLine(string.Format("error occurred: {0]", exc.Message));
            }
        }
    }
}

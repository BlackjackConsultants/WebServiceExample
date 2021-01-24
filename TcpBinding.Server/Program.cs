using System;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TcpBinding.Contracts;

namespace TcpBinding.Server {
    class Program {
        static void Main(string[] args) {
            var uris = new Uri[1];
            string addr = "net.tcp://localhost:4345/ProductService";
            uris[0] = new Uri(addr);
            IProductService productService = new ProductService();
            ServiceHost host = new ServiceHost(productService, uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            host.AddServiceEndpoint(typeof(IProductService), binding, "");
            host.Opened += HostOnOpened;
            host.Open();
            Console.ReadLine();
        }

        private static void HostOnOpened(object sender, EventArgs e) {
            Console.WriteLine("wcf service has started");
        }
    }
}

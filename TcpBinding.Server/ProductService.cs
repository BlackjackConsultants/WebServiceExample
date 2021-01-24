﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TcpBinding.Contracts;

namespace TcpBinding.Server {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ProductService : IProductService {
        public string[] GetStrings() {
            return new[] { "server1", "server2", "server3" };
        }
        public string[] GetStringsTakesLong() {
            Thread.Sleep(300000);
            return new[] { "server1", "server2", "server3" };
        }
    }
}

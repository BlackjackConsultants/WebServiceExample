using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace TcpBinding.Contracts {
    [ServiceContract]
    public interface IProductService {
        [OperationContract]
        string[] GetStrings();
    }
}

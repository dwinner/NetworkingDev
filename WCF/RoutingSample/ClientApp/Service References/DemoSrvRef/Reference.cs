//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34014
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApp.DemoSrvRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.cninnovation.com/Services/2012", ConfigurationName="DemoSrvRef.IDemoService")]
    public interface IDemoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cninnovation.com/Services/2012/IDemoService/GetData", ReplyAction="http://www.cninnovation.com/Services/2012/IDemoService/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cninnovation.com/Services/2012/IDemoService/GetData", ReplyAction="http://www.cninnovation.com/Services/2012/IDemoService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDemoServiceChannel : ClientApp.DemoSrvRef.IDemoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DemoServiceClient : System.ServiceModel.ClientBase<ClientApp.DemoSrvRef.IDemoService>, ClientApp.DemoSrvRef.IDemoService {
        
        public DemoServiceClient() {
        }
        
        public DemoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DemoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DemoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DemoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(string value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string value) {
            return base.Channel.GetDataAsync(value);
        }
    }
}

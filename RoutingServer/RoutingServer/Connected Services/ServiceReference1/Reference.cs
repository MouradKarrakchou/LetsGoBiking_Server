﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoutingServer.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JCDContract", Namespace="http://schemas.datacontract.org/2004/07/ProxyCache")]
    [System.SerializableAttribute()]
    public partial class JCDContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] citiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] cities {
            get {
                return this.citiesField;
            }
            set {
                if ((object.ReferenceEquals(this.citiesField, value) != true)) {
                    this.citiesField = value;
                    this.RaisePropertyChanged("cities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JCDStation", Namespace="http://schemas.datacontract.org/2004/07/ProxyCache")]
    [System.SerializableAttribute()]
    public partial class JCDStation : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contractNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServer.ServiceReference1.MainStands mainStandsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServer.ServiceReference1.Position positionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string contractName {
            get {
                return this.contractNameField;
            }
            set {
                if ((object.ReferenceEquals(this.contractNameField, value) != true)) {
                    this.contractNameField = value;
                    this.RaisePropertyChanged("contractName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServer.ServiceReference1.MainStands mainStands {
            get {
                return this.mainStandsField;
            }
            set {
                if ((object.ReferenceEquals(this.mainStandsField, value) != true)) {
                    this.mainStandsField = value;
                    this.RaisePropertyChanged("mainStands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServer.ServiceReference1.Position position {
            get {
                return this.positionField;
            }
            set {
                if ((object.ReferenceEquals(this.positionField, value) != true)) {
                    this.positionField = value;
                    this.RaisePropertyChanged("position");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MainStands", Namespace="http://schemas.datacontract.org/2004/07/ProxyCache")]
    [System.SerializableAttribute()]
    public partial class MainStands : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RoutingServer.ServiceReference1.Availabilities availabilitiesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServer.ServiceReference1.Availabilities availabilities {
            get {
                return this.availabilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.availabilitiesField, value) != true)) {
                    this.availabilitiesField = value;
                    this.RaisePropertyChanged("availabilities");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/ProxyCache")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double latitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double longitudeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Availabilities", Namespace="http://schemas.datacontract.org/2004/07/ProxyCache")]
    [System.SerializableAttribute()]
    public partial class Availabilities : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int bikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int standsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int bikes {
            get {
                return this.bikesField;
            }
            set {
                if ((this.bikesField.Equals(value) != true)) {
                    this.bikesField = value;
                    this.RaisePropertyChanged("bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int stands {
            get {
                return this.standsField;
            }
            set {
                if ((this.standsField.Equals(value) != true)) {
                    this.standsField = value;
                    this.RaisePropertyChanged("stands");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IProxy")]
    public interface IProxy {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxy/getAllContracts", ReplyAction="http://tempuri.org/IProxy/getAllContractsResponse")]
        RoutingServer.ServiceReference1.JCDContract[] getAllContracts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxy/getAllContracts", ReplyAction="http://tempuri.org/IProxy/getAllContractsResponse")]
        System.Threading.Tasks.Task<RoutingServer.ServiceReference1.JCDContract[]> getAllContractsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxy/getStations", ReplyAction="http://tempuri.org/IProxy/getStationsResponse")]
        RoutingServer.ServiceReference1.JCDStation[] getStations(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxy/getStations", ReplyAction="http://tempuri.org/IProxy/getStationsResponse")]
        System.Threading.Tasks.Task<RoutingServer.ServiceReference1.JCDStation[]> getStationsAsync(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxy/getContract", ReplyAction="http://tempuri.org/IProxy/getContractResponse")]
        RoutingServer.ServiceReference1.JCDContract getContract(string cityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxy/getContract", ReplyAction="http://tempuri.org/IProxy/getContractResponse")]
        System.Threading.Tasks.Task<RoutingServer.ServiceReference1.JCDContract> getContractAsync(string cityName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProxyChannel : RoutingServer.ServiceReference1.IProxy, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProxyClient : System.ServiceModel.ClientBase<RoutingServer.ServiceReference1.IProxy>, RoutingServer.ServiceReference1.IProxy {
        
        public ProxyClient() {
        }
        
        public ProxyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProxyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RoutingServer.ServiceReference1.JCDContract[] getAllContracts() {
            return base.Channel.getAllContracts();
        }
        
        public System.Threading.Tasks.Task<RoutingServer.ServiceReference1.JCDContract[]> getAllContractsAsync() {
            return base.Channel.getAllContractsAsync();
        }
        
        public RoutingServer.ServiceReference1.JCDStation[] getStations(string contract) {
            return base.Channel.getStations(contract);
        }
        
        public System.Threading.Tasks.Task<RoutingServer.ServiceReference1.JCDStation[]> getStationsAsync(string contract) {
            return base.Channel.getStationsAsync(contract);
        }
        
        public RoutingServer.ServiceReference1.JCDContract getContract(string cityName) {
            return base.Channel.getContract(cityName);
        }
        
        public System.Threading.Tasks.Task<RoutingServer.ServiceReference1.JCDContract> getContractAsync(string cityName) {
            return base.Channel.getContractAsync(cityName);
        }
    }
}

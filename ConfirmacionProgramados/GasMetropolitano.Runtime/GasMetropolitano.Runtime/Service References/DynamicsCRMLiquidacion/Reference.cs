﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GasMetropolitano.Runtime.DynamicsCRMLiquidacion {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PedidoCambioEstatus", Namespace="http://schemas.datacontract.org/2004/07/ServicioLiquidacionPedidos")]
    [System.SerializableAttribute()]
    public partial class PedidoCambioEstatus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> Itssa_idestatuspedidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> Itssa_idpedidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> itssa_autotanquemovilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> itssa_factualizacionestatusmovilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> itssa_foliofacturaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> itssa_idrutaboletinField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> itssa_idsgcField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> itssa_idstatusmovilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string itssa_seriefacturaField;
        
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
        public System.Nullable<int> Itssa_idestatuspedido {
            get {
                return this.Itssa_idestatuspedidoField;
            }
            set {
                if ((this.Itssa_idestatuspedidoField.Equals(value) != true)) {
                    this.Itssa_idestatuspedidoField = value;
                    this.RaisePropertyChanged("Itssa_idestatuspedido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Itssa_idpedido {
            get {
                return this.Itssa_idpedidoField;
            }
            set {
                if ((this.Itssa_idpedidoField.Equals(value) != true)) {
                    this.Itssa_idpedidoField = value;
                    this.RaisePropertyChanged("Itssa_idpedido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> itssa_autotanquemovil {
            get {
                return this.itssa_autotanquemovilField;
            }
            set {
                if ((this.itssa_autotanquemovilField.Equals(value) != true)) {
                    this.itssa_autotanquemovilField = value;
                    this.RaisePropertyChanged("itssa_autotanquemovil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> itssa_factualizacionestatusmovil {
            get {
                return this.itssa_factualizacionestatusmovilField;
            }
            set {
                if ((this.itssa_factualizacionestatusmovilField.Equals(value) != true)) {
                    this.itssa_factualizacionestatusmovilField = value;
                    this.RaisePropertyChanged("itssa_factualizacionestatusmovil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> itssa_foliofactura {
            get {
                return this.itssa_foliofacturaField;
            }
            set {
                if ((this.itssa_foliofacturaField.Equals(value) != true)) {
                    this.itssa_foliofacturaField = value;
                    this.RaisePropertyChanged("itssa_foliofactura");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> itssa_idrutaboletin {
            get {
                return this.itssa_idrutaboletinField;
            }
            set {
                if ((this.itssa_idrutaboletinField.Equals(value) != true)) {
                    this.itssa_idrutaboletinField = value;
                    this.RaisePropertyChanged("itssa_idrutaboletin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> itssa_idsgc {
            get {
                return this.itssa_idsgcField;
            }
            set {
                if ((this.itssa_idsgcField.Equals(value) != true)) {
                    this.itssa_idsgcField = value;
                    this.RaisePropertyChanged("itssa_idsgc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> itssa_idstatusmovil {
            get {
                return this.itssa_idstatusmovilField;
            }
            set {
                if ((this.itssa_idstatusmovilField.Equals(value) != true)) {
                    this.itssa_idstatusmovilField = value;
                    this.RaisePropertyChanged("itssa_idstatusmovil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string itssa_seriefactura {
            get {
                return this.itssa_seriefacturaField;
            }
            set {
                if ((object.ReferenceEquals(this.itssa_seriefacturaField, value) != true)) {
                    this.itssa_seriefacturaField = value;
                    this.RaisePropertyChanged("itssa_seriefactura");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Resultado", Namespace="http://schemas.datacontract.org/2004/07/ServicioLiquidacionPedidos")]
    [System.SerializableAttribute()]
    public partial class Resultado : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExcepcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ObservacionesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> OperacionExitosaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GasMetropolitano.Runtime.DynamicsCRMLiquidacion.PedidoCambioEstatus PedidoCambioEstatusField;
        
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
        public string Excepcion {
            get {
                return this.ExcepcionField;
            }
            set {
                if ((object.ReferenceEquals(this.ExcepcionField, value) != true)) {
                    this.ExcepcionField = value;
                    this.RaisePropertyChanged("Excepcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Observaciones {
            get {
                return this.ObservacionesField;
            }
            set {
                if ((object.ReferenceEquals(this.ObservacionesField, value) != true)) {
                    this.ObservacionesField = value;
                    this.RaisePropertyChanged("Observaciones");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> OperacionExitosa {
            get {
                return this.OperacionExitosaField;
            }
            set {
                if ((this.OperacionExitosaField.Equals(value) != true)) {
                    this.OperacionExitosaField = value;
                    this.RaisePropertyChanged("OperacionExitosa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GasMetropolitano.Runtime.DynamicsCRMLiquidacion.PedidoCambioEstatus PedidoCambioEstatus {
            get {
                return this.PedidoCambioEstatusField;
            }
            set {
                if ((object.ReferenceEquals(this.PedidoCambioEstatusField, value) != true)) {
                    this.PedidoCambioEstatusField = value;
                    this.RaisePropertyChanged("PedidoCambioEstatus");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DynamicsCRMLiquidacion.IServicioLiquidacionPedidos")]
    public interface IServicioLiquidacionPedidos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioLiquidacionPedidos/cambioEstatusPedido", ReplyAction="http://tempuri.org/IServicioLiquidacionPedidos/cambioEstatusPedidoResponse")]
        GasMetropolitano.Runtime.DynamicsCRMLiquidacion.Resultado cambioEstatusPedido(GasMetropolitano.Runtime.DynamicsCRMLiquidacion.PedidoCambioEstatus tipo_PedidoCambioEstatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioLiquidacionPedidos/cambioEstatusPedido", ReplyAction="http://tempuri.org/IServicioLiquidacionPedidos/cambioEstatusPedidoResponse")]
        System.Threading.Tasks.Task<GasMetropolitano.Runtime.DynamicsCRMLiquidacion.Resultado> cambioEstatusPedidoAsync(GasMetropolitano.Runtime.DynamicsCRMLiquidacion.PedidoCambioEstatus tipo_PedidoCambioEstatus);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioLiquidacionPedidosChannel : GasMetropolitano.Runtime.DynamicsCRMLiquidacion.IServicioLiquidacionPedidos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioLiquidacionPedidosClient : System.ServiceModel.ClientBase<GasMetropolitano.Runtime.DynamicsCRMLiquidacion.IServicioLiquidacionPedidos>, GasMetropolitano.Runtime.DynamicsCRMLiquidacion.IServicioLiquidacionPedidos {
        
        public ServicioLiquidacionPedidosClient() {
        }
        
        public ServicioLiquidacionPedidosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioLiquidacionPedidosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioLiquidacionPedidosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioLiquidacionPedidosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GasMetropolitano.Runtime.DynamicsCRMLiquidacion.Resultado cambioEstatusPedido(GasMetropolitano.Runtime.DynamicsCRMLiquidacion.PedidoCambioEstatus tipo_PedidoCambioEstatus) {
            return base.Channel.cambioEstatusPedido(tipo_PedidoCambioEstatus);
        }
        
        public System.Threading.Tasks.Task<GasMetropolitano.Runtime.DynamicsCRMLiquidacion.Resultado> cambioEstatusPedidoAsync(GasMetropolitano.Runtime.DynamicsCRMLiquidacion.PedidoCambioEstatus tipo_PedidoCambioEstatus) {
            return base.Channel.cambioEstatusPedidoAsync(tipo_PedidoCambioEstatus);
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp.SimplexSoapCliect {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="A", Namespace="http://kao/")]
    [System.SerializableAttribute()]
    public partial class A : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sField;
        
        private int kField;
        
        private float fField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string s {
            get {
                return this.sField;
            }
            set {
                if ((object.ReferenceEquals(this.sField, value) != true)) {
                    this.sField = value;
                    this.RaisePropertyChanged("s");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int k {
            get {
                return this.kField;
            }
            set {
                if ((this.kField.Equals(value) != true)) {
                    this.kField = value;
                    this.RaisePropertyChanged("k");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public float f {
            get {
                return this.fField;
            }
            set {
                if ((this.fField.Equals(value) != true)) {
                    this.fField = value;
                    this.RaisePropertyChanged("f");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://kao/", ConfigurationName="SimplexSoapCliect.SimplexSoap")]
    public interface SimplexSoap {
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (add) сообщения add не соответствует значению по умолчанию (Add).
        [System.ServiceModel.OperationContractAttribute(Action="http://kao/add", ReplyAction="*")]
        WindowsFormsApp.SimplexSoapCliect.add1 Add(WindowsFormsApp.SimplexSoapCliect.add request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://kao/add", ReplyAction="*")]
        System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.add1> AddAsync(WindowsFormsApp.SimplexSoapCliect.add request);
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (concat) сообщения concat не соответствует значению по умолчанию (Concat).
        [System.ServiceModel.OperationContractAttribute(Action="http://kao/concat", ReplyAction="*")]
        WindowsFormsApp.SimplexSoapCliect.concat1 Concat(WindowsFormsApp.SimplexSoapCliect.concat request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://kao/concat", ReplyAction="*")]
        System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.concat1> ConcatAsync(WindowsFormsApp.SimplexSoapCliect.concat request);
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (sum) сообщения sum не соответствует значению по умолчанию (Sum).
        [System.ServiceModel.OperationContractAttribute(Action="http://kao/sum", ReplyAction="*")]
        WindowsFormsApp.SimplexSoapCliect.sum1 Sum(WindowsFormsApp.SimplexSoapCliect.sum request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://kao/sum", ReplyAction="*")]
        System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.sum1> SumAsync(WindowsFormsApp.SimplexSoapCliect.sum request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="add", WrapperNamespace="http://kao/", IsWrapped=true)]
    public partial class add {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=0)]
        public int x;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=1)]
        public int y;
        
        public add() {
        }
        
        public add(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="addResponse", WrapperNamespace="http://kao/", IsWrapped=true)]
    public partial class add1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=0)]
        public int addResult;
        
        public add1() {
        }
        
        public add1(int addResult) {
            this.addResult = addResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="concat", WrapperNamespace="http://kao/", IsWrapped=true)]
    public partial class concat {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=0)]
        public string s;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=1)]
        public double d;
        
        public concat() {
        }
        
        public concat(string s, double d) {
            this.s = s;
            this.d = d;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="concatResponse", WrapperNamespace="http://kao/", IsWrapped=true)]
    public partial class concat1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=0)]
        public string concatResult;
        
        public concat1() {
        }
        
        public concat1(string concatResult) {
            this.concatResult = concatResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sum", WrapperNamespace="http://kao/", IsWrapped=true)]
    public partial class sum {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=0)]
        public WindowsFormsApp.SimplexSoapCliect.A a1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=1)]
        public WindowsFormsApp.SimplexSoapCliect.A a2;
        
        public sum() {
        }
        
        public sum(WindowsFormsApp.SimplexSoapCliect.A a1, WindowsFormsApp.SimplexSoapCliect.A a2) {
            this.a1 = a1;
            this.a2 = a2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sumResponse", WrapperNamespace="http://kao/", IsWrapped=true)]
    public partial class sum1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kao/", Order=0)]
        public WindowsFormsApp.SimplexSoapCliect.A sumResult;
        
        public sum1() {
        }
        
        public sum1(WindowsFormsApp.SimplexSoapCliect.A sumResult) {
            this.sumResult = sumResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SimplexSoapChannel : WindowsFormsApp.SimplexSoapCliect.SimplexSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SimplexSoapClient : System.ServiceModel.ClientBase<WindowsFormsApp.SimplexSoapCliect.SimplexSoap>, WindowsFormsApp.SimplexSoapCliect.SimplexSoap {
        
        public SimplexSoapClient() {
        }
        
        public SimplexSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SimplexSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WindowsFormsApp.SimplexSoapCliect.add1 WindowsFormsApp.SimplexSoapCliect.SimplexSoap.Add(WindowsFormsApp.SimplexSoapCliect.add request) {
            return base.Channel.Add(request);
        }
        
        public int Add(int x, int y) {
            WindowsFormsApp.SimplexSoapCliect.add inValue = new WindowsFormsApp.SimplexSoapCliect.add();
            inValue.x = x;
            inValue.y = y;
            WindowsFormsApp.SimplexSoapCliect.add1 retVal = ((WindowsFormsApp.SimplexSoapCliect.SimplexSoap)(this)).Add(inValue);
            return retVal.addResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.add1> WindowsFormsApp.SimplexSoapCliect.SimplexSoap.AddAsync(WindowsFormsApp.SimplexSoapCliect.add request) {
            return base.Channel.AddAsync(request);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.add1> AddAsync(int x, int y) {
            WindowsFormsApp.SimplexSoapCliect.add inValue = new WindowsFormsApp.SimplexSoapCliect.add();
            inValue.x = x;
            inValue.y = y;
            return ((WindowsFormsApp.SimplexSoapCliect.SimplexSoap)(this)).AddAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WindowsFormsApp.SimplexSoapCliect.concat1 WindowsFormsApp.SimplexSoapCliect.SimplexSoap.Concat(WindowsFormsApp.SimplexSoapCliect.concat request) {
            return base.Channel.Concat(request);
        }
        
        public string Concat(string s, double d) {
            WindowsFormsApp.SimplexSoapCliect.concat inValue = new WindowsFormsApp.SimplexSoapCliect.concat();
            inValue.s = s;
            inValue.d = d;
            WindowsFormsApp.SimplexSoapCliect.concat1 retVal = ((WindowsFormsApp.SimplexSoapCliect.SimplexSoap)(this)).Concat(inValue);
            return retVal.concatResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.concat1> WindowsFormsApp.SimplexSoapCliect.SimplexSoap.ConcatAsync(WindowsFormsApp.SimplexSoapCliect.concat request) {
            return base.Channel.ConcatAsync(request);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.concat1> ConcatAsync(string s, double d) {
            WindowsFormsApp.SimplexSoapCliect.concat inValue = new WindowsFormsApp.SimplexSoapCliect.concat();
            inValue.s = s;
            inValue.d = d;
            return ((WindowsFormsApp.SimplexSoapCliect.SimplexSoap)(this)).ConcatAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WindowsFormsApp.SimplexSoapCliect.sum1 WindowsFormsApp.SimplexSoapCliect.SimplexSoap.Sum(WindowsFormsApp.SimplexSoapCliect.sum request) {
            return base.Channel.Sum(request);
        }
        
        public WindowsFormsApp.SimplexSoapCliect.A Sum(WindowsFormsApp.SimplexSoapCliect.A a1, WindowsFormsApp.SimplexSoapCliect.A a2) {
            WindowsFormsApp.SimplexSoapCliect.sum inValue = new WindowsFormsApp.SimplexSoapCliect.sum();
            inValue.a1 = a1;
            inValue.a2 = a2;
            WindowsFormsApp.SimplexSoapCliect.sum1 retVal = ((WindowsFormsApp.SimplexSoapCliect.SimplexSoap)(this)).Sum(inValue);
            return retVal.sumResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.sum1> WindowsFormsApp.SimplexSoapCliect.SimplexSoap.SumAsync(WindowsFormsApp.SimplexSoapCliect.sum request) {
            return base.Channel.SumAsync(request);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApp.SimplexSoapCliect.sum1> SumAsync(WindowsFormsApp.SimplexSoapCliect.A a1, WindowsFormsApp.SimplexSoapCliect.A a2) {
            WindowsFormsApp.SimplexSoapCliect.sum inValue = new WindowsFormsApp.SimplexSoapCliect.sum();
            inValue.a1 = a1;
            inValue.a2 = a2;
            return ((WindowsFormsApp.SimplexSoapCliect.SimplexSoap)(this)).SumAsync(inValue);
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyRapid.Proxy.MainService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MyParameter", Namespace="http://schemas.datacontract.org/2004/07/MyRapid.Server")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter>))]
    public partial class MyParameter : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SourceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ValueField;
        
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Source {
            get {
                return this.SourceField;
            }
            set {
                if ((object.ReferenceEquals(this.SourceField, value) != true)) {
                    this.SourceField = value;
                    this.RaisePropertyChanged("Source");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MainService.IMainService", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IMainService {
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMainService/Open", ReplyAction="http://tempuri.org/IMainService/OpenResponse")]
        System.Data.DataTable Open(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IMainService/Open", ReplyAction="http://tempuri.org/IMainService/OpenResponse")]
        System.IAsyncResult BeginOpen(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, System.AsyncCallback callback, object asyncState);
        
        System.Data.DataTable EndOpen(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMainService/Save", ReplyAction="http://tempuri.org/IMainService/SaveResponse")]
        System.Data.DataTable Save(string WorkSet_Id, System.Data.DataTable dt, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IMainService/Save", ReplyAction="http://tempuri.org/IMainService/SaveResponse")]
        System.IAsyncResult BeginSave(string WorkSet_Id, System.Data.DataTable dt, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, System.AsyncCallback callback, object asyncState);
        
        System.Data.DataTable EndSave(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMainService/Execute", ReplyAction="http://tempuri.org/IMainService/ExecuteResponse")]
        int Execute(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, string CRUD);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IMainService/Execute", ReplyAction="http://tempuri.org/IMainService/ExecuteResponse")]
        System.IAsyncResult BeginExecute(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, string CRUD, System.AsyncCallback callback, object asyncState);
        
        int EndExecute(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMainService/GetToken", ReplyAction="http://tempuri.org/IMainService/GetTokenResponse")]
        string GetToken(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMainService/GetToken", ReplyAction="http://tempuri.org/IMainService/GetTokenResponse")]
        System.IAsyncResult BeginGetToken(string userName, string password, System.AsyncCallback callback, object asyncState);
        
        string EndGetToken(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IMainService/LoginOut")]
        void LoginOut();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IMainService/LoginOut")]
        System.IAsyncResult BeginLoginOut(System.AsyncCallback callback, object asyncState);
        
        void EndLoginOut(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMainService/SaveFile", ReplyAction="http://tempuri.org/IMainService/SaveFileResponse")]
        string SaveFile(byte[] file, string fileName);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IMainService/SaveFile", ReplyAction="http://tempuri.org/IMainService/SaveFileResponse")]
        System.IAsyncResult BeginSaveFile(byte[] file, string fileName, System.AsyncCallback callback, object asyncState);
        
        string EndSaveFile(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMainService/GetFile", ReplyAction="http://tempuri.org/IMainService/GetFileResponse")]
        byte[] GetFile(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, AsyncPattern=true, Action="http://tempuri.org/IMainService/GetFile", ReplyAction="http://tempuri.org/IMainService/GetFileResponse")]
        System.IAsyncResult BeginGetFile(string fileName, System.AsyncCallback callback, object asyncState);
        
        byte[] EndGetFile(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMainServiceChannel : MyRapid.Proxy.MainService.IMainService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OpenCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public OpenCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Data.DataTable Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SaveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SaveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Data.DataTable Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExecuteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ExecuteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetTokenCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetTokenCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SaveFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SaveFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public byte[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MainServiceClient : System.ServiceModel.ClientBase<MyRapid.Proxy.MainService.IMainService>, MyRapid.Proxy.MainService.IMainService {
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginSaveDelegate;
        
        private EndOperationDelegate onEndSaveDelegate;
        
        private System.Threading.SendOrPostCallback onSaveCompletedDelegate;
        
        private BeginOperationDelegate onBeginExecuteDelegate;
        
        private EndOperationDelegate onEndExecuteDelegate;
        
        private System.Threading.SendOrPostCallback onExecuteCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetTokenDelegate;
        
        private EndOperationDelegate onEndGetTokenDelegate;
        
        private System.Threading.SendOrPostCallback onGetTokenCompletedDelegate;
        
        private BeginOperationDelegate onBeginLoginOutDelegate;
        
        private EndOperationDelegate onEndLoginOutDelegate;
        
        private System.Threading.SendOrPostCallback onLoginOutCompletedDelegate;
        
        private BeginOperationDelegate onBeginSaveFileDelegate;
        
        private EndOperationDelegate onEndSaveFileDelegate;
        
        private System.Threading.SendOrPostCallback onSaveFileCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetFileDelegate;
        
        private EndOperationDelegate onEndGetFileDelegate;
        
        private System.Threading.SendOrPostCallback onGetFileCompletedDelegate;
        
        public MainServiceClient() {
        }
        
        public MainServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MainServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MainServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<OpenCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<SaveCompletedEventArgs> SaveCompleted;
        
        public event System.EventHandler<ExecuteCompletedEventArgs> ExecuteCompleted;
        
        public event System.EventHandler<GetTokenCompletedEventArgs> GetTokenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> LoginOutCompleted;
        
        public event System.EventHandler<SaveFileCompletedEventArgs> SaveFileCompleted;
        
        public event System.EventHandler<GetFileCompletedEventArgs> GetFileCompleted;
        
        public System.Data.DataTable Open(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters) {
            return base.Channel.Open(WorkSet_Id, sqlParameters);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginOpen(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginOpen(WorkSet_Id, sqlParameters, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Data.DataTable EndOpen(System.IAsyncResult result) {
            return base.Channel.EndOpen(result);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string WorkSet_Id = ((string)(inValues[0]));
            System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters = ((System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter>)(inValues[1]));
            return this.BeginOpen(WorkSet_Id, sqlParameters, callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            System.Data.DataTable retVal = this.EndOpen(result);
            return new object[] {
                    retVal};
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new OpenCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters) {
            this.OpenAsync(WorkSet_Id, sqlParameters, null);
        }
        
        public void OpenAsync(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, new object[] {
                        WorkSet_Id,
                        sqlParameters}, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        public System.Data.DataTable Save(string WorkSet_Id, System.Data.DataTable dt, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters) {
            return base.Channel.Save(WorkSet_Id, dt, sqlParameters);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSave(string WorkSet_Id, System.Data.DataTable dt, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSave(WorkSet_Id, dt, sqlParameters, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Data.DataTable EndSave(System.IAsyncResult result) {
            return base.Channel.EndSave(result);
        }
        
        private System.IAsyncResult OnBeginSave(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string WorkSet_Id = ((string)(inValues[0]));
            System.Data.DataTable dt = ((System.Data.DataTable)(inValues[1]));
            System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters = ((System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter>)(inValues[2]));
            return this.BeginSave(WorkSet_Id, dt, sqlParameters, callback, asyncState);
        }
        
        private object[] OnEndSave(System.IAsyncResult result) {
            System.Data.DataTable retVal = this.EndSave(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSaveCompleted(object state) {
            if ((this.SaveCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SaveCompleted(this, new SaveCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SaveAsync(string WorkSet_Id, System.Data.DataTable dt, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters) {
            this.SaveAsync(WorkSet_Id, dt, sqlParameters, null);
        }
        
        public void SaveAsync(string WorkSet_Id, System.Data.DataTable dt, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, object userState) {
            if ((this.onBeginSaveDelegate == null)) {
                this.onBeginSaveDelegate = new BeginOperationDelegate(this.OnBeginSave);
            }
            if ((this.onEndSaveDelegate == null)) {
                this.onEndSaveDelegate = new EndOperationDelegate(this.OnEndSave);
            }
            if ((this.onSaveCompletedDelegate == null)) {
                this.onSaveCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSaveCompleted);
            }
            base.InvokeAsync(this.onBeginSaveDelegate, new object[] {
                        WorkSet_Id,
                        dt,
                        sqlParameters}, this.onEndSaveDelegate, this.onSaveCompletedDelegate, userState);
        }
        
        public int Execute(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, string CRUD) {
            return base.Channel.Execute(WorkSet_Id, sqlParameters, CRUD);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginExecute(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, string CRUD, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginExecute(WorkSet_Id, sqlParameters, CRUD, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public int EndExecute(System.IAsyncResult result) {
            return base.Channel.EndExecute(result);
        }
        
        private System.IAsyncResult OnBeginExecute(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string WorkSet_Id = ((string)(inValues[0]));
            System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters = ((System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter>)(inValues[1]));
            string CRUD = ((string)(inValues[2]));
            return this.BeginExecute(WorkSet_Id, sqlParameters, CRUD, callback, asyncState);
        }
        
        private object[] OnEndExecute(System.IAsyncResult result) {
            int retVal = this.EndExecute(result);
            return new object[] {
                    retVal};
        }
        
        private void OnExecuteCompleted(object state) {
            if ((this.ExecuteCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ExecuteCompleted(this, new ExecuteCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ExecuteAsync(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, string CRUD) {
            this.ExecuteAsync(WorkSet_Id, sqlParameters, CRUD, null);
        }
        
        public void ExecuteAsync(string WorkSet_Id, System.Collections.Generic.List<MyRapid.Proxy.MainService.MyParameter> sqlParameters, string CRUD, object userState) {
            if ((this.onBeginExecuteDelegate == null)) {
                this.onBeginExecuteDelegate = new BeginOperationDelegate(this.OnBeginExecute);
            }
            if ((this.onEndExecuteDelegate == null)) {
                this.onEndExecuteDelegate = new EndOperationDelegate(this.OnEndExecute);
            }
            if ((this.onExecuteCompletedDelegate == null)) {
                this.onExecuteCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnExecuteCompleted);
            }
            base.InvokeAsync(this.onBeginExecuteDelegate, new object[] {
                        WorkSet_Id,
                        sqlParameters,
                        CRUD}, this.onEndExecuteDelegate, this.onExecuteCompletedDelegate, userState);
        }
        
        public string GetToken(string userName, string password) {
            return base.Channel.GetToken(userName, password);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetToken(string userName, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetToken(userName, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndGetToken(System.IAsyncResult result) {
            return base.Channel.EndGetToken(result);
        }
        
        private System.IAsyncResult OnBeginGetToken(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userName = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return this.BeginGetToken(userName, password, callback, asyncState);
        }
        
        private object[] OnEndGetToken(System.IAsyncResult result) {
            string retVal = this.EndGetToken(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetTokenCompleted(object state) {
            if ((this.GetTokenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTokenCompleted(this, new GetTokenCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetTokenAsync(string userName, string password) {
            this.GetTokenAsync(userName, password, null);
        }
        
        public void GetTokenAsync(string userName, string password, object userState) {
            if ((this.onBeginGetTokenDelegate == null)) {
                this.onBeginGetTokenDelegate = new BeginOperationDelegate(this.OnBeginGetToken);
            }
            if ((this.onEndGetTokenDelegate == null)) {
                this.onEndGetTokenDelegate = new EndOperationDelegate(this.OnEndGetToken);
            }
            if ((this.onGetTokenCompletedDelegate == null)) {
                this.onGetTokenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTokenCompleted);
            }
            base.InvokeAsync(this.onBeginGetTokenDelegate, new object[] {
                        userName,
                        password}, this.onEndGetTokenDelegate, this.onGetTokenCompletedDelegate, userState);
        }
        
        public void LoginOut() {
            base.Channel.LoginOut();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginLoginOut(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginLoginOut(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndLoginOut(System.IAsyncResult result) {
            base.Channel.EndLoginOut(result);
        }
        
        private System.IAsyncResult OnBeginLoginOut(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginLoginOut(callback, asyncState);
        }
        
        private object[] OnEndLoginOut(System.IAsyncResult result) {
            this.EndLoginOut(result);
            return null;
        }
        
        private void OnLoginOutCompleted(object state) {
            if ((this.LoginOutCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.LoginOutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void LoginOutAsync() {
            this.LoginOutAsync(null);
        }
        
        public void LoginOutAsync(object userState) {
            if ((this.onBeginLoginOutDelegate == null)) {
                this.onBeginLoginOutDelegate = new BeginOperationDelegate(this.OnBeginLoginOut);
            }
            if ((this.onEndLoginOutDelegate == null)) {
                this.onEndLoginOutDelegate = new EndOperationDelegate(this.OnEndLoginOut);
            }
            if ((this.onLoginOutCompletedDelegate == null)) {
                this.onLoginOutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLoginOutCompleted);
            }
            base.InvokeAsync(this.onBeginLoginOutDelegate, null, this.onEndLoginOutDelegate, this.onLoginOutCompletedDelegate, userState);
        }
        
        public string SaveFile(byte[] file, string fileName) {
            return base.Channel.SaveFile(file, fileName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSaveFile(byte[] file, string fileName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSaveFile(file, fileName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndSaveFile(System.IAsyncResult result) {
            return base.Channel.EndSaveFile(result);
        }
        
        private System.IAsyncResult OnBeginSaveFile(object[] inValues, System.AsyncCallback callback, object asyncState) {
            byte[] file = ((byte[])(inValues[0]));
            string fileName = ((string)(inValues[1]));
            return this.BeginSaveFile(file, fileName, callback, asyncState);
        }
        
        private object[] OnEndSaveFile(System.IAsyncResult result) {
            string retVal = this.EndSaveFile(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSaveFileCompleted(object state) {
            if ((this.SaveFileCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SaveFileCompleted(this, new SaveFileCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SaveFileAsync(byte[] file, string fileName) {
            this.SaveFileAsync(file, fileName, null);
        }
        
        public void SaveFileAsync(byte[] file, string fileName, object userState) {
            if ((this.onBeginSaveFileDelegate == null)) {
                this.onBeginSaveFileDelegate = new BeginOperationDelegate(this.OnBeginSaveFile);
            }
            if ((this.onEndSaveFileDelegate == null)) {
                this.onEndSaveFileDelegate = new EndOperationDelegate(this.OnEndSaveFile);
            }
            if ((this.onSaveFileCompletedDelegate == null)) {
                this.onSaveFileCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSaveFileCompleted);
            }
            base.InvokeAsync(this.onBeginSaveFileDelegate, new object[] {
                        file,
                        fileName}, this.onEndSaveFileDelegate, this.onSaveFileCompletedDelegate, userState);
        }
        
        public byte[] GetFile(string fileName) {
            return base.Channel.GetFile(fileName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetFile(string fileName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetFile(fileName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public byte[] EndGetFile(System.IAsyncResult result) {
            return base.Channel.EndGetFile(result);
        }
        
        private System.IAsyncResult OnBeginGetFile(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string fileName = ((string)(inValues[0]));
            return this.BeginGetFile(fileName, callback, asyncState);
        }
        
        private object[] OnEndGetFile(System.IAsyncResult result) {
            byte[] retVal = this.EndGetFile(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetFileCompleted(object state) {
            if ((this.GetFileCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetFileCompleted(this, new GetFileCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetFileAsync(string fileName) {
            this.GetFileAsync(fileName, null);
        }
        
        public void GetFileAsync(string fileName, object userState) {
            if ((this.onBeginGetFileDelegate == null)) {
                this.onBeginGetFileDelegate = new BeginOperationDelegate(this.OnBeginGetFile);
            }
            if ((this.onEndGetFileDelegate == null)) {
                this.onEndGetFileDelegate = new EndOperationDelegate(this.OnEndGetFile);
            }
            if ((this.onGetFileCompletedDelegate == null)) {
                this.onGetFileCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetFileCompleted);
            }
            base.InvokeAsync(this.onBeginGetFileDelegate, new object[] {
                        fileName}, this.onEndGetFileDelegate, this.onGetFileCompletedDelegate, userState);
        }
    }
}

﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.18444
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace ServiceReference1
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="CompositeType", [Namespace]:="http://schemas.datacontract.org/2004/07/wcfServicios"),  _
     System.SerializableAttribute()>  _
    Partial Public Class CompositeType
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private BoolValueField As Boolean
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private StringValueField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property BoolValue() As Boolean
            Get
                Return Me.BoolValueField
            End Get
            Set
                If (Me.BoolValueField.Equals(value) <> true) Then
                    Me.BoolValueField = value
                    Me.RaisePropertyChanged("BoolValue")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property StringValue() As String
            Get
                Return Me.StringValueField
            End Get
            Set
                If (Object.ReferenceEquals(Me.StringValueField, value) <> true) Then
                    Me.StringValueField = value
                    Me.RaisePropertyChanged("StringValue")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ServiceReference1.IService1")>  _
    Public Interface IService1
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/GetData", ReplyAction:="http://tempuri.org/IService1/GetDataResponse")>  _
        Function GetData(ByVal value As Integer) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/GetData", ReplyAction:="http://tempuri.org/IService1/GetDataResponse")>  _
        Function GetDataAsync(ByVal value As Integer) As System.Threading.Tasks.Task(Of String)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction:="http://tempuri.org/IService1/GetDataUsingDataContractResponse")>  _
        Function GetDataUsingDataContract(ByVal composite As ServiceReference1.CompositeType) As ServiceReference1.CompositeType
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction:="http://tempuri.org/IService1/GetDataUsingDataContractResponse")>  _
        Function GetDataUsingDataContractAsync(ByVal composite As ServiceReference1.CompositeType) As System.Threading.Tasks.Task(Of ServiceReference1.CompositeType)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/listadoClientes", ReplyAction:="http://tempuri.org/IService1/listadoClientesResponse")>  _
        Function listadoClientes() As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/listadoClientes", ReplyAction:="http://tempuri.org/IService1/listadoClientesResponse")>  _
        Function listadoClientesAsync() As System.Threading.Tasks.Task(Of System.Data.DataSet)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/listadoPaises", ReplyAction:="http://tempuri.org/IService1/listadoPaisesResponse")>  _
        Function listadoPaises() As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/listadoPaises", ReplyAction:="http://tempuri.org/IService1/listadoPaisesResponse")>  _
        Function listadoPaisesAsync() As System.Threading.Tasks.Task(Of System.Data.DataSet)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/ClientesxPais", ReplyAction:="http://tempuri.org/IService1/ClientesxPaisResponse")>  _
        Function ClientesxPais(ByVal pais As String) As System.Data.DataSet
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/ClientesxPais", ReplyAction:="http://tempuri.org/IService1/ClientesxPaisResponse")>  _
        Function ClientesxPaisAsync(ByVal pais As String) As System.Threading.Tasks.Task(Of System.Data.DataSet)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IService1Channel
        Inherits ServiceReference1.IService1, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class Service1Client
        Inherits System.ServiceModel.ClientBase(Of ServiceReference1.IService1)
        Implements ServiceReference1.IService1
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function GetData(ByVal value As Integer) As String Implements ServiceReference1.IService1.GetData
            Return MyBase.Channel.GetData(value)
        End Function
        
        Public Function GetDataAsync(ByVal value As Integer) As System.Threading.Tasks.Task(Of String) Implements ServiceReference1.IService1.GetDataAsync
            Return MyBase.Channel.GetDataAsync(value)
        End Function
        
        Public Function GetDataUsingDataContract(ByVal composite As ServiceReference1.CompositeType) As ServiceReference1.CompositeType Implements ServiceReference1.IService1.GetDataUsingDataContract
            Return MyBase.Channel.GetDataUsingDataContract(composite)
        End Function
        
        Public Function GetDataUsingDataContractAsync(ByVal composite As ServiceReference1.CompositeType) As System.Threading.Tasks.Task(Of ServiceReference1.CompositeType) Implements ServiceReference1.IService1.GetDataUsingDataContractAsync
            Return MyBase.Channel.GetDataUsingDataContractAsync(composite)
        End Function
        
        Public Function listadoClientes() As System.Data.DataSet Implements ServiceReference1.IService1.listadoClientes
            Return MyBase.Channel.listadoClientes
        End Function
        
        Public Function listadoClientesAsync() As System.Threading.Tasks.Task(Of System.Data.DataSet) Implements ServiceReference1.IService1.listadoClientesAsync
            Return MyBase.Channel.listadoClientesAsync
        End Function
        
        Public Function listadoPaises() As System.Data.DataSet Implements ServiceReference1.IService1.listadoPaises
            Return MyBase.Channel.listadoPaises
        End Function
        
        Public Function listadoPaisesAsync() As System.Threading.Tasks.Task(Of System.Data.DataSet) Implements ServiceReference1.IService1.listadoPaisesAsync
            Return MyBase.Channel.listadoPaisesAsync
        End Function
        
        Public Function ClientesxPais(ByVal pais As String) As System.Data.DataSet Implements ServiceReference1.IService1.ClientesxPais
            Return MyBase.Channel.ClientesxPais(pais)
        End Function
        
        Public Function ClientesxPaisAsync(ByVal pais As String) As System.Threading.Tasks.Task(Of System.Data.DataSet) Implements ServiceReference1.IService1.ClientesxPaisAsync
            Return MyBase.Channel.ClientesxPaisAsync(pais)
        End Function
    End Class
End Namespace
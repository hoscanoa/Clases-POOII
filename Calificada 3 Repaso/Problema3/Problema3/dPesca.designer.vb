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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="PESCA")>  _
Partial Public Class dPescaDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Definiciones de métodos de extensibilidad"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertTB_BARCO(instance As TB_BARCO)
    End Sub
  Partial Private Sub UpdateTB_BARCO(instance As TB_BARCO)
    End Sub
  Partial Private Sub DeleteTB_BARCO(instance As TB_BARCO)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.Problema3.My.MySettings.Default.PESCAConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property TB_BARCO() As System.Data.Linq.Table(Of TB_BARCO)
		Get
			Return Me.GetTable(Of TB_BARCO)
		End Get
	End Property
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.SP_LISTARBARCO")>  _
	Public Function SP_LISTARBARCO() As ISingleResult(Of SP_LISTARBARCOResult)
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo))
		Return CType(result.ReturnValue,ISingleResult(Of SP_LISTARBARCOResult))
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.SP_LISTARTIPOBARCO")>  _
	Public Function SP_LISTARTIPOBARCO() As ISingleResult(Of SP_LISTARTIPOBARCOResult)
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo))
		Return CType(result.ReturnValue,ISingleResult(Of SP_LISTARTIPOBARCOResult))
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.SP_ULTIMOBARCO")>  _
	Public Function SP_ULTIMOBARCO() As ISingleResult(Of SP_ULTIMOBARCOResult)
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo))
		Return CType(result.ReturnValue,ISingleResult(Of SP_ULTIMOBARCOResult))
	End Function
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.TB_BARCO")>  _
Partial Public Class TB_BARCO
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _COD_BAR As String
	
	Private _NOM_BAR As String
	
	Private _FEC_COM As System.Nullable(Of Date)
	
	Private _TIP_BAR As String
	
	Private _CAP_BAR As System.Nullable(Of Integer)
	
    #Region "Definiciones de métodos de extensibilidad"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnCOD_BARChanging(value As String)
    End Sub
    Partial Private Sub OnCOD_BARChanged()
    End Sub
    Partial Private Sub OnNOM_BARChanging(value As String)
    End Sub
    Partial Private Sub OnNOM_BARChanged()
    End Sub
    Partial Private Sub OnFEC_COMChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnFEC_COMChanged()
    End Sub
    Partial Private Sub OnTIP_BARChanging(value As String)
    End Sub
    Partial Private Sub OnTIP_BARChanged()
    End Sub
    Partial Private Sub OnCAP_BARChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnCAP_BARChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_COD_BAR", DbType:="Char(5) NOT NULL", CanBeNull:=false, IsPrimaryKey:=true)>  _
	Public Property COD_BAR() As String
		Get
			Return Me._COD_BAR
		End Get
		Set
			If (String.Equals(Me._COD_BAR, value) = false) Then
				Me.OnCOD_BARChanging(value)
				Me.SendPropertyChanging
				Me._COD_BAR = value
				Me.SendPropertyChanged("COD_BAR")
				Me.OnCOD_BARChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NOM_BAR", DbType:="VarChar(100)")>  _
	Public Property NOM_BAR() As String
		Get
			Return Me._NOM_BAR
		End Get
		Set
			If (String.Equals(Me._NOM_BAR, value) = false) Then
				Me.OnNOM_BARChanging(value)
				Me.SendPropertyChanging
				Me._NOM_BAR = value
				Me.SendPropertyChanged("NOM_BAR")
				Me.OnNOM_BARChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FEC_COM", DbType:="DateTime")>  _
	Public Property FEC_COM() As System.Nullable(Of Date)
		Get
			Return Me._FEC_COM
		End Get
		Set
			If (Me._FEC_COM.Equals(value) = false) Then
				Me.OnFEC_COMChanging(value)
				Me.SendPropertyChanging
				Me._FEC_COM = value
				Me.SendPropertyChanged("FEC_COM")
				Me.OnFEC_COMChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TIP_BAR", DbType:="Char(2)")>  _
	Public Property TIP_BAR() As String
		Get
			Return Me._TIP_BAR
		End Get
		Set
			If (String.Equals(Me._TIP_BAR, value) = false) Then
				Me.OnTIP_BARChanging(value)
				Me.SendPropertyChanging
				Me._TIP_BAR = value
				Me.SendPropertyChanged("TIP_BAR")
				Me.OnTIP_BARChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CAP_BAR", DbType:="Int")>  _
	Public Property CAP_BAR() As System.Nullable(Of Integer)
		Get
			Return Me._CAP_BAR
		End Get
		Set
			If (Me._CAP_BAR.Equals(value) = false) Then
				Me.OnCAP_BARChanging(value)
				Me.SendPropertyChanging
				Me._CAP_BAR = value
				Me.SendPropertyChanged("CAP_BAR")
				Me.OnCAP_BARChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

Partial Public Class SP_LISTARBARCOResult
	
	Private _COD_BAR As String
	
	Private _NOM_BAR As String
	
	Private _FEC_COM As System.Nullable(Of Date)
	
	Private _TIP_BAR As String
	
	Private _CAP_BAR As System.Nullable(Of Integer)
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_COD_BAR", DbType:="Char(5) NOT NULL", CanBeNull:=false)>  _
	Public Property COD_BAR() As String
		Get
			Return Me._COD_BAR
		End Get
		Set
			If (String.Equals(Me._COD_BAR, value) = false) Then
				Me._COD_BAR = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NOM_BAR", DbType:="VarChar(100)")>  _
	Public Property NOM_BAR() As String
		Get
			Return Me._NOM_BAR
		End Get
		Set
			If (String.Equals(Me._NOM_BAR, value) = false) Then
				Me._NOM_BAR = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FEC_COM", DbType:="DateTime")>  _
	Public Property FEC_COM() As System.Nullable(Of Date)
		Get
			Return Me._FEC_COM
		End Get
		Set
			If (Me._FEC_COM.Equals(value) = false) Then
				Me._FEC_COM = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TIP_BAR", DbType:="Char(2)")>  _
	Public Property TIP_BAR() As String
		Get
			Return Me._TIP_BAR
		End Get
		Set
			If (String.Equals(Me._TIP_BAR, value) = false) Then
				Me._TIP_BAR = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CAP_BAR", DbType:="Int")>  _
	Public Property CAP_BAR() As System.Nullable(Of Integer)
		Get
			Return Me._CAP_BAR
		End Get
		Set
			If (Me._CAP_BAR.Equals(value) = false) Then
				Me._CAP_BAR = value
			End If
		End Set
	End Property
End Class

Partial Public Class SP_LISTARTIPOBARCOResult
	
	Private _TIP_BAR As String
	
	Private _NOM_TIP As String
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TIP_BAR", DbType:="Char(2) NOT NULL", CanBeNull:=false)>  _
	Public Property TIP_BAR() As String
		Get
			Return Me._TIP_BAR
		End Get
		Set
			If (String.Equals(Me._TIP_BAR, value) = false) Then
				Me._TIP_BAR = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NOM_TIP", DbType:="VarChar(100)")>  _
	Public Property NOM_TIP() As String
		Get
			Return Me._NOM_TIP
		End Get
		Set
			If (String.Equals(Me._NOM_TIP, value) = false) Then
				Me._NOM_TIP = value
			End If
		End Set
	End Property
End Class

Partial Public Class SP_ULTIMOBARCOResult
	
	Private _COD_BAR As String
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_COD_BAR", DbType:="Char(5) NOT NULL", CanBeNull:=false)>  _
	Public Property COD_BAR() As String
		Get
			Return Me._COD_BAR
		End Get
		Set
			If (String.Equals(Me._COD_BAR, value) = false) Then
				Me._COD_BAR = value
			End If
		End Set
	End Property
End Class

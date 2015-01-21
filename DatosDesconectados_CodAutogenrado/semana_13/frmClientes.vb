Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports vb = Microsoft.VisualBasic
Public Class frmClientes
    Dim objdao As New ClienteDAO
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call llenaclientes()
        Call LimpiarTextBox()
        AutogeneraCodigo()
    End Sub
    Sub AutogeneraCodigo()
        Dim ObjCli As New Cliente
        ObjCli.codigo = objdao.Autogenera_Codigo
        txtcodigo.Text = ObjCli.codigo
    End Sub
    Sub llenaclientes()
        dtg1.DataSource = objdao.listadoclientes.Tables("Clientes")
    End Sub
    Sub LimpiarTextBox()
        txtcliente.Clear()
        txtdireccion.Clear()
        txtRuc.Clear()
        txttelefono.Clear()
    End Sub
    Dim sw As Integer
    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        Dim objcli As New Cliente
        objcli.codigo = txtcodigo.Text
        objcli.nombres = txtcliente.Text
        objcli.direccion = txtdireccion.Text
        objcli.ruc = txtRuc.Text
        objcli.telefono = txttelefono.Text
        objdao.agregacliente(objcli)
        Call llenaclientes()
        Call LimpiarTextBox()
        xCod = txtcodigo.Text
        txtcodigo.Text = "C" + vb.Right(vb.Right(xCod, 4) + 10001, 4)
        tsNuevo.Enabled = True
    End Sub
    Private Sub ToolStripLabel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel5.Click
        objdao.actualizaclientes()
        Call llenaclientes()
    End Sub
    Dim xCod As String
    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click
        Try
            Dim objcli As New Cliente
            objcli.codigo = InputBox("Ingrese CODIGO:")
            txtcodigo.Text = objdao.buscacliente(objcli).Item("Cli_codigo")
            txtcliente.Text = objdao.buscacliente(objcli).Item("Cli_nombre")
            txttelefono.Text = objdao.buscacliente(objcli).Item("Cli_telefono")
            txtRuc.Text = objdao.buscacliente(objcli).Item("Cli_Ruc")
            txtdireccion.Text = objdao.buscacliente(objcli).Item("Cli_direccion")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel3.Click
        Dim objcli As New Cliente
        objcli.codigo = txtcodigo.Text
        objcli.nombres = txtcliente.Text
        objcli.direccion = txtdireccion.Text
        objcli.ruc = txtRuc.Text
        objcli.telefono = txttelefono.Text
        objdao.modificacliente(objcli)
        Call llenaclientes()
    End Sub

    Private Sub ToolStripLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel4.Click
        Dim codigo As String = InputBox("Ingrese codigo cliente a eliminar ", "")
        Dim objcli As New Cliente
        objcli.codigo = codigo
        objdao.eliminacliente(objcli)
    End Sub

    Private Sub ToolStripLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel6.Click
        Close()
    End Sub
    Private Sub dtg1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtg1.CurrentCellChanged
        Try
            txtcodigo.Text = dtg1.CurrentRow.Cells(0).Value
            txtcliente.Text = dtg1.CurrentRow.Cells(1).Value
            txttelefono.Text = dtg1.CurrentRow.Cells(2).Value
            txtRuc.Text = dtg1.CurrentRow.Cells(3).Value
            txtdireccion.Text = dtg1.CurrentRow.Cells(4).Value
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tsNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNuevo.Click
        Call LimpiarTextBox()
        If xCod = "" Then
            xCod = objdao.Autogenera_Codigo
        End If
        txtcodigo.Text = "C" + vb.Right(vb.Right(xCod, 4) + 10001, 4).ToString
    End Sub
End Class

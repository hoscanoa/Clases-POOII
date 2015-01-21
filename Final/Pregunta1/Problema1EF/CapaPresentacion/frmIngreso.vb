Imports CapaNegocios
Public Class frmIngreso

    Private Sub frmIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call autogenera()
        Call llenaCombo()
        Call llenaclientes()

    End Sub

    Private Sub llenaclientes()
        Dim capaNegocios As New ClienteCN
        dgClientes.DataSource = capaNegocios.listaClientes.Tables("CLIENTES")
        lblTotal.Text = capaNegocios.listaClientes.Tables("CLIENTES").Rows.Count
    End Sub

    Private Sub llenaCombo()
        Dim capaNegocios As New DistritoCN
        cboDistrito.DataSource = capaNegocios.listaDistritos.Tables("DISTRITOS")
        cboDistrito.DisplayMember = "DESCRIP_DIST"
        cboDistrito.ValueMember = "COD_DIST"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub autogenera()

    End Sub

End Class
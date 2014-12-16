Public Class frmEliminaCliente
    Dim objNeg As New ClienteCN
    Dim objCli As New Cliente

    Private Sub frmEliminaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboPais.DataSource = objNeg.listadoPais
        cboPais.DisplayMember = "nombrePais"
        cboPais.ValueMember = "idPais"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        objCli.Codigo = txtCodigo.Text
        txtCliente.Text = objNeg.buscaCliente(objCli).Rows(0).Item("nomCliente")
        txtDireccion.Text = objNeg.buscaCliente(objCli).Rows(0).Item("dirCliente")
        cboPais.SelectedValue = objNeg.buscaCliente(objCli).Rows(0).Item("idPais")
        txtTelefono.Text = objNeg.buscaCliente(objCli).Rows(0).Item("fonoCliente")
    End Sub


    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim r As Integer
        r = MessageBox.Show("Esta seguro de eliminar a : " & txtCliente.Text & vbNewLine & "con Codigo: " & txtCodigo.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = 6 Then
            objCli.Codigo = txtCodigo.Text
            objNeg.EliminaCliente(objCli)
        End If
    End Sub
End Class
Public Class Form1
    Dim dp As New dPescaDataContext

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call muestraBarcos()
        Call muestraTipoBarco()
        Call generaCodigo()
    End Sub

    Private Sub muestraBarcos()
        dgBarcos.DataSource = dp.SP_LISTARBARCO
    End Sub

    Private Sub muestraTipoBarco()
        cboTipoBarco.DataSource = dp.SP_LISTARTIPOBARCO
        cboTipoBarco.DisplayMember = "TIP_BAR"
        cboTipoBarco.ValueMember = "TIP_BAR"
    End Sub

    Private Sub generaCodigo()
        lblCodigo.Text = (dp.SP_ULTIMOBARCO.First.COD_BAR + 1).ToString("00000")
    End Sub

    Sub limpiarControles()
        Dim misObjetos As Control
        For Each misObjetos In Me.Controls
            If TypeOf misObjetos Is System.Windows.Forms.TextBox Then
                misObjetos.Text = ""
            End If
        Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call generaCodigo()
        Dim objBarco As New TB_BARCO
        objBarco.COD_BAR = lblCodigo.Text
        objBarco.NOM_BAR = txtNombre.Text
        objBarco.FEC_COM = txtFechaCompra.Value
        objBarco.TIP_BAR = cboTipoBarco.SelectedValue
        objBarco.CAP_BAR = CInt(txtCapacidad.Text)

        dp.TB_BARCO.InsertOnSubmit(objBarco)
        dp.SubmitChanges()

        Call muestraBarcos()
        Call generaCodigo()
        Call limpiarControles()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim barco = From b In dp.TB_BARCO
                    Where b.COD_BAR = lblCodigo.Text

        Dim objBarco As New TB_BARCO
        objBarco = barco.First
        objBarco.COD_BAR = lblCodigo.Text
        objBarco.NOM_BAR = txtNombre.Text
        objBarco.FEC_COM = txtFechaCompra.Value
        objBarco.TIP_BAR = cboTipoBarco.SelectedValue
        objBarco.CAP_BAR = CInt(txtCapacidad.Text)

        dp.SubmitChanges()

        Call muestraBarcos()
        Call generaCodigo()
        Call limpiarControles()
    End Sub

    Private Sub dgBarcos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBarcos.CellContentClick
        With dgBarcos.CurrentRow
            lblCodigo.Text = .Cells(0).Value
            txtNombre.Text = .Cells(1).Value
            txtFechaCompra.Value = .Cells(2).Value
            cboTipoBarco.SelectedValue = .Cells(3).Value
            txtCapacidad.Text = .Cells(4).Value
        End With

    End Sub

    

End Class

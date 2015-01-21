Imports vb = Microsoft.VisualBasic
Public Class Form1
    Dim objDAO As New InquilinoDAO

    Dim xCod As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaGrid()
        xCod = txtCodigo.Text
        autogenera()
    End Sub

    Private Sub llenaGrid()
        dgvLista.DataSource = objDAO.listarInquilinos.Tables("Inquilinos")
        lblTotal.Text = dgvLista.Rows.Count - 1
    End Sub

    Private Sub autogenera()
        If (txtCodigo.Text = "") Then
            txtCodigo.Text = objDAO.autogenera
        Else
            ' Dim c As String = dgvLista.Rows(dgvLista.Rows.Count - 1).Cells(0).Value.ToString
            txtCodigo.Text = "USU" & vb.Right(vb.Right(xCod, 3) + 1001, 3)
        End If
    End Sub



    Private Sub btnRegistra_Click(sender As Object, e As EventArgs) Handles btnRegistra.Click
        Dim obj As New Inquilino
        obj.codigo = txtCodigo.Text
        obj.nombre = txtNombres.Text
        obj.apellido = txtApellidos.Text
        obj.basico = CDbl(txtBasico.Text)
        obj.civil = txtCivil.Text
        obj.lugar = txtLugar.Text

        Dim r As Integer = objDAO.agregarInqulino(obj)
        If r > 0 Then
            xCod = txtCodigo.Text
            lblTotal.Text = dgvLista.Rows.Count - 1
            limpiar()
            MessageBox.Show("Se agregó correctamente al inquilino", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No se pudo agregar al inquilino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim obj As New Inquilino
        obj.codigo = txtCodigo.Text
        obj.nombre = txtNombres.Text
        obj.apellido = txtApellidos.Text
        obj.basico = CDbl(txtBasico.Text)
        obj.civil = txtCivil.Text
        obj.lugar = txtLugar.Text

        Dim r As Integer = objDAO.modificarInqulino(obj)
        If r > 0 Then
            MessageBox.Show("Se modificó correctamente al inquilino", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No se pudo modificar al inquilino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        limpiar()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim r As Integer = objDAO.grabar
        If r > 0 Then
            MessageBox.Show("Se grabó correctamente los datos en BD", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No se grabó los datos en BD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub limpiar()
        txtNombres.Clear()
        txtApellidos.Clear()
        txtBasico.Clear()
        txtCivil.Clear()
        txtLugar.Clear()
        autogenera()
    End Sub

    Private Sub dgvLista_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLista.CellClick
        With dgvLista.CurrentRow
            txtCodigo.Text = .Cells(0).Value.ToString
            txtNombres.Text = .Cells(1).Value.ToString
            txtApellidos.Text = .Cells(2).Value.ToString
            txtBasico.Text = .Cells(3).Value.ToString
            txtCivil.Text = .Cells(4).Value.ToString
            txtLugar.Text = .Cells(5).Value.ToString
        End With
    End Sub
End Class

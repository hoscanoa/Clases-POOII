Public Class Form1
    Dim dNegocios As New dNegociosDataContext
 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call muestraEmpelados()
        Call muestraDistritos()
        Call muestraCargos()
        Call generaCodigo()
    End Sub

    Private Sub muestraEmpelados()
        dgEmpleado.DataSource = dNegocios.SP_LISTAEMPELADOS

    End Sub

    Private Sub muestraDistritos()
        cboDistrito.DataSource = dNegocios.SP_LISTADISTRITOS
        cboDistrito.DisplayMember = "nomDistrito"
        cboDistrito.ValueMember = "idDistrito"
    End Sub

    Private Sub muestraCargos()
        cboCargo.DataSource = dNegocios.SP_LISTACARGOS
        cboCargo.DisplayMember = "desCargo"
        cboCargo.ValueMember = "idCargo"
    End Sub

    Private Sub generaCodigo()
        lblCodigo.Text = dNegocios.SP_ULTIMOEMPLEADO.First.IdEmpleado + 1
    End Sub

    Sub limpiarControles()
    Dim misObjetos As Control
        For Each misObjetos In Me.Controls
            If TypeOf misObjetos Is System.Windows.Forms.TextBox Then
                misObjetos.Text = ""
            End If
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Call generaCodigo()
        Dim objEmp As New empleados
        objEmp.IdEmpleado = lblCodigo.Text
        objEmp.ApeEmpleado = txtApellido.Text
        objEmp.NomEmpleado = txtNombre.Text
        objEmp.FecNac = dtpFechaNac.Value
        objEmp.DirEmpleado = txtDireccion.Text
        objEmp.idDistrito = cboDistrito.SelectedValue
        objEmp.FecContrata = dtpFechaCon.Value
        objEmp.idCargo = cboCargo.SelectedValue
        dNegocios.empleados.InsertOnSubmit(objEmp)
        dNegocios.SubmitChanges()
        Call muestraEmpelados()
        Call generaCodigo()
        Call limpiarControles()
    End Sub

    Private Sub dgEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEmpleado.CellContentClick
        lblCodigo.Text = dgEmpleado.CurrentRow.Cells(0).Value
        txtApellido.Text = dgEmpleado.CurrentRow.Cells(1).Value
        txtNombre.Text = dgEmpleado.CurrentRow.Cells(2).Value
        dtpFechaNac.Value = dgEmpleado.CurrentRow.Cells(3).Value
        txtDireccion.Text = dgEmpleado.CurrentRow.Cells(4).Value
        cboDistrito.SelectedValue = dgEmpleado.CurrentRow.Cells(5).Value
        cboCargo.SelectedValue = dgEmpleado.CurrentRow.Cells(6).Value
        dtpFechaCon.Value = dgEmpleado.CurrentRow.Cells(7).Value
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim empleado = From emp In dNegocios.empleados Where emp.IdEmpleado = lblCodigo.Text
        Dim objEmp As New empleados
        objEmp = empleado.First
        objEmp.IdEmpleado = lblCodigo.Text
        objEmp.ApeEmpleado = txtApellido.Text
        objEmp.NomEmpleado = txtNombre.Text
        objEmp.FecNac = dtpFechaNac.Value
        objEmp.DirEmpleado = txtDireccion.Text
        objEmp.idDistrito = cboDistrito.SelectedValue
        objEmp.FecContrata = dtpFechaCon.Value
        objEmp.idCargo = cboCargo.SelectedValue
        dNegocios.SubmitChanges()
        Call muestraEmpelados()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim empleado = From emp In dNegocios.empleados Where emp.IdEmpleado = lblCodigo.Text
        dNegocios.empleados.DeleteOnSubmit(empleado.First)
        dNegocios.SubmitChanges()
        Call muestraEmpelados()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class

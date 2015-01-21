Imports System.Data.EntityClient
Imports System.Data.SqlClient
Public Class Form1
    Dim db As New VENTAS2014Entities1
    Dim cn As New SqlConnection("Server=.;DataBase=Ventas2014;uid=sa;pwd=sql")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FormatoLista()
        Call Autogenera_Codigo()
        Call LlenaLista()
        Call LlenaCombo()
    End Sub

    Private Sub FormatoLista()
        With lv
            .View = View.Details
            .GridLines = True
            .Columns.Add("COD_CLI", 100)
            .Columns.Add("NOMBRES", 100)
            .Columns.Add("APE_PATER_CLI", 100)
            .Columns.Add("APE_MATER_CLI", 100)
            .Columns.Add("DIRECCION_CLI", 100)
            .Columns.Add("TELEFONO_CLI", 100)
            .Columns.Add("COD_DIST", 100)
            .Columns.Add("CORREO_E", 100)
        End With
    End Sub

    Private Sub LlenaLista()
        Using cn As New EntityConnection("Name=Ventas2014Entities1")
            Dim cmd As New EntityCommand("Select VALUE cli from Ventas2014Entities1.cliente as cli", cn)
            cn.Open()
            Dim dr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
            While dr.Read
                Dim it As New ListViewItem(dr("COD_CLI").ToString)
                it.SubItems.Add(dr("NOMBRES"))
                it.SubItems.Add(dr("APE_PATER_CLI"))
                it.SubItems.Add(dr("APE_MATER_CLI"))
                it.SubItems.Add(dr("DIRECCION_CLI"))
                it.SubItems.Add(dr("TELEFONO_CLI"))
                it.SubItems.Add(dr("COD_DIST"))
                it.SubItems.Add(dr("CORREO_E"))
                lv.Items.Add(it)
            End While
            lblCantidad.Text = lv.Items.Count
            dr.Close()
        End Using
    End Sub

    Private Sub LlenaCombo()
        cboDistrito.DataSource = db.DISTRITO.ToList
        cboDistrito.DisplayMember = "DESCRIP_DIST"
        cboDistrito.ValueMember = "COD_DIST"
    End Sub


    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Dim objPro = db.CLIENTE.Find(txtCodigo.Text)
        If objPro Is Nothing Then
            objPro = New CLIENTE
            Call Autogenera_Codigo()
            objPro.COD_CLI = txtCodigo.Text
            objPro.NOMBRES = txtNombre.Text
            objPro.APE_PATER_CLI = txtApPaterno.Text
            objPro.APE_MATER_CLI = txtAPMaterno.Text
            objPro.DIRECCION_CLI = txtDireccion.Text
            objPro.TELEFONO_CLI = txtTelefono.Text
            objPro.COD_DIST = cboDistrito.SelectedValue
            objPro.CORREO_E = txtCorreo.Text
            db.CLIENTE.Add(objPro)
            db.SaveChanges()
            Call LlenaLista()
        Else
            MessageBox.Show("Codigo Registrado!!!")
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim objPro = db.CLIENTE.Find(txtCodigo.Text)
        If objPro Is Nothing Then
            MessageBox.Show("NO EXISTE CODIGO!!!!")
        Else
            objPro.COD_CLI = txtCodigo.Text
            objPro.NOMBRES = txtNombre.Text
            objPro.APE_PATER_CLI = txtApPaterno.Text
            objPro.APE_MATER_CLI = txtAPMaterno.Text
            objPro.DIRECCION_CLI = txtDireccion.Text
            objPro.TELEFONO_CLI = txtTelefono.Text
            objPro.COD_DIST = cboDistrito.SelectedValue
            objPro.CORREO_E = txtCorreo.Text
            db.SaveChanges()
            Call LlenaLista()
        End If
    End Sub

    Private Sub Autogenera_Codigo()
        cn.Open()
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "sp_generaCodigo"
            With cmd.Parameters
                .Add("@Cod", SqlDbType.Char, 6).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            Dim NewCodigo As String
            NewCodigo = cmd.Parameters(0).Value.ToString
            cn.Close()
            txtCodigo.Text = NewCodigo
        End Using
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
        Try
            Call ItemSeleccionado()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ItemSeleccionado()
        Dim i As ListViewItem
        i = lv.SelectedItems(0)
        txtCodigo.Text = i.Text
        txtNombre.Text = i.SubItems.Item(1).Text
        txtApPaterno.Text = i.SubItems.Item(2).Text
        txtAPMaterno.Text = i.SubItems.Item(3).Text
        txtDireccion.Text = i.SubItems.Item(4).Text
        txtTelefono.Text = i.SubItems.Item(5).Text
        cboDistrito.SelectedValue = i.SubItems.Item(6).Text
        txtCorreo.Text = i.SubItems.Item(7).Text
    End Sub

End Class

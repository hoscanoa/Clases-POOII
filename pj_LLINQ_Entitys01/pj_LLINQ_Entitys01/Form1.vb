Imports System.Data.SqlClient
Imports System.Data.EntityClient
Public Class Form1

    Dim cn As New SqlConnection("Server=.;DataBase=Ventas2014;uid=sa;pwd=sql")
    Dim db As New VENTAS2014Entities

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatoLista()
        llenaLista()
        Call Autogenera_codigo()
    End Sub


    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim objPro = db.PRODUCTO.Find(txtCodigo.Text)
        If objPro Is Nothing Then
            objPro = New PRODUCTO

            objPro.COD_PRO = txtCodigo.Text
            objPro.DESCRIP_PRO = txtDescripcion.Text
            objPro.PRECIO_PRO = txtPrecio.Text
            objPro.STOCK_ACT_PRO = txtStockA.Text
            objPro.STOCK_MIN_PRO = txtStockM.Text
            db.PRODUCTO.Add(objPro)
            db.SaveChanges()
            Call llenaLista()

        Else
            MessageBox.Show("Codigo Registrado..!!!")

        End If
    End Sub

    Private Sub formatoLista()
        With lvListar
            .View = View.Details
            .GridLines = True
            .Columns.Add("Codigo", 100)
            .Columns.Add("Descripcion", 250)
            .Columns.Add("Precio", 150)
            .Columns.Add("Stock_Act", 100)
            .Columns.Add("Stock_Min", 100)
        End With
    End Sub

    Private Sub lvListar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvListar.SelectedIndexChanged
        Try
            Call ItemSeleccionado()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenaLista()
        lvListar.Items.Clear()
        Using cn As New EntityConnection("Name=VENTAS2014Entities")
            Dim cmd As New EntityCommand("Select value Prod from VENTAS2014Entities.producto as prod", cn)
            cn.Open()
            Dim dr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
            While dr.Read
                Dim it As New ListViewItem(dr("cod_pro").ToString)
                it.SubItems.Add(dr("Descrip_pro"))
                it.SubItems.Add(dr("Precio_pro"))
                it.SubItems.Add(dr("Stock_Act_pro"))
                it.SubItems.Add(dr("Stock_Min_pro"))
                lvListar.Items.Add(it)
            End While
            dr.Close()
        End Using
    End Sub

    Private Sub ItemSeleccionado()
        Dim i As ListViewItem
        i = lvListar.SelectedItems(0)
        txtCodigo.Text = i.Text
        txtDescripcion.Text = i.SubItems.Item(1).Text
        txtPrecio.Text = i.SubItems(2).Text
        txtPrecio.Text = i.SubItems(3).Text
        txtStockA.Text = i.SubItems(4).Text
        txtStockM.Text = i.SubItems(5).Text

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim objPro = db.PRODUCTO.Find(txtCodigo.Text)
        If objPro Is Nothing Then
            MessageBox.Show("No existe codigo..!!")
        Else
            objPro.COD_PRO = txtCodigo.Text
            objPro.DESCRIP_PRO = txtDescripcion.Text
            objPro.PRECIO_PRO = txtPrecio.Text
            objPro.STOCK_ACT_PRO = txtStockA.Text
            objPro.STOCK_MIN_PRO = txtStockM.Text
            db.SaveChanges()
            Call llenaLista()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiarControles()
    End Sub

    Private Sub limpiarControles()
        Dim misObjetos As Control
        For Each misObjetos In Me.Controls
            If TypeOf misObjetos Is System.Windows.Forms.TextBox Then
                misObjetos.Text = ""
            End If
        Next
        Call Autogenera_codigo()
    End Sub

    Private Sub Autogenera_codigo()
        cn.Open()
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "sp_generaCodigo"
            With cmd.Parameters
                .Add("@Cod", SqlDbType.Char, 4).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            Dim NewCodigo As String
            NewCodigo = cmd.Parameters(0).Value.ToString
            cn.Close()
            txtCodigo.Text = NewCodigo

        End Using
    End Sub

End Class

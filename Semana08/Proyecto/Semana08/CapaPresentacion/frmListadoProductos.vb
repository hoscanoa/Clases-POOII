Imports System.IO
Imports ce = CapaEntidad
Imports CapaNegocios
Imports CapaDatos

Public Class frmListadoProductos
    Dim objProductoCN As New ProductoCN
    Dim op As New OpenFileDialog

    Private Sub frmListadoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generaCodigo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objProducto As New ce.ProductoCE
        objProducto.codigo = objProductoCN.Autogenera_Codigo
        objProducto.descripcion = txtDescripcion.Text
        objProducto.precio = CDbl(txtPrecio.Text)
        objProducto.stockA = CInt(txtStockA.Text)
        objProducto.stockM = CInt(txtStockM.Text)
        'Enviar la foto a la tabla 
        Dim fs As New FileStream(op.FileName, FileMode.OpenOrCreate, FileAccess.Read)
        Dim datos(fs.Length) As Byte
        'Serializando
        fs.Read(datos, 0, fs.Length)
        objProducto.foto = datos
        objProductoCN.nuevoProductoF(objProducto)
        limpiar()
        MessageBox.Show("Producto registrado correctamente...!!", "")

    End Sub

    

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pbFoto.SizeMode = PictureBoxSizeMode.StretchImage
        op.Filter = "Archivo de Imagen JPG|*.jpg|Archivo de Imagen PNG|*.png"
        If op.ShowDialog = Windows.Forms.DialogResult.OK Then
            pbFoto.Image = Image.FromFile(op.FileName)
        End If
    End Sub

    Private Sub generaCodigo()
        txtCodigo.Text = objProductoCN.Autogenera_Codigo()
    End Sub

    Private Sub limpiar()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtPrecio.Clear()
        txtStockA.Clear()
        txtStockM.Clear()
        pbFoto.Image = Nothing
        generaCodigo()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        pbFoto.SizeMode = PictureBoxSizeMode.StretchImage
        'Obtener el código de la caja de texto 
        Dim objproductoCE As New ce.ProductoCE
        objproductoCE.codigo = txtCodigo.Text
        txtDescripcion.Text = objProductoCN.buscaProductosF(objproductoCE).Tables("Productos").Rows(0).Item(1)
        txtPrecio.Text = objProductoCN.buscaProductosF(objproductoCE).Tables("Productos").Rows(0).Item(2)
        txtStockA.Text = objProductoCN.buscaProductosF(objproductoCE).Tables("Productos").Rows(0).Item(3)
        txtStockM.Text = objProductoCN.buscaProductosF(objproductoCE).Tables("Productos").Rows(0).Item(4)
        'Convertir el binario en imagen 
        Dim ms As New MemoryStream(
            CType(objProductoCN.buscaProductosF(objproductoCE).Tables("Productos").Rows(0).Item(5), Byte()))
        Dim imagen As Image = Image.FromStream(ms)
        pbFoto.Image = imagen
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub
End Class
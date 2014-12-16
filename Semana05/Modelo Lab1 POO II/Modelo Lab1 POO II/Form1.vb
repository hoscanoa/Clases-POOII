Public Class Form1

   
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaClientes()
    End Sub

    Private Sub llenaClientes()

        Dim objNegClientes As New NegClientes

        cboCliente.DataSource = objNegClientes.ListaClientes().Tables(0)
        cboCliente.ValueMember = "Codigo"
        cboCliente.DisplayMember = "Nombre"

    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged
        LlenaBoletas()
    End Sub

    Private Sub LlenaBoletas()
        Dim objNegBoletas As New NegBoleta
        Dim c As New EntCliente
        c.codigo = cboCliente.SelectedValue.ToString
        cboFacturas.DataSource = objNegBoletas.ListaBoletas(c).Tables(0)
        cboFacturas.ValueMember = "Codigo"
        cboFacturas.DisplayMember = "Nombre"
    End Sub

    Private Sub btbListar_Click(sender As Object, e As EventArgs) Handles btbListar.Click
        Dim objNegBoletas As New NegBoleta
        Dim b As New EntBoleta
        b.codigo = cboFacturas.SelectedValue.ToString
        dgDetalle.DataSource = objNegBoletas.ListaDetalle(b).Tables(0)
    End Sub

  
End Class

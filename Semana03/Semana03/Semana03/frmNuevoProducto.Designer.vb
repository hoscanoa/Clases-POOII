<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoProducto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.txtUnidadesEnExistencia = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCantidaxUnidad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.txtPrecioxUnidad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnidadesEnPedido = New System.Windows.Forms.TextBox()
        Me.txtEnPedido = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(390, 153)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(213, 71)
        Me.btnRegistrar.TabIndex = 17
        Me.btnRegistrar.Text = "REGISTRAR"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'cboProveedor
        '
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(160, 83)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(151, 21)
        Me.cboProveedor.TabIndex = 16
        '
        'txtUnidadesEnExistencia
        '
        Me.txtUnidadesEnExistencia.Location = New System.Drawing.Point(160, 178)
        Me.txtUnidadesEnExistencia.Name = "txtUnidadesEnExistencia"
        Me.txtUnidadesEnExistencia.Size = New System.Drawing.Size(151, 20)
        Me.txtUnidadesEnExistencia.TabIndex = 12
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(160, 56)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(443, 20)
        Me.txtNombre.TabIndex = 13
        '
        'txtCantidaxUnidad
        '
        Me.txtCantidaxUnidad.Location = New System.Drawing.Point(160, 118)
        Me.txtCantidaxUnidad.Name = "txtCantidaxUnidad"
        Me.txtCantidaxUnidad.Size = New System.Drawing.Size(151, 20)
        Me.txtCantidaxUnidad.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "CANTIDAD X UNIDAD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(79, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "PROVEEDOR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "NOMBRE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(137, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 29)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "REGISTRO DE PRODUCTOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "UNIDADES EN EXISTENCIA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(359, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "CATEGORIA"
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(434, 83)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(169, 21)
        Me.cboCategoria.TabIndex = 16
        '
        'txtPrecioxUnidad
        '
        Me.txtPrecioxUnidad.Location = New System.Drawing.Point(160, 146)
        Me.txtPrecioxUnidad.Name = "txtPrecioxUnidad"
        Me.txtPrecioxUnidad.Size = New System.Drawing.Size(151, 20)
        Me.txtPrecioxUnidad.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "PRECIO X UNIDAD"
        '
        'txtUnidadesEnPedido
        '
        Me.txtUnidadesEnPedido.Location = New System.Drawing.Point(160, 204)
        Me.txtUnidadesEnPedido.Name = "txtUnidadesEnPedido"
        Me.txtUnidadesEnPedido.Size = New System.Drawing.Size(151, 20)
        Me.txtUnidadesEnPedido.TabIndex = 12
        '
        'txtEnPedido
        '
        Me.txtEnPedido.AutoSize = True
        Me.txtEnPedido.Location = New System.Drawing.Point(29, 211)
        Me.txtEnPedido.Name = "txtEnPedido"
        Me.txtEnPedido.Size = New System.Drawing.Size(125, 13)
        Me.txtEnPedido.TabIndex = 18
        Me.txtEnPedido.Text = "UNIDADES EN PEDIDO"
        '
        'frmNuevoProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 235)
        Me.Controls.Add(Me.txtPrecioxUnidad)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEnPedido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.cboCategoria)
        Me.Controls.Add(Me.cboProveedor)
        Me.Controls.Add(Me.txtUnidadesEnPedido)
        Me.Controls.Add(Me.txtUnidadesEnExistencia)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCantidaxUnidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmNuevoProducto"
        Me.Text = "frmNuevoProducto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents cboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents txtUnidadesEnExistencia As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidaxUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents txtPrecioxUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUnidadesEnPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtEnPedido As System.Windows.Forms.Label
End Class

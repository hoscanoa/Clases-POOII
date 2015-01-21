Imports System.Data.EntityClient
Imports System.Data.SqlClient

Public Class Form3

    Dim db As New Negocios2014Entities

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = db.clientes.ToList
        ComboBox1.DataSource = db.paises.ToList
        ComboBox1.DisplayMember = "NombrePais"
        ComboBox1.ValueMember = "IdPais"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim datos As New ArrayList
        Dim cn As New EntityConnection("Name=Negocios2014Entities")
        Dim cmd As New EntityCommand("Select VALUE cli from Negocios2014Entities.clientes as cli where cli.idPais=@cod", cn)
        With cmd.Parameters
            .Add("cod", DbType.String).Value = ComboBox1.SelectedValue
        End With
        cn.Open()
        Dim dr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
        DataGridView1.DataSource = Nothing
        Do While dr.Read
            Dim ObjCliente As New clientes
            ObjCliente.IdCliente = dr.GetString(0)
            ObjCliente.NomCliente = dr.GetString(1)
            ObjCliente.DirCliente = dr.GetString(2)
            ObjCliente.idpais = dr.GetString(3)
            ObjCliente.fonoCliente = dr.GetString(4)
            datos.Add(ObjCliente)
        Loop
        DataGridView1.DataSource = datos
        dr.Close()
        cn.Close()
    End Sub
End Class
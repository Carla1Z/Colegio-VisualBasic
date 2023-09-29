Imports System.Data.SqlClient

Public Class Usuarios
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panelRegistro.Visible = False
        Mostrar()
    End Sub

    Private Sub picAgregar_Click(sender As Object, e As EventArgs) Handles picAgregar.Click
        panelRegistro.Visible = True

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@Nombres", txtNombres.Text)
            cmd.Parameters.AddWithValue("@Login", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            Mostrar()
            panelRegistro.Visible = False
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Sub Mostrar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_usuario", conexion)
            da.Fill(dt)
            dataListado.DataSource = dt
            cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub dataListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellContentClick

    End Sub

    Private Sub dataListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellDoubleClick
        Try
            panelRegistro.Visible = True
            btnGuardar.Visible = False
            btnGuardarCambios.Visible = True
            txtNombres.Text = dataListado.SelectedCells.Item(2).Value
            txtUsuario.Text = dataListado.SelectedCells.Item(3).Value
            txtPassword.Text = dataListado.SelectedCells.Item(4).Value
            lblIdUsuario.Text = dataListado.SelectedCells.Item(1).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardarCambios_Click(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@IdUsuario", lblIdUsuario.Text)
            cmd.Parameters.AddWithValue("@Nombres", txtNombres.Text)
            cmd.Parameters.AddWithValue("@Login", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            Mostrar()
            panelRegistro.Visible = False
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub dataListado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellClick
        If e.ColumnIndex = Me.dataListado.Columns.Item("Eli").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("¿Realmente desea eliminar este Usuario?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                Try
                    Dim cmd As New SqlCommand
                    abrir()
                    cmd = New SqlCommand("eliminar_usuario", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@IdUsuario", dataListado.SelectedCells.Item(1).Value)
                    cmd.ExecuteNonQuery()
                    cerrar()
                    Mostrar()
                Catch ex As Exception : MsgBox(ex.Message)

                End Try
            Else
                MessageBox.Show("Cancelando eliminacion de registros", "Eliminando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
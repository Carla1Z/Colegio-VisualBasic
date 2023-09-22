Public Class Usuarios
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        panelRegistro.Visible = False


    End Sub

    Private Sub picAgregar_Click(sender As Object, e As EventArgs) Handles picAgregar.Click
        panelRegistro.Visible = True

    End Sub
End Class
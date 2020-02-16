Public Class Register

#Region "variaveis"


#End Region


#Region "Botão de cancelar"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Finalize()

    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Todos os campos devem estar preenchidos", MsgBoxStyle.OkOnly)
        Else


        End If

    End Sub
#Region "Botão de sair"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Application.Exit()
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.Crimson
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.Transparent
    End Sub
#End Region
End Class
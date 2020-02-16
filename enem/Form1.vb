Imports System
Imports System.IO
Imports System.Net
Imports System.FtpStyleUriParser

Public Class Form1
#Region "Variaveis"
    Dim mp As Integer = 0

#End Region

#Region "butão de sair" 'Aqui estão todas os codigos sobre o butão de finalizar'

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

#Region "Butão para ocultar a senha" 'Aqui oculta todas as senhas'
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then
        Else
            If mp = 0 Then
                mp = 1
                TextBox2.PasswordChar = ""
                Button4.Text = "#"
            ElseIf mp = 1 Then
                mp = 0
                TextBox2.PasswordChar = "#"
                Button4.Text = "Y"
            End If
        End If
    End Sub
#End Region

#Region "Botão de login"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ldf As String = TextBox1.Text
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("O campo está vazio", MsgBoxStyle.OkOnly)
        ElseIf TextBox2.TextLength < 4 Then
            MsgBox("Precisa ser maior que 4 digitos a senha", MsgBoxStyle.OkOnly)
        Else
            Dim Uls As New Net.WebClient()
            Uls.DownloadFile("http://chattenata.xp3.biz/users/" & TextBox1.Text & "/pass.cag", "C:/temp\ENE\pass\pass.cag")
            Try
                FileSystem.Rename("C:/temp\ENE\pass\pass.cag", "C:/temp\ENE\pass\pass.txt")
                Dim usl As New StreamReader("C:/temp\ENE\pass\pass.txt")
                Dim lsu As String
                lsu = usl.ReadToEnd
                If lsu = TextBox2.Text Then
                    MsgBox("Você está logado", MsgBoxStyle.OkOnly)
                    usl.Close()
                    FileSystem.Kill("C:/temp\ENE\pass\pass.txt")
                Else
                    MsgBox("As senhas não se coencidem", MsgBoxStyle.OkOnly)
                    usl.Close()
                    FileSystem.Kill("C:/temp\ENE\pass\pass.txt")
                End If
            Catch
                MsgBox("Esse usuario não existe", MsgBoxStyle.OkOnly)
            End Try
        End If

    End Sub
#End Region

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Register.Show()
        Finalize()
    End Sub
End Class

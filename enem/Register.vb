Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Text
Public Class Register

#Region "variaveis"
    Dim leraf As IO.StreamReader
    Dim codigo As Integer = 0
    Dim cont As Integer = 0
#End Region


#Region "Botão de cancelar"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Finalize()

    End Sub
#End Region

#Region "Area de register"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Todos os campos devem estar preenchidos", MsgBoxStyle.OkOnly)
        Else

            Dim da2 As New System.Net.WebClient()
            da2.DownloadFile("http://chattenata.xp3.biz/" & (687 * 475) & "\afe.cag", "C:\Temp\ENE\webmail\afe.cag")
            Dim da3 As New System.Net.WebClient()
            da3.DownloadFile("http://chattenata.xp3.biz/" & (687 * 475) & "\afs.cag", "C:\Temp\ENE\webmail\afs.cag")
            da2.Dispose()
            da3.Dispose()

            FileSystem.Rename("C:\Temp\ENE\webmail\afs.cag", "C:\Temp\ENE\webmail\afs.txt")
            FileSystem.Rename("C:\Temp\ENE\webmail\afe.cag", "C:\Temp\ENE\webmail\afe.txt")
            Dim leraf As New StreamReader("C:\Temp\ENE\webmail\afe.txt")
            Dim lndaf As String = leraf.ReadLine
            leraf.Close()
            Dim lerafs As New StreamReader("C:\Temp\ENE\webmail\afs.txt")
            Dim lndafs As String = lerafs.ReadLine
            lerafs.Close()
            My.Computer.FileSystem.DeleteFile("C:\Temp\ENE\webmail\afs.txt")
            My.Computer.FileSystem.DeleteFile("C:\Temp\ENE\webmail\afe.txt")


            Dim rnd As New Random
            codigo = rnd.Next(10000, 99999)
            Try
                Dim oMail As New MailMessage
                oMail.From = New MailAddress(lndaf)
                oMail.To.Add(New MailAddress(TextBox2.Text))
                oMail.IsBodyHtml = False
                oMail.Subject = "codigo de segurança"
                oMail.Body = "Olá " & TextBox1.Text & ", o seu codigo de segurança é ( " & codigo & " )"


                Dim oSMTP As New SmtpClient()
                oSMTP.EnableSsl = True
                oSMTP.Port = 587
                oSMTP.Host = "smtp.gmail.com"
                oSMTP.Credentials = New System.Net.NetworkCredential(lndaf, lndafs)

                oSMTP.Send(oMail)


                Panel1.Visible = True
                TextBox4.Select()
            Catch ex As Exception
                MsgBox("ocorreu um problema, tente novamente", MsgBoxStyle.OkOnly)
                TextBox3.Text = ""

            End Try
        End If

    End Sub
#End Region

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If cont < 4 Then
            If TextBox4.Text = codigo Then
                FileSystem.MkDir("C:/Temp/ENE/user/" & TextBox1.Text)
                Dim path As String = ("C:/Temp/ENE/user/" & TextBox1.Text & "/pass.txt")
                Dim fs As FileStream = File.Create(path)
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(TextBox3.Text)
                fs.Write(info, 0, info.Length)
                fs.Close()
                FileSystem.Rename("C:/Temp/ENE/user/" & TextBox1.Text & "/pass.txt", "C:/Temp/ENE/user/" & TextBox1.Text & "/pass.cag")


                Dim RequestFolderCreate As Net.FtpWebRequest = CType(FtpWebRequest.Create("ftp://chattenata.xp3.biz/users/" & TextBox1.Text), FtpWebRequest)
                RequestFolderCreate.Credentials = New NetworkCredential("chattenata.xp3.biz", "narutomortal1")
                RequestFolderCreate.Method = WebRequestMethods.Ftp.MakeDirectory

                Try
                    Using response As FtpWebResponse = DirectCast(RequestFolderCreate.GetResponse(), FtpWebResponse)

                    End Using

                Catch ex As Exception

                End Try

                Try
                    Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create("ftp://chattenata.xp3.biz/users/" & TextBox1.Text & "/pass.cag"), FtpWebRequest)

                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile

                    ftpRequest.Credentials = New NetworkCredential("chattenata.xp3.biz", "narutomortal1")

                    Dim bytes() As Byte = System.IO.File.ReadAllBytes("C:/temp/ENE/user/" & TextBox1.Text & "/pass.cag")

                    ftpRequest.ContentLength = bytes.Length
                    Using UploadStream As Stream = ftpRequest.GetRequestStream()
                        UploadStream.Write(bytes, 0, bytes.Length)
                        UploadStream.Close()
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Exit Sub
                End Try

                FileSystem.Kill("C:/temp/ENE/user/" & TextBox1.Text)
                MsgBox("Concluido", MsgBoxStyle.OkOnly)
                Form1.Show()
                Finalize()

            Else
                cont += 1

            End If
        End If

    End Sub

End Class
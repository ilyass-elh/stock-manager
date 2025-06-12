Imports System.Data.SqlClient

Public Class LoginForm
    Private connectionString As String = DatabaseHelper.ConnectionString

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim lastName As String = txtLastName.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If lastName = "" Or password = "" Then
            lblError.Text = "Please fill in all fields."
            lblError.Visible = True
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Users WHERE LastName = @LastName AND Password = @Password"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@LastName", lastName)
            cmd.Parameters.AddWithValue("@Password", password)

            Try
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim status As String = reader("Status").ToString()
                    Dim mainForm As New MainMenu(status, lastName)
                    mainForm.Show()
                    Me.Hide()
                Else
                    lblError.Text = "Error. Contact your superior."
                    lblError.Visible = True
                End If
                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Database Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DatabaseHelper.InitializeDatabase()
        Catch ex As Exception
            MessageBox.Show("Failed to initialize database: " & ex.Message)
        End Try
        Theme.ApplyTheme(Me)
        
        ' Custom styling for Login
        ' Keep it clean: Light background, clear labels
        Me.BackColor = Theme.BackgroundColor
        lblError.ForeColor = Theme.DangerColor
    End Sub
End Class

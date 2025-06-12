Imports System.Data.SqlClient

Public Class UserManager
    Inherits Form

    Private connectionString As String = DatabaseHelper.ConnectionString

    ' UI Controls
    Private dgvUsers As New DataGridView()
    Private panelActions As New Panel()
    Private btnAdd As New Button()
    Private btnDelete As New Button()
    Private lblHeader As New Label()

    ' Input Panel Controls (Side Panel)
    Private panelInput As New Panel()
    Private lblInputTitle As New Label()
    
    Private txtLastName As New TextBox()
    Private txtFirstName As New TextBox()
    Private txtEmail As New TextBox()
    Private txtPassword As New TextBox()
    Private cmbStatus As New ComboBox() 
    
    Private btnSave As New Button()
    Private btnCancelInput As New Button()

    Public Sub New()
        ' Form Settings
        Me.Text = "Gestion des Utilisateurs"
        Me.Size = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.None
        
        InitializeCustomComponent()
    End Sub

    Private Sub InitializeCustomComponent()
        ' --- 1. Top Toolbar ---
        panelActions.Dock = DockStyle.Top
        panelActions.Height = 60
        panelActions.BackColor = Color.WhiteSmoke
        
        lblHeader.Text = "Utilisateurs"
        lblHeader.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblHeader.ForeColor = Color.FromArgb(44, 62, 80)
        lblHeader.Location = New Point(20, 15)
        lblHeader.AutoSize = True
        
        btnAdd.Text = "+ Nouveau"
        btnAdd.Size = New Size(120, 35)
        btnAdd.Location = New Point(200, 15)
        AddHandler btnAdd.Click, AddressOf btnAdd_Click
        
        btnDelete.Text = "Supprimer"
        btnDelete.Size = New Size(120, 35)
        btnDelete.Location = New Point(330, 15)
        AddHandler btnDelete.Click, AddressOf btnDelete_Click

        panelActions.Controls.Add(lblHeader)
        panelActions.Controls.Add(btnAdd)
        panelActions.Controls.Add(btnDelete)
        
        ' --- 2. Input Side Panel ---
        panelInput.Dock = DockStyle.Right
        panelInput.Width = 320
        panelInput.BackColor = Color.FromArgb(245, 245, 245)
        panelInput.Padding = New Padding(20)
        panelInput.Visible = False ' Hidden by default

        lblInputTitle.Text = "Nouvel Utilisateur"
        lblInputTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblInputTitle.Dock = DockStyle.Top
        lblInputTitle.Height = 50
        lblInputTitle.ForeColor = Color.FromArgb(44, 62, 80)

        ' Labels & Inputs
        Dim currentTop As Integer = 60
        Dim spacing As Integer = 60

        Dim lblLast As New Label() : lblLast.Text = "Nom :" : lblLast.Top = currentTop : lblLast.Left = 20
        txtLastName.Top = currentTop + 25 : txtLastName.Left = 20 : txtLastName.Width = 280
        currentTop += spacing

        Dim lblFirst As New Label() : lblFirst.Text = "Prénom :" : lblFirst.Top = currentTop : lblFirst.Left = 20
        txtFirstName.Top = currentTop + 25 : txtFirstName.Left = 20 : txtFirstName.Width = 280
        currentTop += spacing

        Dim lblEmail As New Label() : lblEmail.Text = "Email :" : lblEmail.Top = currentTop : lblEmail.Left = 20
        txtEmail.Top = currentTop + 25 : txtEmail.Left = 20 : txtEmail.Width = 280
        currentTop += spacing

        Dim lblPass As New Label() : lblPass.Text = "Mot de passe :" : lblPass.Top = currentTop : lblPass.Left = 20
        txtPassword.Top = currentTop + 25 : txtPassword.Left = 20 : txtPassword.Width = 280 : txtPassword.PasswordChar = "*"c
        currentTop += spacing
        
        Dim lblStatus As New Label() : lblStatus.Text = "Statut :" : lblStatus.Top = currentTop : lblStatus.Left = 20
        cmbStatus.Items.AddRange(New String() {"admin", "user"})
        cmbStatus.SelectedIndex = 1
        cmbStatus.Top = currentTop + 25 : cmbStatus.Left = 20 : cmbStatus.Width = 280 : cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        currentTop += spacing + 10

        ' Buttons
        btnSave.Text = "Enregistrer"
        btnSave.Top = currentTop : btnSave.Left = 20 : btnSave.Width = 120 : btnSave.Height = 35
        btnSave.BackColor = Color.FromArgb(46, 204, 113) ' Green
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        AddHandler btnSave.Click, AddressOf btnSave_Click

        btnCancelInput.Text = "Annuler"
        btnCancelInput.Top = currentTop : btnCancelInput.Left = 160 : btnCancelInput.Width = 120 : btnCancelInput.Height = 35
        AddHandler btnCancelInput.Click, AddressOf btnCancelInput_Click

        panelInput.Controls.AddRange({lblInputTitle, lblLast, txtLastName, lblFirst, txtFirstName, lblEmail, txtEmail, lblPass, txtPassword, lblStatus, cmbStatus, btnSave, btnCancelInput})

        ' --- 3. DataGrid ---
        dgvUsers.Dock = DockStyle.Fill
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        
        ' Add Controls (Order matters for Docking)
        Me.Controls.Add(dgvUsers)
        Me.Controls.Add(panelInput) ' Right dock
        Me.Controls.Add(panelActions) ' Top dock
    End Sub

    Private Sub UserManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        
        ' Fix Styles
        panelActions.BackColor = Theme.SecondaryColor
        lblHeader.ForeColor = Color.White
        panelInput.BackColor = Color.FromArgb(236, 240, 241)
        
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim adapt As New SqlDataAdapter("SELECT Id, LastName, FirstName, Email, Status FROM Users", conn)
                Dim dt As New DataTable()
                adapt.Fill(dt)
                dgvUsers.DataSource = dt
            End Using
            Theme.ApplyDataGridTheme(dgvUsers)
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        ' Show Input Panel
        panelInput.Visible = True
        txtLastName.Clear()
        txtFirstName.Clear()
        txtEmail.Clear()
        txtPassword.Clear()
        cmbStatus.SelectedIndex = 1
        txtLastName.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim lastName As String = txtLastName.Text.Trim()
        Dim firstName As String = txtFirstName.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim status As String = cmbStatus.SelectedItem.ToString()

        If String.IsNullOrWhiteSpace(lastName) OrElse String.IsNullOrWhiteSpace(firstName) OrElse String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Tous les champs sont obligatoires.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO Users (LastName, FirstName, Email, Password, Status) VALUES (@LastName, @FirstName, @Email, @Password, @Status)", conn)
            cmd.Parameters.AddWithValue("@LastName", lastName)
            cmd.Parameters.AddWithValue("@FirstName", firstName)
            cmd.Parameters.AddWithValue("@Email", email)
            cmd.Parameters.AddWithValue("@Password", password)
            cmd.Parameters.AddWithValue("@Status", status)
            Try
                conn.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Utilisateur ajouté avec succès !")
                LoadUsers()
                panelInput.Visible = False
            Catch ex As Exception
                MessageBox.Show("Erreur lors de l'ajout : " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnCancelInput_Click(sender As Object, e As EventArgs)
        panelInput.Visible = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un utilisateur.")
            Return
        End If

        Dim row = dgvUsers.SelectedRows(0)
        Dim id As Integer = Convert.ToInt32(row.Cells("Id").Value)
        
        If MessageBox.Show("Supprimer cet utilisateur ?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Using conn As New SqlConnection(connectionString)
                Dim cmd As New SqlCommand("DELETE FROM Users WHERE Id = @Id", conn)
                cmd.Parameters.AddWithValue("@Id", id)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadUsers()
                Catch ex As Exception
                    MessageBox.Show("Erreur suppression : " & ex.Message)
                End Try
            End Using
        End If
    End Sub
End Class

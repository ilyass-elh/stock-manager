Imports System.Data.SqlClient

Public Class SupplierManager
    Inherits Form

    Private connectionString As String = DatabaseHelper.ConnectionString

    ' UI Controls
    Private dgvSuppliers As New DataGridView()
    Private panelActions As New Panel()
    Private btnAdd As New Button()
    Private btnDelete As New Button()
    Private lblHeader As New Label()

    ' Input Panel Controls (Side Panel)
    Private panelInput As New Panel()
    Private lblInputTitle As New Label()
    Private txtName As New TextBox()
    Private txtPhone As New TextBox()
    Private txtAddress As New TextBox()
    Private btnSave As New Button()
    Private btnCancelInput As New Button()

    Public Sub New()
        ' Form Settings
        Me.Text = "Gestion des Fournisseurs"
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
        
        lblHeader.Text = "Fournisseurs"
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
        panelInput.Width = 300
        panelInput.BackColor = Color.FromArgb(245, 245, 245)
        panelInput.Padding = New Padding(20)
        panelInput.Visible = False ' Hidden by default

        lblInputTitle.Text = "Nouveau Fournisseur"
        lblInputTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblInputTitle.Dock = DockStyle.Top
        lblInputTitle.Height = 50
        lblInputTitle.ForeColor = Color.FromArgb(44, 62, 80)

        ' Labels
        Dim lblName As New Label() : lblName.Text = "Nom :" : lblName.Top = 60 : lblName.Left = 20
        Dim lblPhone As New Label() : lblPhone.Text = "Téléphone :" : lblPhone.Top = 130 : lblPhone.Left = 20
        Dim lblAddress As New Label() : lblAddress.Text = "Adresse :" : lblAddress.Top = 200 : lblAddress.Left = 20

        ' Inputs
        txtName.Top = 85 : txtName.Left = 20 : txtName.Width = 260
        txtPhone.Top = 155 : txtPhone.Left = 20 : txtPhone.Width = 260
        txtAddress.Top = 225 : txtAddress.Left = 20 : txtAddress.Width = 260 : txtAddress.Height = 60 : txtAddress.Multiline = True

        ' Buttons
        btnSave.Text = "Enregistrer"
        btnSave.Top = 320 : btnSave.Left = 20 : btnSave.Width = 120 : btnSave.Height = 35
        btnSave.BackColor = Color.FromArgb(46, 204, 113) ' Green
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        AddHandler btnSave.Click, AddressOf btnSave_Click

        btnCancelInput.Text = "Annuler"
        btnCancelInput.Top = 320 : btnCancelInput.Left = 160 : btnCancelInput.Width = 120 : btnCancelInput.Height = 35
        AddHandler btnCancelInput.Click, AddressOf btnCancelInput_Click

        panelInput.Controls.AddRange({lblInputTitle, lblName, txtName, lblPhone, txtPhone, lblAddress, txtAddress, btnSave, btnCancelInput})

        ' --- 3. DataGrid ---
        dgvSuppliers.Dock = DockStyle.Fill
        dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        
        ' Add Controls (Order matters for Docking)
        Me.Controls.Add(dgvSuppliers)
        Me.Controls.Add(panelInput) ' Right dock
        Me.Controls.Add(panelActions) ' Top dock
    End Sub

    Private Sub SupplierManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        ' Fix Styles
        panelActions.BackColor = Theme.SecondaryColor
        lblHeader.ForeColor = Color.White
        
        ' Panel Input Style Fix
        panelInput.BackColor = Color.FromArgb(236, 240, 241)

        LoadSuppliers()
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim adapt As New SqlDataAdapter("SELECT Id, Name, Phone, Address FROM Suppliers", conn)
                Dim dt As New DataTable()
                adapt.Fill(dt)
                dgvSuppliers.DataSource = dt
            End Using
            Theme.ApplyDataGridTheme(dgvSuppliers)
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        ' Show Input Panel
        panelInput.Visible = True
        txtName.Clear()
        txtPhone.Clear()
        txtAddress.Clear()
        txtName.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim name As String = txtName.Text.Trim()
        Dim phone As String = txtPhone.Text.Trim()
        Dim address As String = txtAddress.Text.Trim()

        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Le nom est obligatoire.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO Suppliers (Name, Phone, Address) VALUES (@Name, @Phone, @Address)", conn)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Phone", phone)
            cmd.Parameters.AddWithValue("@Address", address)
            Try
                conn.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Fournisseur ajouté avec succès !")
                LoadSuppliers()
                panelInput.Visible = False ' Hide after save
            Catch ex As Exception
                MessageBox.Show("Erreur lors de l'ajout : " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnCancelInput_Click(sender As Object, e As EventArgs)
        panelInput.Visible = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If dgvSuppliers.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un fournisseur.")
            Return
        End If

        Dim row = dgvSuppliers.SelectedRows(0)
        Dim id As Integer = Convert.ToInt32(row.Cells("Id").Value)
        
        If MessageBox.Show("Supprimer ce fournisseur ?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Using conn As New SqlConnection(connectionString)
                Dim cmd As New SqlCommand("DELETE FROM Suppliers WHERE Id = @Id", conn)
                cmd.Parameters.AddWithValue("@Id", id)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadSuppliers()
                Catch ex As Exception
                    MessageBox.Show("Erreur suppression : " & ex.Message)
                End Try
            End Using
        End If
    End Sub
End Class

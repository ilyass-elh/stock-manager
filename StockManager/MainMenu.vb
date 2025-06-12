Imports System.Data.SqlClient

Public Class MainMenu
    Private userStatus As String
    Private userLastName As String

    Private connectionString As String = DatabaseHelper.ConnectionString

    Public Sub New(status As String, lastName As String)
        InitializeComponent()
        userStatus = status
        userLastName = lastName
    End Sub

    
    ' Track active button
    Private currentButton As Button

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        
        ' Style Sidebar
        panelSidebar.BackColor = Theme.PrimaryColor
        InitializeSidebarButtons()
        
        ' Override Logo with Custom Dashboard Logo
        Try
            Dim logoPath As String = IO.Path.Combine(Application.StartupPath, "dashboard_logo.png")
            If IO.File.Exists(logoPath) Then
                picLogo.Image = Image.FromFile(logoPath)
                picLogo.SizeMode = PictureBoxSizeMode.Zoom
            Else
                ' Debugging: Uncomment if needed, or remove later
                ' MessageBox.Show("Logo not found at: " & logoPath)
            End If
        Catch ex As Exception
             MessageBox.Show("Error loading logo: " & ex.Message)
        End Try

        ' Show/hide Create User
        btnCreateUser.Visible = (userStatus.ToLower() <> "user")
        lblGreeting.Text = "Bonjour " & userLastName
        
        ' Default View
        ShowDashboard()
    End Sub

    Private Sub InitializeSidebarButtons()
        Theme.ApplySidebarButtonTheme(btnDashboard)
        Theme.ApplySidebarButtonTheme(btnInventory)
        Theme.ApplySidebarButtonTheme(btnOrder)
        Theme.ApplySidebarButtonTheme(btnSuppliers)
        Theme.ApplySidebarButtonTheme(btnCreateUser)
        Theme.ApplyLogoutTheme(btnLogout)
    End Sub

    Private Sub ActivateButton(btnSender As Object)
        If btnSender IsNot Nothing Then
            If currentButton IsNot CType(btnSender, Button) Then
                DisableButton()
                currentButton = CType(btnSender, Button)
                Theme.SetActiveSidebarButton(currentButton)
            End If
        End If
    End Sub

    Private Sub DisableButton()
        If currentButton IsNot Nothing Then
            Theme.SetInactiveSidebarButton(currentButton)
        End If
    End Sub

    Private Sub OpenChildForm(childForm As Form, btnSender As Object)
        ActivateButton(btnSender)
        
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        
        panelContent.Controls.Clear()
        panelContent.Controls.Add(childForm)
        panelContent.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
        
        lblDashboardTitle.Text = childForm.Text ' Update Header Title
    End Sub

    ' --- Navigation Events ---

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowDashboard()
        ActivateButton(sender)
    End Sub

    Private Sub ShowDashboard()
        ' Re-show the internal dashboard panels
        panelContent.Controls.Clear()
        panelContent.Controls.Add(panelStats)
        panelContent.Controls.Add(lblDashboardTitle)
        panelContent.Controls.Add(lstAlerts)
        panelContent.Controls.Add(lblAlertsHeader)
        
        lblDashboardTitle.Text = "Tableau de Bord"
        LoadDashboardStats()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        OpenChildForm(New Inventory(userStatus, userLastName), sender)
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        OpenChildForm(New Order(userStatus, userLastName), sender)
    End Sub

    Private Sub btnSuppliers_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        OpenChildForm(New SupplierManager(), sender)
    End Sub

    Private Sub LoadDashboardStats()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                
                ' 1. Total Products
                Dim cmdCount As New SqlCommand("SELECT COUNT(*) FROM Products", conn)
                Dim count As Integer = Convert.ToInt32(cmdCount.ExecuteScalar())
                lblTotalProducts.Text = count.ToString()

                ' 2. Total Value
                Dim totalValue As Decimal = 0
                Try
                    Dim cmdValue As New SqlCommand("SELECT SUM(Quantity * Price) FROM Products", conn)
                    Dim result = cmdValue.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        totalValue = Convert.ToDecimal(result)
                    End If
                Catch
                End Try
                lblTotalValue.Text = String.Format("{0:N2} DH", totalValue)

                ' 3. Alerts
                lstAlerts.Items.Clear()
                Dim cmdAlerts As New SqlCommand("SELECT Name, Quantity FROM Products WHERE Quantity < 5", conn)
                Dim reader As SqlDataReader = cmdAlerts.ExecuteReader()
                While reader.Read()
                    lstAlerts.Items.Add(reader("Name").ToString() & " - Qty: " & reader("Quantity").ToString())
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            ' MessageBox.Show("Error loading stats: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCreateUser_Click(sender As Object, e As EventArgs) Handles btnCreateUser.Click
        OpenChildForm(New UserManager(), sender)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            Dim loginForm As New LoginForm() '
            loginForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class

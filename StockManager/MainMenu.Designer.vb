<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.panelSidebar = New System.Windows.Forms.Panel()
        Me.panelLogo = New System.Windows.Forms.Panel()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.btnSuppliers = New System.Windows.Forms.Button()
        Me.btnCreateUser = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblGreeting = New System.Windows.Forms.Label()
        Me.panelContent = New System.Windows.Forms.Panel()
        Me.lblDashboardTitle = New System.Windows.Forms.Label()
        Me.panelStats = New System.Windows.Forms.FlowLayoutPanel()
        Me.cardProducts = New System.Windows.Forms.Panel()
        Me.lblTotalProducts = New System.Windows.Forms.Label()
        Me.lblStatsProductTitle = New System.Windows.Forms.Label()
        Me.cardValue = New System.Windows.Forms.Panel()
        Me.lblTotalValue = New System.Windows.Forms.Label()
        Me.lblStatsValueTitle = New System.Windows.Forms.Label()
        Me.lstAlerts = New System.Windows.Forms.ListBox()
        Me.lblAlertsHeader = New System.Windows.Forms.Label()
        
        Me.panelSidebar.SuspendLayout()
        Me.panelLogo.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.panelContent.SuspendLayout()
        Me.panelStats.SuspendLayout()
        Me.cardProducts.SuspendLayout()
        Me.cardValue.SuspendLayout()
        Me.SuspendLayout()
        
        ' 
        ' panelSidebar
        ' 
        Me.panelSidebar.BackColor = System.Drawing.Color.FromArgb(30, 40, 50) ' Dark Sidebar
        Me.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelSidebar.Width = 250
        Me.panelSidebar.Controls.Add(Me.btnLogout)
        Me.panelSidebar.Controls.Add(Me.btnCreateUser)
        Me.panelSidebar.Controls.Add(Me.btnSuppliers)
        Me.panelSidebar.Controls.Add(Me.btnOrder)
        Me.panelSidebar.Controls.Add(Me.btnInventory)
        Me.panelSidebar.Controls.Add(Me.btnDashboard)
        Me.panelSidebar.Controls.Add(Me.panelLogo)
        
        ' 
        ' panelLogo
        ' 
        Me.panelLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelLogo.Height = 150
        Me.panelLogo.Controls.Add(Me.picLogo)
        
        ' 
        ' picLogo
        ' 
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLogo.Padding = New System.Windows.Forms.Padding(20)
        
        ' 
        ' Navigation Buttons
        ' 
        Me.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDashboard.Height = 50
        Me.btnDashboard.Text = "  Dashboard"
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.ForeColor = System.Drawing.Color.White
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        
        Me.btnInventory.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnInventory.Height = 50
        Me.btnInventory.Text = "  Inventaire"
        Me.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInventory.ForeColor = System.Drawing.Color.White
        Me.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInventory.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)

        Me.btnOrder.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnOrder.Height = 50
        Me.btnOrder.Text = "  Commande"
        Me.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrder.ForeColor = System.Drawing.Color.White
        Me.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOrder.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)

        Me.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSuppliers.Height = 50
        Me.btnSuppliers.Text = "  Fournisseurs"
        Me.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuppliers.ForeColor = System.Drawing.Color.White
        Me.btnSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSuppliers.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)

        Me.btnCreateUser.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCreateUser.Height = 50
        Me.btnCreateUser.Text = "  Utilisateurs"
        Me.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateUser.ForeColor = System.Drawing.Color.White
        Me.btnCreateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateUser.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogout.Height = 50
        Me.btnLogout.Text = "  Déconnexion"
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.ForeColor = System.Drawing.Color.IndianRed
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        
        ' 
        ' panelHeader
        ' 
        Me.panelHeader.BackColor = System.Drawing.Color.White
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Height = 60
        Me.panelHeader.Controls.Add(Me.lblGreeting)
        
        ' 
        ' lblGreeting
        ' 
        Me.lblGreeting.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblGreeting.Width = 300
        Me.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblGreeting.Font = New System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Regular)
        Me.lblGreeting.Text = "Welcome"
        Me.lblGreeting.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        
        ' 
        ' panelContent (Dashboard Area)
        ' 
        Me.panelContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContent.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelContent.Padding = New System.Windows.Forms.Padding(30)
        Me.panelContent.Controls.Add(Me.lstAlerts)
        Me.panelContent.Controls.Add(Me.lblAlertsHeader)
        Me.panelContent.Controls.Add(Me.panelStats)
        Me.panelContent.Controls.Add(Me.lblDashboardTitle)
        
        ' 
        ' lblDashboardTitle
        ' 
        Me.lblDashboardTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDashboardTitle.Height = 50
        Me.lblDashboardTitle.Text = "Tableau de Bord"
        Me.lblDashboardTitle.Font = New System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold)
        Me.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        
        ' 
        ' panelStats (Flow Layout for Cards)
        ' 
        Me.panelStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelStats.Height = 150
        Me.panelStats.Controls.Add(Me.cardProducts)
        Me.panelStats.Controls.Add(Me.cardValue)
        
        ' 
        ' cardProducts
        ' 
        Me.cardProducts.BackColor = System.Drawing.Color.White
        Me.cardProducts.Size = New System.Drawing.Size(250, 120)
        Me.cardProducts.Margin = New System.Windows.Forms.Padding(0, 0, 20, 20)
        Me.cardProducts.Controls.Add(Me.lblTotalProducts)
        Me.cardProducts.Controls.Add(Me.lblStatsProductTitle)
        ' Border Logic in Panel if needed, or just flat white
        
        ' 
        ' cardValue
        ' 
        Me.cardValue.BackColor = System.Drawing.Color.White
        Me.cardValue.Size = New System.Drawing.Size(250, 120)
        Me.cardValue.Margin = New System.Windows.Forms.Padding(0, 0, 20, 20)
        Me.cardValue.Controls.Add(Me.lblTotalValue)
        Me.cardValue.Controls.Add(Me.lblStatsValueTitle)
        
        ' 
        ' Labels for Stats
        ' 
        Me.lblStatsProductTitle.Text = "Total Produits"
        Me.lblStatsProductTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblStatsProductTitle.AutoSize = True
        Me.lblStatsProductTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblStatsProductTitle.Font = New System.Drawing.Font("Segoe UI", 10)
        
        Me.lblTotalProducts.Text = "0"
        Me.lblTotalProducts.Location = New System.Drawing.Point(20, 50)
        Me.lblTotalProducts.AutoSize = True
        Me.lblTotalProducts.Font = New System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Bold)
        Me.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(0, 120, 212) ' Blue
        
        Me.lblStatsValueTitle.Text = "Valeur Stock"
        Me.lblStatsValueTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblStatsValueTitle.AutoSize = True
        Me.lblStatsValueTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblStatsValueTitle.Font = New System.Drawing.Font("Segoe UI", 10)

        Me.lblTotalValue.Text = "0.00 DH"
        Me.lblTotalValue.Location = New System.Drawing.Point(20, 50)
        Me.lblTotalValue.AutoSize = True
        Me.lblTotalValue.Font = New System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Bold)
        Me.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(16, 124, 16) ' Green
        
        ' 
        ' Low Stock Alerts
        ' 
        Me.lblAlertsHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlertsHeader.Height = 40
        Me.lblAlertsHeader.Text = "Alertes Stock Faible"
        Me.lblAlertsHeader.Font = New System.Drawing.Font("Segoe UI", 14)
        Me.lblAlertsHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        
        Me.lstAlerts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAlerts.Font = New System.Drawing.Font("Segoe UI", 10)
        Me.lstAlerts.BackColor = System.Drawing.Color.White
        
        ' 
        ' MainMenu
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 697)
        Me.Controls.Add(Me.panelContent)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.panelSidebar)
        Me.Name = "MainMenu"
        Me.Text = "Stock Manager - Admin Panel"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

        Me.panelSidebar.ResumeLayout(False)
        Me.panelLogo.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelContent.ResumeLayout(False)
        Me.panelStats.ResumeLayout(False)
        Me.cardProducts.ResumeLayout(False)
        Me.cardProducts.PerformLayout()
        Me.cardValue.ResumeLayout(False)
        Me.cardValue.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelSidebar As Panel
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelContent As Panel
    Friend WithEvents panelLogo As Panel
    Friend WithEvents picLogo As PictureBox
    
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnOrder As Button
    Friend WithEvents btnSuppliers As Button
    Friend WithEvents btnCreateUser As Button
    Friend WithEvents btnLogout As Button
    
    Friend WithEvents lblGreeting As Label
    
    ' Dashboard Controls
    Friend WithEvents lblDashboardTitle As Label
    Friend WithEvents panelStats As FlowLayoutPanel
    Friend WithEvents cardProducts As Panel
    Friend WithEvents lblTotalProducts As Label
    Friend WithEvents lblStatsProductTitle As Label
    Friend WithEvents cardValue As Panel
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents lblStatsValueTitle As Label
    Friend WithEvents lstAlerts As ListBox
    Friend WithEvents lblAlertsHeader As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.picPassword = New System.Windows.Forms.PictureBox()
        Me.picLastName = New System.Windows.Forms.PictureBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.picPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLastName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(263, 463)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(189, 28)
        Me.btnLogin.TabIndex = 17
        Me.btnLogin.Text = "Se Connecter"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(222, 406)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 16)
        Me.lblError.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 365)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Mot De Passe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(222, 295)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Login"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(225, 381)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(294, 22)
        Me.txtPassword.TabIndex = 13
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(224, 311)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(294, 22)
        Me.txtLastName.TabIndex = 12
        '
        'picPassword
        '
        Me.picPassword.Location = New System.Drawing.Point(179, 365)
        Me.picPassword.Name = "picPassword"
        Me.picPassword.Size = New System.Drawing.Size(37, 35)
        Me.picPassword.TabIndex = 11
        Me.picPassword.TabStop = False
        '
        'picLastName
        '
        Me.picLastName.Location = New System.Drawing.Point(179, 296)
        Me.picLastName.Name = "picLastName"
        Me.picLastName.Size = New System.Drawing.Size(37, 35)
        Me.picLastName.TabIndex = 10
        Me.picLastName.TabStop = False
        '
        'picLogo
        '
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(234, 1)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(252, 251)
        Me.picLogo.TabIndex = 9
        Me.picLogo.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(263, 497)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(189, 27)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Quiter"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'LoginForm
        '
        Me.ClientSize = New System.Drawing.Size(710, 623)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.picPassword)
        Me.Controls.Add(Me.picLastName)
        Me.Controls.Add(Me.picLogo)
        Me.Name = "LoginForm"
        CType(Me.picPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLastName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLogin As Button
    Friend WithEvents lblError As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents picPassword As PictureBox
    Friend WithEvents picLastName As PictureBox
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents btnExit As Button
End Class

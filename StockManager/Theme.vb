Imports System.Drawing

Public Module Theme
    ' Business Professional Theme (Slate & Clean)
    Public PrimaryColor As Color = ColorTranslator.FromHtml("#2c3e50") ' Slate Blue (Sidebar)
    Public SecondaryColor As Color = ColorTranslator.FromHtml("#34495e") ' Lighter Slate
    Public AccentColor As Color = ColorTranslator.FromHtml("#3498db") ' Action Blue
    Public SuccessColor As Color = ColorTranslator.FromHtml("#27ae60") ' Muted Green
    Public DangerColor As Color = ColorTranslator.FromHtml("#c0392b") ' Muted Red
    Public TextColor As Color = ColorTranslator.FromHtml("#ecf0f1") ' Light Text
    Public DarkTextColor As Color = ColorTranslator.FromHtml("#2c3e50") ' Dark Text
    Public BackgroundColor As Color = ColorTranslator.FromHtml("#f4f6f9") ' Professional Light Gray Background

    Public DefaultFont As Font = New Font("Segoe UI", 9, FontStyle.Regular)
    Public HeaderFont As Font = New Font("Segoe UI", 18, FontStyle.Bold)
    Public SubHeaderFont As Font = New Font("Segoe UI", 12, FontStyle.Regular)

    Public Sub ApplyTheme(form As Form)
        form.BackColor = BackgroundColor
        form.Font = DefaultFont
        ' ... existing control loop ...
         For Each ctrl As Control In form.Controls
            ApplyControlTheme(ctrl)
        Next
    End Sub

    Public Sub ApplyControlTheme(ctrl As Control)
        If TypeOf ctrl Is Button Then
            Dim btn As Button = CType(ctrl, Button)
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.BackColor = AccentColor
            btn.ForeColor = Color.White
            btn.Cursor = Cursors.Hand
             If btn.Name.ToLower().Contains("delete") Or btn.Name.ToLower().Contains("cancel") Or btn.Name.ToLower().Contains("exit") Then
                btn.BackColor = DangerColor
            End If
        ElseIf TypeOf ctrl Is Label Then
            ctrl.ForeColor = DarkTextColor
            If ctrl.Name.ToLower().Contains("header") Then
                ctrl.Font = HeaderFont
                ctrl.ForeColor = PrimaryColor
            End If
        ElseIf TypeOf ctrl Is DataGridView Then
            ApplyDataGridTheme(CType(ctrl, DataGridView))
        ElseIf TypeOf ctrl Is Panel Then
            ctrl.BackColor = Color.Transparent
            For Each child As Control In ctrl.Controls
                ApplyControlTheme(child)
            Next
        End If
    End Sub

    Public Sub ApplyDataGridTheme(dgv As DataGridView)
        dgv.BackgroundColor = Color.White
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        
        ' Header Style
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Padding = New Padding(6)
        dgv.ColumnHeadersHeight = 40
        
        ' Row Style
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.ForeColor = DarkTextColor
        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 9)
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255) ' Very Light Blue
        dgv.DefaultCellStyle.SelectionForeColor = DarkTextColor
        dgv.DefaultCellStyle.Padding = New Padding(6)
        dgv.RowTemplate.Height = 35
        
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250)
        
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.RowHeadersVisible = False
        dgv.AllowUserToResizeRows = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Public Sub ApplyTileTheme(btn As Button)
        ' Card Style: White, clean, subtle border
        btn.BackColor = Color.White
        btn.ForeColor = PrimaryColor
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderColor = Color.Gainsboro
        btn.FlatAppearance.BorderSize = 1
        btn.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
        btn.Size = New Size(220, 120) ' Enforce size in theme or designer? Designer is better, but this ensures consistency if applied dynamically.
    End Sub

    Public Sub ApplyLogoutTheme(btn As Button)
        btn.BackColor = Color.Transparent
        btn.ForeColor = DangerColor
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
        btn.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Public Sub ApplySidebarButtonTheme(btn As Button)
        btn.BackColor = Color.Transparent
        btn.ForeColor = Color.FromArgb(189, 195, 199) ' Muted Text
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Padding = New Padding(15, 0, 0, 0)
    End Sub

    Public Sub SetActiveSidebarButton(btn As Button)
        btn.BackColor = Color.FromArgb(52, 73, 94) ' Slightly lighter active bg
        btn.ForeColor = Color.White
        btn.FlatAppearance.BorderColor = AccentColor
        btn.FlatAppearance.BorderSize = 0 ' Or 0 if using left border strip logic (harder in pure winforms without custom paint)
    End Sub

    Public Sub SetInactiveSidebarButton(btn As Button)
        btn.BackColor = Color.Transparent
        btn.ForeColor = Color.FromArgb(189, 195, 199)
    End Sub
End Module

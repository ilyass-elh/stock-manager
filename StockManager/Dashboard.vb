Imports System.Data.SqlClient

Public Class Dashboard
    Inherits Form

    Private connectionString As String = DatabaseHelper.ConnectionString

    ' UI Controls
    Private lblTotalProducts As New Label()
    Private lblTotalValue As New Label()
    Private lblAlertsHeader As New Label()
    Private lstAlerts As New ListBox()
    Private btnBack As New Button()

    Public Sub New()
        ' Form Settings
        Me.Text = "Dashboard"
        Me.Size = New Size(600, 450)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        ' Initialize Controls
        lblTotalProducts.Location = New Point(20, 20)
        lblTotalProducts.AutoSize = True
        lblTotalProducts.Font = New Font("Segoe UI", 12, FontStyle.Bold)

        lblTotalValue.Location = New Point(20, 50)
        lblTotalValue.AutoSize = True
        lblTotalValue.Font = New Font("Segoe UI", 12, FontStyle.Bold)

        lblAlertsHeader.Text = "Low Stock Alerts (< 5 items)"
        lblAlertsHeader.Location = New Point(20, 100)
        lblAlertsHeader.AutoSize = True
        lblAlertsHeader.Font = Theme.HeaderFont

        lstAlerts.Location = New Point(20, 140)
        lstAlerts.Size = New Size(540, 200)

        btnBack.Text = "Back"
        btnBack.Location = New Point(20, 360)
        btnBack.Size = New Size(100, 35)
        AddHandler btnBack.Click, AddressOf btnBack_Click

        ' Add Controls
        Me.Controls.Add(lblTotalProducts)
        Me.Controls.Add(lblTotalValue)
        Me.Controls.Add(lblAlertsHeader)
        Me.Controls.Add(lstAlerts)
        Me.Controls.Add(btnBack)
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        LoadStats()
    End Sub

    Private Sub LoadStats()
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' 1. Total Products
            Dim cmdCount As New SqlCommand("SELECT COUNT(*) FROM Products", conn)
            Dim count As Integer = Convert.ToInt32(cmdCount.ExecuteScalar())
            lblTotalProducts.Text = "Total Products: " & count.ToString()

            ' 2. Total Value (needs Price column)
            Dim totalValue As Decimal = 0
            Try
                Dim cmdValue As New SqlCommand("SELECT SUM(Quantity * Price) FROM Products", conn)
                Dim result = cmdValue.ExecuteScalar()
                If Not IsDBNull(result) Then
                    totalValue = Convert.ToDecimal(result)
                End If
            Catch
                ' Ignore if Price column issue or empty
            End Try
            lblTotalValue.Text = String.Format("Total Inventory Value: {0:C2}", totalValue)

            ' 3. Alerts
            lstAlerts.Items.Clear()
            Dim cmdAlerts As New SqlCommand("SELECT Name, Quantity FROM Products WHERE Quantity < 5", conn)
            Dim reader As SqlDataReader = cmdAlerts.ExecuteReader()
            While reader.Read()
                lstAlerts.Items.Add(reader("Name").ToString() & " - Qty: " & reader("Quantity").ToString())
            End While
            reader.Close()
        End Using
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class

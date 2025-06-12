Imports System.Data.SqlClient

Public Class Order
    Private connectionString As String = DatabaseHelper.ConnectionString
    Private cartTable As New DataTable()

    Private userStatus As String
    Private userLastName As String

    Public Sub New(status As String, lastName As String)
        InitializeComponent()
        userStatus = status
        userLastName = lastName
        SetupCartTable()
    End Sub

    Public Sub New()
        ' Default constructor for designer or other uses if needed
        InitializeComponent()
        SetupCartTable()
    End Sub

    Private Sub SetupCartTable()
        cartTable.Columns.Add("Id", GetType(Integer))
        cartTable.Columns.Add("Product", GetType(String))
        cartTable.Columns.Add("Price", GetType(Decimal))
        cartTable.Columns.Add("Quantity", GetType(Integer))
        cartTable.Columns.Add("Total", GetType(Decimal))
    End Sub

    Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        
        ' Header Style Fix
        panelHeader.BackColor = Theme.PrimaryColor 
        lblTitle.ForeColor = Color.White
        
        ' Specific button styles if needed
        Theme.ApplyControlTheme(btnAddToCart)
        Theme.ApplyControlTheme(btnValidate)
        ' btnCancel is auto-styled red by Theme if name contains "Cancel"
        
        LoadProducts()
        
        dgvCart.DataSource = cartTable
        Theme.ApplyDataGridTheme(dgvCart)
        UpdateTotal()
    End Sub

    Private Sub LoadProducts()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim adapt As New SqlDataAdapter("SELECT Id, Name, Quantity AS Stock, Price FROM Products WHERE Quantity > 0", conn)
                Dim dt As New DataTable()
                adapt.Fill(dt)
                dgvProducts.DataSource = dt
            End Using
            Theme.ApplyDataGridTheme(dgvProducts)
            
            ' Format Price column
             If dgvProducts.Columns("Price") IsNot Nothing Then
                dgvProducts.Columns("Price").DefaultCellStyle.Format = "c2"
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un produit.")
            Return
        End If

        Dim row = dgvProducts.SelectedRows(0)
        Dim id As Integer = Convert.ToInt32(row.Cells("Id").Value)
        Dim name As String = row.Cells("Name").Value.ToString()
        Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
        Dim stock As Integer = Convert.ToInt32(row.Cells("Stock").Value)
        Dim qty As Integer = Convert.ToInt32(numQuantity.Value)

        If qty > stock Then
            MessageBox.Show(String.Format("Stock insuffisant. Seulement {0} disponibles.", stock))
            Return
        End If

        ' Check if already in cart
        Dim foundRow As DataRow = Nothing
        For Each r As DataRow In cartTable.Rows
            If Convert.ToInt32(r("Id")) = id Then
                foundRow = r
                Exit For
            End If
        Next

        If foundRow IsNot Nothing Then
            Dim newQty = Convert.ToInt32(foundRow("Quantity")) + qty
            If newQty > stock Then
                 MessageBox.Show(String.Format("Stock insuffisant pour ajouter {0} de plus.", qty))
                 Return
            End If
            foundRow("Quantity") = newQty
            foundRow("Total") = newQty * price
        Else
            cartTable.Rows.Add(id, name, price, qty, qty * price)
        End If

        UpdateTotal()
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvCart.SelectedRows.Count > 0 Then
             For Each row As DataGridViewRow In dgvCart.SelectedRows
                cartTable.Rows.RemoveAt(row.Index)
             Next
             UpdateTotal()
        End If
    End Sub

    Private Sub UpdateTotal()
        Dim total As Decimal = 0
        For Each row As DataRow In cartTable.Rows
            total += Convert.ToDecimal(row("Total"))
        Next
        lblTotal.Text = String.Format("Total: {0:N2} DH", total)
        lblTotal.ForeColor = Theme.DarkTextColor
    End Sub

    Private Sub btnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        If cartTable.Rows.Count = 0 Then Return

        If MessageBox.Show("Confirmer la commande ?", "Validation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim transaction = conn.BeginTransaction()
                
                Try
                    For Each row As DataRow In cartTable.Rows
                        Dim id As Integer = Convert.ToInt32(row("Id"))
                        Dim qty As Integer = Convert.ToInt32(row("Quantity"))
                        
                        Dim cmd As New SqlCommand("UPDATE Products SET Quantity = Quantity - @Qty WHERE Id = @Id", conn, transaction)
                        cmd.Parameters.AddWithValue("@Qty", qty)
                        cmd.Parameters.AddWithValue("@Id", id)
                        cmd.ExecuteNonQuery()
                    Next

                    transaction.Commit()
                    MessageBox.Show("Commande validée avec succès !")
                    cartTable.Rows.Clear()
                    UpdateTotal()
                    LoadProducts() ' Refresh stock
                    
                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Erreur lors de la validation : " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
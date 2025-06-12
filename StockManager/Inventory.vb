Imports System.Data.SqlClient

Public Class Inventory
    Private connectionString As String = DatabaseHelper.ConnectionString

    Private userStatus As String
    Private userLastName As String

    Public Sub New(status As String, lastName As String)
        InitializeComponent()
        userStatus = status
        userLastName = lastName
    End Sub

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        
        ' Additional Toolbar Styling
        panelActions.BackColor = Theme.SecondaryColor
        lblTitle.ForeColor = Color.White ' Fix for dark background contrast
        
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim adapt As New SqlDataAdapter("SELECT Id, Name, Quantity, Price, ExpirationDate FROM Products", conn)
                Dim dt As New DataTable()
                adapt.Fill(dt)
                
                dgvProducts.DataSource = dt
                
                ' Format Columns
                If dgvProducts.Columns("Price") IsNot Nothing Then
                    dgvProducts.Columns("Price").DefaultCellStyle.Format = "c2"
                End If
            End Using
            
            Theme.ApplyDataGridTheme(dgvProducts)
            
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        End Try
    End Sub

    Private Function GetSelectedProductId() As Integer?
        If dgvProducts.SelectedRows.Count = 0 Then Return Nothing
        
        Dim row = dgvProducts.SelectedRows(0)
        Return Convert.ToInt32(row.Cells("Id").Value)
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim name As String = InputBox("Enter Product Name:").Trim()
        If String.IsNullOrWhiteSpace(name) Then Return

        Dim qtyInput As String = InputBox("Enter Quantity:")
        Dim quantity As Integer
        If Not Integer.TryParse(qtyInput, quantity) OrElse quantity < 0 Then
            MessageBox.Show("Invalid quantity.")
            Return
        End If

        Dim priceInput As String = InputBox("Enter Price (e.g. 10.50):")
        Dim price As Decimal
        If Not Decimal.TryParse(priceInput, price) OrElse price < 0 Then
            MessageBox.Show("Invalid price.")
            Return
        End If

        Dim expDateInput As String = InputBox("Enter Expiration Date (YYYY-MM-DD):")
        Dim expiration As Date
        If Not Date.TryParse(expDateInput, expiration) Then
            MessageBox.Show("Invalid expiration date.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction = conn.BeginTransaction()

            Dim query As String = "INSERT INTO Products (Name, Quantity, Price, ExpirationDate) VALUES (@Name, @Quantity, @Price, @ExpirationDate)"
            Dim cmd As New SqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Quantity", quantity)
            cmd.Parameters.AddWithValue("@Price", price)
            cmd.Parameters.AddWithValue("@ExpirationDate", expiration)

            Try
                cmd.ExecuteNonQuery()
                transaction.Commit()
                MessageBox.Show("Product added successfully.")
                LoadProducts()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error adding product: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Dim selectedId = GetSelectedProductId()
        If selectedId Is Nothing Then
            MessageBox.Show("Please select an item to modify.")
            Return
        End If

        Dim currentName As String = ""
        Dim currentQty As Integer = 0
        Dim currentPrice As Decimal = 0
        Dim currentExp As Date = Date.Now

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Products WHERE Id = @Id"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Id", selectedId)

            Try
                conn.Open()
                Dim reader = cmd.ExecuteReader()
                If reader.Read() Then
                    currentName = reader("Name").ToString()
                    currentQty = Convert.ToInt32(reader("Quantity"))
                    Try
                        currentPrice = Convert.ToDecimal(reader("Price"))
                    Catch
                    End Try
                    currentExp = Convert.ToDateTime(reader("ExpirationDate"))
                Else
                    MessageBox.Show("Selected product not found.")
                    Return
                End If
                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error fetching product: " & ex.Message)
                Return
            End Try
        End Using

        Dim newName As String = InputBox("Modify Product Name:", , currentName).Trim()
        If String.IsNullOrWhiteSpace(newName) Then Return

        Dim qtyInput As String = InputBox("Modify Quantity:", , currentQty.ToString())
        Dim newQty As Integer
        If Not Integer.TryParse(qtyInput, newQty) OrElse newQty < 0 Then
            MessageBox.Show("Invalid quantity.")
            Return
        End If

        Dim priceInput As String = InputBox("Modify Price:", , currentPrice.ToString())
        Dim newPrice As Decimal
        If Not Decimal.TryParse(priceInput, newPrice) OrElse newPrice < 0 Then
            MessageBox.Show("Invalid price.")
            Return
        End If

        Dim expDateInput As String = InputBox("Modify Expiration Date (YYYY-MM-DD):", , currentExp.ToString("yyyy-MM-dd"))
        Dim newExp As Date
        If Not Date.TryParse(expDateInput, newExp) Then
            MessageBox.Show("Invalid expiration date.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction = conn.BeginTransaction()

            Dim query As String = "UPDATE Products SET Name = @Name, Quantity = @Quantity, Price = @Price, ExpirationDate = @ExpirationDate WHERE Id = @Id"
            Dim cmd As New SqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@Name", newName)
            cmd.Parameters.AddWithValue("@Quantity", newQty)
            cmd.Parameters.AddWithValue("@Price", newPrice)
            cmd.Parameters.AddWithValue("@ExpirationDate", newExp)
            cmd.Parameters.AddWithValue("@Id", selectedId)

            Try
                cmd.ExecuteNonQuery()
                transaction.Commit()
                MessageBox.Show("Product modified successfully.")
                LoadProducts()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error modifying product: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim selectedId = GetSelectedProductId()
        If selectedId Is Nothing Then
            MessageBox.Show("Please select an item to delete.")
            Return
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to delete product with Id '" & selectedId.ToString() & "'?", "Confirm Delete", MessageBoxButtons.YesNo)
        If confirm = DialogResult.No Then Return

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction = conn.BeginTransaction()

            Dim query As String = "DELETE FROM Products WHERE Id = @Id"
            Dim cmd As New SqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@Id", selectedId)

            Try
                cmd.ExecuteNonQuery()
                transaction.Commit()
                MessageBox.Show("Product deleted successfully.")
                LoadProducts()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error deleting product: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' In embedded mode, Close() simply destroys this child form, returning view to MainMenu
        Me.Close()
    End Sub

    Private Sub ExportToCSV(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "CSV Files|*.csv"
        sfd.FileName = "Inventory_" & DateTime.Now.ToString("yyyyMMdd") & ".csv"
        If sfd.ShowDialog() = DialogResult.OK Then
            Using sw As New System.IO.StreamWriter(sfd.FileName)
                ' Header
                Dim header As New List(Of String)
                For Each col As DataGridViewColumn In dgvProducts.Columns
                    header.Add(col.HeaderText)
                Next
                sw.WriteLine(String.Join(",", header))
                
                ' Rows
                For Each row As DataGridViewRow In dgvProducts.Rows
                    If Not row.IsNewRow Then
                        Dim cells As New List(Of String)
                        For Each cell As DataGridViewCell In row.Cells
                            If cell.Value IsNot Nothing Then
                                cells.Add(cell.Value.ToString())
                            Else
                                cells.Add("")
                            End If
                        Next
                        sw.WriteLine(String.Join(",", cells))
                    End If
                Next
            End Using
            MessageBox.Show("Export successful!")
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
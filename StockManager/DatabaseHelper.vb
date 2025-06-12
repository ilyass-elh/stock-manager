Imports System.Data.SqlClient

Public Module DatabaseHelper
    Public ConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockDB.mdf;Integrated Security=True"

    Public Sub InitializeDatabase()
        Using conn As New SqlConnection(ConnectionString)
            conn.Open()

            ' 1. Add Price column to Products if not exists
            Dim checkPriceCol As String = "IF COL_LENGTH('Products', 'Price') IS NULL ALTER TABLE Products ADD Price DECIMAL(18, 2) DEFAULT 0.00"
            ExecuteNonQuery(checkPriceCol, conn)

            ' 2. Create Suppliers table if not exists
            Dim createSuppliers As String = _
                "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Suppliers' AND xtype='U') " & _
                "CREATE TABLE Suppliers ( " & _
                "Id INT PRIMARY KEY IDENTITY(1,1), " & _
                "Name NVARCHAR(100) NOT NULL, " & _
                "ContactName NVARCHAR(100), " & _
                "Phone NVARCHAR(20), " & _
                "Address NVARCHAR(255) )"
            ExecuteNonQuery(createSuppliers, conn)
        End Using
    End Sub

    Private Sub ExecuteNonQuery(query As String, conn As SqlConnection)
        Using cmd As New SqlCommand(query, conn)
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                ' Log error or ignore if strictly necessary, but for dev we might want to know
                System.Diagnostics.Debug.WriteLine("DB Init Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
End Module

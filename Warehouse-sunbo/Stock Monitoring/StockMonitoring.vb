Imports MySql.Data.MySqlClient
Public Class StockMonitoring
    Private Sub StockMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadall()
        dtpicker1.Value = Date.Now
    End Sub

    Private Sub loadall()
        reload("SELECT lu.partcode AS Partcode, lm.partname, COUNT(lu.id) as 'Boxes', SUM(lu.qty) AS 'TOTAL' FROM logistics_sunbo lu " &
           "JOIN logistics_masterlist lm ON lu.partcode = lm.partcode " &
           "WHERE lu.status = 1 GROUP BY lu.partcode DESC", datagrid1)

        ' Set the Total column to be highlighted
        AddHandler datagrid1.CellFormatting, AddressOf datagrid1_CellFormatting
    End Sub

    Private Sub datagrid1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = datagrid1.Columns("TOTAL").Index Then
            e.CellStyle.BackColor = Color.LightBlue
            e.CellStyle.Font = New Font("Segoe UI", 11)
        End If
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        If Guna2TextBox1.Text = "" Then
            loadall()
        Else
            reload("SELECT lu.partcode AS Partcode,lm.partname,COUNT(lu.id) as 'Boxes', SUM(lu.qty) AS 'TOTAL' FROM logistics_sunbo lu
JOIN logistics_masterlist lm ON lu.partcode=lm.partcode

WHERE lu.status = 1 AND lu.partcode REGEXP '" & Guna2TextBox1.Text & "' 
GROUP BY lu.partcode DESC", datagrid1)
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        exporttoExcel(datagrid1)
    End Sub

    Private Sub dtpicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker1.ValueChanged

        ' Using parameterized query for security
        Dim query As String = "SELECT ps.partcode AS Partcode, pm.partname AS 'Partname', 
                                SUM(CASE WHEN ps.datein IS NOT NULL THEN ps.qty ELSE 0 END) AS 'Total IN',
                                SUM(CASE WHEN ps.dateout IS NOT NULL THEN ps.qty ELSE 0 END) AS 'Total OUT'
                               FROM logistics_sunbo ps
                               JOIN logistics_masterlist pm ON ps.partcode = pm.partcode
                               WHERE ps.datein = @selectedDate
                               GROUP BY ps.partcode, pm.partname"


        Using cmd As New MySqlCommand(query, con)
            ' Add parameter for date
            cmd.Parameters.AddWithValue("@selectedDate", dtpicker1.Value.ToString("yyyy-MM-dd"))
            con.Close()
            ' Open connection
            con.Open()

            ' Execute the query and bind to DataGridView
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                ' Assuming you already have a method to bind the result to datagrid1
                Dim dt As New DataTable()
                dt.Load(reader)
                datagrid2.DataSource = dt
            End Using

        End Using
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        exporttoExcel(datagrid2)
    End Sub
End Class
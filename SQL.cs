Sub Button1_Click()

'Create a connection
    Dim id, email As String
    Dim row As Integer
    Dim connection As New ADODB.connection
  
    With Sheets("Sheet1")
'        Connection to SQL Server
        connection.Open "Provider=SQLOLEDB;Data Source=.;Initial Catalog=Adventureworks2019;Integrated Security=SSPI;"
'        Start in the second row because row 1 is the header
        row = 2
            
'Run until the row is empty
        Do Until IsEmpty(Cells(row, 1))
'        Get the id from column 1 and the row is dynamic
            oldValue = .Cells(row, 1)
'            Get the email from column 2 and the row is dynamic
            newValue = .Cells(row, 2)
               
'          update the cell values into the email table
            connection.Execute "UPDATE MyTable SET FieldNameY = '" & newValue & "' WHERE FieldNameY = '" & oldValue & "' "
            
' increase the row by 1
            row = row + 1
        Loop
                
'   Close and clean the connection
        connection.Close
        Set connection = Nothing
             
    End With
 

End Sub


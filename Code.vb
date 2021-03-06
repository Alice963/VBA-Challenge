Sub Stock_Analysis()

Dim ws As Worksheet

For Each ws In Worksheets

ws.Cells(1, 8).Value = "Ticker"
ws.Cells(1, 9).Value = "Yearly Change "
ws.Cells(1, 10).Value = "Percent Change"
ws.Cells(1, 11).Value = "Total Stock Volume"

Dim ticker_symbol As String
Dim total_vol As Double
total_vol = 0
Dim rowcount As Long
rowcount = 2
Dim year_open As Double
year_open = 0
Dim year_close As Double
year_close = 0
Dim year_change As Double
year_change = 0
Dim percent_chang As Double
percent_change = 0
Dim lastrow As Long
lastrow = ws.Cells(Rows.Count, 1).End(xlUp).Row
For i = 2 To lastrow
If ws.Cells(i, 1).Value <> ws.Cells(i - 1, 1).Value Then
year_open = ws.Cells(i, 3).Value
End If
total_vol = total_vol + ws.Cells(i, 7)
If ws.Cells(i, 1).Value <> ws.Cells(i + 1, 1).Value Then
ws.Cells(rowcount, 8).Value = ws.Cells(i, 1).Value
ws.Cells(rowcount, 11).Value = total_vol
year_close = ws.Cells(i, 6).Value
year_change = year_close - year_open
ws.Cells(rowcount, 9).Value = year_change
If year_change >= 0 Then
ws.Cells(rowcount, 9).Interior.ColorIndex = 4
Else
ws.Cells(rowcount, 9).Interior.ColorIndex = 3

End If

If year_open = 0 And year_close = 0 Then
percent_change = 0
ws.Cells(rowcount, 10).Value = percent_change
ws.Cells(rowcount, 10).NumberFormat = "0.00%"

ElseIf year_open = 0 Then
Dim percent_change_NA As String
percent_change_NA = "New Stock"
ws.Cells(rowcount, 10).Value = percent_change

Else
percent_change = year_change / year_open
ws.Cells(rowcount, 10).Value = percent_change
ws.Cells(rowcount, 10).NumberFormat = "0.00%"

End If

rowcount = rowcount + 1
total_vol = 0
year_open = 0
year_close = 0
year_change = 0
percent_change = 0

End If

Next i
ws.Cells(2, 14).Value = "Greatest % Increase"
ws.Cells(3, 14).Value = "Greatest  % Decrease"
ws.Cells(4, 14).Value = "Greatest Total Volume"
ws.Cells(1, 15).Value = "Ticker"
ws.Cells(1, 16).Value = "Value"

lastrow = ws.Cells(Rows.Count, 9).End(xlUp).Row

Dim best_stock As String
Dim best_value As Double

best_value = ws.Cells(2, 10).Value

Dim worst_stock As String
Dim worst_value As Double

worst_value = ws.Cells(2, 10).Value

Dim most_vol_stock As String
Dim most_vol_value As Double

most_vol_value = ws.Cells(2, 11).Value

For j = 2 To lastrow

If ws.Cells(j, 10).Value > best_value Then
best_value = ws.Cells(j, 10).Value
best_stock = ws.Cells(j, 8).Value

End If

If ws.Cells(j, 10).Value < worst_value Then
worst_value = ws.Cells(j, 10).Value
worst_stock = ws.Cells(j, 8).Value

End If

If ws.Cells(j, 11).Value > most_vol_value Then
most_vol_value = ws.Cells(j, 11).Value
most_vol_stock = ws.Cells(j, 8).Value

End If
Next j

ws.Cells(2, 15).Value = best_stock
ws.Cells(2, 16).Value = best_value
ws.Cells(2, 16).NumberFormat = "0.00%"
ws.Cells(3, 15).Value = worst_stock
ws.Cells(3, 16).Value = worst_value
ws.Cells(3, 16).NumberFormat = "0.00%"
ws.Cells(4, 15).Value = most_vol_stock
ws.Cells(4, 16).Value = most_vol_value

ws.Columns("I:L").EntireColumn.AutoFit
ws.Columns("O:Q").EntireColumn.AutoFit



Next ws
End Sub

'Imports Microsoft.Office.Core
Imports Microsoft.VisualBasic.ControlChars
Imports System
Imports System.IO

Public Module Export

#Region "Excel"

    Public Sub ExportacionExcel(ByVal DataTable As DataTable)
        'If DataTable.Rows.Count > 0 Then
        '    Dim objApp As Excel.Application
        '    Dim objBook As Excel._Workbook

        '    Dim objBooks As Excel.Workbooks
        '    Dim objSheets As Excel.Sheets
        '    Dim objSheet As Excel._Worksheet
        '    Dim range As Excel.Range

        '    ' Create a new instance of Excel and start a new workbook.
        '    objApp = New Excel.Application()
        '    objBooks = objApp.Workbooks
        '    objBook = objBooks.Add
        '    objSheets = objBook.Worksheets
        '    objSheet = DirectCast(objSheets(1), Excel.Worksheet)

        '    Dim dr As DataRow, dc As DataColumn
        '    Dim row, col As Integer

        '    'Genera el titulo de la hoja (Celda "A1")
        '    range = DirectCast(objSheet.Cells(1, 1), Excel.Range)
        '    range.Value = DataTable.TableName

        '    'Genera los titulos de las columnas
        '    col = 1
        '    For Each dc In DataTable.Columns
        '        range = DirectCast(objSheet.Cells(2, col), Excel.Range)
        '        range.Value = dc.ColumnName
        '        col += 1
        '    Next

        '    'Genera el contenido
        '    row = 3
        '    For Each dr In DataTable.Rows
        '        col = 1
        '        For Each dc In DataTable.Columns
        '            range = DirectCast(objSheet.Cells(row, col), Excel.Range)
        '            range.Value = dr.Item(dc.ColumnName)
        '            col += 1
        '        Next
        '        row += 1
        '    Next

        '    ''voy a tratar de ponerle un autofiltro
        '    'range = DirectCast(objSheet.Rows(3), Excel.Range)
        '    'range.EntireRow.AutoFilter()



        '    'Return control of Excel to the user.
        '    objApp.Visible = True
        '    objApp.UserControl = True

        '    'Clean up a little.
        '    range = Nothing
        '    objSheet = Nothing
        '    objSheets = Nothing
        '    objBooks = Nothing
        'End If
    End Sub

#End Region

#Region "TextFiles"

    Public Function ExportacionTextoPlano(ByVal DataTable As DataTable, ByVal FileName As String, _
                                          ByVal Separator As Char, ByVal Header As Boolean) As Boolean
        'genera un archivo de texto
        Dim successFulExport As Boolean, _
            sw As StreamWriter = Nothing, _
            dr As DataRow, dc As DataColumn, _
            textLine As String = Nothing
        Try
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If
            sw = New StreamWriter(FileName)
            If Header Then
                'Encabezado del archivo
                sw.WriteLine(DataTable.TableName)
                'Encabezado de columnas
                For Each dc In DataTable.Columns
                    textLine &= dc.ColumnName & Separator
                Next
                sw.WriteLine(textLine)
                textLine = Nothing
            End If
            'Genera el contenido
            For Each dr In DataTable.Rows
                For Each dc In DataTable.Columns
                    textLine &= CType(IIf(dr.Item(dc.ColumnName) Is DBNull.Value, String.Empty, dr.Item(dc.ColumnName)), _
                            String) & Separator
                Next
                sw.WriteLine(textLine)
                textLine = Nothing
            Next
            successFulExport = True
        Catch ex As IOException
            successFulExport = False
            Throw ex
        Catch ex As Exception
            successFulExport = False
            Throw ex
        Finally
            sw.Close()
        End Try
        Return successFulExport
    End Function

#End Region

End Module

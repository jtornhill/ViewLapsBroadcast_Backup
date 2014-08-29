Imports System.Net
Imports System.IO
Imports System.Configuration
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module JSON
    'Dim url As String = "http://localhost:3000/api/"
    'Dim url As String = "http://54.229.151.103:8099/api/"
    'Dim url As String = "http://viewlaps.nu/api/"
    Dim url As String = My.Settings.URL
    Public ApplicationError As String = ""

    Private Function GetJSONString(pHeader As String, pId As String) As String
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader



        Try
            ApplicationError = ""
            If pId.Length > 1 Then
                request = DirectCast(WebRequest.Create(url & pHeader & "/" & pId & ".json"), HttpWebRequest)
            Else
                request = DirectCast(WebRequest.Create(url & pHeader & "/"), HttpWebRequest)
            End If

            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim jsonText As String
            jsonText = reader.ReadToEnd()

            ' if starts with an array then it is the first list of events, so adding "events" as object
            If jsonText.StartsWith("[") Then
                jsonText = String.Concat("{", """", pHeader, """", ":", jsonText, "}")
            End If

            GetJSONString = jsonText
        Catch ex As Exception
            ApplicationError = ex.ToString()
            GetJSONString = ""
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

    End Function

    Public Function GetJSONDictionary(pHeader As String, pListId As String, pId As String, pItems As List(Of String), pOrderByItem As String, Optional pIdName As String = "id", Optional pSubListId As String = "", Optional pSubItems As List(Of String) = Nothing) As Dictionary(Of String, String)
        Dim response As HttpWebResponse = Nothing
        Dim jsonText As String
        Dim resultRow As String = ""
        Dim dict As New Dictionary(Of String, String)


        Try
            ApplicationError = ""
            jsonText = GetJSONString(pHeader, pId)

            ' use LINQ via JSON.NET:
            Dim jResults As JObject = JObject.Parse(jsonText)

            Dim jq = From row In jResults(pListId).Children() Order By row(pOrderByItem)

            For Each rowName In jq


                If pItems.Count > 1 Then
                    For Each pItem In pItems
                        If resultRow.Length > 0 Then
                            If pItem = "start_time" Then 'Formattera om till läsligt format
                                resultRow = String.Concat(resultRow, vbTab, CDate(rowName.Item(pItem)))
                            Else
                                resultRow = String.Concat(resultRow, vbTab, rowName.Item(pItem))
                            End If
                        Else
                            Select Case UCase(pItem)
                                Case "TITLE"
                                    resultRow = (rowName.Item(pItem).ToString & Space(15)).Substring(0, 15)

                                Case Else
                                    resultRow = rowName.Item(pItem)
                            End Select

                        End If

                    Next
                Else
                    resultRow = rowName.Item(pItems.Item(0)).ToString
                End If

                'If I need to add a sub list to parent list (like contestants to canoes) I have the possibility to that directly now.
                If pSubListId.Length > 0 Then
                    If Not pSubItems Is Nothing Then
                        For Each subRow In rowName(pSubListId).Children()
                            For Each pSubItem In pSubItems
                                resultRow = String.Concat(resultRow, vbTab, subRow.Item(pSubItem))
                            Next
                        Next
                    End If
                End If
                dict.Add(rowName.Item(pIdName), resultRow)
                resultRow = ""
            Next

            GetJSONDictionary = dict

        Catch ex As Exception
            ApplicationError = ex.ToString()
            GetJSONDictionary = Nothing
        End Try
    End Function
End Module

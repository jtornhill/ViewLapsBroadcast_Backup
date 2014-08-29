
Public Class FrmMain
    Dim ActiveChannel As String
    Dim FormChannelA As FrmChannelA
    Dim FormChannelB As FrmChannelB

    Private Sub ActivateListType(sender As Object, e As EventArgs) Handles PictureBoxList.Click, PictureBoxLive.Click, ListBoxList.Click, ListBoxRace.Click, ListBoxCameraPlace.Click, LblRace.Click, LblList.Click, LblCameraPlace.Click
        Dim pCtrlName As New Control

        pCtrlName = sender
        Select Case pCtrlName.Name.ToUpper
            'Just the upper selection is named... rest will automatically be lower selection
            Case "PICTUREBOXLIST", "LISTBOXLIST", "LBLRACE", "LISTBOXRACE", "LBLLIST"
                Me.PictureBoxList.Image = My.Resources.back_enabled
                Me.PictureBoxLive.Image = My.Resources.back_disabled
                Me.ListBoxCameraPlace.BackColor = Color.CornflowerBlue
                Me.ListBoxRace.BackColor = Color.RoyalBlue
                Me.ListBoxList.BackColor = Color.RoyalBlue
                Me.LabelLive.ForeColor = Color.Gray
                Me.LabelResult.ForeColor = Color.Black
            Case Else
                Me.PictureBoxLive.Image = My.Resources.back_enabled
                Me.PictureBoxList.Image = My.Resources.back_disabled
                Me.ListBoxCameraPlace.BackColor = Color.RoyalBlue
                Me.ListBoxRace.BackColor = Color.CornflowerBlue
                Me.ListBoxList.BackColor = Color.CornflowerBlue
                Me.LabelLive.ForeColor = Color.Black
                Me.LabelResult.ForeColor = Color.Gray
        End Select

    End Sub

    Private Sub BtnStopA_Click(sender As Object, e As EventArgs) Handles BtnStopA.Click
        BtnState("A", False)
    End Sub
    Private Sub BtnStopB_Click(sender As Object, e As EventArgs) Handles BtnStopB.Click
        BtnState("B", False)
    End Sub
    Private Sub BtnTransferA_Click(sender As Object, e As EventArgs) Handles BtnTransferA.Click
        BtnState("A", True)
    End Sub
    Private Sub BtnTransferB_Click(sender As Object, e As EventArgs) Handles BtnTransferB.Click
        BtnState("B", True)
    End Sub
    Private Sub PictureBoxChannelA_Click(sender As Object, e As EventArgs) Handles PictureBoxChannelA.Click
        ActiveChannel = "A"
        ActivateChannel()
    End Sub
    Private Sub PictureBoxChannelB_Click(sender As Object, e As EventArgs) Handles PictureBoxChannelB.Click
        ActiveChannel = "B"
        ActivateChannel()
    End Sub

    Private Sub BtnState(pChannel As String, pTransferFlag As Boolean)

        If pChannel.ToUpper = "A" Then
            ActiveChannel = "A"
            ActivateChannel()
            If pTransferFlag = True Then
                BtnTransferA.Image = My.Resources.play_enabled
                BtnStopA.Image = My.Resources.stop_disabled
                FormChannelA = New FrmChannelA
                FormChannelA.Show()
            Else
                BtnTransferA.Image = My.Resources.play_disabled
                BtnStopA.Image = My.Resources.stop_enabled
                FormChannelA.Dispose()
            End If
        Else
            ActiveChannel = "B"
            ActivateChannel()
            If pTransferFlag = True Then
                BtnTransferB.Image = My.Resources.play_enabled
                BtnStopB.Image = My.Resources.stop_disabled
                FormChannelB = New FrmChannelB
                FormChannelB.Show()
            Else
                BtnTransferB.Image = My.Resources.play_disabled
                BtnStopB.Image = My.Resources.stop_enabled
                FormChannelB.Dispose()
            End If
        End If

    End Sub

    Private Sub ActivateChannel()
        If ActiveChannel = "A" Then
            BtnTransferA.BackColor = Color.RoyalBlue
            BtnStopA.BackColor = Color.RoyalBlue
            BtnTransferB.BackColor = Color.Transparent
            BtnStopB.BackColor = Color.Transparent
            PictureBoxChannelA.Image = My.Resources.back_buttons_enabled
            PictureBoxChannelB.Image = My.Resources.back_buttons_disabled
            LabelChannelA.ForeColor = Color.Black
            LabelChannelB.ForeColor = Color.Gray
        Else
            BtnTransferB.BackColor = Color.RoyalBlue
            BtnStopB.BackColor = Color.RoyalBlue
            BtnTransferA.BackColor = Color.Transparent
            BtnStopA.BackColor = Color.Transparent
            PictureBoxChannelB.Image = My.Resources.back_buttons_enabled
            PictureBoxChannelA.Image = My.Resources.back_buttons_disabled
            LabelChannelA.ForeColor = Color.Gray
            LabelChannelB.ForeColor = Color.Black
        End If
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MyList As New List(Of String)

        Me.Location = New Point(0, 0)


        'Add events from database
        MyList.Add("title")
        ComboBoxEvents.DisplayMember = "Value"
        ComboBoxEvents.ValueMember = "Key"
        ComboBoxEvents.DataSource = New BindingSource(GetJSONDictionary("competitions", "competitions", "", MyList, "title"), Nothing)
        'Fill raceList
        FillRaceList()

    End Sub



    
    Private Sub ComboBoxEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEvents.SelectedIndexChanged
        FillRaceList()
    End Sub

    Private Sub FillRaceList()

        Try
            Dim MyList As New List(Of String)

            If Not Me.ComboBoxEvents.SelectedValue Is Nothing Then
                'Add races from database


                MyList.Add("title")
                MyList.Add("start_time")
                MyList.Add("status")

                ListBoxRace.DisplayMember = "Value"
                ListBoxRace.ValueMember = "Key"
                ListBoxRace.DataSource = New BindingSource(GetJSONDictionary("competitions", "races", Me.ComboBoxEvents.SelectedValue.ToString, MyList, "start_time"), Nothing)
                ''ListBoxRace.DataSource = New BindingSource(GetRaces(Me.ComboBoxEvents.SelectedValue), Nothing)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function GetStartList() As Dictionary(Of String, String)
        Try
            Dim CanoeList As New List(Of String)
            Dim ContestantList As New List(Of String)

            Dim StartListDict As New Dictionary(Of String, String)

            If Not Me.ListBoxRace.SelectedValue Is Nothing Then

                'add the canoes columns for the start

                CanoeList.Add("number")
                CanoeList.Add("nation")

                'Add contestants columns (used as a sub list for canoes)

                ContestantList.Add("number")
                ContestantList.Add("last_name")
                ContestantList.Add("first_name")

                'Fetch the StartList
                GetStartList = GetJSONDictionary("races", "canoes", Me.ListBoxRace.SelectedValue.ToString, CanoeList, "number", "number", "contestants", ContestantList)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub ListBoxList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxList.SelectedIndexChanged
        GetStartList()
    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.LblRace = New System.Windows.Forms.Label()
        Me.ListBoxList = New System.Windows.Forms.ListBox()
        Me.ListBoxRace = New System.Windows.Forms.ListBox()
        Me.ListBoxCameraPlace = New System.Windows.Forms.ListBox()
        Me.LblList = New System.Windows.Forms.Label()
        Me.LblCameraPlace = New System.Windows.Forms.Label()
        Me.LabelResult = New System.Windows.Forms.Label()
        Me.LabelLive = New System.Windows.Forms.Label()
        Me.LabelChannelA = New System.Windows.Forms.Label()
        Me.LabelChannelB = New System.Windows.Forms.Label()
        Me.BtnTransferB = New System.Windows.Forms.Button()
        Me.BtnStopB = New System.Windows.Forms.Button()
        Me.PictureBoxChannelB = New System.Windows.Forms.PictureBox()
        Me.BtnStopA = New System.Windows.Forms.Button()
        Me.BtnTransferA = New System.Windows.Forms.Button()
        Me.PictureBoxChannelA = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxList = New System.Windows.Forms.PictureBox()
        Me.PictureBoxLive = New System.Windows.Forms.PictureBox()
        Me.ComboBoxEvents = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBoxChannelB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxChannelA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxLive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblRace
        '
        Me.LblRace.AutoSize = True
        Me.LblRace.BackColor = System.Drawing.Color.RoyalBlue
        Me.LblRace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblRace.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblRace.Location = New System.Drawing.Point(52, 71)
        Me.LblRace.Name = "LblRace"
        Me.LblRace.Size = New System.Drawing.Size(35, 15)
        Me.LblRace.TabIndex = 2
        Me.LblRace.Text = "Race"
        '
        'ListBoxList
        '
        Me.ListBoxList.BackColor = System.Drawing.Color.RoyalBlue
        Me.ListBoxList.ForeColor = System.Drawing.Color.White
        Me.ListBoxList.FormattingEnabled = True
        Me.ListBoxList.Items.AddRange(New Object() {"Start list", "Passage 5 km", "Passage 10 km", "Passage 15 km", "Result list"})
        Me.ListBoxList.Location = New System.Drawing.Point(491, 87)
        Me.ListBoxList.Name = "ListBoxList"
        Me.ListBoxList.Size = New System.Drawing.Size(230, 186)
        Me.ListBoxList.TabIndex = 1
        '
        'ListBoxRace
        '
        Me.ListBoxRace.BackColor = System.Drawing.Color.RoyalBlue
        Me.ListBoxRace.ForeColor = System.Drawing.Color.White
        Me.ListBoxRace.FormattingEnabled = True
        Me.ListBoxRace.Location = New System.Drawing.Point(55, 87)
        Me.ListBoxRace.Name = "ListBoxRace"
        Me.ListBoxRace.Size = New System.Drawing.Size(364, 186)
        Me.ListBoxRace.TabIndex = 0
        '
        'ListBoxCameraPlace
        '
        Me.ListBoxCameraPlace.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ListBoxCameraPlace.ForeColor = System.Drawing.Color.White
        Me.ListBoxCameraPlace.FormattingEnabled = True
        Me.ListBoxCameraPlace.Items.AddRange(New Object() {"boya No 1", "boya No 2", "boya No 3", "boya No 4"})
        Me.ListBoxCameraPlace.Location = New System.Drawing.Point(52, 481)
        Me.ListBoxCameraPlace.Name = "ListBoxCameraPlace"
        Me.ListBoxCameraPlace.Size = New System.Drawing.Size(230, 186)
        Me.ListBoxCameraPlace.TabIndex = 1
        '
        'LblList
        '
        Me.LblList.AutoSize = True
        Me.LblList.BackColor = System.Drawing.Color.RoyalBlue
        Me.LblList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblList.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblList.Location = New System.Drawing.Point(491, 71)
        Me.LblList.Name = "LblList"
        Me.LblList.Size = New System.Drawing.Size(60, 15)
        Me.LblList.TabIndex = 8
        Me.LblList.Text = "Type of list"
        '
        'LblCameraPlace
        '
        Me.LblCameraPlace.AutoSize = True
        Me.LblCameraPlace.BackColor = System.Drawing.Color.RoyalBlue
        Me.LblCameraPlace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCameraPlace.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblCameraPlace.Location = New System.Drawing.Point(52, 463)
        Me.LblCameraPlace.Name = "LblCameraPlace"
        Me.LblCameraPlace.Size = New System.Drawing.Size(97, 15)
        Me.LblCameraPlace.TabIndex = 9
        Me.LblCameraPlace.Text = "Camera placement"
        '
        'LabelResult
        '
        Me.LabelResult.AutoSize = True
        Me.LabelResult.BackColor = System.Drawing.Color.Transparent
        Me.LabelResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelResult.ForeColor = System.Drawing.Color.Black
        Me.LabelResult.Location = New System.Drawing.Point(305, 9)
        Me.LabelResult.Name = "LabelResult"
        Me.LabelResult.Size = New System.Drawing.Size(158, 33)
        Me.LabelResult.TabIndex = 10
        Me.LabelResult.Text = "Result lists"
        '
        'LabelLive
        '
        Me.LabelLive.AutoSize = True
        Me.LabelLive.BackColor = System.Drawing.Color.Transparent
        Me.LabelLive.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLive.ForeColor = System.Drawing.Color.Gray
        Me.LabelLive.Location = New System.Drawing.Point(161, 393)
        Me.LabelLive.Name = "LabelLive"
        Me.LabelLive.Size = New System.Drawing.Size(397, 33)
        Me.LabelLive.TabIndex = 11
        Me.LabelLive.Text = "Current result at camera view"
        '
        'LabelChannelA
        '
        Me.LabelChannelA.AutoSize = True
        Me.LabelChannelA.BackColor = System.Drawing.Color.Transparent
        Me.LabelChannelA.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelChannelA.ForeColor = System.Drawing.Color.Gray
        Me.LabelChannelA.Location = New System.Drawing.Point(921, 9)
        Me.LabelChannelA.Name = "LabelChannelA"
        Me.LabelChannelA.Size = New System.Drawing.Size(150, 33)
        Me.LabelChannelA.TabIndex = 21
        Me.LabelChannelA.Text = "Channel A"
        '
        'LabelChannelB
        '
        Me.LabelChannelB.AutoSize = True
        Me.LabelChannelB.BackColor = System.Drawing.Color.Transparent
        Me.LabelChannelB.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelChannelB.ForeColor = System.Drawing.Color.Gray
        Me.LabelChannelB.Location = New System.Drawing.Point(921, 393)
        Me.LabelChannelB.Name = "LabelChannelB"
        Me.LabelChannelB.Size = New System.Drawing.Size(150, 33)
        Me.LabelChannelB.TabIndex = 22
        Me.LabelChannelB.Text = "Channel B"
        '
        'BtnTransferB
        '
        Me.BtnTransferB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTransferB.Image = CType(resources.GetObject("BtnTransferB.Image"), System.Drawing.Image)
        Me.BtnTransferB.Location = New System.Drawing.Point(878, 602)
        Me.BtnTransferB.Name = "BtnTransferB"
        Me.BtnTransferB.Size = New System.Drawing.Size(245, 139)
        Me.BtnTransferB.TabIndex = 4
        Me.BtnTransferB.Text = "Transfer (Start sending selected overlay)"
        Me.BtnTransferB.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnTransferB.UseVisualStyleBackColor = True
        '
        'BtnStopB
        '
        Me.BtnStopB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStopB.Image = Global.CanixMix.My.Resources.Resources.stop_enabled
        Me.BtnStopB.Location = New System.Drawing.Point(878, 459)
        Me.BtnStopB.Name = "BtnStopB"
        Me.BtnStopB.Size = New System.Drawing.Size(245, 139)
        Me.BtnStopB.TabIndex = 13
        Me.BtnStopB.Text = "Stop (No overlay)"
        Me.BtnStopB.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnStopB.UseVisualStyleBackColor = True
        '
        'PictureBoxChannelB
        '
        Me.PictureBoxChannelB.Image = Global.CanixMix.My.Resources.Resources.back_buttons_disabled
        Me.PictureBoxChannelB.Location = New System.Drawing.Point(843, 429)
        Me.PictureBoxChannelB.Name = "PictureBoxChannelB"
        Me.PictureBoxChannelB.Size = New System.Drawing.Size(322, 335)
        Me.PictureBoxChannelB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxChannelB.TabIndex = 20
        Me.PictureBoxChannelB.TabStop = False
        '
        'BtnStopA
        '
        Me.BtnStopA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStopA.BackColor = System.Drawing.Color.Transparent
        Me.BtnStopA.Image = Global.CanixMix.My.Resources.Resources.stop_enabled
        Me.BtnStopA.Location = New System.Drawing.Point(878, 71)
        Me.BtnStopA.Name = "BtnStopA"
        Me.BtnStopA.Size = New System.Drawing.Size(245, 139)
        Me.BtnStopA.TabIndex = 13
        Me.BtnStopA.Text = "Stop (No overlay)"
        Me.BtnStopA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnStopA.UseVisualStyleBackColor = False
        '
        'BtnTransferA
        '
        Me.BtnTransferA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTransferA.Image = CType(resources.GetObject("BtnTransferA.Image"), System.Drawing.Image)
        Me.BtnTransferA.Location = New System.Drawing.Point(878, 216)
        Me.BtnTransferA.Name = "BtnTransferA"
        Me.BtnTransferA.Size = New System.Drawing.Size(245, 139)
        Me.BtnTransferA.TabIndex = 4
        Me.BtnTransferA.Text = "Transfer (Start sending selected overlay)"
        Me.BtnTransferA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnTransferA.UseVisualStyleBackColor = True
        '
        'PictureBoxChannelA
        '
        Me.PictureBoxChannelA.Image = Global.CanixMix.My.Resources.Resources.back_buttons_disabled
        Me.PictureBoxChannelA.Location = New System.Drawing.Point(843, 45)
        Me.PictureBoxChannelA.Name = "PictureBoxChannelA"
        Me.PictureBoxChannelA.Size = New System.Drawing.Size(322, 335)
        Me.PictureBoxChannelA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxChannelA.TabIndex = 19
        Me.PictureBoxChannelA.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CanixMix.My.Resources.Resources.LW_Centr_CMYK
        Me.PictureBox1.Location = New System.Drawing.Point(12, 770)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(235, 105)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'PictureBoxList
        '
        Me.PictureBoxList.Image = CType(resources.GetObject("PictureBoxList.Image"), System.Drawing.Image)
        Me.PictureBoxList.Location = New System.Drawing.Point(12, 45)
        Me.PictureBoxList.Name = "PictureBoxList"
        Me.PictureBoxList.Size = New System.Drawing.Size(800, 335)
        Me.PictureBoxList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxList.TabIndex = 6
        Me.PictureBoxList.TabStop = False
        '
        'PictureBoxLive
        '
        Me.PictureBoxLive.Image = CType(resources.GetObject("PictureBoxLive.Image"), System.Drawing.Image)
        Me.PictureBoxLive.Location = New System.Drawing.Point(12, 429)
        Me.PictureBoxLive.Name = "PictureBoxLive"
        Me.PictureBoxLive.Size = New System.Drawing.Size(800, 335)
        Me.PictureBoxLive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBoxLive.TabIndex = 7
        Me.PictureBoxLive.TabStop = False
        '
        'ComboBoxEvents
        '
        Me.ComboBoxEvents.FormattingEnabled = True
        Me.ComboBoxEvents.Location = New System.Drawing.Point(267, 806)
        Me.ComboBoxEvents.Name = "ComboBoxEvents"
        Me.ComboBoxEvents.Size = New System.Drawing.Size(276, 21)
        Me.ComboBoxEvents.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(264, 790)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Please! Check so that you are running the current event!"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1177, 878)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxEvents)
        Me.Controls.Add(Me.LabelChannelB)
        Me.Controls.Add(Me.LabelChannelA)
        Me.Controls.Add(Me.BtnTransferB)
        Me.Controls.Add(Me.BtnStopB)
        Me.Controls.Add(Me.PictureBoxChannelB)
        Me.Controls.Add(Me.BtnStopA)
        Me.Controls.Add(Me.BtnTransferA)
        Me.Controls.Add(Me.PictureBoxChannelA)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LabelLive)
        Me.Controls.Add(Me.LabelResult)
        Me.Controls.Add(Me.LblCameraPlace)
        Me.Controls.Add(Me.LblList)
        Me.Controls.Add(Me.LblRace)
        Me.Controls.Add(Me.ListBoxCameraPlace)
        Me.Controls.Add(Me.ListBoxList)
        Me.Controls.Add(Me.ListBoxRace)
        Me.Controls.Add(Me.PictureBoxList)
        Me.Controls.Add(Me.PictureBoxLive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMain"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Tracks Overlay"
        CType(Me.PictureBoxChannelB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxChannelA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxLive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblRace As System.Windows.Forms.Label
    Friend WithEvents ListBoxList As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxRace As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxCameraPlace As System.Windows.Forms.ListBox
    Friend WithEvents BtnTransferA As System.Windows.Forms.Button
    Friend WithEvents PictureBoxList As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxLive As System.Windows.Forms.PictureBox
    Friend WithEvents LblList As System.Windows.Forms.Label
    Friend WithEvents LblCameraPlace As System.Windows.Forms.Label
    Friend WithEvents LabelResult As System.Windows.Forms.Label
    Friend WithEvents LabelLive As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnStopA As System.Windows.Forms.Button
    Friend WithEvents BtnStopB As System.Windows.Forms.Button
    Friend WithEvents BtnTransferB As System.Windows.Forms.Button
    Friend WithEvents PictureBoxChannelA As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxChannelB As System.Windows.Forms.PictureBox
    Friend WithEvents LabelChannelA As System.Windows.Forms.Label
    Friend WithEvents LabelChannelB As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEvents As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

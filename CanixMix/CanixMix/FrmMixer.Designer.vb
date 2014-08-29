<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMixer
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
        Me.components = New System.ComponentModel.Container()
        Dim SinkPin1 As OpenWire.Proxy.SinkPin = New OpenWire.Proxy.SinkPin()
        Dim DsvlAudioOutputDevice1 As Mitov.VideoLab.DSVLAudioOutputDevice = New Mitov.VideoLab.DSVLAudioOutputDevice()
        Dim SourcePin1 As OpenWire.Proxy.SourcePin = New OpenWire.Proxy.SourcePin()
        Dim DvFormat1 As Mitov.VideoLab.DVFormat = New Mitov.VideoLab.DVFormat()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMixer))
        Dim DsGraph1 As Mitov.AudioLab.DSGraph = New Mitov.AudioLab.DSGraph()
        Dim SourcePin2 As OpenWire.Proxy.SourcePin = New OpenWire.Proxy.SourcePin()
        Dim SinkPin2 As OpenWire.Proxy.SinkPin = New OpenWire.Proxy.SinkPin()
        Dim MasterPumping1 As Mitov.BasicLab.MasterPumping = New Mitov.BasicLab.MasterPumping()
        Dim DsVideoOutputDevice1 As Mitov.VideoLab.DSVideoOutputDevice = New Mitov.VideoLab.DSVideoOutputDevice()
        Dim SinkPin3 As OpenWire.Proxy.SinkPin = New OpenWire.Proxy.SinkPin()
        Dim SinkPin4 As OpenWire.Proxy.SinkPin = New OpenWire.Proxy.SinkPin()
        Dim SourcePin3 As OpenWire.Proxy.SourcePin = New OpenWire.Proxy.SourcePin()
        Dim Transparency1 As Mitov.VideoLab.Transparency = New Mitov.VideoLab.Transparency()
        Me.LabelPreview = New System.Windows.Forms.Label()
        Me.LabelLive = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxEvents = New System.Windows.Forms.ComboBox()
        Me.LblRace = New System.Windows.Forms.Label()
        Me.ListBoxRace = New System.Windows.Forms.ListBox()
        Me.LblList = New System.Windows.Forms.Label()
        Me.ListBoxList = New System.Windows.Forms.ListBox()
        Me.RadioButtonViewStartList = New System.Windows.Forms.RadioButton()
        Me.RadioButtonViewPassages = New System.Windows.Forms.RadioButton()
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAnimation = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBoxAnimate = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnSaveGraphicStartList = New System.Windows.Forms.Button()
        Me.CboGraphTemplateStartList = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboAlignmentStartList = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumColumnsStartList = New System.Windows.Forms.NumericUpDown()
        Me.NumMaxRowsStartList = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumOpacityStartList = New System.Windows.Forms.NumericUpDown()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnSaveGraphicPassages = New System.Windows.Forms.Button()
        Me.CboGraphTemplatePassages = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CboAlignmentPassages = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NumColumnsPassages = New System.Windows.Forms.NumericUpDown()
        Me.NumMaxRowsPassages = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NumOpacityPassages = New System.Windows.Forms.NumericUpDown()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ChkFreeze = New System.Windows.Forms.CheckBox()
        Me.PictureBoxBackColor = New System.Windows.Forms.PictureBox()
        Me.ButtonStatus = New System.Windows.Forms.Button()
        Me.ButtonEndLive = New System.Windows.Forms.Button()
        Me.ButtonToLive = New System.Windows.Forms.Button()
        Me.PictureBoxLive = New System.Windows.Forms.PictureBox()
        Me.PictureBoxPreview = New System.Windows.Forms.PictureBox()
        Me.ChkBigPicture = New System.Windows.Forms.CheckBox()
        Me.DsVideoOut1 = New Mitov.VideoLab.DSVideoOut(Me.components)
        Me.ImageGen1 = New Mitov.VideoLab.ImageGen(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumColumnsStartList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumMaxRowsStartList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumOpacityStartList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumColumnsPassages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumMaxRowsPassages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumOpacityPassages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxBackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxLive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsVideoOut1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageGen1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelPreview
        '
        Me.LabelPreview.AutoSize = True
        Me.LabelPreview.BackColor = System.Drawing.Color.Transparent
        Me.LabelPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPreview.ForeColor = System.Drawing.Color.Black
        Me.LabelPreview.Location = New System.Drawing.Point(277, 39)
        Me.LabelPreview.Name = "LabelPreview"
        Me.LabelPreview.Size = New System.Drawing.Size(119, 33)
        Me.LabelPreview.TabIndex = 11
        Me.LabelPreview.Text = "Preview"
        '
        'LabelLive
        '
        Me.LabelLive.AutoSize = True
        Me.LabelLive.BackColor = System.Drawing.Color.Transparent
        Me.LabelLive.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLive.ForeColor = System.Drawing.Color.Black
        Me.LabelLive.Location = New System.Drawing.Point(1187, 39)
        Me.LabelLive.Name = "LabelLive"
        Me.LabelLive.Size = New System.Drawing.Size(69, 33)
        Me.LabelLive.TabIndex = 12
        Me.LabelLive.Text = "Live"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(661, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Please! Check so that you are running the current event!"
        '
        'ComboBoxEvents
        '
        Me.ComboBoxEvents.FormattingEnabled = True
        Me.ComboBoxEvents.Location = New System.Drawing.Point(664, 39)
        Me.ComboBoxEvents.Name = "ComboBoxEvents"
        Me.ComboBoxEvents.Size = New System.Drawing.Size(276, 21)
        Me.ComboBoxEvents.TabIndex = 25
        '
        'LblRace
        '
        Me.LblRace.AutoSize = True
        Me.LblRace.BackColor = System.Drawing.SystemColors.Control
        Me.LblRace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblRace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblRace.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRace.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblRace.Location = New System.Drawing.Point(12, 453)
        Me.LblRace.Name = "LblRace"
        Me.LblRace.Size = New System.Drawing.Size(144, 22)
        Me.LblRace.TabIndex = 28
        Me.LblRace.Text = "Select Race for list"
        '
        'ListBoxRace
        '
        Me.ListBoxRace.BackColor = System.Drawing.SystemColors.Control
        Me.ListBoxRace.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxRace.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ListBoxRace.FormattingEnabled = True
        Me.ListBoxRace.ItemHeight = 20
        Me.ListBoxRace.Location = New System.Drawing.Point(12, 484)
        Me.ListBoxRace.Name = "ListBoxRace"
        Me.ListBoxRace.Size = New System.Drawing.Size(486, 444)
        Me.ListBoxRace.TabIndex = 27
        '
        'LblList
        '
        Me.LblList.AutoSize = True
        Me.LblList.BackColor = System.Drawing.SystemColors.Control
        Me.LblList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblList.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblList.Location = New System.Drawing.Point(517, 453)
        Me.LblList.Name = "LblList"
        Me.LblList.Size = New System.Drawing.Size(218, 22)
        Me.LblList.TabIndex = 30
        Me.LblList.Text = "Type of list to show in preview"
        '
        'ListBoxList
        '
        Me.ListBoxList.BackColor = System.Drawing.SystemColors.Control
        Me.ListBoxList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxList.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ListBoxList.FormattingEnabled = True
        Me.ListBoxList.ItemHeight = 20
        Me.ListBoxList.Items.AddRange(New Object() {"Start list", "Passage 5 km", "Passage 10 km", "Passage 15 km", "Result list"})
        Me.ListBoxList.Location = New System.Drawing.Point(517, 564)
        Me.ListBoxList.Name = "ListBoxList"
        Me.ListBoxList.Size = New System.Drawing.Size(230, 364)
        Me.ListBoxList.TabIndex = 29
        '
        'RadioButtonViewStartList
        '
        Me.RadioButtonViewStartList.AutoSize = True
        Me.RadioButtonViewStartList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonViewStartList.Location = New System.Drawing.Point(517, 498)
        Me.RadioButtonViewStartList.Name = "RadioButtonViewStartList"
        Me.RadioButtonViewStartList.Size = New System.Drawing.Size(81, 24)
        Me.RadioButtonViewStartList.TabIndex = 37
        Me.RadioButtonViewStartList.TabStop = True
        Me.RadioButtonViewStartList.Text = "Startlist"
        Me.RadioButtonViewStartList.UseVisualStyleBackColor = True
        '
        'RadioButtonViewPassages
        '
        Me.RadioButtonViewPassages.AutoSize = True
        Me.RadioButtonViewPassages.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonViewPassages.Location = New System.Drawing.Point(517, 531)
        Me.RadioButtonViewPassages.Name = "RadioButtonViewPassages"
        Me.RadioButtonViewPassages.Size = New System.Drawing.Size(220, 24)
        Me.RadioButtonViewPassages.TabIndex = 39
        Me.RadioButtonViewPassages.TabStop = True
        Me.RadioButtonViewPassages.Text = "One of the passages below"
        Me.RadioButtonViewPassages.UseVisualStyleBackColor = True
        '
        'TimerMain
        '
        Me.TimerMain.Interval = 200
        '
        'TimerAnimation
        '
        Me.TimerAnimation.Interval = 41
        '
        'CheckBoxAnimate
        '
        Me.CheckBoxAnimate.AutoSize = True
        Me.CheckBoxAnimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxAnimate.Location = New System.Drawing.Point(881, 452)
        Me.CheckBoxAnimate.Name = "CheckBoxAnimate"
        Me.CheckBoxAnimate.Size = New System.Drawing.Size(325, 24)
        Me.CheckBoxAnimate.TabIndex = 38
        Me.CheckBoxAnimate.Text = "Animate ""first position"" Flag (live view only)"
        Me.CheckBoxAnimate.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(881, 482)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(391, 245)
        Me.TabControl1.TabIndex = 43
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(25, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(362, 237)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Graphic Startlist"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnSaveGraphicStartList)
        Me.GroupBox1.Controls.Add(Me.CboGraphTemplateStartList)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CboAlignmentStartList)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.NumColumnsStartList)
        Me.GroupBox1.Controls.Add(Me.NumMaxRowsStartList)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NumOpacityStartList)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 227)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Graphics around Startlist"
        '
        'BtnSaveGraphicStartList
        '
        Me.BtnSaveGraphicStartList.Location = New System.Drawing.Point(125, 193)
        Me.BtnSaveGraphicStartList.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSaveGraphicStartList.Name = "BtnSaveGraphicStartList"
        Me.BtnSaveGraphicStartList.Size = New System.Drawing.Size(201, 28)
        Me.BtnSaveGraphicStartList.TabIndex = 45
        Me.BtnSaveGraphicStartList.Text = "Save Settings"
        Me.BtnSaveGraphicStartList.UseVisualStyleBackColor = True
        Me.BtnSaveGraphicStartList.Visible = False
        '
        'CboGraphTemplateStartList
        '
        Me.CboGraphTemplateStartList.FormattingEnabled = True
        Me.CboGraphTemplateStartList.Location = New System.Drawing.Point(93, 24)
        Me.CboGraphTemplateStartList.Margin = New System.Windows.Forms.Padding(2)
        Me.CboGraphTemplateStartList.Name = "CboGraphTemplateStartList"
        Me.CboGraphTemplateStartList.Size = New System.Drawing.Size(234, 28)
        Me.CboGraphTemplateStartList.TabIndex = 44
        Me.CboGraphTemplateStartList.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 20)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Template:"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Alignment:"
        '
        'CboAlignmentStartList
        '
        Me.CboAlignmentStartList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlignmentStartList.FormattingEnabled = True
        Me.CboAlignmentStartList.Items.AddRange(New Object() {"Bottom", "Center", "Top"})
        Me.CboAlignmentStartList.Location = New System.Drawing.Point(206, 152)
        Me.CboAlignmentStartList.Name = "CboAlignmentStartList"
        Me.CboAlignmentStartList.Size = New System.Drawing.Size(121, 28)
        Me.CboAlignmentStartList.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 20)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Columns:"
        '
        'NumColumnsStartList
        '
        Me.NumColumnsStartList.Location = New System.Drawing.Point(268, 120)
        Me.NumColumnsStartList.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumColumnsStartList.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumColumnsStartList.Name = "NumColumnsStartList"
        Me.NumColumnsStartList.Size = New System.Drawing.Size(59, 26)
        Me.NumColumnsStartList.TabIndex = 39
        Me.NumColumnsStartList.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumMaxRowsStartList
        '
        Me.NumMaxRowsStartList.Location = New System.Drawing.Point(268, 88)
        Me.NumMaxRowsStartList.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumMaxRowsStartList.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumMaxRowsStartList.Name = "NumMaxRowsStartList"
        Me.NumMaxRowsStartList.Size = New System.Drawing.Size(59, 26)
        Me.NumMaxRowsStartList.TabIndex = 36
        Me.NumMaxRowsStartList.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(252, 20)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Maximum amount of rows to show:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Opacity:"
        '
        'NumOpacityStartList
        '
        Me.NumOpacityStartList.Location = New System.Drawing.Point(268, 56)
        Me.NumOpacityStartList.Name = "NumOpacityStartList"
        Me.NumOpacityStartList.Size = New System.Drawing.Size(59, 26)
        Me.NumOpacityStartList.TabIndex = 33
        Me.NumOpacityStartList.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(25, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(362, 237)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Graphic Passages"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnSaveGraphicPassages)
        Me.GroupBox2.Controls.Add(Me.CboGraphTemplatePassages)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.CboAlignmentPassages)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.NumColumnsPassages)
        Me.GroupBox2.Controls.Add(Me.NumMaxRowsPassages)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.NumOpacityPassages)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(342, 227)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Graphics around Passages"
        '
        'BtnSaveGraphicPassages
        '
        Me.BtnSaveGraphicPassages.Location = New System.Drawing.Point(125, 193)
        Me.BtnSaveGraphicPassages.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSaveGraphicPassages.Name = "BtnSaveGraphicPassages"
        Me.BtnSaveGraphicPassages.Size = New System.Drawing.Size(201, 28)
        Me.BtnSaveGraphicPassages.TabIndex = 45
        Me.BtnSaveGraphicPassages.Text = "Save Settings"
        Me.BtnSaveGraphicPassages.UseVisualStyleBackColor = True
        Me.BtnSaveGraphicPassages.Visible = False
        '
        'CboGraphTemplatePassages
        '
        Me.CboGraphTemplatePassages.FormattingEnabled = True
        Me.CboGraphTemplatePassages.Location = New System.Drawing.Point(93, 24)
        Me.CboGraphTemplatePassages.Margin = New System.Windows.Forms.Padding(2)
        Me.CboGraphTemplatePassages.Name = "CboGraphTemplatePassages"
        Me.CboGraphTemplatePassages.Size = New System.Drawing.Size(234, 28)
        Me.CboGraphTemplatePassages.TabIndex = 44
        Me.CboGraphTemplatePassages.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 20)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Template:"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Alignment:"
        '
        'CboAlignmentPassages
        '
        Me.CboAlignmentPassages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlignmentPassages.FormattingEnabled = True
        Me.CboAlignmentPassages.Items.AddRange(New Object() {"Bottom", "Center", "Top"})
        Me.CboAlignmentPassages.Location = New System.Drawing.Point(206, 152)
        Me.CboAlignmentPassages.Name = "CboAlignmentPassages"
        Me.CboAlignmentPassages.Size = New System.Drawing.Size(121, 28)
        Me.CboAlignmentPassages.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 20)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Columns:"
        '
        'NumColumnsPassages
        '
        Me.NumColumnsPassages.Location = New System.Drawing.Point(268, 120)
        Me.NumColumnsPassages.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumColumnsPassages.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumColumnsPassages.Name = "NumColumnsPassages"
        Me.NumColumnsPassages.Size = New System.Drawing.Size(59, 26)
        Me.NumColumnsPassages.TabIndex = 39
        Me.NumColumnsPassages.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumMaxRowsPassages
        '
        Me.NumMaxRowsPassages.Location = New System.Drawing.Point(268, 88)
        Me.NumMaxRowsPassages.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumMaxRowsPassages.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumMaxRowsPassages.Name = "NumMaxRowsPassages"
        Me.NumMaxRowsPassages.Size = New System.Drawing.Size(59, 26)
        Me.NumMaxRowsPassages.TabIndex = 36
        Me.NumMaxRowsPassages.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(252, 20)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Maximum amount of rows to show:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 20)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Opacity:"
        '
        'NumOpacityPassages
        '
        Me.NumOpacityPassages.Location = New System.Drawing.Point(268, 56)
        Me.NumOpacityPassages.Name = "NumOpacityPassages"
        Me.NumOpacityPassages.Size = New System.Drawing.Size(59, 26)
        Me.NumOpacityPassages.TabIndex = 33
        Me.NumOpacityPassages.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(1294, 452)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 20)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Background colour:"
        '
        'ChkFreeze
        '
        Me.ChkFreeze.AutoSize = True
        Me.ChkFreeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFreeze.Location = New System.Drawing.Point(1298, 532)
        Me.ChkFreeze.Name = "ChkFreeze"
        Me.ChkFreeze.Size = New System.Drawing.Size(162, 24)
        Me.ChkFreeze.TabIndex = 46
        Me.ChkFreeze.Text = "Freeze Live picture"
        Me.ChkFreeze.UseVisualStyleBackColor = True
        Me.ChkFreeze.Visible = False
        '
        'PictureBoxBackColor
        '
        Me.PictureBoxBackColor.BackColor = System.Drawing.Color.Olive
        Me.PictureBoxBackColor.Location = New System.Drawing.Point(1446, 453)
        Me.PictureBoxBackColor.Name = "PictureBoxBackColor"
        Me.PictureBoxBackColor.Size = New System.Drawing.Size(53, 50)
        Me.PictureBoxBackColor.TabIndex = 44
        Me.PictureBoxBackColor.TabStop = False
        '
        'ButtonStatus
        '
        Me.ButtonStatus.Image = Global.CanixMix.My.Resources.Resources.greenlight
        Me.ButtonStatus.Location = New System.Drawing.Point(701, 321)
        Me.ButtonStatus.Name = "ButtonStatus"
        Me.ButtonStatus.Size = New System.Drawing.Size(137, 114)
        Me.ButtonStatus.TabIndex = 42
        Me.ButtonStatus.UseVisualStyleBackColor = True
        '
        'ButtonEndLive
        '
        Me.ButtonEndLive.Image = Global.CanixMix.My.Resources.Resources.stop_enabled
        Me.ButtonEndLive.Location = New System.Drawing.Point(701, 197)
        Me.ButtonEndLive.Name = "ButtonEndLive"
        Me.ButtonEndLive.Size = New System.Drawing.Size(137, 114)
        Me.ButtonEndLive.TabIndex = 3
        Me.ButtonEndLive.UseVisualStyleBackColor = True
        '
        'ButtonToLive
        '
        Me.ButtonToLive.Image = Global.CanixMix.My.Resources.Resources.play_enabled
        Me.ButtonToLive.Location = New System.Drawing.Point(701, 75)
        Me.ButtonToLive.Name = "ButtonToLive"
        Me.ButtonToLive.Size = New System.Drawing.Size(137, 116)
        Me.ButtonToLive.TabIndex = 2
        Me.ButtonToLive.UseVisualStyleBackColor = True
        '
        'PictureBoxLive
        '
        Me.PictureBoxLive.BackgroundImage = Global.CanixMix.My.Resources.Resources.kanotbakgrund
        Me.PictureBoxLive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBoxLive.Location = New System.Drawing.Point(881, 75)
        Me.PictureBoxLive.Name = "PictureBoxLive"
        Me.PictureBoxLive.Size = New System.Drawing.Size(640, 360)
        Me.PictureBoxLive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxLive.TabIndex = 1
        Me.PictureBoxLive.TabStop = False
        '
        'PictureBoxPreview
        '
        Me.PictureBoxPreview.BackgroundImage = Global.CanixMix.My.Resources.Resources.kanotbakgrund
        Me.PictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBoxPreview.Location = New System.Drawing.Point(12, 75)
        Me.PictureBoxPreview.Name = "PictureBoxPreview"
        Me.PictureBoxPreview.Size = New System.Drawing.Size(640, 360)
        Me.PictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPreview.TabIndex = 0
        Me.PictureBoxPreview.TabStop = False
        '
        'ChkBigPicture
        '
        Me.ChkBigPicture.AutoSize = True
        Me.ChkBigPicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBigPicture.Location = New System.Drawing.Point(1298, 564)
        Me.ChkBigPicture.Name = "ChkBigPicture"
        Me.ChkBigPicture.Size = New System.Drawing.Size(119, 24)
        Me.ChkBigPicture.TabIndex = 47
        Me.ChkBigPicture.Text = "Use Big Size"
        Me.ChkBigPicture.UseVisualStyleBackColor = True
        Me.ChkBigPicture.Visible = False
        '
        'DsVideoOut1
        '
        Me.DsVideoOut1.AudioInputPin = SinkPin1
        DsvlAudioOutputDevice1.DeviceName = "None"
        Me.DsVideoOut1.AudioOutputDevice = DsvlAudioOutputDevice1
        Me.DsVideoOut1.ClockOutputPin = SourcePin1
        DvFormat1.InternalData = CType(resources.GetObject("DvFormat1.InternalData"), Vcl.VclBinaryData)
        Me.DsVideoOut1.DVFormat = DvFormat1
        DsGraph1.GraphPin = SourcePin2
        Me.DsVideoOut1.Graph = DsGraph1
        SinkPin2.ConnectionData = CType(resources.GetObject("SinkPin2.ConnectionData"), OpenWire.PinConnections)
        Me.DsVideoOut1.InputPin = SinkPin2
        MasterPumping1.Priority = CType(0UI, UInteger)
        Me.DsVideoOut1.MasterPumping = MasterPumping1
        DsVideoOutputDevice1.DeviceName = "Decklink Video Render"
        DsVideoOutputDevice1.InternalData = CType(resources.GetObject("DsVideoOutputDevice1.InternalData"), Vcl.VclBinaryData)
        Me.DsVideoOut1.VideoOutputDevice = DsVideoOutputDevice1
        '
        'ImageGen1
        '
        Me.ImageGen1.ClockPin = SinkPin3
        Me.ImageGen1.FrameRate = 30.0!
        Me.ImageGen1.ImageInputPin = SinkPin4
        SourcePin3.ConnectionData = CType(resources.GetObject("SourcePin3.ConnectionData"), OpenWire.PinConnections)
        Me.ImageGen1.OutputPin = SourcePin3
        Me.ImageGen1.PumpPriority = CType(0UI, UInteger)
        Transparency1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ImageGen1.Transparency = Transparency1
        '
        'FrmMixer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1550, 942)
        Me.Controls.Add(Me.ChkBigPicture)
        Me.Controls.Add(Me.ChkFreeze)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBoxBackColor)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonStatus)
        Me.Controls.Add(Me.RadioButtonViewPassages)
        Me.Controls.Add(Me.CheckBoxAnimate)
        Me.Controls.Add(Me.RadioButtonViewStartList)
        Me.Controls.Add(Me.LblList)
        Me.Controls.Add(Me.ListBoxList)
        Me.Controls.Add(Me.LblRace)
        Me.Controls.Add(Me.ListBoxRace)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxEvents)
        Me.Controls.Add(Me.LabelLive)
        Me.Controls.Add(Me.LabelPreview)
        Me.Controls.Add(Me.ButtonEndLive)
        Me.Controls.Add(Me.ButtonToLive)
        Me.Controls.Add(Me.PictureBoxLive)
        Me.Controls.Add(Me.PictureBoxPreview)
        Me.Name = "FrmMixer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMixer"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumColumnsStartList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumMaxRowsStartList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumOpacityStartList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumColumnsPassages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumMaxRowsPassages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumOpacityPassages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxBackColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxLive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsVideoOut1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageGen1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBoxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxLive As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonToLive As System.Windows.Forms.Button
    Friend WithEvents ButtonEndLive As System.Windows.Forms.Button
    Friend WithEvents LabelPreview As System.Windows.Forms.Label
    Friend WithEvents LabelLive As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEvents As System.Windows.Forms.ComboBox
    Friend WithEvents LblRace As System.Windows.Forms.Label
    Friend WithEvents ListBoxRace As System.Windows.Forms.ListBox
    Friend WithEvents LblList As System.Windows.Forms.Label
    Friend WithEvents ListBoxList As System.Windows.Forms.ListBox
    Friend WithEvents RadioButtonViewStartList As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonViewPassages As System.Windows.Forms.RadioButton
    Friend WithEvents TimerMain As System.Windows.Forms.Timer
    Friend WithEvents TimerAnimation As System.Windows.Forms.Timer
    Friend WithEvents CheckBoxAnimate As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonStatus As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboAlignmentStartList As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumColumnsStartList As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumMaxRowsStartList As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumOpacityStartList As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents BtnSaveGraphicStartList As System.Windows.Forms.Button
    Friend WithEvents CboGraphTemplateStartList As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSaveGraphicPassages As System.Windows.Forms.Button
    Friend WithEvents CboGraphTemplatePassages As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CboAlignmentPassages As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents NumColumnsPassages As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumMaxRowsPassages As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NumOpacityPassages As System.Windows.Forms.NumericUpDown
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents PictureBoxBackColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ChkFreeze As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBigPicture As System.Windows.Forms.CheckBox
    Friend WithEvents DsVideoOut1 As Mitov.VideoLab.DSVideoOut
    Friend WithEvents ImageGen1 As Mitov.VideoLab.ImageGen
End Class

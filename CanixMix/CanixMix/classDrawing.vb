Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text


Public Class classDrawing
  
    '100% Scale on p720 camera
    Dim tvWidth As Integer = 1280
    Dim tvHeight As Integer = 720


    Public Enum EnumAlignment
        Bottom = 0
        Center = 1
        Top = 2
    End Enum

    Public Enum EnumListType
        StartList = 0
        Passages = 1
        StartListPreview = 2
        PassagesPreview = 3
    End Enum

    Dim lOpacity(3) As Integer
    Dim lMaxRows(3) As Integer
    Dim lAlignment(3) As EnumAlignment
    Dim lGraphCols(3) As Integer
    Dim lBackColor As Brush = Brushes.Olive


    Public Property BackColorOut()
        Get
            BackColorOut = lBackColor
        End Get
        Set(value)

            lBackColor = value
        End Set
    End Property

    Public Property ListOpacity(ByVal pListType As EnumListType)
        Get
            Try
                ListOpacity = lOpacity(pListType)
            Catch ex As Exception
                ListOpacity = 100
            End Try
        End Get
        Set(value)
            lOpacity(pListType) = value
        End Set
    End Property

    Public Property ListColumns(ByVal pListType As EnumListType)
        Get
            Try
                ListColumns = lGraphCols(pListType)
            Catch ex As Exception
                ListColumns = 1
            End Try
        End Get
        Set(value)
            lGraphCols(pListType) = value
        End Set
    End Property
    Public Property ListMaxRows(ByVal pListType As EnumListType)
        Get
            Try
                ListMaxRows = lMaxRows(pListType)
            Catch ex As Exception
                ListMaxRows = 10
            End Try
        End Get
        Set(value)
            lMaxRows(pListType) = value
        End Set
    End Property
    Public Property ListAlignment(ByVal pListType As EnumListType)
        Get
            Try
                ListAlignment = lAlignment(pListType)
            Catch ex As Exception
                ListAlignment = 1
            End Try
        End Get
        Set(value)
            lAlignment(pListType) = value
        End Set
    End Property
    '******************************************************************************************
    'This routine calculates the width of the background for each item depending on how many
    'columns you would like to present side by side. Still the same height on them though.
    '******************************************************************************************
    Public Function SetBackGroundWidth(ByVal bmp As Bitmap, columns As Integer) As Bitmap
        Dim bmp2 As New Bitmap(Convert.ToInt32(tvWidth / columns), bmp.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim gfx As Graphics = Graphics.FromImage(bmp2)

        Dim rectpos As Rectangle

        If columns > 1 Then
            rectpos.X = 0
            rectpos.Y = 0
            rectpos.Height = bmp2.Height
            rectpos.Width = bmp2.Width

            gfx.DrawImage(bmp, rectpos)

            Return bmp2
        Else
            Return bmp
        End If

    End Function

    '******************************************************************************************
    'This routine creates some transparancy on the picture. 
    'You send in the opacity and 0 is no transparancy and 100 is total transparancy
    '******************************************************************************************
    Public Function FadeBitmap(ByVal bmp As Bitmap, ByVal pOpacity As Integer) As Bitmap
        Dim bmp2 As New Bitmap(bmp.Width, bmp.Height, Imaging.PixelFormat.Format32bppArgb)

        Using ia As New Imaging.ImageAttributes
            Dim cm As New Imaging.ColorMatrix
            cm.Matrix33 = pOpacity / 100.0F
            ia.SetColorMatrix(cm)
            Dim destpoints() As PointF = _
                   {New Point(0, 0), New Point(bmp.Width, 0), New Point(0, bmp.Height)}
            Using g As Graphics = Graphics.FromImage(bmp2)
                g.Clear(Color.Transparent)
                g.DrawImage(bmp, destpoints, _
                   New RectangleF(Point.Empty, bmp.Size), GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return bmp2
    End Function

    '******************************************************************************************
    'This routine adds text to the picture. 
    'pStartX is the starting position, but if you send in -1, then it tries to put the text in the far right corner.
    '******************************************************************************************
    Public Sub AddTextToBitmap(ByRef bmp As Bitmap, ByVal pText As String, ByVal pStartX As Integer, Optional pHeader As Boolean = False)

        Dim drawFont As New System.Drawing.Font("Arial", Convert.ToInt32(bmp.Height * 0.7), FontStyle.Regular, GraphicsUnit.Pixel)
        Dim drawBrush As New  _
           System.Drawing.SolidBrush(System.Drawing.Color.White)
        Dim drawFormat As New System.Drawing.StringFormat
        Dim totTextLength As SizeF
        'Obtain Graphics object to perform graphics opration
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim fontSize As Integer
        Dim fontType As Integer


        If pHeader = True Then
            '       fontType = FontStyle.Bold
            fontType = FontStyle.Regular
        Else
            fontType = FontStyle.Regular
        End If

        fontSize = Convert.ToInt32(bmp.Height * 0.7)

        Do
            drawFont = New System.Drawing.Font("Arial", fontSize, fontType, GraphicsUnit.Pixel)
            fontSize -= 1
        Loop Until g.MeasureString(pText, drawFont).Width < 0.8 * bmp.Width

     

        'Test the textlength
        totTextLength = g.MeasureString(pText, drawFont)

        'If -1, then it tries to put the text in the far right corner.
        If pStartX = -1 Then
            g.DrawString(pText, drawFont, drawBrush, bmp.Width - (totTextLength.Width + 20), (bmp.Height / 2) - (drawFont.Height / 2), drawFormat)
        Else
            g.DrawString(pText, drawFont, drawBrush, pStartX, (bmp.Height / 2) - (drawFont.Height / 2), drawFormat)
        End If


    End Sub

    '******************************************************************************************
    'DraweffectPlain presents maximum amount (or less) of contestants on the screen
    'for ScreenInterval seconds and then change to next part of contestantlist.
    '******************************************************************************************
    Public Function DrawEffectPlain(ByRef bmpList As Dictionary(Of String, Bitmap), MaxRowsOnScreen As Integer, PicScale As Integer, Optional ScreenIntervalSec As Integer = 1) As Dictionary(Of String, Bitmap)

        '100% Scale on p720 camera
        Dim x As Integer = 1280
        Dim y As Integer = 720

        'Where to put the lines
        Dim xPresentation As Integer
        Dim yPresentation As Integer

        'recalculate 0-100% to a number to use (eg. 50% will be 0.5)
        Dim PercScale As Single = PicScale / 100

        Dim rowCounter As Integer = 0
        Dim pageCounter As Integer = 0

        Dim bmp2 As New Bitmap(x * PercScale, y * PercScale, Imaging.PixelFormat.Format32bppArgb)
        Dim newBmpList As New Dictionary(Of String, Bitmap)

        Dim gfx As Graphics = Graphics.FromImage(bmp2)

        gfx.FillRectangle(lBackColor, New Rectangle(0, 0, x * PercScale, y * PercScale))

        For Each pDictRow In bmpList

            If pDictRow.Key = "Header" Then
                If bmpList.Count > 1 Then
                    If pDictRow.Value.Height > bmpList(bmpList.Keys(1)).Size.Height Then
                        xPresentation = (x - pDictRow.Value.Width) / 2
                        yPresentation = ((y - ((pDictRow.Value.Height / 2) * (MaxRowsOnScreen + 2))) / 2) + (rowCounter * pDictRow.Value.Height)
                    Else
                        xPresentation = (x - pDictRow.Value.Width) / 2
                        yPresentation = 0 '(y - (pDictRow.Value.Height * (MaxRowsOnScreen))) / 2) + (rowCounter * pDictRow.Value.Height)
                    End If
                Else
                    xPresentation = (x - pDictRow.Value.Width) / 2
                    yPresentation = ((y - ((pDictRow.Value.Height / 2) * (MaxRowsOnScreen + 2))) / 2) + (rowCounter * pDictRow.Value.Height)

                End If
            Else
                xPresentation = (x - pDictRow.Value.Width) / 2
                yPresentation = ((y - (pDictRow.Value.Height * (MaxRowsOnScreen))) / 2) + (rowCounter * pDictRow.Value.Height)
            End If

                '...and draw on surface

                gfx.DrawImage(pDictRow.Value, xPresentation * PercScale, yPresentation * PercScale, Convert.ToInt32(pDictRow.Value.Width * PercScale), Convert.ToInt32(pDictRow.Value.Height * PercScale))
                rowCounter += 1


                'For every page of contestants reaching max I produce an image to show later on
                If rowCounter = MaxRowsOnScreen Then
                    pageCounter += 1
                For WaitIndex = 1 To ScreenIntervalSec * 5
                    newBmpList.Add(Convert.ToString(pageCounter) & "_" & Convert.ToString(WaitIndex), bmp2)
                Next
                    bmp2 = New Bitmap(x * PercScale, y * PercScale, Imaging.PixelFormat.Format32bppArgb)
                    gfx = Graphics.FromImage(bmp2)

                    gfx.FillRectangle(lBackColor, New Rectangle(0, 0, x * PercScale, y * PercScale))

                    rowCounter = 0
                    'Add header on next image as well.
                    xPresentation = (x - bmpList.First.Value.Width) / 2
                    yPresentation = ((y - ((bmpList.First.Value.Height / 2) * (MaxRowsOnScreen + 2))) / 2) + (rowCounter * bmpList.First.Value.Height)
                    gfx.DrawImage(bmpList.First.Value, xPresentation * PercScale, yPresentation * PercScale, Convert.ToInt32(bmpList.First.Value.Width * PercScale), Convert.ToInt32(bmpList.First.Value.Height * PercScale))
                    rowCounter += 1
                End If
        Next
        pageCounter += 1
        For WaitIndex = 1 To ScreenIntervalSec * 5
            newBmpList.Add(Convert.ToString(pageCounter) & "_" & Convert.ToString(WaitIndex), bmp2)
        Next

        gfx.Dispose()

        Return newBmpList

    End Function
    '******************************************************************************************
    'DrawEffectKeepTop presents maximum amount (or less) of contestants on the screen
    'until filled. Then it removes one for each new that comes in, but keeps number one.
    '******************************************************************************************
    Public Function DrawEffectKeepTop(ByRef bmpList As Dictionary(Of String, Bitmap), MaxRowsOnScreen As Integer, PicScale As Integer, Columns As Integer, ByVal ItemAlignment As EnumAlignment) As Bitmap


        'Where to put the lines
        Dim xPresentation As Integer
        Dim yPresentation As Integer

        'recalculate 0-100% to a number to use (eg. 50% will be 0.5)
        Dim PercScale As Single = PicScale / 100

        Dim rowCounter As Integer = 0
        Dim startIndex As Integer = 0
        Dim pDictRow As Bitmap
        Dim curColumn As Integer = 1


        Dim bmp2 As New Bitmap(tvWidth * PercScale, tvHeight * PercScale, Imaging.PixelFormat.Format32bppArgb)
        Dim gfx As Graphics = Graphics.FromImage(bmp2)


        '***********************************************
        '***********************************************
        '***********************************************
        gfx.FillRectangle(lBackColor, New Rectangle(0, 0, tvWidth * PercScale, tvHeight * PercScale))

        'Draw the header

        If Columns > 1 Then
            xPresentation = 1
        Else
            xPresentation = (tvWidth - bmpList.First.Value.Width) / 2
        End If

        If bmpList.Count > 1 Then
            If bmpList.First.Value.Height > bmpList(bmpList.Keys(1)).Size.Height Then
                Select Case ItemAlignment
                    Case EnumAlignment.Bottom
                        yPresentation = tvHeight - ((bmpList.First.Value.Height / 2) * (MaxRowsOnScreen + 2))
                    Case EnumAlignment.Center
                        yPresentation = ((tvHeight - ((bmpList.First.Value.Height / 2) * (MaxRowsOnScreen + 2))) / 2)
                    Case EnumAlignment.Top

                End Select
            Else
                yPresentation = 0
            End If
        Else
            yPresentation = 0
        End If


        gfx.DrawImage(bmpList.First.Value, xPresentation * PercScale, yPresentation * PercScale, Convert.ToInt32(bmpList.First.Value.Width * PercScale), Convert.ToInt32(bmpList.First.Value.Height * PercScale))
        rowCounter += 1

        If bmpList.Count > 1 Then
            'Draw the first contestant to the bitmap
            If Columns > 1 Then
                xPresentation = 1
            Else
                xPresentation = (tvWidth - bmpList.ElementAt(1).Value.Width) / 2
            End If

            Select Case ItemAlignment
                Case EnumAlignment.Bottom
                    yPresentation = tvHeight - ((bmpList.ElementAt(1).Value.Height * MaxRowsOnScreen)) + ((rowCounter - 1) * bmpList.ElementAt(1).Value.Height)
                Case EnumAlignment.Center
                    yPresentation = ((tvHeight - (bmpList.ElementAt(1).Value.Height * MaxRowsOnScreen)) / 2) + (rowCounter * bmpList.ElementAt(1).Value.Height)
                Case EnumAlignment.Top

            End Select



            gfx.DrawImage(bmpList.ElementAt(1).Value, xPresentation * PercScale, yPresentation * PercScale, Convert.ToInt32(bmpList.ElementAt(1).Value.Width * PercScale), Convert.ToInt32(bmpList.ElementAt(1).Value.Height * PercScale))
            rowCounter += 1
        End If

        startIndex = bmpList.Count - ((MaxRowsOnScreen * Columns) - 1)
        If startIndex < 2 Then
            startIndex = 2
        End If


        For bmpRows = startIndex To bmpList.Count - 1
            pDictRow = bmpList.ElementAt(bmpRows).Value
            If Columns = 1 Then
                xPresentation = (tvWidth - pDictRow.Width) / 2
            Else
                xPresentation = (pDictRow.Width * curColumn) - pDictRow.Width
            End If


            Select Case ItemAlignment
                Case EnumAlignment.Bottom
                    yPresentation = tvHeight - ((pDictRow.Height * MaxRowsOnScreen)) + ((rowCounter - 1) * pDictRow.Height)
                Case EnumAlignment.Center
                    yPresentation = ((tvHeight - (pDictRow.Height * MaxRowsOnScreen)) / 2) + (rowCounter * pDictRow.Height)
                Case EnumAlignment.Top
            End Select




            '...and draw on surface

            gfx.DrawImage(pDictRow, xPresentation * PercScale, yPresentation * PercScale, Convert.ToInt32(pDictRow.Width * PercScale), Convert.ToInt32(pDictRow.Height * PercScale))
            rowCounter += 1

            If rowCounter > (MaxRowsOnScreen) Then
                If ((bmpList.Count - 1) - bmpRows) >= MaxRowsOnScreen Then
                    rowCounter = 2
                Else
                    rowCounter = (MaxRowsOnScreen - ((bmpList.Count - 1) - bmpRows)) + 1
                    If rowCounter < 2 Then
                        rowCounter = 2
                    End If
                End If
                curColumn += 1
            End If

        Next

        gfx.Dispose()

        Return bmp2

    End Function

    '******************************************************************************************
    'AddFlagToBitmap sends in the three letters of a nationality and the bitmap
    'to put the flag on, then as output you'll get the flag on the bitmap.
    '******************************************************************************************
    Public Sub AddFlagToBitmap(ByRef bmp As Bitmap, ByVal pNationality As String, ByVal pStartX As Integer, Optional ScaleOnImage As Integer = 90)
        Dim RectPos As System.Drawing.Rectangle
        Dim ImageFlag As System.Drawing.Image

        'Obtain Graphics object to perform graphics opration
        Dim g As Graphics = Graphics.FromImage(bmp)

        ImageFlag = GetFlag(pNationality)

        If Not ImageFlag Is Nothing Then

            RectPos.X = pStartX
            RectPos.Y = 5
            RectPos.Height = bmp.Height * (ScaleOnImage / 100)
            RectPos.Width = (bmp.Height / GetFlag(pNationality).Height) * GetFlag(pNationality).Width * (ScaleOnImage / 100)
            g.DrawImage(GetFlag(pNationality), RectPos)
        End If

    End Sub

    '******************************************************************************************
    'AddBitmapOnBitmap sends in the "big" bitmap as parameter bmp
    'and a small bitmap as bpmAddOn to draw another bitmap on top of the first.
    '******************************************************************************************
    Public Sub AddBitmapOnBitmap(ByRef bmp As Bitmap, ByVal bmpAddOn As Bitmap, ByVal X As Integer, ByVal Y As Integer, Optional ScaleOnImage As Integer = 100)
        Dim RectPos As System.Drawing.Rectangle


        'Obtain Graphics object to perform graphics opration
        Dim g As Graphics = Graphics.FromImage(bmp)

        RectPos.X = X
        RectPos.Y = Y
        RectPos.Height = bmpAddOn.Height * (ScaleOnImage / 100)
        RectPos.Width = bmpAddOn.Width * (ScaleOnImage / 100)
        g.DrawImage(bmpAddOn, RectPos)
    End Sub

    '******************************************************************************************
    'SetBitmapToScreen just puts a plain picture
    'in an empty bitmap that has the size of the TV-screen.
    '******************************************************************************************
    Public Function SetBitmapToScreen(ByVal bmpAddOn As Bitmap, ByVal X As Integer, ByVal Y As Integer, Optional ScaleOnImage As Integer = 100) As Bitmap
        Dim RectPos As System.Drawing.Rectangle

        Dim bmp As New Bitmap(tvWidth, tvHeight, Imaging.PixelFormat.Format32bppArgb)

        'Obtain Graphics object to perform graphics opration
        Dim g As Graphics = Graphics.FromImage(bmp)

        RectPos.X = X
        RectPos.Y = Y
        RectPos.Height = bmpAddOn.Height * (ScaleOnImage / 100)
        RectPos.Width = bmpAddOn.Width * (ScaleOnImage / 100)
        g.DrawImage(bmpAddOn, RectPos)

        Return bmp
    End Function

    '******************************************************************************************
    'RotateBitMap just rotates the bitmap a bit. Used for animation of rotation on flags.
     '******************************************************************************************
    Public Function RotateBitMap(ByVal bmp As Bitmap, angle As Integer) As Bitmap
        Dim RectPos As System.Drawing.Rectangle

        'create a new empty bitmap to hold rotated image
        Dim returnBitmap As New Bitmap(bmp.Width, bmp.Height)
        'make a graphics object from the empty bitmap
        Dim g As Graphics = Graphics.FromImage(returnBitmap)


        'move rotation point to center of image
        g.TranslateTransform(128, 128)
        'rotate
        g.RotateTransform(angle)
        'move image back
        g.TranslateTransform(-128, -128)
        'draw passed in image onto graphics object

        RectPos.X = 0
        RectPos.Y = 0
        RectPos.Height = bmp.Height
        RectPos.Width = bmp.Width

        g.DrawImage(bmp, RectPos)


        Return returnBitmap
    End Function

    '******************************************************************************************
    'Send in the trhree long code for an OS country and you will get the flag back
    '******************************************************************************************
    Public Function GetFlag(pNationality As String) As Image

        Try

            Select Case pNationality
                Case "LOGO" ' Our own logo (LearningWell)
                    GetFlag = My.Resources.LW_Centr_CMYK_White
                Case "AFG" '[1]	 Afghanistan
                    GetFlag = My.Resources.AFG
                Case "ALB" '	[2]	 Albania	"
                    GetFlag = My.Resources.ALB
                Case "ALG" '	[3]	 Algeria	AGR (1964), AGL (1968 S)"
                    GetFlag = My.Resources.ALG
                Case "AND" '	[4]	 Andorra	"
                    GetFlag = My.Resources.FLAGAND
                Case "ANG" '	[5]	 Angola	"
                    GetFlag = My.Resources.ANG
                Case "ANT" '	[6]	 Antigua and Barbuda	"
                    GetFlag = My.Resources.ANT
                Case "ARG" '	[7]	 Argentina	"
                    GetFlag = My.Resources.ARG
                Case "ARM" '	[8]	 Armenia	"
                    GetFlag = My.Resources.ARM
                Case "ARU" '	[9]	 Aruba	"
                    GetFlag = My.Resources.ARU
                Case "ASA" '	[10]	 American Samoa	"
                    GetFlag = My.Resources.ASA
                Case "AUS" '	[11]	 Australia	AUT (1956 W)"
                    GetFlag = My.Resources.AUS
                Case "AUT" '	[12]	 Austria	AUS (1956 W)"
                    GetFlag = My.Resources.AUT
                Case "AZE" '	[13]	 Azerbaijan	"
                    GetFlag = My.Resources.AZE
                Case "BAH" '	[14]	 Bahamas	"
                    GetFlag = My.Resources.BAH
                Case "BAN" '	[15]	 Bangladesh	"
                    GetFlag = My.Resources.BAN
                Case "BAR" '	[16]	 Barbados	BAD (1964)"
                    GetFlag = My.Resources.BAR
                Case "BDI" '	[17]	 Burundi	"
                    GetFlag = My.Resources.BDI
                Case "BEL" '	[18]	 Belgium	"
                    GetFlag = My.Resources.BEL
                Case "BEN" '	[19]	 Benin	DAY (1964), DAH (1968–1976)"
                    GetFlag = My.Resources.BEN
                Case "BER" '	[20]	 Bermuda	"
                    GetFlag = My.Resources.BER
                Case "BHU" '	[21]	 Bhutan	"
                    GetFlag = My.Resources.BHU
                Case "BIH" '	[22]	 Bosnia and Herzegovina	BSH (1992 S)"
                    GetFlag = My.Resources.BIH
                Case "BIZ" '	[23]	 Belize	HBR (1968–1972)"
                    GetFlag = My.Resources.BIZ
                Case "BLR" '	[24]	 Belarus	"
                    GetFlag = My.Resources.BLR
                Case "BOL" '	[25]	 Bolivia	"
                    GetFlag = My.Resources.BOL
                Case "BOT" '	[26]	 Botswana	"
                    GetFlag = My.Resources.BOT
                Case "BRA" '	[27]	 Brazil	"
                    GetFlag = My.Resources.BRA
                Case "BRN" '	[28]	 Bahrain	"
                    GetFlag = My.Resources.BRN
                Case "BRU" '	[29]	 Brunei	"
                    GetFlag = My.Resources.BRU
                Case "BUL" '	[30]	 Bulgaria	"
                    GetFlag = My.Resources.BUL
                Case "BUR" '	[31]	 Burkina Faso	VOL (1972–1984)"
                    GetFlag = My.Resources.BUR
                Case "CAF" '	[32]	 Central African Republic	AFC (1968)"
                    GetFlag = My.Resources.CAF
                Case "CAM" '	[33]	 Cambodia	CAB (1964), KHM (1972–1976)"
                    GetFlag = My.Resources.CAM
                Case "CAN" '	[34]	 Canada	"
                    GetFlag = My.Resources.CAN
                Case "CAY" '	[35]	 Cayman Islands	"
                    GetFlag = My.Resources.CAY
                Case "CGO" '	[36]	 Congo	"
                    GetFlag = My.Resources.CGO
                Case "CHA" '	[37]	 Chad	CHD (1964)"
                    GetFlag = My.Resources.CHA
                Case "CHI" '	[38]	 Chile	CIL (1956 W, 1960 S)"
                    GetFlag = My.Resources.CHI
                Case "CHN" '	[39]	 China	"
                    GetFlag = My.Resources.CHN
                Case "CIV" '	[40]	 Ivory Coast	IVC (1964), CML (1968)"
                    GetFlag = My.Resources.CIV
                Case "CMR" '	[41]	 Cameroon	"
                    GetFlag = My.Resources.CMR
                Case "COD" '	[42]	 DR Congo	COK (1968), ZAI (1972–1996)"
                    GetFlag = My.Resources.COD
                Case "COK" '	[43]	 Cook Islands	"
                    GetFlag = My.Resources.COK
                Case "COL" '	[44]	 Colombia	"
                    GetFlag = My.Resources.COL
                Case "COM" '	[45]	 Comoros	"
                    GetFlag = My.Resources.COM
                Case "CPV" '	[46]	 Cape Verde	"
                    GetFlag = My.Resources.CPV
                Case "CRC" '	[47]	 Costa Rica	COS (1964)"
                    GetFlag = My.Resources.CRC
                Case "CRO" '	[48]	 Croatia	"
                    GetFlag = My.Resources.CRO
                Case "CUB" '	[49]	 Cuba	"
                    GetFlag = My.Resources.CUB
                Case "CYP" '	[50]	 Cyprus	"
                    GetFlag = My.Resources.CYP
                Case "CZE" '	[51]	 Czech Republic	"
                    GetFlag = My.Resources.CZE
                Case "DEN" '	[52]	 Denmark	DAN (1960 S, 1968 W), DIN (1968 S)"
                    GetFlag = My.Resources.DEN
                Case "DJI" '	[53]	 Djibouti	"
                    GetFlag = My.Resources.DJI
                Case "DMA" '	[54]	 Dominica	"
                    GetFlag = My.Resources.DMA
                Case "DOM" '	[55]	 Dominican Republic	"
                    GetFlag = My.Resources.DOM
                Case "ECU" '	[56]	 Ecuador	"
                    GetFlag = My.Resources.ECU
                Case "EGY" '	[57]	 Egypt	RAU (1960, 1968), UAR (1964)"
                    GetFlag = My.Resources.EGY
                Case "ERI" '	[58]	 Eritrea	"
                    GetFlag = My.Resources.ERI
                Case "ESA" '	[59]	 El Salvador	SAL (1964–1976)"
                    GetFlag = My.Resources.ESA
                Case "ESP" '	[60]	 Spain	SPA (1956–1964, 1968 W)"
                    GetFlag = My.Resources.ESP
                Case "EST" '	[61]	 Estonia	"
                    GetFlag = My.Resources.EST
                Case "ETH" '	[62]	 Ethiopia	ETI (1960, 1968)"
                    GetFlag = My.Resources.ETH
                Case "FIJ" '	[63]	 Fiji	FIG (1960)"
                    GetFlag = My.Resources.FIJ
                Case "FIN" '	[64]	 Finland	"
                    GetFlag = My.Resources.FIN
                Case "FRA" '	[65]	 France	"
                    GetFlag = My.Resources.FRA
                Case "FSM" '	[66]	 Federated States of Micronesia	"
                    GetFlag = My.Resources.FSM
                Case "GAB" '	[67]	 Gabon	"
                    GetFlag = My.Resources.GAB
                Case "GAM" '	[68]	 Gambia	"
                    GetFlag = My.Resources.GAM
                Case "GBR" '	[69]	 Great Britain	GRB (1956 W–1960), GBI (1964)"
                    GetFlag = My.Resources.GBR
                Case "GBS" '	[70]	 Guinea-Bissau	"
                    GetFlag = My.Resources.GBS
                Case "GEO" '	[71]	 Georgia	"
                    GetFlag = My.Resources.GEO
                Case "GEQ" '	[72]	 Equatorial Guinea	"
                    GetFlag = My.Resources.GEQ
                Case "GER" '	[73]	 Germany	ALL (1968 W), ALE (1968 S)"
                    GetFlag = My.Resources.GER
                Case "GHA" '	[74]	 Ghana	"
                    GetFlag = My.Resources.GHA
                Case "GRE" '	[75]	 Greece	"
                    GetFlag = My.Resources.GRE
                Case "GRN" '	[76]	 Grenada	"
                    GetFlag = My.Resources.GRN
                Case "GUA" '	[77]	 Guatemala	GUT (1964)"
                    GetFlag = My.Resources.GUA
                Case "GUI" '	[78]	 Guinea	"
                    GetFlag = My.Resources.GUI
                Case "GUM" '	[79]	 Guam	"
                    GetFlag = My.Resources.GUM
                Case "GUY" '	[80]	 Guyana	GUA (1960), GUI (1964)"
                    GetFlag = My.Resources.GUY
                Case "HAI" '	[81]	 Haiti	"
                    GetFlag = My.Resources.HAI
                Case "HKG" '	[82]	 Hong Kong	HOK (1960–1968)"
                    GetFlag = My.Resources.HKG
                Case "HON" '	[83]	 Honduras	"
                    GetFlag = My.Resources.HON
                Case "HUN" '	[84]	 Hungary	UNG (1956 W, 1960 S)"
                    GetFlag = My.Resources.HUN
                Case "INA" '	[85]	 Indonesia	INS (1960)"
                    GetFlag = My.Resources.INA
                Case "IND" '	[86]	 India	"
                    GetFlag = My.Resources.IND
                Case "IRI" '	[87]	 Iran	IRN (1956–1988), IRA (1968 W)"
                    GetFlag = My.Resources.IRI
                Case "IRL" '	[88]	 Ireland	"
                    GetFlag = My.Resources.IRL
                Case "IRQ" '	[89]	 Iraq	IRK (1960, 1968)"
                    GetFlag = My.Resources.IRQ
                Case "ISL" '	[90]	 Iceland	ICE (1960 W, 1964 S)"
                    GetFlag = My.Resources.ISL
                Case "ISR" '	[91]	 Israel	"
                    GetFlag = My.Resources.ISR
                Case "ISV" '	[92]	 Virgin Islands	"
                    GetFlag = My.Resources.IVB
                Case "ITA" '	[93]	 Italy	"
                    GetFlag = My.Resources.ITA
                Case "IVB" '	[94]	 British Virgin Islands	"
                    GetFlag = My.Resources.notknown
                Case "JAM" '	[95]	 Jamaica	"
                    GetFlag = My.Resources.JAM
                Case "JOR" '	[96]	 Jordan	"
                    GetFlag = My.Resources.JOR
                Case "JPN" '	[97]	 Japan	GIA (1956 W, 1960 S), JAP (1960 W)"
                    GetFlag = My.Resources.JPN
                Case "KAZ" '	[98]	 Kazakhstan	"
                    GetFlag = My.Resources.KAZ
                Case "KEN" '	[99]	 Kenya	"
                    GetFlag = My.Resources.KEN
                Case "KGZ" '	[100]	 Kyrgyzstan	"
                    GetFlag = My.Resources.KGZ
                Case "KIR" '	[101]	 Kiribati	"
                    GetFlag = My.Resources.KIR
                Case "KOR" '	[102]	 South Korea	COR (1956 W, 1960 S, 1968 S, 1972 S)"
                    GetFlag = My.Resources.KOR
                Case "KSA" '	[103]	 Saudi Arabia	ARS (1968–1976), SAU (1980–1984)"
                    GetFlag = My.Resources.KSA
                Case "KUW" '	[104]	 Kuwait	"
                    GetFlag = My.Resources.KUW
                Case "LAO" '	[105]	 Laos	"
                    GetFlag = My.Resources.LAO
                Case "LAT" '	[106]	 Latvia	"
                    GetFlag = My.Resources.LAT
                Case "LBA" '	[107]	 Libya	LYA (1964), LBY (1968 W)"
                    GetFlag = My.Resources.LBA
                Case "LBR" '	[108]	 Liberia	"
                    GetFlag = My.Resources.LBR
                Case "LCA" '	[109]	 Saint Lucia	"
                    GetFlag = My.Resources.LCA
                Case "LES" '	[110]	 Lesotho	"
                    GetFlag = My.Resources.LES
                Case "LIB" '	[111]	 Lebanon	LEB (1960 W, 1964 S)"
                    GetFlag = My.Resources.FLAGLIB
                Case "LIE" '	[112]	 Liechtenstein	LIC (1956 W, 1964 S, 1968 W)"
                    GetFlag = My.Resources.LIE
                Case "LTU" '	[113]	 Lithuania	LIT (1992 W)"
                    GetFlag = My.Resources.LTU
                Case "LUX" '	[114]	 Luxembourg	"
                    GetFlag = My.Resources.LUX
                Case "MAD" '	[115]	 Madagascar	MAG (1964)"
                    GetFlag = My.Resources.MAD
                Case "MAR" '	[116]	 Morocco	MRC (1964)"
                    GetFlag = My.Resources.MAR
                Case "MAS" '	[117]	 Malaysia	MAL (1964–1988)"
                    GetFlag = My.Resources.MAS
                Case "MAW" '	[118]	 Malawi	"
                    GetFlag = My.Resources.MAW
                Case "MDA" '	[119]	 Moldova	MLD (1994)"
                    GetFlag = My.Resources.MDA
                Case "MDV" '	[120]	 Maldives	"
                    GetFlag = My.Resources.MDV
                Case "MEX" '	[121]	 Mexico	"
                    GetFlag = My.Resources.MEX
                Case "MGL" '	[122]	 Mongolia	MON (1968 W)"
                    GetFlag = My.Resources.MGL
                Case "MHL" '	[123]	 Marshall Islands	"
                    GetFlag = My.Resources.MHL
                Case "MKD" '	[124]	 Macedonia	"
                    GetFlag = My.Resources.MKD
                Case "MLI" '	[125]	 Mali	"
                    GetFlag = My.Resources.MLI
                Case "MLT" '	[126]	 Malta	MAT (1960–1964)"
                    GetFlag = My.Resources.MLT
                Case "MNE" '	[127]	 Montenegro	"
                    GetFlag = My.Resources.MNE
                Case "MON" '	[128]	 Monaco	"
                    GetFlag = My.Resources.MON
                Case "MOZ" '	[129]	 Mozambique	"
                    GetFlag = My.Resources.MOZ
                Case "MRI" '	[130]	 Mauritius	"
                    GetFlag = My.Resources.MRI
                Case "MTN" '	[131]	 Mauritania	"
                    GetFlag = My.Resources.MTN
                Case "MYA" '	[132]	 Myanmar	BIR (1960, 1968–1988), BUR (1964)"
                    GetFlag = My.Resources.MYA
                Case "NAM" '	[133]	 Namibia	"
                    GetFlag = My.Resources.NAM
                Case "NCA" '	[134]	 Nicaragua	NCG (1964), NIC (1968)"
                    GetFlag = My.Resources.NCA
                Case "NED" '	[135]	 Netherlands	OLA (1956 W), NET (1960 W), PBA (1960 S), NLD (1964 S), HOL (1968–1988)"
                    GetFlag = My.Resources.NED
                Case "NEP" '	[136]	 Nepal	"
                    GetFlag = My.Resources.NEP
                Case "NGR" '	[137]	 Nigeria	NGA (1964)"
                    GetFlag = My.Resources.NGR
                Case "NIG" '	[138]	 Niger	NGR (1964)"
                    GetFlag = My.Resources.NIG
                Case "NOR" '	[139]	 Norway	"
                    GetFlag = My.Resources.NOR
                Case "NRU" '	[140]	 Nauru	"
                    GetFlag = My.Resources.NRU
                Case "NZL" '	[141]	 New Zealand	NZE (1960, 1968 W)"
                    GetFlag = My.Resources.NZL
                Case "OMA" '	[142]	 Oman	"
                    GetFlag = My.Resources.OMA
                Case "PAK" '	[143]	 Pakistan	"
                    GetFlag = My.Resources.PAK
                Case "PAN" '	[144]	 Panama	"
                    GetFlag = My.Resources.PAN
                Case "PAR" '	[145]	 Paraguay	"
                    GetFlag = My.Resources.PAR
                Case "PER" '	[146]	 Peru	"
                    GetFlag = My.Resources.PER
                Case "PHI" '	[147]	 Philippines	FIL (1960, 1968)"
                    GetFlag = My.Resources.PHI
                Case "PLE" '	[148]	 Palestine	"
                    GetFlag = My.Resources.PLE
                Case "PLW" '	[149]	 Palau	"
                    GetFlag = My.Resources.PLW
                Case "PNG" '	[150]	 Papua New Guinea	NGY (1976–1980), NGU (1984–1988)"
                    GetFlag = My.Resources.PNG
                Case "POL" '	[151]	 Poland	"
                    GetFlag = My.Resources.POL
                Case "POR" '	[152]	 Portugal	"
                    GetFlag = My.Resources.POR
                Case "PRK" '	[153]	 North Korea	NKO (1964 S, 1968 W), CDN (1968)"
                    GetFlag = My.Resources.PRK
                Case "PUR" '	[154]	 Puerto Rico	PRI (1960), PRO (1968)"
                    GetFlag = My.Resources.PUR
                Case "QAT" '	[155]	 Qatar	"
                    GetFlag = My.Resources.QAT
                Case "ROU" '	[156]	 Romania	ROM (1956–1960, 1972–2006), RUM (1964–1968)"
                    GetFlag = My.Resources.CHA
                Case "RSA" '	[157]	 South Africa	SAF (1960–1972)"
                    GetFlag = My.Resources.RSA
                Case "RUS" '	[158]	 Russia	"
                    GetFlag = My.Resources.RUS
                Case "RWA" '	[159]	 Rwanda	"
                    GetFlag = My.Resources.RWA
                Case "SAM" '	[160]	 Samoa	"
                    GetFlag = My.Resources.SAM
                Case "SEN" '	[161]	 Senegal	SGL (1964)"
                    GetFlag = My.Resources.SEN
                Case "SEY" '	[162]	 Seychelles	"
                    GetFlag = My.Resources.SEY
                Case "SIN" '	[163]	 Singapore	"
                    GetFlag = My.Resources.SIN
                Case "SKN" '	[164]	 Saint Kitts and Nevis	"
                    GetFlag = My.Resources.SKN
                Case "SLE" '	[165]	 Sierra Leone	SLA (1968)"
                    GetFlag = My.Resources.SLE
                Case "SLO" '	[166]	 Slovenia	"
                    GetFlag = My.Resources.SLO
                Case "SMR" '	[167]	 San Marino	SMA (1960–1964)"
                    GetFlag = My.Resources.SMR
                Case "SOL" '	[168]	 Solomon Islands	"
                    GetFlag = My.Resources.SOL
                Case "SOM" '	[169]	 Somalia	"
                    GetFlag = My.Resources.SOM
                Case "SRB" '	[170]	 Serbia	"
                    GetFlag = My.Resources.SRB
                Case "SRI" '	[171]	 Sri Lanka	CEY (1960–1972)"
                    GetFlag = My.Resources.SRI
                Case "STP" '	[172]	 São Tomé and Príncipe	"
                    GetFlag = My.Resources.STP
                Case "SUD" '	[173]	 Sudan	"
                    GetFlag = My.Resources.SUD
                Case "SUI" '	[174]	 Switzerland	SVI (1956 W, 1960 S), SWI (1960 W, 1964 S)"
                    GetFlag = My.Resources.SUI
                Case "SUR" '	[175]	 Suriname	"
                    GetFlag = My.Resources.SUR
                Case "SVK" '	[176]	 Slovakia	"
                    GetFlag = My.Resources.SVK
                Case "SWE" '	[177]	 Sweden	SVE (1956 W, 1960 S), SUE (1968 S)"
                    GetFlag = My.Resources.SWE
                Case "SWZ" '	[178]	 Swaziland	"
                    GetFlag = My.Resources.SWZ
                Case "SYR" '	[179]	 Syria	RAU (1960), SIR (1968)"
                    GetFlag = My.Resources.SYR
                Case "TAN" '	[180]	 Tanzania	"
                    GetFlag = My.Resources.TAN
                Case "TGA" '	[181]	 Tonga	TON (1984)"
                    GetFlag = My.Resources.TGA
                Case "THA" '	[182]	 Thailand	"
                    GetFlag = My.Resources.THA
                Case "TJK" '	[183]	 Tajikistan	"
                    GetFlag = My.Resources.TJK
                Case "TKM" '	[184]	 Turkmenistan	"
                    GetFlag = My.Resources.TKM
                Case "TLS" '	[185]	 Timor-Leste	IOA (Individual Olympic Athletes, 2000)"
                    GetFlag = My.Resources.TLS
                Case "TOG" '	[186]	 Togo	"
                    GetFlag = My.Resources.TOG
                    ' Case "TPE" '	[187]	 Chinese Taipei[5]	RCF (1960), TWN (1964–1968), ROC (1972–1976)"
                    '    GetFlag = My.Resources.TPE
                Case "TRI" '	[188]	 Trinidad and Tobago	TRT (1964–1968)"
                    GetFlag = My.Resources.TRI
                Case "TUN" '	[189]	 Tunisia	"
                    GetFlag = My.Resources.TUN
                Case "TUR" '	[190]	 Turkey	"
                    GetFlag = My.Resources.TUR
                Case "TUV" '	[191]	 Tuvalu	"
                    GetFlag = My.Resources.TUV
                Case "UAE" '	[192]	 United Arab Emirates	"
                    GetFlag = My.Resources.UAE
                Case "UGA" '	[193]	 Uganda	"
                    GetFlag = My.Resources.UGA
                Case "UKR" '	[194]	 Ukraine	"
                    GetFlag = My.Resources.UKR
                Case "URU" '	[195]	 Uruguay	URG (1968)"
                    GetFlag = My.Resources.URU
                Case "USA" '	[196]	 United States	SUA (1960 S), EUA (1968 S)"
                    GetFlag = My.Resources.USA
                Case "UZB" '	[197]	 Uzbekistan	"
                    GetFlag = My.Resources.UZB
                Case "VAN" '	[198]	 Vanuatu	"
                    GetFlag = My.Resources.VAN
                Case "VEN" '	[199]	 Venezuela	"
                    GetFlag = My.Resources.VEN
                Case "VIE" '	[200]	 Vietnam	VET (1964), VNM (1968–1976)"
                    GetFlag = My.Resources.VIE
                Case "VIN" '	[201]	 Saint Vincent and the Grenadines	"
                    GetFlag = My.Resources.VIN
                Case "YEM" '	[202]	 Yemen	"
                    GetFlag = My.Resources.YEM
                Case "ZAM" '	[203]	 Zambia	NRH (1964)"
                    GetFlag = My.Resources.ZAM
                Case "ZIM" '	[204]	 Zimbabwe	RHO (1960–1972)"
                    GetFlag = My.Resources.ZIM
                Case "AHO"
                    GetFlag = My.Resources.AHO
                Case Else
                    GetFlag = My.Resources.HELP
                    'ApplicationError = "No flag/resource for " & pNationality & "!"
            End Select
        Catch ex As Exception
            GetFlag = Nothing
            ApplicationError = "No flag/resource for " & pNationality & "!"
        End Try

    End Function
End Class

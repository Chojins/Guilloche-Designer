'============================================================================
'Guilloche pattern generator based on 4 bar linkage
'=============================================================================
'Imports ZedGraph
Imports System.Math
Imports System.Xml
'Imports Charts

Public Class Form1
    'Dim list4 As New PointPairList

    Dim XPointList As New List(Of Double)
    Dim YPointList As New List(Of Double)
    Private _plotData As Double
    Private _plotData1 As Double
    Dim PlotData As New DataTable()
    Dim xmin As Double
    Dim ymin As Double
    Dim xmax As Double
    Dim ymax As Double
    Dim xrange As Double
    Dim yrange As Double
    Dim Iterations As Double
    Dim ImagePreview As New Drawing.Bitmap(500, 500)
    Dim GFX As Graphics = Graphics.FromImage(ImagePreview)

    Dim period1 As Double = 1
    Dim period2 As Double = 1
    Dim period3 As Double = 1
    Dim k1 As Double, k2 As Double, k3 As Double, alength As Double, blength As Double, clength As Double, dlength As Double, radius2 As Double

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GFX.FillRectangle(Brushes.White, 0, 0, PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = ImagePreview
        Generate()



    End Sub
    Public Sub Generate()
        XPointList.Clear()
        XPointList.Clear()
        YPointList.Clear()


        ' Make up some data points based on the Sine function
        'Dim list As New PointPairList
        'Dim list2 As New PointPairList
        'Dim list3 As New PointPairList

        Dim i As Integer, m1x As Double, m1y As Double, m2x As Double, m2y As Double

        Dim t As Double = 0

        period1 = M1Period.Value
        period2 = M2Period.Value
        period3 = M3Period.Value

        alength = aLengthTextbox.Value ' M1 radius
        blength = bLengthTextbox.Value  'link lengths
        clength = cLengthTextbox.Value
        radius2 = M2LengthTextbox.Value  'M2 radius

        If alength > 0 And blength > 0 And clength > 0 And radius2 > 0 Then
            If period1 > 0 And period2 > 0 And period3 > 0 Then
                Dim m1center(,) As Double = New Double(,) {{Convert.ToDouble(M1XTextbox.Text), Convert.ToDouble(M1YTextbox.Text)}}
                Dim m2center(,) As Double = New Double(,) {{Convert.ToDouble(M2XTextbox.Text), Convert.ToDouble(M2YTextbox.Text)}}
                Dim m3center(,) As Double = New Double(,) {{Convert.ToDouble(M3XTextbox.Text), Convert.ToDouble(M3YTextbox.Text)}}

                Dim TimeStep As Double = Convert.ToDouble(TStepTextbox.Text)
                Iterations = Convert.ToDouble(IterationsTextBox.Text)

                Dim Xcentre As Double = M3XTextbox.Text 'center of image is center of table rotatiom motor
                Dim Ycentre As Double = M3YTextbox.Text

                ' Do all the Math
                For i = 0 To Iterations

                    Dim theta2 As Double = 2 * PI * (t / period1)
                    dlength = Sqrt((m2center(0, 0) - m1center(0, 0)) ^ 2 + (m2center(0, 1) - m1center(0, 1)) ^ 2) 'distance between motors

                    k1 = dlength / alength
                    k2 = dlength / clength
                    k3 = ((alength ^ 2) + (clength ^ 2) + (dlength ^ 2) - (blength ^ 2)) / (2 * alength * clength)

                    'calculate the motor positions
                    m1x = alength * Cos(theta2) + m1center(0, 0)
                    m1y = alength * Sin(theta2) + m1center(0, 1)
                    m2x = -radius2 * Cos(2 * PI * (t / period2)) + m2center(0, 0)
                    m2y = -radius2 * Sin(2 * PI * (t / period2)) + m2center(0, 1)


                    'calculate the linkage position

                    'list.Add(m1x, m1y)
                    'list2.Add(m2x, m2y)

                    Dim Cterm As Double = k1 - (k2 + 1) * Cos(theta2) + k3
                    Dim Bterm As Double = -2 * Sin(theta2)
                    Dim Aterm As Double = Cos(theta2) - k1 - k2 * Cos(theta2) + k3

                    Dim Theta4 As Double = 2 * Atan(-Bterm - Sqrt(Bterm ^ 2 - 4 * Aterm * Cterm)) + PI / 4

                    Dim xlink As Double = clength * Cos(Theta4) + m2x
                    Dim ylink As Double = clength * Sin(Theta4) + m2y

                    'list3.Add(xlink, ylink)

                    Dim m3radius As Double = Sqrt((xlink - m3center(0, 0)) ^ 2 + (ylink - m3center(0, 1)) ^ 2) 'find the radius of the wheel center to the linkage

                    Dim wheelangle As Double = Asin((ylink - m3center(0, 1)) / m3radius)

                    Dim wheelRotated As Double = wheelangle + (t / period3) * 2 * PI

                    Dim xpen As Double
                    Dim ypen As Double
                    xpen = m3radius * Cos(wheelRotated) + m3center(0, 0)
                    ypen = m3radius * Sin(wheelRotated) + m3center(0, 1)

                    'list4.Add(xpen, ypen)

                    If i = 0 Then
                        xmax = xpen
                        ymax = ypen
                        xmin = xpen
                        ymin = ypen
                    End If

                    If xpen < xmin Then
                        xmin = xpen
                    End If
                    If xpen > xmax Then
                        xmax = xpen
                    End If
                    If ypen < ymin Then
                        ymin = ypen
                    End If
                    If ypen > ymax Then
                        ymax = ypen
                    End If



                    If (xmax - Xcentre) < (Xcentre - xmin) Then
                        xrange = 2 * Sqrt((xmax - Xcentre) ^ 2 + (ymax - Ycentre) ^ 2)
                    Else

                        xrange = 2 * Sqrt((Xcentre - xmin) ^ 2 + (Ycentre - ymin) ^ 2)
                    End If

                    yrange = xrange


                    XPointList.Add(xpen) 'generate list for printing svg with seperating , between x and y and spaces between points
                    YPointList.Add(ypen)

                    t = t + TimeStep
                Next i

                '********************************** Draw in picture box *********************************************


                'shift xmin to x=0
                Dim shiftx As Double = 0 - Xcentre
                'shift ymin to y=0
                Dim shifty As Double = 0 - Ycentre

                'find scale
                Dim XScale As Double = PictureBox1.Width / xrange
                Dim YScale As Double = PictureBox1.Height / yrange
                Dim Scale As Double = Min(XScale, YScale)

                Dim c As Integer

                For c = 0 To XPointList.Count - 1
                    XPointList(c) = ((XPointList(c) + shiftx) * Scale) + (PictureBox1.Width / 2)
                    YPointList(c) = ((YPointList(c) + shifty) * Scale) + (PictureBox1.Height / 2)
                Next

                GFX.FillRectangle(Brushes.White, 0, 0, PictureBox1.Width, PictureBox1.Height)

                Dim XPoint1 As Integer
                Dim XPoint2 As Integer
                Dim YPoint1 As Integer
                Dim YPoint2 As Integer

                'check if the solutions are valid otherwise white out the image
                If Double.IsNaN(XPointList(1)) Then
                    GFX.FillRectangle(Brushes.White, 0, 0, PictureBox1.Width, PictureBox1.Height)
                Else

                    For c = 0 To XPointList.Count - 2

                        If Double.IsNaN(XPointList(c)) Then
                        Else
                            XPoint1 = CInt(XPointList(c))
                        End If
                        If Double.IsNaN(XPointList(c + 1)) Then
                        Else
                            XPoint2 = CInt(XPointList(c + 1))
                        End If
                        If Double.IsNaN(YPointList(c)) Then
                        Else
                            YPoint1 = CInt(YPointList(c))
                        End If
                        If Double.IsNaN(YPointList(c + 1)) Then
                        Else
                            YPoint2 = CInt(YPointList(c + 1))
                        End If

                        GFX.DrawLine(Pens.Black, XPoint1, YPoint1, XPoint2, YPoint2)
                    Next

                    PictureBox1.Image = ImagePreview

                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        'Normalise the data for svg generation
        'shift xmin to x=0
        Dim shiftx As Double = 0 - xmin
        'shift ymin to y=0
        Dim shifty As Double = 0 - ymin
        Dim c As Integer

        For c = 0 To XPointList.Count - 1
            XPointList(c) = XPointList(c) + shiftx
            YPointList(c) = YPointList(c) + shifty
        Next

        Dim SVGDirectory As String
        Dim FileNum As Short
        Dim DateString As String = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
        SVGDirectory = My.Settings.SvgDir & "guilloche-" & DateString & ".svg"
        FileNum = FreeFile()
        FileOpen(FileNum, SVGDirectory, OpenMode.Output)



        'Print the machine initial parameters and add some id data comments to the start of the file 
        PrintLine(FileNum, "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
        PrintLine(FileNum, "<svg viewBox=""0 0 " & xrange & " " & yrange & """ xmlns=""http://www.w3.org/2000/svg"" version=""1.1"" xmlns:xlink=""http://www.w3.org/1999/xlink"">")

        'Add comment with parameters used
        PrintLine(FileNum, "<!-- Parameters used to generate this file")

        PrintLine(FileNum, "<period1='" & M1Period.Value & "'")
        PrintLine(FileNum, "<period2='" & M2Period.Value & "'")
        PrintLine(FileNum, "<period3='" & M3Period.Value & "'")

        PrintLine(FileNum, "<m1centerX='" & M1XTextbox.Text & "'")
        PrintLine(FileNum, "<m2centerX='" & M2XTextbox.Text & "'")
        PrintLine(FileNum, "<m3centerX='" & M3XTextbox.Text & "'")
        PrintLine(FileNum, "<m1centerY='" & M1YTextbox.Text & "'")
        PrintLine(FileNum, "<m2centerY='" & M2YTextbox.Text & "'")
        PrintLine(FileNum, "<m3centerY='" & M3YTextbox.Text & "'")

        PrintLine(FileNum, "<TimeStep='" & TStepTextbox.Text & "'")
        PrintLine(FileNum, "<Iterations='" & IterationsTextBox.Text & "'")

        PrintLine(FileNum, "<M1Radius='" & aLengthTextbox.Value & "'")
        PrintLine(FileNum, "<blength='" & bLengthTextbox.Value & "'")
        PrintLine(FileNum, "<clength='" & cLengthTextbox.Value & "'")
        PrintLine(FileNum, "<M2Radius='" & M2LengthTextbox.Text & "'")

        PrintLine(FileNum, "-->")
        '**************************

        Print(FileNum, "<path d=""M ")
        Dim i As Integer

        For i = 0 To XPointList.Count - 1

            Print(FileNum, System.Math.Round(XPointList(i), 2) & " " & System.Math.Round(YPointList(i), 2) & " L ")
        Next
        PrintLine(FileNum, "z"" fill=""none"" stroke=""black"" stroke-width=""0.2""/>")



        PrintLine(FileNum, "</svg>")

        'Print(FileNum, "<polyline points=""")
        'Dim i As Integer

        'For i = 0 To XPointList.Count - 1

        '    Print(FileNum, System.Math.Round(XPointList(i), 2) & "," & System.Math.Round(YPointList(i), 2) & " ")
        'Next
        'PrintLine(FileNum, """ fill=""none"" stroke=""black"" stroke-width=""0.2""/>")



        'PrintLine(FileNum, "</svg>")

        'close the .nc text file and we're done
        FileClose(FileNum)

    End Sub

    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click
        Dim txtPath As String
        OpenFileDialog1.ShowDialog()
        txtPath = OpenFileDialog1.FileName
        Dim reader As XmlNodeReader = Nothing
        'Try

        Dim filestring As String = IO.File.ReadAllText(txtPath)

        Dim doc As New Xml.XmlDocument
        doc.LoadXml(filestring)

        'or just in this case doc.LoadXML(xmlString)
        reader = New Xml.XmlNodeReader(doc)


        ' display each node's content
        While reader.Read

            Select Case reader.NodeType

                ' if Element, display its name
                Case XmlNodeType.Element

                    ' increase tab depth
                    Console.WriteLine("<" & reader.Name & ">")

                    ' if empty element, decrease depth
                    If reader.IsEmptyElement Then
                        Console.WriteLine("Empty Element")
                    End If

                Case XmlNodeType.Comment ' if Comment, display it

                    MessageBox.Show("<!--" & reader.Value & _
                           "-->")
                    Dim Commentstring As String = reader.Value
                    Dim words As String()
                    words = reader.Value.Split(New Char() {"'"c})

                    M1Period.Value = words(1)
                    M2Period.Value = words(3)
                    M3Period.Value = words(5)

                    M1XTextbox.Text = words(7)
                    M2XTextbox.Text = words(9)
                    M3XTextbox.Text = words(11)
                    M1YTextbox.Text = words(13)
                    M2YTextbox.Text = words(15)
                    M3YTextbox.Text = words(17)

                    TStepTextbox.Text = words(19)
                    IterationsTextBox.Text = words(21)

                    aLengthTextbox.Value = words(23)
                    bLengthTextbox.Value = words(25)
                    cLengthTextbox.Value = words(27)
                    M2LengthTextbox.Value = words(29)

                Case XmlNodeType.Text ' if Text, display it
                    Console.WriteLine(reader.Value)

                    ' if XML declaration, display it
                Case XmlNodeType.XmlDeclaration
                    Console.WriteLine("<?" & reader.Name & " " & _
                       reader.Value & "?>")

                    ' if EndElement, display it and decrement depth
                Case XmlNodeType.EndElement
                    Console.WriteLine("</" & reader.Name & ">")


            End Select

        End While




    End Sub

    Private Sub NCSaveButton_Click(sender As Object, e As EventArgs) Handles NCSaveButton.Click
        'Normalise the plot for offset at centre of the page
        Dim Xcentre As Double = M3XTextbox.Text 'center of image is center of table rotatiom motor
        Dim Ycentre As Double = M3YTextbox.Text

        'shift xmin to x=0
        Dim shiftx As Double = 0 - Xcentre
        'shift ymin to y=0
        Dim shifty As Double = 0 - Ycentre

        'find scale
        Dim XScale As Double = PageXSize.Text / xrange
        Dim YScale As Double = PageYSize.Text / yrange
        Dim Scale As Double = Min(XScale, YScale)

        Dim c As Integer

        For c = 0 To XPointList.Count - 1
            XPointList(c) = (XPointList(c) + shiftx) * Scale
            YPointList(c) = (YPointList(c) + shifty) * Scale
        Next

        Dim SVGDirectory As String
        Dim FileNum As Short
        Dim DateString As String = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
        SVGDirectory = My.Settings.GCodeDir & DateString & "guilloche-" & DateString & ".ngc"

        FileNum = FreeFile()
        FileOpen(FileNum, SVGDirectory, OpenMode.Output)



        'Add comment with parameters used
        PrintLine(FileNum, "(!-- Parameters used to generate this file)")

        PrintLine(FileNum, "(period1='" & M1Period.Value & ")")
        PrintLine(FileNum, "(period2='" & M2Period.Value & ")")
        PrintLine(FileNum, "(period3='" & M3Period.Value & ")")

        PrintLine(FileNum, "(m1centerX='" & M1XTextbox.Text & ")")
        PrintLine(FileNum, "(m2centerX='" & M2XTextbox.Text & ")")
        PrintLine(FileNum, "(m3centerX='" & M3XTextbox.Text & ")")
        PrintLine(FileNum, "(m1centerY='" & M1YTextbox.Text & ")")
        PrintLine(FileNum, "(m2centerY='" & M2YTextbox.Text & ")")
        PrintLine(FileNum, "(m3centerY='" & M3YTextbox.Text & ")")

        PrintLine(FileNum, "(TimeStep='" & TStepTextbox.Text & ")")
        PrintLine(FileNum, "(Iterations='" & IterationsTextBox.Text & ")")

        PrintLine(FileNum, "(M1Radius='" & aLengthTextbox.Value & ")")
        PrintLine(FileNum, "(blength='" & bLengthTextbox.Value & ")")
        PrintLine(FileNum, "(clength='" & cLengthTextbox.Value & ")")
        PrintLine(FileNum, "(M2Radius='" & M2LengthTextbox.Value & ")")
        PrintLine(FileNum, "G21 G90 G64 G40")
        PrintLine(FileNum, "T0 M6")
        PrintLine(FileNum, "M3 S1000 F2000")


        Dim i As Integer

        For i = 0 To XPointList.Count - 1
            If i = 1 Then
                PrintLine(FileNum, "G1 X" & System.Math.Round(XPointList(i), 2) & " Y" & System.Math.Round(YPointList(i), 2))
                PrintLine(FileNum, "G0 Z90.0") 'Pen down when at first position
            Else
                PrintLine(FileNum, "G1 X" & System.Math.Round(XPointList(i), 2) & " Y" & System.Math.Round(YPointList(i), 2))
            End If
        Next

        PrintLine(FileNum, "G0 Z0.0")
        PrintLine(FileNum, "M5")
        PrintLine(FileNum, "M30")


        FileClose(FileNum)



    End Sub

    Private Sub VideoButton_Click(sender As Object, e As EventArgs) Handles VideoButton.Click
        Dim Start As Integer
        Dim Finish As Integer
        Start = CInt(VideoStart.Text)
        Finish = CInt(VideoEnd.Text)

        Dim Name As String
        Dim FileSaveString As String

        Dim i As Integer
        For i = Start To Finish
            'blength = i
            bLengthTextbox.Value = i
            Generate()
            Name = CStr(i)

            FileSaveString = My.Settings.VideoDir & Name & ".Png"
            ImagePreview.Save(FileSaveString, System.Drawing.Imaging.ImageFormat.Png)

        Next



    End Sub


    Private Sub M1Period_ValueChanged(sender As Object, e As EventArgs) Handles M1Period.ValueChanged
        Generate()
    End Sub

    Private Sub M2Period_ValueChanged(sender As Object, e As EventArgs) Handles M2Period.ValueChanged
        Generate()
    End Sub

    Private Sub M3Period_ValueChanged(sender As Object, e As EventArgs) Handles M3Period.ValueChanged
        Generate()
    End Sub

    Private Sub GenButton_Click(sender As Object, e As EventArgs) Handles GenButton.Click
        Generate()
    End Sub

    Private Sub aLengthTextbox_ValueChanged(sender As Object, e As EventArgs) Handles aLengthTextbox.ValueChanged
        Generate()
    End Sub

    Private Sub bLengthTextbox_ValueChanged(sender As Object, e As EventArgs) Handles bLengthTextbox.ValueChanged
        Generate()
    End Sub

    Private Sub cLengthTextbox_ValueChanged(sender As Object, e As EventArgs) Handles cLengthTextbox.ValueChanged
        Generate()
    End Sub

    Private Sub M2LengthTextbox_ValueChanged(sender As Object, e As EventArgs) Handles M2LengthTextbox.ValueChanged
        Generate()
    End Sub


End Class

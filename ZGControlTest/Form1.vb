'============================================================================
'ZedGraph demo code
'The code contained in this file (only) is released into the public domain, so you
'can copy it into your project without any license encumbrance.  Note that
'the actual ZedGraph library code is licensed under the LGPL, which is not
'public domain.
'
'This file is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
'=============================================================================
Imports ZedGraph
Imports System.Math
Imports System.Xml
Imports Charts

Public Class Form1
    Dim list4 As New PointPairList
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






    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenButton.Click
        list4.Clear()
        XPointList.Clear()
        YPointList.Clear()
        Dim myCurve As LineItem
        Dim myPane As GraphPane = zg1.GraphPane

        ' Set the titles and axis labels
        myPane.Title.Text = "Demonstration of Dual Y Graph"
        myPane.XAxis.Title.Text = "x"
        myPane.YAxis.Title.Text = "y"
        'myPane.Y2Axis.Title.Text = "x"

        ' Make up some data points based on the Sine function
        Dim list As New PointPairList
        Dim list2 As New PointPairList
        Dim list3 As New PointPairList


        Dim i As Integer, m1x As Double, m1y As Double, m2x As Double, m2y As Double


        Dim t As Double = 0

        Dim period1 As Double = Convert.ToDouble(M1Textbox.Text)
        Dim period2 As Double = Convert.ToDouble(M2Textbox.Text)
        Dim period3 As Double = Convert.ToDouble(M3Textbox.Text)

        Dim m1center(,) As Double = New Double(,) {{Convert.ToDouble(M1XTextbox.Text), Convert.ToDouble(M1YTextbox.Text)}}
        Dim m2center(,) As Double = New Double(,) {{Convert.ToDouble(M2XTextbox.Text), Convert.ToDouble(M2YTextbox.Text)}}
        Dim m3center(,) As Double = New Double(,) {{Convert.ToDouble(M3XTextbox.Text), Convert.ToDouble(M3YTextbox.Text)}}

        Dim TimeStep As Double = Convert.ToDouble(TStepTextbox.Text)
        Iterations = Convert.ToDouble(IterationsTextBox.Text)
        For i = 0 To Iterations

            Dim theta2 As Double = 2 * PI * (t / period1)



            Dim k1 As Double, k2 As Double, k3 As Double, alength As Double, blength As Double, clength As Double, dlength As Double

            alength = Convert.ToDouble(aLengthTextbox.Text) ' M1 radius
            blength = Convert.ToDouble(bLengthTextbox.Text) 'link lengths
            clength = Convert.ToDouble(cLengthTextbox.Text)
            dlength = Sqrt((m2center(0, 0) - m1center(0, 0)) ^ 2 + (m2center(0, 1) - m1center(0, 1)) ^ 2) 'distance between motors

            Dim radius2 As Double = 80 'M2 radius
            radius2 = Convert.ToDouble(M2LengthTextbox.Text) ' M1 radius 'M2 radius

            k1 = dlength / alength
            k2 = dlength / clength
            k3 = ((alength ^ 2) + (clength ^ 2) + (dlength ^ 2) - (blength ^ 2)) / (2 * alength * clength)

            'calculate the motor positions
            m1x = alength * Cos(theta2) + m1center(0, 0)
            m1y = alength * Sin(theta2) + m1center(0, 1)
            m2x = -radius2 * Cos(2 * PI * (t / period2)) + m2center(0, 0)
            m2y = -radius2 * Sin(2 * PI * (t / period2)) + m2center(0, 1)


            'calculate the linkage position

            list.Add(m1x, m1y)
            list2.Add(m2x, m2y)

            Dim Cterm As Double = k1 - (k2 + 1) * Cos(theta2) + k3
            Dim Bterm As Double = -2 * Sin(theta2)
            Dim Aterm As Double = Cos(theta2) - k1 - k2 * Cos(theta2) + k3

            Dim Theta4 As Double = 2 * Atan(-Bterm - Sqrt(Bterm ^ 2 - 4 * Aterm * Cterm)) + PI / 4

            Dim xlink As Double = clength * Cos(Theta4) + m2x
            Dim ylink As Double = clength * Sin(Theta4) + m2y

            list3.Add(xlink, ylink)

            Dim m3radius As Double = Sqrt((xlink - m3center(0, 0)) ^ 2 + (ylink - m3center(0, 1)) ^ 2) 'find the radius of the wheel center to the linkage

            Dim wheelangle As Double = Asin((ylink - m3center(0, 1)) / m3radius)

            Dim wheelRotated As Double = wheelangle + (t / period3) * 2 * PI

            Dim xpen As Double = m3radius * Cos(wheelRotated) + m3center(0, 0)
            Dim ypen As Double = m3radius * Sin(wheelRotated) + m3center(0, 1)

            list4.Add(xpen, ypen)

            If i = 0 Then
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

            xrange = Abs(xmax - xmin)
            yrange = Abs(ymax - ymin)

            XPointList.Add(xpen) 'generate list for pinting svg with seperating , between x and y and spaces between points
            YPointList.Add(ypen)
            'save as datatable for svgC

            'PlotData.Columns.Add("x", GetType(Double))
            'PlotData.Columns.Add("y", GetType(Double))
            'PlotData.Rows.Add(xpen, ypen)

            t = t + TimeStep
        Next i



        ' Generate a red curve with diamond symbols, and "Alpha" in the legend

        'myCurve = myPane.AddCurve("Alpha", list, Color.Red, SymbolType.None)
        ' Fill the symbols with white
        'myCurve.Symbol.Fill = New Fill(Color.White)

        ' Generate a blue curve with circle symbols, and "Beta" in the legend
        'myCurve = myPane.AddCurve("Beta", list2, Color.Blue, SymbolType.None)
        ' Fill the symbols with white
        'myCurve.Symbol.Fill = New Fill(Color.White)

        ' Generate a yellow curve with circle symbols, and "Beta" in the legend
        'myCurve = myPane.AddCurve("Beta", list3, Color.Green, SymbolType.None)

        ' Generate a yellow curve with circle symbols, and "Beta" in the legend
        myCurve = myPane.AddCurve("", list4, Color.Black, SymbolType.None)
        ' Fill the symbols with white
        ' myCurve.Symbol.Fill = New Fill(Color.White)

        ' Associate this curve with the Y2 axis
        'myCurve.IsY2Axis = True

        ' Show the x axis grid
        myPane.XAxis.MajorGrid.IsVisible = True

        ' Make the Y axis scale red
        myPane.YAxis.Scale.FontSpec.FontColor = Color.Red
        myPane.YAxis.Title.FontSpec.FontColor = Color.Red
        ' turn off the opposite tics so the Y tics don't show up on the Y2 axis
        myPane.YAxis.MajorTic.IsOpposite = False
        myPane.YAxis.MinorTic.IsOpposite = False
        ' Don't display the Y zero line
        myPane.YAxis.MajorGrid.IsZeroLine = False
        ' Align the Y axis labels so they are flush to the axis
        myPane.YAxis.Scale.Align = AlignP.Inside
        ' Manually set the axis range
        'myPane.YAxis.Scale.Min = -60
        'myPane.YAxis.Scale.Max = 60

        ' Enable the Y2 axis display
        'myPane.Y2Axis.IsVisible = True
        ' Make the Y2 axis scale blue
        myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue
        myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue
        ' turn off the opposite tics so the Y2 tics don't show up on the Y axis
        myPane.Y2Axis.MajorTic.IsOpposite = False
        myPane.Y2Axis.MinorTic.IsOpposite = False
        ' Display the Y2 axis grid lines
        myPane.Y2Axis.MajorGrid.IsVisible = True
        ' Align the Y2 axis labels so they are flush to the axis
        myPane.Y2Axis.Scale.Align = AlignP.Inside

        ' Fill the axis background with a gradient
        myPane.Chart.Fill = New Fill(Color.White, Color.LightGray, 45.0F)

        ' Add a text box with instructions
        'Dim text As New TextObj( _
        '"Zoom: left mouse & drag" & Chr(10) & "Pan: middle mouse & drag" & Chr(10) & "Context Menu: right mouse", _
        '0.05F, 0.95F, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom)
        ' text.FontSpec.StringAlignment = StringAlignment.Near
        'myPane.GraphObjList.Add(text)

        ' Enable scrollbars if needed
        zg1.IsShowHScrollBar = True
        zg1.IsShowVScrollBar = True
        zg1.IsAutoScrollRange = True
        zg1.IsScrollY2 = True

        zg1.IsShowPointValues = True

        ' Size the control to fit the window
        SetSize()

        ' Tell ZedGraph to calculate the axis ranges
        ' Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
        ' up the proper scrolling parameters
        zg1.AxisChange()
        ' Make sure the Graph gets redrawn
        zg1.Invalidate()
    End Sub

    ' On resize action, resize the ZedGraphControl to fill most of the Form, with a small
    ' margin around the outside
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        SetSize()
    End Sub

    Private Sub SetSize()
        Dim loc As New Point(10, 10)
        zg1.Location = loc
        ' Leave a small margin around the outside of the control
        Dim size As New Size(Me.ClientRectangle.Width - 20, Me.ClientRectangle.Height - 20)
        zg1.Size = size
    End Sub

    'Display customized tooltips when the mouse hovers over a point
    Private Function MyPointValueEvent(ByVal control As ZedGraphControl, _
            ByVal pane As GraphPane, ByVal curve As CurveItem, _
            ByVal iPt As Integer) As String

        ' Get the PointPair that is under the mouse
        Dim pt As PointPair = curve(iPt)

        Return curve.Label.Text + " is " + pt.Y.ToString("f2") + " units at " + pt.X.ToString("f1") + " days"
    End Function

    ' Customize the context menu by adding a new item to the end of the menu
    Private Sub MyContextMenuBuilder(ByVal control As ZedGraphControl, _
               ByVal menu As ContextMenuStrip, ByVal mousePt As Point, _
               ByVal objState As ZedGraphControl.ContextMenuObjectState)

        Dim item As New ToolStripMenuItem
        item.Name = "add-beta"
        item.Tag = "add-beta"
        item.Text = "Add a new Beta Point"
        AddHandler item.Click, AddressOf Me.AddBetaPoint

        menu.Items.Add(item)
    End Sub

    ' Handle the "Add New Beta Point" context menu item.  This finds the curve with
    ' the CurveItem.Label = "Beta", and adds a new point to it.
    Private Sub AddBetaPoint(ByVal sender As Object, ByVal args As EventArgs)
        ' Get a reference to the "Beta" curve PointPairList
        Dim x As Double, y As Double

        Dim ip As IPointListEdit = zg1.GraphPane.CurveList("Beta").Points

        If (Not IsNothing(ip)) Then
            x = ip.Count * 5.0
            y = Math.Sin(ip.Count * Math.PI / 15.0) * 16.0 * 13.5
            ip.Add(x, y)
            zg1.AxisChange()
            zg1.Refresh()
        End If
    End Sub

    Private Sub zg1_ZoomEvent(ByVal control As ZedGraphControl, ByVal oldState As ZoomState, _
            ByVal newState As ZoomState)
        'Here we get notification everytime the user zooms

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        ' DataTable tbValues = GetData();
        'Try

        'Normalise the plot for svg generation
        'shift xmin to x=0
        Dim shiftx As Double = 0 - xmin
        'shift ymin to y=0
        Dim shifty As Double = 0 - ymin
        Dim c As Integer

        For c = 0 To list4.Count - 1
            XPointList(c) = XPointList(c) + shiftx
            YPointList(c) = YPointList(c) + shifty
        Next

        Dim SVGDirectory As String
        Dim FileNum As Short
        Dim DateString As String = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
        SVGDirectory = "C:\Users\Jacob\Documents\Guilloche\guilloche-" & DateString & ".svg"

        FileNum = FreeFile()
        FileOpen(FileNum, SVGDirectory, OpenMode.Output)



        'Print the machine initial parameters and add some id data comments to the start of the file 
        PrintLine(FileNum, "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
        PrintLine(FileNum, "<svg viewBox=""0 0 " & xrange & " " & yrange & """ xmlns=""http://www.w3.org/2000/svg"" version=""1.1"" xmlns:xlink=""http://www.w3.org/1999/xlink"">")

        'Add comment with parameters used
        PrintLine(FileNum, "<!-- Parameters used to generate this file")

        PrintLine(FileNum, "<period1='" & M1Textbox.Text & "'")
        PrintLine(FileNum, "<period2='" & M2Textbox.Text & "'")
        PrintLine(FileNum, "<period3='" & M3TextBox.Text & "'")

        PrintLine(FileNum, "<m1centerX='" & M1XTextbox.Text & "'")
        PrintLine(FileNum, "<m2centerX='" & M2XTextbox.Text & "'")
        PrintLine(FileNum, "<m3centerX='" & M3XTextbox.Text & "'")
        PrintLine(FileNum, "<m1centerY='" & M1YTextbox.Text & "'")
        PrintLine(FileNum, "<m2centerY='" & M2YTextbox.Text & "'")
        PrintLine(FileNum, "<m3centerY='" & M3YTextbox.Text & "'")

        PrintLine(FileNum, "<TimeStep='" & TStepTextbox.Text & "'")
        PrintLine(FileNum, "<Iterations='" & IterationsTextBox.Text & "'")

        PrintLine(FileNum, "<M1Radius='" & aLengthTextbox.Text & "'")
        PrintLine(FileNum, "<blength='" & bLengthTextbox.Text & "'")
        PrintLine(FileNum, "<clength='" & cLengthTextbox.Text & "'")
        PrintLine(FileNum, "<M2Radius='" & M2LengthTextbox.Text & "'")

        PrintLine(FileNum, "-->")
        '**************************
        '<path d="M 100 100 L 300 100 L 200 300 z"
        'fill="red" stroke="blue" stroke-width="3" />

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


        'Catch ex As Exception
        'MessageBox.Show("Exception: " & ex.Message)
        ' End Try


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

                    M1Textbox.Text = words(1)
                    M2Textbox.Text = words(3)
                    M3TextBox.Text = words(5)

                    M1XTextbox.Text = words(7)
                    M2XTextbox.Text = words(9)
                    M3XTextbox.Text = words(11)
                    M1YTextbox.Text = words(13)
                    M2YTextbox.Text = words(15)
                    M3YTextbox.Text = words(17)

                    TStepTextbox.Text = words(19)
                    IterationsTextBox.Text = words(21)

                    aLengthTextbox.Text = words(23)
                    bLengthTextbox.Text = words(25)
                    cLengthTextbox.Text = words(27)
                    M2LengthTextbox.Text = words(29)

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
        Dim Xcentre As Double = xmin + xrange / 2
        Dim Ycentre As Double = ymin + yrange / 2
        'shift xmin to x=0
        Dim shiftx As Double = 0 - Xcentre
        'shift ymin to y=0
        Dim shifty As Double = 0 - Ycentre

        'find scale
        Dim XScale As Double = PageXSize.Text / xrange
        Dim YScale As Double = PageYSize.Text / yrange
        Dim Scale As Double = Min(XScale, YScale)

        Dim c As Integer

        For c = 0 To list4.Count - 1
            XPointList(c) = (XPointList(c) + shiftx) * Scale
            YPointList(c) = (YPointList(c) + shifty) * Scale
        Next

        Dim SVGDirectory As String
        Dim FileNum As Short
        Dim DateString As String = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
        SVGDirectory = "C:\Users\Jacob\Documents\Guilloche\guilloche-" & DateString & ".ngc"

        FileNum = FreeFile()
        FileOpen(FileNum, SVGDirectory, OpenMode.Output)



        'Add comment with parameters used
        PrintLine(FileNum, "(!-- Parameters used to generate this file)")

        PrintLine(FileNum, "(period1='" & M1Textbox.Text & ")")
        PrintLine(FileNum, "(period2='" & M2Textbox.Text & ")")
        PrintLine(FileNum, "(period3='" & M3TextBox.Text & ")")

        PrintLine(FileNum, "(m1centerX='" & M1XTextbox.Text & ")")
        PrintLine(FileNum, "(m2centerX='" & M2XTextbox.Text & ")")
        PrintLine(FileNum, "(m3centerX='" & M3XTextbox.Text & ")")
        PrintLine(FileNum, "(m1centerY='" & M1YTextbox.Text & ")")
        PrintLine(FileNum, "(m2centerY='" & M2YTextbox.Text & ")")
        PrintLine(FileNum, "(m3centerY='" & M3YTextbox.Text & ")")

        PrintLine(FileNum, "(TimeStep='" & TStepTextbox.Text & ")")
        PrintLine(FileNum, "(Iterations='" & IterationsTextBox.Text & ")")

        PrintLine(FileNum, "(M1Radius='" & aLengthTextbox.Text & ")")
        PrintLine(FileNum, "(blength='" & bLengthTextbox.Text & ")")
        PrintLine(FileNum, "(clength='" & cLengthTextbox.Text & ")")
        PrintLine(FileNum, "(M2Radius='" & M2LengthTextbox.Text & ")")
        PrintLine(FileNum, "G21 G90 G64 G40")
        'PrintLine(FileNum, "G0 Z90.0")
        PrintLine(FileNum, "T0 M6")
        PrintLine(FileNum, "M3 S1000 F600")


        Dim i As Integer

        For i = 0 To XPointList.Count - 1
            If i = 1 Then
                PrintLine(FileNum, "G1 G21 F600 X" & System.Math.Round(XPointList(i), 2) & " Y" & System.Math.Round(YPointList(i), 2) & " Z65") 'Pen down when at first position
            Else
                PrintLine(FileNum, "G1 X" & System.Math.Round(XPointList(i), 2) & " Y" & System.Math.Round(YPointList(i), 2))
            End If
        Next

        PrintLine(FileNum, "G0 Z90.0")
        PrintLine(FileNum, "M5")
        PrintLine(FileNum, "M30")


        FileClose(FileNum)



    End Sub
End Class

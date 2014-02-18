<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GenButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.M1Textbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.M2Textbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.M3TextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.M1XTextbox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.M1YTextbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.M2YTextbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.M2XTextbox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.M3YTextbox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.M3XTextbox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.IterationsTextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TStepTextbox = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cLengthTextbox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.bLengthTextbox = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.aLengthTextbox = New System.Windows.Forms.TextBox()
        Me.LoadButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.M2LengthTextbox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.zg1 = New ZedGraph.ZedGraphControl()
        Me.NCSaveButton = New System.Windows.Forms.Button()
        Me.PageXSize = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PageYSize = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GenButton
        '
        Me.GenButton.Location = New System.Drawing.Point(10, 34)
        Me.GenButton.Name = "GenButton"
        Me.GenButton.Size = New System.Drawing.Size(118, 30)
        Me.GenButton.TabIndex = 1
        Me.GenButton.Text = "Generate Plot"
        Me.GenButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(964, 103)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(118, 30)
        Me.SaveButton.TabIndex = 2
        Me.SaveButton.Text = "Save to SVG"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'M1Textbox
        '
        Me.M1Textbox.Location = New System.Drawing.Point(21, 117)
        Me.M1Textbox.Name = "M1Textbox"
        Me.M1Textbox.Size = New System.Drawing.Size(106, 20)
        Me.M1Textbox.TabIndex = 3
        Me.M1Textbox.Text = "413"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "M1 Period"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "M2 Period"
        '
        'M2Textbox
        '
        Me.M2Textbox.Location = New System.Drawing.Point(19, 157)
        Me.M2Textbox.Name = "M2Textbox"
        Me.M2Textbox.Size = New System.Drawing.Size(106, 20)
        Me.M2Textbox.TabIndex = 5
        Me.M2Textbox.Text = "900"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "M3 Period (Table)"
        '
        'M3TextBox
        '
        Me.M3TextBox.Location = New System.Drawing.Point(19, 199)
        Me.M3TextBox.Name = "M3TextBox"
        Me.M3TextBox.Size = New System.Drawing.Size(106, 20)
        Me.M3TextBox.TabIndex = 7
        Me.M3TextBox.Text = "1200"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "M1 Center"
        '
        'M1XTextbox
        '
        Me.M1XTextbox.Location = New System.Drawing.Point(21, 249)
        Me.M1XTextbox.Name = "M1XTextbox"
        Me.M1XTextbox.Size = New System.Drawing.Size(41, 20)
        Me.M1XTextbox.TabIndex = 9
        Me.M1XTextbox.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "X:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(70, 252)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Y:"
        '
        'M1YTextbox
        '
        Me.M1YTextbox.Location = New System.Drawing.Point(84, 249)
        Me.M1YTextbox.Name = "M1YTextbox"
        Me.M1YTextbox.Size = New System.Drawing.Size(41, 20)
        Me.M1YTextbox.TabIndex = 16
        Me.M1YTextbox.Text = "600"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(70, 301)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Y:"
        '
        'M2YTextbox
        '
        Me.M2YTextbox.Location = New System.Drawing.Point(84, 298)
        Me.M2YTextbox.Name = "M2YTextbox"
        Me.M2YTextbox.Size = New System.Drawing.Size(41, 20)
        Me.M2YTextbox.TabIndex = 21
        Me.M2YTextbox.Text = "600"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 301)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "X:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 281)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "M2 Center"
        '
        'M2XTextbox
        '
        Me.M2XTextbox.Location = New System.Drawing.Point(21, 298)
        Me.M2XTextbox.Name = "M2XTextbox"
        Me.M2XTextbox.Size = New System.Drawing.Size(41, 20)
        Me.M2XTextbox.TabIndex = 18
        Me.M2XTextbox.Text = "200"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(70, 348)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Y:"
        '
        'M3YTextbox
        '
        Me.M3YTextbox.Location = New System.Drawing.Point(84, 345)
        Me.M3YTextbox.Name = "M3YTextbox"
        Me.M3YTextbox.Size = New System.Drawing.Size(41, 20)
        Me.M3YTextbox.TabIndex = 26
        Me.M3YTextbox.Text = "100"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 348)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "X:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 328)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "M3 Center"
        '
        'M3XTextbox
        '
        Me.M3XTextbox.Location = New System.Drawing.Point(21, 345)
        Me.M3XTextbox.Name = "M3XTextbox"
        Me.M3XTextbox.Size = New System.Drawing.Size(41, 20)
        Me.M3XTextbox.TabIndex = 23
        Me.M3XTextbox.Text = "100"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 423)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Iterations"
        '
        'IterationsTextBox
        '
        Me.IterationsTextBox.Location = New System.Drawing.Point(19, 440)
        Me.IterationsTextBox.Name = "IterationsTextBox"
        Me.IterationsTextBox.Size = New System.Drawing.Size(106, 20)
        Me.IterationsTextBox.TabIndex = 30
        Me.IterationsTextBox.Text = "1000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 381)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Time step"
        '
        'TStepTextbox
        '
        Me.TStepTextbox.Location = New System.Drawing.Point(19, 398)
        Me.TStepTextbox.Name = "TStepTextbox"
        Me.TStepTextbox.Size = New System.Drawing.Size(106, 20)
        Me.TStepTextbox.TabIndex = 28
        Me.TStepTextbox.Text = "10"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 552)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Link 2 Length"
        '
        'cLengthTextbox
        '
        Me.cLengthTextbox.Location = New System.Drawing.Point(19, 569)
        Me.cLengthTextbox.Name = "cLengthTextbox"
        Me.cLengthTextbox.Size = New System.Drawing.Size(106, 20)
        Me.cLengthTextbox.TabIndex = 36
        Me.cLengthTextbox.Text = "400"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 510)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 13)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Link 1 Length"
        '
        'bLengthTextbox
        '
        Me.bLengthTextbox.Location = New System.Drawing.Point(19, 527)
        Me.bLengthTextbox.Name = "bLengthTextbox"
        Me.bLengthTextbox.Size = New System.Drawing.Size(106, 20)
        Me.bLengthTextbox.TabIndex = 34
        Me.bLengthTextbox.Text = "360"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(20, 470)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "M1 Rad"
        '
        'aLengthTextbox
        '
        Me.aLengthTextbox.Location = New System.Drawing.Point(21, 487)
        Me.aLengthTextbox.Name = "aLengthTextbox"
        Me.aLengthTextbox.Size = New System.Drawing.Size(106, 20)
        Me.aLengthTextbox.TabIndex = 32
        Me.aLengthTextbox.Text = "80"
        '
        'LoadButton
        '
        Me.LoadButton.Location = New System.Drawing.Point(964, 67)
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(118, 30)
        Me.LoadButton.TabIndex = 38
        Me.LoadButton.Text = "Load SVG"
        Me.LoadButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(18, 592)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "M2 Rad"
        '
        'M2LengthTextbox
        '
        Me.M2LengthTextbox.Location = New System.Drawing.Point(19, 609)
        Me.M2LengthTextbox.Name = "M2LengthTextbox"
        Me.M2LengthTextbox.Size = New System.Drawing.Size(106, 20)
        Me.M2LengthTextbox.TabIndex = 39
        Me.M2LengthTextbox.Text = "400"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.M1Textbox)
        Me.GroupBox1.Controls.Add(Me.M2LengthTextbox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.M2Textbox)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.GenButton)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cLengthTextbox)
        Me.GroupBox1.Controls.Add(Me.M3TextBox)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.bLengthTextbox)
        Me.GroupBox1.Controls.Add(Me.M1XTextbox)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.aLengthTextbox)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.M1YTextbox)
        Me.GroupBox1.Controls.Add(Me.IterationsTextBox)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.M2XTextbox)
        Me.GroupBox1.Controls.Add(Me.TStepTextbox)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.M3YTextbox)
        Me.GroupBox1.Controls.Add(Me.M2YTextbox)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.M3XTextbox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 680)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.zg1)
        Me.Panel1.Location = New System.Drawing.Point(164, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(761, 680)
        Me.Panel1.TabIndex = 43
        '
        'zg1
        '
        Me.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zg1.Location = New System.Drawing.Point(12, 19)
        Me.zg1.MaximumSize = New System.Drawing.Size(761, 680)
        Me.zg1.Name = "zg1"
        Me.zg1.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.zg1.ScrollGrace = 0.0R
        Me.zg1.ScrollMaxX = 0.0R
        Me.zg1.ScrollMaxY = 0.0R
        Me.zg1.ScrollMaxY2 = 0.0R
        Me.zg1.ScrollMinX = 0.0R
        Me.zg1.ScrollMinY = 0.0R
        Me.zg1.ScrollMinY2 = 0.0R
        Me.zg1.Size = New System.Drawing.Size(726, 610)
        Me.zg1.TabIndex = 43
        '
        'NCSaveButton
        '
        Me.NCSaveButton.Location = New System.Drawing.Point(964, 147)
        Me.NCSaveButton.Name = "NCSaveButton"
        Me.NCSaveButton.Size = New System.Drawing.Size(118, 30)
        Me.NCSaveButton.TabIndex = 44
        Me.NCSaveButton.Text = "Save to NC"
        Me.NCSaveButton.UseVisualStyleBackColor = True
        '
        'PageXSize
        '
        Me.PageXSize.Location = New System.Drawing.Point(964, 235)
        Me.PageXSize.Name = "PageXSize"
        Me.PageXSize.Size = New System.Drawing.Size(106, 20)
        Me.PageXSize.TabIndex = 45
        Me.PageXSize.Text = "220"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(961, 218)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 46
        Me.Label19.Text = "Page X Size"
        '
        'PageYSize
        '
        Me.PageYSize.Location = New System.Drawing.Point(962, 275)
        Me.PageYSize.Name = "PageYSize"
        Me.PageYSize.Size = New System.Drawing.Size(106, 20)
        Me.PageYSize.TabIndex = 47
        Me.PageYSize.Text = "220"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(961, 258)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 13)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Page Y Size"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 704)
        Me.Controls.Add(Me.PageXSize)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.PageYSize)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.NCSaveButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LoadButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GenButton As System.Windows.Forms.Button
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents M1Textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents M2Textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents M3TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents M1XTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents M1YTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents M2YTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents M2XTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents M3YTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents M3XTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents IterationsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TStepTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cLengthTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents bLengthTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents aLengthTextbox As System.Windows.Forms.TextBox
    Friend WithEvents LoadButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents M2LengthTextbox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents zg1 As ZedGraph.ZedGraphControl
    Friend WithEvents NCSaveButton As System.Windows.Forms.Button
    Friend WithEvents PageXSize As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PageYSize As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label

End Class

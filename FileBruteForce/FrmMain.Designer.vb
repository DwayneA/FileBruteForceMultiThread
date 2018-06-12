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
        Me.TbFile = New System.Windows.Forms.TextBox()
        Me.BtnBrute = New System.Windows.Forms.Button()
        Me.TbCurAtt = New System.Windows.Forms.TextBox()
        Me.TbToAtt = New System.Windows.Forms.TextBox()
        Me.LbFile = New System.Windows.Forms.Label()
        Me.LbCurAtt = New System.Windows.Forms.Label()
        Me.LbToAtt = New System.Windows.Forms.Label()
        Me.LbTime = New System.Windows.Forms.Label()
        Me.TbTime = New System.Windows.Forms.TextBox()
        Me.TbAttPs = New System.Windows.Forms.TextBox()
        Me.LbAttPs = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbDest = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TbFile
        '
        Me.TbFile.Location = New System.Drawing.Point(116, 16)
        Me.TbFile.Name = "TbFile"
        Me.TbFile.Size = New System.Drawing.Size(230, 20)
        Me.TbFile.TabIndex = 0
        Me.TbFile.Text = "C:\test.7z"
        '
        'BtnBrute
        '
        Me.BtnBrute.Location = New System.Drawing.Point(18, 172)
        Me.BtnBrute.Name = "BtnBrute"
        Me.BtnBrute.Size = New System.Drawing.Size(328, 28)
        Me.BtnBrute.TabIndex = 1
        Me.BtnBrute.Text = "Brute It!"
        Me.BtnBrute.UseVisualStyleBackColor = True
        '
        'TbCurAtt
        '
        Me.TbCurAtt.Location = New System.Drawing.Point(152, 68)
        Me.TbCurAtt.Name = "TbCurAtt"
        Me.TbCurAtt.Size = New System.Drawing.Size(194, 20)
        Me.TbCurAtt.TabIndex = 2
        Me.TbCurAtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TbToAtt
        '
        Me.TbToAtt.Location = New System.Drawing.Point(152, 94)
        Me.TbToAtt.Name = "TbToAtt"
        Me.TbToAtt.Size = New System.Drawing.Size(194, 20)
        Me.TbToAtt.TabIndex = 3
        Me.TbToAtt.Text = "0"
        Me.TbToAtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LbFile
        '
        Me.LbFile.AutoSize = True
        Me.LbFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbFile.Location = New System.Drawing.Point(15, 18)
        Me.LbFile.Name = "LbFile"
        Me.LbFile.Size = New System.Drawing.Size(81, 18)
        Me.LbFile.TabIndex = 4
        Me.LbFile.Text = "Input File:"
        '
        'LbCurAtt
        '
        Me.LbCurAtt.AutoSize = True
        Me.LbCurAtt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCurAtt.Location = New System.Drawing.Point(15, 70)
        Me.LbCurAtt.Name = "LbCurAtt"
        Me.LbCurAtt.Size = New System.Drawing.Size(131, 18)
        Me.LbCurAtt.TabIndex = 5
        Me.LbCurAtt.Text = "Current Attempt:"
        '
        'LbToAtt
        '
        Me.LbToAtt.AutoSize = True
        Me.LbToAtt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbToAtt.Location = New System.Drawing.Point(15, 96)
        Me.LbToAtt.Name = "LbToAtt"
        Me.LbToAtt.Size = New System.Drawing.Size(122, 18)
        Me.LbToAtt.TabIndex = 6
        Me.LbToAtt.Text = "Total Attempts:"
        '
        'LbTime
        '
        Me.LbTime.AutoSize = True
        Me.LbTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTime.Location = New System.Drawing.Point(15, 148)
        Me.LbTime.Name = "LbTime"
        Me.LbTime.Size = New System.Drawing.Size(107, 18)
        Me.LbTime.TabIndex = 7
        Me.LbTime.Text = "Runing Time:"
        '
        'TbTime
        '
        Me.TbTime.Location = New System.Drawing.Point(152, 146)
        Me.TbTime.Name = "TbTime"
        Me.TbTime.Size = New System.Drawing.Size(194, 20)
        Me.TbTime.TabIndex = 8
        Me.TbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TbAttPs
        '
        Me.TbAttPs.Location = New System.Drawing.Point(152, 120)
        Me.TbAttPs.Name = "TbAttPs"
        Me.TbAttPs.Size = New System.Drawing.Size(194, 20)
        Me.TbAttPs.TabIndex = 12
        Me.TbAttPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LbAttPs
        '
        Me.LbAttPs.AutoSize = True
        Me.LbAttPs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAttPs.Location = New System.Drawing.Point(15, 122)
        Me.LbAttPs.Name = "LbAttPs"
        Me.LbAttPs.Size = New System.Drawing.Size(122, 18)
        Me.LbAttPs.TabIndex = 11
        Me.LbAttPs.Text = "Attempts per/s:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Destination:"
        '
        'TbDest
        '
        Me.TbDest.Location = New System.Drawing.Point(116, 42)
        Me.TbDest.Name = "TbDest"
        Me.TbDest.Size = New System.Drawing.Size(230, 20)
        Me.TbDest.TabIndex = 13
        Me.TbDest.Text = "C:\"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 216)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TbDest)
        Me.Controls.Add(Me.TbAttPs)
        Me.Controls.Add(Me.LbAttPs)
        Me.Controls.Add(Me.TbTime)
        Me.Controls.Add(Me.LbTime)
        Me.Controls.Add(Me.LbToAtt)
        Me.Controls.Add(Me.LbCurAtt)
        Me.Controls.Add(Me.LbFile)
        Me.Controls.Add(Me.TbToAtt)
        Me.Controls.Add(Me.TbCurAtt)
        Me.Controls.Add(Me.BtnBrute)
        Me.Controls.Add(Me.TbFile)
        Me.Name = "FrmMain"
        Me.Text = "FileBruteForce"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TbFile As System.Windows.Forms.TextBox
    Friend WithEvents BtnBrute As System.Windows.Forms.Button
    Friend WithEvents TbCurAtt As System.Windows.Forms.TextBox
    Friend WithEvents TbToAtt As System.Windows.Forms.TextBox
    Friend WithEvents LbFile As System.Windows.Forms.Label
    Friend WithEvents LbCurAtt As System.Windows.Forms.Label
    Friend WithEvents LbToAtt As System.Windows.Forms.Label
    Friend WithEvents LbTime As System.Windows.Forms.Label
    Friend WithEvents TbTime As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TbAttPs As System.Windows.Forms.TextBox
    Friend WithEvents LbAttPs As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TbDest As System.Windows.Forms.TextBox

End Class

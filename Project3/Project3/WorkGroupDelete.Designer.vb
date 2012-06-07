<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkGroupDelete
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
        Me.lstWorkgroups = New System.Windows.Forms.ListBox()
        Me.lblOutcome = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstWorkgroups
        '
        Me.lstWorkgroups.FormattingEnabled = True
        Me.lstWorkgroups.Location = New System.Drawing.Point(24, 65)
        Me.lstWorkgroups.Name = "lstWorkgroups"
        Me.lstWorkgroups.Size = New System.Drawing.Size(287, 147)
        Me.lstWorkgroups.TabIndex = 0
        '
        'lblOutcome
        '
        Me.lblOutcome.Location = New System.Drawing.Point(21, 221)
        Me.lblOutcome.Name = "lblOutcome"
        Me.lblOutcome.Size = New System.Drawing.Size(290, 45)
        Me.lblOutcome.TabIndex = 11
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(52, 280)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(200, 280)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(94, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 18)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Delete Workgroup"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Berlin Sans FB", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(22, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "(Note: you cannot delelete a Workgroup with employees)"
        '
        'WorkGroupDelete
        '
        Me.AcceptButton = Me.btnDelete
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(337, 335)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblOutcome)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lstWorkgroups)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "WorkGroupDelete"
        Me.Text = "Delete Work Group"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstWorkgroups As System.Windows.Forms.ListBox
    Friend WithEvents lblOutcome As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

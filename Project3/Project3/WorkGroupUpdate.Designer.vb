<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkGroupUpdate
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
        Me.lblOutcome = New System.Windows.Forms.Label()
        Me.lblErrorName = New System.Windows.Forms.Label()
        Me.lblErrorId = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboWorkGroup = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblOutcome
        '
        Me.lblOutcome.Location = New System.Drawing.Point(12, 218)
        Me.lblOutcome.Name = "lblOutcome"
        Me.lblOutcome.Size = New System.Drawing.Size(290, 45)
        Me.lblOutcome.TabIndex = 7
        '
        'lblErrorName
        '
        Me.lblErrorName.AutoSize = True
        Me.lblErrorName.ForeColor = System.Drawing.Color.Red
        Me.lblErrorName.Location = New System.Drawing.Point(78, 205)
        Me.lblErrorName.Name = "lblErrorName"
        Me.lblErrorName.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorName.TabIndex = 8
        '
        'lblErrorId
        '
        Me.lblErrorId.AutoSize = True
        Me.lblErrorId.ForeColor = System.Drawing.Color.Red
        Me.lblErrorId.Location = New System.Drawing.Point(78, 152)
        Me.lblErrorId.Name = "lblErrorId"
        Me.lblErrorId.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorId.TabIndex = 4
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(36, 271)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(197, 270)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(78, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Update Work Group"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(78, 125)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(42, 20)
        Me.txtId.TabIndex = 3
        Me.txtId.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "&Id"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(78, 179)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(203, 20)
        Me.txtName.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "&Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Choose"
        '
        'comboWorkGroup
        '
        Me.comboWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboWorkGroup.FormattingEnabled = True
        Me.comboWorkGroup.Location = New System.Drawing.Point(58, 18)
        Me.comboWorkGroup.Name = "comboWorkGroup"
        Me.comboWorkGroup.Size = New System.Drawing.Size(203, 21)
        Me.comboWorkGroup.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.comboWorkGroup)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(9, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(293, 59)
        Me.Panel1.TabIndex = 1
        '
        'WorkGroupUpdate
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(310, 308)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblOutcome)
        Me.Controls.Add(Me.lblErrorName)
        Me.Controls.Add(Me.lblErrorId)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Name = "WorkGroupUpdate"
        Me.Text = "Update Work Group"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOutcome As System.Windows.Forms.Label
    Friend WithEvents lblErrorName As System.Windows.Forms.Label
    Friend WithEvents lblErrorId As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents comboWorkGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeAdd
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
        Me.comboWorkGroup = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblErrorWorkGroup = New System.Windows.Forms.Label()
        Me.lblErrorId = New System.Windows.Forms.Label()
        Me.lblErrorName = New System.Windows.Forms.Label()
        Me.lblOutcome = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'comboWorkGroup
        '
        Me.comboWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboWorkGroup.FormattingEnabled = True
        Me.comboWorkGroup.Location = New System.Drawing.Point(85, 178)
        Me.comboWorkGroup.Name = "comboWorkGroup"
        Me.comboWorkGroup.Size = New System.Drawing.Size(203, 21)
        Me.comboWorkGroup.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "&Workgroup"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "&Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(85, 127)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(203, 20)
        Me.txtName.TabIndex = 5
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(85, 73)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(42, 20)
        Me.txtId.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "&Id"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(104, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Add Employee"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(195, 282)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(47, 279)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblErrorWorkGroup
        '
        Me.lblErrorWorkGroup.AutoSize = True
        Me.lblErrorWorkGroup.ForeColor = System.Drawing.Color.Red
        Me.lblErrorWorkGroup.Location = New System.Drawing.Point(85, 210)
        Me.lblErrorWorkGroup.Name = "lblErrorWorkGroup"
        Me.lblErrorWorkGroup.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorWorkGroup.TabIndex = 9
        '
        'lblErrorId
        '
        Me.lblErrorId.AutoSize = True
        Me.lblErrorId.ForeColor = System.Drawing.Color.Red
        Me.lblErrorId.Location = New System.Drawing.Point(85, 100)
        Me.lblErrorId.Name = "lblErrorId"
        Me.lblErrorId.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorId.TabIndex = 3
        '
        'lblErrorName
        '
        Me.lblErrorName.AutoSize = True
        Me.lblErrorName.ForeColor = System.Drawing.Color.Red
        Me.lblErrorName.Location = New System.Drawing.Point(85, 153)
        Me.lblErrorName.Name = "lblErrorName"
        Me.lblErrorName.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorName.TabIndex = 6
        '
        'lblOutcome
        '
        Me.lblOutcome.Location = New System.Drawing.Point(16, 225)
        Me.lblOutcome.Name = "lblOutcome"
        Me.lblOutcome.Size = New System.Drawing.Size(290, 45)
        Me.lblOutcome.TabIndex = 10
        '
        'EmployeeAdd
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(321, 324)
        Me.Controls.Add(Me.lblOutcome)
        Me.Controls.Add(Me.lblErrorName)
        Me.Controls.Add(Me.lblErrorId)
        Me.Controls.Add(Me.lblErrorWorkGroup)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboWorkGroup)
        Me.Name = "EmployeeAdd"
        Me.Text = "Add Employee"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboWorkGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblErrorWorkGroup As System.Windows.Forms.Label
    Friend WithEvents lblErrorId As System.Windows.Forms.Label
    Friend WithEvents lblErrorName As System.Windows.Forms.Label
    Friend WithEvents lblOutcome As System.Windows.Forms.Label
End Class

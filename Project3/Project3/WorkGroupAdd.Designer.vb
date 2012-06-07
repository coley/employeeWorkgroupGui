<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkGroupAdd
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblOutcome = New System.Windows.Forms.Label()
        Me.lblErrorName = New System.Windows.Forms.Label()
        Me.lblErrorId = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(120, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Add Workgroup"
        '
        'lblOutcome
        '
        Me.lblOutcome.Location = New System.Drawing.Point(30, 164)
        Me.lblOutcome.Name = "lblOutcome"
        Me.lblOutcome.Size = New System.Drawing.Size(290, 45)
        Me.lblOutcome.TabIndex = 7
        '
        'lblErrorName
        '
        Me.lblErrorName.AutoSize = True
        Me.lblErrorName.ForeColor = System.Drawing.Color.Red
        Me.lblErrorName.Location = New System.Drawing.Point(99, 151)
        Me.lblErrorName.Name = "lblErrorName"
        Me.lblErrorName.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorName.TabIndex = 8
        '
        'lblErrorId
        '
        Me.lblErrorId.AutoSize = True
        Me.lblErrorId.ForeColor = System.Drawing.Color.Red
        Me.lblErrorId.Location = New System.Drawing.Point(99, 97)
        Me.lblErrorId.Name = "lblErrorId"
        Me.lblErrorId.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorId.TabIndex = 6
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(61, 223)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(209, 223)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(99, 70)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(42, 20)
        Me.txtId.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "&Id"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(99, 124)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(203, 20)
        Me.txtName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "&Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(99, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 5
        '
        'WorkGroupAdd
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(350, 271)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblOutcome)
        Me.Controls.Add(Me.lblErrorName)
        Me.Controls.Add(Me.lblErrorId)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Name = "WorkGroupAdd"
        Me.Text = "Add Workgroup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblOutcome As System.Windows.Forms.Label
    Friend WithEvents lblErrorName As System.Windows.Forms.Label
    Friend WithEvents lblErrorId As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

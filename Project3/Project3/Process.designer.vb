<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Process
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
        Me.dgvEmployees = New System.Windows.Forms.DataGridView()
        Me.menuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAddEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuUpdateEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuDeleteEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuWorkgroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAddWorkgroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuUpdateWorkgroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuDeleteWorkgroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.comboWorkgroup = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDgvHeading = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEmployees
        '
        Me.dgvEmployees.AllowUserToAddRows = False
        Me.dgvEmployees.AllowUserToDeleteRows = False
        Me.dgvEmployees.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvEmployees.Location = New System.Drawing.Point(12, 180)
        Me.dgvEmployees.Name = "dgvEmployees"
        Me.dgvEmployees.ReadOnly = True
        Me.dgvEmployees.Size = New System.Drawing.Size(461, 298)
        Me.dgvEmployees.TabIndex = 5
        '
        'menuFile
        '
        Me.menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuExit})
        Me.menuFile.Name = "menuFile"
        Me.menuFile.Size = New System.Drawing.Size(37, 20)
        Me.menuFile.Text = "&File"
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.Size = New System.Drawing.Size(92, 22)
        Me.menuExit.Text = "E&xit"
        '
        'menuEmployee
        '
        Me.menuEmployee.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuAddEmployee, Me.menuUpdateEmployee, Me.menuDeleteEmployee})
        Me.menuEmployee.Name = "menuEmployee"
        Me.menuEmployee.Size = New System.Drawing.Size(71, 20)
        Me.menuEmployee.Text = "&Employee"
        '
        'menuAddEmployee
        '
        Me.menuAddEmployee.Name = "menuAddEmployee"
        Me.menuAddEmployee.Size = New System.Drawing.Size(112, 22)
        Me.menuAddEmployee.Text = "&Add"
        '
        'menuUpdateEmployee
        '
        Me.menuUpdateEmployee.Name = "menuUpdateEmployee"
        Me.menuUpdateEmployee.Size = New System.Drawing.Size(112, 22)
        Me.menuUpdateEmployee.Text = "&Update"
        '
        'menuDeleteEmployee
        '
        Me.menuDeleteEmployee.Name = "menuDeleteEmployee"
        Me.menuDeleteEmployee.Size = New System.Drawing.Size(112, 22)
        Me.menuDeleteEmployee.Text = "Dele&te"
        '
        'menuWorkgroup
        '
        Me.menuWorkgroup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuAddWorkgroup, Me.menuUpdateWorkgroup, Me.menuDeleteWorkgroup})
        Me.menuWorkgroup.Name = "menuWorkgroup"
        Me.menuWorkgroup.Size = New System.Drawing.Size(79, 20)
        Me.menuWorkgroup.Text = "&Workgroup"
        '
        'menuAddWorkgroup
        '
        Me.menuAddWorkgroup.Name = "menuAddWorkgroup"
        Me.menuAddWorkgroup.Size = New System.Drawing.Size(112, 22)
        Me.menuAddWorkgroup.Text = "A&dd"
        '
        'menuUpdateWorkgroup
        '
        Me.menuUpdateWorkgroup.Name = "menuUpdateWorkgroup"
        Me.menuUpdateWorkgroup.Size = New System.Drawing.Size(112, 22)
        Me.menuUpdateWorkgroup.Text = "U&pdate"
        '
        'menuDeleteWorkgroup
        '
        Me.menuDeleteWorkgroup.Name = "menuDeleteWorkgroup"
        Me.menuDeleteWorkgroup.Size = New System.Drawing.Size(112, 22)
        Me.menuDeleteWorkgroup.Text = "De&lete"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFile, Me.menuEmployee, Me.menuWorkgroup})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(489, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'comboWorkgroup
        '
        Me.comboWorkgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboWorkgroup.FormattingEnabled = True
        Me.comboWorkgroup.Location = New System.Drawing.Point(79, 97)
        Me.comboWorkgroup.Name = "comboWorkgroup"
        Me.comboWorkgroup.Size = New System.Drawing.Size(239, 21)
        Me.comboWorkgroup.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Berlin Sans FB", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Workgroup"
        '
        'lblDgvHeading
        '
        Me.lblDgvHeading.AutoSize = True
        Me.lblDgvHeading.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDgvHeading.Location = New System.Drawing.Point(12, 149)
        Me.lblDgvHeading.Name = "lblDgvHeading"
        Me.lblDgvHeading.Size = New System.Drawing.Size(79, 18)
        Me.lblDgvHeading.TabIndex = 4
        Me.lblDgvHeading.Text = "Employees"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(15, 54)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(171, 20)
        Me.txtSearch.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Berlin Sans FB", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(200, 54)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(118, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search Id or Name"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Process
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(489, 499)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblDgvHeading)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboWorkgroup)
        Me.Controls.Add(Me.dgvEmployees)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Process"
        Me.Text = "Process Employees"
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEmployees As System.Windows.Forms.DataGridView
    Friend WithEvents menuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAddEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuUpdateEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDeleteEmployee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAddWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuUpdateWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDeleteWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents comboWorkgroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDgvHeading As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
End Class

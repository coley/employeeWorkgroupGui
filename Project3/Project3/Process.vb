'***************************************************************************************************
'*
'*      Class:          Process         
'*      Author:         Nicole LaBonte
'*      Date Created:   November 27, 2011
'*      Description:    Windows Form class that initiates the processing for employees and
'*                      workgroups.  It handles events initiated through the form.  The
'*                      primary functions that the form allows are:
'*                          -View Employees by WorkGroup and/or by employee name/id search
'*                          -Add, Update, and Delete Employee
'*                          -Add, Update, and Delete WorkGroup
'*                          -Exit
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class Process

    '************************************************************************************************
    '*  Method exits the form when the exit menu option is selected
    '************************************************************************************************
    Private Sub menuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExit.Click
        Me.Close()
    End Sub

    '************************************************************************************************
    '*  Method initiates processing at form load
    '*      -Call method to load all work groups to instance variable and combobox
    '*      -Set combobox to 0 in order to select All
    '*      -Call methods to load employees
    '************************************************************************************************
    Private Sub Process_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Populate work groups in combo box
        loadWorkGroups()

        'Select all in combobox
        comboWorkgroup.SelectedIndex = 0

        'Load employees
        loadEmployees()

    End Sub

    '************************************************************************************************
    '*  Method Loads work groups
    '*      -Clears group combobox
    '*      -Obtains a list of all workgroups from the database and newly populates group combobox
    '************************************************************************************************
    Private Sub loadWorkGroups()
        Dim aWorkGroup As WorkGroup

        'Clear work group combobox
        comboWorkgroup.Items.Clear()

        'Create workgroup All
        aWorkGroup = New WorkGroup("0", "All")

        'Add All to work group combo
        comboWorkgroup.Items.Add(aWorkGroup)

        Try
            'Initialize work groups
            WorkGroup.initialize()

            'Obtain workgroup data
            For Each group As KeyValuePair(Of String, WorkGroup) In WorkGroup.Group

                aWorkGroup = New WorkGroup(group.Value.Id, group.Value.Name)

                'Add WorkGroup to combobox
                comboWorkgroup.Items.Add(aWorkGroup)
            Next

            'Terminate db access
            WorkGroup.terminate()

        Catch ex As Exception

            MessageBox.Show("ERROR: WorkGroups could not be loaded - application must terminate." _
                & ControlChars.NewLine _
                & ControlChars.NewLine _
                & ex.ToString)
            Me.Close()

        End Try

    End Sub


    '************************************************************************************************
    '*  Method Loads employees to the datagridview and it limits 
    '*  processing to employees in the workgroup corresponding to the selected group in the
    '*  combobox and employees that match the employee name / id search criteria.  
    '************************************************************************************************
    Private Sub loadEmployees()
        'Declare variables
        Dim anEmployee As Employee
        Dim aWorkGroup As WorkGroup
        Dim filteredEmployees As List(Of Employee)
        Dim criteria As String

        'Reset datasource
        dgvEmployees.DataSource = Nothing

        'Instantiate dictionary
        filteredEmployees = New List(Of Employee)

        'Set workgroup based on combobox selection
        aWorkGroup = CType(comboWorkgroup.SelectedItem, WorkGroup)

        Try
            'Obtain employees from the database that match escaped criteria
            criteria = Replace(txtSearch.Text, "'", "''")
            Employee.initialize(criteria)

            'Adds employees to a list depending on what group was selected in the combo box
            If comboWorkgroup.SelectedIndex > 0 Then
                'Add employess to list if the workgroup id matches selected workgroup
                For Each person As KeyValuePair(Of String, Employee) In Employee.EmployeeList
                    If person.Value.WorkGroup.Id.Equals(aWorkGroup.Id) Then
                        anEmployee = New Employee(person.Value.Id, person.Value.Name, person.Value.WorkGroup)
                        filteredEmployees.Add(anEmployee)
                    End If
                Next
            ElseIf comboWorkgroup.SelectedIndex = 0 Then
                For Each person As KeyValuePair(Of String, Employee) In Employee.EmployeeList
                    anEmployee = New Employee(person.Value.Id, person.Value.Name, person.Value.WorkGroup)
                    filteredEmployees.Add(anEmployee)
                Next
            End If

            'Terminate db access
            Employee.terminate()

            'Refresh datagridview with new list of employees and place columns in order of id, name, workgroup
            With dgvEmployees
                .DataSource = New List(Of Employee)(filteredEmployees)
                .Columns("Id").DisplayIndex = 0
                .Columns("Name").DisplayIndex = 1
                .Columns("WorkGroup").DisplayIndex = 2
            End With

            'Update datagridview label with count of all employees displayed
            lblDgvHeading.Text = "Employees: " & dgvEmployees.Rows.Count.ToString

        Catch ex As Exception

            MessageBox.Show("ERROR: Employees could not be loaded - application must terminate." _
                            & ControlChars.NewLine _
                            & ControlChars.NewLine _
                            & ex.ToString)
            Me.Close()

        End Try
  

    End Sub

    '************************************************************************************************
    '*  Method processes changes to the comboWorkGroup.  When the index changes, the search field
    '*  is cleared, the new work group is obtained, and employees are re-loaded based on the
    '*  newly selected workgroup
    '************************************************************************************************
    Private Sub comboWorkgroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboWorkgroup.SelectedIndexChanged

        'Clear text search
        txtSearch.Text = Nothing

        'Load employees based on selected index
        loadEmployees()

    End Sub

    '************************************************************************************************
    '*  Method processes when the add employee menu option is selected.  It launches the 
    '*  EmployeeAdd form and then re-loads the employees after the EmployeeAdd form is closed.
    '************************************************************************************************
    Private Sub menuAddEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAddEmployee.Click
        'Declare variables
        Dim employeeAdd As New EmployeeAdd

        'Show employee add form
        employeeAdd.ShowDialog()

        'Requery DB
        loadEmployees()

    End Sub

    '************************************************************************************************
    '*  Method processes when the add workgroup menu option is selected.  It launches the 
    '*  WorkGroupAdd form and then re-loads the workgroups after the WorkGroupAdd form is closed.
    '************************************************************************************************
    Private Sub menuAddWorkgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAddWorkgroup.Click
        'Declare variables
        Dim workGroupAdd As New WorkGroupAdd
        Dim selectedWorkGroup As Integer

        'Get selected workgroup index from form for later processing
        selectedWorkGroup = comboWorkgroup.SelectedIndex

        'Show workgroup add form
        workGroupAdd.ShowDialog()

        'Populate work groups in combo box and work group list
        loadWorkGroups()

        'Assign workgroup (reset to All option since index may have changed in combobox)
        comboWorkgroup.SelectedIndex = 0

    End Sub

    '************************************************************************************************
    '*  Method processes when the delete employee menu option is selected.  If an employee is selected,
    '*  then the user is prompted to confirm deletion.  If confirmed, then the employee is deleted
    '*  from the database.  The employees are then re-loaded to the datagridview.
    '************************************************************************************************
    Private Sub menuDeleteEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDeleteEmployee.Click
        'Declare variables
        Dim answer As DialogResult
        Dim anEmployee As Employee
        Dim returnCode As Integer
        Dim id As String

        'Obtain employee object based on the id value of the row selected
        id = TryCast(dgvEmployees.CurrentRow.Cells("Id").Value, String)
        anEmployee = Employee.find(id)

        'If no employee object exists, then notify user and end.
        'If an employee object exists, then prompt user to confirm delete
        If anEmployee Is Nothing Then
            MessageBox.Show("Employee not found.")
            Exit Sub
        Else
            answer = MessageBox.Show("Are you sure you want to delete employee " _
                                     & id & ": " & anEmployee.Name & "?" _
                                     , "Delete", MessageBoxButtons.YesNo _
                                     , MessageBoxIcon.Question _
                                     , MessageBoxDefaultButton.Button1)

        End If

        'If user decides not to delete, then message is displayed to indcate delete cancelled
        'Else, the delete is attempted
        If answer = DialogResult.No Then
            MessageBox.Show("Deletion has been cancelled.")
            Exit Sub
        Else
            'Attempt to delete employee from the database and display any exceptions
            Try
                returnCode = anEmployee.delete(anEmployee)

                If returnCode = 1 Then
                    MessageBox.Show("Employee " & id & ": " & anEmployee.Name & " was deleted.")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

        End If

        'Load employees
        loadEmployees()
    End Sub

    '************************************************************************************************
    '*  Method processes when the update employee menu option is selected.  The employee object
    '*  is obtained that corresponds to the clicked cell.  This information is passed into
    '*  the employee object variable in the EmployeeUpdate form.  The EmployeeUpdate form is
    '*  launched and after it is closed, the employees are re-loaded.
    '************************************************************************************************
    Private Sub menuUpdateEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUpdateEmployee.Click
        Dim EmployeeUpdate As New EmployeeUpdate
        Dim id As String
        Dim anEmployee As Employee

        'Obtain employee object and pass to update form
        If dgvEmployees.CurrentRow.Index >= 0 Then

            id = TryCast(dgvEmployees.CurrentRow.Cells("Id").Value, String)
            anEmployee = Employee.find(id)

            If Not anEmployee Is Nothing Then
                EmployeeUpdate.AnEmployee = anEmployee

                'Show workgroup add form
                EmployeeUpdate.ShowDialog()

                'Requery DB
                loadEmployees()
            End If

        End If

    End Sub

    '************************************************************************************************
    '*  Method processes when the delete workgroup menu option is selected.  The WorkGroupDelete
    '*  Form is launched.  After this form is launched, the comboworkgroup index is set back to 0
    '*  and the workgroups and employees are re-loaded.
    '************************************************************************************************
    Private Sub menuDeleteWorkgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDeleteWorkgroup.Click
        Dim workGroupDelete As New WorkGroupDelete

        'Show workgroup delete form
        workGroupDelete.ShowDialog()

        'Load workgroups
        loadWorkGroups()

        'Assign workgroup to index 0 for All
        comboWorkgroup.SelectedIndex = 0

        'Load employees
        loadEmployees()

    End Sub

    '************************************************************************************************
    '*  Method processes when the update workgroup menu option is selected.  It launches the
    '*  WorkGroupUpdate form.  After this form is closed, the workgroups and employees are re-loaded.
    '************************************************************************************************
    Private Sub menuUpdateWorkgroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUpdateWorkgroup.Click
        Dim workGroupUpdate As New WorkGroupUpdate
        Dim selectedGroup As Integer

        'Get current group selected
        selectedGroup = comboWorkgroup.SelectedIndex

        'Show workgroup update form
        workGroupUpdate.ShowDialog()

        'Load workgroups
        loadWorkGroups()

        'Assign workgroup
        comboWorkgroup.SelectedIndex = selectedGroup

        'Load employees
        loadEmployees()

    End Sub

    '************************************************************************************************
    '*  Method processes when the search button is clicked.  It sets the workgroup and then
    '*  calls a method to load the employees to the datagridview based on the passed search criteria.
    '*  Focus is set to the search textbox.
    '************************************************************************************************
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'Loads employees
        loadEmployees()

        'Set focus
        txtSearch.Focus()
        txtSearch.SelectAll()

    End Sub

    '************************************************************************************************
    '*  Method processes when a cell in the datagridview is double clicked.  It calls the 
    '*  menuUpdateEmployee_Click method to allow updating of an employee.
    '************************************************************************************************
    Private Sub dgvEmployees_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEmployees.CellMouseDoubleClick
        menuUpdateEmployee_Click(sender, e)
    End Sub
End Class
'***************************************************************************************************
'*
'*      Class:          WorkGroupDelete       
'*      Author:         Nicole LaBonte
'*      Date Created:   November 27, 2011
'*      Description:    Windows Form class that handles the processing for deleting workgroups.
'*                      The primary functions of the form is to process the deletion of a work 
'*                      group and prevent workgroups from being processed if employees are still
'*                      assigned to them
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class WorkGroupDelete

    'Instance variables
    Private _employeeCount As Dictionary(Of String, Integer)

    '************************************************************************************************
    '*  Method begins processing of form at load.  It loads all work groups.  It instantiates
    '*  employeeCount
    '************************************************************************************************
    Private Sub WorkGroupDelete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Instantiate employeeCount
        _employeeCount = New Dictionary(Of String, Integer)

        'Load work groups
        loadWorkGroups()

    End Sub

    '************************************************************************************************
    '*  Method handles the clicking of the exit button.  It closes the form.
    '************************************************************************************************
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '************************************************************************************************
    '*  Method Loads work groups
    '*      -Clears listbox of workgroups
    '*      -Obtains a list of all workgroups from the database and newly populates workgroups listbox
    '*      -Calls method to populate employee counts
    '************************************************************************************************
    Private Sub loadWorkGroups()
        'Declare variables
        Dim aWorkGroup As WorkGroup

        'Clear work group combobox
        lstWorkgroups.Items.Clear()

        'Clear employee list
        _employeeCount.Clear()


        Try
            'Initialize work groups
            WorkGroup.initialize()

            'Obtain workgroup data
            For Each group As KeyValuePair(Of String, WorkGroup) In WorkGroup.Group

                aWorkGroup = New WorkGroup(group.Value.Id, group.Value.Name)

                'Add WorkGroup to combobox
                lstWorkgroups.Items.Add(aWorkGroup)

                'Count employees in workgroup
                countEmployees(aWorkGroup)
            Next

            'Terminate db access
            WorkGroup.terminate()

        Catch ex As Exception

            MessageBox.Show("ERROR: WorkGroups could not be loaded - WorkGroups cannot be deleted." _
                 & ControlChars.NewLine _
                 & ControlChars.NewLine _
                 & ex.ToString)
            Me.Close()

        End Try


    End Sub

    '************************************************************************************************
    '*  Method populates the employeeCount instance variable for the number of employees in 
    '*  the workgroup of the argument
    '************************************************************************************************
    Private Sub countEmployees(ByVal aWorkGroup As WorkGroup)
        'Declare variables
        Dim count As Integer

        'Set variables
        count = 0

        Try
            'Initialize employees
            Employee.initialize("")

            'Set all employees
            'allEmployees = Employee.EmployeeList
            For Each person As KeyValuePair(Of String, Employee) In Employee.EmployeeList
                If person.Value.WorkGroup.Id.Equals(aWorkGroup.Id) Then
                    count = count + 1
                End If
            Next

            'Terminate db access
            Employee.terminate()

            'Sets count for workgroup
            _employeeCount.Add(aWorkGroup.Id, count)

        Catch ex As Exception

            MessageBox.Show("ERROR: Employees could not be counted for each WorkGroup - WorkGroups cannot be deleted." _
                & ControlChars.NewLine _
                & ControlChars.NewLine _
                & ex.ToString)
            Me.Close()

        End Try



    End Sub

    '************************************************************************************************
    '*  Method processes when the delete button is clicked.  It attempts to delete the selected
    '*  workgroup if the workgroup doesn't have any assigned employees.  If employees are assigned
    '*  to the workgroup, then an error is displayed.
    '************************************************************************************************
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer
        Dim answer As DialogResult

        'Clear outcome message
        lblOutcome.Text = Nothing

        'Process delete of workgroup if selected
        If lstWorkgroups.SelectedIndex > -1 Then

            'Obtain selected workgroup
            aWorkGroup = CType(lstWorkgroups.SelectedItem, WorkGroup)

            'If employees associated to workgroup, then an error is displayed and sub is exited
            If _employeeCount.Item(aWorkGroup.Id) > 0 Then
                lblOutcome.ForeColor = Drawing.Color.Red
                lblOutcome.Text = "Workgroup has " & _employeeCount.Item(aWorkGroup.Id) _
                        & " employees.  It cannot be deleted."
                lstWorkgroups.Focus()
                Exit Sub
            End If

            'Prompt user to confirm deletion
            answer = MessageBox.Show("Are you sure you want to delete WorkGroup " _
                                    & lstWorkgroups.SelectedItem.ToString & "?" _
                                    , "Delete", MessageBoxButtons.YesNo _
                                    , MessageBoxIcon.Question _
                                    , MessageBoxDefaultButton.Button1)

            'If user cancels deletion, then display message and exit
            If answer = DialogResult.No Then
                lblOutcome.ForeColor = Drawing.Color.Red
                lblOutcome.Text = "Deletion cancelled."
                Exit Sub
            End If

            'Attempt to delete workgroup and catch errors
            Try
                returnCode = aWorkGroup.delete(aWorkGroup)

                If returnCode = 1 Then
                    loadWorkGroups()
                    lblOutcome.ForeColor = Drawing.Color.Green
                    lblOutcome.Text = "Success!  Workgroup '" & aWorkGroup.Id & ": " _
                                        & aWorkGroup.Name & "' deleted."
                    lstWorkgroups.Focus()
                End If
            Catch ex As Exception
                lblOutcome.ForeColor = Drawing.Color.Red
                lblOutcome.Text = "ERROR: Workgroup could not be deleted."
                MessageBox.Show(ex.ToString)
            End Try

        Else
            'Displays message if no workgroup selected
            lblOutcome.ForeColor = Drawing.Color.Red
            lblOutcome.Text = "Please select a Workgroup."
        End If
    End Sub



    '************************************************************************************************
    '*  Method processes when the index is changed on the workgroups list box.  It displays
    '*  the total count of employees for the selected workgroup to the label.
    '************************************************************************************************
    Private Sub lstWorkgroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWorkgroups.SelectedIndexChanged
        Dim output As String
        Dim aWorkGroup As WorkGroup

        aWorkGroup = CType(lstWorkgroups.SelectedItem, WorkGroup)

        lblOutcome.ForeColor = Drawing.Color.Blue
        output = "Employees: " & _employeeCount.Item(aWorkGroup.Id)

        lblOutcome.Text = output

    End Sub

    '************************************************************************************************
    '*  Method calls the delete button method for processing
    '************************************************************************************************
    Private Sub lstWorkgroups_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstWorkgroups.MouseDoubleClick
        btnDelete_Click(sender, e)
    End Sub

End Class
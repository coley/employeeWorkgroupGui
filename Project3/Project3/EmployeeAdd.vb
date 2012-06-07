'***************************************************************************************************
'*
'*      Class:          EmployeeAdd         
'*      Author:         Nicole LaBonte
'*      Date Created:   November 27, 2011
'*      Description:    Windows Form class that handles the processing for adding employees.
'*                      The primary function of this form is to process the addition 
'*                      of an employee and validate the entered data
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class EmployeeAdd

    'Declare contants
    Const MIN_LENGTH_ID As Integer = 1
    Const MAX_LENGTH_ID As Integer = 3
    Const MIN_LENGTH_NAME As Integer = 3
    Const MAX_LENGTH_NAME As Integer = 25

    '************************************************************************************************
    '*  Method begins processing of form at load.  It calls a method to load work groups to combobox.  
    '*  It sets the max length of both the id and name text entry boxes.
    '************************************************************************************************
    Private Sub EmployeeAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Populate work groups in combo box
        loadWorkGroups()

        'Load all employees
        loadAllEmployees()

        'Set max entry
        txtId.MaxLength = MAX_LENGTH_ID
        txtName.MaxLength = MAX_LENGTH_NAME

    End Sub

    '************************************************************************************************
    '*  Method handles the clicking of the exit button.  It closes the form.
    '************************************************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '************************************************************************************************
    '*  Method Loads all employees
    '*      All employees are loaded to populate the employee list and check for existing employee id
    '************************************************************************************************
    Private Sub loadAllEmployees()
        Try
            'Initialize employees
            Employee.initialize("")

            'Terminate employees
            Employee.terminate()

        Catch ex As Exception

            MessageBox.Show("ERROR: Employees could not be loaded - employees cannot be added." _
                & ControlChars.NewLine _
                & ControlChars.NewLine _
                & ex.ToString)
            Me.Close()

        End Try
    End Sub

    '************************************************************************************************
    '*  Method Loads work groups
    '*      -Clears group combobox
    '*      -Obtains a list of all workgroups from the database and newly populates group combobox
    '************************************************************************************************
    Private Sub loadWorkGroups()

        'Declare variables
        Dim aWorkGroup As WorkGroup

        'Clear work group combobox
        comboWorkGroup.Items.Clear()

        Try
            'Initialize work groups
            WorkGroup.initialize()

            'Obtain workgroup data
            For Each group As KeyValuePair(Of String, WorkGroup) In WorkGroup.Group

                aWorkGroup = New WorkGroup(group.Value.Id, group.Value.Name)

                'Add WorkGroup to combobox
                comboWorkGroup.Items.Add(aWorkGroup)
            Next

            'Terminate db access
            WorkGroup.terminate()

        Catch ex As Exception

            MessageBox.Show("ERROR: WorkGroups could not be loaded -  employees cannot be added." _
                & ControlChars.NewLine _
                & ControlChars.NewLine _
                & ex.ToString)

            Me.Close()

        End Try


    End Sub

    '************************************************************************************************
    '*  Method processes when the add button is clicked.  It calls a method to validate the data
    '*  entered by the user.  Then, it attempts to add a new employee to the database if the 
    '*  employee doesn't already exist (based on id).  If the employee already exists, then the 
    '*  user receives a message indicating the employee couldn't be added.
    '************************************************************************************************
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Declare variables
        Dim isValid As Boolean
        Dim employeeId As String
        Dim employeeName As String
        Dim anEmployee As Employee
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer

        'Verify data
        isValid = validateData()

        'Process employee if data is valid
        If isValid Then
            employeeId = Replace(txtId.Text, "'", "''")
            employeeName = Replace(txtName.Text, "'", "''")
            aWorkGroup = CType(comboWorkGroup.SelectedItem, WorkGroup)

            'Create employee object
            anEmployee = Employee.find(employeeId)

            'Attempt to add employee if employee doesn't already exist
            If anEmployee Is Nothing Then

                'Create new employee object
                anEmployee = New Employee(employeeId, employeeName, aWorkGroup)

                'Attempt to add employee and catch any errors
                Try
                    returnCode = anEmployee.addNew(anEmployee)

                    If returnCode = 1 Then
                        lblOutcome.ForeColor = Drawing.Color.Green
                        lblOutcome.Text = "Success!  Employee '" & employeeId & ": " _
                                            & employeeName & "' added."
                        resetEntry()
                    End If
                Catch ex As Exception
                    lblOutcome.ForeColor = Drawing.Color.Red
                    lblOutcome.Text = "ERROR: Employee could not be added."
                    resetFocus()
                    'MessageBox.Show(ex.ToString)
                End Try

                'Display message if employee already exists and couldn't be added
            Else
                lblOutcome.ForeColor = Drawing.Color.Red
                lblOutcome.Text = "Employee id " & employeeId & " already exists."
                txtId.Focus()
                txtId.SelectAll()
            End If

        End If



    End Sub

    '************************************************************************************************
    '*  Method validates the data entered by the user and returns true if the data is valid.
    '*  It calls methods to validate the id, name, and workgroup.
    '************************************************************************************************
    Private Function validateData() As Boolean

        Dim isValid As Boolean

        'Clear output labels
        clearOutputLabels()

        'Set isValid
        isValid = True

        'Check data in form
        If Not validateId() Then
            If isValid Then
                txtId.Focus()
            End If

            isValid = False
        End If

        If Not validateName() Then
            If isValid Then
                txtName.Focus()
            End If

            isValid = False
        End If

        If Not validateWorkGroup() Then
            If isValid Then
                comboWorkGroup.Focus()
            End If

            isValid = False
        End If

        Return isValid

    End Function

    '************************************************************************************************
    '*  Method validates the name entered by the user and returns true if the data is valid.
    '*  Appropriate error messages are displayed if the data is not valid.
    '************************************************************************************************
    Public Function validateName() As Boolean
        If Trim(txtName.Text) = Nothing Then
            lblErrorName.Text = "enter a name"
            Return False
        ElseIf Trim(txtName.Text).Length > MAX_LENGTH_NAME _
                Or Trim(txtName.Text).Length < MIN_LENGTH_NAME Then
            lblErrorName.Text = "enter between " & MIN_LENGTH_NAME _
                    & " and " & MAX_LENGTH_NAME & " characters (inclusive)"
            Return False
        Else
            Return True
        End If
    End Function

    '************************************************************************************************
    '*  Method validates the id entered by the user and returns true if the data is valid.
    '*  Appropriate error messages are displayed if the data is not valid.
    '************************************************************************************************
    Public Function validateId() As Boolean
        'Declare variable
        Dim id As Integer

        'Set id
        Integer.TryParse(txtId.Text, id)

        'Validate id
        If Trim(txtId.Text) = Nothing Then
            lblErrorId.Text = "enter an ID"
            Return False
        ElseIf Trim(txtId.Text).Length > MAX_LENGTH_ID _
                Or Trim(txtId.Text).Length < MIN_LENGTH_ID Then
            lblErrorId.Text = "enter between " & MIN_LENGTH_ID _
                    & " and " & MAX_LENGTH_ID & " digits (inclusive)"
            Return False
        ElseIf id <= 0 Then
            lblErrorId.Text = "must be greater than 0"
            Return False
        Else
            Return True
        End If
    End Function

    '************************************************************************************************
    '*  Method validates the workgroup entered by the user and returns true if the data is valid.
    '*  Appropriate error messages are displayed if the data is not valid.
    '************************************************************************************************
    Public Function validateWorkGroup() As Boolean
        If comboWorkGroup.SelectedIndex < 0 Then
            lblErrorWorkGroup.Text = "select a Workgroup"
            Return False
        Else
            Return True
        End If
    End Function

    '************************************************************************************************
    '*  Method clears the text in the labels that are used to provide feedback to the user during
    '*  processing.
    '************************************************************************************************
    Public Sub clearOutputLabels()
        lblErrorId.Text = Nothing
        lblErrorName.Text = Nothing
        lblErrorWorkGroup.Text = Nothing
        lblOutcome.Text = Nothing
    End Sub

    '************************************************************************************************
    '*  Method resets the focus to the id textbox and it selects all the data entered in both the 
    '*  id and name textboxes.
    '************************************************************************************************
    Public Sub resetFocus()
        txtId.SelectAll()
        txtName.SelectAll()

        txtId.Focus()
    End Sub

    '************************************************************************************************
    '*  Method resets the form for initial entry.
    '************************************************************************************************
    Public Sub resetEntry()
        comboWorkGroup.SelectedIndex = -1
        txtId.Text = Nothing
        txtName.Text = Nothing
        txtId.Focus()
    End Sub


End Class
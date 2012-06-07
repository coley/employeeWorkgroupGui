'***************************************************************************************************
'*
'*      Class:          EmployeeUpdate         
'*      Author:         Nicole LaBonte
'*      Date Created:   November 27, 2011
'*      Description:    Windows Form class that handles the processing for updating employees.
'*                      The primary functions of the form are:
'*                          -Load all work groups to combobox
'*                          -Process the update of an employee and validate the entered data.
'*                           The employee selected is based on the _anEmployee instance 
'*                           variable that is set when the form is initiated.  Also, 
'*                           the id field is read-only to the user and cannot be changed
'*                           by the user.
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class EmployeeUpdate
    'Set constants
    Const MIN_LENGTH_ID As Integer = 1
    Const MAX_LENGTH_ID As Integer = 3
    Const MIN_LENGTH_NAME As Integer = 3
    Const MAX_LENGTH_NAME As Integer = 25

    'Sets instance variables
    Private _anEmployee As Employee
    'Private allWorkGroups As List(Of WorkGroup)

    '************************************************************************************************
    '*  Property for AnEmployee.  This method is needed to set instance variable _anEmployee
    '*  when the data is passed in from the Process form so that the selected employee from
    '*  the process form has his/her data displayed automatically for editing.
    '************************************************************************************************
    Property AnEmployee As Employee
        Get
            Return _anEmployee
        End Get
        Set(ByVal value As Employee)
            _anEmployee = value
        End Set
    End Property

    '************************************************************************************************
    '*  Method begins processing of form at load.  It calls a method to load work groups to combobox.  
    '*  It sets the max length of name text entry box.  It calls a method to set the value of all 
    '*  fields to the value of the selected employee.
    '************************************************************************************************
    Private Sub EmployeeUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Set max size
        txtName.MaxLength = MAX_LENGTH_NAME

        'Load all work groups
        loadWorkGroups()

        'Obtains selected employee and populate form
        obtainEmployee()

    End Sub

    '************************************************************************************************
    '*  Method sets the values in the form to the current values of the selected employee
    '************************************************************************************************
    Private Sub obtainEmployee()
        Dim index As Integer
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer

        'Find index of employee's work group in combobox
        For index = 0 To comboWorkGroup.Items.Count
            aWorkGroup = CType(comboWorkGroup.Items(index), WorkGroup)

            If aWorkGroup.Id.Equals(AnEmployee.WorkGroup.Id) Then
                returnCode = 1
                Exit For
            End If
        Next

        If returnCode = 1 Then
            'Assign employee's values to form
            txtId.Text = AnEmployee.Id
            txtName.Text = AnEmployee.Name
            comboWorkGroup.SelectedIndex = index

        Else
            MessageBox.Show("Employee could not be found for updating.")
            Me.Close()
        End If

    End Sub

    '************************************************************************************************
    '*  Method handles the clicking of the exit button.  It closes the form.
    '************************************************************************************************
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
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

            MessageBox.Show("ERROR: WorkGroups could not be loaded - employees cannot be updated." _
                & ControlChars.NewLine _
                & ControlChars.NewLine _
                & ex.ToString)

            Me.Close()

        End Try



    End Sub

    '************************************************************************************************
    '*  Method processes when the update button is clicked.  It calls a method to validate the data
    '*  entered by the user.  Then, it attempts to update an existing employee (based on id).  
    '*  If the employee doesn't already exist, then the user receives an error message.
    '************************************************************************************************
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'Declare variables
        Dim isValid As Boolean
        Dim employeeId As String
        Dim employeeName As String
        Dim anEmployee As Employee
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer

        'Verify data
        isValid = validateData()

        'Process employee
        If isValid Then
            'Escapes single quotes in entered fields and sets variables
            employeeId = Replace(txtId.Text, "'", "''")
            employeeName = Replace(txtName.Text, "'", "''")
            aWorkGroup = CType(comboWorkGroup.SelectedItem, WorkGroup)

            'Create employee object
            anEmployee = Employee.find(employeeId)

            'Attempt to update existing employee
            If Not anEmployee Is Nothing Then

                anEmployee.Id = employeeId
                anEmployee.Name = employeeName
                anEmployee.WorkGroup = aWorkGroup

                'Attempt to update database and catch any exceptions
                Try
                    returnCode = anEmployee.update(anEmployee)

                    If returnCode = 1 Then
                        lblOutcome.ForeColor = Drawing.Color.Green
                        lblOutcome.Text = "Success!  Employee '" & employeeId & ": " _
                                            & employeeName & "' updated."
                        resetFocus()
                    End If
                Catch ex As Exception
                    lblOutcome.ForeColor = Drawing.Color.Red
                    lblOutcome.Text = "ERROR: Employee could not be updated."
                    resetFocus()
                    MessageBox.Show(ex.ToString)
                End Try

                'Message displayed if employee doesn't exist
            Else
                lblOutcome.ForeColor = Drawing.Color.Red
                lblOutcome.Text = "Employee id " & employeeId & " does not exist."
                resetFocus()
            End If

        End If



    End Sub

    '************************************************************************************************
    '*  Method validates the data entered by the user and returns true if the data is valid.
    '*  It calls methods to validate the id, name, and workgroup.  Note: Even though the 
    '*  id field is not enterable, the validation is still run on it to ensure there are no
    '*  issues with it.
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
    '*  Method resets the focus to the name textbox and it selects all the data entered in the
    '*  name textbox.
    '************************************************************************************************
    Public Sub resetFocus()
        txtName.SelectAll()
        txtName.Focus()
    End Sub


End Class
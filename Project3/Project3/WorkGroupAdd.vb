'***************************************************************************************************
'*
'*      Class:          WorkGroupAdd         
'*      Author:         Nicole LaBonte
'*      Date Created:   November 27, 2011
'*      Description:    Windows Form class that handles the processing for adding workgroups.
'*                      The primary functions of the form is to process the addition of a work 
'*                      group and validate the entered data
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class WorkGroupAdd

    'Set constants
    Const MIN_LENGTH_ID As Integer = 1
    Const MAX_LENGTH_ID As Integer = 3
    Const MIN_LENGTH_NAME As Integer = 3
    Const MAX_LENGTH_NAME As Integer = 25

    '************************************************************************************************
    '*  Method begins processing of form at load.  It sets the max length of the id and name
    '*  text boxes.
    '************************************************************************************************
    Private Sub WorkGroupAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set max lengths of text entry fields
        txtId.MaxLength = MAX_LENGTH_ID
        txtName.MaxLength = MAX_LENGTH_NAME

        'Load all workgroups
        loadAllWorkgroups()
    End Sub

    '************************************************************************************************
    '*  Method Loads all workgroups
    '*      All workgroups are loaded to populate the workgroup list and check for existing workgroup
    '************************************************************************************************
    Private Sub loadAllWorkgroups()
        Try
            'Initialize employees
            WorkGroup.initialize()

            'Terminate employees
            WorkGroup.terminate()

        Catch ex As Exception

            MessageBox.Show("ERROR: WorkGroups could not be loaded - WorkGroups cannot be added." _
                & ControlChars.NewLine _
                & ControlChars.NewLine _
                & ex.ToString)
            Me.Close()

        End Try
    End Sub

    '************************************************************************************************
    '*  Method handles the clicking of the exit button.  It closes the form.
    '************************************************************************************************
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '************************************************************************************************
    '*  Method processes when the add button is clicked.  It calls a method to validate the data
    '*  entered by the user.  Then, it attempts to add a new workgroup to the database if the 
    '*  workgroup doesn't already exist (based on id).  If the workgroup already exists, then the 
    '*  user receives a message indicating the workgroup couldn't be added.
    '************************************************************************************************
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Declare variables
        Dim isValid As Boolean
        Dim workGroupId As String
        Dim workGroupName As String
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer

        'Verify data is valid
        isValid = validateData()

        'Process employee if data is valid
        If isValid Then
            'Escape single quotes and assign text box information to variables
            workGroupId = Replace(txtId.Text, "'", "''")
            workGroupName = Replace(txtName.Text, "'", "''")

            'Create work group object
            aWorkGroup = WorkGroup.find(workGroupId)

            'Attempt to add workgroup if it doesn't exist and catch exceptions
            If aWorkGroup Is Nothing Then

                aWorkGroup = New WorkGroup(workGroupId, workGroupName)

                Try
                    returnCode = aWorkGroup.addNew(aWorkGroup)

                    If returnCode = 1 Then
                        lblOutcome.ForeColor = Drawing.Color.Green
                        lblOutcome.Text = "Success!  Workgroup '" & workGroupId & ": " _
                                            & workGroupName & "' added."
                        resetEntry()
                    End If
                Catch ex As Exception
                    lblOutcome.ForeColor = Drawing.Color.Red
                    lblOutcome.Text = "ERROR: Workgroup could not be added."
                    resetFocus()
                    MessageBox.Show(ex.ToString)
                End Try

                'Display error message if workgroup already exists
            Else
                lblOutcome.ForeColor = Drawing.Color.Red
                lblOutcome.Text = "Workgroup id " & workGroupId & " already exists."
                txtId.Focus()
                txtId.SelectAll()
            End If

        End If

    End Sub

    '************************************************************************************************
    '*  Method validates the data entered by the user and returns true if the data is valid.
    '*  It calls methods to validate the id and name.
    '************************************************************************************************
    Private Function validateData() As Boolean
        Dim isValid As Boolean

        'Clear output labels
        clearOutputLabels()

        isValid = True

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

        Return isValid

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
    '*  Method clears the text in the labels that are used to provide feedback to the user during
    '*  processing.
    '************************************************************************************************
    Private Sub clearOutputLabels()
        lblErrorId.Text = Nothing
        lblErrorName.Text = Nothing
        lblOutcome.Text = Nothing
    End Sub

    '************************************************************************************************
    '*  Method resets the focus to the id textbox and it selects all the data entered in both the 
    '*  id and name textboxes.
    '************************************************************************************************
    Private Sub resetFocus()
        txtId.SelectAll()
        txtName.SelectAll()
    End Sub

    '************************************************************************************************
    '*  Method resets the form for initial entry.
    '************************************************************************************************
    Private Sub resetEntry()
        txtId.Text = Nothing
        txtName.Text = Nothing
        txtId.Focus()
    End Sub


End Class
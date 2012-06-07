'***************************************************************************************************
'*
'*      Class:          WorkGroupUpdate        
'*      Author:         Nicole LaBonte
'*      Date Created:   November 27, 2011
'*      Description:    Windows Form class that handles the processing for updating workgroups.
'*                      The primary functions of the form are:
'*                          -Load all work groups to combobox
'*                          -Process the update of a workgroup and validate the entered data.
'*                           The workgroup selected is based on the workgroup chosen from
'*                           combobox.  Also, the id field is read-only to the user and cannot 
'*                           be changed by the user.
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

Public Class WorkGroupUpdate

    'Set constants
    Const MIN_LENGTH_ID As Integer = 1
    Const MAX_LENGTH_ID As Integer = 3
    Const MIN_LENGTH_NAME As Integer = 3
    Const MAX_LENGTH_NAME As Integer = 25

    '************************************************************************************************
    '*  Method begins processing of form at load.  It calls a method to load work groups to combobox.
    '*  It sets the max length of the name text entry box.  
    '************************************************************************************************
    Private Sub WorkGroupUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load all work groups
        loadWorkGroups()

        'Select first workgroup
        comboWorkGroup.SelectedIndex = 0

        'Set focus
        comboWorkGroup.Focus()

        'Set max lengths of fields
        txtName.MaxLength = MAX_LENGTH_NAME
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

            MessageBox.Show("ERROR: WorkGroups could not be loaded - WorkGroups could not be updated." _
                & ControlChars.NewLine _
                & ControlChars.NewLine _
                & ex.ToString)
            Me.Close()

        End Try



    End Sub

    '************************************************************************************************
    '*  Method processes with the comboworkgroup index changes.  It sets the text box information
    '*  to match the workgroup selected.
    '************************************************************************************************
    Private Sub comboWorkGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboWorkGroup.SelectedIndexChanged
        Dim aWorkGroup As WorkGroup

        'Obtain selected workgroup
        aWorkGroup = CType(comboWorkGroup.SelectedItem, WorkGroup)

        'Display workgroup data
        txtId.Text = aWorkGroup.Id
        txtName.Text = aWorkGroup.Name

        'Set focus
        comboWorkGroup.Focus()

    End Sub

    '************************************************************************************************
    '*  Method processes when the update button is clicked.  It calls a method to validate the data
    '*  entered by the user.  Then, it attempts to update an existing workgroup (based on id).  
    '*  If the workgroup doesn't already exist, then the user receives an error message.
    '************************************************************************************************
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'Declare variables
        Dim isValid As Boolean
        Dim id As String
        Dim name As String
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer

        'Verify data
        isValid = validateData()

        'Process workgroup if data is valid
        If isValid Then
            'Escape single quotes and assign variables
            id = Replace(txtId.Text, "'", "''")
            name = Replace(txtName.Text, "'", "''")
            aWorkGroup = CType(comboWorkGroup.SelectedItem, WorkGroup)

            'Attempt to update existing workgroup and catch exceptions
            If Not aWorkGroup Is Nothing Then

                aWorkGroup.Id = id
                aWorkGroup.Name = name

                Try
                    returnCode = aWorkGroup.update(aWorkGroup)

                    If returnCode = 1 Then
                        lblOutcome.ForeColor = Drawing.Color.Green
                        lblOutcome.Text = "Success!  Workgroup '" & id & "' updated."
                        resetEntry()
                    End If
                Catch ex As Exception
                    lblOutcome.ForeColor = Drawing.Color.Red
                    lblOutcome.Text = "ERROR: Workgroup could not be updated."
                    MessageBox.Show(ex.ToString)
                End Try

                'Displays error message if work group doesn't exist
            Else
                lblOutcome.ForeColor = Drawing.Color.Red
                lblOutcome.Text = "Workgroup id " & id & " does not exist."
                comboWorkGroup.Focus()
            End If
        End If

    End Sub

    '************************************************************************************************
    '*  Method validates the data entered by the user and returns true if the data is valid.
    '*  It calls methods to validate the id and name.  Note: Even though the 
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
    '*  Method clears the text in the labels that are used to provide feedback to the user during
    '*  processing.
    '************************************************************************************************
    Public Sub clearOutputLabels()
        lblErrorId.Text = Nothing
        lblErrorName.Text = Nothing
        lblOutcome.Text = Nothing
    End Sub

    '************************************************************************************************
    '*  Method resets the form entry for the combobox and textboxes
    '************************************************************************************************
    Public Sub resetEntry()
        Dim selectedWorkGroup As Integer

        'Obtain selected workgroup
        selectedWorkGroup = comboWorkGroup.SelectedIndex

        'Load all work groups
        loadWorkGroups()

        'Select first workgroup
        comboWorkGroup.SelectedIndex = selectedWorkGroup

        'Set focus
        comboWorkGroup.Focus()
    End Sub
End Class
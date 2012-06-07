'***************************************************************************************************
'*
'*      Class:          WorkGroupDA          
'*      Author:         Nicole LaBonte
'*      Date Created:   November 13, 2011
'*      Description:    A data reader class for the WorkGroup.  
'*
'*                      Instance Variables - Shared
'*                          _Group: Dictionary(Of String, WorkGroup)
'*                          _cnWorkgroup: OleDbConnection
'*
'*                      Property - Shared                     
'*                          Group: read-only property for access to _Group
'*                      
'*                      Methods - Shared
'*                          -initialize: opens the database connection and calls loadWorkGorupData
'*                          -loadWorkGroupData: initiates the reading of data by creating the 
'*                              command and data reader object. Calls readData() method
'*                          -readData: reads data from the database, creates a WorkGroup object,
'*                              and adds WorkGroups to the Group Dictionary
'*                          -terminate: closes the database connection
'*                          -find: searches for a WorkGroup and returns the WorkGroup reference
'*                          -addNew: adds WorkGroup to _Group Dictionary and to the database
'*                          -delete: deletes WorkGroup from _Group Dictionary and from the database
'*                          -update: updates WorkGroup in _Group Dictionary and in database
'*                          -A main method to this class to test all of the method calls 
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Imports
Imports System.Data.OleDb

Public Class WorkGroupDA

    'Constants
    Const CN_STRING As String = "Provider=Microsoft.Jet.OLEDB.4.0;" _
                                & "Data Source=..\..\workgroup.mdb"

    'Shared variables
    Private Shared _Group As Dictionary(Of String, WorkGroup)
    Private Shared _cnWorkgroup As OleDbConnection

    '************************************************************************************************
    '*  Shared read-only property Group that returns the reference to the Group Dictionary
    '************************************************************************************************
    Public Shared ReadOnly Property Group As Dictionary(Of String, WorkGroup)
        Get
            Return _Group
        End Get
    End Property

    '************************************************************************************************
    '*  Shared Initialize method
    '*      -Opens the connection
    '*      -Calls loadWorkGroupData()
    '************************************************************************************************
    Public Shared Sub initialize()
        'Create connection string
        _cnWorkgroup = New OleDbConnection(CN_STRING)

        Try
            'Open connection
            _cnWorkgroup.Open()

            'Load WorkGroupData
            loadWorkGroupData()

        Catch ex As Exception

            Throw ex

        End Try


    End Sub

    '************************************************************************************************
    '*  Shared loadWorkGroupData method
    '*      -Initiates the reading of data by creating the command and data reader object
    '*      -Calls readData() method
    '************************************************************************************************
    Private Shared Sub loadWorkGroupData()
        Dim sqlString As String
        Dim command As OleDbCommand
        Dim dataReader As OleDbDataReader

        'Instantiate command object
        command = New OleDbCommand

        'Assign sql string
        sqlString = "SELECT workID, workName " _
                & "FROM workgroup " _
                & "ORDER BY CInt(workID)"

        'Assign command text and connection
        command.CommandText = sqlString
        command.Connection = _cnWorkgroup

        'Create a data reader
        dataReader = command.ExecuteReader

        'Read data
        readData(dataReader)

    End Sub

    '************************************************************************************************
    '*  Shared readData method - takes OleDbDataReader as an argument
    '*      -reads data from the database
    '*      -creates a WorkGroup object
    '*      -adds WorkGroups to the Group Dictionary
    '************************************************************************************************
    Private Shared Sub readData(ByVal dataReader As OleDbDataReader)
        Dim id As String
        Dim name As String
        Dim aWorkGroup As WorkGroup

        'Instantiate data dictionary
        _Group = New Dictionary(Of String, WorkGroup)

        'Update dictionary
        While dataReader.Read

            'Assign values from row
            id = dataReader.GetString(0)
            name = dataReader.GetString(1)

            'Instantiate work group object
            aWorkGroup = New WorkGroup(id, name)

            'Add to data dictionary
            _Group.Add(id, aWorkGroup)

        End While

    End Sub

    '************************************************************************************************
    '*  Shared Terminate method
    '*      -Closes the connection
    '************************************************************************************************
    Public Shared Sub terminate()
        _cnWorkgroup.Close()
    End Sub

    '************************************************************************************************
    '*  Shared AddNew method - takes a workgroup as argument
    '*      -inserts the workgroup into the database with the values from the passed argument
    '*      -adds the workgroup to the Group Dictionary
    '************************************************************************************************
    Public Shared Function addNew(ByVal aWorkGroup As WorkGroup) As Integer
        'Declare variables
        Dim command As OleDbCommand
        Dim sqlString As String
        Dim returnCode As Integer

        'Define sql
        sqlString = "INSERT INTO workgroup(workID, workName) " _
            & "VALUES ('" & aWorkGroup.Id _
            & "','" & aWorkGroup.Name & "')"

        Try
            'Open connection
            _cnWorkgroup.Open()

            'Create command object
            command = New OleDbCommand(sqlString, _cnWorkgroup)

            'Checks if record was added
            returnCode = command.ExecuteNonQuery()

            'If record added, then add to employee list
            If returnCode = 1 Then
                _Group.Add(aWorkGroup.Id, aWorkGroup)
            End If

        Catch ex As Exception
            Throw ex
            'Console.WriteLine(ex)
        Finally
            _cnWorkgroup.Close()
        End Try

        Return returnCode

    End Function


    '************************************************************************************************
    '*  Shared Find method - takes a workgroup id as input
    '*      -return the workgroup object reference from the Group Dictionary or return 'Nothing'. 
    '************************************************************************************************
    Public Shared Function find(ByVal workGroupId As String) As WorkGroup

        If Group Is Nothing Then
            Return Nothing
        End If

        If Group.ContainsKey(workGroupId) Then
            Return Group(workGroupId)
        Else
            Return Nothing
        End If


    End Function

    '************************************************************************************************
    '*  Shared Delete method - takes a WorkGroup object as argument
    '*      -deletes a workgroup from the database
    '*      -removes the workgroup object reference from the Group Dictionary
    '************************************************************************************************
    Public Shared Function delete(ByVal aWorkGroup As WorkGroup) As Integer
        'Declare variables
        Dim command As OleDbCommand
        Dim sqlString As String
        Dim returnCode As Integer

        'Define sql
        sqlString = " DELETE FROM workgroup " _
            & "WHERE workID = '" & aWorkGroup.Id & "'"

        'Delete work group
        Try
            'Open connection
            _cnWorkgroup.Open()

            'Create command object
            command = New OleDbCommand(sqlString, _cnWorkgroup)

            'Checks if record was added
            returnCode = command.ExecuteNonQuery()

            'If record added, then add to employee list
            If returnCode = 1 Then
                _Group.Remove(aWorkGroup.Id)
            End If

        Catch ex As Exception
            Throw ex
            'Console.WriteLine(ex)
        Finally
            _cnWorkgroup.Close()
        End Try


        Return returnCode

    End Function

    '************************************************************************************************
    '*  Shared Update method - takes a workgroup object as argument
    '*      -Updates a workgroup row
    '*      -Removes the workgroup from the Group Dictionary and then adds the workgroup with the
    '*       updated data to the Group Dictionary
    '************************************************************************************************
    Public Shared Function update(ByVal aWorkGroup As WorkGroup) As Integer
        'Declare variables
        Dim command As OleDbCommand
        Dim sqlString As String
        Dim returnCode As Integer

        'Define sql
        sqlString = "UPDATE workgroup " _
            & "SET workName = '" & aWorkGroup.Name _
            & "' WHERE workID = '" & aWorkGroup.Id & "'"

        Try
            'Open connection
            _cnWorkgroup.Open()

            'Create command object
            command = New OleDbCommand(sqlString, _cnWorkgroup)

            'Checks if record was added
            returnCode = command.ExecuteNonQuery()

            'If record added, then update record
            If returnCode = 1 Then
                _Group.Remove(aWorkGroup.Id)
                _Group.Add(aWorkGroup.Id, aWorkGroup)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            _cnWorkgroup.Close()
        End Try

        Return returnCode

    End Function

    '************************************************************************************************
    '*  A main method to this class to test all of the method calls
    '************************************************************************************************
    Public Shared Sub main()

        Dim workGroupId As String
        Dim output As String
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer

        'Set variables
        workGroupId = "824"

        'Test initialize / terminate
        initialize()
        terminate()

        'Test addNew
        aWorkGroup = New WorkGroup(workGroupId, "newGroup")
        returnCode = addNew(aWorkGroup)
        If returnCode = 1 Then
            output = "WorkGroup added for addNew(" & aWorkGroup.ToString & ")"
            Console.WriteLine(output)
            Console.WriteLine()
        End If

        'Test find
        output = "Workgroup for find(" & workGroupId & ")"
        Console.WriteLine(output)
        Console.WriteLine(find(workGroupId))
        Console.WriteLine()

        'Test update
        aWorkGroup.Name = "changedGroup"
        returnCode = update(aWorkGroup)
        If returnCode = 1 Then
            Console.WriteLine("WorkGroup after update - name changed to changedGroup: ")
            Console.WriteLine(find(workGroupId))
            Console.WriteLine()
        End If

        'Test delete
        returnCode = delete(aWorkGroup)
        If returnCode = 1 Then
            output = "WorkGroup after delete (" & aWorkGroup.ToString & ")"
            Console.WriteLine(output)
            Console.WriteLine()
        End If

        'Test Find
        output = "WorkGroup (post-delete) for find(" & workGroupId & ")"
        Console.WriteLine(output)
        Console.WriteLine(find(workGroupId))
        Console.WriteLine()

        Console.ReadLine()


    End Sub

End Class

'***************************************************************************************************
'*
'*      Class:          WorkGroup          
'*      Author:         Nicole LaBonte
'*      Date Created:   November 13, 2011
'*      Description:    Contains the properties and methods for a WorkGroup.
'*
'*                      Instance Variables
'*                          _Id: holds id of WorkGroup
'*                          _Name: holds name of WorkGroup
'*                          _Members: holds a list of Employees
'*
'*                      Properties: 
'*                          _Id, _Name, and _Members have public properties
'*                          Group has a read-only public property that accesses the WorkGroupDA variable
'*
'*                      Constructor: 
'*                          Takes variables for the 2 properties as arguments and instantiates the list
'*
'*                      Methods - Shared
'*                          -initialize: calls the WorkGroupDA class to open the database connection 
'*                              and populate the Group Dictionary
'*                          -terminate: calls the WorkGroupDA class to close the database connection
'*                          -find: calls the WorkGroupDA class to search for a WorkGroup and 
'*                              return the WorkGroup reference
'*                          -A main method to this class to test all of the method calls 

'*                      Methods - Non-Shared
'*                          -addNew: calls the WorkGroupDA class to add a WorkGroup to 
'*                              Group Dictionary and to the database
'*                          -delete: calls the WorkGroupDA class to delete the WorkGroup from 
'*                              Group Dictionary and from the database
'*                          -update: calls the WorkGroupDA class to update the WorkGroup in 
'*                              Group Dictionary and in database
'*                          -toString: displays the WorkGroup with formatting for a GUI display
'*                          -toStringConsole: displays the WorkGroup with formatting for a console display.
'*                              It displays both the WorkGroup and employees in the WorkGroup
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Import for StringBuilder
Imports System.Text

Public Class WorkGroup

    'Declare instance variables
    Private _Id As String
    Private _Name As String
    Private _Members As List(Of Employee)

    '************************************************************************************************
    '*  Properties
    '************************************************************************************************
    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property Members() As List(Of Employee)
        Get
            Return _Members
        End Get
        Set(ByVal value As List(Of Employee))
            _Members = value
        End Set
    End Property

    '************************************************************************************************
    '*  Shared property which will access the WorkgroupDA's group property
    '*      -returns the reference to the workgroup datadictionary
    '************************************************************************************************
    Public Shared ReadOnly Property Group As Dictionary(Of String, WorkGroup)
        Get
            Return WorkGroupDA.Group
        End Get
    End Property

    '************************************************************************************************
    '*  Constructors
    '************************************************************************************************
    Public Sub New(ByVal id As String, ByVal name As String)
        Me.Id = id
        Me.Name = name

        'instantiate the members list
        Me.Members = New List(Of Employee)
    End Sub

    '************************************************************************************************
    '*  Method displays this workgroup and all of its employees for a CONSOLE APPLICATION
    '*      -use a string builder
    '*      -to add the employee information iterate though the list of members, calling the 
    '*        employee obect's toString method 
    '************************************************************************************************
    Public Function ToStringConsole() As String
        Dim builder As New StringBuilder

        'Workgroup information
        builder.Append("Work Group => " & Id & ": " & Name)
        builder.Append(ControlChars.NewLine)
        builder.Append("****************************************")
        builder.Append(ControlChars.NewLine)

        'Display all employees in work group
        For Each person As Employee In Members
            builder.Append(person.ToString)
            builder.Append(ControlChars.NewLine)
        Next

        'Display footer
        builder.Append("****************************************")

        'Return String of employees
        Return builder.ToString

    End Function

    '************************************************************************************************
    '*  Overridden ToString method optimized to display the workgroup for a GUI interface
    '************************************************************************************************
    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder

        'Workgroup information
        builder.Append(Id & ": " & Name)

        'Return String of employees
        Return builder.ToString

    End Function


    '************************************************************************************************
    '*  Shared method Initialize which will call the WorkgroupDA's method
    '*      -opens the database connection 
    '*      -populates the Group Dictionary
    '************************************************************************************************
    Public Shared Sub initialize()
        WorkGroupDA.initialize()
    End Sub

    '************************************************************************************************
    '*  Shared method Terminate which will call the WorkgroupDA's method
    '*      -Closes the connection
    '************************************************************************************************
    Public Shared Sub terminate()
        WorkGroupDA.terminate()
    End Sub

    '************************************************************************************************
    '*  Shared method Find which will call the WorkgroupDA's method
    '*      -return the workgroup object reference from the Group Dictionary or return 'Nothing'
    '************************************************************************************************
    Public Shared Function find(ByVal workGroupId As String) As WorkGroup
        Return WorkGroupDA.find(workGroupId)
    End Function

    '************************************************************************************************
    '*  Non-shared method AddNew calls the DA method, passing the current instance
    '*      -inserts a WorkGroup into the database with the values from the passed argument
    '*      -Adds the WorkGroup to the Group dictionary
    '************************************************************************************************
    Public Function addNew(ByVal aWorkGroup As WorkGroup) As Integer
        Return WorkGroupDA.addNew(aWorkGroup)
    End Function

    '************************************************************************************************
    '*  Non-shared method delete which calls the DA method, passing the current instance
    '*      -deletes a workgroup based on the WorkGroup object argument
    '************************************************************************************************
    Public Function delete(ByVal aWorkGroup As WorkGroup) As Integer
        Return WorkGroupDA.delete(aWorkGroup)
    End Function

    '************************************************************************************************
    '*  Non-shared method update which calls the DA method, passing the current instance 
    '*      -Updates a WorkGroup in the database
    '*      -Removes the workgroup from the Group Dictionary and then adds the workgroup with the
    '*       updated data to the Group Dictionary
    '************************************************************************************************
    Public Function update(ByVal aWorkGroup As WorkGroup) As Integer
        Return WorkGroupDA.update(aWorkGroup)
    End Function


    '************************************************************************************************
    '*  A main method to this class to test all of the method calls
    '************************************************************************************************
    Public Shared Sub main()

        Dim workGroupId As String
        Dim workGroupConsoleId As String
        Dim output As String
        Dim aWorkGroup As WorkGroup
        Dim returnCode As Integer

        'Set variables
        workGroupId = "824"
        workGroupConsoleId = "100"

        'Test initialize / terminate
        initialize()
        terminate()

        'Test addNew
        aWorkGroup = New WorkGroup(workGroupId, "newGroup")
        returnCode = aWorkGroup.addNew(aWorkGroup)
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
        returnCode = aWorkGroup.update(aWorkGroup)
        If returnCode = 1 Then
            Console.WriteLine("WorkGroup after update - name changed to changedGroup: ")
            Console.WriteLine(find(workGroupId))
            Console.WriteLine()
        End If

        'Test delete and toString
        returnCode = aWorkGroup.delete(aWorkGroup)
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

        'Test toStringConsole and find (initialize of employee list)
        Employee.initialize("")
        Employee.terminate()

        aWorkGroup = WorkGroup.find(workGroupConsoleId)
        output = "Workgroup toStringConsole(" & workGroupId & ")"
        Console.WriteLine(output)
        Console.WriteLine(aWorkGroup.ToStringConsole())
        Console.WriteLine(aWorkGroup.Members.Count.ToString)


        Console.ReadLine()


    End Sub

End Class

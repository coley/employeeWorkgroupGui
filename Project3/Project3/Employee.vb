'***************************************************************************************************
'*
'*      Class:          Employee         
'*      Author:         Nicole LaBonte
'*      Date Created:   November 13, 2011
'*      Description:    Contains the properties and methods for an Employee.
'*
'*                      Instance Variables
'*                          _Id: String for id of employee
'*                          _Name: String for name of employee
'*                          _WorkGroup: WorkGroup object reference for employee
'*
'*                      Properties: 
'*                          _Id, _Name, and _WorkGroup have public properties
'*                          EmployeeList has a read-only public property that accesses the 
'*                              EmployeeDA variable
'*
'*                      Constructor: 
'*                          The constructor receives values for all three properties as arguments
'*                          and sets the name and id properties. It will add the reference of this 
'*                          object to the workgroup object's member arraylist
'*
'*                      Methods - Shared:
'*                          -initialize: calls the EmployeeDA class to open the database connection
'*                              and populate the EmployeeList
'*                          -terminate: calls the EmployeeDA class and closes the database connection
'*                          -find: calls the EmployeeDA class and returns the employee reference for 
'*                              a searched Employee
'*                          -main: tests the method calls 
'*
'*                      Methods - Non-Shared:
'*                          -addNew: calls the EmployeeDA class and adds employee to _EmployeeList 
'*                              and to the database
'*                          -delete: calls the EmployeeDA class and deletes employee from _EmployeeList 
'*                              and from the database
'*                          -update: calls the EmployeeDA class and updates employee in _EmployeeList 
'*                              and in database
'*                          -ToString: returns the contents of the Employee object as a string 
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Class
Public Class Employee

    'Declare instance variables
    Private _Id As String
    Private _Name As String
    Private _WorkGroup As WorkGroup

    '************************************************************************************************
    '*  Properties
    '************************************************************************************************
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property Id As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property

    Public Property WorkGroup As WorkGroup
        Get
            Return _WorkGroup
        End Get
        Set(ByVal value As WorkGroup)
            _WorkGroup = value
        End Set
    End Property

    '************************************************************************************************
    '*  Shared readonly property which calls the DA property and returns an employee list reference
    '************************************************************************************************
    Public Shared ReadOnly Property EmployeeList As Dictionary(Of String, Employee)
        Get
            Return EmployeeDA.EmployeeList
        End Get
    End Property

    '************************************************************************************************
    '*  Constructors
    '************************************************************************************************
    Public Sub New(ByVal id As String,
                   ByVal name As String,
                   ByVal workGroup As WorkGroup)

        Me.Id = id
        Me.Name = Name
        Me.WorkGroup = workGroup

    End Sub

    '************************************************************************************************
    '*  Shared Initialize method which calls the EmployeeDA class's Initialize method.
    '*  This method opens the connection, instantiate a dataset object, and call methods to 
    '*  get employee data and populate the employee list of objects. Note: The criteria entered is 
    '*  passed to the getEmployeeData method to match the criteria of name or id
    '************************************************************************************************
    Public Shared Sub initialize(ByVal criteria As String)
        EmployeeDA.initialize(criteria)
    End Sub

    '************************************************************************************************
    '*  Shared find method which takes a string id as argument and calls the DA method.
    '*  Compares the id to the id of each employee in the employee list.  If the employee is found,
    '*  returns the found employee reference; otherwise, returns the term Nothing null reference.
    '************************************************************************************************
    Public Shared Function find(ByVal id As String) As Employee
        Return EmployeeDA.find(id)
    End Function

    '************************************************************************************************
    '*  Terminate method calls the EmployeeDA class's Terminate
    '*  Closes the connection
    '************************************************************************************************
    Public Shared Sub terminate()
        EmployeeDA.terminate()
    End Sub

    '************************************************************************************************
    '*  Non-shared method AddNew calls the DA method, passing this instance and adds the employee
    '*  Inserts an employee row with the values of the from the passed argument and adds the 
    '*  employee to the list
    '************************************************************************************************
    Public Function addNew(ByVal anEmployee As Employee) As Integer
        Return EmployeeDA.addNew(anEmployee)
    End Function

    '************************************************************************************************
    '*  Non-shared method delete calls the DA method, passing this instance and deletes the employee
    '*  Deletes an employee row and removes the employee from the employee list
    '************************************************************************************************
    Public Function delete(ByVal anEmployee As Employee) As Integer
        Return EmployeeDA.delete(anEmployee)
    End Function

    '************************************************************************************************
    '*  Non-shared method update calls the DA method, passing this instance and updates the employee
    '*  Updates an employee row based on the employee argument, removes the employee from the 
    '*  employee list and newly adds the employee with the updates to the employee list
    '************************************************************************************************
    Public Function update(ByVal anEmployee As Employee) As Integer
        Return EmployeeDA.update(anEmployee)
    End Function

    '************************************************************************************************
    '* ToString method which will return the contents of this object as a string. This string
    '* is optimized for display in a form.
    '************************************************************************************************
    Public Overrides Function ToString() As String
        Return Id & ": " & Name
    End Function

    '************************************************************************************************
    '*  A main method to this class to test all of the method calls
    '************************************************************************************************
    Public Shared Sub main()

        Dim anEmployee As Employee
        Dim employeeId As String
        Dim workGroupId As String
        Dim output As String
        Dim returnCode As Integer
        Dim aWorkGroup As WorkGroup

        'Set variables
        employeeId = "984"
        workGroupId = "100"

        'Initialize all work groups and set workgroup
        WorkGroup.initialize()
        aWorkGroup = WorkGroup.find(workGroupId)
        WorkGroup.terminate()

        'Test initialize / terminate of employees
        initialize("")
        terminate()

        If Not aWorkGroup Is Nothing Then
            'Display employees in workgroup
            output = "1. ToStringConsole - Display WorkGroup " & aWorkGroup.ToString
            Console.WriteLine(output)
            Console.WriteLine(aWorkGroup.ToStringConsole)
            Console.WriteLine()

            'Test getWorkGroup
            output = "2. getWorkGroup - Workgroup: " & workGroupId
            Console.WriteLine(output)
            Console.WriteLine(aWorkGroup)
            Console.WriteLine()

            'Test addNew and toString
            anEmployee = New Employee(employeeId, "thomas", aWorkGroup)
            returnCode = anEmployee.addNew(anEmployee)
            If returnCode = 1 Then
                output = "3. addNew - " _
                    & "id: " & employeeId _
                    & ", name: thomas" _
                    & ", workgroup: " & aWorkGroup.ToString
                Console.WriteLine(output)
            End If

            'Display employees in workgroup
            Console.WriteLine(aWorkGroup.ToStringConsole)
            Console.WriteLine()

            'Test Find
            output = "4. find - employee: " & employeeId
            Console.WriteLine(output)
            Console.WriteLine(find(employeeId))
            Console.WriteLine()

            'Test update
            anEmployee.Name = "Janulia"
            returnCode = anEmployee.update(anEmployee)
            If returnCode = 1 Then
                Console.WriteLine("5. update - name changed to Janulia for id " & employeeId)
                Console.WriteLine(find(employeeId))
                Console.WriteLine()
            End If

            'Display employees in workgroup
            Console.WriteLine(aWorkGroup.ToStringConsole)
            Console.WriteLine()

            'Test delete and ToString
            returnCode = anEmployee.delete(anEmployee)
            If returnCode = 1 Then
                output = "6. delete - employee deleted for id " & employeeId
                Console.WriteLine(output)
                Console.WriteLine()
            End If

            'Display employees in workgroup
            Console.WriteLine(aWorkGroup.ToStringConsole)
            Console.WriteLine()

        Else
            Console.WriteLine("ERROR: Workgroup missing.")
        End If

        Console.ReadLine()


    End Sub
End Class

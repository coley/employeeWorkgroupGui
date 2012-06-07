'***************************************************************************************************
'*
'*      Class:          EmployeeDA          
'*      Author:         Nicole LaBonte
'*      Date Created:   November 13, 2011
'*      Description:    A data adapter class for the Employee.  
'*
'*                      Instance Variables - Shared
'*                          cnEmployee: OleDbConnection
'*                          dataAdapter: OleDbDataAdapter
'*                          _EmployeeList: Dictionary(of String, Employee)
'*
'*                      Property - Shared                     
'*                          EmployeeList: read-only property for access to _EmployeeList
'*
'*                      Methods - Shared
'*                          -initialize: opens the database connection and calls getEmployeeData method
'*                          -getEmployeeData: instantiates dataset and adapter, fills dataset,
'*                              and calls readData method
'*                          -readData: reads dataset, creates an employee object, adds 
'*                              employee to list, and adds employee to workgroup members list
'*                          -terminate: closes the database connection
'*                          -find: searches for an Employee and returns the employee reference
'*                          -addNew: adds employee to _EmployeeList, to the database, and to 
'*                              workgroup members list
'*                          -delete: deletes employee from _EmployeeList, from the database, and
'*                              from workgroup members list
'*                          -update: updates employee in _EmployeeList and in database
'*                          -main: tests the method calls 
'*
'***************************************************************************************************

'Set options
Option Strict On
Option Explicit On
Option Infer Off

'Imports
Imports System.Data.OleDb

Public Class EmployeeDA

    'Constants
    Const CN_STRING As String = "Provider=Microsoft.Jet.OLEDB.4.0;" _
                                & "Data Source=..\..\workgroup.mdb"

    'Declare variables
    Private Shared cnEmployee As OleDbConnection
    Private Shared _EmployeeList As Dictionary(Of String, Employee)
    Private Shared dataAdapter As OleDbDataAdapter

    '************************************************************************************************
    '*  A shared readonly property for the _EmployeeList
    '************************************************************************************************
    Public Shared ReadOnly Property EmployeeList As Dictionary(Of String, Employee)
        Get
            Return _EmployeeList
        End Get
    End Property

    '************************************************************************************************
    '*  Initialize method - shared - it takes criteria as a string
    '*  Open the connection, instantiate a dataset object, and call methods to get employee data
    '*  and populate the employee list of objects.  Note: The criteria entered is passed
    '*  to the getEmployeeData method to match the criteria of name or id.  This allows searching
    '*  on the form.
    '************************************************************************************************
    Public Shared Sub initialize(ByVal criteria As String)
        'Create connection string
        cnEmployee = New OleDbConnection(CN_STRING)

        Try
            'Open connection
            cnEmployee.Open()

            'Obtain employee data
            getEmployeeData(criteria)

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    '************************************************************************************************
    '*  getEmployeeData method - shared
    '*  Instantiate an adapter object, fill the dataset, and call method to read data
    '************************************************************************************************
    Private Shared Sub getEmployeeData(ByVal criteria As String)
        Dim sqlString As String
        Dim employeeTable As DataTable
        Dim dataSet As DataSet

        'Instantiate data set object
        dataSet = New DataSet

        'Set sql string
        sqlString = "SELECT empID, empName, workID " _
                & "FROM  employee " _
                & "WHERE empName like '" & criteria & "%' " _
                & "OR empID like '" & criteria & "%'" _
                & "ORDER BY CInt(workID), CInt(empID)"

        'Instantiate adapter with sql string
        dataAdapter = New OleDbDataAdapter(sqlString, cnEmployee)

        'Obtain data from DB and place in dataset
        dataAdapter.Fill(dataSet)

        'Populate table with data set
        employeeTable = dataSet.Tables(0)

        'Read data from the table
        readData(employeeTable)

        'Set dataset to nothing
        dataSet = Nothing

    End Sub

    '************************************************************************************************
    '*  readData method - shared
    '*  Read each row from the employee table, use the workgroup id field to call the the workgroup 
    '*  shared find method to get a reference to the workgroup to which this employee belongs, 
    '*  instantiate the employee object, add the object to the employee arraylist
    '************************************************************************************************
    Private Shared Sub readData(ByVal employeeTable As DataTable)
        Dim id As String
        Dim name As String
        Dim workGroupId As String
        Dim index As Integer
        Dim aWorkGroup As WorkGroup
        Dim anEmployee As Employee
        Dim rows As DataRowCollection
        Dim employeeRow As DataRow

        'Instantiate list of employees
        _EmployeeList = New Dictionary(Of String, Employee)

        'Assign rows from table
        rows = employeeTable.Rows

        'Create employee objects and assign to employee list
        For index = 0 To rows.Count - 1
            'Assign current employee row
            employeeRow = rows(index)

            'Obtain data from row and assign to variables
            id = employeeRow(0).ToString
            name = employeeRow(1).ToString
            workGroupId = employeeRow(2).ToString

            'Obtain work group
            aWorkGroup = WorkGroup.find(workGroupId)

            'Create an employee object
            anEmployee = New Employee(id, name, aWorkGroup)

            'Add employee to list
            EmployeeList.Add(id, anEmployee)

            'Add employee to WorkGroup members list
            If Not aWorkGroup Is Nothing Then
                aWorkGroup.Members.Add(anEmployee)
            End If
        Next

    End Sub


    '************************************************************************************************
    '*  Terminate method - shared no arguments 
    '*  Close the connection
    '************************************************************************************************
    Public Shared Sub terminate()
        cnEmployee.Close()
    End Sub

    '************************************************************************************************
    '*  Find method - shared takes an id as argument
    '*  Compares the id to the id of each employee in the employee list.  If found returns the 
    '*  found employee reference; otherwise, returns the term Nothing null reference
    '************************************************************************************************
    Public Shared Function find(ByVal id As String) As Employee

        'Dim anEmployee As Employee = Nothing

        If EmployeeList Is Nothing Then
            Return Nothing
        End If

        If EmployeeList.ContainsKey(id) Then
            'anEmployee = EmployeeList(id)
            Return EmployeeList(id)
        Else
            Return Nothing
        End If

        'Return anEmployee

    End Function

    '************************************************************************************************
    '*  AddNew method - shared takes an employee object as argument
    '*  Insert sql statement that inserts an employee row with the values from the passed 
    '*  argument and add the employee to the list and insert the row into the database table
    '************************************************************************************************
    Public Shared Function addNew(ByVal anEmployee As Employee) As Integer
        'Declare variables
        Dim command As OleDbCommand
        Dim sqlString As String
        Dim returnCode As Integer
        Dim aWorkGroup As WorkGroup

        'Define sql
        sqlString = "INSERT INTO employee(empID, empName, workID) " _
            & "VALUES ('" & anEmployee.Id _
            & "','" & anEmployee.Name _
            & "','" & anEmployee.WorkGroup.Id & "')"

        Try
            'Open connection
            cnEmployee.Open()

            'Create command object
            command = New OleDbCommand(sqlString, cnEmployee)

            'Checks if record was added
            returnCode = command.ExecuteNonQuery()

            'If record added, then add to employee list and workgroup members list
            If returnCode = 1 Then
                _EmployeeList.Add(anEmployee.Id, anEmployee)

                aWorkGroup = anEmployee.WorkGroup
                aWorkGroup.Members.Add(anEmployee)
            End If

        Catch ex As Exception
            Throw ex
            'Console.WriteLine(ex)
        Finally
            cnEmployee.Close()
        End Try

        Return returnCode

    End Function

    '************************************************************************************************
    '*  Delete method - shared takes an employee object as argument
    '*  Deletes an employee row and removes the employee from the employee list
    '************************************************************************************************
    Public Shared Function delete(ByVal anEmployee As Employee) As Integer
        'Declare variables
        Dim command As OleDbCommand
        Dim sqlString As String
        Dim returnCode As Integer
        Dim aWorkGroup As WorkGroup

        'Define sql
        sqlString = "DELETE FROM employee " _
            & "WHERE empId = '" & anEmployee.Id & "'"

        Try
            'Open connection
            cnEmployee.Open()

            'Create command object
            command = New OleDbCommand(sqlString, cnEmployee)

            'Checks if record was deleted
            returnCode = command.ExecuteNonQuery()

            'If record deleted, then remove from employee list and workgroup members list
            If returnCode = 1 Then
                _EmployeeList.Remove(anEmployee.Id)

                aWorkGroup = anEmployee.WorkGroup
                aWorkGroup.Members.Remove(anEmployee)
            End If

        Catch ex As Exception
            Throw ex
            'Console.WriteLine(ex)
        Finally
            cnEmployee.Close()
        End Try

        Return returnCode

    End Function

    '************************************************************************************************
    '*  Update method - shared takes an employee object as argument
    '*  Updates an employee row based on the employee argument, removes the employee from the 
    '*  employee list and newly adds the employee with the updates to the employee list
    '************************************************************************************************
    Public Shared Function update(ByVal anEmployee As Employee) As Integer
        'Declare variables
        Dim command As OleDbCommand
        Dim sqlString As String
        Dim returnCode As Integer

        'Define sql
        sqlString = "UPDATE employee " _
            & "SET empName = '" & anEmployee.Name _
            & "', workID = '" & anEmployee.WorkGroup.Id _
            & "' WHERE empId = '" & anEmployee.Id & "'"

        Try
            'Open connection
            cnEmployee.Open()

            'Create command object
            command = New OleDbCommand(sqlString, cnEmployee)

            'Checks if record was updated
            returnCode = command.ExecuteNonQuery()

            'If record updated, then remove and re-add to employee list
            If returnCode = 1 Then
                _EmployeeList.Remove(anEmployee.Id)
                _EmployeeList.Add(anEmployee.Id, anEmployee)
            End If

        Catch ex As Exception
            Throw ex
            'Console.WriteLine(ex)
        Finally
            cnEmployee.Close()
        End Try

        Return returnCode

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

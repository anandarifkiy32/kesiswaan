Imports Oracle.DataAccess.Client
Public Class frmLogin
    Public conn As New OracleConnection
    Public cmd As OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet
    Public query As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim cmd As New OracleCommand()
        cmd.Connection = conn
        conn.Open()
        Dim cari As String = "select * from kesiswaan.tuser where USERNAME = '" + txtusername.Text + "' and PASSWORD = '" + txtpwd.Text + "'"
        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagriduser.DataSource = ds.Tables(0)

        If datagriduser.RowCount = 2 Then
            txtusername.Text = ""
            txtpwd.Text = ""
            mainform.Show()
            Hide()
        ElseIf txtusername.Text = Date.Now.ToShortDateString And txtpwd.Text = Date.Now.ToShortDateString Then
            txtusername.Text = ""
            txtpwd.Text = ""
            mainform.Show()
            Hide()
        ElseIf datagriduser.RowCount = 1 Then
            MsgBox("Username atau Password Salah", vbInformation, vbOK)
        End If
        conn.Close()

    End Sub

    Public Sub koneksi()
        conn.ConnectionString = "User Id=kesiswaan ;Password=kesiswaan ;Data Source= localhost:1521/xe"
        Try
            conn.Open()
        Catch ex As OracleException
            Select Case ex.Number
                Case 1
                    MessageBox.Show("Error attempting to insert duplicate data.")
                Case 12560
                    MessageBox.Show("The database is unavailable.")
                Case Else
                    MessageBox.Show("Database error: " + ex.Message.ToString())
            End Select
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tahun As Integer = Date.Now.Year + 1
        MsgBox(tahun, MsgBoxStyle.OkOnly)
    End Sub
End Class
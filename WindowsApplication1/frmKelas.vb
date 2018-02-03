Imports Oracle.DataAccess.Client
Public Class frmKelas

    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da, dac As OracleDataAdapter
    Public cb, cbc As OracleCommandBuilder
    Public ds, dsc As DataSet

    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninputkelas.Click
        If txtnoindukkelas.Text = "" Then
            MsgBox("Nomor Induk tidak boleh kosong", vbInformation & vbOKOnly, "Perhatian")
            txtnoindukkelas.Focus()
            Exit Sub
        End If

        Dim des As Double = Convert.ToDouble(Val(txtdeskelas.Text))

        cmd.Connection = conn
        conn.Open()
        Dim cari As String = "select * from kesiswaan.kelas where NO_INDUK = '" + txtnoindukkelas.Text + "'"
        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        mainform.DataGridSiswa.DataSource = ds.Tables(0)

        If mainform.DataGridSiswa.RowCount = 1 Then
            cmd = New OracleCommand("insert into kesiswaan.kelas (NO_INDUK, KELAS, DES, TA) values ('" + txtnoindukkelas.Text + "','" + cbokelaskelas.Text + "'," & des & ",'" + txttakelas.Text + "')", conn)
            cmd.ExecuteNonQuery()

            Call tampildatakelas()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("update kesiswaan.kelas set KELAS='" + cbokelaskelas.Text + "', DES=" & des & ", TA='" + txttakelas.Text + "')", conn)
                cmd.ExecuteNonQuery()
                Call tampildatakelas()
                mainform.DataGridSiswa.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
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

    Private Sub frmKelas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
        Call tampildatakelas()
        Call load_cbokelas()
        mainform.DataGridSiswa.DataSource = ds.Tables(0)
    End Sub

    Public Sub load_cbokelas()
        Dim i As Integer
        i = mainform.datagridkelas.RowCount
        Dim maxrow As Integer = i - 2
        Dim row As Integer
        Dim value As Object
        For row = 0 To maxrow
            value = mainform.datagridkelas.Item(0, row).Value
            cbokelaskelas.Items.Remove(value)
        Next
        For row = 0 To maxrow
            value = mainform.datagridkelas.Item(0, row).Value
            cbokelaskelas.Items.Add(value)
        Next
    End Sub

    Public Sub tampildatakelas()
        Dim sql As String = "select * from kesiswaan.kelas"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
    End Sub
End Class
Imports Oracle.DataAccess.Client
Public Class frmBakatSiswa
    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtnoinduk.Text = "" Then
            MsgBox("No Induk tidak boleh kosong", vbOKOnly + vbInformation, "Perhatian")
            Exit Sub
        End If

        cmd.Connection = conn
        conn.Open()
        Dim cari As String = "select * from kesiswaan.siswa where NO_INDUK = '" + txtnoinduk.Text + "'"
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
            cmd = New OracleCommand("insert into kesiswaan.siswa (NO_INDUK, KESENIAN, OLAH_RAGA, ORGANISASI, LAIN_LAIN ) values ('" + txtnoinduk.Text + "','" + txtkesenian.Text + "','" + txtolahraga.Text + "','" + txtorganisasi.Text + "','" + txtlainlain.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            cmd = New OracleCommand("Update kesiswaan.siswa set KESENIAN='" + txtkesenian.Text + "', OLAH_RAGA='" +
                                    txtolahraga.Text + "', ORGANISASI='" + txtorganisasi.Text + "', LAIN_LAIN='" + txtlainlain.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
        End If
        Call clear()
    End Sub

    Public Sub clear()
        txtnoinduk.Text = ""
        txtlainlain.Text = ""
        txtlainlain.Enabled = False
        txtkesenian.Text = ""
        txtkesenian.Enabled = False
        txtolahraga.Text = ""
        txtolahraga.Enabled = False
        txtorganisasi.Text = ""
        txtorganisasi.Enabled = False
        txtnoinduk.Enabled = True
        txtnoinduk.Focus()
        Button1.Enabled = False
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

    Public Sub tampildatasiswa()
        Dim sql As String = "select * from kesiswaan.siswa order by no_induk asc"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
    End Sub

    Private Sub frmArsipBakatSiswa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
        Call clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call tampildatasiswa()
        mainform.DataGridSiswa.DataSource = ds.Tables(0)
        Close()
    End Sub

    Private Sub input()
        txtkesenian.Enabled = True
        txtlainlain.Enabled = True
        txtolahraga.Enabled = True
        txtorganisasi.Enabled = True
        txtnoinduk.Enabled = False
        Button1.Enabled = True
    End Sub

    Private Sub txtnoinduk_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnoinduk.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim query As String = "select * from kesiswaan.siswa where no_induk = '" + txtnoinduk.Text + "'"

            conn.Open()

            cmd = New OracleCommand(query, conn)

            Dim dr As OracleDataReader = cmd.ExecuteReader()
            dr.Read()

            da = New OracleDataAdapter(cmd)
            cb = New OracleCommandBuilder(da)
            ds = New DataSet()
            da.Fill(ds)

            mainform.DataGridSiswa.DataSource = ds.Tables(0)

            If mainform.DataGridSiswa.RowCount = 1 Then
                Call input()
            Else
                Call input()

                If IsDBNull(dr.Item(25)) Then
                    txtkesenian.Text = ""
                Else
                    txtkesenian.Text = dr.Item(25)
                End If

                If IsDBNull(dr.Item(26)) Then
                    txtolahraga.Text = ""
                Else
                    txtolahraga.Text = dr.Item(26)
                End If

                If IsDBNull(dr.Item(27)) Then
                    txtorganisasi.Text = ""
                Else
                    txtorganisasi.Text = dr.Item(27)
                End If
            End If
            conn.Close()
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clear()
    End Sub
End Class
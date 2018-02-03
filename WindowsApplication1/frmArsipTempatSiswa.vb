Imports Oracle.DataAccess.Client
Public Class frmArsipTempatSiswa

    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da, dac As OracleDataAdapter
    Public cb, cbc As OracleCommandBuilder
    Public ds, dsc As DataSet

    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        If txtnoinduk.Text = "" Then
            MsgBox("No Induk  tidak boleh kosong", vbOK + vbInformation, "Perhatian")
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
            cmd = New OracleCommand("insert into kesiswaan.siswa( NO_INDUK, ALAMAT_RUMAH_SISWA, TELP_SISWA, ALAMAT_KOST_SISWA, BAPAK_KOST_SISWA, TELP_KOST_SISWA, JARAK_SISWA) VALUES ('" + txtnoinduk.Text + "','" + txtalamatrumah.Text + "','" + txttelpsiswa.Text + "','" + txtalamatkos.Text + "','" + txtbapakkos.Text + "','" + txttelpkos.Text + "','" + txtjaraksiswa.Text + "';", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.siswa set ALAMAT_RUMAH_SISWA='" + txtalamatrumah.Text + "', TELP_SISWA='" +
                                    txttelpsiswa.Text + "', ALAMAT_KOST_SISWA='" + txtalamatkos.Text + "', BAPAK_KOST_SISWA='" + txtbapakkos.Text + "',
                                    TELP_KOST_SISWA='" + txttelpkos.Text + "', JARAK_SISWA='" + txtjaraksiswa.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatasiswa()
                mainform.DataGridSiswa.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
        Call clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call tampildatasiswa()
        mainform.DataGridSiswa.DataSource = ds.Tables(0)
        Close()
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

    Public Sub clear()
        txtnoinduk.Text = ""
        txttelpsiswa.Text = ""
        txttelpsiswa.Enabled = False
        txttelpkos.Text = ""
        txttelpkos.Enabled = False
        txtalamatkos.Text = ""
        txtalamatkos.Enabled = False
        txtalamatrumah.Text = ""
        txtalamatrumah.Enabled = False
        txtbapakkos.Text = ""
        txtbapakkos.Enabled = False
        txtjaraksiswa.Text = ""
        txtjaraksiswa.Enabled = False
    End Sub

    Private Sub txtnoinduk_TextChanged(sender As Object, e As EventArgs) Handles txtnoinduk.TextChanged

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

    Private Sub frmArsipTempatSiswa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
        Call clear()
    End Sub
End Class
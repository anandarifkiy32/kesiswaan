Imports Oracle.DataAccess.Client
Public Class frmArsipDataWali
    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet

    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        If txtnoinduk.Text = "" Then
            MsgBox("No Induk Tidak boleh kosong", vbOKOnly + vbInformation, "Perhatian")
            txtnoinduk.Select()
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

        Dim penghasilan As Double = Convert.ToDouble(Val(txtpenghasilan.Text))

        If mainform.DataGridSiswa.RowCount = 1 Then
            cmd = New OracleCommand("insert into kesiswaan.siswa (NO_INDUK, NAMA_WALI, TEMPAT_WALI, TGL_LAHIR_WALI, AGAMA_WALI, KWRG_WALI, PENDIDIKAN_WALI, PEKERJAAN_WALI, PENGHASILAN_WALI, ALAMAT_RUMAH_WALI, TELP_RUMAH_WALI, ALAMAT_KANTOR_WALI, TELP_KANTOR_WALI) values ('" + txtnoinduk.Text + "','" + txtnamawali.Text + "','" + txttempatlahir.Text + "','" + dtplahirwali.Value.ToShortDateString + "','" + cboagama.Text + "','" + txtwn.Text + "','" + txtpd.Text + "','" + txtpekerjaan.Text + "'," & penghasilan & ",'" + txtalamatrumah.Text + "','" + txttelprumah.Text + "','" + txtalamatkantor.Text + "','" + txttelpkantor.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.siswa Set NAMA_WALI='" + txtnamawali.Text + "', TEMPAT_WALI='" + txttempatlahir.Text + "',TGL_LAHIR_WALI='" + dtplahirwali.Value.ToShortDateString + "',AGAMA_WALI='" + cboagama.Text + "', KWRG_WALI='" + txtwn.Text + "', PENDIDIKAN_WALI='" + txtpd.Text + "',PEKERJAAN_WALI='" + txtpekerjaan.Text + "',PENGHASILAN_WALI=" & penghasilan & ", ALAMAT_RUMAH_WALI='" + txtalamatrumah.Text + "', TELP_RUMAH_WALI='" + txttelprumah.Text + "', ALAMAT_KANTOR_WALI='" + txtalamatkantor.Text + "', TELP_KANTOR_WALI='" + txttelpkantor.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatasiswa()
                mainform.DataGridSiswa.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If

    End Sub

    Public Sub tampildatasiswa()
        Dim sql As String = "select * from kesiswaan.siswa"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
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

    Private Sub frmArsipDataIbu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
    End Sub

    Private Sub txtpenghasilan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpenghasilan.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
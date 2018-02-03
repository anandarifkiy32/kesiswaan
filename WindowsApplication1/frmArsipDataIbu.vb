Imports Oracle.DataAccess.Client
Public Class frmArsipDataIbu
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
            cmd = New OracleCommand("insert into kesiswaan.siswa (NO_INDUK, NAMA_IBU, TEMPAT_IBU, TGL_LAHIR_IBU, AGAMA_IBU, KWRG_IBU, PENDIDIKAN_IBU, PEKERJAAN_IBU, PENGHASILAN_IBU, ALAMAT_RUMAH_IBU, TELP_RUMAH_IBU, ALAMAT_KANTOR_IBU, TELP_KANTOR_IBU) values ('" + txtnoinduk.Text + "','" + txtnamaibu.Text + "','" + txttempatlahir.Text + "', TO_DATE ('" + dtplahiribu.Value.ToShortDateString + "','DD/MM/YY'),'" + cboagama.Text + "','" + txtwn.Text + "','" + txtpd.Text + "','" + txtpekerjaan.Text + "'," & penghasilan & ",'" + txtalamatrumah.Text + "','" + txttelprumah.Text + "','" + txtalamatkantor.Text + "','" + txttelpkantor.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.siswa Set NAMA_IBU='" + txtnamaibu.Text + "', TEMPAT_IBU='" + txttempatlahir.Text + "',TGL_LAHIR_IBU= TO_DATE ('" + dtplahiribu.Value.ToShortDateString + "', 'DD/MM/YY'), AGAMA_IBU='" + cboagama.Text + "', KWRG_IBU='" + txtwn.Text + "', PENDIDIKAN_IBU='" + txtpd.Text + "',PEKERJAAN_IBU='" + txtpekerjaan.Text + "',PENGHASILAN_IBU=" & penghasilan & ", ALAMAT_RUMAH_IBU='" + txtalamatrumah.Text + "', TELP_RUMAH_IBU='" + txttelprumah.Text + "', ALAMAT_KANTOR_IBU='" + txtalamatkantor.Text + "', TELP_KANTOR_IBU='" + txttelpkantor.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatasiswa()
                mainform.DataGridSiswa.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
        Call clear()
    End Sub

    Public Sub clear()
        txtalamatkantor.Text = ""
        txtalamatrumah.Text = ""
        txtnamaibu.Text = ""
        txtnoinduk.Text = ""
        txtpd.Text = ""
        txtpekerjaan.Text = ""
        txtpenghasilan.Text = ""
        txttelpkantor.Text = ""
        txttelprumah.Text = ""
        txttempatlahir.Text = ""
        txtwn.Text = ""
        dtplahiribu.Value = Date.Now
        cboagama.ResetText()
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

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clear()
    End Sub
End Class
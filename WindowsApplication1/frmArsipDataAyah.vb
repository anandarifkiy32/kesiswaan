Imports Oracle.DataAccess.Client
Public Class frmArsipDataAyah

    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
            cmd = New OracleCommand("insert into kesiswaan.siswa (NO_INDUK, NAMA_AYAH, TEMPAT_AYAH, TGL_LAHIR_AYAH, AGAMA_AYAH, KWRG_AYAH, PENDIDIKAN_AYAH, PEKERJAAN_AYAH, PENGHASILAN_AYAH, ALAMAT_RUMAH_AYAH, TELP_RUMAH_AYAH, ALAMAT_KANTOR_AYAH, TELP_KANTOR_AYAH) values ('" + txtnoinduk.Text + "','" + txtnamaayah.Text + "','" + txttempatlahir.Text + "', TO_DATE ('" + dtptglhrayah.Value.ToShortDateString + "', 'DD/MM//YY'),'" + cboagamaayah.Text + "','" + txtwn.Text + "','" + txtpdayah.Text + "','" + txtpekerjaan.Text + "'," & penghasilan & ",'" + txtalamatrumah.Text + "','" + txttelprumah.Text + "','" + txtalamatkantor.Text + "','" + txttelpkantor.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.siswa Set NAMA_AYAH='" + txtnamaayah.Text + "', TEMPAT_AYAH='" + txttempatlahir.Text + "',TGL_LAHIR_AYAH = TO_DATE ('" + dtptglhrayah.Value.ToShortDateString + "', 'DD/MM/YY') ,AGAMA_AYAH='" + cboagamaayah.Text + "', KWRG_AYAH='" + txtwn.Text + "', PENDIDIKAN_AYAH='" + txtpdayah.Text + "',PEKERJAAN_AYAH='" + txtpekerjaan.Text + "',PENGHASILAN_AYAH=" & penghasilan & ", ALAMAT_RUMAH_AYAH='" + txtalamatrumah.Text + "', TELP_RUMAH_AYAH='" + txttelprumah.Text + "', ALAMAT_KANTOR_AYAH='" + txtalamatkantor.Text + "', TELP_KANTOR_AYAH='" + txttelpkantor.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
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
        txtnoinduk.Text = ""
        txtpdayah.Text = ""
        txtalamatkantor.Text = ""
        dtptglhrayah.Value = Date.Now
        txtalamatrumah.Text = ""
        txtnamaayah.Text = ""
        txtwn.Text = ""
        txttempatlahir.Text = ""
        txttelprumah.Text = ""
        txttelpkantor.Text = ""
        txtpenghasilan.Text = ""
        txtpekerjaan.Text = ""
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

    Private Sub frmArsipDataAyah_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
    End Sub

    Private Sub txtpenghasilan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpenghasilan.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub


End Class
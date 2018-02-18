Imports Oracle.DataAccess.Client
Public Class frmArsipDataWali
    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet

    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            cmd = New OracleCommand("insert into kesiswaan.siswa (NO_INDUK, NAMA_WALI, TEMPAT_WALI, TGL_LAHIR_WALI, AGAMA_WALI, KWRG_WALI, PENDIDIKAN_WALI, PEKERJAAN_WALI, PENGHASILAN_WALI, ALAMAT_RUMAH_WALI, TELP_RUMAH_WALI, ALAMAT_KANTOR_WALI, TELP_KANTOR_WALI) values ('" + txtnoinduk.Text + "','" + txtnamawali.Text + "','" + txttempatlahir.Text + "',TO_DATE ('" + dtplahirwali.Value.ToShortDateString + "', 'DD/MM/YY'),'" + cboagama.Text + "','" + txtwn.Text + "','" + txtpd.Text + "','" + txtpekerjaan.Text + "'," & penghasilan & ",'" + txtalamatrumah.Text + "','" + txttelprumah.Text + "','" + txtalamatkantor.Text + "','" + txttelpkantor.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.siswa Set NAMA_WALI='" + txtnamawali.Text + "', TEMPAT_WALI='" + txttempatlahir.Text + "',TGL_LAHIR_WALI=TO_DATE ('" + dtplahirwali.Value.ToShortDateString + "', 'DD/MM/YY'),AGAMA_WALI='" + cboagama.Text + "', KWRG_WALI='" + txtwn.Text + "', PENDIDIKAN_WALI='" + txtpd.Text + "',PEKERJAAN_WALI='" + txtpekerjaan.Text + "',PENGHASILAN_WALI=" & penghasilan & ", ALAMAT_RUMAH_WALI='" + txtalamatrumah.Text + "', TELP_RUMAH_WALI='" + txttelprumah.Text + "', ALAMAT_KANTOR_WALI='" + txtalamatkantor.Text + "', TELP_KANTOR_WALI='" + txttelpkantor.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatasiswa()
                mainform.DataGridSiswa.DataSource = ds.Tables(0)
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
        Call clear()
        conn.Close()
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
        Call clear()
    End Sub

    Private Sub txtpenghasilan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpenghasilan.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub clear()
        txtalamatkantor.Text = ""
        txtalamatkantor.Enabled = False
        txtalamatrumah.Text = ""
        txtalamatrumah.Enabled = False
        txtnamawali.Text = ""
        txtnamawali.Enabled = False
        txtnoinduk.Enabled = True
        txtnoinduk.Focus()
        txtpd.Text = ""
        txtpd.Enabled = False
        txtpekerjaan.Text = ""
        txtpekerjaan.Enabled = False
        txtpenghasilan.Text = ""
        txtpenghasilan.Enabled = False
        txttelpkantor.Text = ""
        txttelpkantor.Enabled = False
        txttelprumah.Text = ""
        txttelprumah.Enabled = False
        txttempatlahir.Text = ""
        txttempatlahir.Enabled = False
        txtwn.Text = ""
        txtwn.Enabled = False
        Button2.Enabled = False
        cboagama.ResetText()
        cboagama.Enabled = False
        dtplahirwali.Value = Date.Now
        dtplahirwali.Enabled = False
        txtnoinduk.Text = ""

    End Sub
    Private Sub input()
        txtalamatkantor.Enabled = True
        txtalamatrumah.Enabled = True
        txtnamawali.Enabled = True
        txtnoinduk.Enabled = False
        txtpd.Enabled = True
        txtpekerjaan.Enabled = True
        txtpenghasilan.Enabled = True
        txttelpkantor.Enabled = True
        txttelprumah.Enabled = True
        txttempatlahir.Enabled = True
        txtwn.Enabled = True
        Button2.Enabled = True
        dtplahirwali.Enabled = True
        cboagama.Enabled = True
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

                If IsDBNull(dr.Item(53)) Then
                    txtnamawali.Text = ""
                Else
                    txtnamawali.Text = dr.Item(53)
                End If

                If IsDBNull(dr.Item(54)) Then
                    txttempatlahir.Text = ""
                Else
                    txttempatlahir.Text = dr.Item(54)
                End If

                If IsDBNull(dr.Item(55)) Then
                    dtplahirwali.Value = Date.Now
                Else
                    dtplahirwali.Value = dr.Item(55)
                End If

                If IsDBNull(dr.Item(56)) Then
                    cboagama.Text = ""
                Else
                    cboagama.Text = dr.Item(56)
                End If

                If IsDBNull(dr.Item(57)) Then
                    txtwn.Text = ""
                Else
                    txtwn.Text = dr.Item(57)
                End If

                If IsDBNull(dr.Item(58)) Then
                    txtpd.Text = ""
                Else
                    txtpd.Text = dr.Item(58)
                End If

                If IsDBNull(dr.Item(59)) Then
                    txtpekerjaan.Text = ""
                Else
                    txtpekerjaan.Text = dr.Item(59)
                End If

                If IsDBNull(dr.Item(60)) Then
                    txtpenghasilan.Text = ""
                Else
                    txtpenghasilan.Text = dr.Item(60)
                End If

                If IsDBNull(dr.Item(61)) Then
                    txtalamatrumah.Text = ""
                Else
                    txtalamatrumah.Text = dr.Item(61)
                End If

                If IsDBNull(dr.Item(62)) Then
                    txttelprumah.Text = ""
                Else
                    txttelprumah.Text = dr.Item(62)
                End If

                If IsDBNull(dr.Item(63)) Then
                    txtalamatkantor.Text = ""
                Else
                    txtalamatkantor.Text = dr.Item(63)
                End If

                If IsDBNull(dr.Item(64)) Then
                    txttelpkantor.Text = ""
                Else
                    txttelpkantor.Text = dr.Item(64)
                End If
            End If
            conn.Close()
        End If
    End Sub
End Class
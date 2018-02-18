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
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            cmd = New OracleCommand("Update kesiswaan.siswa Set NAMA_IBU='" + txtnamaibu.Text + "', TEMPAT_IBU='" + txttempatlahir.Text + "',TGL_LAHIR_IBU= TO_DATE ('" + dtplahiribu.Value.ToShortDateString + "', 'DD/MM/YY'), AGAMA_IBU='" + cboagama.Text + "', KWRG_IBU='" + txtwn.Text + "', PENDIDIKAN_IBU='" + txtpd.Text + "',PEKERJAAN_IBU='" + txtpekerjaan.Text + "',PENGHASILAN_IBU=" & penghasilan & ", ALAMAT_RUMAH_IBU='" + txtalamatrumah.Text + "', TELP_RUMAH_IBU='" + txttelprumah.Text + "', ALAMAT_KANTOR_IBU='" + txtalamatkantor.Text + "', TELP_KANTOR_IBU='" + txttelpkantor.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
        End If
        Call clear()
        conn.Close()
    End Sub

    Public Sub clear()
        txtalamatkantor.Text = ""
        txtalamatkantor.Enabled = False
        txtalamatrumah.Text = ""
        txtalamatrumah.Enabled = False
        txtnamaibu.Text = ""
        txtnamaibu.Enabled = False
        txtnoinduk.Text = ""
        txtnoinduk.Enabled = False
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
        dtplahiribu.Value = Date.Now
        dtplahiribu.Enabled = False
        cboagama.ResetText()
        cboagama.Enabled = False
        txtnoinduk.Enabled = True
        txtnoinduk.Focus()
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

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clear()
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
                Call Input()
            Else
                Call Input()

                If IsDBNull(dr.Item(41)) Then
                    txtnamaibu.Text = ""
                Else
                    txtnamaibu.Text = dr.Item(41)
                End If

                If IsDBNull(dr.Item(42)) Then
                    txttempatlahir.Text = ""
                Else
                    txttempatlahir.Text = dr.Item(42)
                End If

                If IsDBNull(dr.Item(43)) Then
                    dtplahiribu.Value = Date.Now
                Else
                    dtplahiribu.Value = dr.Item(43)
                End If

                If IsDBNull(dr.Item(44)) Then
                    cboagama.Text = ""
                Else
                    cboagama.Text = dr.Item(44)
                End If

                If IsDBNull(dr.Item(45)) Then
                    txtwn.Text = ""
                Else
                    txtwn.Text = dr.Item(45)
                End If

                If IsDBNull(dr.Item(46)) Then
                    txtpd.Text = ""
                Else
                    txtpd.Text = dr.Item(46)
                End If

                If IsDBNull(dr.Item(47)) Then
                    txtpekerjaan.Text = ""
                Else
                    txtpekerjaan.Text = dr.Item(47)
                End If

                If IsDBNull(dr.Item(48)) Then
                    txtpenghasilan.Text = ""
                Else
                    txtpenghasilan.Text = dr.Item(48)
                End If

                If IsDBNull(dr.Item(49)) Then
                    txtalamatrumah.Text = ""
                Else
                    txtalamatrumah.Text = dr.Item(49)
                End If

                If IsDBNull(dr.Item(50)) Then
                    txttelprumah.Text = ""
                Else
                    txttelprumah.Text = dr.Item(50)
                End If

                If IsDBNull(dr.Item(51)) Then
                    txtalamatkantor.Text = ""
                Else
                    txtalamatkantor.Text = dr.Item(51)
                End If

                If IsDBNull(dr.Item(52)) Then
                    txttelpkantor.Text = ""
                Else
                    txttelpkantor.Text = dr.Item(52)
                End If
            End If
            conn.Close()
        End If
    End Sub

    Private Sub input()
        txtalamatkantor.Enabled = True
        txtalamatrumah.Enabled = True
        txtnamaibu.Enabled = True
        txtnoinduk.Enabled = True
        txtpd.Enabled = True
        txtpekerjaan.Enabled = True
        txtpenghasilan.Enabled = True
        txttelpkantor.Enabled = True
        txttelprumah.Enabled = True
        txttempatlahir.Enabled = True
        txtwn.Enabled = True
        dtplahiribu.Enabled = True
        cboagama.Enabled = True
        txtnoinduk.Enabled = False
    End Sub
End Class
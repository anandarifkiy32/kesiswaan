Imports Oracle.DataAccess.Client
Public Class frmArsipDataAyah

    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btninpsiswa.Click
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
        conn.Close()
        Call clear()
    End Sub

    Public Sub clear()
        txtnoinduk.Text = ""
        txtpdayah.Text = ""
        txtpdayah.Enabled = False
        txtalamatkantor.Text = ""
        txtalamatkantor.Enabled = False
        dtptglhrayah.Value = Date.Now
        dtptglhrayah.Enabled = False
        txtalamatrumah.Text = ""
        txtalamatrumah.Enabled = False
        txtnamaayah.Text = ""
        txtnamaayah.Enabled = False
        txtwn.Text = ""
        txtwn.Enabled = False
        txttempatlahir.Text = ""
        txttempatlahir.Enabled = False
        txttelprumah.Text = ""
        txttelprumah.Enabled = False
        txttelpkantor.Text = ""
        txttelpkantor.Enabled = False
        txtpenghasilan.Text = ""
        txtpenghasilan.Enabled = False
        txtpekerjaan.Text = ""
        txtpekerjaan.Enabled = False
        cboagamaayah.Enabled = False
        btninpsiswa.Enabled = False
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

    Private Sub frmArsipDataAyah_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
        Call clear()
    End Sub

    Private Sub txtpenghasilan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpenghasilan.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub txtnoinduk_TextChanged(sender As Object, e As EventArgs) Handles txtnoinduk.TextChanged

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

                If IsDBNull(dr.Item(29)) Then
                    txtnamaayah.Text = ""
                Else
                    txtnamaayah.Text = dr.Item(29)
                End If

                If IsDBNull(dr.Item(30)) Then
                    txttempatlahir.Text = ""
                Else
                    txttempatlahir.Text = dr.Item(30)
                End If

                If IsDBNull(dr.Item(31)) Then
                    dtptglhrayah.Value = Date.Now
                Else
                    dtptglhrayah.Value = dr.Item(31)
                End If

                If IsDBNull(dr.Item(32)) Then
                    cboagamaayah.Text = ""
                Else
                    cboagamaayah.Text = dr.Item(32)
                End If

                If IsDBNull(dr.Item(33)) Then
                    txtwn.Text = ""
                Else
                    txtwn.Text = dr.Item(33)
                End If

                If IsDBNull(dr.Item(34)) Then
                    txtpdayah.Text = ""
                Else
                    txtpdayah.Text = dr.Item(34)
                End If

                If IsDBNull(dr.Item(35)) Then
                    txtpekerjaan.Text = ""
                Else
                    txtpekerjaan.Text = dr.Item(35)
                End If

                If IsDBNull(dr.Item(36)) Then
                    txtpenghasilan.Text = ""
                Else
                    txtpenghasilan.Text = dr.Item(36)
                End If

                If IsDBNull(dr.Item(37)) Then
                    txtalamatrumah.Text = ""
                Else
                    txtalamatrumah.Text = dr.Item(37)
                End If

                If IsDBNull(dr.Item(38)) Then
                    txttelprumah.Text = ""
                Else
                    txttelprumah.Text = dr.Item(38)
                End If

                If IsDBNull(dr.Item(39)) Then
                    txtalamatkantor.Text = ""
                Else
                    txtalamatkantor.Text = dr.Item(39)
                End If

                If IsDBNull(dr.Item(40)) Then
                    txttelpkantor.Text = ""
                Else
                    txttelpkantor.Text = dr.Item(40)
                End If
            End If
            conn.Close()
        End If
    End Sub

    Private Sub input()
        txtalamatkantor.Enabled = True
        txtalamatrumah.Enabled = True
        txtnamaayah.Enabled = True
        txtpdayah.Enabled = True
        txtpekerjaan.Enabled = True
        txtpenghasilan.Enabled = True
        txttelpkantor.Enabled = True
        txttelprumah.Enabled = True
        txttempatlahir.Enabled = True
        txtwn.Enabled = True
        cboagamaayah.Enabled = True
        dtptglhrayah.Enabled = True
        btninpsiswa.Enabled = True
        txtnoinduk.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clear()
    End Sub
End Class
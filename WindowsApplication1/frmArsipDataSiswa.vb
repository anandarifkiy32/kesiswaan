Imports Oracle.DataAccess.Client
Imports System
Public Class frmArsipDataSiswa

    Public conn As New OracleConnection
    Public cmd1, cmd2 As New OracleCommand
    Public da, dac As OracleDataAdapter
    Public cb, cbc As OracleCommandBuilder
    Public ds, dsc As DataSet
    Public jenkel As String
    Public anake, kandung, tiri, angkat As Double

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call tampildatasiswa()
        mainform.DataGridSiswa.DataSource = ds.Tables(0)
        Close()
    End Sub

    Private Sub btninpsiswa_Click_1(sender As Object, e As EventArgs) Handles btninpsiswa.Click

        If txtinpid.Text = "" Then
            MsgBox("Nomor induk tidak boleh kosong", vbInformation, "Perhatian")
            txtinpid.Focus()
            Exit Sub
        End If

        If txtinpnama.Text = "" Then
            MsgBox("Nama tidak boleh kosong", vbInformation, "Perhatian")
            txtinpnama.Focus()
            Exit Sub
        End If

        cmd1.Connection = conn
        conn.Open()
        Dim cari As String = "select * from kesiswaan.siswa where NO_INDUK = '" + txtinpid.Text + "'"
        cmd1 = New OracleCommand(cari, conn)
        cmd1.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd1.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd1)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        mainform.DataGridSiswa.DataSource = ds.Tables(0)

        anake = Convert.ToDouble(Val(cboanake.Text))
        kandung = Convert.ToDouble(Val(cbojmlkandung.Text))
        tiri = Convert.ToDouble(Val(cbojmltiri.Text))
        angkat = Convert.ToDouble(Val(cbojmlangkat.Text))

        If rdbtnlaki.Checked = True Then
            jenkel = "L"
        ElseIf rdbtnperempuan.Checked = True Then
            jenkel = "P"
        End If

        Dim lahirhari As String = dtpinptglhr.Value.Day.ToString
        Dim lahirbulan As String = MonthName(dtpinptglhr.Value.Month, True)

        Dim lahirtahun As String = dtpinptglhr.Value.Year.ToString
        Dim tgl_lahir As String = "'" + lahirhari + "-" + lahirbulan + "-" + lahirtahun + "'"

        If mainform.DataGridSiswa.RowCount = 1 Then
            cmd1 = New OracleCommand("insert into kesiswaan.siswa( NO_INDUK, NAMA_SISWA, PANGGILAN, JK, TEMPAT,
                                    TGL_LHR, AGAMA, KWRG, ANAK_KE, JML_KANDUNG, JML_TIRI, JML_ANGKAT, BAHASA, 
                                    TGL_TERIMA, ANGKATAN, GOL_DARAH_SISWA, BERAT_SISWA, TINGGI_SISWA, PENYAKIT ) values ('" + txtinpid.Text + "','" + txtinpnama.Text +
                                    "','" + txtpanggilan.Text + "','" + jenkel + "','" + txttmptlahir.Text +
                                    "', TO_DATE ('" + dtpinptglhr.Value.ToShortDateString + "','DD/MM/YY'),'" + cboagamasiswa.Text +
                                    "','" + txtwarganegara.Text + "'," & anake & "," & kandung & "," & tiri &
                                    "," & angkat & ",'" + txtbahasa.Text + "', TO_DATE ('" + dtptglterima.Value.ToShortDateString + "','DD/MM/YY'), '" + txtangkatan.Text + "','" + cbogoldar.Text + "','" + txtberat.Text + "','" + txttinggi.Text + "','" + txtpenyakit.Text + "')", conn)
            cmd2 = New OracleCommand("insert into kesiswaan.kelas (NO_INDUK,KELAS,TA) VALUES ('" + txtinpid.Text + "','" + cbokelas.Text + "','" + cbota.Text + "')", conn)

            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            cmd1 = New OracleCommand("Update kesiswaan.siswa set NAMA_SISWA='" + txtinpnama.Text + "', PANGGILAN='" +
                                    txtpanggilan.Text + "', JK='" + jenkel + "', TEMPAT='" + txttmptlahir.Text + "',
                                    TGL_LHR= TO_DATE('" + dtpinptglhr.Value.ToShortDateString + "','DD/MM/YY'), AGAMA='" + cboagamasiswa.Text +
                                    "', KWRG='" + txtwarganegara.Text + "', ANAK_KE=" & anake & ", JML_KANDUNG=" & kandung &
                                    ", JML_TIRI=" & tiri & ", JML_ANGKAT=" & angkat & ", BAHASA='" + txtbahasa.Text + "', TGL_TERIMA= TO_DATE('" + dtptglterima.Value.ToShortDateString + "','DD/MM/YY'), ANGKATAN='" + txtangkatan.Text + "', GOL_DARAH_SISWA='" + cbogoldar.Text + "', BERAT_SISWA='" + txtberat.Text + "', TINGGI_SISWA='" + txttinggi.Text + "',PENYAKIT='" + txtpenyakit.Text + "' where NO_INDUK='" + txtinpid.Text + "'", conn)
            cmd2 = New OracleCommand("Update kesiswaan.kelas set KELAS='" + cbokelas.Text + "', TA='" + cbota.Text + "' where NO_INDUK='" + txtinpid.Text + "'", conn)
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
                conn.Close()
            MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
        End If
        Call clean()
    End Sub

    Private Sub txtberat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtberat.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub txttinggi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttinggi.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Public Sub tampildatasiswa()
        Dim sql As String = "select * from kesiswaan.siswa order by no_induk asc"
        cmd1 = New OracleCommand(sql, conn)
        cmd1.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd1)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
    End Sub

    Private Sub btncancel_Click_1(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clean()
        Call tampildatasiswa()
        mainform.DataGridSiswa.DataSource = ds.Tables(0)
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

    Public Sub clean()
        txtinpid.Text = ""
        txtinpnama.Text = ""
        cbota.Text = ""
        cbota.Enabled = False
        txtinpnama.Enabled = False
        txtpanggilan.Text = ""
        txtpanggilan.Enabled = False
        rdbtnlaki.Checked = False
        rdbtnlaki.Enabled = False
        rdbtnperempuan.Checked = False
        rdbtnperempuan.Enabled = False
        dtpinptglhr.Value = Now
        dtpinptglhr.Enabled = False
        cbojmlangkat.Text = ""
        cbojmlangkat.Enabled = False
        cboanake.Text = ""
        cboanake.Enabled = False
        cbojmlkandung.Text = ""
        cbojmlkandung.Enabled = False
        cbojmltiri.Text = ""
        cbojmltiri.Enabled = False
        txtbahasa.Text = ""
        txtbahasa.Enabled = False
        dtptglterima.Value = Now
        dtptglterima.Enabled = False
        txtangkatan.Text = ""
        txtangkatan.Enabled = False
        txttmptlahir.Text = ""
        txttmptlahir.Enabled = False
        txtwarganegara.Text = ""
        txtwarganegara.Enabled = False
        txttinggi.Text = ""
        txttinggi.Enabled = False
        txtberat.Text = ""
        txtberat.Enabled = False
        txtpenyakit.Text = ""
        txtpenyakit.Enabled = False
        cbogoldar.ResetText()
        cbogoldar.Enabled = False
        cboagamasiswa.ResetText()
        cboagamasiswa.Enabled = False
        cbokelas.Text = ""
        cbokelas.Enabled = False
        btndelete.Enabled = False

    End Sub

    Private Sub frmArsipDataSiswa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
        Call tampildatasiswa()
        With cboagamasiswa
            .Items.Add("ISLAM")
            .Items.Add("PROTESTAN")
            .Items.Add("KATHOLIK")
            .Items.Add("BUDHA")
            .Items.Add("HINDU")
        End With
        txtinpid.Select()
        Call clean()
        Call load_cbokelas()
        Call load_cbota()
    End Sub

    Private Sub load_cbota()
        Dim tahun As Integer = Date.Now.Year
        Dim awal As Integer
        Dim akhir = tahun + 5
        Dim ta As String
        For awal = tahun - 5 To akhir
            akhir = awal + 1
            ta = awal.ToString + "/" + akhir.ToString
            cbota.Items.Add(ta)
        Next
    End Sub
    Public Sub load_cbokelas()
        Dim i As Integer
        i = mainform.datagridkelas.RowCount
        Dim maxrow As Integer = i - 2
        Dim row As Integer
        Dim value As Object
        For row = 0 To maxrow
            value = mainform.datagridkelas.Item(0, row).Value
            cbokelas.Items.Remove(value)
        Next
        For row = 0 To maxrow
            value = mainform.datagridkelas.Item(0, row).Value
            cbokelas.Items.Add(value)
        Next
    End Sub

    Private Sub txtangkatan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtangkatan.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboanake_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboanake.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbojmlkandung_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbojmlkandung.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbojmltiri_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbojmltiri.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If MsgBox("Hapus Data?", vbOKCancel + vbInformation, "Perhatian") = vbOK Then
            conn.Open()
            cmd1 = New OracleCommand("delete from kelas where no_induk = '" + txtinpid.Text + "'", conn)
            cmd2 = New OracleCommand("delete from siswa where no_induk = '" + txtinpid.Text + "'", conn)
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Berhasil", vbInformation, "Pehatian")
            Call clean()
        End If
    End Sub

    Private Sub cbojmlangkat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbojmlangkat.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbojmltiri_LostFocus(sender As Object, e As EventArgs) Handles cbojmltiri.LostFocus
        If cbojmltiri.Text = "" Then
            cbojmltiri.Text = 0
        End If
    End Sub

    Private Sub cboanake_LostFocus(sender As Object, e As EventArgs) Handles cboanake.LostFocus
        If cboanake.Text = "" Then
            cboanake.Text = 0
        End If
    End Sub

    Private Sub cbojmlkandung_LostFocus(sender As Object, e As EventArgs) Handles cbojmlkandung.LostFocus
        If cbojmlkandung.Text = "" Then
            cbojmlkandung.Text = 0
        End If
    End Sub

    Private Sub cbojmlangkat_LostFocus(sender As Object, e As EventArgs) Handles cbojmlangkat.LostFocus
        If cbojmlangkat.Text = "" Then
            cbojmlangkat.Text = 0
        End If
    End Sub

    Private Sub txtinpid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtinpid.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim query As String = "select * from kesiswaan.siswa where no_induk = '" + txtinpid.Text + "'"
            Dim query2 As String = "select * from kesiswaan.kelas where no_induk = '" + txtinpid.Text + "'"

            conn.Open()

            cmd2 = New OracleCommand(query2, conn)
            cmd1 = New OracleCommand(query, conn)
            cmd2.CommandType = CommandType.Text
            cmd1.CommandType = CommandType.Text

            Dim dr2 As OracleDataReader = cmd2.ExecuteReader()
            Dim dr As OracleDataReader = cmd1.ExecuteReader()
            dr.Read()
            dr2.Read()

            da = New OracleDataAdapter(cmd1)
            cb = New OracleCommandBuilder(da)
            ds = New DataSet()
            da.Fill(ds)

            dac = New OracleDataAdapter(cmd2)
            cbc = New OracleCommandBuilder(dac)
            dsc = New DataSet()
            dac.Fill(dsc)

            mainform.DataGridSiswa.DataSource = ds.Tables(0)

            If mainform.DataGridSiswa.RowCount = 1 Then
                Call input()
            Else
                Call input()

                If IsDBNull(dr.Item(1)) Then
                    txtinpnama.Text = ""
                Else
                    txtinpnama.Text = dr.Item(1)
                End If

                If IsDBNull(dr.Item(2)) Then
                    txtpanggilan.Text = ""
                Else
                    txtpanggilan.Text = dr.Item(2)
                End If

                If IsDBNull(dr.Item(3)) Then
                    rdbtnlaki.Checked = False
                    rdbtnperempuan.Checked = False
                Else
                    If dr.Item(3) = "L" Then
                        rdbtnlaki.Checked = True
                    Else
                        rdbtnperempuan.Checked = True
                    End If
                End If

                If IsDBNull(dr.Item(4)) Then
                    txttmptlahir.Text = ""
                Else
                    txttmptlahir.Text = dr.Item(4)
                End If

                If IsDBNull(dr2.Item(1)) Then
                    cbokelas.Text = ""
                Else
                    cbokelas.Text = dr2.Item(1)
                End If

                If IsDBNull(dr2.Item(3)) Then
                    cbota.Text = ""
                Else
                    cbota.Text = dr2.Item(3)
                End If

                If IsDBNull(dr.Item(5)) Then
                    dtpinptglhr.Value = ""
                Else
                    dtpinptglhr.Value = dr.Item(5)
                End If

                If IsDBNull(dr.Item(6)) Then
                    cboagamasiswa.Text = ""
                Else
                    cboagamasiswa.Text = dr.Item(6)
                End If

                If IsDBNull(dr.Item(7)) Then
                    txtwarganegara.Text = ""
                Else
                    txtwarganegara.Text = dr.Item(7)
                End If

                If IsDBNull(dr.Item(8)) Then
                    cboanake.Text = ""
                Else
                    cboanake.Text = dr.Item(8)
                End If

                If IsDBNull(dr.Item(9)) Then
                    cbojmlkandung.Text = ""
                Else
                    cbojmlkandung.Text = dr.Item(9)
                End If

                If IsDBNull(dr.Item(10)) Then
                    cbojmltiri.Text = ""
                Else
                    cbojmltiri.Text = dr.Item(10)
                End If

                If IsDBNull(dr.Item(11)) Then
                    cbojmlangkat.Text = ""
                Else
                    cbojmlangkat.Text = dr.Item(11)
                End If

                If IsDBNull(dr.Item(12)) Then
                    txtbahasa.Text = ""
                Else
                    txtbahasa.Text = dr.Item(12)
                End If

                If IsDBNull(dr.Item(13)) Then
                    dtptglterima.Value = ""
                Else
                    dtptglterima.Value = dr.Item(13)
                End If

                If IsDBNull(dr.Item(14)) Then
                    txtangkatan.Text = ""
                Else
                    txtangkatan.Text = dr.Item(14)
                End If

                If IsDBNull(dr.Item(21)) Then
                    cbogoldar.Text = ""
                Else
                    cbogoldar.Text = dr.Item(21)
                End If

                If IsDBNull(dr.Item(23)) Then
                    txtberat.Text = ""
                Else
                    txtberat.Text = dr.Item(23)
                End If

                If IsDBNull(dr.Item(22)) Then
                    txttinggi.Text = ""
                Else
                    txttinggi.Text = dr.Item(22)
                End If

                If IsDBNull(dr.Item(24)) Then
                    txtpenyakit.Text = ""
                Else
                    txtpenyakit.Text = dr.Item(24)
                End If

                btndelete.Enabled = True

            End If
            conn.Close()
        End If
    End Sub

    Public Sub input()
        cbota.Enabled = True
        txtinpnama.Enabled = True
        txtinpnama.Text = ""
        txtpanggilan.Enabled = True
        txtpanggilan.Text = ""
        rdbtnlaki.Enabled = True
        rdbtnlaki.Checked = False
        rdbtnperempuan.Enabled = True
        rdbtnperempuan.Checked = False
        dtpinptglhr.Enabled = True
        dtpinptglhr.Value = Date.Now
        cbojmlangkat.Enabled = True
        cbojmlangkat.Text = ""
        cboanake.Enabled = True
        cboanake.Text = ""
        cbojmlkandung.Enabled = True
        cbojmlkandung.Text = ""
        cbojmltiri.Enabled = True
        cbojmltiri.Text = ""
        txtbahasa.Enabled = True
        txtbahasa.Text = ""
        dtptglterima.Enabled = True
        dtptglterima.Value = Date.Now
        txtangkatan.Enabled = True
        txtangkatan.Text = ""
        txttmptlahir.Enabled = True
        txttmptlahir.Text = ""
        txtwarganegara.Enabled = True
        txtwarganegara.Text = ""
        txttinggi.Enabled = True
        txttinggi.Text = ""
        txtberat.Enabled = True
        txtberat.Text = ""
        txtpenyakit.Enabled = True
        txtpenyakit.Text = ""
        cbogoldar.Enabled = True
        cbogoldar.Text = ""
        cboagamasiswa.Enabled = True
        cboagamasiswa.Text = ""
        cbokelas.Enabled = True
        cbokelas.Text = ""
    End Sub

    Private Sub txtinpid_SystemColorsChanged(sender As Object, e As EventArgs) Handles txtinpid.SystemColorsChanged

    End Sub
End Class
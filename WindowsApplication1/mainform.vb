Imports Oracle.DataAccess.Client
Imports System
Public Class mainform
    Public conn As New OracleConnection
    Public cmd As OracleCommand
    Public da, dac As OracleDataAdapter
    Public cb, cbc As OracleCommandBuilder
    Public ds, dsc As DataSet
    Public jenkel As String
    Public anake, kandung, tiri, angkat As Double
    Public query As String

    Private Sub btnbakatsiswa_Click(sender As Object, e As EventArgs) Handles btnbakatsiswa.Click
        frmArsipBakatSiswa.Show()
    End Sub

    Private Sub btnKelas_Click(sender As Object, e As EventArgs)
        frmArsipDataAyah.Show()
    End Sub

    Private Sub btninputkelas_Click(sender As Object, e As EventArgs) Handles btninputkelas.Click
        If txtkelas.Text = "" Then
            MsgBox("Kelas tidak boleh kosong", vbOKOnly + vbInformation, "Perhatian")
            txtkelas.Select()
            Exit Sub
        End If

        cmd.Connection = conn
        conn.Open()
        Dim cari As String = "select * from kesiswaan.kelas_jurusan where KELAS = '" + txtkelas.Text + "'"
        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridkelas.DataSource = ds.Tables(0)

        If datagridkelas.RowCount = 1 Then
            cmd = New OracleCommand("insert into kesiswaan.kelas_jurusan(KELAS, KODE_PROGRAM) VALUES ('" + txtkelas.Text + "','" + cbokodeprogram.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildataKelas_Jurusan()
            datagridkelas.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Kelas Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.kelas_jurusan set KODE_PROGRAM='" + cbokodeprogram.Text + "' where KELAS='" + txtkelas.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildataKelas_Jurusan()
                datagridkelas.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
        Call clean_kelasjurusan()
        Call load_cbokelas()
    End Sub

    Private Sub btntempatsiswa_Click(sender As Object, e As EventArgs) Handles btntempatsiswa.Click
        frmArsipTempatSiswa.Show()
    End Sub

    Private Sub btninputjurusan_Click(sender As Object, e As EventArgs) Handles btninputjurusan.Click
        If txtkodeprogram.Text = "" Then
            MsgBox("Kode Program tidak boleh kosong", vbOKOnly + vbInformation, "Perhatian")
            txtkelas.Select()
            Exit Sub
        End If

        cmd.Connection = conn
        conn.Open()
        Dim cari As String = "select * from kesiswaan.JURUSAN where KODE_PROGRAM= '" + txtkodeprogram.Text + "'"
        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridjurusan.DataSource = ds.Tables(0)

        If datagridjurusan.RowCount = 1 Then
            cmd = New OracleCommand("insert into kesiswaan.JURUSAN (KODE_PROGRAM, NAMA_PROGRAM, BIDANG_KEAHLIAN) VALUES ('" + txtkodeprogram.Text + "','" + txtnamaprogram.Text + "','" + txtprogkeahlian.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildataJurusan()
            datagridjurusan.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Kelas Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.jurusan set NAMA_PROGRAM='" + txtnamaprogram.Text + "', BIDANG_KEAHLIAN='" + txtprogkeahlian.Text + "' where KODE_PROGRAM='" + txtkodeprogram.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildataJurusan()
                datagridjurusan.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
        Call load_cbojurusan()
        Call clean_jurusan()
    End Sub

    Public Sub clean_jurusan()
        txtkodeprogram.Text = ""
        txtnamaprogram.Text = ""
        txtprogkeahlian.Text = ""
    End Sub

    Private Sub btnarsipsiswa_Click(sender As Object, e As EventArgs) Handles btnarsipsiswa.Click
        frmArsipDataSiswa.Show()
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

    Private Sub btnarsipayah_Click(sender As Object, e As EventArgs) Handles btnarsipayah.Click
        frmArsipDataAyah.Show()
    End Sub

    Private Sub btnarsipibu_Click(sender As Object, e As EventArgs) Handles btnarsipibu.Click
        frmArsipDataIbu.Show()
    End Sub

    Private Sub btnarsipwali_Click(sender As Object, e As EventArgs) Handles btnarsipwali.Click
        frmArsipDataWali.Show()
    End Sub

    Private Sub btnarsipsmp_Click(sender As Object, e As EventArgs) Handles btnarsipsmp.Click
        frmDataSmpSiswa.Show()
    End Sub

    Private Sub btnkelas_Click_1(sender As Object, e As EventArgs)
        frmKelas.Show()
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click

        If chkkelas.Checked = True Then
            query = "select * from siswa,kelas where kelas.no_induk like siswa.no_induk"

            Dim noinduk As String = " and siswa.no_induk like '%" + carinoinduk.Text + "%'"
            Dim nama As String = " and siswa.nama_siswa like '%" + carinama.Text + "%'"
            Dim kelas As String = " and kelas.kelas like '%" + carikelas.Text + "%'"
            Dim tempatlahir As String = " and siswa.tempat like '%" + caritempatlahir.Text + "%'"
            Dim agama As String = " and siswa.agama like '%" + cariagama.Text + "%'"
            Dim angkatan As String = " and siswa.angkatan = " + cariangkatandari.Text
            Dim angkatansampai As String = " and siswa.angkatan >= " + cariangkatandari.Text + " and siswa.angkatan <= " + cariangkatansampai.Text
            Dim tinggi As String = " and siswa.tinggi_siswa = " + caritinggidari.Text
            Dim tinggisampai As String = " and siswa.tinggi_siswa >= " + caritinggidari.Text + " and siswa.tinggi_siswa <= " + caritinggisampai.Text
            Dim berat As String = " and siswa.berat_siswa = " + cariberatdari.Text
            Dim beratsmpai As String = " and siswa.berat_siswa >= " + cariberatdari.Text + " and siswa.berat_siswa <= " + cariberatsampai.Text
            Dim umur As String = " and siswa.umur_siswa = " + cariumurdari.Text
            Dim umursampai As String = " and siswa.umur_siswa >= " + cariumurdari.Text + " and siswa.umur_siswa <= " + cariumursampai.Text
            Dim tgl_lhr As String = "  and siswa.tgl_lhr = TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY')"
            Dim tgl_lhr_sampai As String = " and siswa.tgl_lhr between TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY') and TO_DATE ('" + caritgllhrsampai.Value.ToShortDateString + "', 'DD/MM/YY')"

            If chknoinduk.Checked = True Then
                query = query + noinduk
            End If

            If chknama.Checked = True Then
                query = query + nama
            End If

            If chkkelas.Checked = True Then
                query = query + kelas
            End If

            If chktempatlahir.Checked = True Then
                query = query + tempatlahir
            End If

            If chktgllhr.Checked = True Then
                If chktgllhrsampai.Checked = True Then
                    query = query + tgl_lhr_sampai
                Else
                    query = query + tgl_lhr
                End If

            End If

            If chkagama.Checked = True Then
                query = query + agama
            End If

            If chkangkatan.Checked = True Then
                If chkangkatansampai.Checked = True Then
                    query = query + angkatansampai
                Else
                    query = query + angkatan
                End If
            End If

            If chktinggi.Checked = True Then
                If chktinggisampai.Checked = True Then
                    query = query + tinggisampai
                Else
                    query = query + tinggi
                End If
            End If

            If chkberat.Checked = True Then
                If chkberatsampai.Checked = True Then
                    query = query + beratsmpai
                Else
                    query = query + berat
                End If
            End If

            If chkumur.Checked = True Then
                If chkumursampai.Checked = True Then
                    query = query + umursampai
                Else
                    query = query + umur
                End If
            End If

            query = query + " order by siswa.no_induk asc"
        Else
            query = "select * from siswa where no_induk = no_induk"
            Dim noinduk As String = " and siswa.no_induk like '%" + carinoinduk.Text + "%'"
            Dim nama As String = " and siswa.nama_siswa like '%" + carinama.Text + "%'"
            Dim tempatlahir As String = " and siswa.tempat like '%" + caritempatlahir.Text + "%'"
            Dim agama As String = " and siswa.agama like '%" + cariagama.Text + "%'"
            Dim angkatan As String = " and siswa.angkatan = " + cariangkatandari.Text
            Dim angkatansampai As String = " and siswa.angkatan >= " + cariangkatandari.Text + " and siswa.angkatan <= " + cariangkatansampai.Text
            Dim tinggi As String = " and siswa.tinggi_siswa = " + caritinggidari.Text
            Dim tinggisampai As String = " and siswa.tinggi_siswa >= " + caritinggidari.Text + " and siswa.tinggi_siswa <= " + caritinggisampai.Text
            Dim berat As String = " and siswa.berat_siswa = " + cariberatdari.Text
            Dim beratsmpai As String = " and siswa.berat_siswa >= " + cariberatdari.Text + " and siswa.berat_siswa <= " + cariberatsampai.Text
            Dim umur As String = " and siswa.umur_siswa = " + cariumurdari.Text
            Dim umursampai As String = " and siswa.umur_siswa >= " + cariumurdari.Text + " and siswa.umur_siswa <= " + cariumursampai.Text
            Dim tgl_lhr As String = "  and siswa.tgl_lhr = TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY')"
            Dim tgl_lhr_sampai As String = " and siswa.tgl_lhr between TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY') and TO_DATE ('" + caritgllhrsampai.Value.ToShortDateString + "', 'DD/MM/YY')"

            If chknoinduk.Checked = True Then
                query = query + noinduk
            End If

            If chknama.Checked = True Then
                query = query + nama
            End If

            If chktempatlahir.Checked = True Then
                query = query + tempatlahir
            End If

            If chktgllhr.Checked = True Then
                If chktgllhrsampai.Checked = True Then
                    query = query + tgl_lhr_sampai
                Else
                    query = query + tgl_lhr
                End If

            End If

            If chkagama.Checked = True Then
                query = query + agama
            End If

            If chkangkatan.Checked = True Then
                If chkangkatansampai.Checked = True Then
                    query = query + angkatansampai
                Else
                    query = query + angkatan
                End If
            End If

            If chktinggi.Checked = True Then
                If chktinggisampai.Checked = True Then
                    query = query + tinggisampai
                Else
                    query = query + tinggi
                End If
            End If

            If chkberat.Checked = True Then
                If chkberatsampai.Checked = True Then
                    query = query + beratsmpai
                Else
                    query = query + berat
                End If
            End If

            If chkumur.Checked = True Then
                If chkumursampai.Checked = True Then
                    query = query + umursampai
                Else
                    query = query + umur
                End If
            End If

            query = query + " order by no_induk asc"
        End If

        cmd = New OracleCommand(query, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridcari.DataSource = ds.Tables(0)
    End Sub

    Private Sub chknoinduk_CheckedChanged(sender As Object, e As EventArgs) Handles chknoinduk.CheckedChanged
        If chknoinduk.Checked = True Then
            carinoinduk.Enabled = True
        End If

        If chknoinduk.Checked = False Then
            carinoinduk.Enabled = False
            carinoinduk.Text = ""
        End If
    End Sub

    Private Sub chknama_CheckedChanged(sender As Object, e As EventArgs) Handles chknama.CheckedChanged
        If chknama.Checked = True Then carinama.Enabled = True
        If chknama.Checked = False Then
            carinama.Enabled = False
            carinama.Text = ""
        End If
    End Sub

    Private Sub chkkelas_CheckedChanged(sender As Object, e As EventArgs) Handles chkkelas.CheckedChanged
        If chkkelas.Checked = True Then carikelas.Enabled = True
        If chkkelas.Checked = False Then
            carikelas.Enabled = False
            carikelas.Text = ""
        End If
    End Sub

    Private Sub chktempatlahir_CheckedChanged(sender As Object, e As EventArgs) Handles chktempatlahir.CheckedChanged
        If chktempatlahir.Checked = True Then caritempatlahir.Enabled = True
        If chktempatlahir.Checked = False Then
            caritempatlahir.Enabled = False
            caritempatlahir.Text = ""
        End If
    End Sub

    Private Sub chkagama_CheckedChanged(sender As Object, e As EventArgs) Handles chkagama.CheckedChanged
        If chkagama.Checked = True Then cariagama.Enabled = True
        If chkagama.Checked = False Then
            cariagama.Enabled = False
            cariagama.Text = ""
        End If
    End Sub

    Private Sub chkangkatan_CheckedChanged(sender As Object, e As EventArgs) Handles chkangkatan.CheckedChanged
        If chkangkatan.Checked = True Then
            cariangkatandari.Enabled = True
            chkangkatansampai.Enabled = True
        End If
        If chkangkatan.Checked = False Then
            cariangkatandari.Enabled = False
            chkangkatansampai.Enabled = False
            chkangkatansampai.Checked = False
            cariangkatandari.Text = ""
        End If
    End Sub

    Private Sub chktinggi_CheckedChanged(sender As Object, e As EventArgs) Handles chktinggi.CheckedChanged
        If chktinggi.Checked = True Then
            caritinggidari.Enabled = True
            chktinggisampai.Enabled = True
        End If
        If chktinggi.Checked = False Then
            caritinggidari.Enabled = False
            chktinggisampai.Enabled = False
            chktinggisampai.Checked = False
            caritinggidari.Text = ""
        End If
    End Sub

    Private Sub chkberat_CheckedChanged(sender As Object, e As EventArgs) Handles chkberat.CheckedChanged
        If chkberat.Checked = True Then
            cariberatdari.Enabled = True
            chkberatsampai.Enabled = True
        End If
        If chkberat.Checked = False Then
            cariberatdari.Enabled = False
            chkberatsampai.Enabled = False
            chkberatsampai.Checked = False
            cariberatdari.Text = ""
        End If
    End Sub

    Private Sub chkumur_CheckedChanged(sender As Object, e As EventArgs) Handles chkumur.CheckedChanged
        If chkumur.Checked = True Then
            chkumursampai.Enabled = True
            cariumurdari.Enabled = True
        End If
        If chkumur.Checked = False Then
            cariumurdari.Enabled = False
            chkumursampai.Enabled = False
            chkumursampai.Checked = False
            cariumurdari.Text = ""
        End If
    End Sub

    Private Sub chkgoldar_CheckedChanged(sender As Object, e As EventArgs) Handles chkgoldar.CheckedChanged
        If chkgoldar.Checked = True Then carigoldar.Enabled = True
        If chkgoldar.Checked = False Then carigoldar.Enabled = False
    End Sub

    Private Sub chktgllhr_CheckedChanged(sender As Object, e As EventArgs) Handles chktgllhr.CheckedChanged
        If chktgllhr.Checked = True Then
            caritgllhrdari.Enabled = True
            chktgllhrsampai.Enabled = True
        End If

        If chktgllhr.Checked = False Then
            caritgllhrdari.Enabled = False
            chktgllhrsampai.Enabled = False
            chktgllhrsampai.Checked = False
        End If
    End Sub

    Private Sub chktgllhrsampai_CheckedChanged(sender As Object, e As EventArgs) Handles chktgllhrsampai.CheckedChanged
        If chktgllhrsampai.Checked = True Then caritgllhrsampai.Enabled = True
        If chktgllhrsampai.Checked = False Then caritgllhrsampai.Enabled = False
    End Sub

    Public Sub tampildataKelas_Jurusan()
        Dim sql As String = "select * from kesiswaan.kelas_jurusan order by kelas asc"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
    End Sub

    Private Sub chkangkatansampai_CheckedChanged(sender As Object, e As EventArgs) Handles chkangkatansampai.CheckedChanged
        If chkangkatansampai.Checked = True Then cariangkatansampai.Enabled = True
        If chkangkatansampai.Checked = False Then
            cariangkatansampai.Enabled = False
            cariangkatansampai.Text = ""
        End If
    End Sub

    Private Sub chktinggisampai_CheckedChanged(sender As Object, e As EventArgs) Handles chktinggisampai.CheckedChanged
        If chktinggisampai.Checked = True Then caritinggisampai.Enabled = True
        If chktinggisampai.Checked = False Then
            caritinggisampai.Enabled = False
            caritinggisampai.Text = ""
        End If
    End Sub

    Private Sub chkberatsampai_CheckedChanged(sender As Object, e As EventArgs) Handles chkberatsampai.CheckedChanged
        If chkberatsampai.Checked = True Then cariberatsampai.Enabled = True
        If chkberatsampai.Checked = False Then
            cariberatsampai.Enabled = False
            cariberatsampai.Text = ""
        End If
    End Sub

    Private Sub chkumursampai_CheckedChanged(sender As Object, e As EventArgs) Handles chkumursampai.CheckedChanged
        If chkumursampai.Checked = True Then cariumursampai.Enabled = True
        If chkumursampai.Checked = False Then
            cariumursampai.Enabled = False
            cariumursampai.Text = ""
        End If
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        chkagama.Checked = False
        chknoinduk.Checked = False
        chkangkatan.Checked = False
        chkberat.Checked = False
        chkgoldar.Checked = False
        chkkelas.Checked = False
        chknama.Checked = False

        chktempatlahir.Checked = False
        chktinggi.Checked = False
        chkumur.Checked = False
        chktgllhr.Checked = False
        chkangkatan.Checked = False

        caritgllhrdari.Value = Date.Now
        caritgllhrsampai.Value = Date.Now

        Call tampildatasiswa()
        datagridcari.DataSource = ds.Tables(0)

    End Sub

    Public Sub tampildataJurusan()
        Dim sql As String = "select * from kesiswaan.jurusan order by kode_program asc"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
    End Sub

    Private Sub btninpuser_Click(sender As Object, e As EventArgs) Handles btninpuser.Click
        If txtuser.Text = "" Then
            MsgBox("Username Tidak Boleh Kosong", vbOKOnly + vbInformation, "Perhatian")
            txtuser.Select()
            Exit Sub
        End If

        cmd.Connection = conn
        conn.Open()
        Dim cari As String = "select * from kesiswaan.tuser where USERNAME = '" + txtuser.Text + "'"
        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagriduser.DataSource = ds.Tables(0)

        If datagriduser.RowCount = 1 Then
            cmd = New OracleCommand("insert into kesiswaan.tuser(USERNAME, PASSWORD, LVL) VALUES ('" + txtuser.Text + "','" + txtpwd.Text + "','" + cbostatus.Text + "')", conn)
            cmd.ExecuteNonQuery()
            Call tampildatauser()
            datagriduser.DataSource = ds.Tables(0)
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Username Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.tuser set PASSWORD='" + txtpwd.Text + "', LVL = '" + cbostatus.Text + "' where Username='" + txtuser.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatauser()
                datagridkelas.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
    End Sub

    Public Sub tampildatauser()
        Dim sql As String = " select * from kesiswaan.tuser order by username asc"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
    End Sub

    Private Sub carinoinduk_TextChanged(sender As Object, e As EventArgs) Handles carinoinduk.TextChanged
        Call cari()
    End Sub

    Private Sub carinama_TextChanged(sender As Object, e As EventArgs) Handles carinama.TextChanged
        Call cari()
    End Sub

    Private Sub carikelas_TextChanged(sender As Object, e As EventArgs) Handles carikelas.TextChanged
        Call cari()
    End Sub

    Private Sub cari()
        If chkkelas.Checked = True Then
            query = "select * from siswa,kelas where kelas.no_induk like siswa.no_induk"

            Dim noinduk As String = " and siswa.no_induk like '%" + carinoinduk.Text + "%'"
            Dim nama As String = " and siswa.nama_siswa like '%" + carinama.Text + "%'"
            Dim kelas As String = " and kelas.kelas like '%" + carikelas.Text + "%'"
            Dim tempatlahir As String = " and siswa.tempat like '%" + caritempatlahir.Text + "%'"
            Dim agama As String = " and siswa.agama like '%" + cariagama.Text + "%'"
            Dim angkatan As String = " and siswa.angkatan = " + cariangkatandari.Text
            Dim angkatansampai As String = " and siswa.angkatan >= " + cariangkatandari.Text + " and siswa.angkatan <= " + cariangkatansampai.Text
            Dim tinggi As String = " and siswa.tinggi_siswa = " + caritinggidari.Text
            Dim tinggisampai As String = " and siswa.tinggi_siswa >= " + caritinggidari.Text + " and siswa.tinggi_siswa <= " + caritinggisampai.Text
            Dim berat As String = " and siswa.berat_siswa = " + cariberatdari.Text
            Dim beratsmpai As String = " and siswa.berat_siswa >= " + cariberatdari.Text + " and siswa.berat_siswa <= " + cariberatsampai.Text
            Dim umur As String = " and siswa.umur_siswa = " + cariumurdari.Text
            Dim umursampai As String = " and siswa.umur_siswa >= " + cariumurdari.Text + " and siswa.umur_siswa <= " + cariumursampai.Text
            Dim tgl_lhr As String = "  and siswa.tgl_lhr = TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY')"
            Dim tgl_lhr_sampai As String = " and siswa.tgl_lhr between TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY') and TO_DATE ('" + caritgllhrsampai.Value.ToShortDateString + "', 'DD/MM/YY')"

            If chknoinduk.Checked = True Then
                query = query + noinduk
            End If

            If chknama.Checked = True Then
                query = query + nama
            End If

            If chkkelas.Checked = True Then
                query = query + kelas
            End If

            If chktempatlahir.Checked = True Then
                query = query + tempatlahir
            End If

            If chktgllhr.Checked = True Then
                If chktgllhrsampai.Checked = True Then
                    query = query + tgl_lhr_sampai
                Else
                    query = query + tgl_lhr
                End If

            End If

            If chkagama.Checked = True Then
                query = query + agama
            End If

            If chkangkatan.Checked = True Then
                If chkangkatansampai.Checked = True Then
                    query = query + angkatansampai
                Else
                    query = query + angkatan
                End If
            End If

            If chktinggi.Checked = True Then
                If chktinggisampai.Checked = True Then
                    query = query + tinggisampai
                Else
                    query = query + tinggi
                End If
            End If

            If chkberat.Checked = True Then
                If chkberatsampai.Checked = True Then
                    query = query + beratsmpai
                Else
                    query = query + berat
                End If
            End If

            If chkumur.Checked = True Then
                If chkumursampai.Checked = True Then
                    query = query + umursampai
                Else
                    query = query + umur
                End If
            End If

            query = query + " order by siswa.no_induk asc"
        Else
            query = "select * from siswa where no_induk = no_induk"
            Dim noinduk As String = " and siswa.no_induk like '%" + carinoinduk.Text + "%'"
            Dim nama As String = " and siswa.nama_siswa like '%" + carinama.Text + "%'"
            Dim tempatlahir As String = " and siswa.tempat like '%" + caritempatlahir.Text + "%'"
            Dim agama As String = " and siswa.agama like '%" + cariagama.Text + "%'"
            Dim angkatan As String = " and siswa.angkatan = " + cariangkatandari.Text
            Dim angkatansampai As String = " and siswa.angkatan >= " + cariangkatandari.Text + " and siswa.angkatan <= " + cariangkatansampai.Text
            Dim tinggi As String = " and siswa.tinggi_siswa = " + caritinggidari.Text
            Dim tinggisampai As String = " and siswa.tinggi_siswa >= " + caritinggidari.Text + " and siswa.tinggi_siswa <= " + caritinggisampai.Text
            Dim berat As String = " and siswa.berat_siswa = " + cariberatdari.Text
            Dim beratsmpai As String = " and siswa.berat_siswa >= " + cariberatdari.Text + " and siswa.berat_siswa <= " + cariberatsampai.Text
            Dim umur As String = " and siswa.umur_siswa = " + cariumurdari.Text
            Dim umursampai As String = " and siswa.umur_siswa >= " + cariumurdari.Text + " and siswa.umur_siswa <= " + cariumursampai.Text
            Dim tgl_lhr As String = "  and siswa.tgl_lhr = TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY')"
            Dim tgl_lhr_sampai As String = " and siswa.tgl_lhr between TO_DATE ('" + caritgllhrdari.Value.ToShortDateString + "', 'DD/MM/YY') and TO_DATE ('" + caritgllhrsampai.Value.ToShortDateString + "', 'DD/MM/YY')"

            If chknoinduk.Checked = True Then
                query = query + noinduk
            End If

            If chknama.Checked = True Then
                query = query + nama
            End If

            If chktempatlahir.Checked = True Then
                query = query + tempatlahir
            End If

            If chktgllhr.Checked = True Then
                If chktgllhrsampai.Checked = True Then
                    query = query + tgl_lhr_sampai
                Else
                    query = query + tgl_lhr
                End If

            End If

            If chkagama.Checked = True Then
                query = query + agama
            End If

            If chkangkatan.Checked = True Then
                If chkangkatansampai.Checked = True Then
                    query = query + angkatansampai
                Else
                    query = query + angkatan
                End If
            End If

            If chktinggi.Checked = True Then
                If chktinggisampai.Checked = True Then
                    query = query + tinggisampai
                Else
                    query = query + tinggi
                End If
            End If

            If chkberat.Checked = True Then
                If chkberatsampai.Checked = True Then
                    query = query + beratsmpai
                Else
                    query = query + berat
                End If
            End If

            If chkumur.Checked = True Then
                If chkumursampai.Checked = True Then
                    query = query + umursampai
                Else
                    query = query + umur
                End If
            End If

            query = query + " order by no_induk asc"
        End If

        cmd = New OracleCommand(query, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridcari.DataSource = ds.Tables(0)
    End Sub

    Private Sub caritempatlahir_TextChanged(sender As Object, e As EventArgs) Handles caritempatlahir.TextChanged
        Call cari()
    End Sub

    Private Sub caritgllhrdari_ValueChanged(sender As Object, e As EventArgs) Handles caritgllhrdari.ValueChanged
        Call cari()
    End Sub

    Private Sub cariagama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cariagama.SelectedIndexChanged
        Call cari()
    End Sub

    Private Sub cariangkatandari_TextChanged(sender As Object, e As EventArgs) Handles cariangkatandari.TextChanged
        Call cari()
    End Sub

    Private Sub cariangkatansampai_TextChanged(sender As Object, e As EventArgs) Handles cariangkatansampai.TextChanged
        Call cari()
    End Sub

    Private Sub caritinggidari_TextChanged(sender As Object, e As EventArgs) Handles caritinggidari.TextChanged
        Call cari()
    End Sub

    Private Sub caritinggisampai_TextChanged(sender As Object, e As EventArgs) Handles caritinggisampai.TextChanged
        Call cari()
    End Sub

    Private Sub cariberatdari_TextChanged(sender As Object, e As EventArgs) Handles cariberatdari.TextChanged
        Call cari()
    End Sub

    Private Sub cariberatsampai_TextChanged(sender As Object, e As EventArgs) Handles cariberatsampai.TextChanged
        Call cari()
    End Sub

    Private Sub cariumurdari_TextChanged(sender As Object, e As EventArgs) Handles cariumurdari.TextChanged
        Call cari()
    End Sub

    Private Sub cariumursampai_TextChanged(sender As Object, e As EventArgs) Handles cariumursampai.TextChanged
        Call cari()
    End Sub

    Private Sub carigoldar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles carigoldar.SelectedIndexChanged
        Call cari()
    End Sub

    Private Sub cbokelaskelas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbokelaskelas.SelectedIndexChanged
        Dim querykelas As String = cbokelaskelas.Text
        Dim queryta As String = cbota.Text
        Dim cari As String
        cmd.Connection = conn
        conn.Open()
        If cbokelaskelas.Text = "-" And cbota.Text = "-" Then
            cari = "select * from kesiswaan.kelas"
        ElseIf cbokelaskelas.Text = "-" Then
            cari = "select * from kesiswaan.kelas where TA = '" + queryta + "'"
        ElseIf cbota.Text = "-" Then
            cari = "select * from kesiswaan.kelas where KELAS = '" + querykelas + "'"
        Else
            cari = "select * from kesiswaan.kelas where KELAS = '" + querykelas + "' and TA='" + queryta + "'"
        End If
        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridkelassiswa.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    Private Sub mainform_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
        Call tampildatasiswa()
        datagridcari.DataSource = ds.Tables(0)
        DataGridSiswa.DataSource = ds.Tables(0)
        Call tampildataKelas_Jurusan()
        datagridkelas.DataSource = ds.Tables(0)

        Call tampildataJurusan()
        datagridjurusan.DataSource = ds.Tables(0)

        Call tampildatakelas()
        datagridkelassiswa.DataSource = ds.Tables(0)

        Call tampildatauser()
        datagriduser.DataSource = ds.Tables(0)

        Call load_cbojurusan()
        Call load_cbokelas()

        cariagama.Enabled = False
        cariangkatandari.Enabled = False
        cariberatdari.Enabled = False
        carigoldar.Enabled = False
        carikelas.Enabled = False
        carinama.Enabled = False
        carinoinduk.Enabled = False
        caritempatlahir.Enabled = False
        caritinggidari.Enabled = False
        cariumurdari.Enabled = False
        caritgllhrdari.Enabled = False
        caritgllhrsampai.Enabled = False
        chktgllhrsampai.Enabled = False
        chkangkatansampai.Enabled = False
        cariangkatansampai.Enabled = False
        chkberatsampai.Enabled = False
        cariberatsampai.Enabled = False
        cariumursampai.Enabled = False

        chktinggisampai.Enabled = False
        caritinggisampai.Enabled = False
        chkumursampai.Enabled = False

        Call load_cbota()

    End Sub

    Private Sub cbota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbota.SelectedIndexChanged
        Dim querykelas As String = cbokelaskelas.Text
        Dim queryta As String = cbota.Text
        Dim cari As String
        cmd.Connection = conn
        conn.Open()
        If cbokelaskelas.Text = "-" And cbota.Text = "-" Then
            cari = "select * from kesiswaan.kelas"
        ElseIf cbokelaskelas.Text = "-" Then
            cari = "select * from kesiswaan.kelas where TA = '" + queryta + "'"
        ElseIf cbota.Text = "-" Then
            cari = "select * from kesiswaan.kelas where KELAS = '" + querykelas + "'"
        Else
            cari = "select * from kesiswaan.kelas where KELAS = '" + querykelas + "' and TA='" + queryta + "'"
        End If
        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridkelassiswa.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    Public Sub load_cbota()
        Dim tahun As Integer = Date.Now.Year
        Dim awal As Integer
        Dim akhir = tahun + 5
        Dim ta As String
        cbota.Items.Add("-")
        For awal = tahun - 5 To akhir
            akhir = awal + 1
            ta = awal.ToString + "/" + akhir.ToString
            cbota.Items.Add(ta)
        Next
    End Sub

    Public Sub load_cbojurusan()
        Dim i As Integer
        i = datagridjurusan.RowCount
        Dim maxrow As Integer = i - 2
        Dim row As Integer
        Dim value As Object
        For row = 0 To maxrow
            value = datagridjurusan.Item(0, row).Value
            cbokodeprogram.Items.Remove(value)
        Next
        For row = 0 To maxrow
            value = datagridjurusan.Item(0, row).Value
            cbokodeprogram.Items.Add(value)
        Next

    End Sub

    Public Sub load_cbokelas()
        Dim i As Integer
        i = datagridkelas.RowCount
        Dim maxrow As Integer = i - 2
        Dim row As Integer
        Dim value As Object
        For row = 0 To maxrow
            value = datagridkelas.Item(0, row).Value
            cbokelaskelas.Items.Remove(value)
        Next
        cbokelaskelas.Items.Remove("-")
        cbokelaskelas.Items.Add("-")
        For row = 0 To maxrow
            value = datagridkelas.Item(0, row).Value
            cbokelaskelas.Items.Add(value)
        Next

    End Sub

    Public Sub clean_kelasjurusan()
        txtkelas.Text = ""
        cbokodeprogram.Text = ""
    End Sub

    Public Sub tampildatakelas()
        Dim sql As String = "select * from kesiswaan.kelas order by kelas asc"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)
    End Sub

    Private Sub mainform_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmLogin.Show()
    End Sub
End Class
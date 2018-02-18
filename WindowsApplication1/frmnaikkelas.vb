Imports Oracle.DataAccess.Client
Public Class frmnaikkelas
    Public conn As New OracleConnection
    Public cmd As OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet

    Public query As String

    Private Sub frmnaikkelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()

        'load cbota
        Dim tahun As Integer = Date.Now.Year
        Dim awal As Integer
        Dim akhir = tahun + 5
        Dim ta As String
        cbotalama.Items.Add("Semua")
        cbotabaru.Items.Add("Semua")
        For awal = tahun - 5 To akhir
            akhir = awal + 1
            ta = awal.ToString + "/" + akhir.ToString
            cbotalama.Items.Add(ta)
            cbotabaru.Items.Add(ta)
        Next

        'load cbokelas
        Dim i As Integer
        i = mainform.datagridkelas.RowCount
        Dim maxrow As Integer = i - 2
        Dim row As Integer
        Dim value As Object
        cbokelaslama.Items.Add("Semua")
        cbokelasbaru.Items.Add("Semua")
        For row = 0 To maxrow
            value = mainform.datagridkelas.Item(0, row).Value
            cbokelaslama.Items.Add(value)
            cbokelasbaru.Items.Add(value)
        Next

        'tampil data kelas
        Dim sql As String = "select kelas.no_induk,siswa.nama_siswa, kelas.kelas,kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.no_induk = siswa.no_induk order by kelas asc"
        cmd = New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridkelasbaru.DataSource = ds.Tables(0)
        datagridkelaslama.DataSource = ds.Tables(0)

        cbokelasbaru.SelectedIndex = 0
        cbokelaslama.SelectedIndex = 0
        cbotabaru.SelectedIndex = 0
        cbotalama.SelectedIndex = 0

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
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

    Private Sub cbokelaslama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbokelaslama.SelectedIndexChanged
        Call tampil_kelaslama()
    End Sub

    Private Sub cbotalama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotalama.SelectedIndexChanged
        Call tampil_kelaslama()
    End Sub

    Private Sub cbokelasbaru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbokelasbaru.SelectedIndexChanged
        Call tampil_kelasbaru()
    End Sub

    Private Sub cbotabaru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotabaru.SelectedIndexChanged
        Call tampil_kelasbaru()
    End Sub

    Private Sub tampil_kelaslama()
        Dim querykelas As String = cbokelaslama.Text
        Dim queryta As String = cbotalama.Text
        Dim cari As String
        cmd.Connection = conn
        conn.Open()

        If querykelas = "Semua" And queryta = "Semua" Then
            cari = "select kelas.no_induk,siswa.nama_siswa, kelas.kelas,kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.no_induk = siswa.no_induk order by kelas asc"
        ElseIf querykelas = "Semua" And queryta IsNot "Semua" Then
            cari = "select kelas.no_induk, siswa.nama_siswa, kelas.kelas, kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.TA='" + queryta + "' and kelas.no_induk = siswa.no_induk order by kelas.no_induk asc"
        ElseIf querykelas IsNot "Semua" And queryta = "Semua" Then
            cari = "select kelas.no_induk, siswa.nama_siswa, kelas.kelas, kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.KELAS = '" + querykelas + "' and kelas.no_induk = siswa.no_induk order by kelas.no_induk asc"
        Else
            cari = "select kelas.no_induk, siswa.nama_siswa, kelas.kelas, kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.KELAS = '" + querykelas + "' and kelas.TA='" + queryta + "' and kelas.no_induk = siswa.no_induk order by kelas.no_induk asc"
        End If

        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridkelaslama.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    Private Sub tampil_kelasbaru()
        Dim querykelas As String = cbokelasbaru.Text
        Dim queryta As String = cbotabaru.Text
        Dim cari As String
        cmd.Connection = conn
        conn.Open()
        If querykelas = "Semua" And queryta = "Semua" Then
            cari = "select kelas.no_induk,siswa.nama_siswa, kelas.kelas,kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.no_induk = siswa.no_induk order by kelas asc"
        ElseIf querykelas = "Semua" And queryta IsNot "Semua" Then
            cari = "select kelas.no_induk, siswa.nama_siswa, kelas.kelas, kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.TA='" + queryta + "' and kelas.no_induk = siswa.no_induk order by kelas.no_induk asc"
        ElseIf querykelas IsNot "Semua" And queryta = "Semua" Then
            cari = "select kelas.no_induk, siswa.nama_siswa, kelas.kelas, kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.KELAS = '" + querykelas + "' and kelas.no_induk = siswa.no_induk order by kelas.no_induk asc"
        Else
            cari = "select kelas.no_induk, siswa.nama_siswa, kelas.kelas, kelas.ta from kesiswaan.kelas,kesiswaan.siswa where kelas.KELAS = '" + querykelas + "' and kelas.TA='" + queryta + "' and kelas.no_induk = siswa.no_induk order by kelas.no_induk asc"
        End If

        cmd = New OracleCommand(cari, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()
        dr.Read()
        da = New OracleDataAdapter(cmd)
        cb = New OracleCommandBuilder(da)
        ds = New DataSet()
        da.Fill(ds)

        datagridkelasbaru.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    Private Sub btnnaik_Click(sender As Object, e As EventArgs) Handles btnnaik.Click
        If datagridkelaslama.CurrentRow.Selected Then
            If cbokelasbaru.Text = "Semua" Then
                MsgBox("Harap Pilih Kelas", vbOKOnly, "Perhatian")
                cbokelasbaru.Focus()
                Exit Sub
            End If
            If cbotabaru.Text = "Semua" Then
                MsgBox("Harap Pilih Tahun Ajaran", vbOKOnly, "Perhatian")
                cbotabaru.Focus()
                Exit Sub
            End If
            Dim querykelasbaru As String = cbokelasbaru.Text
            Dim querytabaru As String = cbotabaru.Text
            Dim i As Object = datagridkelaslama.CurrentRow.Index
            Dim no_induk As String = datagridkelaslama.Item(0, i).Value

            cmd.Connection = conn
            conn.Open()

            cmd = New OracleCommand("update kesiswaan.kelas set kelas = '" + cbokelasbaru.Text + "', ta = '" + cbotabaru.Text + "' where no_induk='" + no_induk + "'", conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            Call tampil_kelasbaru()
            Call tampil_kelaslama()

        End If
    End Sub

    Private Sub btnturun_Click(sender As Object, e As EventArgs) Handles btnturun.Click
        If datagridkelasbaru.CurrentRow.Selected Then
            If cbokelaslama.Text = "Semua" Then
                MsgBox("Harap Pilih Kelas", vbOKOnly, "Perhatian")
                cbokelaslama.Focus()
                Exit Sub
            End If
            If cbotalama.Text = "Semua" Then
                MsgBox("Harap Pilih Tahun Ajaran", vbOKOnly, "Perhatian")
                cbotalama.Focus()
                Exit Sub
            End If

            Dim i As Object = datagridkelasbaru.CurrentRow.Index
            Dim no_induk As String = datagridkelasbaru.Item(0, i).Value

            cmd.Connection = conn
            conn.Open()

            cmd = New OracleCommand("update kesiswaan.kelas set kelas = '" + cbokelaslama.Text + "', ta = '" + cbotalama.Text + "' where no_induk='" + no_induk + "'", conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            Call tampil_kelasbaru()
            Call tampil_kelaslama()

        End If
    End Sub
End Class
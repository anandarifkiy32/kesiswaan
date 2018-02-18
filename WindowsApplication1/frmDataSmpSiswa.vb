Imports Oracle.DataAccess.Client
Public Class frmDataSmpSiswa
    Public conn As New OracleConnection
    Public cmd As New OracleCommand
    Public da As OracleDataAdapter
    Public cb As OracleCommandBuilder
    Public ds As DataSet
    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        If txtnoinduk.Text = "" Then
            MsgBox("No Induk tidak boleh kosong", vbOKOnly + vbInformation, "Perhatian")
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

        Dim nmat As Double = Convert.ToDouble(Val(txtnmat.Text))
        Dim nind As Double = Convert.ToDouble(Val(txtnind.Text))
        Dim ningg As Double = Convert.ToDouble(Val(txtningg.Text))

        If mainform.DataGridSiswa.RowCount = 1 Then
            cmd = New OracleCommand("insert into kesiswaan.siswa (NO_INDUK, NAMA_SMP, ALAMAT_SMP, TELP_SMP, FAX_SMP, NO_IJAZAH, NMAT, NIND, NINGG, KET, PRETASI) values ('" + txtnoinduk.Text + "','" + txtnama.Text + "','" + txtalamat.Text + "','" + txttelp.Text + "','" + txtfax.Text + "','" + txtnoijazah.Text + "'," & nmat & "," & nind & "," & ningg & ")", conn)
            cmd.ExecuteNonQuery()
            Call tampildatasiswa()
            mainform.DataGridSiswa.DataSource = ds.Tables(0)
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.siswa Set NAMA_SMP='" + txtnama.Text + "', ALAMAT_SMP='" + txtalamat.Text + "', TELP_SMP='" + txttelp.Text + "', FAX_SMP='" + txtfax.Text + "', NO_IJAZAH='" + txtnoijazah.Text + "', NMAT=" & nmat & ", NIND=" & nind & ", NINGG=" & ningg & ", KET='" + txtket.Text + "', PRESTASI='" + txtprestasi.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatasiswa()
                mainform.DataGridSiswa.DataSource = ds.Tables(0)
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
        Call clean()
        conn.Close()
    End Sub

    Public Sub clean()
        txtnoinduk.Text = ""
        txtnama.Text = ""
        txtnama.Enabled = False
        txtalamat.Text = ""
        txtalamat.Enabled = False
        txtfax.Text = ""
        txtfax.Enabled = False
        txtket.Text = ""
        txtket.Enabled = False
        txtnind.Text = ""
        txtnind.Enabled = False
        txtningg.Text = ""
        txtningg.Enabled = False
        txtnmat.Text = ""
        txtnmat.Enabled = False
        txtnoijazah.Text = ""
        txtnoijazah.Enabled = False
        txtprestasi.Text = ""
        txtprestasi.Enabled = False
        txttelp.Text = ""
        txttelp.Enabled = False
        txtnoinduk.Enabled = True
        txtnoinduk.Focus()
        btninput.Enabled = False
    End Sub
    Public Sub input()
        txtnama.Enabled = True
        txtalamat.Enabled = True
        txtfax.Enabled = True
        txtket.Enabled = True
        txtnind.Enabled = True
        txtningg.Enabled = True
        txtnmat.Enabled = True
        txtnoijazah.Enabled = True
        txtprestasi.Enabled = True
        txttelp.Enabled = True
        txtnoinduk.Enabled = False
        btninput.Enabled = True
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

    Private Sub frmArsipDataSmpSiswa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call clean()
        Call koneksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call tampildatasiswa()
        mainform.DataGridSiswa.DataSource = ds.Tables(0)
        Close()
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

                If IsDBNull(dr.Item(65)) Then
                    txtnama.Text = ""
                Else
                    txtnama.Text = dr.Item(65)
                End If

                If IsDBNull(dr.Item(66)) Then
                    txtalamat.Text = ""
                Else
                    txtalamat.Text = dr.Item(66)
                End If

                If IsDBNull(dr.Item(67)) Then
                    txttelp.Text = ""
                Else
                    txttelp.Text = dr.Item(67)
                End If

                If IsDBNull(dr.Item(68)) Then
                    txtfax.Text = ""
                Else
                    txtfax.Text = dr.Item(68)
                End If

                If IsDBNull(dr.Item(69)) Then
                    txtnoijazah.Text = ""
                Else
                    txtnoijazah.Text = dr.Item(69)
                End If

                If IsDBNull(dr.Item(70)) Then
                    txtnmat.Text = ""
                Else
                    txtnmat.Text = dr.Item(70)
                End If

                If IsDBNull(dr.Item(71)) Then
                    txtnind.Text = ""
                Else
                    txtnind.Text = dr.Item(71)
                End If

                If IsDBNull(dr.Item(72)) Then
                    txtningg.Text = ""
                Else
                    txtningg.Text = dr.Item(72)
                End If

                If IsDBNull(dr.Item(73)) Then
                    txtket.Text = ""
                Else
                    txtket.Text = dr.Item(73)
                End If

                If IsDBNull(dr.Item(74)) Then
                    txtprestasi.Text = ""
                Else
                    txtprestasi.Text = dr.Item(74)
                End If
            End If
            conn.Close()
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clean()
    End Sub
End Class
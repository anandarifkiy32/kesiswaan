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
            conn.Close()
            MsgBox("Data Berhasil Disimpan", vbOK + vbInformation, "Perhatian")
        Else
            If MsgBox("Nomor Induk Sudah Ada, Perbarui Data?", vbYesNo + vbInformation, " Perhatian") = vbYes Then
                cmd = New OracleCommand("Update kesiswaan.siswa Set NAMA_SMP='" + txtnama.Text + "', ALAMAT_SMP='" + txtalamat.Text + "', TELP_SMP='" + txttelp.Text + "', FAX_SMP='" + txtfax.Text + "', NO_IJAZAH='" + txtnoijazah.Text + "', NMAT=" & nmat & ", NIND=" & nind & ", NINGG=" & ningg & ", KET='" + txtket.Text + "', PRESTASI='" + txtprestasi.Text + "' where NO_INDUK='" + txtnoinduk.Text + "'", conn)
                cmd.ExecuteNonQuery()
                Call tampildatasiswa()
                mainform.DataGridSiswa.DataSource = ds.Tables(0)
                conn.Close()
                MsgBox("Data Berhasil di Perbarui", vbOK, "Perhatian")
            End If
        End If
        Call clean()
    End Sub

    Public Sub clean()
        txtnoinduk.Text = ""
        txtnama.Text = ""
        txtalamat.Text = ""
        txtfax.Text = ""
        txtket.Text = ""
        txtnind.Text = ""
        txtningg.Text = ""
        txtnmat.Text = ""
        txtnoijazah.Text = ""
        txtprestasi.Text = ""
        txttelp.Text = ""
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

    Private Sub frmArsipDataSmpSiswa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call koneksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
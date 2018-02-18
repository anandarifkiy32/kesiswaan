<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmArsipDataAyah
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtnoinduk = New System.Windows.Forms.TextBox()
        Me.txtnamaayah = New System.Windows.Forms.TextBox()
        Me.txttempatlahir = New System.Windows.Forms.TextBox()
        Me.cboagamaayah = New System.Windows.Forms.ComboBox()
        Me.txtpdayah = New System.Windows.Forms.TextBox()
        Me.txtpekerjaan = New System.Windows.Forms.TextBox()
        Me.txtpenghasilan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtwn = New System.Windows.Forms.TextBox()
        Me.dtptglhrayah = New System.Windows.Forms.DateTimePicker()
        Me.txtalamatrumah = New System.Windows.Forms.TextBox()
        Me.txttelprumah = New System.Windows.Forms.TextBox()
        Me.txtalamatkantor = New System.Windows.Forms.TextBox()
        Me.txttelpkantor = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btninpsiswa = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtnoinduk
        '
        Me.txtnoinduk.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnoinduk.Location = New System.Drawing.Point(270, 73)
        Me.txtnoinduk.Name = "txtnoinduk"
        Me.txtnoinduk.Size = New System.Drawing.Size(100, 22)
        Me.txtnoinduk.TabIndex = 0
        '
        'txtnamaayah
        '
        Me.txtnamaayah.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnamaayah.Location = New System.Drawing.Point(270, 99)
        Me.txtnamaayah.Name = "txtnamaayah"
        Me.txtnamaayah.Size = New System.Drawing.Size(172, 22)
        Me.txtnamaayah.TabIndex = 1
        '
        'txttempatlahir
        '
        Me.txttempatlahir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempatlahir.Location = New System.Drawing.Point(270, 125)
        Me.txttempatlahir.Name = "txttempatlahir"
        Me.txttempatlahir.Size = New System.Drawing.Size(100, 22)
        Me.txttempatlahir.TabIndex = 3
        '
        'cboagamaayah
        '
        Me.cboagamaayah.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboagamaayah.FormattingEnabled = True
        Me.cboagamaayah.Items.AddRange(New Object() {"ISLAM", "PROTESTAN", "KATHOLIK", "HINDU", "BUDDHA"})
        Me.cboagamaayah.Location = New System.Drawing.Point(270, 177)
        Me.cboagamaayah.Name = "cboagamaayah"
        Me.cboagamaayah.Size = New System.Drawing.Size(100, 24)
        Me.cboagamaayah.TabIndex = 6
        '
        'txtpdayah
        '
        Me.txtpdayah.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpdayah.Location = New System.Drawing.Point(270, 230)
        Me.txtpdayah.Name = "txtpdayah"
        Me.txtpdayah.Size = New System.Drawing.Size(45, 22)
        Me.txtpdayah.TabIndex = 7
        '
        'txtpekerjaan
        '
        Me.txtpekerjaan.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpekerjaan.Location = New System.Drawing.Point(270, 256)
        Me.txtpekerjaan.Name = "txtpekerjaan"
        Me.txtpekerjaan.Size = New System.Drawing.Size(172, 22)
        Me.txtpekerjaan.TabIndex = 8
        '
        'txtpenghasilan
        '
        Me.txtpenghasilan.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpenghasilan.Location = New System.Drawing.Point(270, 282)
        Me.txtpenghasilan.Name = "txtpenghasilan"
        Me.txtpenghasilan.Size = New System.Drawing.Size(127, 22)
        Me.txtpenghasilan.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(68, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "NO INDUK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(68, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 19)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "NAMA AYAH"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(68, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 19)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "TEMPAT LAHIR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(68, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 19)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "TANGGAL LAHIR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(68, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 19)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "AGAMA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(68, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 19)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "KEWARGANEGARAAN"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label7.Location = New System.Drawing.Point(68, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 19)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "PENDIDIKAN TERKAHIR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(68, 256)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 19)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "PEKERJAAN "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label9.Location = New System.Drawing.Point(68, 282)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 19)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "PENGHASILAN"
        '
        'txtwn
        '
        Me.txtwn.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwn.Location = New System.Drawing.Point(270, 205)
        Me.txtwn.Name = "txtwn"
        Me.txtwn.Size = New System.Drawing.Size(45, 22)
        Me.txtwn.TabIndex = 21
        '
        'dtptglhrayah
        '
        Me.dtptglhrayah.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtptglhrayah.Location = New System.Drawing.Point(270, 151)
        Me.dtptglhrayah.Name = "dtptglhrayah"
        Me.dtptglhrayah.Size = New System.Drawing.Size(172, 22)
        Me.dtptglhrayah.TabIndex = 22
        Me.dtptglhrayah.Value = New Date(2018, 2, 14, 16, 55, 48, 0)
        '
        'txtalamatrumah
        '
        Me.txtalamatrumah.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtalamatrumah.Location = New System.Drawing.Point(270, 308)
        Me.txtalamatrumah.Multiline = True
        Me.txtalamatrumah.Name = "txtalamatrumah"
        Me.txtalamatrumah.Size = New System.Drawing.Size(172, 63)
        Me.txtalamatrumah.TabIndex = 23
        '
        'txttelprumah
        '
        Me.txttelprumah.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelprumah.Location = New System.Drawing.Point(270, 377)
        Me.txttelprumah.Name = "txttelprumah"
        Me.txttelprumah.Size = New System.Drawing.Size(127, 22)
        Me.txttelprumah.TabIndex = 24
        '
        'txtalamatkantor
        '
        Me.txtalamatkantor.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtalamatkantor.Location = New System.Drawing.Point(270, 403)
        Me.txtalamatkantor.Multiline = True
        Me.txtalamatkantor.Name = "txtalamatkantor"
        Me.txtalamatkantor.Size = New System.Drawing.Size(172, 63)
        Me.txtalamatkantor.TabIndex = 25
        '
        'txttelpkantor
        '
        Me.txttelpkantor.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelpkantor.Location = New System.Drawing.Point(270, 472)
        Me.txttelpkantor.Name = "txttelpkantor"
        Me.txttelpkantor.Size = New System.Drawing.Size(127, 22)
        Me.txttelpkantor.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label10.Location = New System.Drawing.Point(68, 308)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 19)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "ALAMAT RUMAH"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label11.Location = New System.Drawing.Point(68, 377)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 19)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "NO. TELP."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label12.Location = New System.Drawing.Point(68, 403)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 19)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "ALAMAT KANTOR"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label13.Location = New System.Drawing.Point(68, 472)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 19)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "NO. TELP. KANTOR"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(201, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 25)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "DATA AYAH"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Transparent
        Me.Button2.Location = New System.Drawing.Point(486, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 23)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.DimGray
        Me.btncancel.FlatAppearance.BorderSize = 0
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.ForeColor = System.Drawing.Color.White
        Me.btncancel.Location = New System.Drawing.Point(336, 509)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(70, 23)
        Me.btncancel.TabIndex = 109
        Me.btncancel.Text = "BATAL"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btninpsiswa
        '
        Me.btninpsiswa.BackColor = System.Drawing.Color.DimGray
        Me.btninpsiswa.FlatAppearance.BorderSize = 0
        Me.btninpsiswa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btninpsiswa.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btninpsiswa.ForeColor = System.Drawing.Color.White
        Me.btninpsiswa.Location = New System.Drawing.Point(270, 509)
        Me.btninpsiswa.Name = "btninpsiswa"
        Me.btninpsiswa.Size = New System.Drawing.Size(60, 23)
        Me.btninpsiswa.TabIndex = 108
        Me.btninpsiswa.Text = "INPUT"
        Me.btninpsiswa.UseVisualStyleBackColor = False
        '
        'frmArsipDataAyah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 573)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btninpsiswa)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txttelpkantor)
        Me.Controls.Add(Me.txtalamatkantor)
        Me.Controls.Add(Me.txttelprumah)
        Me.Controls.Add(Me.txtalamatrumah)
        Me.Controls.Add(Me.dtptglhrayah)
        Me.Controls.Add(Me.txtwn)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtpenghasilan)
        Me.Controls.Add(Me.txtpekerjaan)
        Me.Controls.Add(Me.txtpdayah)
        Me.Controls.Add(Me.cboagamaayah)
        Me.Controls.Add(Me.txttempatlahir)
        Me.Controls.Add(Me.txtnamaayah)
        Me.Controls.Add(Me.txtnoinduk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(130, 110)
        Me.Name = "frmArsipDataAyah"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmArsipKelasSiswa"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtnoinduk As TextBox
    Friend WithEvents txtnamaayah As TextBox
    Friend WithEvents txttempatlahir As TextBox
    Friend WithEvents cboagamaayah As ComboBox
    Friend WithEvents txtpdayah As TextBox
    Friend WithEvents txtpekerjaan As TextBox
    Friend WithEvents txtpenghasilan As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtwn As TextBox
    Friend WithEvents dtptglhrayah As DateTimePicker
    Friend WithEvents txtalamatrumah As TextBox
    Friend WithEvents txttelprumah As TextBox
    Friend WithEvents txtalamatkantor As TextBox
    Friend WithEvents txttelpkantor As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btncancel As Button
    Friend WithEvents btninpsiswa As Button
End Class

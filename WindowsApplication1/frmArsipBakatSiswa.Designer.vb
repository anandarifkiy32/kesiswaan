<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmArsipBakatSiswa
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnoinduk = New System.Windows.Forms.TextBox()
        Me.txtkesenian = New System.Windows.Forms.TextBox()
        Me.txtolahraga = New System.Windows.Forms.TextBox()
        Me.txtorganisasi = New System.Windows.Forms.TextBox()
        Me.txtlainlain = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(150, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BAKAT SISWA"
        '
        'txtnoinduk
        '
        Me.txtnoinduk.Location = New System.Drawing.Point(199, 71)
        Me.txtnoinduk.Name = "txtnoinduk"
        Me.txtnoinduk.Size = New System.Drawing.Size(100, 20)
        Me.txtnoinduk.TabIndex = 1
        '
        'txtkesenian
        '
        Me.txtkesenian.Location = New System.Drawing.Point(199, 97)
        Me.txtkesenian.Multiline = True
        Me.txtkesenian.Name = "txtkesenian"
        Me.txtkesenian.Size = New System.Drawing.Size(154, 47)
        Me.txtkesenian.TabIndex = 2
        '
        'txtolahraga
        '
        Me.txtolahraga.Location = New System.Drawing.Point(199, 150)
        Me.txtolahraga.Multiline = True
        Me.txtolahraga.Name = "txtolahraga"
        Me.txtolahraga.Size = New System.Drawing.Size(154, 47)
        Me.txtolahraga.TabIndex = 3
        '
        'txtorganisasi
        '
        Me.txtorganisasi.Location = New System.Drawing.Point(199, 203)
        Me.txtorganisasi.Multiline = True
        Me.txtorganisasi.Name = "txtorganisasi"
        Me.txtorganisasi.Size = New System.Drawing.Size(154, 47)
        Me.txtorganisasi.TabIndex = 4
        '
        'txtlainlain
        '
        Me.txtlainlain.Location = New System.Drawing.Point(199, 256)
        Me.txtlainlain.Multiline = True
        Me.txtlainlain.Name = "txtlainlain"
        Me.txtlainlain.Size = New System.Drawing.Size(154, 59)
        Me.txtlainlain.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label2.Location = New System.Drawing.Point(71, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "NO INDUK"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label3.Location = New System.Drawing.Point(71, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "KESENIAN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label4.Location = New System.Drawing.Point(71, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "OLAHRAGA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label5.Location = New System.Drawing.Point(71, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "ORGANISASI"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label6.Location = New System.Drawing.Point(71, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 19)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "LAIN-LAIN"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DimGray
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(199, 321)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 23)
        Me.Button1.TabIndex = 84
        Me.Button1.Text = "INPUT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Transparent
        Me.Button2.Location = New System.Drawing.Point(378, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 23)
        Me.Button2.TabIndex = 85
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmArsipBakatSiswa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 434)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtlainlain)
        Me.Controls.Add(Me.txtorganisasi)
        Me.Controls.Add(Me.txtolahraga)
        Me.Controls.Add(Me.txtkesenian)
        Me.Controls.Add(Me.txtnoinduk)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmArsipBakatSiswa"
        Me.Text = "frmArsipBakatSiswa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtnoinduk As TextBox
    Friend WithEvents txtkesenian As TextBox
    Friend WithEvents txtolahraga As TextBox
    Friend WithEvents txtorganisasi As TextBox
    Friend WithEvents txtlainlain As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class

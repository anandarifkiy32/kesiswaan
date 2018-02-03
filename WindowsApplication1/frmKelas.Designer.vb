<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKelas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtnoindukkelas = New System.Windows.Forms.TextBox()
        Me.cbokelaskelas = New System.Windows.Forms.ComboBox()
        Me.txttakelas = New System.Windows.Forms.TextBox()
        Me.txtdeskelas = New System.Windows.Forms.TextBox()
        Me.btninputkelas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label1.Location = New System.Drawing.Point(69, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "KELAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label3.Location = New System.Drawing.Point(69, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "NO. INDUK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label2.Location = New System.Drawing.Point(69, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "DES"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.Label4.Location = New System.Drawing.Point(69, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "TAHUN AJARAN"
        '
        'txtnoindukkelas
        '
        Me.txtnoindukkelas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnoindukkelas.Location = New System.Drawing.Point(195, 122)
        Me.txtnoindukkelas.Name = "txtnoindukkelas"
        Me.txtnoindukkelas.Size = New System.Drawing.Size(139, 23)
        Me.txtnoindukkelas.TabIndex = 15
        '
        'cbokelaskelas
        '
        Me.cbokelaskelas.FormattingEnabled = True
        Me.cbokelaskelas.Location = New System.Drawing.Point(195, 152)
        Me.cbokelaskelas.Name = "cbokelaskelas"
        Me.cbokelaskelas.Size = New System.Drawing.Size(92, 21)
        Me.cbokelaskelas.TabIndex = 16
        '
        'txttakelas
        '
        Me.txttakelas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttakelas.Location = New System.Drawing.Point(195, 213)
        Me.txttakelas.Name = "txttakelas"
        Me.txttakelas.Size = New System.Drawing.Size(139, 23)
        Me.txttakelas.TabIndex = 18
        '
        'txtdeskelas
        '
        Me.txtdeskelas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdeskelas.Location = New System.Drawing.Point(195, 182)
        Me.txtdeskelas.Name = "txtdeskelas"
        Me.txtdeskelas.Size = New System.Drawing.Size(33, 23)
        Me.txtdeskelas.TabIndex = 17
        '
        'btninputkelas
        '
        Me.btninputkelas.Location = New System.Drawing.Point(195, 242)
        Me.btninputkelas.Name = "btninputkelas"
        Me.btninputkelas.Size = New System.Drawing.Size(75, 23)
        Me.btninputkelas.TabIndex = 19
        Me.btninputkelas.Text = "input"
        Me.btninputkelas.UseVisualStyleBackColor = True
        '
        'frmKelas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 402)
        Me.Controls.Add(Me.btninputkelas)
        Me.Controls.Add(Me.txtdeskelas)
        Me.Controls.Add(Me.txttakelas)
        Me.Controls.Add(Me.cbokelaskelas)
        Me.Controls.Add(Me.txtnoindukkelas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmKelas"
        Me.Text = "frmKelas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtnoindukkelas As TextBox
    Friend WithEvents cbokelaskelas As ComboBox
    Friend WithEvents txttakelas As TextBox
    Friend WithEvents txtdeskelas As TextBox
    Friend WithEvents btninputkelas As Button
End Class

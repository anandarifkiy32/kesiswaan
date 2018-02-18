<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmnaikkelas
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
        Me.datagridkelaslama = New System.Windows.Forms.DataGridView()
        Me.datagridkelasbaru = New System.Windows.Forms.DataGridView()
        Me.cbokelaslama = New System.Windows.Forms.ComboBox()
        Me.cbotalama = New System.Windows.Forms.ComboBox()
        Me.cbotabaru = New System.Windows.Forms.ComboBox()
        Me.cbokelasbaru = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnnaik = New System.Windows.Forms.Button()
        Me.btnturun = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.datagridkelaslama, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datagridkelasbaru, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datagridkelaslama
        '
        Me.datagridkelaslama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridkelaslama.Location = New System.Drawing.Point(12, 96)
        Me.datagridkelaslama.Name = "datagridkelaslama"
        Me.datagridkelaslama.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datagridkelaslama.Size = New System.Drawing.Size(432, 412)
        Me.datagridkelaslama.TabIndex = 0
        '
        'datagridkelasbaru
        '
        Me.datagridkelasbaru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridkelasbaru.Location = New System.Drawing.Point(519, 96)
        Me.datagridkelasbaru.Name = "datagridkelasbaru"
        Me.datagridkelasbaru.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datagridkelasbaru.Size = New System.Drawing.Size(432, 412)
        Me.datagridkelasbaru.TabIndex = 1
        '
        'cbokelaslama
        '
        Me.cbokelaslama.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbokelaslama.FormattingEnabled = True
        Me.cbokelaslama.Location = New System.Drawing.Point(90, 58)
        Me.cbokelaslama.Name = "cbokelaslama"
        Me.cbokelaslama.Size = New System.Drawing.Size(121, 25)
        Me.cbokelaslama.TabIndex = 2
        '
        'cbotalama
        '
        Me.cbotalama.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotalama.FormattingEnabled = True
        Me.cbotalama.Location = New System.Drawing.Point(323, 58)
        Me.cbotalama.Name = "cbotalama"
        Me.cbotalama.Size = New System.Drawing.Size(121, 25)
        Me.cbotalama.TabIndex = 3
        '
        'cbotabaru
        '
        Me.cbotabaru.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotabaru.FormattingEnabled = True
        Me.cbotabaru.Location = New System.Drawing.Point(830, 58)
        Me.cbotabaru.Name = "cbotabaru"
        Me.cbotabaru.Size = New System.Drawing.Size(121, 25)
        Me.cbotabaru.TabIndex = 5
        '
        'cbokelasbaru
        '
        Me.cbokelasbaru.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbokelasbaru.FormattingEnabled = True
        Me.cbokelasbaru.Location = New System.Drawing.Point(603, 58)
        Me.cbokelasbaru.Name = "cbokelasbaru"
        Me.cbokelasbaru.Size = New System.Drawing.Size(121, 25)
        Me.cbokelasbaru.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Transparent
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(921, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 23)
        Me.Button2.TabIndex = 123
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnnaik
        '
        Me.btnnaik.Location = New System.Drawing.Point(460, 245)
        Me.btnnaik.Name = "btnnaik"
        Me.btnnaik.Size = New System.Drawing.Size(43, 30)
        Me.btnnaik.TabIndex = 124
        Me.btnnaik.Text = ">"
        Me.btnnaik.UseVisualStyleBackColor = True
        '
        'btnturun
        '
        Me.btnturun.Location = New System.Drawing.Point(460, 294)
        Me.btnturun.Name = "btnturun"
        Me.btnturun.Size = New System.Drawing.Size(43, 30)
        Me.btnturun.TabIndex = 125
        Me.btnturun.Text = "<"
        Me.btnturun.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 20)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Kelas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(267, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 20)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "T/A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(526, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 20)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "Kelas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 11.0!)
        Me.Label4.Location = New System.Drawing.Point(778, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 20)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "T/A"
        '
        'frmnaikkelas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(963, 520)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnturun)
        Me.Controls.Add(Me.btnnaik)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cbotabaru)
        Me.Controls.Add(Me.cbokelasbaru)
        Me.Controls.Add(Me.cbotalama)
        Me.Controls.Add(Me.cbokelaslama)
        Me.Controls.Add(Me.datagridkelasbaru)
        Me.Controls.Add(Me.datagridkelaslama)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmnaikkelas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmnaikkelas"
        Me.TopMost = True
        CType(Me.datagridkelaslama, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datagridkelasbaru, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents datagridkelaslama As DataGridView
    Friend WithEvents datagridkelasbaru As DataGridView
    Friend WithEvents cbokelaslama As ComboBox
    Friend WithEvents cbotalama As ComboBox
    Friend WithEvents cbotabaru As ComboBox
    Friend WithEvents cbokelasbaru As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents btnnaik As Button
    Friend WithEvents btnturun As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class

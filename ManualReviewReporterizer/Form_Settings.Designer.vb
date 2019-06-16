<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Settings))
        Me.TextBox_Company_Name = New System.Windows.Forms.TextBox()
        Me.Label_Company_Name = New System.Windows.Forms.Label()
        Me.Button_Go = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox_Company_Name
        '
        Me.TextBox_Company_Name.Location = New System.Drawing.Point(127, 19)
        Me.TextBox_Company_Name.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_Company_Name.Name = "TextBox_Company_Name"
        Me.TextBox_Company_Name.Size = New System.Drawing.Size(392, 22)
        Me.TextBox_Company_Name.TabIndex = 0
        '
        'Label_Company_Name
        '
        Me.Label_Company_Name.AutoSize = True
        Me.Label_Company_Name.Location = New System.Drawing.Point(13, 19)
        Me.Label_Company_Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Company_Name.Name = "Label_Company_Name"
        Me.Label_Company_Name.Size = New System.Drawing.Size(106, 16)
        Me.Label_Company_Name.TabIndex = 1
        Me.Label_Company_Name.Text = "Company Name"
        '
        'Button_Go
        '
        Me.Button_Go.BackColor = System.Drawing.Color.MistyRose
        Me.Button_Go.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Go.Location = New System.Drawing.Point(413, 128)
        Me.Button_Go.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Go.Name = "Button_Go"
        Me.Button_Go.Size = New System.Drawing.Size(106, 29)
        Me.Button_Go.TabIndex = 8
        Me.Button_Go.Text = "Save"
        Me.Button_Go.UseVisualStyleBackColor = False
        '
        'Form_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(530, 167)
        Me.Controls.Add(Me.Button_Go)
        Me.Controls.Add(Me.Label_Company_Name)
        Me.Controls.Add(Me.TextBox_Company_Name)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form_Settings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox_Company_Name As TextBox
    Friend WithEvents Label_Company_Name As Label
    Friend WithEvents Button_Go As Button
End Class

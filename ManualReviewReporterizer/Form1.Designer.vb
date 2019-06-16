<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button_Go = New System.Windows.Forms.Button()
        Me.TextBox_Case_REF = New System.Windows.Forms.TextBox()
        Me.Label_Case_REF = New System.Windows.Forms.Label()
        Me.Label_examiner_name = New System.Windows.Forms.Label()
        Me.TextBox_Examiner_name = New System.Windows.Forms.TextBox()
        Me.Label_Save_Location = New System.Windows.Forms.Label()
        Me.TextBox_save_location = New System.Windows.Forms.TextBox()
        Me.Label_Drap_Drop = New System.Windows.Forms.Label()
        Me.Label_Page_Header = New System.Windows.Forms.Label()
        Me.TextBox_Page_Header = New System.Windows.Forms.TextBox()
        Me.Label_Selected_Files = New System.Windows.Forms.Label()
        Me.Label_date_of_ME = New System.Windows.Forms.Label()
        Me.Button_Open_Folder = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TextBox_Date_of_ME = New System.Windows.Forms.MaskedTextBox()
        Me.ProgressBar_Overall = New System.Windows.Forms.ProgressBar()
        Me.CheckBox_Rotate = New System.Windows.Forms.CheckBox()
        Me.ComboBox_per_Page = New System.Windows.Forms.ComboBox()
        Me.Label_per_page = New System.Windows.Forms.Label()
        Me.TextBox_Comments = New System.Windows.Forms.TextBox()
        Me.CheckBox_Comments = New System.Windows.Forms.CheckBox()
        Me.Label_Comments = New System.Windows.Forms.Label()
        Me.Label_Coment_photos = New System.Windows.Forms.Label()
        Me.PictureBox_Image_Display = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button_add_comment = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListBox_Selected_Files = New System.Windows.Forms.CheckedListBox()
        Me.Label_Ignore_Tickboxes = New System.Windows.Forms.Label()
        Me.CheckBox_90 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_270 = New System.Windows.Forms.CheckBox()
        Me.PictureBox_settings = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_Image_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox_settings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Go
        '
        Me.Button_Go.BackColor = System.Drawing.Color.MistyRose
        Me.Button_Go.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Go.Location = New System.Drawing.Point(12, 498)
        Me.Button_Go.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Go.Name = "Button_Go"
        Me.Button_Go.Size = New System.Drawing.Size(702, 38)
        Me.Button_Go.TabIndex = 7
        Me.Button_Go.Text = "Reportorize....."
        Me.Button_Go.UseVisualStyleBackColor = False
        '
        'TextBox_Case_REF
        '
        Me.TextBox_Case_REF.Location = New System.Drawing.Point(12, 113)
        Me.TextBox_Case_REF.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Case_REF.Name = "TextBox_Case_REF"
        Me.TextBox_Case_REF.Size = New System.Drawing.Size(265, 22)
        Me.TextBox_Case_REF.TabIndex = 1
        '
        'Label_Case_REF
        '
        Me.Label_Case_REF.AutoSize = True
        Me.Label_Case_REF.Location = New System.Drawing.Point(12, 93)
        Me.Label_Case_REF.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Case_REF.Name = "Label_Case_REF"
        Me.Label_Case_REF.Size = New System.Drawing.Size(109, 16)
        Me.Label_Case_REF.TabIndex = 2
        Me.Label_Case_REF.Text = "Case Reference:"
        '
        'Label_examiner_name
        '
        Me.Label_examiner_name.AutoSize = True
        Me.Label_examiner_name.Location = New System.Drawing.Point(12, 206)
        Me.Label_examiner_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_examiner_name.Name = "Label_examiner_name"
        Me.Label_examiner_name.Size = New System.Drawing.Size(107, 16)
        Me.Label_examiner_name.TabIndex = 4
        Me.Label_examiner_name.Text = "Examiner Name:"
        '
        'TextBox_Examiner_name
        '
        Me.TextBox_Examiner_name.Location = New System.Drawing.Point(12, 226)
        Me.TextBox_Examiner_name.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Examiner_name.Name = "TextBox_Examiner_name"
        Me.TextBox_Examiner_name.Size = New System.Drawing.Size(265, 22)
        Me.TextBox_Examiner_name.TabIndex = 3
        '
        'Label_Save_Location
        '
        Me.Label_Save_Location.AutoSize = True
        Me.Label_Save_Location.Location = New System.Drawing.Point(12, 445)
        Me.Label_Save_Location.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Save_Location.Name = "Label_Save_Location"
        Me.Label_Save_Location.Size = New System.Drawing.Size(177, 16)
        Me.Label_Save_Location.TabIndex = 6
        Me.Label_Save_Location.Text = "Save Location (no filename):"
        '
        'TextBox_save_location
        '
        Me.TextBox_save_location.Location = New System.Drawing.Point(13, 466)
        Me.TextBox_save_location.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_save_location.Name = "TextBox_save_location"
        Me.TextBox_save_location.Size = New System.Drawing.Size(675, 22)
        Me.TextBox_save_location.TabIndex = 6
        '
        'Label_Drap_Drop
        '
        Me.Label_Drap_Drop.AllowDrop = True
        Me.Label_Drap_Drop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Drap_Drop.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label_Drap_Drop.Location = New System.Drawing.Point(13, 9)
        Me.Label_Drap_Drop.Name = "Label_Drap_Drop"
        Me.Label_Drap_Drop.Size = New System.Drawing.Size(683, 74)
        Me.Label_Drap_Drop.TabIndex = 7
        Me.Label_Drap_Drop.Text = "Drag Photos Here"
        Me.Label_Drap_Drop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Page_Header
        '
        Me.Label_Page_Header.AutoSize = True
        Me.Label_Page_Header.Location = New System.Drawing.Point(12, 262)
        Me.Label_Page_Header.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Page_Header.Name = "Label_Page_Header"
        Me.Label_Page_Header.Size = New System.Drawing.Size(178, 16)
        Me.Label_Page_Header.TabIndex = 9
        Me.Label_Page_Header.Text = "Report Name/Page Header:"
        '
        'TextBox_Page_Header
        '
        Me.TextBox_Page_Header.Location = New System.Drawing.Point(12, 282)
        Me.TextBox_Page_Header.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Page_Header.Name = "TextBox_Page_Header"
        Me.TextBox_Page_Header.Size = New System.Drawing.Size(265, 22)
        Me.TextBox_Page_Header.TabIndex = 4
        '
        'Label_Selected_Files
        '
        Me.Label_Selected_Files.AutoSize = True
        Me.Label_Selected_Files.Location = New System.Drawing.Point(292, 91)
        Me.Label_Selected_Files.Name = "Label_Selected_Files"
        Me.Label_Selected_Files.Size = New System.Drawing.Size(97, 16)
        Me.Label_Selected_Files.TabIndex = 11
        Me.Label_Selected_Files.Text = "Selected Files:"
        '
        'Label_date_of_ME
        '
        Me.Label_date_of_ME.AutoSize = True
        Me.Label_date_of_ME.Location = New System.Drawing.Point(12, 149)
        Me.Label_date_of_ME.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_date_of_ME.Name = "Label_date_of_ME"
        Me.Label_date_of_ME.Size = New System.Drawing.Size(223, 16)
        Me.Label_date_of_ME.TabIndex = 14
        Me.Label_date_of_ME.Text = "Date of Manual Exam (yyyy-mm-dd):"
        '
        'Button_Open_Folder
        '
        Me.Button_Open_Folder.BackColor = System.Drawing.Color.MistyRose
        Me.Button_Open_Folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Open_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Open_Folder.Location = New System.Drawing.Point(691, 466)
        Me.Button_Open_Folder.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Open_Folder.Name = "Button_Open_Folder"
        Me.Button_Open_Folder.Size = New System.Drawing.Size(22, 22)
        Me.Button_Open_Folder.TabIndex = 8
        Me.Button_Open_Folder.Text = ":"
        Me.Button_Open_Folder.UseVisualStyleBackColor = False
        '
        'TextBox_Date_of_ME
        '
        Me.TextBox_Date_of_ME.Location = New System.Drawing.Point(12, 168)
        Me.TextBox_Date_of_ME.Mask = "0000-00-00"
        Me.TextBox_Date_of_ME.Name = "TextBox_Date_of_ME"
        Me.TextBox_Date_of_ME.Size = New System.Drawing.Size(263, 22)
        Me.TextBox_Date_of_ME.TabIndex = 2
        '
        'ProgressBar_Overall
        '
        Me.ProgressBar_Overall.Location = New System.Drawing.Point(12, 543)
        Me.ProgressBar_Overall.Name = "ProgressBar_Overall"
        Me.ProgressBar_Overall.Size = New System.Drawing.Size(702, 10)
        Me.ProgressBar_Overall.TabIndex = 15
        '
        'CheckBox_Rotate
        '
        Me.CheckBox_Rotate.AutoSize = True
        Me.CheckBox_Rotate.Checked = True
        Me.CheckBox_Rotate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Rotate.Location = New System.Drawing.Point(12, 381)
        Me.CheckBox_Rotate.Name = "CheckBox_Rotate"
        Me.CheckBox_Rotate.Size = New System.Drawing.Size(174, 20)
        Me.CheckBox_Rotate.TabIndex = 5
        Me.CheckBox_Rotate.Text = "Rotate Images to Portrait"
        Me.CheckBox_Rotate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox_Rotate.ThreeState = True
        Me.CheckBox_Rotate.UseVisualStyleBackColor = True
        '
        'ComboBox_per_Page
        '
        Me.ComboBox_per_Page.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_per_Page.FormattingEnabled = True
        Me.ComboBox_per_Page.Location = New System.Drawing.Point(198, 344)
        Me.ComboBox_per_Page.Name = "ComboBox_per_Page"
        Me.ComboBox_per_Page.Size = New System.Drawing.Size(71, 24)
        Me.ComboBox_per_Page.TabIndex = 16
        '
        'Label_per_page
        '
        Me.Label_per_page.AutoSize = True
        Me.Label_per_page.Location = New System.Drawing.Point(11, 347)
        Me.Label_per_page.Name = "Label_per_page"
        Me.Label_per_page.Size = New System.Drawing.Size(181, 16)
        Me.Label_per_page.TabIndex = 17
        Me.Label_per_page.Text = "Number of Images Per Page:"
        '
        'TextBox_Comments
        '
        Me.TextBox_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Comments.Location = New System.Drawing.Point(6, 100)
        Me.TextBox_Comments.Multiline = True
        Me.TextBox_Comments.Name = "TextBox_Comments"
        Me.TextBox_Comments.Size = New System.Drawing.Size(333, 254)
        Me.TextBox_Comments.TabIndex = 18
        '
        'CheckBox_Comments
        '
        Me.CheckBox_Comments.AutoSize = True
        Me.CheckBox_Comments.Location = New System.Drawing.Point(14, 316)
        Me.CheckBox_Comments.Name = "CheckBox_Comments"
        Me.CheckBox_Comments.Size = New System.Drawing.Size(175, 20)
        Me.CheckBox_Comments.TabIndex = 19
        Me.CheckBox_Comments.Text = "Add coments to images?"
        Me.CheckBox_Comments.UseVisualStyleBackColor = True
        '
        'Label_Comments
        '
        Me.Label_Comments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Comments.Location = New System.Drawing.Point(0, 1)
        Me.Label_Comments.Name = "Label_Comments"
        Me.Label_Comments.Size = New System.Drawing.Size(346, 37)
        Me.Label_Comments.TabIndex = 20
        Me.Label_Comments.Text = "Selet photo from the list and add a comment here (for landscape photos, max 4 lin" &
    "es)"
        Me.Label_Comments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Coment_photos
        '
        Me.Label_Coment_photos.AutoSize = True
        Me.Label_Coment_photos.Location = New System.Drawing.Point(7, 56)
        Me.Label_Coment_photos.Name = "Label_Coment_photos"
        Me.Label_Coment_photos.Size = New System.Drawing.Size(147, 16)
        Me.Label_Coment_photos.TabIndex = 21
        Me.Label_Coment_photos.Text = "Select a Photo to Begin"
        '
        'PictureBox_Image_Display
        '
        Me.PictureBox_Image_Display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox_Image_Display.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_Image_Display.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_Image_Display.Name = "PictureBox_Image_Display"
        Me.PictureBox_Image_Display.Size = New System.Drawing.Size(344, 153)
        Me.PictureBox_Image_Display.TabIndex = 22
        Me.PictureBox_Image_Display.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(720, 9)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_add_comment)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_Comments)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_Comments)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_Coment_photos)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox_Image_Display)
        Me.SplitContainer1.Size = New System.Drawing.Size(346, 544)
        Me.SplitContainer1.SplitterDistance = 385
        Me.SplitContainer1.TabIndex = 23
        '
        'Button_add_comment
        '
        Me.Button_add_comment.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button_add_comment.Location = New System.Drawing.Point(5, 356)
        Me.Button_add_comment.Name = "Button_add_comment"
        Me.Button_add_comment.Size = New System.Drawing.Size(336, 23)
        Me.Button_add_comment.TabIndex = 22
        Me.Button_add_comment.Text = "Add Comment"
        Me.Button_add_comment.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(128, 128)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ListBox_Selected_Files
        '
        Me.ListBox_Selected_Files.AllowDrop = True
        Me.ListBox_Selected_Files.FormattingEnabled = True
        Me.ListBox_Selected_Files.HorizontalScrollbar = True
        Me.ListBox_Selected_Files.Location = New System.Drawing.Point(293, 130)
        Me.ListBox_Selected_Files.Name = "ListBox_Selected_Files"
        Me.ListBox_Selected_Files.Size = New System.Drawing.Size(420, 327)
        Me.ListBox_Selected_Files.TabIndex = 24
        '
        'Label_Ignore_Tickboxes
        '
        Me.Label_Ignore_Tickboxes.AutoSize = True
        Me.Label_Ignore_Tickboxes.Location = New System.Drawing.Point(294, 110)
        Me.Label_Ignore_Tickboxes.Name = "Label_Ignore_Tickboxes"
        Me.Label_Ignore_Tickboxes.Size = New System.Drawing.Size(414, 16)
        Me.Label_Ignore_Tickboxes.TabIndex = 25
        Me.Label_Ignore_Tickboxes.Text = "(ignore tickboxes unless selectively rotating images using checkbox)"
        '
        'CheckBox_90
        '
        Me.CheckBox_90.AutoSize = True
        Me.CheckBox_90.Checked = True
        Me.CheckBox_90.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_90.Location = New System.Drawing.Point(12, 419)
        Me.CheckBox_90.Name = "CheckBox_90"
        Me.CheckBox_90.Size = New System.Drawing.Size(45, 20)
        Me.CheckBox_90.TabIndex = 26
        Me.CheckBox_90.Text = "90°"
        Me.CheckBox_90.UseVisualStyleBackColor = True
        '
        'CheckBox_270
        '
        Me.CheckBox_270.AutoSize = True
        Me.CheckBox_270.Location = New System.Drawing.Point(63, 419)
        Me.CheckBox_270.Name = "CheckBox_270"
        Me.CheckBox_270.Size = New System.Drawing.Size(52, 20)
        Me.CheckBox_270.TabIndex = 27
        Me.CheckBox_270.Text = "270°"
        Me.CheckBox_270.UseVisualStyleBackColor = True
        '
        'PictureBox_settings
        '
        Me.PictureBox_settings.BackgroundImage = CType(resources.GetObject("PictureBox_settings.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox_settings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox_settings.Location = New System.Drawing.Point(696, 9)
        Me.PictureBox_settings.Name = "PictureBox_settings"
        Me.PictureBox_settings.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox_settings.TabIndex = 28
        Me.PictureBox_settings.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(720, 561)
        Me.Controls.Add(Me.PictureBox_settings)
        Me.Controls.Add(Me.CheckBox_270)
        Me.Controls.Add(Me.CheckBox_90)
        Me.Controls.Add(Me.Label_Ignore_Tickboxes)
        Me.Controls.Add(Me.ListBox_Selected_Files)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.CheckBox_Comments)
        Me.Controls.Add(Me.Label_per_page)
        Me.Controls.Add(Me.ComboBox_per_Page)
        Me.Controls.Add(Me.CheckBox_Rotate)
        Me.Controls.Add(Me.ProgressBar_Overall)
        Me.Controls.Add(Me.TextBox_Date_of_ME)
        Me.Controls.Add(Me.Button_Open_Folder)
        Me.Controls.Add(Me.Label_date_of_ME)
        Me.Controls.Add(Me.Label_Selected_Files)
        Me.Controls.Add(Me.Label_Page_Header)
        Me.Controls.Add(Me.TextBox_Page_Header)
        Me.Controls.Add(Me.Label_Drap_Drop)
        Me.Controls.Add(Me.Label_Save_Location)
        Me.Controls.Add(Me.TextBox_save_location)
        Me.Controls.Add(Me.Label_examiner_name)
        Me.Controls.Add(Me.TextBox_Examiner_name)
        Me.Controls.Add(Me.Label_Case_REF)
        Me.Controls.Add(Me.TextBox_Case_REF)
        Me.Controls.Add(Me.Button_Go)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(1090, 600)
        Me.MinimumSize = New System.Drawing.Size(736, 600)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manual Review Reporter v1.6"
        CType(Me.PictureBox_Image_Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox_settings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Go As Button
    Friend WithEvents TextBox_Case_REF As TextBox
    Friend WithEvents Label_Case_REF As Label
    Friend WithEvents Label_examiner_name As Label
    Friend WithEvents TextBox_Examiner_name As TextBox
    Friend WithEvents Label_Save_Location As Label
    Friend WithEvents TextBox_save_location As TextBox
    Friend WithEvents Label_Drap_Drop As Label
    Friend WithEvents Label_Page_Header As Label
    Friend WithEvents TextBox_Page_Header As TextBox
    Friend WithEvents Label_Selected_Files As Label
    Friend WithEvents Label_date_of_ME As Label
    Friend WithEvents Button_Open_Folder As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents TextBox_Date_of_ME As MaskedTextBox
    Friend WithEvents ProgressBar_Overall As ProgressBar
    Friend WithEvents CheckBox_Rotate As CheckBox
    Friend WithEvents ComboBox_per_Page As ComboBox
    Friend WithEvents Label_per_page As Label
    Friend WithEvents TextBox_Comments As TextBox
    Friend WithEvents CheckBox_Comments As CheckBox
    Friend WithEvents Label_Comments As Label
    Friend WithEvents Label_Coment_photos As Label
    Friend WithEvents PictureBox_Image_Display As PictureBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Button_add_comment As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ListBox_Selected_Files As CheckedListBox
    Friend WithEvents Label_Ignore_Tickboxes As Label
    Friend WithEvents CheckBox_90 As CheckBox
    Friend WithEvents CheckBox_270 As CheckBox
    Friend WithEvents PictureBox_settings As PictureBox
End Class

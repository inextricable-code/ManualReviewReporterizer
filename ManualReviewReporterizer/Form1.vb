Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports System.IO

Public Class Form1

    '##########################################################
    '#                DECLARE GLOBAL VARIABLES                #
    '##########################################################
    Dim comments_dic As New Dictionary(Of String, String)
    Dim picture_id As New Dictionary(Of String, Int16)


    '##########################################################
    '# Sub Name: Button_Go_Click                              #
    '# Passed Variables: none                                 #
    '# Purpose: Ensures all the textboxes have been filled in #
    '#          correctly. Calls to steralise filename, Calls #
    '#          main program to write the pdf etc             #
    '##########################################################
    Private Sub Button_Go_Click(sender As Object, e As EventArgs) Handles Button_Go.Click
        If TextBox_save_location.Text = "" Or TextBox_Date_of_ME.Text = "" Or TextBox_DFU_REF.Text = "" Or TextBox_Examiner_name.Text = "" Or TextBox_Page_Header.Text = "" Then
            MsgBox("Fill out all the details", MsgBoxStyle.OkOnly, "Don't be lazy")
        Else
            Dim pics_per_page As Int16 = ComboBox_per_Page.Text

            Dim filename As String = TextBox_Page_Header.Text & ".pdf"
            'gets the usable filename
            filename = get_usable_filename(filename)

            If File.Exists(TextBox_save_location.Text & "\" & filename) Then
                If MsgBox("A report already exists in this location called this, do you want to overwrite?", vbYesNo, "File already Exists") = vbYes Then
                    main_run(filename, pics_per_page)
                Else
                    Exit Sub
                End If

            Else
                main_run(filename, pics_per_page)
            End If

        End If

    End Sub


    '############################################################
    '# Sub Name: main_run                                       #
    '# Passed Variables: filename as string                     #
    '#                   pics_per_page as integer               #
    '# Purpose: Sets up the list of picture names, and the list #
    '#          of rotation (if needed). Creates Progress bar   #
    '#          Calls "run_in_thread", the main program in a    #
    '#          seperate thread to keep GUI from freezing       #
    '############################################################
    Private Sub main_run(filename, pics_per_page)

        'gets the selected images into a list
        Dim picture_list As New List(Of String)
        Dim rotate_list As New List(Of Integer)
        'if its selective choice, needs to know which ones are meant to be turned
        If CheckBox_Rotate.CheckState = CheckState.Indeterminate Then
            Dim i As Integer = 0
            For Each path In ListBox_Selected_Files.Items
                picture_list.Add(path)
                rotate_list.Add(ListBox_Selected_Files.GetItemCheckState(i))
                i = i + 1
            Next
        Else
            For Each path In ListBox_Selected_Files.Items
                picture_list.Add(path)
            Next
        End If

        ProgressBar_Overall.Maximum = picture_list.Count

        'runs the main programme in a seperate thread
        Task.Factory.StartNew(Sub()
                                  run_in_thread(filename, picture_list, pics_per_page, rotate_list)
                              End Sub)
    End Sub


    '############################################################
    '# Function Name: get_usable_filename                       #
    '# Passed Variables: filename as string                     #
    '# Returned Variables: filename as string                   #
    '# Purpose: Replaces the chars you can't use in a filename  #
    '#          with ones you can, returns sanatised filename   #
    '############################################################
    Private Function get_usable_filename(filename)
        filename = filename.Replace("/", "-")
        filename = filename.Replace("\", "-")
        filename = filename.Replace(":", "_")
        filename = filename.Replace("*", "_")
        filename = filename.Replace("?", "_")
        filename = filename.Replace("""", "_")
        filename = filename.Replace("<", "_")
        filename = filename.Replace(">", "_")
        filename = filename.Replace("|", "_")
        Return filename
    End Function


    '##########################################################
    '# Sub Name: update_progressB                             #
    '# Passed Variables: i as int, maximum as int             #
    '# Purpose: Takes the maximum progress bar value, and the #
    '#          current value and upades the bar - done in a  #
    '#          different sub/thread as it updates the form   #
    '##########################################################
    Private Sub update_progressB(i, maximum)
        If i <= maximum Then
            Try
                ProgressBar_Overall.Value = i
            Catch squid As Exception
            End Try
        End If
    End Sub


    '########################################################
    '# Sub Name: unlock_form                                #
    '# Passed Variables: unlock_form as booleon             #
    '# Purpose: Locks or unlocks the form feature based on  #
    '#          the booleon value passed                    #
    '########################################################
    Private Sub unlock_form(lock_unlock)
        TextBox_Date_of_ME.Enabled = lock_unlock
        TextBox_DFU_REF.Enabled = lock_unlock
        TextBox_Examiner_name.Enabled = lock_unlock
        TextBox_Page_Header.Enabled = lock_unlock
        TextBox_save_location.Enabled = lock_unlock
        Button_Go.Enabled = lock_unlock
        CheckBox_Rotate.Enabled = lock_unlock
        Button_Open_Folder.Enabled = lock_unlock
        ComboBox_per_Page.Enabled = lock_unlock
        CheckBox_Comments.Enabled = lock_unlock
        CheckBox_90.Enabled = lock_unlock
        CheckBox_270.Enabled = lock_unlock
    End Sub


    '############################################################
    '# Sub Name: run_in_thread                                  #
    '# Passed Variables: filename as string                     #
    '#                   picture_list as list                   #
    '#                   pics_per_page as integer               #
    '#                   rotate_list as list                    #
    '# Purpose: Creates the PDF, sets up the fonts,             #
    '#          Calls to write pictures to the pdf              #
    '#          Calls to update the progress bar                #
    '#          Calls to lock the form                          #
    '#          Calls to write front page                       #
    '#          Calls to write file name                        #
    '#          Calls to write comments                         #
    '#          Calls to save document                          #
    '############################################################
    Private Sub run_in_thread(filename, picture_list, pics_per_page, rotate_list)

        Invoke(Sub()
                   unlock_form(False)
               End Sub)

        'creates the new document and fonts/pens etc
        Dim document As PdfDocument = New PdfDocument
        document.Info.Title = My.Settings.company_name
        Dim font As XFont = New XFont("Verdana", 20, XFontStyle.Bold)
        Dim footer_font As XFont = New XFont("Verdana", 10, XFontStyle.Bold)
        Dim header_text As String = TextBox_Page_Header.Text
        Dim pen As XPen = New XPen(XColor.FromArgb(39, 58, 124))

        'creates the title/front page
        write_title_page(header_text, document, pen)

        Dim i As Int16 = 0 'this is for the index
        Dim v As Int16 = 1 'this is for the pagenumbers
        Dim x As Int16 = 1 'progress bar counter
        Dim double_page_amount As Double = picture_list.Count / pics_per_page 'this finds the total page numbers
        Dim page_amount As Int16 = Math.Ceiling(double_page_amount) 'rounds up to the next full number (so you don't end up with 4/3.5 pages)

        Dim transform_degree As Integer

        If CheckBox_90.Checked = True Then
            transform_degree = 90
        Else
            transform_degree = 270
        End If

        While i < picture_list.Count

            Dim page As PdfPage = document.AddPage
            page.Orientation = page.Orientation.Landscape
            Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
            gfx.DrawString(header_text, font, XBrushes.Black, New XRect(0, 20, page.Width.Point, page.Height.Point), XStringFormats.TopCenter)
            gfx.DrawLine(pen, New XPoint(0, 562), New XPoint(850, 562))
            gfx.DrawString("Page: " & v & " of " & page_amount, footer_font, XBrushes.Black, New XRect(0, -20, page.Width.Point, page.Height.Point), XStringFormats.BottomCenter)

            'write the filename on the page
            ' write_file_name(picture_list, i, pics_per_page, page, gfx, footer_font)

            If CheckBox_Comments.Checked = True Then 'if they DO want to add comments
                write_comments(gfx, picture_list, i, footer_font)
            End If
            'dispose the text stuff
            gfx.Dispose()

            If pics_per_page = "2" Then 'if they want 2 on a page, do this
                write_two_images(picture_list, i, page, transform_degree, rotate_list, footer_font)
                i = i + 2 'add two on as its added two pictures
                v = v + 1 'page number only goes up by one
            Else 'if they only want one on a page, do this
                write_one_image(picture_list, i, page, transform_degree, rotate_list, footer_font)
                i = i + 1 'add 1 on as its added 1 picture
                v = v + 1 'page number only goes up by one
            End If

            Invoke(Sub()
                       update_progressB(i, picture_list.count)
                   End Sub)
        End While

        'force the progress bar to 100% at the end
        Invoke(Sub()
                   update_progressB(picture_list.count, picture_list.count)
               End Sub)

        'save the pdf file
        save_pdf(filename, document)
    End Sub


    '##########################################################
    '# Sub Name: write_one_image                              #
    '# Passed Variables: picture_list as list                 #
    '#                   i as integer                         #
    '#                   page as Xpage (pdf page)             #
    '#                   transform_degree as integer          #
    '#                   rotate_list as list                  #
    '# Purpose: writes ONE image per pdf page                 #
    '##########################################################
    Private Sub write_one_image(picture_list, i, page, transform_degree, rotate_list, footer_font)

        '### SET UP THE FILE LOCATION ###
        Dim file_name_location_x
        Dim file_name_location_y
        '### END SET UP THE FILE LOCATION ###

        '################# Get aspect Ratio of File #########################
        Dim img_size As Image = Image.FromFile(picture_list(i))
        Dim img_longest
        Dim img_shortest
        'Find the largest one
        If img_size.Width > img_size.Height Then
            img_longest = img_size.Width
            img_shortest = img_size.Height
        Else
            img_shortest = img_size.Width
            img_longest = img_size.Height
        End If
        Dim ratio = img_longest / img_shortest
        '################# Get aspect Ratio of File #########################

        Dim img As XImage
        img = XBitmapSource.FromFile(picture_list(i))
        Dim xgr = PdfSharp.Drawing.XGraphics.FromPdfPage(page)
        '############ NO COMMENTS #####################
        If CheckBox_Comments.Checked = False Then 'if they DON'T want to add comments

            If CheckBox_Rotate.CheckState = CheckState.Checked Then
                xgr.RotateTransform(transform_degree)
                Dim shrtside = 460 / ratio
                If transform_degree = 90 Then
                    Dim location = -427.5 - (shrtside / 2)
                    xgr.DrawImage(img, 60, location, 460, shrtside)

                    file_name_location_x = shrtside + ((427.5 - shrtside) - (shrtside / 2))
                    file_name_location_y = 460 + 60
                Else
                    Dim location = 422.5 - (shrtside / 2)
                    xgr.DrawImage(img, -520, location, 460, shrtside)

                    file_name_location_x = shrtside + ((422 - shrtside) - (shrtside / 2))
                    file_name_location_y = 460 + 60
                End If

            ElseIf CheckBox_Rotate.CheckState = CheckState.Indeterminate Then
                If rotate_list(i) = 1 Then 'if the picture is checked to be rotated
                    xgr.RotateTransform(transform_degree)
                    Dim shrtside = 460 / ratio
                    If transform_degree = 90 Then
                        Dim location = -427.5 - (shrtside / 2)
                        xgr.DrawImage(img, 60, location, 460, shrtside)
                        file_name_location_x = shrtside + ((427.5 - shrtside) - (shrtside / 2))
                        file_name_location_y = 460 + 60
                    Else
                        Dim location = 422.5 - (shrtside / 2)
                        xgr.DrawImage(img, -520, location, 460, shrtside)
                        file_name_location_x = shrtside + ((422 - shrtside) - (shrtside / 2))
                        file_name_location_y = 460 + 60
                    End If
                Else
                    Dim shrtside = 600 / ratio
                    Dim location = 293 - (shrtside / 2)
                    xgr.DrawImage(img, 135, location, 625, shrtside)
                    file_name_location_x = 135
                    file_name_location_y = location + shrtside
                End If

            Else 'if its not rotated
                Dim shrtside = 600 / ratio
                Dim location = 293 - (shrtside / 2)
                xgr.DrawImage(img, 135, location, 600, shrtside)
                file_name_location_x = 135
                file_name_location_y = location + shrtside
            End If

        Else 'if they DO want to add comments

            If CheckBox_Rotate.Checked = True Then 'so this is portrait
                xgr.RotateTransform(transform_degree)
                '''''''''''''first one is distane frm top -> increase to make further from top (increase negative number, i.e. -510 is further that -500)
                '''''''''''''second one is the distace from left hand decrease to make it closer to the left (closer to the left edge)
                Dim shrtside = 460 / ratio
                If transform_degree = 90 Then
                    Dim location = -227.5 - (shrtside / 2)
                    xgr.DrawImage(img, 60, location, 460, shrtside)
                    file_name_location_x = shrtside + ((227.5 - shrtside) - (shrtside / 2))
                    file_name_location_y = 460 + 60
                Else
                    Dim location = 210 - (shrtside / 2)
                    xgr.DrawImage(img, -520, location, 460, shrtside)
                    file_name_location_x = shrtside + ((210 - shrtside) - (shrtside / 2))
                    file_name_location_y = 460 + 60
                End If

            Else 'if its landscape
                Dim shrtside = 500 / ratio
                Dim location = 255 - (shrtside / 2)
                xgr.DrawImage(img, 150, location, 500, shrtside)

                file_name_location_x = 150
                file_name_location_y = location + shrtside
            End If

        End If

        img.Dispose()
        xgr.Dispose()
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        write_single_file_name(picture_list, i, page, gfx, footer_font, file_name_location_x, file_name_location_y)

    End Sub


    '##########################################################
    '# Sub Name: write_two_images                             #
    '# Passed Variables: picture_list as list                 #
    '#                   i as integer                         #
    '#                   page as Xpage (pdf page)             #
    '#                   transform_degree as integer          #
    '#                   rotate_list as list                  #
    '# Purpose: writes TWO images on the pdf page             #
    '##########################################################
    Private Sub write_two_images(picture_list, i, page, transform_degree, rotate_list, footer_font)
        '################# Get aspect Ratio of File #########################
        Dim img_size As Image = Image.FromFile(picture_list(i))
        Dim img_longest
        Dim img_shortest
        'Find the largest one
        If img_size.Width > img_size.Height Then
            img_longest = img_size.Width
            img_shortest = img_size.Height
        Else
            img_shortest = img_size.Width
            img_longest = img_size.Height
        End If
        Dim ratio = img_longest / img_shortest
        '################# Get aspect Ratio of File #########################

        '### SET UP THE FILE LOCATION ###
        Dim file_name_location_x
        Dim file_name_location_y
        Dim file_name_location_x2
        Dim file_name_location_y2
        '### END SET UP THE FILE LOCATION ###

        Dim img As XImage
        img = XBitmapSource.FromFile(picture_list(i))
        Dim xgr = PdfSharp.Drawing.XGraphics.FromPdfPage(page)
        If CheckBox_Rotate.CheckState = CheckState.Checked Then

            xgr.RotateTransform(transform_degree)
            Dim shrtside = 460 / ratio
            If transform_degree = 90 Then
                Dim location = -227.5 - (shrtside / 2)
                xgr.DrawImage(img, 60, location, 460, shrtside)
                file_name_location_x = shrtside + ((227.5 - shrtside) - (shrtside / 2))
                file_name_location_y = 460 + 60
            Else
                'first one is distane frm top -> increase to make further from top (increase negative number, i.e. -510 is further that -500)
                'second one is the distace from left hand decrease to make it closer to the left (closer to the left edge)
                Dim location = 210 - (shrtside / 2)
                xgr.DrawImage(img, -520, location, 460, shrtside)
                file_name_location_x = shrtside + ((210 - shrtside) - (shrtside / 2))
                file_name_location_y = 460 + 60
            End If


        ElseIf CheckBox_Rotate.CheckState = CheckState.Indeterminate Then
            If rotate_list(i) = 1 Then 'if the picture is checked to be rotated

                xgr.RotateTransform(transform_degree)
                Dim shrtside = 460 / ratio
                If transform_degree = 90 Then
                    Dim location = -227.5 - (shrtside / 2)
                    xgr.DrawImage(img, 60, location, 460, shrtside)
                    file_name_location_x = shrtside + ((227.5 - shrtside) - (shrtside / 2))
                    file_name_location_y = 460 + 60
                Else
                    'first one is distane frm top -> increase to make further from top (increase negative number, i.e. -510 is further that -500)
                    'second one is the distace from left hand decrease to make it closer to the left (closer to the left edge)
                    Dim location = 210 - (shrtside / 2)
                    xgr.DrawImage(img, -520, location, 460, shrtside)
                    file_name_location_x = shrtside + ((210 - shrtside) - (shrtside / 2))
                    file_name_location_y = 460 + 60
                End If

            Else 'if the picture is NOT to be rotated
                Dim shrtside = 390 / ratio
                Dim location = 293 - (shrtside / 2)
                xgr.DrawImage(img, 20, location, 390, shrtside)
                file_name_location_x = 20
                file_name_location_y = location + shrtside
            End If
        Else 'NOT ROTATED
            Dim shrtside = 390 / ratio
            Dim location = 293 - (shrtside / 2)
            xgr.DrawImage(img, 20, location, 390, shrtside)
            file_name_location_x = 20
            file_name_location_y = location + shrtside
        End If
        img.Dispose()
        xgr.Dispose()

        If Not i = picture_list.Count() - 1 Then 'needs to do this so that it doesn't fall over if an odd number of pictures!
            '################# Get aspect Ratio of File #########################
            Dim img_size2 = Image.FromFile(picture_list(i + 1))
            'Find the largest one
            If img_size2.Width > img_size2.Height Then
                img_longest = img_size2.Width
                img_shortest = img_size2.Height
            Else
                img_shortest = img_size2.Width
                img_longest = img_size2.Height
            End If
            ratio = img_longest / img_shortest
            '################# Get aspect Ratio of File #########################

            Dim img2 As XImage
            img2 = XBitmapSource.FromFile(picture_list(i + 1))
            Dim xgr2 = PdfSharp.Drawing.XGraphics.FromPdfPage(page)

            '######## ROTATE ALL SECOND IMAGES ##############
            If CheckBox_Rotate.CheckState = CheckState.Checked Then
                xgr2.RotateTransform(transform_degree)
                Dim shrtside = 460 / ratio
                If transform_degree = 90 Then
                    Dim location = -630 - (shrtside / 2)
                    xgr2.DrawImage(img2, 60, location, 460, shrtside)
                    file_name_location_x2 = shrtside + ((630 - shrtside) - (shrtside / 2))
                    file_name_location_y2 = 460 + 60
                Else
                    Dim location = 630 - (shrtside / 2)
                    xgr2.DrawImage(img2, -520, location, 460, shrtside)
                    file_name_location_x2 = shrtside + ((630 - shrtside) - (shrtside / 2))
                    file_name_location_y2 = 460 + 60
                End If

                '######## ROTATE SOME SECOND IMAGES ##############
            ElseIf CheckBox_Rotate.CheckState = CheckState.Indeterminate Then
                If rotate_list(i + 1) = 1 Then 'if the picture is checked to be rotated
                    xgr2.RotateTransform(transform_degree)
                    Dim shrtside = 460 / ratio
                    If transform_degree = 90 Then
                        Dim location = -630 - (shrtside / 2)
                        xgr2.DrawImage(img2, 60, location, 460, shrtside)
                        file_name_location_x2 = shrtside + ((630 - shrtside) - (shrtside / 2))
                        file_name_location_y2 = 460 + 60
                    Else
                        Dim location = 630 - (shrtside / 2)
                        xgr2.DrawImage(img2, -520, location, 460, shrtside)
                        file_name_location_x2 = shrtside + ((630 - shrtside) - (shrtside / 2))
                        file_name_location_y2 = 460 + 60
                    End If
                Else
                    Dim shrtside = 390 / ratio
                    Dim location = 293 - (shrtside / 2)
                    xgr2.DrawImage(img2, 430, location, 390, shrtside)
                    file_name_location_x2 = 430
                    file_name_location_y2 = location + shrtside
                End If
                '############# DON'T ROTATE THE IMAGES #################
            Else
                Dim shrtside = 390 / ratio
                Dim location = 293 - (shrtside / 2)
                xgr2.DrawImage(img2, 430, location, 390, shrtside) 'this is the one if they aren't rotated
                file_name_location_x2 = 430
                file_name_location_y2 = location + shrtside
            End If
            xgr2.Dispose()
            img2.Dispose()
        End If

        '###########
        img.Dispose()
        xgr.Dispose()
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        write_single_file_name(picture_list, i, page, gfx, footer_font, file_name_location_x, file_name_location_y)


        '##############
        If Not i = picture_list.Count() - 1 Then 'needs to do this so that it doesn't fall over if an odd number of pictures!
            img.Dispose()
            xgr.Dispose()
            'Dim gfx2 As XGraphics = XGraphics.FromPdfPage(page)
            write_single_file_name(picture_list, i + 1, page, gfx, footer_font, file_name_location_x2, file_name_location_y2)
        End If
    End Sub


    '##########################################################
    '# Sub Name: write_comments                               #
    '# Passed Variables: picture_list as list                 #
    '#                   i as integer                         #
    '#                   gfx as Xgraphics                     #
    '#                   footer_font as font                  #
    '# Purpose: writes the comments on the pdf page           #
    '#          Calls get_comment_by_picture to get the text  #
    '##########################################################
    Private Sub write_comments(gfx, picture_list, i, footer_font)
        Dim tf = New Layout.XTextFormatter(gfx)
        tf.Alignment = Drawing.Layout.XParagraphAlignment.Left
        Dim comment As String = get_comment_by_picture(picture_list(i))
        If CheckBox_Rotate.Checked = True Then
            Dim rect As XRect = New XRect(500, 140, 300, 500)
            tf.DrawString(comment, footer_font, XBrushes.Black, rect)
        Else
            Dim rect As XRect = New XRect(40, 500, 780, 200)
            tf.DrawString(comment, footer_font, XBrushes.Black, rect)
        End If
    End Sub


    '####################################################
    '# Sub Name: save_pdf                               #
    '# Passed Variables: filename as text               #
    '#                   document as pdf document       #
    '# Purpose: saves the pdf to disk                   #
    '#          Calls to unlock form                    #
    '####################################################
    Private Sub save_pdf(filename, document)
        Dim filepath As String = TextBox_save_location.Text & "\" & filename
        Try
            document.Save(filepath)
            If MsgBox("PDF Created, do you wish to open it?", vbYesNo, "Successful") = vbYes Then
                Process.Start("""" & filepath & """") 'cos of the spaces, put this in quotes 
            End If

        Catch bass As Exception
            Call MsgBox("Save Not possible, Ex01" & vbCrLf & vbCrLf & bass.ToString)
        End Try

        Invoke(Sub()
                   unlock_form(True)
               End Sub)
    End Sub


    '####################################################
    '# Sub Name: write_title_page                       #
    '# Passed Variables: header_text as text            #
    '#                   title_gfx as Xgraphics         #
    '#                   title_page as pdf page         #
    '#                   pen as pen                     #
    '# Purpose: writes the front/title page of the pdf  #
    '####################################################
    Private Sub write_title_page(header_text, document, pen) ', title_gfx, title_page)
        Dim title_page As PdfPage = document.AddPage
        title_page.Orientation = title_page.Orientation.Landscape
        Dim title_gfx As XGraphics = XGraphics.FromPdfPage(title_page)

        Dim font As XFont = New XFont("Verdana", 20, XFontStyle.Bold)
        Dim todays_date = Date.Now().ToString("yyyy-MM-dd") 'get the current date
        title_gfx.DrawString(header_text, font, XBrushes.Black, New XRect(0, 50, title_page.Width.Point, title_page.Height.Point), XStringFormats.TopCenter)
        title_gfx.DrawString("DFU Reference: " & TextBox_DFU_REF.Text, font, XBrushes.Black, New XRect(0, 150, title_page.Width.Point, title_page.Height.Point), XStringFormats.TopCenter)
        title_gfx.DrawString("Manual Examination Date: " & TextBox_Date_of_ME.Text, font, XBrushes.Black, New XRect(0, 200, title_page.Width.Point, title_page.Height.Point), XStringFormats.TopCenter)
        title_gfx.DrawString("Examiner: " & TextBox_Examiner_name.Text, font, XBrushes.Black, New XRect(0, 250, title_page.Width.Point, title_page.Height.Point), XStringFormats.TopCenter)
        title_gfx.DrawString(My.Settings.company_name, font, XBrushes.Black, New XRect(0, 300, title_page.Width.Point, title_page.Height.Point), XStringFormats.TopCenter)
        title_gfx.DrawString("Report Date: " & todays_date, font, XBrushes.Black, New XRect(0, 350, title_page.Width.Point, title_page.Height.Point), XStringFormats.TopCenter)

        ' Dim pen As XPen = New XPen(XColor.FromArgb(39, 58, 124))
        Dim pen_thick As XPen = New XPen(XColor.FromArgb(39, 58, 124), 15)
        title_gfx.DrawLine(pen_thick, New XPoint(0, 450), New XPoint(850, 450))
        title_gfx.DrawLine(pen, New XPoint(0, 462), New XPoint(850, 462))
        title_gfx.Dispose()
    End Sub

    '###################### DEV ##############################
    '# Sub Name: write_single_file_name                 #
    '# Passed Variables: picture_list as list           #
    '#                   i as integer                   #
    '#                   pics_per_page as integer       #
    '#                   page as pdf page               #
    '#                   gfx as Xgraphics               #
    '#                   footer_font as font            #
    '# Purpose: writes the filename(s) on the pdf page  #
    '####################### DEV #############################
    Private Sub write_single_file_name(picture_list, i, page, gfx, footer_font, file_name_x, file_name_y)
        Dim name_of_file As String = Path.GetFileName(picture_list(i))
        gfx.DrawString("File Name: " & name_of_file, footer_font, XBrushes.Black, New XRect(file_name_x, file_name_y + 10, page.Width.Point, page.Height.Point), XStringFormats.TopLeft)
    End Sub

    '########################################################
    '# Sub Name: Label_Drap_Drop_DragDrop                   #
    '# Passed Variables: none                               #
    '# Purpose: Adds the drag and dropped files to the list #
    '#          box if they don't already exists (unique)   #
    '########################################################
    Private Sub Label_Drap_Drop_DragDrop(sender As Object, e As DragEventArgs) Handles Label_Drap_Drop.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            If Not ListBox_Selected_Files.Items.Contains(path) Then 'avoid duplicates
                ListBox_Selected_Files.Items.Add(path)
            End If
        Next
        ListBox_Selected_Files.Sorted = True
        Label_Selected_Files.Text = "Selected Files (" & ListBox_Selected_Files.Items.Count & "):"
    End Sub


    '########################################################
    '# Sub Name: ListBox_Selected_Files_DragEnte            #
    '# Passed Variables: none                               #
    '# Purpose: Shows the drop files cursor on the listbox  #
    '########################################################
    Private Sub Label_Drap_Drop_DragEnter(sender As Object, e As DragEventArgs) Handles Label_Drap_Drop.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub


    '##############################################################
    '# Sub Name: Button_Open_Folder_Click                         #
    '# Passed Variables: none                                     #
    '# Purpose: opens the folder dialog and gets the user input   #
    '##############################################################
    Private Sub Button_Open_Folder_Click(sender As Object, e As EventArgs) Handles Button_Open_Folder.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox_save_location.Text = FolderBrowserDialog1.SelectedPath()
        End If
    End Sub

    '##############################################################
    '# Sub Name: Form1_Load                                       #
    '# Passed Variables: none                                     #
    '# Purpose: Adds values to the ComboBox for pictures-per-page #
    '##############################################################
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.first_setup = True Then
            FirstTimeSetup()
        End If

        ComboBox_per_Page.Items.Add("1")
        ComboBox_per_Page.Items.Add("2")
        ComboBox_per_Page.Text = "2"
    End Sub

    '#############################################################
    '# Sub Name: FirstTimeSetup                                  #
    '# Passed Variables: none                                    #
    '# Purpose: Sets the defualt company name                    #
    '#############################################################
    Private Sub FirstTimeSetup()
        MsgBox("Please set up company name")
        Form_Settings.Show()
        My.Settings.first_setup = False
    End Sub



    '#############################################################
    '# Sub Name: CheckBox_Comments_CheckedChanged                #
    '# Passed Variables: none                                    #
    '# Purpose: Expands/shrinks the form to show/hide the        #
    '#          comment section. Tri-state not available with    #
    '#          comments so disables/enables this                #
    '#############################################################
    Private Sub CheckBox_Comments_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Comments.CheckedChanged
        If CheckBox_Comments.Checked = True Then
            ComboBox_per_Page.Text = 1
            ComboBox_per_Page.Enabled = False
            Me.Width = 1090
            Me.Height = 567
            CheckBox_Rotate.ThreeState = False
        Else
            ComboBox_per_Page.Enabled = True
            Me.Width = 736
            Me.Height = 567
            CheckBox_Rotate.ThreeState = True
        End If
    End Sub


    '#########################################################
    '# Sub Name: Button_add_comment_Click                    #
    '# Passed Variables: none                                #
    '# Purpose: Adds the value of the comment textbox to the #
    '#          dictionary with the key as the picture path  #
    '#########################################################
    Private Sub Button_add_comment_Click(sender As Object, e As EventArgs) Handles Button_add_comment.Click
        Dim selected As String = ListBox_Selected_Files.SelectedItem
        If Not selected = "" Then 'make sure it's not empty
            If comments_dic.ContainsKey(ListBox_Selected_Files.SelectedItem) Then
                comments_dic(selected) = TextBox_Comments.Text
                Button_add_comment.Enabled = False
            Else
                comments_dic.Add(ListBox_Selected_Files.SelectedItem, "")
            End If
        End If
    End Sub


    '########################################################
    '# Function Name: get_comment_but_picture               #
    '# Passed Variables: picture                            #
    '# Returns: Comment as String                           #
    '# Purpose: Returns the comment from the dictionary     #
    '#          for the passed picture name                 #
    '########################################################
    Private Function get_comment_by_picture(picture)
        Dim comment As String
        Try
            comment = comments_dic.Item(picture)
        Catch salmon As Exception
            comment = ""
        End Try
        Return comment
    End Function


    '#########################################################
    '# Sub Name: CheckBox_Rotate_Click                       #
    '# Passed Variables: none                                #
    '# Purpose: Changes the label of the checkbox to fit     #
    '#          the description, and wipes the listbox ticks #
    '#########################################################
    Private Sub CheckBox_Rotate_Click(sender As Object, e As EventArgs) Handles CheckBox_Rotate.Click
        If CheckBox_Rotate.CheckState = CheckState.Indeterminate Then
            CheckBox_Rotate.Text = "Selectively Rotate Images to Portrait" & vbCrLf & "(tick pictures you wish to rotate)"
            ListBox_Selected_Files.SelectionMode = SelectionMode.One
        Else
            CheckBox_Rotate.Text = "Rotate Images to Portrait"
            For i As Int16 = 0 To ListBox_Selected_Files.Items.Count - 1
                ListBox_Selected_Files.SetItemChecked(i, False)
            Next
        End If
    End Sub


    '########################################################
    '# Sub Name: ListBox_Selected_Files_DragDrop            #
    '# Passed Variables: none                               #
    '# Purpose: Adds the drag and dropped files to the list #
    '#          box if they don't already exists (unique)   #
    '########################################################
    Private Sub ListBox_Selected_Files_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox_Selected_Files.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            If Not ListBox_Selected_Files.Items.Contains(path) Then 'avoid duplicates
                ListBox_Selected_Files.Items.Add(path)
            End If
        Next
        ListBox_Selected_Files.Sorted = True
        Label_Selected_Files.Text = "Selected Files (" & ListBox_Selected_Files.Items.Count & "):"
    End Sub


    '########################################################
    '# Sub Name: ListBox_Selected_Files_DragEnte            #
    '# Passed Variables: none                               #
    '# Purpose: Shows the drop files cursor on the listbox  #
    '########################################################
    Private Sub ListBox_Selected_Files_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox_Selected_Files.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    '#############################################################
    '# Sub Name: ListBox_Selected_Files_SelectedIndexChanged     #
    '# Passed Variables: none                                    #
    '# Purpose: Updates the thumbnail image and the comment in   #
    '#          the textbox for the chosen image in the listview #
    '############################################################# 
    Private Sub ListBox_Selected_Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Selected_Files.SelectedIndexChanged

        If Not CheckBox_Rotate.CheckState = CheckState.Indeterminate Then
            Try
                Dim i As Int16 = ListBox_Selected_Files.SelectedIndices(0)
                ListBox_Selected_Files.SetItemChecked(i, False)
            Catch
            End Try
        End If

        'Clears everything
        PictureBox_Image_Display.BackgroundImage = Nothing
        PictureBox_Image_Display.Refresh()
        ImageList1.Dispose()

        're sets up the imagelist
        ImageList1 = New ImageList
        ImageList1.ImageSize = New Size(256, 192)
        ImageList1.ColorDepth = ColorDepth.Depth32Bit

        'sets up the image, and as it's new it'll always be in position 0
        Dim tempImage As Image
        Try
            tempImage = Image.FromFile(ListBox_Selected_Files.SelectedItem)
            ImageList1.Images.Add(tempImage)
        Catch es As Exception
        End Try


        If CheckBox_Comments.Checked = True Then 'check to see if they want to actually add a comment 
            'this changes the label text to show which picture is being edited
            Label_Coment_photos.Text = "Adding Comment for photo:" & vbCrLf & ListBox_Selected_Files.SelectedItem
            Try
                PictureBox_Image_Display.BackgroundImage = ImageList1.Images(0)
            Catch eel As Exception
            End Try

            If comments_dic.ContainsKey(ListBox_Selected_Files.SelectedItem) Then
                TextBox_Comments.Text = comments_dic.Item(ListBox_Selected_Files.SelectedItem)
            Else
                TextBox_Comments.Text = ""
                comments_dic.Add(ListBox_Selected_Files.SelectedItem, "")
            End If
        End If

        'disposes the image
        Try 'the try is needed to avoid falling over if nothing is actually clicked
            tempImage.Dispose()
        Catch bass As Exception
        End Try

        ImageList1.Dispose()
        Button_add_comment.Enabled = True
    End Sub


    '########################################################
    '# Sub Name: CheckBox_90_CheckedChanged                 #
    '# Passed Variables: none                               #
    '# Purpose: Manages the rotation checkboxes to ensure   #
    '#          they are not both checked at the same time  #
    '########################################################
    Private Sub CheckBox_90_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_90.CheckedChanged
        If CheckBox_90.Checked = True Then
            CheckBox_270.Checked = False
        Else
            CheckBox_270.Checked = True
        End If
    End Sub


    '########################################################
    '# Sub Name: CheckBox_270_CheckedChanged                #
    '# Passed Variables: none                               #
    '# Purpose: Manages the rotation checkboxes to ensure   #
    '#          they are not both checked at the same time  #
    '########################################################
    Private Sub CheckBox_270_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_270.CheckedChanged
        If CheckBox_270.Checked = True Then
            CheckBox_90.Checked = False
        Else
            CheckBox_90.Checked = True
        End If
    End Sub


    '########################################################
    '# Sub Name: ListBox_Selected_Files_KeyDown             #
    '# Passed Variables: none                               #
    '# Purpose: Allows items to be removed from the listbox #
    '#          by selecting them and pressing the DEL key  #
    '########################################################
    Private Sub ListBox_Selected_Files_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox_Selected_Files.KeyDown
        If e.KeyValue = Keys.Delete Then
            ListBox_Selected_Files.Items.Remove(ListBox_Selected_Files.SelectedItem)
            Label_Selected_Files.Text = "Selected Files (" & ListBox_Selected_Files.Items.Count & "):"
        End If
    End Sub

    Private Sub ListBox_Selected_Files_DoubleClick(sender As Object, e As EventArgs) Handles ListBox_Selected_Files.DoubleClick
        If Not CheckBox_Rotate.CheckState = CheckState.Indeterminate Then
            Try
                Dim i As Int16 = ListBox_Selected_Files.SelectedIndices(0)
                ListBox_Selected_Files.SetItemChecked(i, False)
            Catch
            End Try
        End If
    End Sub


End Class

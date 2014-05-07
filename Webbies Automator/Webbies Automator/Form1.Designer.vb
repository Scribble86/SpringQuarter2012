<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebbiesAutomator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WebbiesAutomator))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Webbies = New System.Windows.Forms.TextBox()
        Me.CorrectBtn = New System.Windows.Forms.Button()
        Me.Warnings = New System.Windows.Forms.TextBox()
        Me.SearchCharacters = New System.Windows.Forms.TextBox()
        Me.CharactersLbl = New System.Windows.Forms.Label()
        Me.SKULbl = New System.Windows.Forms.Label()
        Me.SearchSKUs = New System.Windows.Forms.TextBox()
        Me.SpecialsRemoved = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.VerifySaveCheckBox = New System.Windows.Forms.CheckBox()
        Me.OAyes = New System.Windows.Forms.Label()
        Me.Yes = New System.Windows.Forms.TextBox()
        Me.Exist = New System.Windows.Forms.TextBox()
        Me.OAexist = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Paste webbies file here:"
        '
        'Webbies
        '
        Me.Webbies.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Webbies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Webbies.Location = New System.Drawing.Point(16, 20)
        Me.Webbies.MaxLength = 999999999
        Me.Webbies.Multiline = True
        Me.Webbies.Name = "Webbies"
        Me.Webbies.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Webbies.Size = New System.Drawing.Size(756, 250)
        Me.Webbies.TabIndex = 1
        Me.Webbies.WordWrap = False
        '
        'CorrectBtn
        '
        Me.CorrectBtn.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CorrectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CorrectBtn.Location = New System.Drawing.Point(697, 276)
        Me.CorrectBtn.Name = "CorrectBtn"
        Me.CorrectBtn.Size = New System.Drawing.Size(75, 23)
        Me.CorrectBtn.TabIndex = 2
        Me.CorrectBtn.Text = "Correct Text"
        Me.CorrectBtn.UseVisualStyleBackColor = False
        '
        'Warnings
        '
        Me.Warnings.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Warnings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Warnings.Location = New System.Drawing.Point(423, 315)
        Me.Warnings.Multiline = True
        Me.Warnings.Name = "Warnings"
        Me.Warnings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Warnings.Size = New System.Drawing.Size(348, 235)
        Me.Warnings.TabIndex = 4
        '
        'SearchCharacters
        '
        Me.SearchCharacters.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.SearchCharacters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SearchCharacters.Location = New System.Drawing.Point(16, 324)
        Me.SearchCharacters.Name = "SearchCharacters"
        Me.SearchCharacters.Size = New System.Drawing.Size(401, 20)
        Me.SearchCharacters.TabIndex = 4
        Me.SearchCharacters.Visible = False
        '
        'CharactersLbl
        '
        Me.CharactersLbl.AutoSize = True
        Me.CharactersLbl.Location = New System.Drawing.Point(13, 308)
        Me.CharactersLbl.Name = "CharactersLbl"
        Me.CharactersLbl.Size = New System.Drawing.Size(397, 13)
        Me.CharactersLbl.TabIndex = 5
        Me.CharactersLbl.Text = "Special Characters to search for. (Replacement character follows target character" & _
    ".)"
        Me.CharactersLbl.Visible = False
        '
        'SKULbl
        '
        Me.SKULbl.AutoSize = True
        Me.SKULbl.Location = New System.Drawing.Point(13, 347)
        Me.SKULbl.Name = "SKULbl"
        Me.SKULbl.Size = New System.Drawing.Size(394, 13)
        Me.SKULbl.TabIndex = 6
        Me.SKULbl.Text = "SKUs to search for. (Include all SKUs and variation, separated ONLY by commas.)"
        Me.SKULbl.Visible = False
        '
        'SearchSKUs
        '
        Me.SearchSKUs.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.SearchSKUs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SearchSKUs.Location = New System.Drawing.Point(16, 363)
        Me.SearchSKUs.Name = "SearchSKUs"
        Me.SearchSKUs.Size = New System.Drawing.Size(401, 20)
        Me.SearchSKUs.TabIndex = 7
        Me.SearchSKUs.Visible = False
        '
        'SpecialsRemoved
        '
        Me.SpecialsRemoved.AutoSize = True
        Me.SpecialsRemoved.Location = New System.Drawing.Point(564, 299)
        Me.SpecialsRemoved.Name = "SpecialsRemoved"
        Me.SpecialsRemoved.Size = New System.Drawing.Size(13, 13)
        Me.SpecialsRemoved.TabIndex = 8
        Me.SpecialsRemoved.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(420, 299)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Special Characters Removed:"
        '
        'SaveBtn
        '
        Me.SaveBtn.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveBtn.Location = New System.Drawing.Point(327, 467)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(90, 23)
        Me.SaveBtn.TabIndex = 12
        Me.SaveBtn.Text = "Save Changes"
        Me.SaveBtn.UseVisualStyleBackColor = False
        Me.SaveBtn.Visible = False
        '
        'VerifySaveCheckBox
        '
        Me.VerifySaveCheckBox.AutoSize = True
        Me.VerifySaveCheckBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.VerifySaveCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.VerifySaveCheckBox.Location = New System.Drawing.Point(16, 282)
        Me.VerifySaveCheckBox.Name = "VerifySaveCheckBox"
        Me.VerifySaveCheckBox.Size = New System.Drawing.Size(198, 17)
        Me.VerifySaveCheckBox.TabIndex = 4
        Me.VerifySaveCheckBox.Text = "I want to change the search settings!"
        Me.VerifySaveCheckBox.UseVisualStyleBackColor = False
        '
        'OAyes
        '
        Me.OAyes.AutoSize = True
        Me.OAyes.Location = New System.Drawing.Point(13, 386)
        Me.OAyes.Name = "OAyes"
        Me.OAyes.Size = New System.Drawing.Size(86, 13)
        Me.OAyes.TabIndex = 8
        Me.OAyes.Text = "Owner Alert: Yes"
        Me.OAyes.Visible = False
        '
        'Yes
        '
        Me.Yes.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Yes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Yes.Location = New System.Drawing.Point(16, 402)
        Me.Yes.Name = "Yes"
        Me.Yes.Size = New System.Drawing.Size(401, 20)
        Me.Yes.TabIndex = 9
        Me.Yes.Visible = False
        '
        'Exist
        '
        Me.Exist.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Exist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Exist.Location = New System.Drawing.Point(16, 441)
        Me.Exist.Name = "Exist"
        Me.Exist.Size = New System.Drawing.Size(401, 20)
        Me.Exist.TabIndex = 11
        Me.Exist.Visible = False
        '
        'OAexist
        '
        Me.OAexist.AutoSize = True
        Me.OAexist.Location = New System.Drawing.Point(13, 425)
        Me.OAexist.Name = "OAexist"
        Me.OAexist.Size = New System.Drawing.Size(104, 13)
        Me.OAexist.TabIndex = 10
        Me.OAexist.Text = "Owner Alert: Existing"
        Me.OAexist.Visible = False
        '
        'Version
        '
        Me.Version.AutoSize = True
        Me.Version.Location = New System.Drawing.Point(733, 3)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(32, 13)
        Me.Version.TabIndex = 13
        Me.Version.Text = "V 1.1"
        '
        'WebbiesAutomator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.OAexist)
        Me.Controls.Add(Me.Exist)
        Me.Controls.Add(Me.Yes)
        Me.Controls.Add(Me.OAyes)
        Me.Controls.Add(Me.SpecialsRemoved)
        Me.Controls.Add(Me.VerifySaveCheckBox)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SearchSKUs)
        Me.Controls.Add(Me.SKULbl)
        Me.Controls.Add(Me.CharactersLbl)
        Me.Controls.Add(Me.SearchCharacters)
        Me.Controls.Add(Me.Warnings)
        Me.Controls.Add(Me.CorrectBtn)
        Me.Controls.Add(Me.Webbies)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WebbiesAutomator"
        Me.Text = "Webbies Automator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Webbies As System.Windows.Forms.TextBox
    Friend WithEvents CorrectBtn As System.Windows.Forms.Button
    Friend WithEvents Warnings As System.Windows.Forms.TextBox
    Friend WithEvents SearchCharacters As System.Windows.Forms.TextBox
    Friend WithEvents CharactersLbl As System.Windows.Forms.Label
    Friend WithEvents SKULbl As System.Windows.Forms.Label
    Friend WithEvents SearchSKUs As System.Windows.Forms.TextBox
    Friend WithEvents SpecialsRemoved As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents VerifySaveCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents OAyes As System.Windows.Forms.Label
    Friend WithEvents Yes As System.Windows.Forms.TextBox
    Friend WithEvents Exist As System.Windows.Forms.TextBox
    Friend WithEvents OAexist As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label

End Class

Option Strict On
Imports System
Imports System.IO

'Nikita Chrystephan

'Currently there is a bug where the customer comment correct functions erase some customer comments. (just the first one?) 
'

Public Class WebbiesAutomator

    Dim strSKUs As String
    Dim arrSKUs() As String
    Dim SkuNotes As String = ""

    Private Sub WebbiesAutomator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'this is a list of all of the special characters that our database system can't understand, or reserves for other functions. Following each one, is the character we will replace it with.
        'i am declaring it at load, so that the list will be viewable by, and can be modified by the user if any characters need to be added or removed in the future.
        Dim strCharacters As String = File.ReadAllText(".\Characters.txt")
        SearchCharacters.Text = strCharacters
        strSKUs = File.ReadAllText(".\Skus.txt")
        SearchSKUs.Text = strSKUs
        Yes.Text = File.ReadAllText(".\Yes.txt")
        Exist.Text = File.ReadAllText(".\Existing.txt")

    End Sub

    'this button kicks off the action, and prevents any changes to the text while it's working. in practice this takes so little time that it's probably not necessary, but better safe than sorry.
    Private Sub CorrectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorrectBtn.Click

        CorrectBtn.Enabled = False
        Webbies.ReadOnly = True
        SearchCharacters.ReadOnly = True
        SearchSKUs.ReadOnly = True

        Webbies.Text = Webbies.Text.Trim()
        arrSKUs = Split(strSKUs, ",")
        Webbies.Text = SpecialCharacters(Webbies.Text)
        Webbies.Text = Breakdown(Webbies.Text)

        SearchSKUs.ReadOnly = False
        SearchCharacters.ReadOnly = False
        Webbies.ReadOnly = False

    End Sub

    'this function goes through the entire text and checks each character against the list of special characters.
    Private Function SpecialCharacters(ByVal WebText As String) As String

        'final string to output.
        Dim strCorrected As String = ""

        'gets list of characters from user editable text box.
        Dim strCharacters As String = SearchCharacters.Text

        'starts a loop that runs as long as the full text is, so that we can check every character in it.
        For a As Integer = 0 To (WebText.Length - 1) Step 1

            'starts a loop inside a loop that runs for the number of special characters. remember, each special character is followed by it's "equivalent," so i am stepping over them.
            For b As Integer = 0 To (strCharacters.Length - 1) Step 2

                'checks to see if the character from the main text is the same as the current special character selected.
                If WebText.Substring(a, 1) = strCharacters.Substring(b, 1) Then

                    'replaces the character from the main text with it's replacement if it is a special character.
                    WebText = WebText.Remove(a, 1)
                    WebText = WebText.Insert(a, strCharacters.Substring(b + 1, 1))
                    SpecialsRemoved.Text = CStr(CInt(SpecialsRemoved.Text) + 1)

                End If

            Next

        Next

        Return WebText

    End Function

    'this function does a lot of things. it corrects canadian province codes and some US territory state codes, so that they can be recognized by our database software. 
    'After that it looks at the items people have ordered, for particularly troublesome ones.
    'Finally, it prints the list of troublesome orders by type into a user viewable text box.
    Private Function Breakdown(ByVal WebText As String) As String

        'declaring variables and arrays for storing comments and order info...
        Dim strWebArray() As String
        Dim strModText As String = ""

        'declaring variables for customer comments and product warnings.
        Dim strComments As String = ""
        Dim strItag() As String = {""}
        Dim strStag() As String = {""}
        Dim strBwl() As String = {""}
        Dim strIclr() As String = {""}
        Dim strCJtag() As String = {""}
        Dim strJic() As String = {""}
        Dim strYes() As String = {""}
        Dim strAlready() As String = {""}

        'First, we break up the text into an array, where each entry in the array is one line from the text. (one order item.)
        strWebArray = Split(WebText, (Chr(34) & vbNewLine), Limit:=-1)

        'searches the split up array for any entries that aren't blank and don't start with an order number. Then, it assumes they are part of the previous entry and joins them together.
        For a As Integer = 0 To UBound(strWebArray)

            If Not strWebArray(a) = "" Then

                If Not IsNumeric(strWebArray(a).Substring(1, 6)) Then

                    If a > 0 Then

                        strWebArray(a - 1) = strWebArray(a - 1) & strWebArray(a)
                        strWebArray(a) = ""

                        a = 0

                    End If

                End If

            End If

        Next a

        'this is code to remove empty arrays created by joining other processes.
        For b As Integer = 0 To UBound(strWebArray)

            Dim intChangeCount As Integer

            If Not b > UBound(strWebArray) Then

                If strWebArray(b) = "" And Not b = UBound(strWebArray) Then

                    strWebArray(b) = strWebArray(b + 1)
                    strWebArray(b + 1) = ""
                    intChangeCount += 1

                End If

                If b = UBound(strWebArray) Then

                    If strWebArray(b) = "" Then

                        strWebArray(b) = ""
                        ReDim Preserve strWebArray(UBound(strWebArray) - 1)

                        If intChangeCount >= 0 Then
                            b = 0
                        End If

                    End If

                End If

            End If

        Next b

        'This loop runs for each line in the order.
        For i As Integer = 0 To UBound(strWebArray)

            'declaring a new array to split the order line into it's component parts
            Dim strSubArray() As String

            'splitting order line...
            strSubArray = Split(strWebArray(i), (Chr(34) & "," & Chr(34)))

            'checks against empty lines, we don't want to try to call array(38) from a 0 size array.
            If strSubArray.Length > 1 Then

                'our database doesn't recognize full canadian province names or some people's idea of postal abbreviations, so i am attempting to catch them here and change them to a 2 digit code that it recognizes.
                If strSubArray(5).ToUpper.Contains("CANADA") Then

                    'for all of these if statements, i am attempting to distinguish the provinces from eachother, even if people didn't write the whole thing out. For example, people write "british columbia" or "b.c." which will both cause our database to throw a fit.
                    If strSubArray(3).ToUpper.Contains("Q") And strSubArray(3).ToUpper.Contains("C") Then

                        strSubArray(3) = "QC"
                        strSubArray(11) = "QC"

                    End If

                    If strSubArray(3).ToUpper.Contains("B") And strSubArray(3).ToUpper.Contains("C") And Not strSubArray(3).ToUpper.Contains("N") Then

                        strSubArray(3) = "BC"
                        strSubArray(11) = "BC"

                    End If

                    If strSubArray(3).ToUpper.Contains("N") And strSubArray(3).ToUpper.Contains("B") And Not strSubArray(3).ToUpper.Contains("M") Then

                        strSubArray(3) = "NB"
                        strSubArray(11) = "NB"

                    End If

                    If strSubArray(3).ToUpper.Contains("O") And strSubArray(3).ToUpper.Contains("N") And Not strSubArray(3).ToUpper.Contains("B") And Not strSubArray(3).ToUpper.Contains("S") And Not strSubArray(3).ToUpper.Contains("L") Then

                        strSubArray(3) = "ON"
                        strSubArray(11) = "ON"

                    End If

                    If strSubArray(3).ToUpper.Contains("N") And strSubArray(3).ToUpper.Contains("S") And Not strSubArray(3).ToUpper.Contains("B") And Not strSubArray(3).ToUpper.Contains("E") Then

                        strSubArray(3) = "NS"
                        strSubArray(11) = "NS"

                    End If

                    If strSubArray(3).ToUpper.Contains("M") And strSubArray(3).ToUpper.Contains("B") And Not strSubArray(3).ToUpper.Contains("C") Then

                        strSubArray(3) = "MB"
                        strSubArray(11) = "MB"

                    End If

                    If strSubArray(3).ToUpper.Contains("P") And strSubArray(3).ToUpper.Contains("E") Then

                        strSubArray(3) = "PE"
                        strSubArray(11) = "PE"

                    End If

                    If strSubArray(3).ToUpper.Contains("S") And strSubArray(3).ToUpper.Contains("K") Then

                        strSubArray(3) = "SK"
                        strSubArray(11) = "SK"

                    End If

                    If strSubArray(3).ToUpper.Contains("A") And strSubArray(3).ToUpper.Contains("B") And Not strSubArray(3).ToUpper.Contains("M") And Not strSubArray(3).ToUpper.Contains("C") Then

                        strSubArray(3) = "AB"
                        strSubArray(11) = "AB"

                    End If

                    If strSubArray(3).ToUpper.Contains("N") And strSubArray(3).ToUpper.Contains("L") And Not strSubArray(3).ToUpper.Contains("P") Then

                        strSubArray(3) = "NL"
                        strSubArray(11) = "NL"

                    End If

                ElseIf strSubArray(3).ToUpper.Contains("ALASKA") Then

                    strSubArray(3) = "AK"
                    strSubArray(11) = "AK"

                ElseIf strSubArray(3).ToUpper.Contains("ARMED FORCES PACIFIC") Then

                    strSubArray(3) = "AP"
                    strSubArray(11) = "AP"

                ElseIf strSubArray(3).ToUpper.Contains("EUROPE") Or strSubArray(3).ToUpper.Contains("CANADA") Or strSubArray(3).ToUpper.Contains("AFRICA") Or strSubArray(3).ToUpper.Contains("MIDDLE EAST") Then

                    strSubArray(3) = "AE"
                    strSubArray(11) = "AE"

                ElseIf strSubArray(3).ToUpper.Contains("AMERICA") Then

                    strSubArray(3) = "AA"
                    strSubArray(11) = "AA"

                ElseIf strSubArray(3).ToUpper.Contains("ISLANDS") Then

                    strSubArray(3) = "VI"
                    strSubArray(11) = "VI"

                End If

                'customer comments are worth keeping, sometimes they put useful requests in this field. However, they will also cause our database program to have a fit, so I am saving them and then removing them.
                If strSubArray(22) <> "" Then

                    'since one order can contain multiple orders and lines, but they are always grouped together, i check to see if we have already made a note  of this order so that we can avoid duplicate notation.
                    If strComments.Contains(strSubArray(22)) = False Then

                        'adding the new comment to the list of customer comments
                        strComments = strComments & vbNewLine & strSubArray(0).Substring(0, 6) & " " & strSubArray(22)

                        'clearing the customer comment field to be nice to our database.
                        strSubArray(22) = ""

                    End If

                End If

                For intSKUCount As Integer = 0 To UBound(arrSKUs)

                    SKUChecker(strSubArray, intSKUCount)

                Next intSKUCount

                ''the rest of these statements work pretty much just like the above, except that we're looking for a product sku instead, and simply making a note of the order it is in.
                'If strSubArray(29).ToUpper.Contains("ITAG-11-1") Then

                '    If (strItag(UBound(strItag)).Contains(strSubArray(0).Substring(0, 6))) = False Then

                '        ReDim Preserve strItag(0 To UBound(strItag) + 1)
                '        strItag(UBound(strItag)) = strSubArray(0).Substring(0, 6) & vbNewLine

                '    End If

                'End If

                'If strSubArray(29).ToUpper.Contains("STAG-11-1") Or strSubArray(29).ToUpper.Contains("STAG-15-1") Then

                '    If (strStag(UBound(strStag)).Contains(strSubArray(0).Substring(0, 6))) = False Then

                '        ReDim Preserve strStag(0 To UBound(strStag) + 1)
                '        strStag(UBound(strStag)) = strSubArray(0).Substring(0, 6) & vbNewLine

                '    End If

                'End If

                'If strSubArray(29).ToUpper.Contains("BWL") Then

                '    If (strBwl(UBound(strBwl)).Contains(strSubArray(0).Substring(0, 6))) = False Then

                '        ReDim Preserve strBwl(0 To UBound(strBwl) + 1)
                '        strBwl(UBound(strBwl)) = strSubArray(0).Substring(0, 6) & vbNewLine

                '    End If

                'End If

                'If strSubArray(29).ToUpper.Contains("ICLR-1") Then

                '    If (strIclr(UBound(strIclr)).Contains(strSubArray(0).Substring(0, 6))) = False Then

                '        ReDim Preserve strIclr(0 To UBound(strIclr) + 1)
                '        strIclr(UBound(strIclr)) = strSubArray(0).Substring(0, 6) & vbNewLine

                '    End If

                'End If

                'If strSubArray(29).ToUpper.Contains("CJTAG-10-1") Or strSubArray(29).ToUpper.Contains("CJTAG-30-1") Then

                '    If (strCJtag(UBound(strCJtag)).Contains(strSubArray(0).Substring(0, 6))) = False Then

                '        ReDim Preserve strCJtag(0 To UBound(strCJtag) + 1)
                '        strCJtag(UBound(strCJtag)) = strSubArray(0).Substring(0, 6) & vbNewLine

                '    End If

                'End If

                'If strSubArray(29).ToUpper.Contains("JIC-10-1") Or strSubArray(29).ToUpper.Contains("JIC-30-1") Then

                '    If strJic(UBound(strJic)).Contains(strSubArray(0).Substring(0, 6)) = False Then

                '        ReDim Preserve strJic(0 To UBound(strJic) + 1)
                '        strJic(UBound(strJic)) = strSubArray(0).Substring(0, 6) & vbNewLine

                '    End If

                'End If

                'not all products offer some additional services. we have a "pet recovery service" that is offered only on tags. this appears near the end of the order line, so i'm just checking to see if there are enough entries in the line.



                For j As Integer = 0 To UBound(strSubArray)
                    'checking for a keyword in a specific portion of the line, so as to avoid picking up things like "yesterday" etc.
                    If (strSubArray(j).Contains(Yes.Text)) = True Then

                        'the rest of this works the same way as the above statements.
                        If (strYes(UBound(strYes)).Contains(strSubArray(0).Substring(0, 6))) = False Then

                            ReDim Preserve strYes(0 To UBound(strYes) + 1)

                            strYes(UBound(strYes)) = strSubArray(0).Substring(0, 6) & vbNewLine

                        End If

                    End If

                    If (strSubArray(j).Contains(Exist.Text)) = True Then

                        If strAlready(UBound(strAlready)).Contains(strSubArray(0).Substring(0, 6)) = False Then

                            ReDim Preserve strAlready(0 To UBound(strAlready) + 1)

                            strAlready(UBound(strAlready)) = strSubArray(0).Substring(0, 6) & vbNewLine

                        End If

                    End If

                Next j

            End If

            'putting the order line back in place, after making changes to it.
            strWebArray(i) = Join(strSubArray, (Chr(34) & "," & Chr(34)))

        Next i

        'putting the order array back together...
        strModText = Join(strWebArray, (Chr(34) & vbNewLine))

        Warnings.Text = "Customer Comments" & vbNewLine & strComments & vbNewLine & SkuNotes & vbNewLine & "YES" & vbNewLine & Join(strYes) & vbNewLine & "ALREADY" & vbNewLine & Join(strAlready)

        'before returning the updated string back to the user so they can import it into the database.
        Return strModText

    End Function

    'Attempting to create a modular tool to check for the presence of any sku, return the order it is in, and avoid duplicate entries.
    Private Sub SKUChecker(ByVal arrOrderLine() As String, ByVal intSKUCount As Integer)

        Try
            If arrOrderLine(29).ToUpper.Contains(arrSKUs(intSKUCount)) Then

                FuncSKUNotes(arrOrderLine(0).Substring(0, 6), intSKUCount)

            End If

        Catch

            MessageBox.Show("There was an error while processing  order number " & CStr(arrOrderLine(0).Substring(0, 6)) & "." & vbNewLine & "This is likely caused by a customer comment. Please remove all instances of the customer's comment from this order and begin processing again.", "Oops!")

        End Try

    End Sub

    Private Sub FuncSKUNotes(ByVal strOrderID As String, ByVal intSKUCount As Integer)

        Static arrNotes(UBound(arrSKUs), 0) As String
        Dim boolAlreadyExists = False
        Dim strTest = ""

        For z As Integer = 0 To UBound(arrNotes, 2)

            strTest = arrNotes(intSKUCount, z)

            If strTest = strOrderID Then

                boolAlreadyExists = True

            End If

        Next z

        If boolAlreadyExists = False Then

            If arrNotes(intSKUCount, UBound(arrNotes, 2)) <> Nothing Then

                ReDim Preserve arrNotes(UBound(arrNotes, 1), UBound(arrNotes, 2) + 1)

            End If

            arrNotes(intSKUCount, (UBound(arrNotes, 2))) = strOrderID

        End If

        SkuNotes = NoteWriter(arrNotes)

    End Sub

    Private Function NoteWriter(ByVal arrNotes(,) As String) As String

        Dim strSKULog As String = ""

        For x As Integer = 0 To UBound(arrNotes, 1)

            strSKULog = strSKULog & vbNewLine & arrSKUs(x) & vbNewLine

            For y As Integer = 0 To UBound(arrNotes, 2)


                If arrNotes(x, y) <> Nothing Then

                    strSKULog = strSKULog & arrNotes(x, y) & vbNewLine

                End If

            Next y

        Next x

        NoteWriter = strSKULog

    End Function

    Private Sub VerifySaveCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerifySaveCheckBox.CheckedChanged

        If VerifySaveCheckBox.Checked Then

            SearchCharacters.Visible = True
            SearchSKUs.Visible = True
            SKULbl.Visible = True
            CharactersLbl.Visible = True
            SaveBtn.Visible = True
            SaveBtn.Enabled = True
            Yes.Visible = True
            Exist.Visible = True
            OAyes.Visible = True
            OAexist.Visible = True

        Else

            SearchCharacters.Visible = False
            SearchSKUs.Visible = False
            SKULbl.Visible = False
            CharactersLbl.Visible = False
            SaveBtn.Visible = False
            SaveBtn.Visible = False
            Yes.Visible = False
            Exist.Visible = False
            OAyes.Visible = False
            OAexist.Visible = False

        End If

    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click

        File.WriteAllText(".\Skus.txt", SearchSKUs.Text)
        File.WriteAllText(".\Characters.txt", SearchCharacters.Text)
        File.WriteAllText(".\Yes.txt", Yes.Text)
        File.WriteAllText(".\Existing.txt", Exist.Text)

        SaveBtn.Enabled = False
        SaveBtn.Visible = False
        VerifySaveCheckBox.Checked = False

        MessageBox.Show("Your changes have been saved!" & vbNewLine & "Please close and restart this application before continuing.")

    End Sub

End Class

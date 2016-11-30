Public Class CloseLEDFrom
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text Like "TDN-###-###-##" Or TextBox1.Text Like "TDN-##########" Or TextBox1.Text Like "TDN-###-##X-##" Then
            LEDOpenclose(TextBox1.Text, "_1")
            TextBox1.Clear() : TextBox1.Focus()
        Else
            TextBox1.Clear() : TextBox1.Focus()



        End If
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)
        End If
    End Sub
End Class
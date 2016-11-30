Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module Server_Interface
    Public SqlData As String = "Data Source=suznt004;Initial Catalog=KTE;Integrated Security=False;User ID=andy;Password=123;"

    Public ImagePath As String = "http://10.194.48.150:8080/image/"
    Public Endip, Endport, Endsend As String

    Public Sub Ledinterface(ByVal LocID As String, ByVal NO As String)
        Try
            Dim cn As SqlConnection
            Dim cm As SqlCommand
            cn = New SqlConnection(SqlData)
            cn.Open()
            Dim ii As String = "EXEC sp_Port '" & LocID & "'"
            cm = New SqlCommand(ii, cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            If ds.Tables(0).Rows.Count > 0 Then

                '--------------------------------------------------打开LED接口
                Dim ipval, portval, sendval As String
                ipval = ds.Tables(0).Rows(0)("ServerIP")
                portval = ds.Tables(0).Rows(0)("Port")
                sendval = ds.Tables(0).Rows(0)("SendMessage") + NO
                Endip = ipval
                Endport = portval
                Endsend = ds.Tables(0).Rows(0)("SendMessage")
                Send(ipval, portval, sendval)


            End If


        Catch ex As Exception

        End Try


    End Sub
    Public Sub LEDOpenclose(ByVal PNID As String, ByVal NO As String)
        Try
            Dim cn As SqlConnection
            Dim cm As SqlCommand
            cn = New SqlConnection(SqlData)
            cn.Open()
            Dim ii As String = "EXEC sp_LEDopenclose '" & PNID & "'"
            cm = New SqlCommand(ii, cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            If ds.Tables(0).Rows.Count > 0 Then

                '--------------------------------------------------打开LED接口
                Dim ipval, portval, sendval As String
                ipval = ds.Tables(0).Rows(0)("ServerIP")
                portval = ds.Tables(0).Rows(0)("Port")
                sendval = ds.Tables(0).Rows(0)("SendMessage") + NO
                Send(ipval, portval, sendval)


            End If


        Catch ex As Exception

        End Try


    End Sub

    Public Sub Send(ByVal IP As String, ByVal port As String, ByVal SendMsg As String)
        'Form1.Label25.Text = IP
        'Form1.Label26.Text = port
        'Form1.Label27.Text = SendMsg


        Try
            If IP <> "" And port <> "" Then
                Dim bytes(1024) As Byte
                Dim s = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim localEndPoint As New IPEndPoint(IPAddress.Parse(IP), port)
                s.Connect(localEndPoint)
                s.Send(Encoding.ASCII.GetBytes(SendMsg))
                s.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

End Module

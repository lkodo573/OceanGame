Public Class Form1



    Sub Move(P As PictureBox, X As Integer, Y As Integer)
        PictureBox3.Location = New Point(PictureBox3.Location.X + X, PictureBox3.Location.Y + Y)

    End Sub


    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        Chase(PictureBoxE)
    End Sub
    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        Chase(PictureRBoxE)
    End Sub
    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        Chase(PictureOBoxE)
    End Sub
    Private Sub Timer9_Tick(sender As Object, e As EventArgs) Handles Timer9.Tick
        Chase(PictureJBoxE)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Chase(CrabMan)
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        MoveTo(Bullet, 100, 0)
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        MoveTo(Bullet2, -100, 0)
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        MoveTo(Bullet3, 0, 100)
    End Sub
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        MoveTo(Bullet4, 0, -100)
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.R
                PictureBox3.Image.RotateFlip(RotateFlipType.Rotate180FlipY)
                Me.Refresh()
            Case Keys.Left, Keys.A
                MoveTo(PictureBox3, -10, 0)
                PictureBox3.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            Case Keys.Right, Keys.D
                MoveTo(PictureBox3, 10, 0)
            Case Keys.Up, Keys.W
                MoveTo(PictureBox3, 0, -10)
            Case Keys.Down, Keys.S
                MoveTo(PictureBox3, 0, 10)
            Case Keys.V
                Bullet4.Location = PictureBox3.Location
                Bullet4.Visible = True
                Timer5.Enabled = True
            Case Keys.C
                Bullet3.Location = PictureBox3.Location
                Bullet3.Visible = True
                Timer4.Enabled = True
            Case Keys.X
                Bullet2.Location = PictureBox3.Location
                Bullet2.Visible = True
                Timer3.Enabled = True
            Case Keys.Z
                Bullet.Location = PictureBox3.Location
                Bullet.Visible = True
                Timer2.Enabled = True
            Case Keys.Enter
                PictureRBoxE.Visible = True
                PictureBoxE.Visible = True
                PictureJBoxE.Visible = True
                PictureOBoxE.Visible = True
                InstructionsWall.Visible = False

            Case Else


        End Select
    End Sub



    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox3.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub Chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > PictureBox3.Location.X Then
            x = -3
        Else
            x = 3
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < PictureBox3.Location.Y Then
            y = 3
        Else
            y = -3
        End If
        MoveTo(p, x, y)

    End Sub

    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "PictureBox3" And Collision(p, "WIN", other) Then

            PictureBoxWin.BackColor = Color.Green
            Wiin.Visible = True
            Return

        End If



        If p.Name = "Bullet" And Collision(p, "PictureBoxx", other) Then
            Bullet.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            Me.Refresh()
            Return
        End If

        If p.Name = "EnemyBulet1" And Collision(p, "PictureBox3", other) Then
            Lose.Visible = True
            PictureBoxWin.Visible = False
            Return
        End If
        If p.Name = "EnemyBulet2" And Collision(p, "PictureBox3", other) Then
            Lose.Visible = True
            PictureBoxWin.Visible = False
            Return
        End If
        If p.Name = "EnemyBulet3" And Collision(p, "PictureBox3", other) Then
            Lose.Visible = True
            PictureBoxWin.Visible = False
            Return
        End If
        If p.Name = "EnemyBulet4" And Collision(p, "PictureBox3", other) Then
            Lose.Visible = True
            PictureBoxWin.Visible = False
            Return
        End If

        If p.Name = "Bullet" And Collision(p, "man") Then
            CrabMan.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            CrabMan.Visible = False
            PictureBoxWin.Visible = True
            Me.Refresh()

            Return
        End If
        If p.Name = "Bullet2" And Collision(p, "man") Then
            CrabMan.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            CrabMan.Visible = False
            PictureBoxWin.Visible = True
            Me.Refresh()

            Return

        End If
        If p.Name = "Bullet3" And Collision(p, "man") Then
            CrabMan.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            CrabMan.Visible = False
            PictureBoxWin.Visible = True
            Me.Refresh()

            Return

        End If
        If p.Name = "Bullet4" And Collision(p, "man") Then
            CrabMan.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            CrabMan.Visible = False
            PictureBoxWin.Visible = True
            Me.Refresh()

            Return

        End If
        If p.Name = "Bullet" And Collision(p, "BoxE", other) Then
            CrabMan.Visible = True
            Timer11.Enabled = True
            PictureBox1jxmWall.Visible = False
            PictureBox1im.Visible = False


            other.visible = False
            Me.Refresh()

            Return
        End If
        If p.Name = "Bullet2" And Collision(p, "BoxE", other) Then
            CrabMan.Visible = True
            Timer11.Enabled = True
            PictureBox1jxmWall.Visible = False
            PictureBox1im.Visible = False



            other.visible = False
            Me.Refresh()
            Return

        End If
        If p.Name = "Bullet3" And Collision(p, "BoxE", other) Then
            CrabMan.Visible = True
            Timer11.Enabled = True
            PictureBox1jxmWall.Visible = False
            PictureBox1im.Visible = False


            other.visible = False
            Me.Refresh()
            Return

        End If
        If p.Name = "Bullet4" And Collision(p, "BoxE", other) Then
            CrabMan.Visible = True
            Timer11.Enabled = True
            PictureBox1jxmWall.Visible = False
            PictureBox1im.Visible = False


            other.visible = False
            Me.Refresh()
            Return

        End If




    End Sub


    Private Sub CrabMan_Click(sender As Object, e As EventArgs) Handles CrabMan.Click

    End Sub



    Private Sub Timer12_Tick(sender As Object, e As EventArgs) Handles Timer12.Tick
        If CrabMan.Visible Then
            EnemyBulet1.Location = New Point(CrabMan.Location.X + 100, CrabMan.Location.Y + 100)
            EnemyBulet1.Visible = True
        End If

        If CrabMan.Visible Then
            EnemyBulet2.Location = New Point(CrabMan.Location.X + 100, CrabMan.Location.Y + 100)
            EnemyBulet2.Visible = True
        End If

        If CrabMan.Visible Then
            EnemyBulet3.Location = New Point(CrabMan.Location.X + 100, CrabMan.Location.Y + 100)
            EnemyBulet3.Visible = True
        End If

        If CrabMan.Visible Then
            EnemyBulet4.Location = New Point(CrabMan.Location.X + 100, CrabMan.Location.Y + 100)
            EnemyBulet4.Visible = True
        End If
    End Sub

    Private Sub Timer13_Tick(sender As Object, e As EventArgs) Handles Timer13.Tick
        MoveTo(EnemyBulet1, -150, 0)
        MoveTo(EnemyBulet2, 150, 0)
        MoveTo(EnemyBulet3, 0, 150)
        MoveTo(EnemyBulet4, 0, -150)
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class

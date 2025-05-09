﻿Public Class subframe
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btn_menu.Click
        If btn_menu.ContextMenuStrip IsNot Nothing Then
            btn_menu.ContextMenuStrip.Show(btn_menu, 0, btn_menu.Height)

        End If
    End Sub

    Private Sub btn_profile_Click(sender As Object, e As EventArgs) Handles btn_profile.Click
        btn_user.Text = "Hi, " & user_Username
        btn_administrator.Visible = isAdmin()

        If btn_profile.ContextMenuStrip IsNot Nothing Then
            btn_profile.ContextMenuStrip.Show(btn_profile, 0, btn_profile.Height)

        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        display_inMain(Login)
        Me.Close()
    End Sub

    Private Sub RecievingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecievingToolStripMenuItem.Click
        display_inSub(Recieving)
    End Sub

    Private Sub DeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveryToolStripMenuItem.Click
        display_inSub(Delivery)
    End Sub

    Private Sub RecievingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RecievingToolStripMenuItem1.Click
        display_inSub(Recieving_view)
    End Sub

    Private Sub DeliveryOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveryOUTToolStripMenuItem.Click
        display_inSub(Delivery_view)
    End Sub

    Private Sub StockMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReturnablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnablesToolStripMenuItem.Click
        display_inSub(Returnables)
    End Sub

    Private Sub ReturnBoxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnBoxToolStripMenuItem.Click
        display_inSub(return_view)
    End Sub

    Private Sub btn_stock_Click(sender As Object, e As EventArgs) Handles btn_stock.Click
        display_inSub(New StockMonitoring)
    End Sub

    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click
        display_inSub(add_user)
    End Sub
End Class
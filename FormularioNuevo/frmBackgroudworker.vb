Imports System.ComponentModel

Public Class frmBackgroudworker
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (BackgroundWorker1.IsBusy = False) Then

            '// Start the asynchronous operation.
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        For i = 1 To 100
            If (worker.CancellationPending = True) Then
                e.Cancel = True
                Exit For
            Else
                '// Perform a time consuming operation And report progress.
                System.Threading.Thread.Sleep(500)
                worker.ReportProgress(i)
            End If
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        resultLabel.Text = (e.ProgressPercentage.ToString() + "%")
        ProgressBar1.Value = Convert.ToInt32(e.ProgressPercentage.ToString())
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If (e.Cancelled = True) Then
            resultLabel.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            resultLabel.Text = "Error: " + e.Error.Message
        Else
            resultLabel.Text = "Done!"
        End If
    End Sub
End Class
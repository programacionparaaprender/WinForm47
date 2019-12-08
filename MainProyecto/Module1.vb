
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports FormularioNuevo

Module Module1
    <STAThread>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim Login As New LoginForm1
        'Login.ShowDialog()
        If (Login.condicion = 1) Then
            Application.Run(New frmDialogos())

        ElseIf (Login.condicion = 8) Then
            Application.Run(New frmTiempoReal())
        ElseIf (Login.condicion = 2) Then
            Application.Run(New frmBackgroudworker())

        ElseIf (Login.condicion = 3) Then
            Application.Run(New frmContrato())

        ElseIf (Login.condicion = 4) Then
            Application.Run(New MenuTooltipStrip())

        ElseIf (Login.condicion = 5) Then
            Application.Run(New frmTreeView())

        ElseIf (Login.condicion = 6) Then
            'Application.Run(New frmCrystalReport())

        ElseIf (Login.condicion = 7) Then
            Application.Run(New Form1())

        End If

        'Console.WriteLine("Ejemplo de aplicación visual basic")
        'Console.ReadKey()
    End Sub
End Module


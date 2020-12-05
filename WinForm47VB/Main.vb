Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Module Main
    <STAThread>
    Public Sub Main()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        '//Application.Run(New frmInforme())
        Application.Run(New Form1())
    End Sub
End Module

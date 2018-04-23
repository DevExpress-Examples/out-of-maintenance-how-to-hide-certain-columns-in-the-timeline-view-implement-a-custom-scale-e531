Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace TimelineTimeScales
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim scales As TimeScaleCollection = schedulerControl1.TimelineView.Scales

			scales.BeginUpdate()
			Try
				scales.Clear()
				scales.Add(New CustomTimeScaleDay())
				scales.Add(New CustomTimeScaleHour())
			Finally
				scales.EndUpdate()
			End Try

		End Sub
	End Class
End Namespace
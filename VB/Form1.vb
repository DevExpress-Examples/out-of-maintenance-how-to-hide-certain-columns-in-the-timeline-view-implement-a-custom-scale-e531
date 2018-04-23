Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace TimelineTimeScales
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			schedulerControl1.TimelineView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Always
			schedulerControl1.TimelineView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Always
			schedulerControl1.TimelineView.AppointmentDisplayOptions.TimeDisplayType = AppointmentTimeDisplayType.Text
			schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled
'			#Region "#changescales"
			Dim scales As TimeScaleCollection = schedulerControl1.TimelineView.Scales

			scales.BeginUpdate()
			Try
				scales.Clear()
				scales.Add(New CustomTimeScaleDay())
				scales.Add(New CustomTimeScaleHour())
			Finally
				scales.EndUpdate()
			End Try
'			#End Region ' #changescales

		End Sub
	End Class
End Namespace
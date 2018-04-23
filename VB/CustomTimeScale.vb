Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraScheduler

Namespace TimelineTimeScales

	Public Class CustomTimeScaleDay
		Inherits TimeScaleDay
		Public Overrides Function Floor(ByVal [date] As DateTime) As DateTime
			If [date] = DateTime.MinValue Then
				Return [date].AddHours(8)
			End If

			Dim start As DateTime = MyBase.Floor([date])
			If [date].Hour < 8 Then
				start = start.AddDays(-1)
			End If

			Return start.AddHours(8)
		End Function
	End Class
	Public Class CustomTimeScaleHour
		Inherits TimeScale
		Private Const StartHour As Integer = 8
		Private Const FinishHour As Integer = 19

		Protected Overrides ReadOnly Property DefaultDisplayFormat() As String
			Get
				Return "HH:mm"
			End Get
		End Property
		Protected Overrides ReadOnly Property DefaultMenuCaption() As String
			Get
				Return "8:00-19:00"
			End Get
		End Property

		Protected Overrides ReadOnly Property SortingWeight() As TimeSpan
			Get
				Return TimeSpan.FromHours(FinishHour - StartHour + 1)
			End Get
		End Property
		Public Overrides Function Floor(ByVal [date] As DateTime) As DateTime
			If [date] = DateTime.MinValue OrElse [date] = DateTime.MaxValue Then
				Return RoundToHour([date], [date].Hour)
			End If

			If [date].Hour < StartHour Then
				' Round down to the end of the previous working day.
				Return RoundToHour([date].AddDays(-1), FinishHour)
			End If

			If [date].Hour > FinishHour Then
				' Round down to the end of the current working day.
				Return RoundToHour([date], FinishHour)
			End If

			Return RoundToHour([date], [date].Hour)
		End Function
		Protected Function RoundToHour(ByVal [date] As DateTime, ByVal hour As Integer) As DateTime
			Return New DateTime([date].Year, [date].Month, [date].Day, hour, 0, 0)
		End Function
		Protected Overrides Function HasNextDate(ByVal [date] As DateTime) As Boolean
			Return [date] <= RoundToHour(DateTime.MaxValue, FinishHour)
		End Function
		Public Overrides Function GetNextDate(ByVal [date] As DateTime) As DateTime
			If ([date].Hour > FinishHour - 1) Then
				Return RoundToHour([date].AddDays(1), StartHour)
			Else
				Return [date].AddHours(1)
			End If
		End Function
	End Class

End Namespace

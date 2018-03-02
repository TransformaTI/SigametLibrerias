Public Class InactivityLock
    Public InactivityTime As Integer
    Dim _LockTime As Integer = 300000
    Dim _TimeParameter As Integer = 6000
    Dim _Units As TimeUnit = TimeUnit.Minutes

    Dim WithEvents tmrInactivityDetector As System.Timers.Timer

    Public Sub New()
        tmrInactivityDetector = New Timers.Timer()
        tmrInactivityDetector.Interval = 1
        tmrInactivityDetector.Enabled = True
    End Sub

    Public Enum TimeUnit As Byte
        Seconds = 0
        Minutes = 1
    End Enum

    Property LockTime() As Integer
        Get
            Return CInt(_LockTime / _TimeParameter)
        End Get
        Set(ByVal Value As Integer)
            _LockTime = Value * _TimeParameter
        End Set
    End Property

    Property TimeUnits() As TimeUnit
        Get
            Return _Units
        End Get
        Set(ByVal Value As TimeUnit)
            _Units = Value
            Select Case Value
                Case TimeUnit.Minutes
                    _TimeParameter = 6000
                Case TimeUnit.Seconds
                    _TimeParameter = 100
            End Select
        End Set
    End Property

    Property Enabled() As Boolean
        Get
            Return (tmrInactivityDetector.Enabled)
        End Get
        Set(ByVal Value As Boolean)
            tmrInactivityDetector.Enabled = Value
        End Set
    End Property

    Public Event Lock()

    Private Sub tmrInactivityDetector_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrInactivityDetector.Elapsed
        If Not InputCheck() Then
            InactivityTime += 1
        Else
            InactivityTime = 0
        End If
        If InactivityTime = _LockTime Then
            RaiseEvent Lock()
        End If
    End Sub

End Class

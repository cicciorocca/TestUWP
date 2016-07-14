Public Class CodiceFiscaleViewModel
    Public Delegate Sub LoadCompletedEventHandler(sender As Object, e As EventArgs)
    Public Event LoadCompleted As LoadCompletedEventHandler
    Private Worker As BackgroundWorker

    Public Property Soggetto As SoggettoFiscale

    Private _calcolaCfCommand As CalculateCommand
    Public Property CalcolaCfCommand As CalculateCommand
        Get
            If _calcolaCfCommand Is Nothing Then
                _calcolaCfCommand = New CalculateCommand()
            End If
            Return _calcolaCfCommand
        End Get
        Set(value As CalculateCommand)
            _calcolaCfCommand = value
        End Set
    End Property

    Private _Comuni As Object
    Public ReadOnly Property Comuni As Object
        Get
            Return _Comuni
        End Get
    End Property

    Private Sub Load()
        Soggetto = New SoggettoFiscale()
        Dim t As New TestJson
        t.GetComuni()

        _Comuni = t.lista
        RaiseEvent LoadCompleted(Me, Nothing)
    End Sub

    Public Sub Initialize()
        Worker.RunWorkerAsync()
    End Sub

    Public Sub New()
        Worker = New BackgroundWorker()
        AddHandler Worker.DoWork, AddressOf Load
    End Sub

End Class
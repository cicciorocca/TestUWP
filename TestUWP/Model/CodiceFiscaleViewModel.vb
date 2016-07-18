Public Class CodiceFiscaleViewModel
    Inherits ViewModelBase

    Public ReadOnly Property VmName As String = "Calcola"
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

    Private _Comuni As List(Of ComuneCodCat)
    Public ReadOnly Property Comuni As List(Of ComuneCodCat)
        Get
            Return _Comuni
        End Get
    End Property

    Public Overrides Function LoadViewModelAsync() As Object
        Soggetto = New SoggettoFiscale()

        If AppContext IsNot Nothing Then
            _Comuni = AppContext.Comuni.OrderBy(Of String)(Function(com) com.nome).ToList()
        End If

        Return Me
    End Function

End Class
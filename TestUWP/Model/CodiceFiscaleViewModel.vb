Imports Newtonsoft.Json

Public Class CodiceFiscaleViewModel
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

    Public Async Function LoadViewModelAsync() As Task(Of CodiceFiscaleViewModel)
        Soggetto = New SoggettoFiscale()

        'Caricamento dei comuni'
        Dim ComuniStorage As Windows.Storage.StorageFile = Await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(New Uri("ms-appx:///Resources/ComuniCodCat.json"))
        Dim StrJsonComuni As String = Await Windows.Storage.FileIO.ReadTextAsync(ComuniStorage)

        _Comuni = Await Task.Run(Function()
                                     Return JsonConvert.DeserializeObject(Of List(Of ComuneCodCat))(StrJsonComuni).OrderBy(Function(com) com.nome)
                                 End Function)
        Return Me
    End Function
End Class
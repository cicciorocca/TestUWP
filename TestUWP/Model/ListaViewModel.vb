Public Class ListaViewModel
    Inherits ViewModelBase

    Public ReadOnly Property VmName As String = "Lista"
    Public Property Soggetto As ObservableCollection(Of SoggettoFiscale)

    Public Overrides Function LoadViewModelAsync() As Task(Of Object)
        Throw New NotImplementedException()
    End Function
End Class

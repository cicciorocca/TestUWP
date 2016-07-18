Public Class ListaViewModel
    Inherits ViewModelBase

    Public ReadOnly Property VmName As String = "Lista"
    Public Property Soggetti As ObservableCollection(Of SoggettoFiscale)


    Public Overrides Function LoadViewModelAsync() As Object
        If AppContext IsNot Nothing Then
            Soggetti = New ObservableCollection(Of SoggettoFiscale)(AppContext.SoggettiFiscali.ToList())
        End If

        Return Me
    End Function

    Public Overrides Function GetAppBar() As List(Of AppBarButton)
        'TODO: Implementare command
        Return New List(Of AppBarButton)
    End Function
End Class

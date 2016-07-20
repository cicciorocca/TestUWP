Public MustInherit Class ViewModelBase
    Public Property AppContext As AppCodFiscContext

    Public MustOverride Function LoadViewModelAsync() As Object
    Public MustOverride Function GetAppBar() As List(Of AppBarButton)

    Public Delegate Sub ViewModelChangedHandler(sender As Object, e As PropertyChangedEventArgs)
End Class

Public Class MainViewModel
    Private Shared AppContext As AppCodFiscContext
    Public Property MainVm As List(Of Object)
    Public Property SelectedViewModel As ViewModelBase

    Public Function GetAppContextInstance() As AppCodFiscContext
        If AppContext Is Nothing Then
            AppContext = New AppCodFiscContext()
        End If

        Return AppContext
    End Function
End Class

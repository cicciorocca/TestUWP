﻿Public Class ListaViewModel
    Inherits ViewModelBase

    Public ReadOnly Property VmName As String = "Lista"
    Public Property Soggetto As ObservableCollection(Of SoggettoFiscale)


    Public Overrides Function LoadViewModelAsync() As Object
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetAppBar() As List(Of AppBarButton)
        Throw New NotImplementedException()
    End Function
End Class

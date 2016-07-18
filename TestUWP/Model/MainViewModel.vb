Public Class MainViewModel
    Implements INotifyPropertyChanged

    Private Shared AppContext As AppCodFiscContext
    Public Property MainVm As List(Of Object)

    Private _selectedViewModel As ViewModelBase
    Public Property SelectedViewModel As ViewModelBase
        Get
            Return _selectedViewModel
        End Get
        Set(value As ViewModelBase)
            _selectedViewModel = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("SelectedViewModel"))
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAppContextInstance() As AppCodFiscContext
        If AppContext Is Nothing Then
            AppContext = New AppCodFiscContext()
        End If

        Return AppContext
    End Function
End Class

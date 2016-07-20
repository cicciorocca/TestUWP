Public Class ListaViewModel
    Inherits ViewModelBase
    Implements INotifyPropertyChanged

    Public Event ViewModelChanged As ViewModelChangedHandler
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public ReadOnly Property VmName As String = "Lista"

    Private _Soggetti As ObservableCollection(Of SoggettoFiscale)
    Public Property Soggetti As ObservableCollection(Of SoggettoFiscale)
        Get
            Return _Soggetti
        End Get
        Set(value As ObservableCollection(Of SoggettoFiscale))
            _Soggetti = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Soggetti"))
        End Set
    End Property

    Private _selectedSoggetto As SoggettoFiscale
    Public Property SelectedSoggetto As SoggettoFiscale
        Get
            Return _selectedSoggetto
        End Get
        Set(value As SoggettoFiscale)
            _selectedSoggetto = value
            RaiseEvent ViewModelChanged(Me, New PropertyChangedEventArgs("SelectedSoggetto"))
        End Set
    End Property

    Public Overrides Function LoadViewModelAsync() As Object
        If AppContext IsNot Nothing Then
            Soggetti = New ObservableCollection(Of SoggettoFiscale)(AppContext.SoggettiFiscali.ToList())
        End If

        If Soggetti.Count > 0 Then
            SelectedSoggetto = Soggetti(0)
        End If

        Return Me
    End Function

    Public Overrides Function GetAppBar() As List(Of AppBarButton)
        Dim cmds As List(Of AppBarButton) = New List(Of AppBarButton)

        ' New Button '
        Dim addBtn As AppBarButton = New AppBarButton
        addBtn.Label = "Nuovo"
        addBtn.Icon = New SymbolIcon(Symbol.AddFriend)
        cmds.Add(addBtn)

        ' Delete Button '
        Dim deleteBtn As AppBarButton = New AppBarButton()
        deleteBtn.Label = "Elimina"
        deleteBtn.Icon = New SymbolIcon(Symbol.Delete)
        cmds.Add(deleteBtn)

        ' Edit Button '
        Dim editBtn As AppBarButton = New AppBarButton()
        editBtn.Label = "Modifica"
        editBtn.Icon = New SymbolIcon(Symbol.Edit)
        cmds.Add(editBtn)

        'saveBtn.SetBinding(AppBarButton.CommandProperty, New Binding() With {.Source = Me, .Path = New PropertyPath("SalvaCfCommand")})

        'TODO: Tessera Button '
        'TODO: New Button '

        Return cmds
    End Function

End Class

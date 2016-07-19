Imports GalaSoft.MvvmLight.Command

Public Class MainViewModel
    Inherits ViewModelBase
    Implements INotifyPropertyChanged

    Private Shared Shadows AppContext As AppCodFiscContext
    Public Property MainVm As List(Of Object)

    Private _selectedViewModel As ViewModelBase
    Public Property SelectedViewModel As ViewModelBase
        Get
            Return _selectedViewModel
        End Get
        Set(value As ViewModelBase)
            _selectedViewModel = value
            OnPropertyChanged("SelectedViewModel")
        End Set
    End Property

#Region "Commands"
    Private _canExecuteSalvaCf As Boolean
    Public ReadOnly Property CanExecuteSalvaCf As Boolean
        Get
            Return True
        End Get
    End Property

    Private _salvaCfCommand As RelayCommand
    Public Property SalvaCfCommand As RelayCommand
        Get
            If _salvaCfCommand Is Nothing Then
                Dim cfVm = CType(SelectedViewModel, CodiceFiscaleViewModel)
                _salvaCfCommand = New RelayCommand(AddressOf cfVm.SalvaCf, Function()
                                                                               Return True
                                                                           End Function)
            End If
            Return _salvaCfCommand
        End Get
        Set(value As RelayCommand)
            _salvaCfCommand = value
        End Set
    End Property
#End Region

    Public Function GetAppContextInstance() As AppCodFiscContext
        If AppContext Is Nothing Then
            AppContext = New AppCodFiscContext()
        End If

        Return AppContext
    End Function


    Public Overrides Function LoadViewModelAsync() As Object
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetAppBar() As List(Of AppBarButton)

        Dim cmds As List(Of AppBarButton) = New List(Of AppBarButton)

        If SelectedViewModel.GetType.Equals(GetType(CodiceFiscaleViewModel)) Then
            ' Save Button '
            Dim saveBtn As AppBarButton = New AppBarButton()
            With saveBtn
                .Label = "Salva"
                .Icon = New SymbolIcon(Symbol.Save)
            End With

            saveBtn.SetBinding(ButtonBase.CommandProperty, New Binding() With {.Source = Me, .Path = New PropertyPath("SalvaCfCommand")})

            'TODO: Delete Button '
            'TODO: Tessera Button '
            'TODO: New Button '

            cmds.Add(saveBtn)
        End If

        If SelectedViewModel.GetType.Equals(GetType(ListaViewModel)) Then

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
        End If

        Return cmds
    End Function

    Private Sub OnPropertyChanged(PropName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropName))
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class

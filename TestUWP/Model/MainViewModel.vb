Imports GalaSoft.MvvmLight.Command

Public Class MainViewModel
    Inherits ViewModelBase
    Implements INotifyPropertyChanged


    Public Sub New()
        ' Inizializzazione contenuto ViewModel '
        Dim CfVm As CodiceFiscaleViewModel = New CodiceFiscaleViewModel() With {.AppContext = GetAppContextInstance()}
        Dim LsVm As ListaViewModel = New ListaViewModel() With {.AppContext = GetAppContextInstance()}

        AddHandler CfVm.ViewModelChanged, AddressOf OnViewModelChanged
        AddHandler LsVm.ViewModelChanged, AddressOf OnViewModelChanged

        MainVm = New List(Of Object) From {LsVm, CfVm}

        SelectedViewModel = MainVm(0)
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
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
    Private _canExecuteSalvaSoggetto As Boolean
    Public ReadOnly Property CanExecuteSalvaSoggetto As Boolean
        Get
            Dim cfVm = CType(SelectedViewModel, CodiceFiscaleViewModel)
            Return (Not String.IsNullOrEmpty(cfVm.Soggetto.CodiceFiscale))
        End Get
    End Property

    Private _canExecuteEliminaSoggetto As Boolean
    Public ReadOnly Property CanExecuteEliminaSoggetto As Boolean
        Get
            Return (CType(SelectedViewModel, ListaViewModel).SelectedSoggetto IsNot Nothing)
        End Get
    End Property

    Private _salvaSoggettoCommand As RelayCommand
    Public Property SalvaSoggettoCommand As RelayCommand
        Get
            If _salvaSoggettoCommand Is Nothing Then
                Dim cfVm = CType(SelectedViewModel, CodiceFiscaleViewModel)
                _salvaSoggettoCommand = New RelayCommand(AddressOf SalvaSoggetto, Function()
                                                                                      Return CanExecuteSalvaSoggetto
                                                                                  End Function)
            End If
            Return _salvaSoggettoCommand
        End Get
        Set(value As RelayCommand)
            _salvaSoggettoCommand = value
        End Set
    End Property

    Private _eliminaSoggettoCommand As RelayCommand
    Public Property EliminaSoggettoCommand As RelayCommand
        Get
            If _eliminaSoggettoCommand Is Nothing Then
                Dim lsVm = CType(SelectedViewModel, ListaViewModel)
                _eliminaSoggettoCommand = New RelayCommand(AddressOf EliminaSoggetto, Function()
                                                                                          Return CanExecuteEliminaSoggetto
                                                                                      End Function)
            End If

            Return _eliminaSoggettoCommand
        End Get
        Set(value As RelayCommand)
            _eliminaSoggettoCommand = value
        End Set
    End Property

#End Region

    Private Sub EliminaSoggetto()
        Dim lsVm As ListaViewModel = SelectedViewModel
        If lsVm Is Nothing Then
            Return
        End If

        If AppContext IsNot Nothing Then
            AppContext.SoggettiFiscali.Remove(lsVm.SelectedSoggetto)

            AppContext.SaveChanges()
        End If
    End Sub

    Private Sub SalvaSoggetto()
        Dim CfVm As CodiceFiscaleViewModel = SelectedViewModel
        If CfVm Is Nothing Then
            Return
        End If
        If AppContext IsNot Nothing Then
            If Not AppContext.SoggettiFiscali.Contains(CfVm.Soggetto) Then
                AppContext.SoggettiFiscali.Add(CfVm.Soggetto)
            End If

            AppContext.SaveChanges()
        End If
    End Sub

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

            saveBtn.SetBinding(ButtonBase.CommandProperty, New Binding() With {.Source = Me, .Path = New PropertyPath("SalvaSoggettoCommand")})

            'TODO: Delete Button '
            'TODO: Tessera Button '
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
            deleteBtn.SetBinding(ButtonBase.CommandProperty, New Binding() With {.Source = Me, .Path = New PropertyPath("EliminaSoggettoCommand")})

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

    Private Sub OnViewModelChanged(sender As Object, e As PropertyChangedEventArgs)
        If sender.GetType.Equals(GetType(CodiceFiscaleViewModel)) Then
            SalvaSoggettoCommand.RaiseCanExecuteChanged()
        End If
        If sender.GetType.Equals(GetType(ListaViewModel)) Then
            EliminaSoggettoCommand.RaiseCanExecuteChanged()
        End If
    End Sub

    Private Sub OnPropertyChanged(PropName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropName))
    End Sub

End Class

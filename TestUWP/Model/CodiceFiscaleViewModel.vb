Imports GalaSoft.MvvmLight.Command

Public Class CodiceFiscaleViewModel
    Inherits ViewModelBase

    Public Sub New()
        Soggetto = New SoggettoFiscale()

        AddHandler Soggetto.PropertyChanged, AddressOf OnPropChanged
    End Sub

    Public ReadOnly Property VmName As String = "Calcola"

    Public Property Soggetto As SoggettoFiscale

    Private _Comuni As List(Of ComuneCodCat)
    Public ReadOnly Property Comuni As List(Of ComuneCodCat)
        Get
            Return _Comuni
        End Get
    End Property

#Region "Commands"
    Private _canExecuteSalvaCf As Boolean
    Public ReadOnly Property CanExecuteSalvaCf As Boolean
        Get
            Return True
        End Get
    End Property

    Private _canExecuteCalcolaCf As Boolean
    Public ReadOnly Property CanExecuteCalcolaCf As Boolean
        Get
            If Soggetto Is Nothing Then
                Return False
            End If
            Return (Soggetto.Cognome IsNot Nothing And Soggetto.Name IsNot Nothing And Not Soggetto.DataNascita.Equals(DateTime.MinValue) And Soggetto.CodiceCatastale IsNot Nothing)
        End Get
    End Property

    Private _calcolaCfCommand As RelayCommand
    Public Property CalcolaCfCommand As RelayCommand
        Get
            If _calcolaCfCommand Is Nothing Then
                _calcolaCfCommand = New RelayCommand(AddressOf CalcolaCf, Function()
                                                                              Return CanExecuteCalcolaCf
                                                                          End Function)
            End If
            Return _calcolaCfCommand
        End Get
        Set(value As RelayCommand)
            _calcolaCfCommand = value
        End Set
    End Property

    Private _salvaCfCommand As RelayCommand
    Public Property SalvaCfCommand As RelayCommand
        Get
            If _salvaCfCommand Is Nothing Then
                _salvaCfCommand = New RelayCommand(AddressOf SalvaCf, AddressOf CanSalvaCf)
            End If
            Return _salvaCfCommand
        End Get
        Set(value As RelayCommand)
            _salvaCfCommand = value
        End Set
    End Property

    Private Sub SalvaCf()
        If AppContext IsNot Nothing Then
            AppContext.SoggettiFiscali.Add(Soggetto)

            AppContext.SaveChanges()
        End If
    End Sub

    Private Function CanSalvaCf() As Boolean
        Return True
    End Function

    Private Sub CalcolaCf()
        Soggetto.CodiceFiscale = CodiceFiscaleHelper.CalcolaCodiceFiscale(nome:=Soggetto.Name, cognome:=Soggetto.Cognome,
                                             sesso:=Soggetto.Sesso, datanascita:=Soggetto.DataNascita, codicecatastale:=Soggetto.CodiceCatastale)
    End Sub

#End Region

    Public Overrides Function GetAppBar() As List(Of AppBarButton)
        Dim cmds As List(Of AppBarButton) = New List(Of AppBarButton)

        ' Save Button '
        Dim saveBtn As AppBarButton = New AppBarButton()
        With saveBtn
            .Label = "Salva"
            .Icon = New SymbolIcon(Symbol.Save)
        End With
        saveBtn.SetBinding(AppBarButton.CommandProperty, New Binding() With {.Source = Me, .Path = New PropertyPath("SalvaCfCommand")})

        'TODO: Delete Button '
        'TODO: Tessera Button '
        'TODO: New Button '


        cmds.Add(saveBtn)

        Return cmds
    End Function

    Private Sub OnPropChanged(sender As Object, e As PropertyChangedEventArgs)
        CalcolaCfCommand.RaiseCanExecuteChanged()
    End Sub

    Public Overrides Function LoadViewModelAsync() As Object
        If AppContext IsNot Nothing Then
            _Comuni = AppContext.Comuni.OrderBy(Of String)(Function(com) com.nome).ToList()
        End If

        Return Me
    End Function

End Class
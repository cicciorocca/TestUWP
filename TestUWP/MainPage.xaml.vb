''' <summary>
''' Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Vm As CodiceFiscaleViewModel
    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Vm = New CodiceFiscaleViewModel()

        AddHandler Vm.LoadCompleted, AddressOf LoadCompleted
        Vm.Initialize()
    End Sub

    Private Async Sub LoadCompleted(sender As Object, e As EventArgs)
        Await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, Sub()
                                                                                   DataContext = Vm
                                                                               End Sub)
    End Sub

    Private Sub OpenPane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = True
    End Sub

    Private Sub ClosePane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = False
    End Sub

End Class








''' <summary>
''' Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Vm As MainViewModel

    Public Sub New()
        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        Vm = New MainViewModel()

        DataContext = Vm
    End Sub

    Private Sub OpenPane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = True
    End Sub

    Private Sub ClosePane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = False
    End Sub

    Private Sub ListView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        CmdBar.PrimaryCommands.Clear()

        For Each cmd In Vm.GetAppBar
            CmdBar.PrimaryCommands.Add(cmd)
        Next
    End Sub
End Class








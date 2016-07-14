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

        Vm.MainVm = New List(Of Object) From {New CodiceFiscaleViewModel()}
        Vm.SelectedViewModel = Vm.MainVm(0)

        DataContext = Vm
    End Sub

    Private Sub OpenPane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = True
        'Dim l As List(Of ComuneCodCat) = New List(Of ComuneCodCat)()

        'For Each elem In Vm.Comuni
        '    l.Add(New ComuneCodCat() With {.nome = elem.nome, .codiceCatastale = elem.codiceCatastale})
        'Next

        'Dim serialized = JsonConvert.SerializeObject(l)

        ''Dim newFile As Windows.Storage.StorageFile = Await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("ComuniCodCat.json", Windows.Storage.CreationCollisionOption.ReplaceExisting)
        ''Await Windows.Storage.FileIO.WriteTextAsync(newFile, serialized)

        'Dim savePicker = New Windows.Storage.Pickers.FileSavePicker()
        'savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop
        'savePicker.FileTypeChoices.Add("Json", New List(Of String)() From {".json"})

        'Dim newFile As Windows.Storage.StorageFile = Await savePicker.PickSaveFileAsync()
        'If newFile IsNot Nothing Then
        '    Await Windows.Storage.FileIO.WriteTextAsync(newFile, serialized)
        'End If

    End Sub

    Private Sub ClosePane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = False
    End Sub


End Class








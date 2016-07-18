﻿''' <summary>
''' Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Vm As MainViewModel

    Public Sub New()
        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        Vm = New MainViewModel()

        Vm.MainVm = New List(Of Object) From {New CodiceFiscaleViewModel() With {.AppContext = Vm.GetAppContextInstance()}}
        Vm.SelectedViewModel = Vm.MainVm(0)


        DataContext = Vm
    End Sub

    Private Sub OpenPane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = True
    End Sub

    Private Sub ClosePane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = False
    End Sub


End Class








' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Public NotInheritable Class CalcoloCfView
    Inherits UserControl


    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim Vm As Object = DataContext
        DataContext = Nothing
        Vm = Await Vm.LoadViewModelAsync()

        Await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, Sub()
                                                                                   DataContext = Vm

                                                                                   Dim parent As FrameworkElement = VisualTreeHelper.GetParent(Me)
                                                                                   While Not parent.GetType.Equals(GetType(MainPage))
                                                                                       parent = VisualTreeHelper.GetParent(parent)
                                                                                   End While
                                                                                   parent.FindName("ProgrRing").IsActive = False
                                                                                   parent.FindName("ProgrRing").Visibility = Visibility.Collapsed
                                                                               End Sub)
    End Sub
End Class

Public Class CalculateCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim obj As CodiceFiscaleViewModel = parameter
        If obj Is Nothing Then
            Return
        End If
        obj.Soggetto.CodiceFiscale = CodiceFiscaleHelper.CalcolaCodiceFiscale(nome:=obj.Soggetto.Name, cognome:=obj.Soggetto.Cognome,
                                             sesso:=obj.Soggetto.Sesso, datanascita:=obj.Soggetto.DataNascita, codicecatastale:=obj.Soggetto.CodiceCatastale)
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
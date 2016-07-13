' Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

''' <summary>
''' Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        DataContext = New CodiceFiscaleViewModel()
    End Sub

    Private Sub OpenPane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = True
    End Sub

    Private Sub ClosePane(sender As Object, e As RoutedEventArgs)
        MainView.IsPaneOpen = False
    End Sub

End Class

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

Public Class CodiceFiscaleViewModel
    Public Property Soggetto As SoggettoFiscale

    Private _calcolaCfCommand As CalculateCommand
    Public Property CalcolaCfCommand As CalculateCommand
        Get
            If _calcolaCfCommand Is Nothing Then
                _calcolaCfCommand = New CalculateCommand()
            End If
            Return _calcolaCfCommand
        End Get
        Set(value As CalculateCommand)
            _calcolaCfCommand = value
        End Set
    End Property

    Private _Comuni As Object
    Public ReadOnly Property Comuni As Object
        Get
            Return _Comuni
        End Get
    End Property

    Public Sub New()
        Soggetto = New SoggettoFiscale()
        Dim t As New TestJson
        t.GetComuni()

        _Comuni = t.lista
    End Sub

End Class

Public Enum Sex
    M
    F
End Enum

Public Class SoggettoFiscale
    Implements INotifyPropertyChanged

    Private _Name As String
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
            OnPropertyChanged("Name")
        End Set
    End Property

    Private _Cognome As String
    Public Property Cognome As String
        Get
            Return _Cognome
        End Get
        Set(value As String)
            _Cognome = value
            OnPropertyChanged("Cognome")
        End Set
    End Property

    Private _Sesso As Sex
    Public Property Sesso As Sex
        Get
            Return _Sesso
        End Get
        Set(value As Sex)
            _Sesso = value
            OnPropertyChanged("Sesso")
        End Set
    End Property

    Private _DataNascita As Date
    Public Property DataNascita As Date
        Get
            Return _DataNascita
        End Get
        Set(value As Date)
            _DataNascita = value
            OnPropertyChanged("DataNascita")
        End Set
    End Property

    Private _CodiceCatastale As String
    Public Property CodiceCatastale As String
        Get
            Return _CodiceCatastale
        End Get
        Set(value As String)
            _CodiceCatastale = value
            OnPropertyChanged("CodiceCatastale")
        End Set
    End Property

    Private _CodiceFiscale As String
    Public Property CodiceFiscale As String
        Get
            Return _CodiceFiscale
        End Get
        Set(value As String)
            _CodiceFiscale = value
            OnPropertyChanged("CodiceFiscale")
        End Set
    End Property

    Public Sub New()
        Name = ""
        Cognome = ""
        Sesso = Sex.M
        DataNascita = Date.Today
    End Sub

    Private Sub OnPropertyChanged(ByVal PropertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class

Public Class SexToBooleanConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        If value Is Nothing Then
            Return False
        End If

        If parameter Is Nothing Then
            Return False
        End If

        If parameter.Equals("M") Then
            Return (value = 0)
        End If

        If parameter.Equals("F") Then
            Return (value = 1)
        End If

        Return False
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        If value Is Nothing Then
            Return 0
        End If

        If parameter Is Nothing Then
            Return 0
        End If

        If parameter.Equals("M") Then
            If value Then
                Return 0
            End If
        End If

        If parameter.Equals("F") Then
            Return 1
        End If

        Return 0
    End Function
End Class

Public Class DateToDatetimeOffset
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        If value Is Nothing Then
            Return New DateTimeOffset(Date.Now)
        End If

        Return New DateTimeOffset(value)

    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        If value Is Nothing Then
            Return Date.MinValue
        End If

        Return CType(value, DateTimeOffset).DateTime
    End Function
End Class

Public Class CodiceFiscaleHelper

    Private Shared ReadOnly TabChrDispari As Dictionary(Of Char, UShort) =
            New Dictionary(Of Char, UShort) _
            From {{"0", 1}, {"1", 0}, {"2", 5}, {"3", 7}, {"4", 9}, {"5", 13}, {"6", 15},
                    {"7", 17}, {"8", 19}, {"9", 21}, {"A", 1}, {"B", 0}, {"C", 5}, {"D", 7}, {"E", 9},
                    {"F", 13}, {"G", 15}, {"H", 17}, {"I", 19}, {"J", 21}, {"K", 2}, {"L", 4}, {"M", 18},
                    {"N", 20}, {"O", 11}, {"P", 3}, {"Q", 6}, {"R", 8}, {"S", 12}, {"T", 14}, {"U", 16},
                    {"V", 10}, {"W", 22}, {"X", 25}, {"Y", 24}, {"Z", 23}}

    Private Shared ReadOnly TabChrPari As Dictionary(Of Char, UShort) =
            New Dictionary(Of Char, UShort) _
            From {{"0", 0}, {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6},
                    {"7", 7}, {"8", 8}, {"9", 9}, {"A", 0}, {"B", 1}, {"C", 2}, {"D", 3}, {"E", 4},
                    {"F", 5}, {"G", 6}, {"H", 7}, {"I", 8}, {"J", 9}, {"K", 10}, {"L", 11}, {"M", 12},
                    {"N", 13}, {"O", 14}, {"P", 15}, {"Q", 16}, {"R", 17}, {"S", 18}, {"T", 19}, {"U", 20},
                    {"V", 21}, {"W", 22}, {"X", 23}, {"Y", 24}, {"Z", 25}}

    Private Shared ReadOnly Resto As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    Private Shared ReadOnly Mesi As String() = {"", "A", "B", "C", "D", "E", "H", "L", "M", "P", "R", "S", "T"}

    Private Shared ReadOnly Vocali As String = "AEIOU"

    Private Shared ReadOnly Consonanti As String = "BCDFGHJKLMNPQRSTVWXYZ"

    Public Shared Function CalcolaCodiceFiscale(nome As String, cognome As String, sesso As Sex, datanascita As Date, codicecatastale As String) As String
        Dim CodiceFiscale As String = String.Empty
        Dim DayString As String = String.Empty
        Dim MonString As String = String.Empty
        Dim YeaString As String = String.Empty
        Dim SurString As String = String.Empty
        Dim NamString As String = String.Empty

        If sesso = Sex.M Then
            DayString = datanascita.Day.ToString("00")
        Else
            DayString = (datanascita.Day + 40).ToString("00")
        End If
        MonString = Mesi(datanascita.Month)
        YeaString = datanascita.Year.ToString("0000").Substring(2)

        Dim SurnameWithoutSpaces As String = cognome.Replace(" ", "").Trim().ToUpper()
        Dim NameWithourSpaces As String = nome.Replace(" ", "").Trim().ToUpper()

        SurString = ((New String((From lett In SurnameWithoutSpaces Where Consonanti.Contains(lett) Select lett).ToArray())) +
                            (New String((From lett In SurnameWithoutSpaces Where Not Consonanti.Contains(lett) Select lett).ToArray()))).PadRight(3, "X").Substring(0, 3)

        Dim NomeSenzaVocali As String = New String((From lett In NameWithourSpaces Where Consonanti.Contains(lett) Select lett).ToArray())

        If NomeSenzaVocali.Length <= 3 Then
            NamString = (NomeSenzaVocali + (New String((From lett In NameWithourSpaces Where Not Consonanti.Contains(lett) Select lett).ToArray()))).PadRight(3, "X").Substring(0, 3)
        Else
            NamString = NomeSenzaVocali(0) + NomeSenzaVocali(2) + NomeSenzaVocali(3)
        End If

        Dim TempCodice As String = SurString + NamString + YeaString + MonString + DayString + codicecatastale.Trim()
        CodiceFiscale = TempCodice + CalcoloCin(TempCodice)

        Return CodiceFiscale
    End Function

    Public Shared Function CalcoloCin(codice As String)
        Dim ValChar As UShort = 0
        For i As UShort = 0 To codice.Length - 1
            ValChar = ValChar + If((i + 1) Mod 2 = 0, TabChrPari(codice(i)), TabChrDispari(codice(i)))
        Next

        Return Resto(ValChar Mod 26)
    End Function
End Class
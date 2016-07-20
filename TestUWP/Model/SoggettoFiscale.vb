
Public Enum Sex
    M
    F
End Enum

Public Class SoggettoFiscale
    Implements INotifyPropertyChanged

    Public Property SoggettoFiscaleId As Integer

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
        CodiceCatastale = ""
        CodiceFiscale = ""
    End Sub

    Private Sub OnPropertyChanged(ByVal PropertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class

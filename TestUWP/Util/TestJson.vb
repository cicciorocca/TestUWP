Imports Newtonsoft.Json

Public Class TestJson

    Public Property lista As Object

    Public Async Function GetComuni() As Task(Of Object)
        'Dim fs As FileStream = New FileStream("C:\Users\FRANCESCO\Desktop\comuni.json.txt", FileMode.Open, FileAccess.Read, FileShare.None, bufferSize:=4096, useAsync:=True)
        'Dim Sr As StreamReader = New StreamReader(fs)

        Dim sampleFile As Windows.Storage.StorageFile = Await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(New Uri("ms-appx:///Resources/comuni.json.txt"))
        Dim StrJson As String = Await Windows.Storage.FileIO.ReadTextAsync(sampleFile)
        'Dim StrJson As String = Await File.ReadAllText("C:\Users\FRANCESCO\Desktop\comuni.json.txt")
        lista = Await Task.Run(Function()
                                   Return JsonConvert.DeserializeObject(Of List(Of Comune))(StrJson).OrderBy(Function(com) com.nome)
                               End Function)
        Return lista
    End Function

End Class

Public Class ComuneCodCat
    Public Property nome() As String
        Get
            Return m_nome
        End Get
        Set
            m_nome = Value
        End Set
    End Property
    Private m_nome As String

    Public Property codiceCatastale() As String
        Get
            Return m_codiceCatastale
        End Get
        Set
            m_codiceCatastale = Value
        End Set
    End Property
    Private m_codiceCatastale As String
End Class

Public Class Zona
    Public Property nome() As String
        Get
            Return m_nome
        End Get
        Set
            m_nome = Value
        End Set
    End Property
    Private m_nome As String
    Public Property codice() As String
        Get
            Return m_codice
        End Get
        Set
            m_codice = Value
        End Set
    End Property
    Private m_codice As String
End Class

Public Class Regione
    Public Property codice() As String
        Get
            Return m_codice
        End Get
        Set
            m_codice = Value
        End Set
    End Property
    Private m_codice As String
    Public Property nome() As String
        Get
            Return m_nome
        End Get
        Set
            m_nome = Value
        End Set
    End Property
    Private m_nome As String
End Class

Public Class Cm
    Public Property codice() As String
        Get
            Return m_codice
        End Get
        Set
            m_codice = Value
        End Set
    End Property
    Private m_codice As String
    Public Property nome() As String
        Get
            Return m_nome
        End Get
        Set
            m_nome = Value
        End Set
    End Property
    Private m_nome As String
End Class

Public Class Provincia
    Public Property codice() As String
        Get
            Return m_codice
        End Get
        Set
            m_codice = Value
        End Set
    End Property
    Private m_codice As String
    Public Property nome() As String
        Get
            Return m_nome
        End Get
        Set
            m_nome = Value
        End Set
    End Property
    Private m_nome As String
End Class

Public Class Comune
    Public Property nome() As String
        Get
            Return m_nome
        End Get
        Set
            m_nome = Value
        End Set
    End Property
    Private m_nome As String
    Public Property codice() As String
        Get
            Return m_codice
        End Get
        Set
            m_codice = Value
        End Set
    End Property
    Private m_codice As String
    Public Property zona() As Zona
        Get
            Return m_zona
        End Get
        Set
            m_zona = Value
        End Set
    End Property
    Private m_zona As Zona
    Public Property regione() As Regione
        Get
            Return m_regione
        End Get
        Set
            m_regione = Value
        End Set
    End Property
    Private m_regione As Regione
    Public Property cm() As Cm
        Get
            Return m_cm
        End Get
        Set
            m_cm = Value
        End Set
    End Property
    Private m_cm As Cm
    Public Property provincia() As Provincia
        Get
            Return m_provincia
        End Get
        Set
            m_provincia = Value
        End Set
    End Property
    Private m_provincia As Provincia
    Public Property sigla() As String
        Get
            Return m_sigla
        End Get
        Set
            m_sigla = Value
        End Set
    End Property
    Private m_sigla As String
    Public Property codiceCatastale() As String
        Get
            Return m_codiceCatastale
        End Get
        Set
            m_codiceCatastale = Value
        End Set
    End Property
    Private m_codiceCatastale As String
    Public Property cap() As Object
        Get
            Return m_cap
        End Get
        Set
            m_cap = Value
        End Set
    End Property
    Private m_cap As Object
End Class
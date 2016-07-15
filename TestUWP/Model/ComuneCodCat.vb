Public Class ComuneCodCat

    Public Property ComuneCodCatId As Integer

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

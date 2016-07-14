Public Class Template
    Public Property DataType As String
    Public Property DataTemplate As DataTemplate
End Class

Public Class TemplateCollection
    Inherits Collection(Of Template)
End Class

Public Class MyDataTemplateSelector
    Inherits DataTemplateSelector

    Public Property Templates As TemplateCollection
    Private Property _templateCache As IList(Of Template)

    Public Sub New()
    End Sub

    Private Sub InitTemplateCollection()
        _templateCache = Templates.ToList()
    End Sub

    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        If _templateCache Is Nothing Then
            InitTemplateCollection()
        End If

        If item IsNot Nothing Then
            Dim datatype = item.GetType.ToString()
            Dim match = _templateCache.Where(Function(m) m.DataType = datatype).FirstOrDefault()

            If match IsNot Nothing Then
                Return match.DataTemplate
            End If
        End If

        Return MyBase.SelectTemplateCore(item, container)
    End Function

End Class

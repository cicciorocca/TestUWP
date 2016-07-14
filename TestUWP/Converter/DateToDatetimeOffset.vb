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
Public Class StringaToInizialeConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        If value Is Nothing Then
            Return String.Empty
        End If

        Return value.ToString().PadLeft(1, " ").Substring(0, 1).ToUpper()

    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

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


Imports Microsoft.EntityFrameworkCore
Imports Windows.Storage

Public Class AppCodFiscContext
    Inherits DbContext

    Public Property SoggettiFiscali As DbSet(Of SoggettoFiscale)
    Public Property Comuni As DbSet(Of ComuneCodCat)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        Dim path As String = ApplicationData.Current.LocalFolder.Path
        If Not File.Exists(IO.Path.Combine(path, "AppCodfisc.db")) Then
            File.Create(IO.Path.Combine(path, "AppCodfisc.db"))
        End If
        optionsBuilder.UseSqlite("Data Source=" + IO.Path.Combine(path, "AppCodfisc.db") + ";")
    End Sub

End Class

Imports Microsoft.EntityFrameworkCore

Public Class AppCodFiscContext
    Inherits DbContext

    Public Property SoggettiFiscali As DbSet(Of SoggettoFiscale)
    Public Property Comuni As DbSet(Of ComuneCodCat)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlite("Filename=AppCodfisc.db")
    End Sub
End Class

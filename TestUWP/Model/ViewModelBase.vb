Public MustInherit Class ViewModelBase
    Public Property AppContext As AppCodFiscContext

    Public MustOverride Function LoadViewModelAsync() As Object
End Class

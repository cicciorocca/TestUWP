Public MustInherit Class ViewModelBase
    Public MustOverride Async Function LoadViewModelAsync() As Task(Of Object)
End Class

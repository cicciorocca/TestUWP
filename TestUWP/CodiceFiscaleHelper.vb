Public Class CodiceFiscaleHelper

    Private Shared ReadOnly TabChrDispari As Dictionary(Of Char, UShort) =
            New Dictionary(Of Char, UShort) _
            From {{"0", 1}, {"1", 0}, {"2", 5}, {"3", 7}, {"4", 9}, {"5", 13}, {"6", 15},
                    {"7", 17}, {"8", 19}, {"9", 21}, {"A", 1}, {"B", 0}, {"C", 5}, {"D", 7}, {"E", 9},
                    {"F", 13}, {"G", 15}, {"H", 17}, {"I", 19}, {"J", 21}, {"K", 2}, {"L", 4}, {"M", 18},
                    {"N", 20}, {"O", 11}, {"P", 3}, {"Q", 6}, {"R", 8}, {"S", 12}, {"T", 14}, {"U", 16},
                    {"V", 10}, {"W", 22}, {"X", 25}, {"Y", 24}, {"Z", 23}}

    Private Shared ReadOnly TabChrPari As Dictionary(Of Char, UShort) =
            New Dictionary(Of Char, UShort) _
            From {{"0", 0}, {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6},
                    {"7", 7}, {"8", 8}, {"9", 9}, {"A", 0}, {"B", 1}, {"C", 2}, {"D", 3}, {"E", 4},
                    {"F", 5}, {"G", 6}, {"H", 7}, {"I", 8}, {"J", 9}, {"K", 10}, {"L", 11}, {"M", 12},
                    {"N", 13}, {"O", 14}, {"P", 15}, {"Q", 16}, {"R", 17}, {"S", 18}, {"T", 19}, {"U", 20},
                    {"V", 21}, {"W", 22}, {"X", 23}, {"Y", 24}, {"Z", 25}}

    Private Shared ReadOnly Resto As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    Private Shared ReadOnly Mesi As String() = {"", "A", "B", "C", "D", "E", "H", "L", "M", "P", "R", "S", "T"}

    Private Shared ReadOnly Vocali As String = "AEIOU"

    Private Shared ReadOnly Consonanti As String = "BCDFGHJKLMNPQRSTVWXYZ"

    Public Shared Function CalcolaCodiceFiscale(nome As String, cognome As String, sesso As Sex, datanascita As Date, codicecatastale As String) As String
        Dim CodiceFiscale As String = String.Empty
        Dim DayString As String = String.Empty
        Dim MonString As String = String.Empty
        Dim YeaString As String = String.Empty
        Dim SurString As String = String.Empty
        Dim NamString As String = String.Empty

        If sesso = Sex.M Then
            DayString = datanascita.Day.ToString("00")
        Else
            DayString = (datanascita.Day + 40).ToString("00")
        End If
        MonString = Mesi(datanascita.Month)
        YeaString = datanascita.Year.ToString("0000").Substring(2)

        Dim SurnameWithoutSpaces As String = cognome.Replace(" ", "").Trim().ToUpper()
        Dim NameWithourSpaces As String = nome.Replace(" ", "").Trim().ToUpper()

        SurString = ((New String((From lett In SurnameWithoutSpaces Where Consonanti.Contains(lett) Select lett).ToArray())) +
                            (New String((From lett In SurnameWithoutSpaces Where Not Consonanti.Contains(lett) Select lett).ToArray()))).PadRight(3, "X").Substring(0, 3)

        Dim NomeSenzaVocali As String = New String((From lett In NameWithourSpaces Where Consonanti.Contains(lett) Select lett).ToArray())

        If NomeSenzaVocali.Length <= 3 Then
            NamString = (NomeSenzaVocali + (New String((From lett In NameWithourSpaces Where Not Consonanti.Contains(lett) Select lett).ToArray()))).PadRight(3, "X").Substring(0, 3)
        Else
            NamString = NomeSenzaVocali(0) + NomeSenzaVocali(2) + NomeSenzaVocali(3)
        End If

        Dim TempCodice As String = SurString + NamString + YeaString + MonString + DayString + codicecatastale.Trim()
        CodiceFiscale = TempCodice + CalcoloCin(TempCodice)

        Return CodiceFiscale
    End Function

    Public Shared Function CalcoloCin(codice As String)
        Dim ValChar As UShort = 0
        For i As UShort = 0 To codice.Length - 1
            ValChar = ValChar + If((i + 1) Mod 2 = 0, TabChrPari(codice(i)), TabChrDispari(codice(i)))
        Next

        Return Resto(ValChar Mod 26)
    End Function
End Class
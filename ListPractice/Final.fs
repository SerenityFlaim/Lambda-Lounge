module Final
open System
let areLettersOrdered str =
    let lowercaseLetters = 
        str 
        |> Seq.filter System.Char.IsLower
        |> Seq.toList
    
    let rec isOrdered list = 
        match list with
        | [] | [_] -> true
        | x::y::rest -> x <= y && isOrdered (y::rest)
    
    isOrdered lowercaseLetters
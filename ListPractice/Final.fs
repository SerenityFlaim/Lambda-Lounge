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

let sortStringByFrequencyDeviation (input: string) (langFreq: Map<char, float>) =
    let inputFreq =
        input
        |> Seq.filter Char.IsLetter
        |> Seq.countBy id
        |> Seq.map (fun (c, cnt) -> (c, float cnt / float input.Length))
        |> Map.ofSeq

    let mostFreqChar = 
        inputFreq
        |> Map.toSeq
        |> Seq.maxBy snd
        |> fst

    let langFreqValue = 
        langFreq 
        |> Map.tryFind mostFreqChar 
        |> Option.defaultValue 0.0

    let charDeviations =
        input
        |> Seq.distinct
        |> Seq.map (fun c ->
            let inputFreqValue = Map.tryFind c inputFreq |> Option.defaultValue 0.0
            let langFreqValue = Map.tryFind c langFreq |> Option.defaultValue 0.0
            let deviation = (inputFreqValue - langFreqValue) ** 2.0
            (c, deviation))
        |> Map.ofSeq

    let sortedChars =
        input
        |> Seq.sortBy (fun c -> 
            Map.find c charDeviations)
        |> Seq.toArray

    String(sortedChars)
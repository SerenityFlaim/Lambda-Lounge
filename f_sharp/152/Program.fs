open System

let setOfNumbers = [2;3;4;5;6;7;8;9;10;12;14;15;16;18;20;21;24;25;27;28;30;32;35;36;40;42;45;48;49;50;54;56;60;63;64;70;72;75;80]
// let setOfNumbers = [2;3;4;5;6;7;9;10;12;15;20;28;30;35;36;40;45] //,48;49;50;54;56;60;63;64;70;72;75;80]
let lcm = 4480842240000L
let inverses = setOfNumbers |> List.map (fun x -> lcm / int64(x * x))
let half = lcm / 2L

let residuals =
    [ for i in 0 .. setOfNumbers.Length - 1 do
        List.sum inverses[i..inverses.Length-1] ]

let realNumbers (indices: int list) =
    [ for j in indices -> setOfNumbers[j] ]

let rec find (remainder: int64) (startIndex: int) (factors: int list) = seq {
    if remainder = 0L then
        yield factors
    else
        for j in startIndex .. setOfNumbers.Length - 1 do
            let newRemainder = remainder - inverses[j]
            if newRemainder >= 0L then
                let newFactors = factors @ [j]
                yield! find newRemainder (j + 1) newFactors
            elif remainder > residuals[j] then
                // printfn "%d %d %d %d" setOfNumbers[j] remainder residuals[j] inverses[j]
                ()
}

let euler152() =
    let fmt = "yyyy-MM-dd HH:mm:ss"
    printfn "Start %s" (DateTime.UtcNow.ToString(fmt))
    find half 0 []
    |> Seq.mapi (fun i x -> (i, DateTime.UtcNow, realNumbers x))
    |> Seq.iter (fun (i, time, nums) -> printfn "%d %s %A" i (time.ToString(fmt)) nums)
    printfn "End %s" (DateTime.UtcNow.ToString(fmt))

[<EntryPoint>]
let main argv =
    euler152()
    0
open System

let setOfNumbers = [2;3;4;5;6;7;8;9;10;12;14;15;16;18;20;21;24;25;27;28;30;32;35;36;40;42;45;48;49;50;54;56;60;63;64;70;72;75;80]
let lcm = 4480842240000L
let inverses = setOfNumbers |> List.map (fun x -> lcm / int64(x * x))
let half = lcm / 2L

let residuals =
    let _, result =
        List.foldBack (fun x (accSum, accList) ->
            let newSum = x + accSum
            (newSum, newSum :: accList)
        ) inverses (0L, [])
    result

let realNumbers (indices: int list) =
    indices |> List.map (fun j -> List.item j setOfNumbers)

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
let countDigits number =
    let rec countTail number acc =
        match number with
        | 0 -> acc
        | n ->
            let digit = n % 10
            let next = n / 10
            countTail next (digit :: acc)
    countTail number []

let findBestDivisor number =
    let digits = countDigits number
    let rec findTail d bestDiv bestCount =
        match d with
        | d when d > number -> bestDiv
        | _ ->
            let mutualPrimeCount = List.fold (fun acc digit -> if gcd d digit = 1 then acc + 1 else acc) 0 digits
            let (newBestDiv, newBestCount) =
                if number % d = 0 && mutualPrimeCount > bestCount then (d, mutualPrimeCount)
                else (bestDiv, bestCount)
            findTail (d + 1) newBestDiv newBestCount
    findTail 1 1 0
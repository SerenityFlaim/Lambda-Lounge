module MyNumbers
open Numbers
open Euler
open System

let rec gcd x y = 
    match y with
    | 0 -> x
    | _ -> gcd y (x % y)

// let countPrimeDivisors number = 
//     let rec countTail number acc temp = 
//         match temp with
//         | 0 -> acc
//         | _ -> 
//             let newAcc = if gcd number temp = 1 then acc+1 else acc
//             countTail number newAcc (temp-1)
//     countTail number 0 number

let countPrimeDivisors number = 
    EulerFunction number

// let countDigitDivisors3 number = 
//     let rec countTail number acc = 
//         match number with
//         | 0 -> acc
//         | n ->
//             let digit = number % 10
//             let next = number / 10
//             let newAcc = if digit % 3 = 0 then acc+digit else acc
//             countTail next newAcc
//     countTail number 0

let countDigitDivisors3 number = 
    digitTraverseCondition number (+) 0 (fun x -> x % 3 = 0)

// let primeDigitTraverse number div = 
//     let rec primeTail number div acc = 
//         match number with
//         | 0 -> acc
//         | _ -> 
//             let digit = number % 10
//             let next = number / 10
//             let newAcc = if gcd digit div = 1 then acc + 1 else acc
//             primeTail next div newAcc
//     primeTail number div 0

let primeDigitTraverse number div = 
    digitTraverseCondition number (fun x y -> x+1) 0 (fun x -> gcd x div = 1)

let findBestDivisor number = 
    let rec findTail div bestDiv bestCount = 
        match div with
        | 1 -> bestDiv
        | _ ->
            let mutualPrimeCount = primeDigitTraverse number div
            let (newBestDiv, newBestCount) = 
                if number % div = 0 && mutualPrimeCount > bestCount then (div, mutualPrimeCount)
                else (bestDiv, bestCount)
            findTail (div-1) newBestDiv newBestCount
    findTail number 1 0
module Euler

let rec gcd x y = 
    match y with
    | 0 -> x
    | _ -> gcd y (x % y)

let mutPrimeTraverse number (func :int->int->int) init =
    let rec primeTail number acc temp =
        match temp with
        | 0 -> acc
        | _ -> 
            let newAcc = if gcd number temp = 1 then (func acc temp) else acc
            primeTail number newAcc (temp-1)
    primeTail number init number

let EulerFunction number = 
    mutPrimeTraverse number (fun x y -> x+1) 0

let mutPrimeTraverseCondition number (func :int->int->int) (cond :int->bool) init = 
    let rec primeTail number acc temp = 
        match temp with
        | 0 -> acc
        | _ -> 
            let next = temp-1
            let isPrime = if gcd number temp = 1 then true else false
            let flag = cond temp
            match isPrime, flag with
            | true, true -> primeTail number (func acc temp) next
            | _ -> primeTail number acc next
    primeTail number init number
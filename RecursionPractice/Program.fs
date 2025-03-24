﻿open System
open Numbers

[<EntryPoint>]
    let main (argv :string[]) = 

        Console.WriteLine("<---------------->")
        Console.WriteLine("Factorial vs DigitSum choice")
        let testSum = sumDigits 1234
        printfn "Sum: %d" testSum 
        let factorial_f = choice6 false
        let fact_res = factorial_f 5

        let digitSum_f = choice6 true
        let sum_res = digitSum_f 2458
        
        printfn "Factorial of %d, is %d" 5 fact_res
        printfn "Digit Sum of %d, is %d" 2458 sum_res

        Console.WriteLine("<---------------->")
        Console.WriteLine("Digit traversal: Sum of Digits - 3489")
        let tr_sum = digitTraverse 3489 (fun x y -> (x+y)) 0
        Console.WriteLine(tr_sum)

        Console.WriteLine("Digit traversal: Prod of Digits - 816")
        let tr_prod = digitTraverse 816 (fun x y -> (x*y)) 1
        Console.WriteLine(tr_prod)

        Console.WriteLine("Digit traversal: Min of Digits - 3489")
        let tr_min = digitTraverse 3489 (fun x y -> if x < y then x else y) 10
        Console.WriteLine(tr_min)

        Console.WriteLine("Digit traversal: Max of Digits - 3489")
        let tr_max = digitTraverse 3489 (fun x y -> if x > y then x else y) -1
        Console.WriteLine(tr_max)

        0
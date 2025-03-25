open System
open Numbers
open FavePL

let SuperPL () = 
    Console.WriteLine("What is your favourite programming language?")
    (Console.ReadLine >> favouritePL >> Console.WriteLine) ()

let CurryPL () =
    Console.WriteLine("What is your favourite programming language?")
    let func read proc write = write (proc (read ()))
    func Console.ReadLine

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

        Console.WriteLine("<---------------->")
        Console.WriteLine("Product of even digits of 3489")
        let evenProd = digitTraverseCondition 3489 (fun x y -> (x*y)) 1 (fun x -> (x%2)=0)
        Console.WriteLine(evenProd)

        Console.WriteLine("Max of uneven digits of 3489")
        let unevenMax = digitTraverseCondition 3489 (fun x y -> if x > y then x else y) 0 (fun x -> (x%2)<>0)
        Console.WriteLine(unevenMax)

        Console.WriteLine("8 count in 8488")
        let count8 = digitTraverseCondition 8488 (fun x y -> (x + 1)) 0 (fun x -> x=8)
        Console.WriteLine(count8)

        Console.WriteLine("<---------------->")
        SuperPL()
        let pl_curry = CurryPL()
        pl_curry favouritePL Console.WriteLine

        Console.WriteLine("<---------------->")
        Console.WriteLine("Sum of mutually prime numbers with 24")
        let pr_sum = mutPrimeTraverse 24 (+) 0
        Console.WriteLine(pr_sum)

        Console.WriteLine("Euler function result for 24")
        let eu_res = EulerFunction 24
        Console.WriteLine(eu_res)
        0
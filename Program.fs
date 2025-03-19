open System

type SolveResult = 
    None
    | Linear of float
    | Quadratic of float*float

let solve a b c =
    let D = b*b - 4.0*a*c
    if a=0.0 then
        if b=0. then None
        else Linear(-c/b)
    else
        if D<0. then None
        else Quadratic(((-b+sqrt(D))/(2.0*a), (-b-sqrt(D))/(2.0*a)))

let circleSurface r = Math.PI * r * r
let multiplySurfaceH s h = s * h

let cylinderVolumeSuperPosition = circleSurface >> multiplySurfaceH
let cylinderVolumeCurry r h = (circleSurface r) * h


let rec digitSumUp num = 
    if num = 0 then 0
    else (num % 10) + (digitSumUp(num / 10))

let digitSumDown num = 
    let rec digitSumTail num acc = 
        if num = 0 then acc
        else
            let digit = num % 10
            let cur_num = num / 10
            digitSumTail cur_num (acc + digit)
    digitSumTail num 0

[<EntryPoint>]
let main (argv :string[]) = 
    printfn "Hello World"

    Console.WriteLine("<<----------------->>")
    Console.WriteLine("Solving quadratic equation")

    let res = solve 1.0 2.0 -3.0
    match res with
        None -> Console.WriteLine("No solution")
        | Linear(x) -> printfn "Linear equation x=%f" x
        | Quadratic(x1, x2) -> printfn "Quadratic equation: x1=%f, x2=%f" x1 x2

    Console.WriteLine("<<----------------->>")
    Console.WriteLine("Cylinder Volume via SuperPosition")

    Console.WriteLine("Enter radius:")
    let r = System.Console.ReadLine() |> float
    Console.WriteLine("Enter height:")
    let h = System.Console.ReadLine() |> float

    let cylinder_vol = cylinderVolumeSuperPosition r h
    printfn "Cylinder Volume: %f" cylinder_vol

    Console.WriteLine("<<----------------->>")
    Console.WriteLine("Cylinder Volume via Curry")

    Console.WriteLine("Enter radius:")
    let r2 = System.Console.ReadLine() |> float
    Console.WriteLine("Enter height:")
    let h2 = System.Console.ReadLine() |> float

    let cylinder_vol_c = cylinderVolumeCurry r h
    printfn "Cylinder Volume: %f" cylinder_vol

    Console.WriteLine("<<----------------->>")
    Console.WriteLine("Digit Sum (Recursion UP)")

    Console.WriteLine("Enter number:")
    let num = Console.ReadLine() |> int

    let sum = digitSumUp num
    printfn "Digit sum of %d is: %d" num sum

    Console.WriteLine("<<----------------->>")
    Console.WriteLine("Digit Sum (Recursion DOWN)")

    Console.WriteLine("Enter number:")
    let num2 = Console.ReadLine() |> int

    let sum2 = digitSumDown num2
    printfn "Digit sum of %d is: %d" num2 sum2
    0
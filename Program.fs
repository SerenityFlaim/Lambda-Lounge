﻿open System

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
    0
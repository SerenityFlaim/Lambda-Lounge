module Task18
open System

let readIntArray () =
    printfn "Введите элементы массива через пробел:"
    let input = Console.ReadLine()
    try
        if String.IsNullOrWhiteSpace input then
            [||]
        else
            input.Split(' ')
            |> Array.filter (fun s -> not (String.IsNullOrWhiteSpace s))
            |> Array.map int
    with
    | :? FormatException ->
        [||]
    | ex ->
        [||]


let filterDivisibleBy3 (arr: int[]) =
    arr |> Array.filter (fun x -> x % 3 = 0)


let task18 =
    printfn "18 Задача 4:"
    let arr = [|1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12|]
    let filtered = filterDivisibleBy3 arr
    printfn "Исходный массив: %A" arr
    printfn "Отфильтрованный (делятся на 3): %A" filtered
module Task17
open System

// Вспомогательные функции
let readIntList () =
    printfn "Введите элементы списка через пробел (например, 1 2 3):"
    let input = Console.ReadLine()
    try
        if String.IsNullOrWhiteSpace input then
            printfn "Ошибка: пустой ввод. Возвращается пустой список."
            []
        else
            input.Split(' ')
            |> Array.filter (fun s -> not (String.IsNullOrWhiteSpace s)) // Убираем пустые элементы
            |> Array.map int
            |> List.ofArray
    with
    | :? FormatException ->
        printfn "Ошибка: введены некорректные данные. Возвращается пустой список."
        []
    | ex ->
        printfn "Ошибка: %s. Возвращается пустой список." ex.Message
        []

let readInt () =
    printfn "Введите число:"
    try
        Console.ReadLine() |> int
    with
    | :? FormatException ->
        printfn "Ошибка: введено некорректное число. Используется 0."
        0

let fiveLists (list: int list) =
    let list1 = list |> List.filter (fun x -> x % 2 = 0) |> List.map (fun x -> x / 2)
    let list2 = list1 |> List.filter (fun x -> x % 3 = 0) |> List.map (fun x -> x / 3)
    let list3 = list2 |> List.map (fun x -> x * x)
    let list4 = list3 |> List.filter (fun x -> List.contains x list1)
    let list5 = (list2 @ list3 @ list4) |> List.distinct
    (list1, list2, list3, list4, list5)


let task17 = 
    printfn "17 Задача 2:"
    let list = readIntList ()
    let result = fiveLists list
    printfn "Five lists: %A" result
    0

task17
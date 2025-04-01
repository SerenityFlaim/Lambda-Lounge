open System
open ListOps

[<EntryPoint>]
let main argv =
    let arr = [1; 2; 7; 7; 7; 2; 5; 3; 4]

    Console.WriteLine("<--->")
    let res = listTraverseCondition arr (+) (fun x -> x%2=0) 0
    Console.WriteLine(res)

    let min = findMinElement arr
    Console.WriteLine(min)

    let un_res = countUneven arr
    Console.WriteLine(un_res)

    Console.WriteLine("<------------->")
    let most_freq = frequencyElement arr
    Console.WriteLine("Most freak element:")
    Console.WriteLine(most_freq)
    0
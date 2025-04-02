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

    Console.WriteLine("<------------->")
    let list = [1; 2; 8; 64; 4; 16; 9]
    let squares = countSquares arr
    Console.WriteLine("Number of elements, that can be other's squares:")
    Console.WriteLine(squares)

    Console.WriteLine("<------------->")
    Console.WriteLine("Tuples with conditions")
    let listA = [6; 7; 2; 1]
    let listB = [123; 9; 72; 52]
    let listC = [8; 64; 28; 15]

    let result = createTuples listA listB listC
    Console.WriteLine(result)

    Console.WriteLine("<------------->")
    Console.WriteLine("Enter strings (empty string as finish):")
    let stringList = readStrings

    let sortedStrings = sortByLength stringList
    Console.WriteLine("Sorted strings:\n{0}", String.Join("\n", sortedStrings))
    0
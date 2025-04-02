open System
open ListOps
open ListTasks

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

    // Console.WriteLine("<------------->")
    // Console.WriteLine("Enter strings (empty string as finish):")
    // let stringList = readStrings

    // let sortedStrings = sortByLength stringList
    // Console.WriteLine("Sorted strings:\n{0}", String.Join("\n", sortedStrings))

    Console.WriteLine("<------------->")
    Console.WriteLine("1.2 - Find min index in list")
    let list = [1; 2; 8; -64; 4; 16; 9]
    let minList = findMinIndexList list
    let minChurch = findMinIndexChurch list
    Console.WriteLine("List: {0}", minList)
    Console.WriteLine("Church: {0}", minChurch)

    Console.WriteLine("<------------->")
    Console.WriteLine("1.12 - Reverse list between max and min")
    let list = [1; -2; 8; 3; 4; 16; 64]
    Console.WriteLine("List: {0}", reverseBetweenMinMaxList list)
    Console.WriteLine("Church: {0}", reverseBetweenMinMaxChurch list)

    Console.WriteLine("<------------->")
    Console.WriteLine("1.22 - Min elements in a..b")
    let list = [1; -2; -2; 3; 4; 16; 64]
    Console.WriteLine("List: {0}", countMinInRangeList list 1 5)
    Console.WriteLine("Church: {0}", countMinInRangeChurch list 1 5)

    Console.WriteLine("<------------->")
    Console.WriteLine("1.32 - Local max elements")
    let list = [1; 3; 2; 5; 4]
    Console.WriteLine("List: {0}", countLocalMaxList list)
    Console.WriteLine("Church: {0}", countLocalMaxChurch list)

    Console.WriteLine("<------------->")
    Console.WriteLine("1.42 - Elements below average")
    let list = [1; -2; 8; 3; 4; 16; 64]
    Console.WriteLine("List: {0}", belowAverageList list)
    Console.WriteLine("Church: {0}", belowAverageChurch list)

    Console.WriteLine("<------------->")
    Console.WriteLine("1.52 - Elements below average")
    Console.WriteLine("List: {0}", primeFactorsList 36)
    Console.WriteLine("Church: {0}", primeFactorsChurch 36)

    Console.WriteLine("<-------->")
    Console.WriteLine("Order of lowercase letters")
    Console.WriteLine(areLettersOrdered "aBcDeFg")

    Console.WriteLine("<-------->")
    Console.WriteLine("Frequency deviation")
    let englishFreq = 
        [ ('e', 0.127); ('t', 0.091); ('a', 0.082); 
        ('o', 0.075); ('i', 0.070); ('n', 0.067) ]
        |> Map.ofList

    let input = "hello world"
    let result = sortStringByFrequencyDeviation input englishFreq
    Console.WriteLine(result)
    0
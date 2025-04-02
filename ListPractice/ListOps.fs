module ListOps
open System

let readList n  =  
    let rec readListTail n acc = 
        match n with
        | 0 -> acc
        | k -> 
            let el = Console.ReadLine() |> Int32.Parse
            let newAcc = acc@[el]
            readListTail (k-1) newAcc
    readListTail n []

let rec printList l = 
    match l with
    | [] -> Console.ReadKey()
    | head::tail ->
        Console.WriteLine(Int32.Parse(head))
        printList tail

let rec listTraverseCondition list (func :int->int->int) (cond :int->bool) acc  = 
    match list with
    | [] -> acc
    | head::tail -> 
        let flag = cond head
        match flag with
        | true -> listTraverseCondition tail func cond (func acc head)
        | false -> listTraverseCondition tail func cond acc


let findMinElement list = 
    match list with
    | [] -> 0
    | head::tail -> listTraverseCondition tail (fun x y -> if x < y then x else y) (fun x -> true) head

let findEvenSum list = 
    listTraverseCondition list (+) (fun x -> x%2=0) 0

let countUneven list = 
    listTraverseCondition list (fun x y -> x+1) (fun x -> x%2=1) 0

//7
let maxList list =
    listTraverseCondition list (fun x y -> if x > y then x else y) (fun x -> true) System.Int32.MinValue

let rec freqElement list element count =
    match list with
    | [] -> count
    | head :: tail ->
        match head=element with
        | false -> freqElement tail element count
        | true -> freqElement tail element (count+1)

let rec freqList list mainList currentList =
    match list with
    | [] -> currentList
    | head :: tail -> 
        let freqEl = freqElement mainList head 0
        freqList tail mainList (currentList @ [freqEl])

let pos list el = 
    let rec pos1 list el num = 
        match list with
            |[] -> 0
            |h::t ->    
                if (h = el) then num
                else 
                    let num1 = num + 1
                    pos1 t el num1
    pos1 list el 1

let getIn list pos = 
    let rec getIn1 list num curNum = 
        match list with 
            |[] -> 0
            |h::t -> 
                if num = curNum then h
                else 
                    let newNum = curNum + 1
                    getIn1 t num newNum
    getIn1 list pos 1

let frequencyElement list = 
    let fL = freqList list list []
    let maxFreq = maxList fL
    let index = pos fL maxFreq
    getIn list index

//8
let countSquares (list: int list) = 
    let squares = list |> List.map(fun x -> x * x ) |> List.distinct

    list |> List.filter (fun x -> List.contains x squares) |> List.length

//9
let digitSum n = 
    n |> abs |> string |> Seq.sumBy (fun c -> int c - int '0')

let countDivisors n = 
    let absN = abs n
    [1..absN] |> List.filter (fun x -> absN % x = 0) |> List.length

let conditionSort list condFunc reverse = 
    list |> List.sortBy (fun x -> condFunc x, if reverse then -abs x else abs x)

let createTuples listA listB listC = 
    let sortedA = List.sortDescending listA
    let sortedB = conditionSort listB digitSum false
    let sortedC = conditionSort listC countDivisors true

    List.zip3 sortedA sortedB sortedC

//10
let sortByLength (strings: string list) =
    strings |> List.sortBy String.length

let readStrings =
    let rec read acc =
        let input = Console.ReadLine()
        if input = "" then List.rev acc
        else read (input :: acc)
    read []
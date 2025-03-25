module Numbers

let sumDigits num = 
    let rec sumDigitsTail num acc = 
        match num with
        | 0 -> acc
        | _ -> sumDigitsTail (num/10) (acc + (num%10))
    sumDigitsTail num 0

let factorial num = 
    let rec factorialTail num acc = 
        match num with
        | 0 -> acc
        | _ -> factorialTail (num-1) (acc*num)
    factorialTail num 1

let choice6 arg = 
    match arg with
    | true -> sumDigits
    | false -> factorial

let rec digitTraverse num (func : int->int->int) acc = 
    match num with
    | 0 -> acc
    | n -> digitTraverse (n/10) func (func acc (n%10))

let rec digitTraverseCondition num (func :int->int->int) acc (predicate :int->bool) = 
    match num with
    | 0 -> acc
    | n ->
        let digit = n%10
        let next = n/10
        let flag = predicate digit
        match flag with
        | false -> digitTraverseCondition next func acc predicate
        | true -> digitTraverseCondition next func (func acc digit) predicate
        
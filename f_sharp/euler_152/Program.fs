open System
open System.Collections.Generic
[<Struct; CustomComparison; CustomEquality>]
type Fraction = 
    val num: uint64
    val den: uint64

    new(numerator: uint64, denominator: uint64) = 
        {num = numerator;
         den = if denominator = 0UL then 1UL else denominator}

    static member Create(?numerator, ?denominator) = 
        let num = defaultArg numerator 0UL
        let den = defaultArg denominator 1UL
        Fraction(num, den)

    static member (+)(a: Fraction, b: Fraction) = 
        if a.den = b.den then
            Fraction.Create(a.num + b.num, a.den)
        else
            Fraction.Create(a.num * b.den + b.num * a.den, a.den * b.den)

    static member (-)(a: Fraction, b: Fraction) = 
        if a.den = b.den then
            Fraction.Create(a.num - b.num, a.den)
        else 
            Fraction(a.num * b.den - b.num * a.den, a.den * b.den)

    interface IComparable with
        member this.CompareTo(other) = 
            match other with
            | :? Fraction as f -> (this :> IComparable<Fraction>).CompareTo(f)
            | _ -> -1

    interface System.IComparable<Fraction> with
        member this.CompareTo(other) = 
            let left = this.num * other.den
            let right = other.num * this.den
            if left < right then -1
            elif left > right then 1
            else 0

    override this.Equals(other) = 
        match other with
        | :? Fraction as f -> (this :> System.IComparable<Fraction>).CompareTo(f) = 0
        | _ -> false

    override this.GetHashCode() =
        int (this.num ^^^ this.den)

    member this.Reduced() = 
        if this.num = 0UL || this.den = 1UL then
            Fraction.Create(this.num, 1UL)
        else
            let rec gcd a b = 
                match a with
                | 0UL -> b
                | _ -> gcd (b % a) a
            
            let divisor = gcd this.num this.den
            if divisor = 1UL then this
            else Fraction.Create(this.num / divisor, this.den / divisor)

let targetSum = Fraction.Create(1UL, 2UL)

let candidates = ResizeArray<uint64>()

let lastNumberThreshold = 40UL
let lastNumbers = SortedSet<Fraction>()

let remaining = SortedDictionary<uint64, Fraction>()

//for debug only
let members = ResizeArray<uint64>()

let rec search (current: Fraction ) (next : int ) = 
    if current = targetSum then
        // for x in members do
        //     printf "%d + " (int x)
        // printf ""
        1UL
    elif targetSum < current then
        0UL
    elif next >= candidates.Count then
        0UL
    else
        let number = candidates.[next]

        let maxPossible = current + remaining.[number]
        if maxPossible < targetSum then
            0UL
        else
            // lookup difference in all pre-computed sums of the last values
            match number >= lastNumberThreshold with
            | true -> 
                let difference = targetSum - current
                // is there any sum matching the difference ?
                let solutions = lastNumbers.GetViewBetween(difference, difference).Count
                uint64 solutions
            | false -> 
                let startResult = 0UL
                //try to build result without current number
                let sumWithoutNumber = startResult + search current (next + 1)
                
                //try to build result with current number
                let add = Fraction.Create(1UL, number * number)
                members.Add(number)
                let newCurrent = (current + add).Reduced()
                let sumWithNumber = sumWithoutNumber + search newCurrent (next + 1)
                members.RemoveAt(members.Count - 1)

                sumWithNumber

let searchDefault() = search (Fraction.Create(0UL, 1UL)) 0

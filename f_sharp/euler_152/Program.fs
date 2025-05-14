open System
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


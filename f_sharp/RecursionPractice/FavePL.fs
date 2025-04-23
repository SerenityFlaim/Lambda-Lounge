module FavePL
open System

let favouritePL (pl :string) = 
    match pl with
    | "F#" | "Prologue" -> Console.WriteLine("Подлиза")
    | "Go" -> Console.WriteLine("rep++")
    | "Ruby" -> Console.WriteLine("._.")
    | "Python" -> Console.WriteLine("Okay, but not okay")
    | "Java" -> Console.WriteLine("Very nice!")
    | "R" -> Console.WriteLine("I did not know you exist")
    | _ -> Console.WriteLine("Unknown programming language.")
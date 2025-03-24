module DigitSum

let rec digitSumUp num = 
    if num = 0 then 0
    else (num % 10) + (digitSumUp(num / 10))

let digitSumDown num = 
    let rec digitSumTail num acc = 
        if num = 0 then acc
        else
            let digit = num % 10
            let cur_num = num / 10
            digitSumTail cur_num (acc + digit)
    digitSumTail num 0
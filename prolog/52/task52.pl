solution([X1, X2, X3, X4, X5]) :-
    my_between(1, 7, X1),   
    between(1, 6, X2),        
    S12 is X1 + X2,
    RemainingSum is 20 - S12,
    RemainingSum >= 3,         
    RemainingSum =< 12,         
    my_between(1, 5, X3),      
    S123 is S12 + X3,
    RemainingSum2 is 20 - S123,
    RemainingSum2 >= 2,       
    RemainingSum2 =< 7,         
    my_between(1, 4, X4),        
    X5 is RemainingSum2 - X4, 
    my_between(1, 3, X5).         

my_between(Low, High, Value) :-
    integer(Low),
    integer(High),
    Low =< High,               
    (Value = Low ; NewLow is Low + 1,     
     my_between(NewLow, High, Value)
    ).

my_findall(Template, Goal, Result) :-
    call(Goal), 
    assertz(temp_result(Template)), 
    fail.

my_findall(_, _, Result) :-
    collect_results([], Result).

collect_results(Acc, Result) :-
    retract(temp_result(X)),
    !,
    collect_results([X | Acc], Result).

collect_results(Result, Result). % Когда результаты закончились, возвращаем аккумулятор

write_solutions([], _).
write_solutions([Solution | Rest], Stream) :-
    write(Stream, Solution),
    nl(Stream),
    write_solutions(Rest, Stream).

solve :-
    my_findall([X1, X2, X3, X4, X5], solution([X1, X2, X3, X4, X5]), Solutions),
    open('/home/serenity-flaim/Desktop/ФКТиПМ/Summer_semester/ФиЛП/LambdaLounge/FSharp/prolog/52/solutions.txt', write, Stream),
    write_solutions(Solutions, Stream),
    close(Stream).
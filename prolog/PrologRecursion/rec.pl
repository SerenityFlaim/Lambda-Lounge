%Task 1
%Max
max(X, Y, X) :- X > Y, !.
max(_, Y, Y).

max(X, Y, Z, U) :-
    max(X, Y, M), 
    max(M, Z, U).

max(X, Y, Z, X) :- X > Y, X > Z, !.
max(_, Y, Z, Y) :- Y > Z, !.
max(_, _, Z, Z).

%Factorial
fact_up(0, 1).
fact_up(N, X) :-
    N > 0,
    N1 is N - 1,
    fact_up(N1, X1),
    X is N * X1. 

fact_down(N, X) :- 
    fact_tail(N, 1, X).

fact_tail(0, Acc, Acc).
fact_tail(N, Acc, X) :-
    N > 0,
    NewAcc is N * Acc,
    N1 is N - 1,
    fact_tail(N1, NewAcc, X).

%sum_cifr - up, sum_digits - down
%sum_cifr(+N, ?S).

sum_cifr(0, 0):- !.
sum_cifr(N, S):- 
    Cifr is N mod 10,
    NewN is N div 10, 
    sum_cifr(NewN, NewSum),
    S is NewSum + Cifr.

sum_digits(X, Answer) :-
    sum_digits_tail(X, 0, Answer).
    sum_digits_tail(0, Acc, Acc) :- !.
    sum_digits_tail(X, Acc, Answer) :-
    X1 is X // 10,
    Acc1 is Acc + X mod 10,
    sum_digits_tail(X1, Acc1, Answer).

%Square_free_check
square_free(1).
square_free(N) :-
    N > 1,
    \+ has_square_factor(N, 2).

has_square_factor(N, K) :-
    K * K =< N,
    (
        0 is N mod (K * K); 
        NextK is K + 1,
        has_square_factor(N, NextK)
    ).

%Read_list
r_list(A,N):-r_list(A,N,0,[]).
r_list(A,N,N,A):-!.
r_list(A,N,K,B):-read(X),append(B,[X],B1),K1 is K+1,r_list(A,N,K1,B1).

%Write_to_list
w_list([]):-!.
w_list([H|T]):-write(H),nl,w_list(T).

%Append_to_list
my_append([], X, Y).
my_append([X|Tail], Y, [X|Tail1]):- my_append(Tail, Y, Tail1).

%Check_in_list
in_list([], _):- false.
in_list([X|Tail], X):- !.
in_list([_|Tail], X):- in_list(Tail, X).

%Get_by_index
get_at(0, [Head|_], Head).

get_at(Ix, [_|Tail], Element) :-
    Ix > 0,
    NewIx is Ix - 1,
    get_at(NewIx, Tail, Element).

%Sum_of_elements_list
sum_list_up([], 0).

sum_list_up([H|T], Sum) :-
    sum_list_up(T, TS),
    Sum is H + TS.

sum_list_down(List, Sum) :-
    sum_list_down(List, 0, Sum).

sum_list_down([], Acc, Acc).

sum_list_down([H|T], Acc, Sum) :-
    NewAcc is Acc + H,
    sum_list_down(T, NewAcc, Sum).

% Deletion of elements with non equal digit sum
remove_if_sum_equal([], _, []).

remove_if_sum_equal([X | Tail], TargetSum, Result) :-
    digit_sum_down(X, Sum),
    (Sum =:= TargetSum -> remove_if_sum_equal(Tail, TargetSum, Result); Result = [X | NewResult], remove_if_sum_equal(Tail, TargetSum, NewResult)).
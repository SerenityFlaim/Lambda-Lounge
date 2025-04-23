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

%Task 2
%Max_digit_in_number
max_digit_up(X, X) :- X < 10, !.
max_digit_up(X, Max) :-
    X >= 10,
    LastDigit is X mod 10,
    Rest is X // 10,
    max_digit_up(Rest, MaxRest),
    Max is max(LastDigit, MaxRest).

max_digit_down(X, Max) :- max_digit_down(X, 0, Max).

max_digit_down(0, Acc, Acc) :- !.
max_digit_down(X, Acc, Max) :-
    X > 0,
    LastDigit is X mod 10,
    NewAcc is max(Acc, LastDigit),
    Rest is X // 10,
    max_digit_down(Rest, NewAcc, Max).

%Sum of digits that is divisible by 3
sum_div3_up(X, Sum) :-
    X < 10,
    (X mod 3 =:= 0 -> Sum = X; Sum = 0), !.
sum_div3_up(X, Sum) :-
    X >= 10,
    LastDigit is X mod 10,
    Rest is X // 10,
    sum_div3_up(Rest, SumRest),
    (LastDigit mod 3 =:= 0 -> Sum is SumRest + LastDigit; Sum = SumRest).

sum_div3_down(X, Sum) :- sum_div3_down(X, 0, Sum).

sum_div3_down(0, Acc, Acc) :- !.
sum_div3_down(X, Acc, Sum) :-
    X > 0,
    LastDigit is X mod 10,
    (LastDigit mod 3 =:= 0 -> NewAcc is Acc + LastDigit; NewAcc is Acc),
    Rest is X // 10,
    sum_div3_down(Rest, NewAcc, Sum).

%Number of divisors
count_divisors_up(N, Count) :-
    count_divisors_up(N, 1, 0, Count).

count_divisors_up(N, D, Acc, Count) :-
    D =< N,
    (N mod D =:= 0 ->
        NewAcc is Acc + 1,
        NextD is D + 1;
        NewAcc is Acc,
        NextD is D + 1),
    count_divisors_up(N, NextD, NewAcc, Count).

count_divisors_up(N, D, Count, Count) :- D > N.

count_divisors_down(N, Count) :-
    count_divisors_down(N, 1, 0, Count).

count_divisors_down(N, D, Acc, Acc) :- D > N, !.
count_divisors_down(N, D, Acc, Count) :-
    D =< N,
    (N mod D =:= 0 -> NewAcc is Acc + 1; NewAcc is Acc),
    NextD is D + 1,
    count_divisors_down(N, NextD, NewAcc, Count).

%Task 3
% 3.1 Вывести индексы массива в порядке убывания соответствующих элементов
index_element_pairs(List, Pairs) :-
    index_element_pairs(List, 0, Pairs).

index_element_pairs([], _, []).
index_element_pairs([H|T], Index, [(Index, H)|RestPairs]) :-
    NextIndex is Index + 1,
    index_element_pairs(T, NextIndex, RestPairs).

% Предикат для сравнения пар по убыванию элементов
compare_pairs(Order, (_, A), (_, B)) :-
    compare(Order, B, A).

indices_in_decreasing_order(List, Indices) :-
    index_element_pairs(List, Pairs),
    predsort(compare_pairs, Pairs, SortedPairs),
    pairs_keys(SortedPairs, Indices).

pairs_keys([], []).
pairs_keys([(K,_)|T], [K|RestKeys]) :-
    pairs_keys(T, RestKeys).

% 3.2 Найти элементы между первым и вторым максимальным
first_max(List, Max, Index) :-
    max_list(List, Max),
    nth0(Index, List, Max).

second_max(List, FirstMax, SecondMax, SecondIndex) :-
    exclude(=(FirstMax), List, FilteredList),
    (   FilteredList = [] -> SecondMax = FirstMax, SecondIndex = -1  % Все элементы одинаковые
    ;   max_list(FilteredList, SecondMax),
        nth0(SecondIndex, List, SecondMax),
        dif(SecondIndex, FirstIndex)  % Убедимся, что это другой индекс
    ).

elements_between_first_and_second_max(List, Elements) :-
    first_max(List, FirstMax, FirstIndex),
    second_max(List, FirstMax, SecondMax, SecondIndex),
    (   FirstIndex < SecondIndex ->
        Start is FirstIndex + 1,
        End is SecondIndex - 1,
        (Start =< End -> sublist(List, Start, End, Elements); Elements = [])
    ;   FirstIndex > SecondIndex ->
        Start is SecondIndex + 1,
        End is FirstIndex - 1,
        (Start =< End -> sublist(List, Start, End, Elements); Elements = [])
    ;   Elements = []  % Максимумы совпадают или стоят рядом
    ).

% Вспомогательный предикат для извлечения подсписка
sublist(List, Start, End, Sublist) :-
    findall(X, (between(Start, End, I), nth0(I, List, X)), Sublist).

% 3.3. Найти элементы между первым и последним максимальным

first_and_last_max_indices(List, FirstIndex, LastIndex) :-
    max_list(List, Max),
    nth0(FirstIndex, List, Max),
    last_max_index(List, Max, LastIndex).

last_max_index(List, Max, LastIndex) :-
    length(List, Len),
    LastIndex is Len - 1,
    nth0(LastIndex, List, Max).
last_max_index(List, Max, LastIndex) :-
    length(List, Len),
    LastCandidate is Len - 1,
    nth0(LastCandidate, List, X),
    X \= Max,
    last_max_index(List, Max, LastIndex).

elements_between_first_and_last_max(List, Elements) :-
    first_and_last_max_indices(List, FirstIndex, LastIndex),
    (   FirstIndex < LastIndex ->
        Start is FirstIndex + 1,
        End is LastIndex - 1,
        (Start =< End -> sublist(List, Start, End, Elements); Elements = [])
    ;   Elements = []  % Максимум один
    ).

%Task 4
solve_liquids :-
    Vessels = [_,_,_,_],
    Liquids = [milk, lemonade, kvas, water],

    in_list(Vessels, [bottle, _, not(milk), not(water)]),
    (between(jug, lemonade, kvas, Vessels); between(kvas, lemonade, jug, Vessels)),

    in_list(Vessels, [jar, _, not(lemonade), not(water)]),

    (next_to(glass, jar, Vessels); next_to(jar, glass, Vessels)),
    (next_to(glass, milk, Vessels); next_to(milk, glass, Vessels)),

    findall([Vessel, Liquid], member([Vessel, Liquid, _, _], Vessels), Results),
    print_results(Results).

between(Y, X, Z, List) :-
    append(_, [Y, X, Z|_], List).
between(Y, X, Z, List) :-
    append(_, [Z, X, Y|_], List).

next_to(X, Y, List) :-
    append(_, [X, Y|_], List).
next_to(X, Y, List) :-
    append(_, [Y, X|_], List).

print_results([]).
print_results([[Vessel, Liquid]|Rest]) :-
    write(Vessel), write(': '), write(Liquid), nl,
    print_results(Rest).


%Task 5
% 5.1 Найти количество четных чисел, не взаимно простых с данным
gcd(X, 0, X) :- !.
gcd(X, Y, G) :- Z is X mod Y, gcd(Y, Z, G).

not_coprime(A, B) :- gcd(A, B, G), G > 1.

count_even_not_coprime(N, Count) :-
    findall(X, (between(1, N, X), X mod 2 =:= 0, not_coprime(X, N)), L),
    length(L, Count).

% 5.2. Найти произведение максимального числа, не взаимно простого с данным,
% не делящегося на наименьший делитель исходного числа,
% и суммы цифр числа, меньших 5
% Нахождение наименьшего делителя числа (>1)

smallest_divisor(N, D) :-
    N > 1,
    between(2, N, D),
    N mod D =:= 0,
    !.

digit_less_5(N, Sum) :-
    number_digits(N, Digits),
    include(>(5), Digits, Filtered),
    sum_list(Filtered, Sum).

number_digits(N, Digits) :-
    number_chars(N, Chars),
    maplist(char_number, Chars, Digits).

char_number(C, N) :- char_type(C, digit(N)).

max_not_coprime_not_div(N, Max) :-
    smallest_divisor(N, SD),
    findall(X, (
        between(1, N, X),
        not_coprime(X, N),
        X mod SD =\= 0
    ), List),
    max_list(List, Max).

compute_product(N, Product) :-
    max_not_coprime_not_div(N, Max),
    digit_less_5(N, Sum),
    Product is Max * Sum.

% 6.1 Найти минимальный четный элемент в целочисленном массиве

min_even([], _) :- fail.

min_even([H|T], Min) :-
    H mod 2 =:= 0,
    min_even(T, H, Min).

min_even([H|T], Min) :-
    H mod 2 =\= 0,
    min_even(T, Min).

min_even([], CurrentMin, CurrentMin).
min_even([H|T], CurrentMin, Min) :-
    H mod 2 =:= 0,
    (H < CurrentMin -> NewMin = H ; NewMin = CurrentMin),
    min_even(T, NewMin, Min).
min_even([H|T], CurrentMin, Min) :-
    H mod 2 =\= 0,
    min_even(T, CurrentMin, Min).

% ?- min_even([3, 8, 2, 5, 4], Min).
% Min = 2

% 6.2  Построение списка простых делителей с учетом кратности
is_prime(2) :- !.
is_prime(3) :- !.
is_prime(N) :-
    N > 3,
    N mod 2 =\= 0,
    \+ has_factor(N, 3).

has_factor(N, K) :-
    K * K =< N,
    (N mod K =:= 0 -> true ; K1 is K + 2, has_factor(N, K1)).

prime_factors(1, []) :- !.
prime_factors(N, [H|T]) :-
    N > 1,
    first_prime_factor(N, 2, H),
    N1 is N // H,
    prime_factors(N1, T).

first_prime_factor(N, K, K) :-
    N mod K =:= 0,
    is_prime(K).
first_prime_factor(N, K, P) :-
    N mod K =\= 0,
    K1 is K + 1,
    first_prime_factor(N, K1, P).

count_degree(N, P, Count) :-
    count_degree(N, P, 0, Count).

count_degree(N, P, Acc, Acc) :-
    N mod P =\= 0, !.
count_degree(N, P, Acc, Count) :-
    N mod P =:= 0,
    N1 is N // P,
    Acc1 is Acc + 1,
    count_degree(N1, P, Acc1, Count).

prime_divisors(N, Result) :-
    N > 1,
    prime_factors(N, UniquePrimes),
    sort(UniquePrimes, SortedPrimes),
    expand_primes(N, SortedPrimes, Result).

expand_primes(_, [], []).
expand_primes(N, [P|Ps], Expanded) :-
    count_degree(N, P, Count),
    duplicate(Count, P, DupP),
    expand_primes(N, Ps, Rest),
    append(DupP, Rest, Expanded).

duplicate(0, _, []) :- !.
duplicate(N, X, [X|T]) :-
    N > 0,
    N1 is N - 1,
    duplicate(N1, X, T).


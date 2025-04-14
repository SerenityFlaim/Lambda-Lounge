man(anatoliy).
man(dimitriy).
man(vlad).
man(kirill).
man(mefodiy).
woman(vladina).
woman(galya).
woman(sveta).
woman(suryat).
woman(zoya).
woman(katrin).
child(dimitriy, anatoliy).
child(dimitriy, galya).
child(vladina, anatoliy).
child(vladina, galya).
child(suryat, anatoliy).
child(suryat, galya).
child(kirill, dimitriy).
child(mefodiy, dimitriy).
child(kirill, sveta).
child(mefodiy, sveta).
child(zoya, vlad).
child(zoya, vladina).
child(katrin, vlad).
child(katrin, vladina).

men :- man(X), write(X), nl, fail.
women :- woman(X), write(X), nl, fail.
parent(X, Y) :- child(Y, X).
mother(X, Y) :- woman(X), child(Y, X).

brother(X, Y) :- 
    man(X), 
    child(X, P1), child(Y, P1),
    child(X, P2), child(Y, P2),
    X \= Y.

sister(X, Y) :-
    woman(X),
    child(X, P1), child(Y, P1),
    child(X, P2), child(Y, P2),
    X \= Y.

brothers(X) :- brother(Y, X), write(Y), nl, fail.

b_s(X, Y) :-
    child(X, P1), child(Y, P1),
    child(X, P2), child(Y, P2),
    X \= Y.

b_s(X) :- b_s(X, Y), write(Y), nl, fail.

father(X, Y) :-
    man(X),
    child(Y, X).

wife(X, Y) :-
    woman(X),
    man(Y),
    child(C, X),
    child(C, Y).

grand_da(X, Y) :-
    woman(X),
    child(X, P),
    child(P, Y).

grand_dats(X, Y) :- grand_da(Y, X), write(Y), nl, fail.

grand_pa_and_da(X, Y) :-
    man(X), 
    woman(Y),
    child(Y, P),
    child(P, X).

grand_pa_and_da(X, Y) :-
    woman(X),
    man(Y),
    child(X, P),
    child(P, Y).

aunt(X, Y) :- 
    woman(X),
    child(Y, P),
    sister(X, P).

aunts(X) :-aunt(Y, X), write(Y), nl, fail.


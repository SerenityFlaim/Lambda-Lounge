rock(zahna, 1).
rock(magdalene_rose, 1).
rock(ri-an, 0).
rock(jabberloop, 0).
rock(fox_capture_plan, 0).
rock(adelaide, 1).
rock(nesdam, 1).
rock(jeremy_riddle, 0).
rock(dj_okawari, 0).
rock(seventh_day_slumber, 1).
rock(skillet, 1).
rock(flyleaf, 1).
rock(lacey_sturm, 1).
rock(rivers_and_robots, 0).
rock(jonathan_ogden, 0).
rock(akina_sanat, 0).
rock(ledger, 1).
rock(kim_walker_smith, 0).
rock(for_king_and_country, 0).
rock(citizens, 1).

group(zahna, 0).
group(magdalene_rose, 0).
group(ri-an, 0).
group(jabberloop, 1).
group(fox_capture_plan, 1).
group(adelaide, 0).
group(nesdam, 0).
group(jeremy_riddle, 0).
group(dj_okawari, 0).
group(seventh_day_slumber, 1).
group(skillet, 1).
group(flyleaf, 1).
group(lacey_sturm, 0).
group(rivers_and_robots, 1).
group(jonathan_ogden, 0).
group(akina_sanat, 0).
group(ledger, 0).
group(kim_walker_smith, 0).
group(for_king_and_country, 1).
group(citizens, 1).

vocals(zahna, 2).
vocals(magdalene_rose, 2).
vocals(ri-an, 2).
vocals(jabberloop, 0).
vocals(fox_capture_plan, 0).
vocals(adelaide, 2).
vocals(nesdam, 1).
vocals(jeremy_riddle, 1).
vocals(dj_okawari, 0).
vocals(seventh_day_slumber, 1).
vocals(skillet, 1).
vocals(flyleaf, 2).
vocals(lacey_sturm, 2).
vocals(rivers_and_robots, 1).
vocals(jonathan_ogden, 1).
vocals(akina_sanat, 0).
vocals(ledger, 2).
vocals(kim_walker_smith, 2).
vocals(for_king_and_country, 1).
vocals(citizens, 1).

electronic(zahna, 2).
electronic(magdalene_rose, 0).
electronic(ri-an, 1).
electronic(jabberloop, 1).
electronic(fox_capture_plan, 2).
electronic(adelaide, 0).
electronic(nesdam, 1).
electronic(jeremy_riddle, 0).
electronic(dj_okawari, 2).
electronic(seventh_day_slumber, 1).
electronic(skillet, 0).
electronic(flyleaf, 0).
electronic(lacey_sturm, 0).
electronic(rivers_and_robots, 2).
electronic(jonathan_ogden, 2).
electronic(akina_sanat, 1).
electronic(ledger, 1).
electronic(kim_walker_smith, 0).
electronic(for_king_and_country, 1).
electronic(citizens, 1).

jazz(zahna, 0).
jazz(magdalene_rose, 1).
jazz(ri-an, 1).
jazz(jabberloop, 2).
jazz(fox_capture_plan, 2).
jazz(adelaide, 0).
jazz(nesdam, 0).
jazz(jeremy_riddle, 0).
jazz(dj_okawari, 2).
jazz(seventh_day_slumber, 0).
jazz(skillet, 0).
jazz(flyleaf, 0).
jazz(lacey_sturm, 0).
jazz(rivers_and_robots, 1).
jazz(jonathan_ogden, 0).
jazz(akina_sanat, 2).
jazz(ledger, 1).
jazz(kim_walker_smith, 0).
jazz(for_king_and_country, 0).
jazz(citizens, 0).

origin(zahna, 2).
origin(magdalene_rose, 2).
origin(ri-an, 2).
origin(jabberloop, 1).
origin(fox_capture_plan, 1).
origin(adelaide, 2).
origin(nesdam, 2).
origin(jeremy_riddle, 2).
origin(dj_okawari, 1).
origin(seventh_day_slumber, 2).
origin(skillet, 2).
origin(flyleaf, 2).
origin(lacey_sturm, 2).
origin(rivers_and_robots, 0).
origin(jonathan_ogden, 0).
origin(akina_sanat, 1).
origin(ledger, 2).
origin(kim_walker_smith, 2).
origin(for_king_and_country, 0).
origin(citizens, 2).

theme(zahna, 1).
theme(magdalene_rose, 1).
theme(ri-an, 0).
theme(jabberloop, 0).
theme(fox_capture_plan, 0).
theme(adelaide, 1).
theme(nesdam, 1).
theme(jeremy_riddle, 2).
theme(dj_okawari, 0).
theme(seventh_day_slumber, 1).
theme(skillet, 1).
theme(flyleaf, 1).
theme(lacey_sturm, 1).
theme(rivers_and_robots, 2).
theme(jonathan_ogden, 2).
theme(akina_sanat, 0).
theme(ledger, 1).
theme(kim_walker_smith, 2).
theme(for_king_and_country, 2).
theme(citizens, 2).

question1(X1):-	write("Is main genre rock?"),nl,
				write("1. Yes *guitar riff*"),nl,
				write("0. No"),nl,
				read(X1).

question2(X2):-	write("Is it a collective?"),nl,
				write("1. Yes"),nl,
				write("0. Solo"),nl,
				read(X2).

question3(X3):-	write("What are lead vocals?"),nl,
				write("2. Female"),nl,
				write("1. Male"),nl,
				write("0. Zero"),
				read(X3).

question4(X4):-	write("How much electronic is it?"),nl,
				write("2. Very"),nl,
				write("1. Partially"),nl,
				write("0. Zero"),nl,
				read(X4).

question5(X5):-	write("Does it contain jazz elements?"),nl,
				write("2. Jazz itself *saxaphone noises*"),nl,
				write("1. Partially"),nl,
				write("0. Zero"),nl,
				read(X5).

question6(X6):-	write("What's the country of origin?"),nl,
				write("2. America"),nl,
				write("1. Japan"),nl,
				write("0. Other"),nl,
				read(X6).

question7(X7):-	write("Main lyric theme?"),nl,
				write("2. Worship"),nl,
				write("1. Human_experience"),nl,
				write("0. Instrumental"),nl,
				read(X7).				

artist:-	question1(X1),question2(X2),question3(X3),question4(X4),
		question5(X5),question6(X6),question7(X7),
		rock(X,X1),group(X,X2),vocals(X,X3),electronic(X,X4),
		jazz(X,X5),origin(X,X6),theme(X,X7),
		write(X).
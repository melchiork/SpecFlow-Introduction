#language: pl-PL
Właściwość: Ubezpieczenia

Scenariusz: Balans portfela ubezpieczeń
	Zakładając istnienie następujących kientów
		| Numer | Balans Składek |
		| 12    | 300            |
		| 13    | -100           |
		| 22    | -1600          |
	Jeśli wyliczam balans dla portfela
	Wtedy balans wynosi -1400
(defrule main
	(declare (salience 10000))
	=>
	(load "C:/Users/Anton/Dropbox/sudoku_solver/s_main.erl")
	(load "C:/Users/Anton/Dropbox/sudoku_solver/s_solver.erl")
	(load "C:/Users/Anton/Dropbox/sudoku_solver/s_printer.erl")
	(load "C:/Users/Anton/Dropbox/sudoku_solver/s_sudoku.erl")
	(assert (load_all_componets)))

(defrule start
	(load_all_componets)
	=>
	(assert (start)))

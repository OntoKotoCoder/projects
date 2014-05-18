(deftemplate field 
	(slot row)
	(slot column)
	(slot zone)
	(slot value))

(deftemplate sudoku 
	(slot row)
	(slot column)
	(slot zone)
	(slot value))

(deftemplate possible-value 
	(slot row)
	(slot column)
	(slot zone)
	(slot value))

(deffacts chech_facts
	(check_row 1)
	(check_column 1)
	(count 0))

(defrule start_program
	(declare (salience 7000))
	=>
	(printout t "============================================" crlf)
	(printout t "Sudoku solver v 0.7.17 beta                 " crlf)
	(printout t "Author - Anton Motorkov                     " crlf)
	(printout t "e-mail: ontoshka777@yandex.ru               " crlf)
	(printout t "--------------------------------------------" crlf)
	(printout t "This program is able to solve simple Sudoku." crlf)
	(printout t "If you have any questions or suggestions you" crlf)
	(printout t "can write me on e-mail. The author does not " crlf)
	(printout t "impose restrictions on the use of this open " crlf)
	(printout t "source program.                             " crlf)
	(printout t "============================================" crlf)
	(printout t crlf "Unsolved sudoku:" crlf)
	(printout t "--------------------------------------------" crlf)
	(assert (print_next)))	

(defrule solve_check_column
	?current_column <- (check_column ?ch_column)
	?current_row <- (check_row ?ch_row)
	?current_count <- (count ?count)
	?field <- (field (column ?column&?ch_column) (row ?row&?ch_row) (value ?value&~0))
	(test (< ?ch_column 9))
	=>
	(bind ?new_count (+ ?count 1))
	(assert	(count ?new_count))
	(bind ?new_column (+ ?ch_column 1))
	(assert (check_column ?new_column))
	(retract ?current_column ?current_count))

(defrule solve_check_row
	?current_column <- (check_column ?ch_column)
	?current_row <- (check_row ?ch_row)
		?current_count <- (count ?count)
	?field <- (field (column ?column&?ch_column) (row ?row&?ch_row) (value ?value&~0))
	(test (= ?ch_column 9))
	=>
	(bind ?new_count (+ ?count 1))
	(assert	(count ?new_count))
	(bind ?new_row (+ ?ch_row 1))
	(assert (check_row ?new_row))
	(assert (check_column 1))
	(retract ?current_row ?current_column ?current_count))

(defrule solve_check
	?full_count <- (count ?count)
	(test (= ?count	81))
	=>
	(assert (print_next))
	(assert (sudoku_solved))
	(printout t crlf crlf "Solved sudoku:  " crlf)
	(printout t "--------------------------------------------" crlf))

(defrule end_of_program
	(sudoku_solved)
	=>
	(printout t "--------------------------------------------" crlf)
	(printout t "finished successfully..." crlf))
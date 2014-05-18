;/------------------------------------------------------------------------------------
;/"Ниже представлены правила, выполняющие вывод решённого и не решённого судоку"     -	
;/------------------------------------------------------------------------------------
(deffacts element_to_print
	(next_row 1)
	(next_column 1))

(defrule print_field
	(declare (salience 1000))
	(print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	?field <- (field (value ?value&~0) (column ?column&?cur_column&~3&~6) (row ?row&?cur_row))
	(test (< ?cur_column 9))
	=>
	(printout t ?value " ")
	(bind ?new_column (+ ?cur_column 1))
	(assert (next_column ?new_column))
	(assert (next_row ?cur_row))
	(retract ?current_column)
)

(defrule print_field_0
	(declare (salience 1000))
	(print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	?field <- (field (value ?value&0) (column ?column&?cur_column&~3&~6) (row ?row&?cur_row))
	(test (< ?cur_column 9))
	=>
	(printout t  "* ")
	(bind ?new_column (+ ?cur_column 1))
	(assert (next_column ?new_column))
	(assert (next_row ?cur_row))
	(retract ?current_column)
)

(defrule print_field_last_in_zone_column
	(declare (salience 1000))
	(print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	?field <- (field (value ?value&~0) (column ?column&?cur_column) (row ?row&?cur_row))
	(test (or (= ?cur_column 3) (= ?cur_column 6)))
	=>
	(printout t ?value " | ")
	(bind ?new_column (+ ?cur_column 1))
	(assert (next_column ?new_column))
	(assert (next_row ?cur_row))
	(retract ?current_column)
)

(defrule print_field_last_in_zone_column_0
	(declare (salience 1000))
	(print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	?field <- (field (value ?value&0) (column ?column&?cur_column) (row ?row&?cur_row))
	(test (or (= ?cur_column 3) (= ?cur_column 6)))
	=>
	(printout t  "* | ")
	(bind ?new_column (+ ?cur_column 1))
	(assert (next_column ?new_column))
	(assert (next_row ?cur_row))
	(retract ?current_column)
)

(defrule print_field_last_in_zone_row
	(declare (salience 1000))
	?print_next <- (print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	(field (value ?value&~0) (column ?column&?cur_column) (row ?row&?cur_row))
	(test (and (= ?cur_column 9) (or (= ?cur_row 3) (= ?cur_row 6))))
	=>
	(assert (print_line))
	(printout t ?value crlf)
	(bind ?new_row (+ ?cur_row 1))
	(assert (next_column 1)  (next_row ?new_row))
	(retract ?current_row)
	(retract ?print_next)
)

(defrule print_field_last_in_zone_row_0
	(declare (salience 1000))
	?print_next <- (print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	(field (value ?value&0) (column ?column&?cur_column) (row ?row&?cur_row))
	(test (and (= ?cur_column 9) (or (= ?cur_row 3) (= ?cur_row 6))))
	=>
	(assert (print_line))
	(printout t "*" crlf)
	(bind ?new_row (+ ?cur_row 1))
	(assert (next_column 1)  (next_row ?new_row))
	(retract ?current_row)
	(retract ?print_next)
)

(defrule print_field_last_in_row
	(declare (salience 1000))	
	(print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	(field (value ?value&~0) (column ?column&?cur_column) (row ?row&?cur_row&~3&~6&~9))
	(test (= ?cur_column 9))
	=>
	(printout t ?value crlf)
	(bind ?new_row (+ ?cur_row 1))
	(assert (next_column 1)  (next_row ?new_row))
	(retract ?current_row)
)

(defrule print_field_last_in_row_0
	(declare (salience 1000))	
	(print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	(field (value ?value&0) (column ?column&?cur_column) (row ?row&?cur_row&~3&~6&~9))
	(test (= ?cur_column 9))
	=>
	(printout t "*" crlf)
	(bind ?new_row (+ ?cur_row 1))
	(assert (next_column 1)  (next_row ?new_row))
	(retract ?current_row)
)

(defrule print_field_last
	(declare (salience 1000))
	?print_next <- (print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	(field (value ?value&~0) (column ?column&?cur_column&9) (row ?row&?cur_row&9))
	(test (and (= ?cur_column 9) (= ?cur_row 9)))
	=>
	(printout t ?value crlf)
	(assert (print_finished))	
	(retract ?current_row ?current_column)
)

(defrule print_field_last_0
	(declare (salience 1000))
	?print_next <- (print_next)
	?current_row <- (next_row ?cur_row)
	?current_column <- (next_column ?cur_column)
	(field (value ?value&0) (column ?column&?cur_column&9) (row ?row&?cur_row&9))
	(test (and (= ?cur_column 9) (= ?cur_row 9)))
	=>
	(printout t "*" crlf)
	(assert (print_finished))	
	(retract ?current_row ?current_column)
)

(defrule print_line
	(declare (salience 1000))	
	?print_line <- (print_line)
	=>
	(printout t "-- -- -- -- -- -- ---" crlf)
	(assert	(print_next))
	(retract ?print_line))

(defrule print_finished
	(declare (salience 1000))	
	?print_finished <- (print_finished)
	?print_next <- (print_next)
	=>
	(assert (next_row 1))
	(assert (next_column 1))
	(retract ?print_finished ?print_next))
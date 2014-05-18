;/------------------------------------------------------------------------------------
;/"Ниже представлены правила, осуществляющие поиск решения судоку"				     -	
;/------------------------------------------------------------------------------------
(defrule new_1
	(declare (salience 100))
	?new_field <- (field (row ?row) (column ?column) (zone ?zone) (value ?value&0))
	=>
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 1)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 2)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 3)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 4)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 5)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 6)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 7)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 8)))
	(assert (possible-value (row ?row) (column ?column) (zone ?zone) (value 9)))
	(retract ?new_field))

(defrule rule_2
	(declare (salience 5))
	?new_possible_value <- (possible-value (row ?row) (column ?column) (zone ?zone) (value ?value))
	(not (possible-value (row ?row) (column ?column) (zone ?zone) (value ~?value)))
	=>
	(assert (field (row ?row) (column ?column) (zone ?zone) (value ?value)))
	(retract ?new_possible_value))

(defrule rule_3
	(declare (salience 15))
	?new_field <- (field (row ?row) (value ?value&~0))
	?new_possible_value <- (possible-value (row ?row) (value ?value))
	=>
	(retract ?new_possible_value))

(defrule rule_4
	(declare (salience 15))
	?new_field <- (field (column ?column) (value ?value&~0))
	?new_possible_value <- (possible-value (column ?column) (value ?value))
	=>
	(retract ?new_possible_value))

(defrule rule_5
	(declare (salience 15))
	?new_field <- (field (zone ?zone) (value ?value&~0))
	?new_possible_value <- (possible-value (zone ?zone) (value ?value))
	=>
	(retract ?new_possible_value))

(defrule rule_6
	(declare (salience 250))
	(field (value ?value&~0) (column ?column) (row ?row) (zone ?zone))
	?new_possible_value <- (possible-value (column ?column) (row ?row) (zone ?zone))
	=>
	(retract ?new_possible_value))

(defrule rule_7
	(declare (salience 4))
	?new_possible_value <- (possible-value (zone ?zone) (value ?value) (column ?column) (row ?row))
	(not (possible-value (zone ?zone) (value ?value)))
	(not (field (value ?value) (zone ?zone)))
	(not (field (value ?value) (row ?row)))
	(not (field (value ?value) (column ?column)))
	=>
	(assert (field (value ?value) (column ?column) (row ?row) (zone ?zone)))
	(retract ?new_possible_value))

(defrule rule_8
	(declare (salience 4))
	?new_possible_value <- (possible-value (zone ?zone) (value ?value) (column ?column) (row ?row))
	(not (possible-value (column ?column) (value ?value)))
	(not (field (value ?value) (zone ?zone)))
	(not (field (value ?value) (row ?row)))
	(not (field (value ?value) (column ?column)))
	=>
	(assert (field (value ?value) (column ?column) (row ?row) (zone ?zone)))
	(retract ?new_possible_value))
	
(defrule rule_9
	(declare (salience 4))
	?new_possible_value <- (possible-value (zone ?zone) (value ?value) (column ?column) (row ?row))
	(not (possible-value (row ?row) (value ?value)))
	(not (field (value ?value) (zone ?zone)))
	(not (field (value ?value) (row ?row)))
	(not (field (value ?value) (column ?column)))
	=>
	(assert (field (value ?value) (column ?column) (row ?row) (zone ?zone)))
	(retract ?new_possible_value))

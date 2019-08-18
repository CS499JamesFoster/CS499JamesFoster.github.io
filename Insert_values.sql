USE time_tracker;
SELECT * FROM employee;

INSERT INTO employee (first_name, middle_initial, last_name, hire_date)
VALUES('James', 'J', 'Foster', '2011-09-12');

INSERT INTO employee (first_name, middle_initial, last_name, hire_date)
VALUES('Jane', 'L', 'Doe', '2015-05-11');

INSERT INTO employee (first_name, middle_initial, last_name, hire_date)
VALUES('Jack', 'O', 'Walker', '2018-01-12');

INSERT INTO employee (first_name, middle_initial, last_name, hire_date)
VALUES('Frank', 'M', 'Joker', '2011-07-12');

UPDATE employee
Set first_name = 'Frank', middle_initial = 'M', last_name = 'Joker', hire_date = '2014-05-26'
Where employee_id = 6;

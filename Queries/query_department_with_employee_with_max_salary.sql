SELECT * FROM `train_database`.`department`
WHERE ID = (SELECT DEPARTMENT_ID FROM `train_database`.`employee` WHERE SALARY = (SELECT MAX(SALARY) FROM `train_database`.`employee`))
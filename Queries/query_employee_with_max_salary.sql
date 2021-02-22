SELECT * FROM `train_database`.`employee`
WHERE SALARY = ( SELECT MAX(SALARY) FROM `train_database`.`employee`)


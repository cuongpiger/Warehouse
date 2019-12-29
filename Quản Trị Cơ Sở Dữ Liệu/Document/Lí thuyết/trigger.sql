-Add the TotalCredit column to the student table 
 to show the total number of credits that students
 have accumulated. 
Writing triggers to maintain this column 
is always true.

create function getTotalCredit 
(@studentID varchar(20))
returns int
as begin
	declare @s int
	select @s=sum(sub.credis)
	from result r, subject sub
	where r.subjectID=sub.ID and r.studentID=@studentID 
and r.mark>=5	
   and r.times>=all(select r1.times from result r1 where r1.studentID=r.studentID and r1.subjectID=r.subjectID)
	return @s
end
alter table student 
add TotalCredit int
update student set 
TotalCredit =dbo.getTotalCredit (ID)

		insert   delete   update
Result     +       +        +(subjectID, mark, times, studentID)
Subject    -       -        +(credits)
create trigger Cau3_1 on result
for insert,update
as begin
	update student set 
	TotalCredit =dbo.getTotalCredit (ID)
	where ID in (select studentiD from inserted)
end
create trigger Cau3_2 on result
for delete,update
as begin
	update student set 
	TotalCredit =dbo.getTotalCredit (ID)
	where ID in (select studentiD from deleted)
end
create trigger cau3_3 on subject 
for update
as begin
	update student set 
	TotalCredit =dbo.getTotalCredit (ID)
	where ID in 
( select r.studentID
from result r, inserted i
where r.subjectID=i.ID
and r.mark>=5	
 and r.times>=all(select r1.times from result r1 where r1.studentID=r.studentID and r1.subjectID=r.subjectID)
)
end

-Add the TotalStudent column to the table teacher
 to show the number of students whom a teacher 
has manage. Writing triggers 
to maintain this column is always true.
create function getTotalStudent(@teacherID varchar(10))
returns int
as begin
	declare @q int
	select @q=count(*)
	from student s, class c
	where s.classID=c.ID and
	c.managerID=@teacherID
	return @q
end
alter table teacher
add TotalStudent int
update teacher set 
TotalStudent=dbo.getTotalStudent(ID)
		Insert Delete Update    
Class     -      +     +(managerID)
Student   +      +     +(ClassID)
create trigger Cau4_1 on Class
for delete, update
as begin
	update teacher set 
TotalStudent=dbo.getTotalStudent(ID)
	where ID in (select managerID from deleted)
end
create trigger Cau4_2 on Student
for insert,update
as begin
	update teacher set 
TotalStudent=dbo.getTotalStudent(ID)
	where ID in 
	(select managerID from inserted i, class c
	where i.classID=c.ID)
end
create trigger Cau4_2 on Student
for delete,update
as begin
	update teacher set 
TotalStudent=dbo.getTotalStudent(ID)
	where ID in 
	(select managerID from deleted i, class c
	where i.classID=c.ID)
end


	
















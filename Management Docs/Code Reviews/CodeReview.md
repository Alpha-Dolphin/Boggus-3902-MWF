Readability Review
Author of code review: Sounak Dey
Date of code review: 10/3/2022
Sprint 2
Name of file: rope.cs
Author of rope.cs: XiaoXiao Shi
Minutes taken to complete review: 20

Comments:
Code for the most part is decently readable and easy to follow with each variable given an 
appropriate name and a class structure that makes sense. The update function, however is a bit less 
readable than the other functions and requires a little more work to figure out what it is exactly doing. 
Dividing up some of the work done in the Update function into other functions would make the code even more
readable and easier to follow.

Quality Review
Author of code review: Sounak Dey
Date of code review: 10/3/2022
Sprint 2
Name of file: zol.cs
Author of zol.cs: XiaoXiao Shi

Comments:
Zol.cs looked very similar in structure to rope.cs. As far as quality goes, the class is easy enough to understand
and follow however again, the update function may need to be divided up into other functions to increase 
maintainability. If the game changed so that the jelly moved in a different motion and instead had three animations,
this code would be a bit tedious to change. The update function would have to be changed mainly with many constants 
being updated. A checkMoved function may help this particular scenario as well as an animate function to animate the 
sprite.

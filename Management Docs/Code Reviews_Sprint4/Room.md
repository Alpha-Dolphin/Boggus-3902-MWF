Author: Ben Elleman
Date: 11/14/22
Sprint#: 4
File Reviewed: .\Tools\LevelManager\Room.cs
File Author: John Cook
Time Taken For Review: 25 Minutes

Readability:

	No comments, but things are pretty intuitively layed-out and named.


Code Quality:

	In terms of coupling, this class does a very good job. As the room loader, there really isn't much opportunity for it to be coupled to anything in the first place.
	However, the use of constants throughout instead of magic numbers is a nice design that will prevent refactoring later on.

Conclusion:

	The Room class is well-built, with little fat or complexity. It does it's job simply and quickly without messing about.
	I can hardly think of any ways to improve upon the design.


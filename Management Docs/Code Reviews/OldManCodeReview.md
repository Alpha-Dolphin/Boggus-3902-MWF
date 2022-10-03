Author: Nate Crowder
Date: 10/3/22
Sprint#: 2
File Reviewed: ./Tools/NPCObjects/NPCFactory.cs
File Author: Sounak Dey
Time Taken For Review: 25 Minutes

Readability:

	Pretty readable. It is easy to tell what each part of the class is supposed to do. Update() and Draw() follow the convention.
	There is nothing unnecessary or extraneous that makes it more confusing than it has to be.
	As with my Arrow.cs file, the constructor arguments are used in opposite order of which they are called, which isn't a huge deal but
	is just a bit confusing at first.


Code Quality:

	Overall, this works well for for what we currently need; a static sprite that sits there to showcase its existence.

	Also the case with my item files, this loads a new spritesheet everytime the constructor is called. This is probably 
	unnecessary and an inefficient use of memory, but it will probably involve changing around the underlying sprite classes.

	To make the Old Man do anything beyond sit at a certain point, it will be necessary to complete the method body for Update(). 
	For our current functionality it is fine as it is, but we will have to change this later.

Conclusion:

	For what we need out of Sprint 2, this works perfectly fine. Moving forward, we will have to add the Update() body as mentioned
	to add functionality for the real game, as well as changing around the structure of the sprite classes to avoid constantly loading
	the spritesheet. Good work.
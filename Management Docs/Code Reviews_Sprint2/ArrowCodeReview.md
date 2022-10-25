Author: John Cook
Date: 10/3/22
Sprint#: 0
File Reviewed: ./Tools/ItemObjects/Arrow.cs
File Author: Nate Crowder
Time Taken For Review: 25 Minutes

Readability:

	Generally Good, The object definition has a few properties up top that have good variable names.
	Not a lot of fluff or logic contained at the top level.

	The constructor makes some sense though I would benefit from a comment defining the function, and the order
	of the arguments is reversed from the order they're called by the constructor which is a bit mind bendy.


Code Quality:

	Not much to say here. The use case for this object isn't fully defined yet so the only object
	that it's coupled to is the StationaryStaticSprite which seems fine for now.

	From a memory perspective this does load a new spritesheet every time a new arrow is created which
	is not an efficient use of memory or processing time. The spritesheet is already loaded on a global level
	so it could just be referenced here. That may be something that has to be corrected in the StationaryStaticSprite
	class though. Maybe a better sprite class could be created to avoid that.

	If we wanted this arrow to appear, dissappear, or move the Update function will probably need a body. As is these functions
	are not supported. Which is fine for this sprint but will be needed in the future.

Conclusion:

	Good enough for now. There are concerns for the future but nothing gamebreaking
	or out of scope for iterative development as far as I can tell.
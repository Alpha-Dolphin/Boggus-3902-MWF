Author: Aubert Li
Date: 10/24/22
Sprint#: 3
File Reviewed: .\Tools\Collision.cs
File Author: Ben Elleman
Time Taken For Review: 25 Minutes

NOT UPDATED
Readability:

	Good in readability, most of the code is clear on what exactly it's doing. The comments about the
	help focus on the nitpicks that are not immediately obvious (referring to link's sword here).


Code Quality:

	In terms of coupling this class does an okay job, coupling itself with Link as well as a few interfaces,
	these seem mostly unavoidable. The reusability is also limited by the handling of different types of objects, 
	however this isn't too much of a concern since the enemies themselves are very specific. This can be 
	refactored later to have a collision handler as well as a collision detection class.

Conclusion:

	This class is okay, there aren't any huge causes for concern and will need some revamping to work 
	better with code quality concepts. I would argue that the changes needed are more due to the structure of the sprints.
	Overall good job abstracting most of the code away from specifics and relatively clean code. The vague 
	variable names are unavoidable as collision deals with everything.

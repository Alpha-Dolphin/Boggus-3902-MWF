Author: Aubert Li
Date: 11/14/22
Sprint#: 4
File Reviewed: .\Tools\EnemyObjects\Stalfos.cs
File Author: Ben Elleman
Time Taken For Review: 25 Minutes

NOT UPDATED
Readability:

	Good in readability, most of the code is clear on what exactly it's doing.


Code Quality:

	In terms of coupling this class does an okay job. The Stalfos should probably include the logic for
	the StalfosSprite instead of using another separate sprite, but it doesn't cause any large issues.
	Everything else looks good, the state transitions of it also help with death handling.

Conclusion:

	This class is good, everything works properly and looks okay, some logic is hidden in its sprite
	but that isn't a major concern.


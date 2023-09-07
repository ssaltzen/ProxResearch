# Social Proxemics ---  Virtual NonHumanoid Model 
Virtual Nonhumanoid model is a model designed for user interaction in a research testing game, aimed at exploring the social proxemic differences between reality and the game environment. This documentation will primarily focus on demonstrating the process behind the scene.

## Researcher Information ##
**Role**: _Virtual Non Humanoid Model_

**Name**: _Huy Nguyen_

**Email**: _hxnguyen@ucdavis.edu_

## Begin ##

### Set up: 
 -  **Unity Version**: 2022.2.13f1


### Non Humanoid Models:
 - Model #0 : Initial fbx format female model from [mixamo.com](https://www.mixamo.com/#/), titled `Goblin_D_Shareyko`



## Models Test Process ##


## The Scripting Process ##
The model came from mixamo website. I also downloaded the animation that is considered useful in the Proximity research. They are IDLE, Walk, and Informal Bow.

The folder contains 2 scripting files: GoblinController.cs and RandomMovement.cs. The GoblinController file act as the bone and movement of the goblin himself. The other acts as a reference online, came from this [Github](https://github.com/JonDevTutorial/RandomNavMeshMovement) link. The following bullet points descript the general idea of how the Goblin moves.

1. 
    i. We implemented a preset of location on our map. Using these preset locations, we settle on random for the model to inherent the random movement.
    
    ii. Behind, a nav mesh model, which will scan our plane and obstacles and avoid phrasing through.  
    
2. 
    i. From here, it is in the GoblinController.cs that took over. It will consider moving at toward the first location. Wait there at a specfic time and palace, and move toward another location.
    
    ii. If there are players, or our interactive participants, our model will greet them if they get too close. A informal bow is selected for the purpose of this research. This part is partially working. There are some bugs that occured in the implementation car. 


## Reference ##



[Mixamo Offical Website](https://www.mixamo.com/#/)
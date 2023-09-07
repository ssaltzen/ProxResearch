# Social Proxemics ---  Virtual Humanoid Model （Female Model）
Virtual character models are humanoid models designed for user interaction in a research testing game, aimed at exploring the social proxemic differences between reality and the game environment. Human behavior can vary when interacting with different characters. Therefore, we have included male, female, and gender-neutral character models. Our goal is to make these character models mimic normal human behavior while also being valuable for research purposes. To achieve this, we have incorporated a variety of animations and ensured that the characters can be utilized in both base and augmented reality (AR) modes. This documentation will primarily focus on the process of creating and working with the female character model.

## Researcher Information ##
**Role**: _Virtual Humanoid Model - Female Model_

**Name**: _Xinhe Wang_

**Email**: _xhewang@ucdavis.edu_

## Begin ##

### Set up: 
 -  **Unity Version**: 2022.2.13f1
 -  **Maxon Cinema 4D 2023**



### Female Humanoid Models:
 - Female Model #0 : Initial fbx format female model from sketchfab.com.
![female#0Unity](https://github.com/ssaltzen/ProxResearch/assets/115097655/1e62283d-d7c2-401a-9430-dd2b76a428c3)

 - [Female Model #1](https://github.com/ssaltzen/ProxResearch/tree/8232085f0ba5a2be95de3a856e5253bf874deeec/Social%20Proxima%20Testing/Assets/VirtualModels/Models) : After team deliberation, we've opted for a uniform character style to enhance immersion. The characters will be available in the fbx format for seamless integration. Prepare for an immersive experience that transcends reality.
![female#1Unity](https://github.com/ssaltzen/ProxResearch/assets/115097655/e6fc6590-455e-466a-86f9-2eedcc50160e)

 - Extra Female Model: Build a female model from scratch using C4D(in process).
![ExtraModelinProgressError](https://github.com/ssaltzen/ProxResearch/assets/115097655/4b496297-fa6b-43b1-bc07-7c6d8f8e577e)


## Female Models Build Process ##


### Female Model #0

Initially, my plan was to acquire a premade character model and add animations using Mixamo. However, due to Mixamo.com's file format restrictions (accepting only fbx, obj, and zip), I extensively searched for a suitable model that would seamlessly integrate with the platform. Eventually, I discovered "Female Model #0" on sketchfab.com, a pre-made humanoid model complete with bones. I proceeded to create a range of animations including sit, sit talking, walk, run, and waving, further enhancing the character's versatility and lifelike movements.

Here is the screenshot of the character in Mixamo.com:
![female#0MixamoUpload](https://github.com/ssaltzen/ProxResearch/assets/115097655/c5ab4f53-cd39-4aaf-b8b9-30e1b3d79537)
![female#0Mixamo](https://github.com/ssaltzen/ProxResearch/assets/115097655/8529b932-8278-450f-93bb-935c882ed43a)



### Female Model #1

Following a productive group meeting with Davin and Jesse, we have collectively decided to streamline our character style selection in order to deliver an enhanced gaming and observation experience for both players and researchers. We have chosen a pre-existing character model package which included bones, ensuring effortless integration of additional animations as per future requirements. The Female Model #1 is from that model package. 

Similar to the previous model, I have also uploaded "Female Model #1" to Mixamo. After addressing format issues and meticulously debugging the character model within Mixamo, we have successfully achieved seamless animation functionality.
![female#1Mixamo](https://github.com/ssaltzen/ProxResearch/assets/115097655/4ce7c7f8-5f0e-4b4b-b17a-14869856871a)

One notable observation we made while utilizing Mixamo is that when downloading different animations for the same model, Unity treats each animation as a separate model instead of a single model with multiple animations. This presented a challenge for us, prompting further discussion during our follow-up group meeting.

To address this issue, we initially explored combining all the animations using Blender. However, during the process, I stumbled upon an alternative approach that seemed more efficient and straightforward: editing the animations directly within Unity. Collaborating closely with Davin, I successfully created an animation controller specifically tailored for "Female Model #1," allowing for seamless integration and control of various animations within Unity's environment.

Animation Controller in Progress Screenshot:
![AnimationController_inProgress](https://github.com/ssaltzen/ProxResearch/assets/115097655/bf81c970-a5ee-4a73-a71f-7aa948ad55ec)

Female model asset in Unity with animations:
![female#1UnityInfo](https://github.com/ssaltzen/ProxResearch/assets/115097655/58f2b5dc-d84c-4027-a446-dca95df309ee)

Detail informations of Female model's animations:
![female#1UnityAnimationInfo](https://github.com/ssaltzen/ProxResearch/assets/115097655/8a965c52-ca7b-4c28-9f50-190ad4a5c49a)

With the completion of the model and animations, our focus now shifts to thorough testing by our team to identify any potential additions or adjustments that may be required. Once we are satisfied with the results, we will share the model with other teams, encouraging them to test and utilize it in their respective projects. We eagerly anticipate receiving valuable feedback from these teams, which will help us further refine and enhance the overall quality of the model.


### Extra Female Model（In Progress）

After individual meeting with Siena, I decided to create a 3D model from scratch with C4D to get experiences with new skills relate to Virtual Modeling. 

I following the [tutoring video](https://www.bilibili.com/video/BV1J24y1z7GC/?spm_id_from=333.880.my_history.page.click&vd_source=eac0914bfe8c5470c96b9f441ab50f36) of C4D Personalized Cartoon Character. 

I first start with the character body, and create a cylinder to start with. changed the properties and lining format to better build on it.
![Screenshot (584)](https://github.com/ssaltzen/ProxResearch/assets/115097655/992995b5-cbc5-4f3e-9cef-4f826915acb6)

Secondly, I reshape the cylinder, by squeeze its width to let haev a back and front of body. Then choose the top right area to cut and pull out the shoulder 
![Screenshot (588)](https://github.com/ssaltzen/ProxResearch/assets/115097655/28545a5c-c14f-484c-94a5-bba3faf6f047)

Thrid, I delete the body's bottom surface and recreate a surface where the tight will connect to. Then adjust the body's outer edge to make it have a waist. 
![Screenshot (591)](https://github.com/ssaltzen/ProxResearch/assets/115097655/281ae4c3-23b4-433f-877d-b4a67bf6f8e4)

Until here, I only did the right side of the body. Since we know hunman body is symmetry, therefore I can just delete the left half and create a symmetry copy of the right side body and connect them together to have the full body.
![Screenshot (576)](https://github.com/ssaltzen/ProxResearch/assets/115097655/ef011361-8d82-45ce-acce-8498407ccdf6)

Then, I want to cut the top layer of the body to draw a circle and pull it out to have the neck. However, I am facing some trouble that it won't let me correctly cut the top platform, so I am currently stuck right here.
![Screenshot (577)](https://github.com/ssaltzen/ProxResearch/assets/115097655/52514b54-77e3-4ca6-8f1d-a5e1b6883bbd)


## Testing ##
We build and run the female character model on unity to test its animation. After first round of testing, I send the female character model to AR team to let them test and build. We received some feedback about the model's size, however afterward they noticed that they can adjust the size, so problem solved. 

![9815f115cf3bb4459c24dded5d984a5f (1)](https://github.com/ssaltzen/ProxResearch/assets/115097655/d020d3a6-bbf3-43da-9cfd-6a03a235b40e)


Through out the testing, we noticed that the sit position which will coorperate with base team's sofa might need adjustions inorder to perfectlly fit togehter. After the base team test with the model we recieved feed back that: 
1. **Character Model Selection**:
    i. The character model menu selection resets to option 0, "male" every time the game is paused
    
    ii. The character model menu selection only works for option 0, "male." When selecting option 1, "female," the system will instead spawn in option 2, "non-binary." When the character menu is set to "non-binary" or "non-humanoid," nothing is spawned and an error occurs. 
    
2. **Set data tracker** to track the virtual model instead of the couch
    i. The data tracker was temporarily assigned to track the couch before the virtual model was developed. Sage Zimmerman tried to switch the tracker to track the virtual model instead, but she state that she was not knowledgeable enough to do this. Asking someone else on the virtual model team or the data team to give it a shot!
    
    ii. The virtual model game object just needs to replace the "Couch" serialized field in the PlayerDistanceTractor.cs script, which is currently located in the "Game Controller" object in the dynamic room scene. 


### Download C4D ###
For the extra female model, I use Maxon Cinema 4D 2023 to create and build the Extra Female Model. C4D is essential for creating 3D Models that can later build with bones then use in Unity with Mixamo.

Download C4D from: https://www.maxon.net/en/downloads


## Following Work ##

For future research and enhancement, we require a broader range of models to generate diverse research findings and data for the project. We plan to incorporate several new functionalities in our subsequent work.

- Add in face and gesture recognition
- Add animation feed back according to the model's identity
- Animation Controller Update: Add in new animations therefore animation controller need to revise too. 


## Reference ##

[C4D个性化卡通角色｜身体建模](https://www.bilibili.com/video/BV1J24y1z7GC/?spm_id_from=333.880.my_history.page.click&vd_source=eac0914bfe8c5470c96b9f441ab50f36) 

[CINEMA 4D USER GUIDE](https://help.maxon.net/c4d/en-us/)

[How to Animate Characters in Unity 3D | Importing Free Characters and Animations from Mixamo](https://www.youtube.com/watch?v=-FhvQDqmgmU)

[Maxon Cinema 4D 2023 EDUCATIONAL LICENSING](https://www.maxon.net/en/educational-licenses)

[Mixamo addon for Blender 2.8/2.9/3.0](https://www.youtube.com/watch?v=wYqJ7AyEuhc)

[Mixamo Offical Website](https://www.mixamo.com/#/)

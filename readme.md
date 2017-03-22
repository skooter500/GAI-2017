# DT228/DT282/DT211 4th Year Game AI Course 2017

[![YouTube](http://img.youtube.com/vi/iucyXHyrBQI/0.jpg)](https://www.youtube.com/watch?v=iucyXHyrBQI)

## Resources
- [Class Facebook group - Please join!](https://www.facebook.com/groups/1887916721485612/)
- [Previous lab tests](https://1drv.ms/u/s!Ak7y2552PWCrkNACJ7n8qiU8UPRs9w)
- [Assignment]()
- [A set of out of date course notes](https://onedrive.live.com/?authkey=%21AAb-R5vP9R9enWo&id=AB603D769EDBF24E%21210396&cid=AB603D769EDBF24E)
- [Forms git repo - Please Fork!](https://github.com/skooter500/Forms)
- [A spotify playlist of music to listen to while coding](https://open.spotify.com/user/1155805407/playlist/5NYFsIFTgNOI93hONLbqNI)

## Contact the lecturer

- Email: bryan.duggan@dit.ie
- Twitter: [@skooter500](http://twitter.com/skooter500)
- [Class Facebook group](https://www.facebook.com/groups/1887916721485612/)

## Web Resources
- [AI Game Dev](http://aigamedev.com/)
- [GDC Vault](http://www.gdcvault.com/)
- [Game maths tutorials](http://www.wildbunny.co.uk/blog/vector-maths-a-primer-for-games-programmers/)
- [Behaviour trees in C#](https://github.com/BraveSirAndrew/DisciplineOak)

## Previous years courses
- 2015-2016
    - https://github.com/skooter500/gameengines2015
    - https://github.com/skooter500/BGE4Unity
- 2014-2015
    - https://github.com/skooter500/BGE
    - https://github.com/skooter500/UnitySteeringBehaviours 
- 2013-2014
    - https://github.com/skooter500/XNA-3D-Steering-Behaviours-for-Space-Ships

## Week 9
- Obstacle avoidance behaviour
- Coroutines

![Image](images/IMAG0190.jpg)

### Lab
Check out these happy, dancing, back flipping tardigrades:

[![YouTube](http://img.youtube.com/vi/5lNe3H6jXJA/0.jpg)](https://www.youtube.com/watch?v=5lNe3H6jXJA)

They use a variation of the harmonic behaviour that we learned last week that I call NoiseWander. Instead of using a sin finction to generate the steering, NoiseWander uses Perlin Noise. See if you can implement NoiseWander. Perlin noise is a really cool technique for generating coherent noise that has lots of applications in game development. For example, Perlin noise is used to generate the rolling landscapes in Minecraft. I also add several Perlin noise functions together to generate the landscape of Forms.

In the second video, the dolphin is combining a vertical harmonic steering behaviour with NoiseWander. Both behaviours are active on the dolphin at the same time and the forces are weighted and summed. See if you can make something similar.

[![YouTube](http://img.youtube.com/vi/_qrh4X9B7qA/0.jpg)](https://www.youtube.com/watch?v=_qrh4X9B7qA)

In the third video (which you have probably already seen) many of the creatures use another script called HarmonicController. What this does is every few seconds, changes the frequency and amplitude of the harmonic controller. I lerp to the new values so the changes are nice and smooth. See what you can come up with using a similar technique:

[![YouTube](http://img.youtube.com/vi/-dTmgEUPLj0/0.jpg)](https://www.youtube.com/watch?v=-dTmgEUPLj0)

## Week 8
- Harmonic steering behaviour
- Spine animator
### Lab

Have a look at the PathFollowSteering project in the git repo and implement the Harmonic steering behaviour you can see in this video:

[![YouTube](http://img.youtube.com/vi/zOMWSVkWpT8/0.jpg)](https://www.youtube.com/watch?v=zOMWSVkWpT8)

You can see from the gizmos what the behaviour needs to do. The harmonic steering behaviour should seek a point on the outside of a sphere whose center is projected in front of the boid on the X-Z plane. The point should move along the circumpherence of the sphere on a harmonic motion.  You can specify the frequency and amplitude of the harmonic and the radius and distance to the harmonic sphere. Your harmoinc behaviour should also draw lovely gizmos. 

In the class we will implement a lerping spine animator and some other lerping magic which we will use with the harmonic steering behaviour to make all kinds of wriggling creatures.  

## Week 7 
- Games Fleadh    

## Week 6
- Forms a journey into the deep heart of code

    [![YouTube](http://img.youtube.com/vi/ZLmbl5NSCew/0.jpg)](https://www.youtube.com/watch?v=ZLmbl5NSCew)

- My latest creatures video

    [![YouTube](http://img.youtube.com/vi/-dTmgEUPLj0/0.jpg)](https://www.youtube.com/watch?v=-dTmgEUPLj0)

# Lab

The aim today is to program a path following behaviour. You can use the steering behaviours notes to figure out how to do it from a blank Unity project or you can start with the [project from last week](unity/SeekArrivePursue). Whay you should to is: 

- Make a Path component
- Make it a field in the Boid
- Make a path following behaviour in the Boid

Things to consider
- How will you store the waypoints?
- Can you add the option of looping the path, so that when the boid reaches the end of the path, it loops back to the start.
- How can you refactor the steering behaviours code to make it better? Consider making each behaviour a seperate component. 

## Week 5
- Seek & arrive steering behaviours - Look at the slides for [course notes](https://onedrive.live.com/?authkey=%21AAb-R5vP9R9enWo&id=AB603D769EDBF24E%21210396&cid=AB603D769EDBF24E)
- [Seek and arrive steering behaviours in Unity.](https://github.com/skooter500/GamesAIBasics) These are implemented using my old framework (boolean flags - quick and dirty but ugly)
- [Assignment brief! PM me with any comments/ideas](ca.md)
- [Craig Reynolds on steering behaviours](http://www.red3d.com/cwr/steer/) - Everyone should read!

# Lab

- Make this in Unity:

    [![YouTube](http://img.youtube.com/vi/wB4Ptbgwra0/0.jpg)](https://www.youtube.com/watch?v=wB4Ptbgwra0)

- What is happening:
- Third person camera that follows the player tank, which is controlled with the wasd keys. Shoot with the space key
- The game always tries to keep 5 target tanks around the player
- Tanks spawn every 2 seconds starting after 3 seconds into the game
- Bullets disappear after 20 seconds
- When a bullet hits a target tank, it should explode. After 3 seconds the pieces sink into the floor and a new tank will respawn

- [Lab Solution](unity/Demo1) - Switch branch to tank_ai to get the solution!

## Week 4
- Unity Fundamentals. Maks sure you know about:
    - GameObjects
    - GameComponents
    - Transforms, positions, quaternions
    - Lerping, Slerping and LookAt
    - Getting and adding gamecomponents programmatically
    - Awake, Start, Update
    - Instiantiating GameObjects from prefabs
    - Using materials an setting colours
    - The fundamentals of lighting
    - Using tags
    - Using Coroutines
    - Using Invoke
- [Demo project we worked on with the movable tank](unity/Demo1)

## Week 3
- Making creatures with tails and stuff

[![YouTube](http://img.youtube.com/vi/Z9Phd1HzTT0/0.jpg)](https://www.youtube.com/watch?v=Z9Phd1HzTT0)

# Lab

Use Forms to make a new creature. The steps we followed to make Steve are:

- Make a head:
    - Renderer
    - Boid
    - Harmonic
    - Spine Animator
    - Optionally add
        - Noise Wander
        - Obstacle avoidance
        - Harmoinc Controller
        - Any other behaviours
- Make a body
    - Just a renderer, no behaviours
- Make a Creature Generator
    - Experiment with the parameters to change the layout of the segments
    - Set the head and body prefabs
    - Test it!
- Make fins/wings. You need to make seperate left and right wings 
    - Make the fin head
        - Fin Animator
        - Spine Animator
    - Make the fin body segment
        - Just a renderer
    - Use a Creature Generator to layout the wing segments
- Make the tail
    - Make the tail body segment and attach a CreatureGenerator to make the actual tail
    - Make the tail head
        - Tail Animator
        - Spine Animator
    - Make the tail body          

## Week 2
- Making creatures part 1:

    [![YouTube](http://img.youtube.com/vi/9E087q0SEBM/0.jpg)](https://www.youtube.com/watch?v=9E087q0SEBM)

# Lab
- Make a procedural fish animation
- Fix bugs in Forms

## Week 1
- [Introduction slides](https://1drv.ms/p/s!Ak7y2552PWCrjP0aAPZh_GfC1J8xyA)


# Running Game (Rolling road)

This is the Documentation of the Running Game Package which will be the first brief ill be focusing on to create an endless runner with random turns at random points in the game, This is inspired by games such as the mobile running games, Temple Run and Subway Surfers.

## Scripts And its Behaviours
-  (Old) Platform spawner
- NewPlatformSpawner
- DestroyAfter
- CameraMovement
- PlayerMovement

### Old Platform spawner

This is an old script i used to create a platform for the user which will continuously clone the platform prefabs in front of the player. The transform variable **`PlatformDuplicate`** is what spawns in the platforms in the Z-axis using a [Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html) Variable called **`PlatformIncrementer`**.

A coroutine called **`PlatformSpawn`** is what spawns the platform after a certain amount of time had gone by - in this case after 1.5 seconds, after those seconds go by, the [instantiate](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html) method is called which increments the position of the next platfom by 3.2 unity units in the z-axis, which is then called agaian to spawn the next platform

### NewPlatformSpawner

The newer Script is more efficient since it didn't require existing platforms in the scene to actually spawn the platforms, This one will continuously spawn new platforms in front of the player and will randomly create turning platforms as the player progresses through the game.

The script uses a reference point object and a gap value to determine the placement of the next platform. The time offset is what controls the amount of platforms it will spawn at a time.

There are a series of [Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html) variables which determine the direction and position of each platform. With the implementation of [random](https://docs.unity3d.com/ScriptReference/Random.html), a random number is generated to determine exactly when to create turning platforms for the player.

### DestroyAfter

The script here [destroys](https://docs.unity3d.com/ScriptReference/Object.Destroy.html) the game object after a certain time had passed. The script checks the position of the game object's z-axis compared to the camera's z-axis, if the game object is behind the camera, it will be destroyed after the set delay. This is done through a method which is called in the [update](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html) function so that the game object is checked every time to meet its conditions.

### CameraMovement

the script here controls the movement of the camera in the game, where the player's game object is followed as the target object. The camera has a fixed distance away from the player with a height offset. The camera's position is updated each frame so that it follows the target smoothly.

### PlayerMovement

The Script here is for controlling the movement of the player in the game. The player moves fowards automatically and will turn left or right depending on the keys being pressed. The script use's a [CharacterController](https://docs.unity3d.com/ScriptReference/CharacterController.html) component which handles the movement and rotation of the player. The speed of the player can be changed in the inspector called **`CharSpeed`**.

## Parameters

### CameraMovement
`TargetToTrack` should always be the object that has the movement script inside it so that the player is targeted during the program when its ran. You may ste the `DistanceAwayFromTarget` to any value you desire so that the camera follows the player at a certain distance you want. `HeightOffset` is changable to what height you'd like the camera to be from the player with the cameras delay for the actual delay of when the camera should start following the player.

### NewPlatformSpawner
`PlatfromToSpawn` will hold the prefab called `PlatformDuplicate` so that the platform being duplicated is that certain platform. `ObjectReferencePoint` will hold the preplaced platform at the end which will be where the duplications will occur at. `GapsBetweenPlatforms` can be changed to what ever number you desire - however this will affect the gameplay since the player may fall through the gaps between the platforms that are spawning. `TimeOffset` can be changed to what ever number you want for how frequent the tiles should spawn. And lastly a random number generator you may choose for when a turn should occur during runtime.

### PlayerMovement
`CharSpeed` is changable to what ever value you prefer to change the speed at which the player is moving at.

# - the scripts have been commented for a better understanding -





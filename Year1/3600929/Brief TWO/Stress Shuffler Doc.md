# Stress Shuffler (Shuffle)

This is the Documentation for the Shuffling of music brief where i will be stress testing the randomness of which order the tracks play at, whilst also detecting whether a track thats been played is playing again and to catch those errors whereby the random didnt in fact change the songs randomly and just played the same song again. 

## Scripts And its Scenes
- ShufflePlaylist
- ShuffleTester

- Working Scene (no errors)
- Error Scene (with errors)


### ShufflePlaylist

The following Script is for shuffling and playing a list of tracks in Unity. The script uses a [list](https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Array.html) variable which stores the tracks, in this case 6 tracks have been selected and an [AudioSource](https://docs.unity3d.com/ScriptReference/AudioSource.html) variable to play the tracks. The script also uses several [variables](https://docs.unity3d.com/Manual/VariablesAndTheInspector.html) to keep track of the current tracks and the number of tracks played.

There are three main [methods](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) in this script; **`TimePlayingIncrementer`**, **`ChangeSong`**, and **`ReShuffleSong`**. **`TimePlayingIncrementer`**, increments a timer variable while a track is playing. **`ChangeSong`**, skips to the next track if the current track playing is done or the player pushes the space key. And lastly the **`ReShuffleSong`**, resets the list of tracks played if all tracks have been played and shuffles the list if there are no repeated tracks.

Another method the script has is the **`SkipToNextSong`** method which plays the next track and updates the variables accordingly.

The script also uses Unity [action event](https://docs.unity3d.com/ScriptReference/Events.UnityAction.html) system to notify other components of changes in the current track.



### ShuffleTester

This script checks for audio that has been played already from the playlist and saves them into a list. It uses the event system to check for changes in the currently playing track and compares it to the previously played track - and if both were the same, a [debug error](https://docs.unity3d.com/ScriptReference/Debug.LogError.html) statement is printed out in the console, however if theyre not the same, another statement is logged indicating a different track is playing. If **`SaveToList`** is **true**, the currently playing track is appended to the list of played audio tracks.

### Working Scene (no errors)

The **`WithErrors`** boolean field is unchecked in the **`ReShuffleSong`** method so that the method runs without possible repetitions when the tracks are shuffled. 

### Error Scene (with errors)

**`WithErrors`** boolean field is checked in this scenario, which means the shuffle will result in possible repetitons as the program **skips the line** in the **`ReShuffleSong`** method called `MusicThatPlayed[i] = false;` and **will not reset** the **`MusicThatPlayed`** array allowing the possibility of repetitions.


## Parameters

### ShufflePlaylist

- `PlayList` will be holding the number of tracks in the array with the tracks itself.
- `TracksToPlay` will be holding the audiosource in which they  audio is coming from which in this case is the gameobject.
- `TimePlaying` is the duration the music is has been playing of the current track.
- `MusicThatPlayed` takes into account the tracks in the PlayList and checks them wheter they are played to true and falses only when all the tracks have played to reset the list.
- `WithErrors` is unchecked but can be checked so that repetitions can occur.
- `SaveToList` can be activated to save the tracks into a list to check for the repetitions of the tracks if a song had played twice.

### ShuffleTester

- `ShufflePlaylist` takes the reference of the script **`ShufflePlaylist`** from the game object.
- `PreviouslyPlaying` holds the track which had played last before the current track that is playing
- `CurrentlyPlaying` holds the track that is currently playing
- `PlayedAudioClips` holds the tracks that have played during runtime and will only save into the list if `SaveToList` **is active**.


# - the scripts have been commented for a better understanding -





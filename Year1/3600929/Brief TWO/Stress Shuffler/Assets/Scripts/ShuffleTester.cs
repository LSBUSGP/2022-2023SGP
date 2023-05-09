using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTester : MonoBehaviour
{
    [SerializeField]  ShufflePlaylist ShufflePlaylist; // reference to script
    [SerializeField]  AudioClip PreviouslyPlaying; // audioclip variable which will hold the track that played last
    [SerializeField]  AudioClip CurrentlyPlaying; // audioclip variable for what tracks playing in the present
    [SerializeField]  List<AudioClip> playedAudioClips; // a list for all the audiofiles that have been played 
    [SerializeField]  bool SaveToList; // bool to save the tracks that played to the list

    private void Start()
    {
        ShufflePlaylist.OnChangeSong += CheckDuplications; // the invoked function is ccarried out here from the refernec script ( the action in which the event will carry out)
        playedAudioClips = new List<AudioClip>(); // played audioclips list is created
    }

    private void CheckDuplications()
    {
        PreviouslyPlaying = CurrentlyPlaying; // the previous playing track will be the the track currently playing
        CurrentlyPlaying = ShufflePlaylist.CurrentlyPlaying; // the currently playing from this script is referenced from the other script that is also in currentlyplaying 
        if(CurrentlyPlaying == PreviouslyPlaying) // if the currentlyplaying is the same as the previousplaying tracks
        {
            Debug.LogError("Same Track is playing!"); // this will print out into the console
        }
        else // or
        {
            Debug.Log("Different Track is playing!"); // there is no repitions in the list of songs
        }
        if(SaveToList) 
            playedAudioClips.Add(CurrentlyPlaying); // appends to the list of all the tracks that are currently playing
    }
}

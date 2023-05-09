using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShufflePlaylist : MonoBehaviour
{
    [SerializeField] List<AudioClip> PlayList; // list variabled called playlist which will be accessible in the unity inspector to add the music into the list
    [SerializeField] AudioSource TracksToPlay; // audiosource variable called trackstoplay 
    
    [SerializeField] float TimePlaying; // float variable in which will increment as the song/music plays in the program
    [SerializeField] float MusicPlayed; // float variable in which increments by one everytime the method is called
    [SerializeField] bool[] MusicThatPlayed; // a bool list in which checks what music has already been played in the list leaving the random songs unchecked  
    [SerializeField] bool withErrors;
   
    public event Action OnChangeSong; // creates an event in unity 
    public AudioClip CurrentlyPlaying; // currentlyplaying is a cache variable for whats being played currently

    // Start is called before the first frame update
    void Start()
    {
       TracksToPlay = GetComponent<AudioSource>(); // TracksToPlay variable cachesthe AudioSource component 
       MusicThatPlayed = new bool [PlayList.Count]; // assigning the list with the playlist audioclip variable list which holds all the audio files
    }

    // Update is called once per frame
    void Update()
    {
        TimePlayingIncrementer();
        ChangeSong();
        ReShuffleSong();
    }

    void TimePlayingIncrementer() // timeplaying incrementer method
    {
        if (TracksToPlay.isPlaying) // if the Trackstoplay variable is active and playing music
        {
            TimePlaying += 1 * Time.deltaTime; // TimePlaying variable is incremented by 1 multiplied byt the frames of our system 
        }
    }

    void ChangeSong() // change songs method
    {
        if (!TracksToPlay.isPlaying || TimePlaying >= TracksToPlay.clip.length || Input.GetKeyDown(KeyCode.Space)) // if the trackstoplay variable is inactive or the timeplaying variable is greater than the actual musics length or runtime or user enters space bar
        {
            SkipToNextSong(UnityEngine.Random.Range(0, PlayList.Count)); // the method is ran where a random index is selected from the list playlist from 0 to the legth of the playlist 
   
        }
    }

    void ReShuffleSong() // shuffling songs method
    {
        if (MusicPlayed == PlayList.Count) // if the musicplayed variable hits the same amount of tracks in the playlist
        {
            MusicPlayed = 0f; // reset the musicplayed variable to 0
            for (int i = 0; i < PlayList.Count; i++) // for integer i = 0 as long as i is less than the playlist length, increment i
            {
                if (i == PlayList.Count) //  if the integer i is equal to the length of the playlist
                {
                    break; // break out of the for loop and stops incrementing 
                }
                else // or
                {
                    MusicThatPlayed[i] = false; // Musicthatplayed list bool is set to false and pass in i for the integer of what music or song its on
                }
            }
            if (withErrors) // a boolean is checked when the array runs with errors (repitions in the array)
                return; // the program will not go beyond this point 
            MusicPlayed++; // musicplayed is incremented by 1
            MusicThatPlayed[PlayList.IndexOf(CurrentlyPlaying)] = true; //music thats played will be set to true at the index of currentlyplaying
        }
    }

    void SkipToNextSong(int currentlyPlaying) // method for skiping to the next track with a temp variable called currentlyplaying in integer form
    {
        if (!MusicThatPlayed[currentlyPlaying]) // if musicthatplayed bool list is falsed the currently playing variable is assigned to whats playing  
        {
            MusicPlayed++; // increments MusicPlayed float variable by 1 
            MusicThatPlayed[currentlyPlaying] = true; // MusicThatPlayed that was "currently playing" is now set to true 
            TimePlaying = 0f; // timeplaying variable resets to 0
            TracksToPlay.clip = PlayList[currentlyPlaying]; // AudioSource variable is equal to the playlist [list] assigning the next track to play as the integer variable "currently playing"
            CurrentlyPlaying = TracksToPlay.clip;
            TracksToPlay.Play(); // AudioSource plays
            OnChangeSong?.Invoke();
        }
        
        else // or
        {
            TracksToPlay.Stop(); // stop playing the music
        }
    }
}


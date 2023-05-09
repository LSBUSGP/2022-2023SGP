# Music Spec (Audio Frequency Detector)

This is the brief where I had to create an Audio frequency detector where by i'll be showing some cubes transform when they detect the band frequencies they currently have. Using calculations to update the values at every frame so that we can visualize the audio through the cube prefabs which transforms when a frequency band is detected. This script will be showcasing the `Getcomponent<AudioSource().GetSpectrumData(Samples, channel, FFTWindow);`which essentially converts audio into small samples into frequency data and amplitude. Since the human hearing can hear a range of hertz from 20 to 20,000 herts, i will be making the samples smaller since the range would be too big to deal with when sampled. So to split the hertz into bands i divided by 512 which gave us a smaller number to deal with. I further split the hertz into 4 bands which should be configurable in the inspector for which frequency can be detected during runtime (22050/512 = 43hertz 43 * 1 to 4 for the four bands)

## Scripts And its Behaviours 

- AudioData
- CubeScript
- FlashCubes
- InstantiateCubes



### AudioData

The AudioData Script is responsible for genertaing and manipulating audio data from the [AudioSource](https://docs.unity3d.com/ScriptReference/AudioSource.html) component in unity. This forms the frequency bands based on the spectrum data is gathered from the AudioSource. To smoothen out the transitions between the bands a buffer is used for a clean and crisp look. The script also created audio bands by dividing the frequency bands by the highest frequency band (22050Hz) and stores the values into an array which is accessed by other scripts. This all occurs in the update function in order for accurate data to be given. The [Fast Fourrier Transform Window](https://docs.unity3d.com/ScriptReference/FFTWindow.html) being used is the [Blackman](https://docs.unity3d.com/ScriptReference/FFTWindow.Blackman.html) algorithm to reduce the spectral leakage.


### CubeScript

The following script mannipulates the cube prefabs in order to show the bands frequency being detected from the AudioData script which is then visually represented on the cubes by showing the different transforms of the cube on different bands. By accessing the `AudioData` script, the cubes can either be using the frequency bands or the buffer band array. The cubes `StartScale`and `ScaleMult` variables can be changed. The **`BufferInUse`** variable allows the user to choose whether to use the buffer bands or frequency bands for the cubes scaling.

### FlashCubes

The script here is used to create a flashing effect on the prefabed cubes based on the audiodata it recieves. The script accesses the **`AudioData`** script to get information about the audio being played, specifically the frequency bands and buffer bands. the cubes transform is mannipulated by the `ScaleMult` and added to the `StartScale` variable. Yet again, if the **`BufferInUse`** bool is active, the cubes will also change color based on the **`BufferBand`** data. The cubes [Material](https://docs.unity3d.com/ScriptReference/Material.html) component of emission color is changed to create the flashing effect of the cubes. However, if BufferInUse is false, the cubes will change color based on **`AudioBand`** data.

### InstantiateCubes

The following script forms a cricle of cubes and scales them based on the audio frequency data recieved from **`AudioData`**. In the Start function, 512 cubes are instantiated using the prefabs of cubes and arranged in a circle by using [`eulerAngles`](https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html) to correct their position and create a full 360 degree circle. In the update funciton, each of the cubes scale is based on the audio data it recieves. The `AudioData.Samples` array contains the amplitude data for every frequency band. This data is then mannipulated by **`MaxScale`** and added to 2 to set the Y scale of the cubes. 


## Parameters

### CubeScript 

- `Band` Holds the frequency in which the cube will be detecting during runtime.
- `StartScale` The original scale of the cubes will be held here.
- `ScaleMult` The multiplier of which the cubes should transform by
- `BufferInUse` active only when the user chooses to  change from using raw AudioData to BufferBands for clear transitions when the cubes transforms.

### FlashCubes

- `Band` Holds the frequency in which the cube will be detecting during runtime.
- `StartScale` The original scale of the cubes will be held here.
- `ScaleMult` The multiplier of which the cubes should transform by
- `BufferInUse` active only when the user chooses to  change from using raw AudioData to BufferBands for clear transitions when the cubes transforms.

### InstantiateCubes

- `SampleCubePrefab` Takes the reference of the gameobject of cubes to mannipulate with.
- `CircleNumber` holds the exact number (-0.703125) to determine the angle between each cube when instantiated in a circular formation.
- `MaxScale` determines the maximum scale of the cubes being transformed

# - the scripts have been commented for a better understanding -





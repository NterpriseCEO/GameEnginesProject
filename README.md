# A Tardis House

Name: Alex Nuzum

Student Number: C19307776

Class Group: TU856

Video:

[![YouTube](https://i9.ytimg.com/vi_webp/_KZZjSHwsgo/mq1.webp?sqp=CMDb3pwG-oaymwEmCMACELQB8quKqQMa8AEB-AH-CYAC0AWKAgwIABABGGUgYSg6MA8=&rs=AOn4CLAu-aWXH847p727bzq3u9Fr26y5LA)](https://www.youtube.com/watch?v=_KZZjSHwsgo)

# Description of the project
A fairly nondescript looking house that is shaped like an old British police box (a tardis). It has a door that leads to a room that is bigger on the inside. This room has a TV, a record player, 2 couches and table. There's a fireplace in the middle and my own album cover art on the walls. The coutches, table, art and fireplace change size based on the music coming from the record player.

The record player itself plays 5 songs, all originals produced by me sometime in the last year. THe song can be changed by clicking on the record player. If you look closely enough, you can see the tonearm and needle moving. The TV also plays a music video created for me over the summer for an album reveal party.

# Instructions for use
WASD and the arrows keys move the player around. The mouse can be used to look around. The gold button on the TV turns the TV on and off. The record player can be clicked on to change the song. The black switch on the back of the record player mutes/unmutes the music.

# How it works
The house is a simple 3d model made in probuilder. It is textured using images genereated in Stable Diffusion. In fact, all the textures (exculding the wall art)/ terrain is generated in stable diffusion (except for the floor). The portal doors have colliders on them that teleport the player inside/outside the house. This was adapted from a Brackey's tutorial on YouTube. The TV has a Video component attached to it that allows video to be played on the CRT. The record player has an Audio component that plays my music. Each piece of furniture has a script that changes its size based on the music. There are also 3 easter eggs to find within the terrain (hint, there's 18,000x18,000m of terrain).
# List of classes/assets in the project

| Class/asset | Source |
|-----------|-----------|
| Bounce.cs | Self written |
| CameraMovevment.cs | Self written |
| ChangeMusic.cs | Self written |
| FurnitureAudioMovement.cs | Self written |
| PauseMusic.cs | Self written |
| PortalCameraMovement.cs | Modified from [here](https://www.youtube.com/watch?v=cuQao3hEKfs) |
| PortalTextureSetup | Modified from [here](https://www.youtube.com/watch?v=cuQao3hEKfs) |
| RotateArm.cs | Self written |
| RotateRecord.cs | Self written |
| Telporter.cs | Self written |
| TVTurnOn.cs | Self written |

# What I am most proud of in the assignment
I am most proud of the record player as it has quite a high level of detail. I am proud of the music as well as I produced it myself. I think the tv, while simple, is cool as well.

# What I learned
Throughout this project, I learnt everything I know about unity. I learnt how to do proper camera movement, how to play video files and hwo to create terrain from heightmaps. I also learnt how to create a flame effect and how to use Git LFS.

# The original proposal
A fairly nondescript looking house that is shaped like an old British police box (a tardis). It will have an openable door that upon opening reveals a room that is bigger on the inside. This room will be a studio appartment.

The appartment will contain futuristic looking funiture with neon glowing couches, a bed and a floating record player. On the beat of the drums the coutches will change colour.

The record player will play a choice of 3 songs, all produced by me sometime in the last year with an option to change the song by clicking on the record player.

Lastly, if possible, there will be a retrofuturistic TV cabinet facing the coutches, playing a video.

## Implementation
I intend to use a shader that will render a scene onto a quad that will be located somewhere else in the 3d world. This will be the inside of the appartment. When a user walks through the door, they are teleported to the location of the previously rendered scene. The furniture will be basic 3d object generated in Blender. Lighting shaders will also be used for neon lighting effects. The couches will respond to audio roughly in the frequency range of the music's drumbeats.

This is code for raycasting to detect if the user clicks on the button. This is one of the most useful things I learnt while working on this project:

```Java
if (Input.GetMouseButtonDown(0)) {
	RaycastHit raycast;
	// Gets the camera by name
	Camera camera = GameObject.Find("AR Camera").GetComponent<Camera>();
	Ray ray = camera.ScreenPointToRay(Input.mousePosition);
	if (Physics.Raycast(ray, out raycast, 100f)) {
		if (raycast.transform != null & raycast.transform.gameObject == gameObject) {
			// Moves the button forwards and backwards once using a coroutine
			coroutine = StartCoroutine(MoveButton());
		}
	}
}
```
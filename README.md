# GameEnginesProject
A fairly nondescript looking house that is shaped like an old British police box (a tardis). It will have an openable door that upon opening reveals a room that is bigger on the inside. This room will be a studio appartment.

The appartment will contain futuristic looking funiture with neon glowing couches, a bed and a floating record player. On the beat of the drums the coutches will change colour.

The record player will play a choice of 3 songs, all produced by me sometime in the last year with an option to change the song by clicking on the record player.

Lastly, if possible, there will be a retrofuturistic TV cabinet facing the coutches, playing a video.

# Implementation

I intend to use a shader that will render a scene onto a quad that will be located somewhere else in the 3d world. This will be the inside of the appartment. When a user walks through the door, they are teleported to the location of the previously rendered scene. The furniture will be basic 3d object generated in Blender. Lighting shaders will also be used for neon lighting effects. The couches will respond to audio roughly in the frequency range of the music's drumbeats.

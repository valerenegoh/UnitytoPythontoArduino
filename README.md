# UnitytoPythontoArduino
Stage 2 of SUTD Capstone 45 Pico Musical Engineering Installation project.<br/>
Refer to the following [link](https://youtu.be/EubplCl5Q8s) for a demo.

The python script receives the song choice from Unity, reads the corresponding text file and sends the notes to play to an Arduino. When it is done, it sends a message back to Unity. All this is done via Serial communication.

The Arduino script requires you to set up an electronic circuit with 25 LEDs/solenoids/etc as shown in the video. Ensure they are wired to the corresponding pin numbers as in the `Arduino` file. An Arduino MEGA was used for this project as it has enough number of pin holes.

Steps:
1. Connect to your Arduino and upload the sketch in `Arduino folder`.
2. Ensure that your Arduino is connected to the right COM Port in `DropZone.cs`.
3. Enter the following in your command line.
`python runrun.py`
4. Open The Unity project & run.

To add new songs to the playlist:
1. Run Part 1 of https://github.com/ValereneGoh/MiditoArduino to convert to midi to interpretable text format files.
2. Add the text file to the folder under Assets > Scripts > txt.
3. Open Unity and manually create a new CD player and holder for the new song via the Prefab folder. I can create a tutorial on YouTube on how to do it if necessary.

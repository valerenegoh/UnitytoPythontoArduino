# UnitytoPythontoArduino
Stage 2 of SUTD Capstone 45 Pico Musical Engineering Installation project.<br/>
Refer to the following [link](https://youtu.be/EubplCl5Q8s) for a demo.

The python script receives the song choice from Unity, reads the corresponding text file and sends the notes to play to an Arduino. When it is done, it sends a message back to Unity. All this is done via Serial communication.

Steps:
1. Connect to your Arduino and upload the sketch in `Arduino folder`.
2. Ensure that your Arduino is connected to the right COM Port in `DropZone.cs`.
3. Enter the following in your command line.
`python runrun.py`
4. Open The Unity project & run.

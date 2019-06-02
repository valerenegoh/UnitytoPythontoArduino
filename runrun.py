import socket
import serial
from time import sleep

dict = {
        "48": '0',  # C
        "50": '1',  # D
        "52": '2',  # E
        "53": '3',  # F
        "55": '4',  # G
        "57": '5',  # A
        "59": '6',  # B
        "60": '7',  # C
        "62": '8',  # D
        "64": '9',  # E
        "65": 'a',  # F
        "67": 'b',  # G
        "69": 'c',  # A
        "71": 'd',  # B
        "72": 'e'   # C
        }

# Enter your COM port in the below line
ard = serial.Serial('com3', 9600)
sleep(2)
print (ard.readline(ard.inWaiting()))

def sending_and_receiving():
    s = socket.socket()
    print('socket created')
    port = 1234
    s.bind(('127.0.0.1', port)) #bind port with ip address
    print('socket binded to port ')
    s.listen(5) #listening for connection
    print('socket listensing ... ')
    while True:
        c, addr = s.accept() #when port connected
        print("\ngot connection from ", addr)
        name = c.recv(1024).decode("utf-8") #Collect data from port and decode into string
        print('Getting Data from the Unity : ', name)


        runSong("txt/%s_GI25.txt" %name)
        text = name +' ended'
        c.sendall(text.encode("utf-8"))#then encode and send that string back to unity
        c.close()

def runSong(fname):
    with open(fname, "r") as f:
        for line in f:
            notes = line.rstrip("\n").rstrip().split()
            print(notes)
            if notes:    # beat contains notes
                for i in range(len(notes)):
                    ard.write(dict[notes[i]])
                    sleep(0.1)
            sleep(0.3)         # tempo of song

sending_and_receiving() #calling the function to run server
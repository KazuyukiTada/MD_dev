cd C:\Program Files\Wireshark
tshark -i 1 -b duration:60 -b files:10 -w C:\share\Capture
pause;
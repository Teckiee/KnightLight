# pip install sacn

import sacn
import time

sender = sacn.sACNsender()  # provide an IP-Address to bind to if you want to send multicast packets from a specific interface
sender.start()  # start the sending thread
sender.activate_output(1)  # start sending out data in the 1st universe
sender[1].multicast = True  # set multicast to True
# sender[1].destination = "192.168.1.20"  # or provide unicast information.
# Keep in mind that if multicast is on, unicast is not used
print("Sending now")
sender[1].priority=100
dmx_data = [0] * 512  # Initialize with all channels at 0 (off)
dmx_data[7] = 255
#sender[1].dmx_data = (255, 255, 255, 255)  # some test DMX data
sender[1].dmx_data = dmx_data
time.sleep(6)  # send the data for 10 seconds
sender.stop()  # do not forget to stop the sender
print("All done")
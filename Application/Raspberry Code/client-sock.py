import asyncio
import json

ip_pc_eco = '10.152.1.165'
ip_pc_digi =  '192.168.43.251'
ip_tel_eco = '10.152.0.67'
ip_tel_digi = ''
# Asynchronous communication with Unity 3D over TCP
async def tcp_echo_client(loop):
    # open connection with Unity 3D
    reader, writer = await asyncio.open_connection(ip_tel_eco,  8080,
                                                   loop=loop)

    message = ''

    with open('data.txt', 'r') as file:
        message = file.read()

#    print('Send: %r' % message)

    # convert JSON to bytes
#    message_json = json.dumps(message).encode()
    encoded = message.encode(encoding='UTF-8',errors='strict')
    
    # send message
    writer.write(encoded)

#    print('Close the socket')
    writer.close()


loop = asyncio.get_event_loop()
while True:
    try:
        loop.run_until_complete(tcp_echo_client(loop))
    except:
        pass
        #print('Reconnecting...')
loop.close()

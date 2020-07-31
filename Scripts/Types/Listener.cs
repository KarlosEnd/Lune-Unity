using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lune {

    public class Listener : MonoBehaviour {
        public virtual void PacketReceive (PacketReceiveEvent packetReceiveEvent) { }
        public virtual void ServerConnect (ServerConnectEvent serverConnectEvent) { }
        public virtual void ServerDisconnect (ServerDisconnectEvent serverDisconnectEvent) { }
    }

}
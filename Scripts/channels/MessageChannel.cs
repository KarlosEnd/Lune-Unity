using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lune {
    public class MessageChannel : Channel {

        public override void Resolve (Packet packet) {
            if (packet.subchannel == "chat") {
                this.HandleChat(packet);
            }
        }

        public void HandleChat (Packet unwrapped) {
            ChatPacket packet = PacketHandler.CastChatPacket(unwrapped);
            Debug.Log("Chat: " + packet.message);
        }
    }
}
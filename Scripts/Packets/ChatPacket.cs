using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class ChatPacket : Packet {
        public string message { get; set; } 

        public ChatPacket (string message) {
            this.message = message;
        }
    }
}
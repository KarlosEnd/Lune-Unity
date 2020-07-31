using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class PacketReceiveEvent : Lune.Event {
        private Packet packet;

        public PacketReceiveEvent (Packet packet) {
            this.packet = packet;
        }

        public Packet GetPacket () {
            return this.packet;
        }

        public string GetChannel () {
            return this.packet.channel;
        }

        public string GetSubchannels () {
            return this.packet.subchannel;
        }
    }
}
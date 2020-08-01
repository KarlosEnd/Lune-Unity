using Newtonsoft.Json;

namespace Lune {
    public class PacketHandler {
        public static Packet ParseFromString (string data) {
            Packet packet = JsonConvert.DeserializeObject<Packet>(data);
            packet.raw = data;

            return packet;
        }

        public static ChatPacket CastChatPacket (Packet packet) {
            return JsonConvert.DeserializeObject<ChatPacket>(packet.raw);
        }
    }
}
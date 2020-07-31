using Newtonsoft.Json;

namespace Lune {
    public class PacketHandler {
        public static Packet ParseFromString (string data) {
            return JsonConvert.DeserializeObject<Packet>(data);
        }
    }
}
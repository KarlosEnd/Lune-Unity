namespace Lune {
    public class PacketParserPipe : Pipeline {
        public override Packet Process(Packet packet) {
            return packet;
        }
    }
}
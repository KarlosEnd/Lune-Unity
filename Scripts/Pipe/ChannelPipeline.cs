using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class ChannelPipeline : Pipeline {

        private Dictionary<string, Channel> channels = new Dictionary<string, Channel>();

        public ChannelPipeline () {
            channels.Add("message", new MessageChannel());
        }

        public override Packet Process(Packet packet) {

            if (channels.ContainsKey(packet.channel)) {
                Channel channel = channels[packet.channel];
                channel.Resolve(packet);
            }

            return packet;
        }
    }
}
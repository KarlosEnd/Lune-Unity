using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class PipelineHandler {
        
        private static List<Pipeline> pipelines = new List<Pipeline>();

        public static void SetInitialsPipelines () {
            AddPipeline(new PacketParserPipe());
        }

        public static void AddPipeline (Pipeline pipeline) {
            pipelines.Add(pipeline);
        }

        public static void RunPipeline (Packet packet) {
            foreach (Pipeline pipeline in pipelines) {
                if (!packet.isCancelled()) {
                    packet = pipeline.Process(packet);
                }
            }
        }

        public static void HandlePacket (Packet packet) {
            if (packet.isCancelled()) {
                return;
            }

            PacketReceiveEvent ev = new PacketReceiveEvent(packet);
            EventHandler.PacketReceive(ev);
        }
    }
}
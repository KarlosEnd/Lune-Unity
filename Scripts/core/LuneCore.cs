namespace Lune {
    public class LuneCore {
        public static void Init () {
            Lune.NetworkManager.Init();
            PipelineHandler.AddPipeline(new ChannelPipeline());
        }
    }
}
namespace Lune {
    public class NetworkManager {

        private static TCPClient client;

        public static void Init () {
            client = new TCPClient();
        }

        public static void Connect (string ip, int port) {
            client.Connect(ip, port);
        }

        public static void Send (string data) {
            client.Send(data);
        }

    }
}
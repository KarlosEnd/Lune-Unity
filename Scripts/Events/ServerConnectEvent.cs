using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class ServerConnectEvent : Lune.Event {
        private string address;
        private int port;

        public ServerConnectEvent (string address, int port) {
            this.address = address;
            this.port = port;
        }

        public string GetAddress () {
            return this.address;
        }

        public int GetPort () {
            return this.port;
        }
    }
}
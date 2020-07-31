using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class ServerDisconnectEvent : Lune.Event {
        private string address;
        private int port;
        private string reason;

        public ServerDisconnectEvent (string address, int port, string reason) {
            this.address = address;
            this.port = port;
            this.reason = reason;
        }

        public string GetReason () {
            return this.reason;
        }

        public string GetAddress () {
            return this.address;
        }

        public int GetPort () {
            return this.port;
        }
    }
}
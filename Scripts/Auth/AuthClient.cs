using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lune {
    public class AuthClient {
        
        private TCPClient client;

        public AuthClient (string address, int port) {
            client = new TCPClient();
            client.Connect(address, port);
        }
    }
}
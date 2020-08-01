using System.Collections;
using System.Collections.Generic;

namespace Lune {
    public class EventHandler {
        private static List<Listener> listeners = new List<Listener>();

        public static void RegisterEvents (Listener listener) {
            listeners.Add(listener);
        }

        public static void PacketReceive (PacketReceiveEvent packetReceiveEvent) {
            foreach (Listener listener in listeners) {
                listener.PacketReceive(packetReceiveEvent);
            }
        }

        public static void ServerConnect (ServerConnectEvent serverConnectEvent) {
            foreach (Listener listener in listeners) {
                listener.ServerConnect(serverConnectEvent);
            }
        }

        public static void ServerDisconnect (ServerDisconnectEvent serverDisconnectEvent) {
            foreach (Listener listener in listeners) {
                listener.ServerDisconnect(serverDisconnectEvent);
            }
        }

        public static void AccountLogin (AccountLoginEvent accountLoginEvent) {
            foreach (Listener listener in listeners) {
                listener.AccountLogin(accountLoginEvent);
            }
        }

        public static void AccountLoginFailed (AccountLoginFailedEvent accountLoginFailedEvent) {
            foreach (Listener listener in listeners) {
                listener.AccountLoginFailed(accountLoginFailedEvent);
            }
        }
    }
}
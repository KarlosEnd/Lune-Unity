using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Lune {
    public class TCPClient {
        private TcpClient socket; 
        private Thread clientThread;
        private string currentAddress = "";
        private int currentPort = 8052;

        // Public methods
        public void Connect (string address, int port) {
            this.currentAddress = address;
            this.currentPort = port;

            try {
                clientThread = new Thread (new ThreadStart(ListenForData)); 			
                clientThread.IsBackground = true; 			
                clientThread.Start();
		    } catch (Exception e) { 			
			    HandleDisconnect(e.Message); 		
		    } 
        }

        public void Send (string data) {         
		    if (socket == null) {             
			    return;         
		    } 

		    try { 						
			    NetworkStream stream = socket.GetStream(); 			
			    if (stream.CanWrite) {                 	                
				    byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(data); 				                
				    stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);                             
			    }         
		    } catch (Exception e) {             
			    HandleDisconnect(e.Message);        
		    }     
	    }

        public string GetAddress () {
            return this.currentAddress;
        }

        public int GetPort () {
            return this.currentPort;
        }

        // Private utils
        private void ListenForData () {
            try { 			
			    socket = new TcpClient(this.currentAddress, this.currentPort);  			
			    Byte[] bytes = new Byte[1024];     
                this.HandleConnect();   

			    while (true) { 								
				    using (NetworkStream stream = socket.GetStream()) { 					
					    int length; 

					    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) { 						
						    var incommingData = new byte[length]; 						
						    Array.Copy(bytes, 0, incommingData, 0, length); 						
						
						    string serverMessage = Encoding.ASCII.GetString(incommingData); 
                            this.HandleResponse(serverMessage);											
					    } 				
				    } 			
			    }         
		    } catch (Exception e) {     
                HandleDisconnect(e.Message);
			    // Debug.Log("Socket exception: " + socketException);         
		    }
        }

        private void HandleConnect () {
            ServerConnectEvent ev = new ServerConnectEvent(this.currentAddress, this.currentPort);
            EventHandler.ServerConnect(ev);
        }

        private void HandleDisconnect (string reason) {
            ServerDisconnectEvent ev = new ServerDisconnectEvent(this.currentAddress, this.currentPort, reason);
            EventHandler.ServerDisconnect(ev);
        }

        private void HandleResponse (string data) {
            Packet packet = PacketHandler.ParseFromString(data);
            PacketReceiveEvent ev = new PacketReceiveEvent(packet);
            PipelineHandler.HandlePacket(packet);
        }
    }
}
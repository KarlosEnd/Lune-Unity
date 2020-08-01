using System.Collections;
using System.Collections.Generic;

namespace Lune {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Packet    {

        // Deserializable fields
        public string channel { get; set; } 
        public string subchannel { get; set; } 
        public string raw { get; set; } 

        // Class fields
        private bool cancelled = false;

        public bool isCancelled () {
            return this.cancelled;
        }

        public void Cancel () {
            this.cancelled = true;
        }
    }
}
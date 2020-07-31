using System.Collections;
using System.Collections.Generic;

namespace Lune {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Packet    {

        // Deserializable fields
        public string channel { get; set; } 
        public string subchannel { get; set; } 
        public List<object> strings { get; set; } 
        public List<object> ints { get; set; } 
        public List<object> bools { get; set; } 
        public List<object> vector3 { get; set; } 
        public List<object> vector2 { get; set; } 

        // Class fields
        private bool cancelled;

        public bool isCancelled () {
            return this.cancelled;
        }

        public void Cancel () {
            this.cancelled = true;
        }
    }
}
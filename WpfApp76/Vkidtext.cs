using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WpfApp76
{
    [DataContract]
    class Vkidtext
    {
        [DataMember]
        public string id;
        [DataMember]
        public string text;
    }
}

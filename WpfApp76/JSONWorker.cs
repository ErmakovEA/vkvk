using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WpfApp76
{
    class JSONWorker
    {
        public static void setDataInJson(List<Vkidtext> vk)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Vkidtext>));
            using (FileStream fileStream = new FileStream("Vkidtext.json", FileMode.Create))
            {
                dataContractJsonSerializer.WriteObject(fileStream, vk);
            }
        }
        public static List<Vkidtext> Getvk()
        {
            if (!File.Exists("Vkidtext.json"))
                return new List<Vkidtext>();
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Vkidtext>));
            using (FileStream fileStream = new FileStream("Vkidtext.json", FileMode.Open))
            {
                return (List<Vkidtext>) dataContractJsonSerializer.ReadObject(fileStream);
            }

        }
        public static void setDataInJson1(List<Vkphoto> vk2)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Vkphoto>));
            using (FileStream fileStream = new FileStream("Vkphoto.json", FileMode.Create))
            {
                dataContractJsonSerializer.WriteObject(fileStream, vk2);
            }
        }
        public static List<Vkphoto> Getvk1()
        {
            if (!File.Exists("Vkphoto.json"))
                return new List<Vkphoto>();
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Vkphoto>));
            using (FileStream fileStream = new FileStream("Vkphoto.json", FileMode.Open))
            {
                return (List<Vkphoto>)dataContractJsonSerializer.ReadObject(fileStream);
            }

        }
        public static void setDataInJson2(List<Vksilka> vk3)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Vksilka>));
            using (FileStream fileStream = new FileStream("Vksilka.json", FileMode.Create))
            {
                dataContractJsonSerializer.WriteObject(fileStream, vk3);
            }
        }
        public static List<Vksilka> Getvk2()
        {
            if (!File.Exists("Vksilka.json"))
                return new List<Vksilka>();
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Vkidtext>));
            using (FileStream fileStream = new FileStream("Vkidtext.json", FileMode.Open))
            {
                return (List<Vksilka>)dataContractJsonSerializer.ReadObject(fileStream);
            }

        }
    }
}

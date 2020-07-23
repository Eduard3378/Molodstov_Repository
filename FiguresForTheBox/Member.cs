using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Xml.Serialization;

namespace FiguresForTheBox
{
    [XmlRoot("member")]
    public class Member
    {
        [XmlAttribute("figure")]
        public int FIGURE { get; set; }

        [XmlElement("side")]
        public string Side { get; set; }

        [XmlElement("side1")]
        public string Side1 { get; set; }
        public Member() { }

        public Member(string xml)
        {
            LoadXml(xml);
        }

        public void LoadXml(string source)
        {
            XmlSerializer mySerializer = new XmlSerializer(this.GetType());

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(source)))
            {
                object obj = mySerializer.Deserialize(ms);

                foreach (PropertyInfo p in obj.GetType().GetProperties())
                {
                    PropertyInfo p2 = this.GetType().GetProperty(p.Name);
                    if (p2 != null && p2.CanWrite)
                    {
                        p2.SetValue(this, p.GetValue(obj, null), null);
                    }
                }
            }
        }
    }
}

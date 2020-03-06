using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    class PokemonWriter
    {
        XmlSerializer serializer;

        /// <summary>
        /// Construtor
        /// </summary>
        public PokemonWriter()
        {
            serializer = new XmlSerializer(typeof(Pokedex));
        }


        public bool Save(string path,  Pokedex pokedex)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pokedex));
                    xmlSerializer.Serialize(fs, pokedex);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("Pokedex")]
    public class Pokedex
    {
        [XmlArray("Pokemons")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemons { get; set; }

        public Pokedex()
        {
            Pokemons = new List<Pokemon>();
        }

        Pokemon GetPokemonByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemonByName(string name)
        {
            foreach (var item in Pokemons)
            {
                if(item.Name == name)
                {
                    return item;
                }
	        }
            return null;
        }

        List<Pokemon> GetPokemonsOfType(string type)
        {
            // Note to check both Type1 and Type2
            throw new NotImplementedException();
        }

        Pokemon GetHighestHPPokemon()
        {
            throw new NotImplementedException();
        }

        Pokemon GetHighestAttackPokemon()
        {
            throw new NotImplementedException();
        }

        Pokemon GetHighestDefensePokemon()
        {
            throw new NotImplementedException();
        }

        Pokemon GetHighestMaxCPPokemon()
        {
            throw new NotImplementedException();
        }

    }
}

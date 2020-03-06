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

        public Pokemon GetPokemonByIndex(int index)
        {
            foreach (var item in Pokemons)
            {
                if(item.Index == index)
                {
                    return item;
                }
	        }
            return null;
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

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            // Note to check both Type1 and Type2
            List<Pokemon> newList = new List<Pokemon>();
            foreach (var item in Pokemons)
            {
                if(item.Type1 == type || item.Type2 == type)
                {
                    newList.Add(item);
                }
	        }
            return newList;
        }

        public Pokemon GetHighestHPPokemon()
        {
            Pokemon highestHP = new Pokemon();
            foreach(var item in Pokemons)
            {
                if(highestHP.HP < item.HP)
                {
                    highestHP = item;
                }
            }
            return highestHP;
        }

        public Pokemon GetHighestAttackPokemon()
        {
            Pokemon highestAttack = new Pokemon();
            foreach (var item in Pokemons)
            {
                if (highestAttack.Attack < item.Attack)
                {
                    highestAttack = item;
                }
            }
            return highestAttack;
        }

        public Pokemon GetHighestDefensePokemon()
        {
            Pokemon highestDefense = new Pokemon();
            foreach (var item in Pokemons)
            {
                if (highestDefense.Defense < item.Defense)
                {
                    highestDefense = item;
                }
            }
            return highestDefense;
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            Pokemon highestMaxCP = new Pokemon();
            foreach (var item in Pokemons)
            {
                if (highestMaxCP.MaxCP < item.MaxCP)
                {
                    highestMaxCP = item;
                }
            }
            return highestMaxCP;
        }

    }
}

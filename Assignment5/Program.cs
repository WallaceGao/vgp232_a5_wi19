﻿using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.Load("pokemon151.xml");

            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }

            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.
            PokemonBag pokemonBag = new PokemonBag();
            int bulbasaurIndex = pokedex.GetPokemonByName("Bulbasaur").Index;
            int charizardIndex = pokedex.GetPokemonByName("Charizard").Index;
            int mewIndex = pokedex.GetPokemonByName("Mew").Index;
            int dragoniteIndex = pokedex.GetPokemonByName("Dragonite").Index;
            pokemonBag.Pokemons.Add(bulbasaurIndex);
            pokemonBag.Pokemons.Add(bulbasaurIndex);
            pokemonBag.Pokemons.Add(charizardIndex);
            pokemonBag.Pokemons.Add(mewIndex);
            pokemonBag.Pokemons.Add(dragoniteIndex);

            pokemonBag.Save("pokebag.xml");
            pokemonBag.Pokemons.Clear();
            pokemonBag.Load("pokebag.xml");

            foreach(var item in pokemonBag.Pokemons)
            {
                Console.WriteLine(item);
            }

            // TODO: Add item reader and print out all the items


            // TODO: hook up item data to display with the inventory

            var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            // TODO: move this into a inventory with a serialize and deserialize function.
            string inventoryFile = "inventory.xml";
            using (var writer = XmlWriter.Create(inventoryFile))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, source);

            using (var sreader = new StreamReader(inventoryFile))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    Inventory inventory = serializer.Deserialize(sreader) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Console.WriteLine("Item: {0} Quantity: {1}", item.Key, item.Value);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}", 
                        inventoryFile, ex.Message);
                }

            }


            Console.ReadKey();
        }
    }
}

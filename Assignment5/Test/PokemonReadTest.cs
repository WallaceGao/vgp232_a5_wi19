using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment5.Data;

namespace Assignment5.Test
{
    public class PokemonReadTest
    {
        const string TEST_DATA_OUTPUT_FILE = "output.csv";
        const string TEST_DATA_INPUT_FILE = "pokemon151.xml";

        const string TEST_POKEMONBAG_OUTPUT_FILE = "pokemonBag.xml";

        string testOutputFile = "";
        string testbagOutputFile = "";
        string testInputFile = "";


        Pokedex pokemons = new Pokedex();
        PokemonReader pokemonReader = new PokemonReader();
        PokemonWriter pokemonWriter = new PokemonWriter();
        PokemonBag pokemonBag = new PokemonBag();

        [SetUp]
        public void Setup()
        {
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            string appDir = AppContext.BaseDirectory;
            testOutputFile = Path.Combine(appDir, TEST_DATA_OUTPUT_FILE);
            testInputFile = Path.Combine(appDir, TEST_DATA_INPUT_FILE);
            testbagOutputFile = Path.Combine(appDir, TEST_POKEMONBAG_OUTPUT_FILE);
        }

        [Test]
        public void LoadTest()
        {
            try
            {
                pokemons = pokemonReader.Load(testInputFile);
            }
            catch
            {
                Assert.IsFalse(true);
            }
        }

        [Test]
        public void SaveTest()
        {
            try
            {
                LoadTest();
                pokemonWriter.Save(testOutputFile,pokemons);
            }
            catch
            {
                Assert.IsFalse(true);
            }
            FileAssert.Exists(testOutputFile);
        }

        [Test]
        public void SavePokebagTest()
        {
            try
            {
                int bulbasaurIndex = pokemons.GetPokemonByName("Bulbasaur").Index;
                int charizardIndex = pokemons.GetPokemonByName("Charizard").Index;
                int mewIndex = pokemons.GetPokemonByName("Mew").Index;
                int dragoniteIndex = pokemons.GetPokemonByName("Dragonite").Index;
                pokemonBag.Pokemons.Add(bulbasaurIndex);
                pokemonBag.Pokemons.Add(bulbasaurIndex);
                pokemonBag.Pokemons.Add(charizardIndex);
                pokemonBag.Pokemons.Add(mewIndex);
                pokemonBag.Pokemons.Add(dragoniteIndex);

                pokemonBag.Save(testbagOutputFile);
            }
            catch
            {
                Assert.IsFalse(true);
            }
            FileAssert.Exists(testbagOutputFile);

        }

        [Test]
        public void LoadPokebagTest()
        {
            try
            {
                pokemonBag.Load(testbagOutputFile);
            }
            catch
            {
                Assert.IsFalse(true);
            }

        }
    }
}

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
    public class ItemTest
    {
        const string TEST_DATA_OUTPUT_FILE = "output.csv";
        const string TEST_DATA_INPUT_FILE = "pokemon151.xml";

        const string TEST_POKEMONBAG_OUTPUT_FILE = "pokemonBag.xml";

        string testOutputFile = "";
        string testbagOutputFile = "";
        string testInputFile = "";


        Pokedex pokemons = new Pokedex();
        PokemonReader pokemonReader = new PokemonReader();

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

        [TestCase(300)]
        public void GetHighestAttackTest(int testAttack)
        {
            LoadTest();
            Pokemon pokemon = pokemons.GetHighestAttackPokemon();
            Assert.AreEqual(pokemon.Attack, testAttack);
        }

        [TestCase(256)]
        public void GetHighestDefenceTest(int testAttack)
        {
            LoadTest();
            Pokemon pokemon = pokemons.GetHighestDefensePokemon();
            Assert.AreEqual(pokemon.Defense, testAttack);
        }

        [TestCase(487)]
        public void GetHighestHPTest(int testAttack)
        {
            LoadTest();
            Pokemon pokemon = pokemons.GetHighestHPPokemon();
            Assert.AreEqual(pokemon.HP, testAttack);
        }

        [TestCase(4178)]
        public void GetHighestMaxCPTest(int testAttack)
        {
            LoadTest();
            Pokemon pokemon = pokemons.GetHighestMaxCPPokemon();
            Assert.AreEqual(pokemon.MaxCP, testAttack);
        }
    }
}

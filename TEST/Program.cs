using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST.Models;

namespace TEST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Instatiate the models so that we can write to them from the console.
            PokemonModel pokemonModel = new();
            Trainer trainer = new Trainer();
            int chosenPokemon = 0;


            //CreateHostBuilder(args).Build().Run();
            XMLAPI2 xMLAPI2 = new XMLAPI2();
            xMLAPI2.makePokemonFile();
            Console.WriteLine("Choose the name of your Trainer.");
            Console.WriteLine("Trainer: ");
            //With each ReadLine, we are setting the object property to what ever the 
            //user inputs. Once the user is done going through the prompts the object
            //is then passed as a parameter to the method so the properties of the 
            //object can be used 
            trainer.Name = Console.ReadLine();
            Console.WriteLine("How old is your is your trainer?");
            Console.WriteLine("Age: ");
            trainer.Age = int.Parse(Console.ReadLine());
            Console.WriteLine($"Awesome! Trainer {trainer.Name}, age {trainer.Age}.");
            Console.WriteLine("Let's pick a Pokemon!");
            Console.WriteLine("Here are your starters to choose from:");
            Console.WriteLine("1) Eevee, Normal");
            Console.WriteLine("2) Pikachu, Electric");
            Console.WriteLine("3) Psyduck, Water");
            //This do while loop allows to keep reading the user input until an appropriate
            //key is pressed {i.e. 1, 2, or 3}
            do
            {
                Console.WriteLine("Which do you choose are your companion?");
                chosenPokemon = int.Parse(Console.ReadLine());
                if (chosenPokemon == 1)
                {
                    pokemonModel.Name = "Eevee";
                    pokemonModel.Type = "Normal";
                    Console.WriteLine($"You chose {pokemonModel.Name}! Great choice!");
                    break;
                }
                else if (chosenPokemon == 2)
                {
                    pokemonModel.Name = "Pikachu";
                    pokemonModel.Type = "Electric";
                    Console.WriteLine($"You chose {pokemonModel.Name}! Awesome starter!");
                    break;
                }
                else if (chosenPokemon == 3)
                {
                    pokemonModel.Name = "Psyduck";
                    pokemonModel.Type = "Water";
                    Console.WriteLine($"You chose {pokemonModel.Name}! One of the best!");
                    break;
                }
            } while (chosenPokemon != 1 || chosenPokemon != 2 || chosenPokemon != 3);


            //Here we pass both objects that have been filled out by the user. 
            //Putting a breaking point at this line and then hovering over the objects 
            //will show you the properties that have been passed into the objects
            //as well as how they go into the method itself.
            xMLAPI2.postPokemon(pokemonModel, trainer);




            //XMLAPI xMLAPI = new XMLAPI();
            //xMLAPI.postPokemon();
            //xMLAPI.getPokemon();
            //xMLAPI.updatePokemon();
            //xMLAPI.deletePokemon();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}

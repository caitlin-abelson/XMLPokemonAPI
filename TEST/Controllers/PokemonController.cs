using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        //private static readonly string[] Type = new[]
        //{
        //    "Fire", "Grass", "Bug", "Water", "Electric", "Flying", "Dragon", "Psychic", "Ground"
        //};

        //private static readonly string[] Name = new[]
        //{
        //    "Pikachu", "Eevee", "Meowth", "Piplup", "Empoleon", "Cubone", "Caterpie", "Roselia", "Turtwig"
        //};

        //[HttpGet]
        //public IEnumerable<Pokemon> Get()
        //{
        //    var random = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new Pokemon
        //    {
        //        Name = Name[random.Next(Name.Length)],
        //        Type = Type[random.Next(Type.Length)],
        //        HP = random.Next(20, 200),
        //        Generation = random.Next(1, 8)
        //    })
        //    .ToArray();
        //}



    }
}

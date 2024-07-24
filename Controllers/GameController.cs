using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CardGameBackend.Models;
using System.Linq;

namespace CardGameBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> Games = new List<Game>();

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return Games;
        }

        [HttpPost]
        public Game Post([FromBody] Game game)
        {
            game.Id = Games.Count + 1;

            Games.Add(game);
            return game;
        }

        [HttpPut]
        public Game Put([FromBody] Game game)
        {
            Game existingGame = Games.Where(g => g.Id == game.Id).FirstOrDefault();
            existingGame.Points = game.Points;

            return game;
        }
    }
}
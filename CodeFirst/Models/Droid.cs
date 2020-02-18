using System.Collections.Generic;

namespace StarWars.Models
{
    /// <summary>
    /// A droid in the Star Wars universe.
    /// </summary>
    public class Droid
       : ICharacter
    {
        public string Id { get; set; }
    }
}

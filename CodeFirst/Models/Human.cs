using System.Collections.Generic;

namespace StarWars.Models
{
    /// <summary>
    /// A human character in the Star Wars universe.
    /// </summary>
    public class Human
        : ICharacter
    {
        public string Id { get; set; }       
    }
}

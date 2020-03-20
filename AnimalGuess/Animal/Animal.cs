using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GuessingGameRepository
{
    public class Animal
    {
        public string Location { get; set; }
        public string SkinType { get; set; }
        public string TravelType { get; set; }
        public string Hint { get; set; }
        public string Name { get; set; }
        public Animal(string location, string skinType, string travelType, string hint, string name)
        {
            Location = location;
            SkinType = skinType;
            TravelType = travelType;
            Hint = hint;
            Name = name;
        }
        public Animal() { }
    }
}
/* Animal List
 * Tiger
 * Giraffe
 * Gorilla
 * Eagle
 * Chicken
 * Zebra
 * Whale
 * Cow
 * Snake
 * Rat
 * Lizard
 * Turtle
 */

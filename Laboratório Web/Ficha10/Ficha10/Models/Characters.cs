namespace Ficha10.Models
{
    public class Characters : ICharacters
    {
        public Characters()
        {
            List<Character> CharactersList = new List<Character>();
        }   


        public List<Character> CharactersList { get; set; }
    }
}

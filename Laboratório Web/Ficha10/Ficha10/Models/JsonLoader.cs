using System.Text.Json;

namespace Ficha10.Models
{
    public class JsonLoader
    {
        public static Employees LoadEmployeesJson()
        {
            string text = File.ReadAllText("./JsonFiles/employees.json");
            Employees emp = JsonSerializer.Deserialize<Employees>(text);
            return emp;
        }


        public static Characters LoadCharactersJson()
        {
            string text = File.ReadAllText("./JsonFiles/characters.json");
            Characters characters = JsonSerializer.Deserialize<Characters>(text);
            return characters;
        }

        Characters characters = LoadCharactersJson();
    }
}

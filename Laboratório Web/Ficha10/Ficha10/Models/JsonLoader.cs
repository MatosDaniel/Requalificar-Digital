using System.Text.Json;

namespace Ficha10.Models
{
    public class JsonLoader
    {
        public static List<Employee>? LoadEmployeesJson()
        {
            string text = System.IO.File.ReadAllText("./JsonFiles/employees.json");
            return JsonSerializer.Deserialize<List<Employee>>(text);
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

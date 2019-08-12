using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnit.Util
{
    public static class GanerateTest
    {
        public static string NumberPhone()
        {
            Random telefoneGenerate = new Random(98989876);
            return telefoneGenerate.Next().ToString();
        }

        public static string Email()
        {
            Random random = new Random();
            const string chars = "abcdefghiglmnopqrstuvxz";
            return new string(Enumerable.Repeat(chars, 7).Select(s => s[random.Next(s.Length)]).ToArray()) + "@teste.com.br"; ;
        }

        public static string GenerateName()
        {
            Random r = new Random();
            string[] consonants = { "Maria", "Carlos", "Eduardo", "Daniele", "Afonso", "Miguel", "Thais", "Edvania", "Alcenor", "Renata", "Sandro" };
            string[] vowels = { "Brito", "Silva", "João", "Marcela", "Edilza", "Sara", "Rafaela" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)];
            int b = 1;
            while (b < 0)
            {
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
    }
}

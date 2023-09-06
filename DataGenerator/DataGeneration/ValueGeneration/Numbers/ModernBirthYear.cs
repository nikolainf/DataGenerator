using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataGeneration.ValueGeneration.Numers;
internal class ModernBirthYearGenerator
{
    public async Task<string[]> Generate(int count)
    {
        Random random = new();
        var currentYear = DateTime.Today.Year;

        string[] years = new string[count];

        for(int i = 0; i < count; i++) 
        {
            years[i] = (currentYear - random.Next(0, 100)).ToString();
        }

        return years;

    }
}

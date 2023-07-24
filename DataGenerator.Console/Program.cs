
using DataGenerator.DataStore;

//string[] maleLastNames = { "Федоров", "Анискин", "Пендеров", "Петухов", "Олухов", "Кипелов", "Кинчев", "Горшенев", "Летов", "Холстини", "Гоголь" };

//DataItemJsonFileContext context = new(DataItemName.FemaleLastNames);
//await context.AddNew(maleLastNames);

var result = await DataGenerator.Data.Generate("3 firstname lastname birthdate year pet");


Console.WriteLine(result);

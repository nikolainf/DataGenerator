// See https://aka.ms/new-console-template for more information

using DataGenerator.FillData;
using Newtonsoft.Json;

string[] firstNames = new string[]
{
    "Николай",
    "Дмитрий",
    "Василий",
    "Петр",
    "Иван",
    "Андрей",
    "Евгений",
    "Денис",
    "Анатолий",
    "Николай"
};



FirstNamesJsonFileContext context = new(DataItemName.MaleFirstNames);
var success = await context.AddNew(firstNames);
Console.WriteLine(success); 

namespace DataGenerator.RequestParsing;
public class RequestParser
{
	private readonly string _input;

	public RequestParser(string input) =>
		_input = input;

	public ParsingResult? Parse()
	{
		var units = _input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

		List<RequestProperty> propList = new(units.Length);

		var firstUnit = units.FirstOrDefault();
		

		if(firstUnit == null)
		{
			return null;
		}

		bool isFirstUnitItemsCount = int.TryParse(firstUnit, out var itemsCount);
		
		if(isFirstUnitItemsCount)
		{
			units = units.Skip(1).ToArray();
		}
		else
		{
			var lastUnit = units.LastOrDefault();

			bool isLastUnitItemsCount = int.TryParse(lastUnit, out itemsCount);

			if (!isLastUnitItemsCount)
			{
				itemsCount = 100;
			}
			else
			{
				units = units.SkipLast(1).ToArray();
			}
		}

	
		foreach(var wordUnit in units)
		{
			propList.Add(new RequestProperty(wordUnit, RequestPropertyType.String));
		}

		ParsingResult result = new();
		result.Properties = propList;
		result.ItemsCount = itemsCount;

		return result;
	}
}

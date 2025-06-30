```C#
public static (Container Container, string Error) Create(Guid id, string name, DateOnly dateOfCreation)
{
	var error = string.Empty;
	//валидация
	if()
	{
		error = ''
	}

	var container = new Container(Guid id, string name, DateOnly dateOfCreation);

	return (container, error);
}
```
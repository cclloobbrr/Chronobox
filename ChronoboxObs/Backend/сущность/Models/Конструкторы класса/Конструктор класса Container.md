```C#
private Container(Guid id, string name, DateOnly dateOfCreating)
{
	Id = id;
	Name = name;
	DateOfCreating = dateOfCreating;
}
...
```

  Конструктор класса делаем приватным, чтобы не менять свойства из вне.

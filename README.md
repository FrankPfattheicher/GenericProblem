# GenericProblem

## Vorgaben
Es gibt folgende Datenklassen (Data.cs)

```csharp
abstract class DataBase    
class DataA : DataBase    
class DataB : DataBase    
class DataC : DataBase    
```

Ein Interface für Handler, die diese Datentypen verarbeiten können (Handler.cs)

```csharp
public interface IHandler<in T> where T : DataBase
```

Und folgende Handler, die den entsprechenden Datentyp bearbeiten können (Handler.cs)

```csharp
public class HandlerForA : IHandler<DataA>    
public class HandlerForB : IHandler<DataB>    
public class HandlerForC : IHandler<DataC>    
```

## Gewünschtes Verhalten
Die Daten werden als konkreter Typ übergeben.

```csharp
public void HandleSomething(DataBase data)    
{    
    // Bestimmung des Handlers für den konkreten Datentyp.    
    var handler = _repo.GetHandlerForType_3(data);    
    Assert.IsNotNull(handler);    
    // Aufruf des Handlers ohne Cast zu einem zu diesem    
    // Zeitpunkt nicht bekannten konkreten Typs    
    handler.DoSomething(data);    
}    
```


## Handler Repository
Und letzendlich ein Repository als DI container, das die Handler liefern soll (Repository.cs)

```csharp
public void Register<T>(object instance)
```

mit zwei Versuchen den Handler als konkreten Typ zurück zu liefern

```csharp
public IHandler<DataBase> GetHandlerForType_1(DataBase data)    
public IHandler<T> GetHandlerForType_2<T>(T data) where T : DataBase
```

Beide hab ich nicht zum laufen bekommen

Was funktioniert ist den Handler als dynamic zurückzugeben - es soll aber eine Implementierung OHNE dynamic gefunden werden

```csharp
public dynamic GetHandlerForType_3<T>(T data) where T : DataBase
```


Happy coding
Gruß Frank

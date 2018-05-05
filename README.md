# GenericProblem

Es gibt folgende Datenklassen (Data.cs)

DataBase
DataA : DataBase
DataB : DataBase
DataC : DataBase

Ein Interface für Handler, die diese Datentypen verarbeiten können (Handler.cs)

public interface IHandler<in T> where T : DataBase

Und folgende Handler, die den entsprechenden Datentyp bearbeiten können (Handler.cs)

public class HandlerForA : IHandler<DataA>
public class HandlerForB : IHandler<DataB>
public class HandlerForC : IHandler<DataC>


Und letzendlich ein Repository als DI container, das die Handler liefern soll (Repository.cs)

public void Register<T>(object instance)

mit zwei Versuchen den Handler als konkreten Typ zurück zu liefern

public IHandler<DataBase> GetHandlerForType_1(DataBase data)
public IHandler<T> GetHandlerForType_2<T>(T data) where T : DataBase

Beide hab ich nicht zum laufen bekommen

Was funktioniert ist den Handler als dynamic zurückzugeben - es soll aber eine Implementierung OHNE dynamic gefunden werden

public dynamic GetHandlerForType_3<T>(T data) where T : DataBase



Happy coding
Gruß Frank

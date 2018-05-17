using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandlerRepository
{
    [TestClass]
    public class UnitTests
    {
        private Repository _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Repository();
            _repo.Register<IHandler<DataA>>(new HandlerForA());
            _repo.Register<IHandler<DataB>>(new HandlerForB());
            _repo.Register<IHandler<DataC>>(new HandlerForC());
        }

        // Versuch 1
        [TestMethod]
        public void GetHandler1_ForConcreteType()
        {
            var data = new DataB();
            var handler = _repo.GetHandlerForType_1(data);
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public void GetHandler1_ForDerivedType()
        {
            var data = new DataB() as DataBase;
            var handler = _repo.GetHandlerForType_1(data);
            Assert.IsNotNull(handler);
        }

        // Versuch 2
        [TestMethod]
        public void GetHandler2_ForConcreteType()   // DAS funktioniert
        {
            var data = new DataB();
            var handler = _repo.GetHandlerForType_2(data);
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public void GetHandler2_ForDerivedType()
        {
            var data = new DataB() as DataBase;
            IHandler<DataBase> handler = _repo.GetHandlerForType_2<DataBase>(data);
            Assert.IsNotNull(handler);
        }

        // Versuch 3
        [TestMethod]
        public void GetHandler3_ForConcreteType()   // DAS funktioniert
        {
            var data = new DataB();
            var handler = _repo.GetHandlerForType_3(data);
            Assert.IsNotNull((object)handler);
        }

        [TestMethod]
        public void GetHandler3_ForDerivedType()   // DAS funktioniert
        {
            var data = new DataB() as DataBase;
            dynamic handler = _repo.GetHandlerForType_3(data);
            Assert.IsNotNull((object)handler);
        }

        // Versuch 4
        [TestMethod]
        public void GetHandler4_ForConcreteType()
        {
            var data = new DataB();
            object handler = _repo.GetHandlerForType_4(data);
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public void GetHandler4_ForDerivedType()
        {
            var data = new DataB() as DataBase;
            object handler = _repo.GetHandlerForType_4(data);
            Assert.IsNotNull(handler);
        }

        // Versuch 5
        [TestMethod]
        public void GetHandler5_ForConcreteType()
        {
            var data = new DataB();
            IHandler<DataB> handler = _repo.GetHandlerForType_5<IHandler<DataB>, DataB>(data);
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public void GetHandler5_ForDerivedType()
        {
            var data = new DataB() as DataBase;


            /**
             * hier wird der Rückgabewert explizit angegeben.
             * Da ein IHandler'DataB nicht in ein IHandler'DataBase umgewandelt werden kann, (Kontravarianz)
             * kann die Methode kein Objekt vom Typ IHandler'DataBase zurückgeben.
             *
             * Der Rückgabewert liegt im GetHandler2 implizit vor.
             * var data = new DataB() as DataBase;
             * var handler = _repo.GetHandlerForType_2(data);
             *
             * ist gleichbedeutend zu
             * var data = new DataB() as DataBase;
             * IHandler<DataBase> handler = _repo.GetHandlerForType_2<DataBase>(data);
             * Die Methode muss also ein IHandler<DataBase> zurück geben, was nicht möglich ist,
             * da ein IHandler<DataB> konkreter ist als IHandler<DataBase> aber die Implementierung den konkreten Typ
             * DataB benötigt. Ansonsten könnte man die DoSomething()-Signatur auch in DoSomething(DataBase db) ändern.
             * 
             *
             * Als Eingabeparameter ist ein DataBase erlaubt.
             */
            IHandler<DataB> handler = _repo.GetHandlerForType_5<IHandler<DataB>, DataB>(data);


            Assert.IsNotNull(handler);
        }
    }
}

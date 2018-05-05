﻿using System;
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
            var handler = _repo.GetHandlerForType_2(data);
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
            var handler = _repo.GetHandlerForType_3(data);
            Assert.IsNotNull((object)handler);
        }



    }
}

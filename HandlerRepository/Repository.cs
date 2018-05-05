using System;
using System.Collections.Generic;
using System.Linq;

namespace HandlerRepository
{
    public class Repository
    {
        private readonly Dictionary<Type, object> _repo = new Dictionary<Type, object>();

        public void Register<T>(object instance)
        {
            _repo.Add(typeof(T), instance);
        }

        /// <summary>
        /// Versuch 1 - Handler immer über den Basis-Datentyp holen
        /// </summary>
        /// <param name="data">Datentyp den der Handler verarbeiten können soll</param>
        /// <returns></returns>
        public IHandler<DataBase> GetHandlerForType_1(DataBase data)
        {
            var type = typeof(IHandler<>).MakeGenericType(data.GetType());
            var handler = _repo.FirstOrDefault(i => i.Key == type).Value;

            // Das Objekt des Typs "HandlerRepository.HandlerForB" kann nicht in Typ "HandlerRepository.IHandler`1[HandlerRepository.DataBase]" umgewandelt werden.
            return (IHandler<DataBase>) handler;
        }

        /// <summary>
        /// Versuch 2 - Handler über den konkreten Datentyp holen
        /// </summary>
        /// <typeparam name="T">Datentyp den der Handler verarbeiten können soll</typeparam>
        /// <param name="data">Instanz des Datentyps</param>
        /// <returns></returns>
        public IHandler<T> GetHandlerForType_2<T>(T data) where T : DataBase
        {
            var type = typeof(IHandler<>).MakeGenericType(data.GetType());
            var handler = _repo.FirstOrDefault(i => i.Key == type).Value;

            // Das Objekt des Typs "HandlerRepository.HandlerForB" kann nicht in Typ "HandlerRepository.IHandler`1[HandlerRepository.DataBase]" umgewandelt werden.
            return (IHandler<T>) handler;
        }

        /// <summary>
        /// Versuch 3 - Handler über dynamic zurück liefern
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public dynamic GetHandlerForType_3<T>(T data) where T : DataBase
        {
            var type = typeof(IHandler<>).MakeGenericType(data.GetType());
            var handler = _repo.FirstOrDefault(i => i.Key == type).Value;
            return handler;
        }

    }
}
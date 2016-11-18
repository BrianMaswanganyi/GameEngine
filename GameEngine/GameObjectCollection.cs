using System;
using System.Collections;
using System.Collections.Generic;

namespace GameEngine
{
    public class GameObjectCollection : IEnumerable<GameObject>
    {
        List<GameObject> _gameObjects;

        public GameObjectCollection()
        {
            _gameObjects = new List<GameObject>();
        }
        public void AddComponent<T>() where T : GameObject
        {
            var gameObject = Activator.CreateInstance<T>();

            _gameObjects.Add(gameObject);
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            return _gameObjects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _gameObjects.GetEnumerator();
        }

    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameObject
    {
        public string Name { get; set; }
        public GameObject()
        {
            gameObjectThread = new Thread(new ThreadStart(Update));
        }
        Thread gameObjectThread;

        public virtual void Update()
        {
            if (Debug.IsDebugMode)
            {
                Debug.Log(Name);
            }
        }

        internal void Start()
        {
            // gameObjectThread.Start();
            Update();
        }
    }
}

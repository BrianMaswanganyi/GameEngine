using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameObject
    {
        internal bool IsRendered { get; set; }

        public virtual void Update()
        {

        }

        internal void Start()
        {
            if(!IsRendered)
            {
                Rendered();
            }
            Update();
        }

        private void Rendered()
        {
            
        }
    }
}

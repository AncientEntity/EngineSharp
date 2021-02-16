using System;
using System.Collections.Generic;
using System.Text;

namespace EngineSharp
{
    public abstract class Component
    {
        public abstract void Awake();
        public abstract void Start();
        public abstract void Update();

        private GameObject parent;
        
        public Component()
        {
            Awake();
            Start();
        }

        public Component Clone()
        {
            return (Component)MemberwiseClone();
        }

        public void SetParent(GameObject parent)
        {
            this.parent = parent;
        }


    }
}

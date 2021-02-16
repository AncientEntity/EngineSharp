using System;
using System.Collections.Generic;
using System.Text;

namespace EngineSharp
{
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z=0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    
    public class Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

    }

}

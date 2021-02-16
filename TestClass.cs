using System;
using System.Collections.Generic;

namespace EngineSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Scene scene = new Scene("TestScene");
            GameObject testGO = new GameObject();
            testGO.components.Add(new TestComponent());
            testGO.components.Add(new TestComponent());
            testGO.components.Add(new TestComponent());
            scene.objects.Add(testGO);

            List<Scene> scenes = new List<Scene>();
            scenes.Add(scene);
            
            SharpGame sG = new SharpGame(scenes,"TestScene",new List<GameObject>());
            sG.StartGame();
        }


        class TestComponent : Component
        {
            public override void Awake()
            {
                Console.WriteLine("AWAKE");
            }
            public override void Start()
            {
                Console.WriteLine("START");
            }

            public override void Update()
            {
                Console.WriteLine("UPDATE");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EngineSharp
{
    public class SharpGame
    {
        public static bool gameActive = true;
        
        public static List<GameObject> activeObjects = new List<GameObject>();
        public static List<GameObject> prefabs = new List<GameObject>();
        public static List<Scene> scenes = new List<Scene>();

        public static string currentScene;

        public SharpGame(List<Scene> givenScenes, string startingScene, List<GameObject> prefabs)
        {
            scenes = givenScenes;
            currentScene = startingScene;
        }

        public void StartGame()
        {
            SceneManagement.LoadScene(currentScene);
            GameLoop();
        }


        private void GameLoop()
        {
            while(gameActive)
            {
                long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                GameTick();
                Time.deltaTime = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - currentTime) / 1000.0f;
            }
        }


        private void GameTick()
        {
            foreach(GameObject obj in activeObjects)
            {
                foreach(Component component in obj.components)
                {
                    component.Update();
                }
            }
        }

    }

    public class GameObject
    {
        public Vector3 position;
        public Vector3 scale;
        public Quaternion rotation;

        public List<Component> components;

        public GameObject()
        {
            position = new Vector3(0,0,0);
            scale = new Vector3(0,0,0);
            rotation = new Quaternion();

            components = new List<Component>();
        }

        public GameObject Clone()
        {
            GameObject cloned = (GameObject)this.MemberwiseClone();
            cloned.components = new List<Component>();
            foreach(Component comp in components)
            {
                Component clonedComp = comp.Clone();
                clonedComp.SetParent(cloned);
                cloned.components.Add(clonedComp);
            }


            return cloned;
        }

        public static GameObject Instantiate(GameObject prefab, Vector3 position)
        {
            GameObject obj = prefab.Clone();
            obj.position = new Vector3(position.x, position.y, position.z);
            SharpGame.activeObjects.Add(obj);
            return obj;
        }

    }

    public class Scene 
    {
        public string sceneName;
        public List<GameObject> objects;
        
        public Scene(string name)
        {
            sceneName = name;
            objects = new List<GameObject>();
        }

    }
    


}

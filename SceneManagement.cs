using System;
using System.Collections.Generic;
using System.Text;

namespace EngineSharp
{
    public static class SceneManagement
    {
        public static List<Scene> scenes
        {
            get
            {
                return SharpGame.scenes;
            }
        }


        public static void LoadScene(string sceneName)
        {
            foreach(GameObject obj in GetSceneByName(sceneName).objects)
            {
                GameObject.Instantiate(obj, obj.position);
            }
        }


        public static Scene GetSceneByName(string sceneName)
        {
            foreach(Scene s in SharpGame.scenes)
            {
                if(s.sceneName == sceneName)
                {
                    return s;
                }
            }
            return null;
        }

    }
}

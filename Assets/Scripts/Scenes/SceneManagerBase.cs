using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scenes
{
    public class SceneManagerBase
    {
        public void LoadNewSceneRoutine(string name) => SceneManager.LoadScene(name);
        public void QuitRoutine() => Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace FC.ScreenService
{
    public class SceneService : MonoBehaviour, ISceneService
    {
        public void LoadingScene(ScreenReference sceneRef)
        {
            SceneManager.LoadScene(sceneRef.SceneName, LoadSceneMode.Single);
        }

        public void LoadingAdditiveScene(ScreenReference sceneRef)
        {
            SceneManager.LoadScene(sceneRef.SceneName, LoadSceneMode.Additive);
        }
    }
}

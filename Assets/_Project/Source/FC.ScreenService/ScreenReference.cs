using UnityEngine;

namespace FC.ScreenService
{
    [CreateAssetMenu(menuName = "Services and Scriptables/Screen Reference")]
    public sealed class ScreenReference : ScriptableObject
    {
        [SerializeField] private string _sceneName;

        public string SceneName => _sceneName;
    }
}

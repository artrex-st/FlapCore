using FC.DataService;
using FC.ScreenService;
using FC.SoundService;
using Sirenix.OdinInspector;
using Source;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace FC
{
    public class StartupController : MonoBehaviour
    {
        [SerializeField] private ScreenReference _firstScreenRef;
        [FoldoutGroup("Save Data config")]
        [SerializeField] private string _fileName;
        [FoldoutGroup("Save Data config")]
        [SerializeField] private bool _useEncryption;

        [FoldoutGroup("Sound config")]
        [SerializeField] private SoundLibrary _library;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixer _audioMixer;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixerGroup _musicMixerGroup;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixerGroup _sfxMixerGroup;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixerGroup _uiSfxMixerGroup;
        [FoldoutGroup("Screen Config")]
        private ISceneService _sceneService;

        private void Awake()
        {
            SpawnScreenService();
            SpawnDataService();
            _sceneService.LoadingScene(_firstScreenRef);
        }

        private void SpawnScreenService()
        {
            GameObject screenServiceObject = new GameObject(nameof(SceneService));
            DontDestroyOnLoad(screenServiceObject);
            SceneService sceneService = screenServiceObject.AddComponent<SceneService>();
            ServiceLocator.Instance.RegisterService<ISceneService>(sceneService);
            _sceneService = ServiceLocator.Instance.GetService<ISceneService>();
        }

        private void SpawnDataService()
        {
            GameObject saveDataServiceObject = new GameObject(nameof(SaveDataService));
            DontDestroyOnLoad(saveDataServiceObject);
            SaveDataService saveDataService = saveDataServiceObject.AddComponent<SaveDataService>();
            ServiceLocator.Instance.RegisterService<ISaveDataService>(saveDataService);
            saveDataService.Initialize(_fileName, _useEncryption);
        }

        private void SpawnSoundService()
        {
            GameObject soundServiceObject = new GameObject(nameof(SoundMixerService));
            DontDestroyOnLoad(soundServiceObject);
            SoundMixerService soundMixerService = soundServiceObject.AddComponent<SoundMixerService>();
            ServiceLocator.Instance.RegisterService<ISoundService>(soundMixerService);
            soundMixerService.Initialize(_library, _audioMixer, _musicMixerGroup, _sfxMixerGroup, _uiSfxMixerGroup);
        }
    }
}

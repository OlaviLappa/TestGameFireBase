using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Scenes;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button[] _gameMenuButtons;
    [SerializeField] private GameObject _gameMenuPanel;
    [SerializeField] private Text _scoreValueTxt;

    private SceneManagerBase sceneManagerBase;
    private GlassesVault glassesVault;
    private SettlementSystem settlementSystem;

    public static UnityEvent<object, int> OnGlassesChange;

    private void Start()
    {
        PlayerPrefs.DeleteAll();

        if(OnGlassesChange == null)
            OnGlassesChange = new UnityEvent<object, int>();

        glassesVault = new GlassesVault();
        glassesVault.Initialize();

        settlementSystem = new SettlementSystem(glassesVault);
        sceneManagerBase = new SceneManagerBase();

        _gameMenuPanel.SetActive(false);

        _gameMenuButtons[0].onClick.AddListener(() => OpenGameMenu());
        _gameMenuButtons[1].onClick.AddListener(() => CloseGameMenu());
        _gameMenuButtons[2].onClick.AddListener(() => ReloadLevel());
        _gameMenuButtons[3].onClick.AddListener(() => LeaveGame());

        OnGlassesChange.AddListener((sender, value) =>
        {
            if(sender is BallDetection)
            {
                settlementSystem.AddGlasses(sender, value);
                _scoreValueTxt.text = glassesVault.Glasses.ToString();
            }
        });
    }

    private void OpenGameMenu() => _gameMenuPanel.SetActive(true);
    private void CloseGameMenu() => _gameMenuPanel.SetActive(false);
    private void ReloadLevel() => sceneManagerBase.LoadNewSceneRoutine("Game");
    private void LeaveGame() => sceneManagerBase.LoadNewSceneRoutine("MainMenu");
}
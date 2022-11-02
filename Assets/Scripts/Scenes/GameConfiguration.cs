using UnityEngine;
using Assets.Scripts.Scenes;
using UnityEngine.UI;

public class GameConfiguration : MonoBehaviour
{
    private SceneManagerBase sceneManagerBase;

    [SerializeField] Button[] _menuButtons;
    [SerializeField] Button[] _choiceLevelsButtons;
    [SerializeField] GameObject _choiceLevelPanel;

    void Start()
    {
        _choiceLevelPanel.SetActive(false);

        sceneManagerBase = new SceneManagerBase();
        _menuButtons[0].onClick.AddListener(() => StartGameHandler());
        _menuButtons[1].onClick.AddListener(() => QuitGameHandler());

        _choiceLevelsButtons[0].onClick.AddListener(() => CloseChoicePanelHandler());

        _choiceLevelsButtons[1].onClick.AddListener(() => ChoiceGeneratedLevelHandler(1));
        _choiceLevelsButtons[2].onClick.AddListener(() => ChoiceGeneratedLevelHandler(2));
    }

    private void StartGameHandler()
    {
        _choiceLevelPanel.SetActive(true);
    }

    private void ChoiceGeneratedLevelHandler(int level_id)
    {
        DataHolder.LevelId = level_id;
        sceneManagerBase.LoadNewSceneRoutine("Game");
    }

    private void CloseChoicePanelHandler() => _choiceLevelPanel.SetActive(false);
    private void QuitGameHandler() => sceneManagerBase.QuitRoutine();
}

using UnityEngine;
using Assets.Scripts.Scenes;
using UnityEngine.Events;

public class LevelConfiguration : MonoBehaviour
{
    private GameObject _levelPrefab;
    public static UnityEvent OnCreateNewUserBall;

    private void Start()
    {
        InitNewUserBall();

        LoadNewLevel(DataHolder.LevelId);
        OnCreateNewUserBall = new UnityEvent();

        OnCreateNewUserBall.AddListener(() =>
        {
            InitNewUserBall();
        });
    }

    private void InitNewUserBall()
    {
        UserBall user = new UserBall();
        BallThrow ballThrow = new BallThrow();

        ballThrow.NextThrow(user._onGenerateNewUserBall);
    }

    private void LoadNewLevel(int id)
    {
        switch (id)
        {
            case 1:
                LoadGenerateScene();
                break;

            case 2:
                LoadStandartScene();
                break;

            default:
                break;
        }

        if(_levelPrefab != null)
        {
            GameObject _levelCopy = Instantiate(_levelPrefab) as GameObject;
        }
    }

    private void LoadGenerateScene()
    {
        _levelPrefab = Resources.Load<GameObject>("Config/ConfigureRandom");
    }

    private void LoadStandartScene()
    {
        _levelPrefab = Resources.Load<GameObject>("Config/DefineBalls");
    }
}

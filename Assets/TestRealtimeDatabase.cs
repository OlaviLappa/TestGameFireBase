using Firebase.Database;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestRealtimeDatabase : MonoBehaviour
{
    [SerializeField] private MyFireBaseRemoteConfig remoteConfig;
    //[SerializeField] SampleWebView _sampleWebView;

    private SampleWebView _sampleWeb;

    private DatabaseReference _databaseReference;
    private string _url;
    private StringBuilder _sb_url;
    [SerializeField] private Text urlTxt;

    GameObject testWebViewObject;
    GameObject testWebViewCopy;

    public static UnityEvent Ontest;

    private void Start()
    {
        remoteConfig.FetchDataAsync();

        _sb_url = new StringBuilder();
        Ontest = new UnityEvent();

        Invoke(nameof(DatabaseInit), 5);
        Invoke(nameof(GetUrl), 7);

        Ontest.AddListener(() =>
        {
            urlTxt.text = _sb_url.ToString();

            testWebViewObject = Resources.Load<GameObject>("Config/TestWebView");
            testWebViewCopy = Instantiate(testWebViewObject) as GameObject;
            _sampleWeb = testWebViewCopy.GetComponent<SampleWebView>();

            _sampleWeb.Url = _sb_url.ToString();
        });
    }

    private void DatabaseInit()
    {
        try
        {
            _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        }

        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            throw;
        }
    }

    private void GetUrl()
    {
        _databaseReference.Child("configure").Child("url").GetValueAsync().ContinueWith(task => 
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                TryLoadWebViewAsync(snapshot, Ontest);
            }
        });
    }

    private void TryLoadWebViewAsync(DataSnapshot snapshot, UnityEvent t1)
    {
        _url = snapshot.GetRawJsonValue();

        foreach (char c in _url)
        {
            if (c != '"')
                _sb_url.Append(c);
        }

        Debug.Log(_sb_url);
    }

    public void GetWebViewButton()
    {
        Ontest.Invoke();
    }

    private void LoadGame() => SceneManager.LoadScene("Game");
}

using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Database;
using System.Threading.Tasks;
using System;
using System.Text;

public class FirstTestConfiguration : MonoBehaviour
{
    private SampleWebView _sampleWeb;
    private DatabaseReference _reference;

    private StringBuilder sb;
    private string rawUserData;

    private void Awake()
    {
        MainAsync();
    }

    private async void MainAsync()
    {
        sb = new StringBuilder();
        _reference = FirebaseDatabase.DefaultInstance.RootReference;

        DataSnapshot snapshot = await GetUserAsync();
        await Task.Delay(2000);

        if(snapshot != null)
            LoadWebViewAsync(snapshot);
    }

    private async Task<DataSnapshot> GetUserAsync()
    {
        DataSnapshot snapshot = await _reference.Child("configure").Child("url").GetValueAsync();
        await Task.Delay(2000);

        if(snapshot.Value == null)
        {
            LoadGame();
        }

        return snapshot;
    }

    private void LoadWebViewAsync(DataSnapshot snapshot)
    {
        rawUserData = snapshot.GetRawJsonValue();

        foreach (char c in rawUserData)
        {
            if (c != '"')
                sb.Append(c);
        }

        GameObject testWebViewObject = Resources.Load<GameObject>("Config/TestWebView");
        GameObject testWebViewCopy = Instantiate(testWebViewObject) as GameObject;
        _sampleWeb = testWebViewCopy.GetComponent<SampleWebView>();

        _sampleWeb.Url = sb.ToString();
    }

    private void LoadGame() => SceneManager.LoadScene("MainMenu");
}

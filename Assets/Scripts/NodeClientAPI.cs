using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class NodeClientAPI : MonoBehaviour
{
    [SerializeField] private string URI = "http://localhost:3000";
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(GetWebRequest), URI);
    }

    // Update is called once per frame
    void Update() { }

    public IEnumerator GetWebRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            
            // Get the very last part of the URI, e.g, if the URI was `http://localhost/Some/Page/Here.html" then 
            // `pages[page]` would be `Here.html`.
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    
    public IEnumerator GetHighscoreRecordViaWebRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            
            // Get the very last part of the URI, e.g, if the URI was `http://localhost/Some/Page/Here.html" then 
            // `pages[page]` would be `Here.html`.
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    var resultString = webRequest.downloadHandler.text;
                    Debug.Log(pages[page] + ":\nReceived: " + resultString);

                    var highscoreRecord = JsonUtility.FromJson<HighscoreRecord>(resultString);
                    
                    
                    break;
            }
        }
    }
    
}

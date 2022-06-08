using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class keyword : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private string[] Keywords_array = new string[] { "玩","最大","對不起" };
    static public int voice = 0;

    // Start is called before the first frame update
    void Start()
    {
        keywordRecognizer = new KeywordRecognizer(Keywords_array);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text + "; Start Time: " + args.phraseStartTime + "; Duration: " + args.phraseDuration);

        if (args.text == "玩") voice = 1;
        else if (args.text == "最大") TestGameFrame.Test_EnemyTask.waitforspeak = 2;
        else if (args.text == "對不起") TestGameFrame.Test_EnemyTask.apologize = 1;
    }
}

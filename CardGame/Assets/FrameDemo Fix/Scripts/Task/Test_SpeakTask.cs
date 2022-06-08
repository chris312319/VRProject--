using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SpeakTask : MonoBehaviour
{
    float time = 0;
    int count = 1;
    public Animator TeacherA;
    // Start is called before the first frame update
    void Start()
    {
        TeacherA = GameObject.Find("teacher").GetComponent<Animator>();
    }
    void Update()
    {
        StartCoroutine(update());
    }

    // Update is called once per frame
    IEnumerator update()
    {
        if (Input.GetKeyDown(KeyCode.J)) TestGameFrame.Test_EnemyTask.waitforspeak = 2;

        if (Input.GetKeyDown(KeyCode.F)) TestGameFrame.Test_EnemyTask.apologize = 1;

        if (TestGameFrame.Test_EnemyTask.waitforspeak == 1)
        {
            if (count == 1) time += Time.deltaTime;
            if (time > 6 && TestGameFrame.Test_EnemyTask.showtouch == 0)
            {
                count = 0;
                AudioClip clip = Resources.Load<AudioClip>("Audios/Host記得舉牌");
                GameAudioController.Instance.PlayOneShot(clip);
                time = 0;
                Test_GameData.showcard[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                count = 1;
            }
            else if (time > 6 && TestGameFrame.Test_EnemyTask.showtouch == 1)
            {
                count = 0;
                AudioClip clip = Resources.Load<AudioClip>("Audios/Host記得我最大");
                GameAudioController.Instance.PlayOneShot(clip);
                time = 0;
                Test_GameData.saybig[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                count = 1;
            }
        }
        else time = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CardTask : MonoBehaviour
{
    float time = 0;
    static public int allspeak = 0;
    AudioClip clip;
    public Animator TeacherA;
    public Animator Enemy02A = null;
    static public int now = 0,count = 1;
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
        if (Enemy02A == null)
        {
            Enemy02A = GameObject.Find("enemy02(Clone)").GetComponent<Animator>();
        }
        if (TestGameFrame.Test_EnemyTask.waitforjudge == 1)
        {
            if(count == 1)time += Time.deltaTime;
            
            if (now == 0)
            {
                if (time > 5)
                {
                    count = 0;
                    clip = Resources.Load<AudioClip>("Audios/NPC_小花記得翻牌");
                    Enemy02A.Play("d02");
                    GameAudioController.Instance.PlayOneShot(clip);
                    time = 0;
                    Test_GameData.turncard[TestGameFrame.Test_EnemyTask.j + 3] += 1;
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy02A.Play("dstop");
                    now = 1;
                    count = 1;
                }
            }
            else if (now == 1)
            {
                if (time > 3)
                {
                    count = 0;
                    clip = Resources.Load<AudioClip>("Audios/Host記得翻牌");
                    TeacherA.Play("Teacher2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    time = 0;
                    Test_GameData.turncard[TestGameFrame.Test_EnemyTask.j + 3] += 1;
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("Teacher1");
                    count = 1;
                }
            }
        }
        else time = 0;
    }
}

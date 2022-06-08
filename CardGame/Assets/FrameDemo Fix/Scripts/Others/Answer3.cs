using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer3 : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage Ans3Img;
    public Animator TeacherA;
    AudioClip clip;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        TeacherA = GameObject.Find("teacher").GetComponent<Animator>();
        Ans3Img = GameObject.Find("Ans3Pic").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TestGameFrame.Test_EnemyTask.Round == 3)
        {
            Ans3Img.texture = Resources.Load<Texture2D>("Pictures/難過");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 4)
        {
            Ans3Img.texture = Resources.Load<Texture2D>("Pictures/難過");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 5)
        {
            Ans3Img.texture = Resources.Load<Texture2D>("Pictures/難過");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 6)
        {
            Ans3Img.texture = Resources.Load<Texture2D>("Pictures/難過");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 7)
        {
            Ans3Img.texture = Resources.Load<Texture2D>("Pictures/難過");
        }
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (((other.tag == "RightHand") || other.tag == "LeftHand") && Answer1.Speaking == 0 && TestGameFrame.Test_EnemyTask.qstart == 1)
        {
            if (TestGameFrame.Test_EnemyTask.Round == 3)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Sad";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Sad";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host第一輪對");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 4)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Sad";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Sad";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host第二輪對");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 5)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Sad";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Sad";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第三輪錯眉");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 6)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Sad";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Sad";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host第四輪對眉");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 7)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Sad";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Sad";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第四輪錯眉");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
            }
        }

    }
    IEnumerator Waiting(AudioClip clip)
    {
        Debug.Log(clip.length);
        yield return new WaitForSeconds(4f);
    }
}

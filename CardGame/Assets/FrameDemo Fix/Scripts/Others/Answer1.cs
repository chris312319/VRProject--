using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer1 : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage Ans1Img;
    public Animator TeacherA;
    AudioClip clip;
    float time = 0;
    static public int Speaking = 0;
    // Start is called before the first frame update
    void Start()
    {
        TeacherA = GameObject.Find("teacher").GetComponent<Animator>();
        Ans1Img = GameObject.Find("Ans1Pic").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TestGameFrame.Test_EnemyTask.Round == 0)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/生氣");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 1)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/亂丟");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 2)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/生氣");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 3)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/開心");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 4)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/開心");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 5)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/開心");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 6)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/開心");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 7)
        {
            Ans1Img.texture = Resources.Load<Texture2D>("Pictures/開心");
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (((other.tag == "RightHand") || other.tag == "LeftHand") && Speaking == 0&& TestGameFrame.Test_EnemyTask.qstart ==1)
        {
            if (TestGameFrame.Test_EnemyTask.Round == 0)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Angry";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Angry";
                Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host問題一對");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 1)
            {
                TestGameFrame.Test_EnemyTask.ChooseActionRT = 0;
                if (Test_DataCenter.ChooseAction_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseAction_Choice[Test_DataCenter.now] = "ThrowCard";
                else Test_DataCenter.ChooseAction_Choice[Test_DataCenter.now] += ",ThrowCard";
                Speaking = 1;
                if (Test_DataCenter.ChooseAction_Acc == -1) Test_DataCenter.ChooseAction_Acc = 0;
                clip = Resources.Load<AudioClip>("Audios/Host問題二錯");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 2)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Angry";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Angry";
                Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host問題三錯");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 3)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Happy";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Happy";
                Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第一輪錯H");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 4)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Happy";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Happy";
                Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第一輪錯H");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 5)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Happy";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Happy";
                Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第三輪錯H");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 6)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Happy";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Happy";
                Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第四輪錯H");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 7)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Happy";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Happy";
                Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host你贏了很棒");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
        }

    }
    IEnumerator Waiting(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
    }
}

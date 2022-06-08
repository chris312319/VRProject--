using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer2 : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage Ans2Img;
    public Animator TeacherA;
    AudioClip clip;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        TeacherA = GameObject.Find("teacher").GetComponent<Animator>();
        Ans2Img = GameObject.Find("Ans2Pic").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TestGameFrame.Test_EnemyTask.Round == 0)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/開心");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 1)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/深呼吸");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 2)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/開心");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 3)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/生氣");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 4)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/生氣");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 5)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/生氣");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 6)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/生氣");
        }
        if (TestGameFrame.Test_EnemyTask.Round == 7)
        {
            Ans2Img.texture = Resources.Load<Texture2D>("Pictures/生氣");
        }
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (((other.tag == "RightHand") || other.tag == "LeftHand") && Answer1.Speaking == 0 &&　TestGameFrame.Test_EnemyTask.qstart == 1)
        {
            if(TestGameFrame.Test_EnemyTask.Round == 0)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Happy";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Happy";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host問題一錯");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Debug.Log("hello");
                Answer1.Speaking = 0;
            }
            if(TestGameFrame.Test_EnemyTask.Round == 1)
            {
                TestGameFrame.Test_EnemyTask.ChooseActionRT = 0;
                if (Test_DataCenter.ChooseAction_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseAction_Choice[Test_DataCenter.now] = "DeepBreath";
                else Test_DataCenter.ChooseAction_Choice[Test_DataCenter.now] += ",DeepBreath";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseAction_Acc == -1) Test_DataCenter.ChooseAction_Acc = 1;
                clip = Resources.Load<AudioClip>("Audios/Host問題二對");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 2)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Happy";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Happy";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host問題三對");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 3)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Angry";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Angry";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第一輪錯A");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 4)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Angry";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Angry";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第一輪錯A");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                Test_GameData.question[TestGameFrame.Test_EnemyTask.j] += 1;
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
            }           
            if (TestGameFrame.Test_EnemyTask.Round == 5)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Angry";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Angry";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host第三輪對");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Answer1.Speaking = 0;
                TestGameFrame.Test_EnemyTask.trueans = 1;
            }
            if (TestGameFrame.Test_EnemyTask.Round == 6)
            {
                TestGameFrame.Test_EnemyTask.ChooseEmotionRT = 0;
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Angry";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Angry";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 1;
                clip = Resources.Load<AudioClip>("Audios/Host第四輪對A");
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
                if (Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] == "-1") Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] = "Angry";
                else Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now] += ",Angry";
                Answer1.Speaking = 1;
                if (Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] == -1) Test_DataCenter.ChooseEmotion_AccList[Test_DataCenter.now] = 0;
                clip = Resources.Load<AudioClip>("Audios/Host第五輪錯A");
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

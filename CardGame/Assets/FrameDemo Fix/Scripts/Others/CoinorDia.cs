using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinorDia : MonoBehaviour
{
    public GameObject GoldP;

    public GameObject Gold1;

    public GameObject Gold2;

    public GameObject Gold3;

    public GameObject DiaP;

    public GameObject Dia1;

    public GameObject Dia2;

    public GameObject Dia3;

    public  AudioClip clip;

    public float timer1 = 0, timer2 = 0, timer3 = 0, timer4 = 0, timer5 = 0, timer6 = 0, timer7 = 0, timer8 = 0;

    static public int c1 = 0, c2 = 0, c3 = 0, cP = 0, d1 = 0, d2 = 0, d3 = 0, dP = 0;

    // Start is called before the first frame update
    void Start()
    {
        GoldP = GameObject.Find("GoldP");
        Gold1 = GameObject.Find("Gold1");
        Gold2 = GameObject.Find("Gold2");
        Gold3 = GameObject.Find("Gold3");
        DiaP = GameObject.Find("DiaP");
        Dia1 = GameObject.Find("Dia1");
        Dia2 = GameObject.Find("Dia2");
        Dia3 = GameObject.Find("Dia3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            {
            TestGameFrame.Test_EnemyTask.transferdata = true;
        }
        if (c1 == 1) {
            Gold1.SetActive(true);
            timer1 += Time.deltaTime;
            if (timer1 > 2)
            {
                Gold1.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/blingblingcoin");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.coin01 += 1;
                timer1 = 0;
                c1 = 0;
            }
        }
        if (c2 == 1)
        {
            Gold2.SetActive(true);
            timer2 += Time.deltaTime;
            if (timer2 > 2)
            {
                Gold2.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/blingblingcoin");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.coin02 += 1;
                timer2 = 0;
                c2 = 0;
            }
        }
        if (c3 == 1)
        {
            Gold3.SetActive(true);
            timer3 += Time.deltaTime;
            if (timer3 > 2)
            {
                Gold3.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/blingblingcoin");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.coin03 += 1;
                timer3 = 0;
                c3 = 0;
            }
        }
        if (cP == 1)
        {
            GoldP.SetActive(true);
            timer4 += Time.deltaTime;
            if (timer4 > 2)
            {
                GoldP.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/blingblingcoin");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.coinP += 1;
                timer4 = 0;
                cP = 0;
            }
        }
        if (d1 == 1)
        {
            Dia1.SetActive(true);
            timer5 += Time.deltaTime;
            if (timer5 > 2)
            {
                Dia1.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/ruby");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.diamond01 += 1;
                timer5 = 0;
                d1 = 0;
            }
        }
        if (d2 == 1)
        {
            Dia2.SetActive(true);
            timer6 += Time.deltaTime;
            if (timer6 > 2)
            {
                Dia2.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/ruby");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.diamond02 += 1;
                timer6 = 0;
                d2 = 0;
            }
        }
        if (d3 == 1)
        {
            Dia3.SetActive(true);
            timer7 += Time.deltaTime;
            if (timer7 > 2)
            {
                Dia3.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/ruby");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.diamond03 += 1;
                timer7 = 0;
                d3 = 0;
            }
        }
        if (dP == 1)
        {
            DiaP.SetActive(true);
            timer8 += Time.deltaTime;
            if (timer8 > 2)
            {
                DiaP.SetActive(false);
                clip = Resources.Load<AudioClip>("Audios/ruby");
                GameAudioController.Instance.PlayOneShot(clip);
                TestGameFrame.Test_CoinTask.diamondP += 1;
                timer8 = 0;
                dP = 0;
            }
        }
    }
}

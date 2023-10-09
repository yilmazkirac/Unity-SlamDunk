using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("------------Level Ayarlar")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyutucu;
    [SerializeField] private GameObject[] PotaBuyutucuNoktasi;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private ParticleSystem[] Efektler;



    [Header("------------Canvas Ayarlar")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;


    [Header("------------Teknik Ayarlar")]
    [SerializeField] private int AtilmasiGerekenTop;
    int BasketSayisi;




    private void Start()
    {
       
        for (int i = 0; i < AtilmasiGerekenTop; i++)
        {
            GorevGorselleri[i].gameObject.SetActive(true);
        }
        Invoke("OzellikOlussun",3f);
    }
    private void Update()
    {
        if (Platform.transform.position.x>-1.7)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Platform.transform.position = Vector3.Lerp(Platform.transform.position,
                    new Vector3(Platform.transform.position.x - .5f, Platform.transform.position.y, Platform.transform.position.z), .05f);
            }
        }
        if (Platform.transform.position.x <1.7)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Platform.transform.position = Vector3.Lerp(Platform.transform.position,
                    new Vector3(Platform.transform.position.x + .5f, Platform.transform.position.y, Platform.transform.position.z), .05f);
            }
        }

    }
    void OzellikOlussun()
    {
        int Sayi = Random.Range(0, PotaBuyutucuNoktasi.Length-1);
        PotaBuyutucu.transform.position = PotaBuyutucuNoktasi[Sayi].transform.position;
        PotaBuyutucu.SetActive(true);
    }
    public void Basket(Vector3 Pos)
    {
        Sesler[4].Play();
        BasketSayisi++;
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamSprite;
        Efektler[0].transform.position = Pos;
        Efektler[0].gameObject.SetActive(true);
        Efektler[0].Play();
        if (BasketSayisi==AtilmasiGerekenTop)
        {
            Kazandin();
        }
      
    }
    public void Kaybettin()
    {
        Sesler[1].Play();
    }
    public void Kazandin()
    {
        Sesler[2].Play();
    }
    public void PotaBuyut(Vector3 Pos)
    {
        Efektler[1].transform.position = Pos;
        Efektler[1].gameObject.SetActive(true);
        Efektler[1].Play();
        Sesler[0].Play();
        Pota.transform.localScale = new Vector3(75, 75, 75);
        Invoke("PotaKucult", 5f);
    }
    public void PotaKucult()
    {
        Pota.transform.localScale = new Vector3(55, 55, 55);
     
    }
}

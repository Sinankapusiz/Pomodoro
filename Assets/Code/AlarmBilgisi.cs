using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmBilgisi : MonoBehaviour
{
    public Text alarmBaslikText;
    public Text alarmSuresiText;
    public Color calismaRengi, molaRengi, SoruCozumuRengi;
    public float alarmSuresi;
    public float alarmKalanSure;
    public string alarmTipi;
    public string alarmBasligi;
    public Text alarmTipiText;
    public GameObject yuklenme;
    public bool alarmCalismaDurumu = false;
    public GameObject alarmSoundObject;
    AudioSource alarmSound;
    public GameObject mainCamera;

    [Header("Alarm Değişkenleri")]
    public int saat;
    public int dakika;
    public float saniye;
    public AlarmSuresiKayitlari alarmSuresiKayitlari ;
    void Start()
    {
        alarmSuresi = (saat * 60) * 60 + dakika * 60 + saniye;
        alarmSuresiText.text = saat.ToString("00:") + dakika.ToString("00:") + saniye.ToString("00");
        alarmKalanSure = alarmSuresi;
        if (alarmTipi == "Çalışma")
        {
            alarmTipiText.text = "Çalışma";
            alarmTipiText.color = calismaRengi;
        }
        if (alarmTipi == "Mola")
        {
            alarmTipiText.text = "Mola";
            alarmTipiText.color = molaRengi;
        }
        if (alarmTipi == "Soru Çözümü")
        {
            alarmTipiText.text = "Soru Çözümü";
            alarmTipiText.color = SoruCozumuRengi;
        }
        alarmBaslikText.text = alarmBasligi;
        alarmSuresiKayitlari = new AlarmSuresiKayitlari {saat=saat,dakika=dakika,saniye=saniye };
    }
    //private void FixedUpdate()
    //{
    //    if (alarmCalismaDurumu == true)
    //    {
    //        if (saniye > 0)
    //            saniye -= Time.deltaTime;
    //        else
    //        {
    //            if (dakika > 0)
    //            {
    //                dakika--;
    //                saniye = 59;
    //            }
    //            else
    //            {
    //                if (saat > 0)
    //                {
    //                    saat--;
    //                    dakika = 60;
    //                }
    //                else
    //                {
    //                    if (mainCamera.GetComponent<AlarmManager>().alarmSirasi < mainCamera.GetComponent<AlarmManager>().alarmlar.Length)
    //                    {
    //                        mainCamera.GetComponent<AlarmManager>().alarmSirasi++;
    //                        mainCamera.GetComponent<AlarmManager>().uyari.SetActive(true);
    //                        Debug.Log("Alarm Çalıştı");
    //                        alarmCalismaDurumu = false;
    //                        mainCamera.GetComponent<AlarmManager>().alarmSirasiText.text =   mainCamera.GetComponent<AlarmManager>().alarmSirasi.ToString() + "/" + mainCamera.GetComponent<AlarmManager>().alarmlar.Length;
    //                    }
    //                    else
    //                    {
    //                        mainCamera.GetComponent<AlarmManager>().baslatDuraklatButonu.GetComponent<Image>().sprite = mainCamera.GetComponent<AlarmManager>().butonImage1;
    //                        mainCamera.GetComponent<AlarmManager>().butonaBasmaSayisi = 0;
    //                    }
    //                }

    //            }
    //        }
    //        alarmSuresiText.text = saat.ToString("00:") + dakika.ToString("00:") + saniye.ToString("00");
    //        alarmKalanSure = (saat * 60) * 60 + dakika * 60 + saniye;
    //        yuklenme.GetComponent<Image>().fillAmount = 1 - alarmKalanSure / alarmSuresi;
    //    }

    //}
}
public class AlarmSuresiKayitlari
{
    public int saat { get; set; }
    public int dakika { get; set; }
    public float saniye { get; set; }
}

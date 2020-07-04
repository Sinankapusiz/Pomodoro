using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmManager : MonoBehaviour
{
    public GameObject[] alarmlar;
    public Sprite butonImage1, butonImage2;
    public GameObject baslatDuraklatButonu;
    public GameObject uyari;
    public Text alarmSirasiText;
    public int alarmSirasi = 0;
    public int butonaBasmaSayisi = 0;

    public void Start()
    {
        alarmSirasiText.text = alarmSirasi.ToString() + "/" + alarmlar.Length;
    }
    public void AlarmlariBaslat()
    {
        if (butonaBasmaSayisi==0)
        {
            butonaBasmaSayisi++;
            baslatDuraklatButonu.GetComponent<Image>().sprite = butonImage2;
            alarmlar[alarmSirasi].GetComponent<AlarmBilgisi>().alarmCalismaDurumu = true;
        }
        if (butonaBasmaSayisi == 2)
            butonaBasmaSayisi = 0;
    }
    public void AlarmlariDuraklat()
    {
        if (butonaBasmaSayisi == 1)
        {
            butonaBasmaSayisi++;
            baslatDuraklatButonu.GetComponent<Image>().sprite = butonImage1;
            alarmlar[alarmSirasi].GetComponent<AlarmBilgisi>().alarmCalismaDurumu = false;
        }
    }
    public void UyariKapat()
    {
        GameObject.Find("Main Camera").GetComponent<AlarmManager>().uyari.SetActive(false);
        alarmlar[alarmSirasi].GetComponent<AlarmBilgisi>().alarmCalismaDurumu = true;
    }
    public void AlarmlariSifirla()
    {
        AlarmlariDuraklat();
        Destroy(alarmlar[alarmSirasi].GetComponent<Sayac>());

        butonaBasmaSayisi = 0;
        alarmSirasi = 0;
        alarmSirasiText.text="0/"+ alarmlar.Length;

        for (int a=0;a<alarmlar.Length;a++)
        {
            alarmlar[a].GetComponent<AlarmBilgisi>().yuklenme.GetComponent<Image>().fillAmount=0;
            alarmlar[a].GetComponent<AlarmBilgisi>().saat = alarmlar[a].GetComponent<AlarmBilgisi>().alarmSuresiKayitlari.saat;
            alarmlar[a].GetComponent<AlarmBilgisi>().dakika = alarmlar[a].GetComponent<AlarmBilgisi>().alarmSuresiKayitlari.dakika;
            alarmlar[a].GetComponent<AlarmBilgisi>().saniye = alarmlar[a].GetComponent<AlarmBilgisi>().alarmSuresiKayitlari.saniye;
            alarmlar[a].GetComponent<AlarmBilgisi>().alarmSuresiText.text = alarmlar[a].GetComponent<AlarmBilgisi>().saat.ToString("00:") + alarmlar[a].GetComponent<AlarmBilgisi>().dakika.ToString("00:") + alarmlar[a].GetComponent<AlarmBilgisi>().saniye.ToString("00");
        }
        alarmlar[0].AddComponent<Sayac>();
    }

    //public void SayacEkle()
    //{
    //    alarmlar[0].AddComponent<Sayac>();
    //}
}


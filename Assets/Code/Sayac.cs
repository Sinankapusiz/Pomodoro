using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sayac : MonoBehaviour
{
    private void FixedUpdate()
    {
        SayacCalistir();
       // Debug.Log(this.GetComponent<AlarmBilgisi>().saat);
    }
    public void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            SayacCalistir();
            // Game is paused, start service to get notifications
        }
    }
    private void SayacCalistir()
    {
        if (this.GetComponent<AlarmBilgisi>().alarmCalismaDurumu == true)
        {
            if (this.GetComponent<AlarmBilgisi>().saniye > 0)
                this.GetComponent<AlarmBilgisi>().saniye -= Time.deltaTime;
            else
            {
                if (this.GetComponent<AlarmBilgisi>().dakika > 0)
                {
                    this.GetComponent<AlarmBilgisi>().dakika--;
                    this.GetComponent<AlarmBilgisi>().saniye = 59;
                }
                else
                {
                    if (this.GetComponent<AlarmBilgisi>().saat > 0)
                    {
                        this.GetComponent<AlarmBilgisi>().saat--;
                        this.GetComponent<AlarmBilgisi>().dakika = 60;
                    }
                    else
                    {
                        if (this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmSirasi < this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmlar.Length)
                        {
                            this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmSirasi++;
                            this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().uyari.SetActive(true);
                            Debug.Log("Alarm Çalıştı");
                            this.GetComponent<AlarmBilgisi>().alarmCalismaDurumu = false;
                            this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmSirasiText.text = this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmSirasi.ToString() + "/" + this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmlar.Length;
                            this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmlar[this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().alarmSirasi].AddComponent<Sayac>();
                            Destroy(this.GetComponent<Sayac>());
                        }
                        else
                        {
                            this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().baslatDuraklatButonu.GetComponent<Image>().sprite = this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().butonImage1;
                            this.GetComponent<AlarmBilgisi>().mainCamera.GetComponent<AlarmManager>().butonaBasmaSayisi = 0;
                        }
                    }

                }
            }
            this.GetComponent<AlarmBilgisi>().alarmSuresiText.text = this.GetComponent<AlarmBilgisi>().saat.ToString("00:") + this.GetComponent<AlarmBilgisi>().dakika.ToString("00:") + this.GetComponent<AlarmBilgisi>().saniye.ToString("00");
            this.GetComponent<AlarmBilgisi>().alarmKalanSure = (this.GetComponent<AlarmBilgisi>().saat * 60) * 60 + this.GetComponent<AlarmBilgisi>().dakika * 60 + this.GetComponent<AlarmBilgisi>().saniye;
            this.GetComponent<AlarmBilgisi>().yuklenme.GetComponent<Image>().fillAmount = 1 - this.GetComponent<AlarmBilgisi>().alarmKalanSure / this.GetComponent<AlarmBilgisi>().alarmSuresi;
        }
    }
}

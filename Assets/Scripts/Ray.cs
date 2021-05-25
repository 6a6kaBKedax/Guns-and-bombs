using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Ray : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PickUpInfo;
    public GameObject InfoItemUI;
    public GameObject InfoItemTextUI;

    public GameObject Tumbochka1;
    public GameObject Tumbochka2;

    public AudioSource Tumba;
    public AudioSource Dver;


    public GameObject Journal;
    public GameObject JournalText;

    public TimeScript timeScript;

    string InfoItemText = "";
    public float rayDistance;
    ETUlics ulics = new ETUlics();
    RaycastHit HitInfo;
    AdvancedCameraMove move;

    bool FbuttonPressed = false;

    bool JbuttonPressed = false;

    void Start()
    {
        // PickUPUI.SetActive(false);
        Dver.Play();
        move = GetComponent<AdvancedCameraMove>();
    }
    void Update()
    {
        var ray = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, rayDistance);
        if(ray)
        {
            bool value = Search();
            if (value)
            {
                PickUpInfo.SetActive(true);
            }
            else
            {
                PickUpInfo.SetActive(false);
            }
        }
        //bool j = Jpressed();
    }
    bool Fpresseed() 
    {
        if (Input.GetKeyDown(KeyCode.F) && FbuttonPressed == false)
        {
            InfoItemUI.SetActive(true);
            PickUpInfo.SetActive(false);
            InfoItemTextUI.SetActive(true);
            FbuttonPressed = true;
            move.releaseCursor();
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && FbuttonPressed == true)
        {
            print("f");
            InfoItemUI.SetActive(false);
            FbuttonPressed = false;
            move.lockCursor();
            return false;
        }
        return false;
    }
    bool Jpressed() 
    {
        if (Input.GetKeyDown(KeyCode.J) && JbuttonPressed == false)
        {
            Journal.SetActive(true);
            JournalText.SetActive(true);
            JbuttonPressed = true;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.J) && JbuttonPressed == true)
        {
            Journal.SetActive(false);
            JournalText.SetActive(false);
            JbuttonPressed = false;
            return false;
        }
        return false;
    }
    int TestPorox = 0;

    int TestSelitra = 0;

    int TestChek = 0;
    int TestChek1 = 0;

    int PhoneChek = 0;
    int PhoneChek1 = 0;

    int TestAKM = 0;
    int TestAKM1 = 0;

    int TestNote = 0;
    int TestNote1 = 0;

    bool tumbochka1 = false;
    bool tumbochka2 = false;

    bool key = false;

    int myxa = 0;

    bool Search() 
    {
        

        bool value = false;
        if (HitInfo.distance == 0)
            return false;
        print(HitInfo.collider.name);
        switch (HitInfo.collider.name)
        {
            case "Porox":
                {
                    bool f = Fpresseed();


                    PickUpInfo.GetComponent<Text>().text = "Осмотреть порох";
                    InfoItemTextUI.GetComponent<Text>().text = ulics.PoroxText;
                    if (FbuttonPressed && TestPorox == 0)
                    {
                        InfoItemText += ulics.PoroxText;
                        InfoItemText += "\n";
                        JournalText.GetComponent<Text>().text = InfoItemText;
                        print("zapis");
                        print(TestPorox);

                        TestPorox++;
                    }
                    value = true;
                }
                break;
            case "Chek":
                {
                    bool f = Fpresseed();

                    print("detected");

                    PickUpInfo.GetComponent<Text>().text = "Осмотреть чек";
                    if (FbuttonPressed && TestChek < 1)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = ulics.ChekText + "\n" + "Желаете отправить предмет на экспертизу (E - да; F - нет): расчетное время от 5 до 10 минут";
                        InfoItemText += ulics.ChekText;
                        InfoItemText += "\n";
                        JournalText.GetComponent<Text>().text = InfoItemText;
                        TestChek++;
                    }
                    if (Input.GetKeyDown(KeyCode.E) && TestChek1 == 0)
                    {
                        timeScript.timeLeft -= Random.Range(300f, 600f);
                        string opisanie = "Продавец сообщил что покупатель был темноватого цвета кожи, средних лет, имеется борода";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.ChekText + "\n" + opisanie;
                        JournalText.GetComponent<Text>().text = "\n" + opisanie;
                        TestChek1++;
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && TestChek1 != 0)
                    {
                        string opisanie = "Продавец сообщил что покупатель был темноватого цвета кожи, средних лет, имеется борода";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.ChekText + "\n" + opisanie;
                    }

                    value = true;
                }
                break;
            case "Smartphone":
                {
                    bool f = Fpresseed();
                    print("smartphone derected");
                    PickUpInfo.GetComponent<Text>().text = "Осмотреть телефон";
                    if (FbuttonPressed && PhoneChek < 1)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = ulics.PhoneText + "\n" + "Желаете отправить предмет на экспертизу (E - да; F - нет): расчетное время от 3 до 6 минут";
                        InfoItemText += ulics.PhoneText;
                        InfoItemText += "\n";
                        JournalText.GetComponent<Text>().text = InfoItemText;
                        PhoneChek++;
                    }
                    if (Input.GetKeyDown(KeyCode.E) && PhoneChek1 == 0)
                    {

                        timeScript.timeLeft -= Random.Range(180f, 360f);
                        string opisanie = "На телефоне был найден чат https://t.me/ChatBombsAndGuns.";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.PhoneText + "\n" + opisanie;
                        JournalText.GetComponent<Text>().text = "\n" + opisanie;
                        TestAKM1++;
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && PhoneChek1 != 0)
                    {
                        string opisanie = "На телефоне был найден чат https://t.me/ChatBombsAndGuns.";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.PhoneText + "\n" + opisanie;
                    }

                    value = true;
                }
                
        
                break;
            case "akm 1":
                {
                    bool f = Fpresseed();

                    PickUpInfo.GetComponent<Text>().text = "Осмотреть АКМ";
                    if (FbuttonPressed && TestAKM < 1)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = ulics.AKText + "\n" + "Желаете отправить предмет на экспертизу (E - да; F - нет): расчетное время 5 до 10 минут";
                        InfoItemText += ulics.AKText;
                        InfoItemText += "\n";
                        JournalText.GetComponent<Text>().text = InfoItemText;
                        TestAKM++;
                    }
                    if (Input.GetKeyDown(KeyCode.E) && TestAKM1 == 0)
                    {

                        timeScript.timeLeft -= Random.Range(300f, 600f);
                        string opisanie = "Автомат был потерян на учениях в 69-ом. Эта зацепка ничего не даст.";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.AKText + "\n" + opisanie;
                        JournalText.GetComponent<Text>().text = "\n" + opisanie;
                        TestAKM1++;
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && TestAKM1 != 0)
                    {
                        string opisanie = "Автомат был потерян на учениях в 69-ом. Эта зацепка ничего не даст.";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.AKText + "\n" + opisanie;
                    }

                    value = true;
                }
                break;
            case "selitra 1":
                {
                    bool f = Fpresseed();

                    print("detected");

                    PickUpInfo.GetComponent<Text>().text = "Осмотреть селитру";
                    InfoItemTextUI.GetComponent<Text>().text = ulics.SelitraText;
                    if (FbuttonPressed && TestSelitra == 0)
                    {
                        InfoItemText += ulics.SelitraText;
                        InfoItemText += "\n";
                        JournalText.GetComponent<Text>().text = InfoItemText;
                        print("zapis");
                        print(TestSelitra);

                        TestSelitra++;
                    }
                    value = true;
                }
                break;
            case "notebook 1":
                {
                    bool f = Fpresseed();

                    PickUpInfo.GetComponent<Text>().text = "Осмотреть ноутбук";
                    InfoItemTextUI.GetComponent<Text>().text = ulics.NoutText;
                    if (FbuttonPressed && TestNote == 0)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = ulics.NoutText + "\n" + "Желаете отправить предмет на экспертизу (E - да; F - нет): расчетное время 1 до 2 минут";
                        InfoItemText += ulics.NoutText;
                        InfoItemText += "\n";
                        JournalText.GetComponent<Text>().text = InfoItemText;
                    }
                    if (Input.GetKeyDown(KeyCode.E) && TestNote1 == 0)
                    {

                        timeScript.timeLeft -= Random.Range(60f, 120f);
                        string opisanie = "На ПК в истории найден сайт https://guns-and-bombs-1.mozello.com/ ";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.NoutText + "\n" + opisanie;
                        JournalText.GetComponent<Text>().text = "\n" + opisanie;
                        TestNote1++;
                    }
                    else if (TestNote1 != 0)
                    {
                        string opisanie = "На ПК в истории найден сайт https://guns-and-bombs-1.mozello.com/ ";
                        InfoItemTextUI.GetComponent<Text>().text = ulics.NoutText + "\n" + opisanie;
                    }

                    value = true;
                }
                break;
            case "tumbochka1":
                {
                    if(key)
                    {
                        PickUpInfo.GetComponent<Text>().text = "Осмотреть тумбочку";
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            BoxScript box = HitInfo.collider.gameObject.GetComponent<BoxScript>();
                            Tumba.Play();
                            box.isOpen = !box.isOpen;
                        }
                    }else
                    {
                        PickUpInfo.GetComponent<Text>().text = "Нужен ключ";
                    }
                    value = true;
                }
                break;
            case "key 1":
                {
                    bool f = Fpresseed();

                    PickUpInfo.GetComponent<Text>().text = "Осмотреть ключ";
                    if (FbuttonPressed && key == false)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Обычный ключ, из тех что что-то отпирает" + "\n" + "Подобать? E - Да, F - нет";
                    }
                    if (Input.GetKeyDown(KeyCode.E) && key == false)
                    {
                        key = true;
                        FbuttonPressed = false;
                        InfoItemUI.SetActive(false);
                        InfoItemTextUI.SetActive(false);
                        PickUpInfo.SetActive(true);
                        HitInfo.collider.gameObject.SetActive(false);
                        move.lockCursor();
                    }

                    value = true;
                }
                break;
            case "diary 1":
                {
                    bool f = Fpresseed();

                    PickUpInfo.GetComponent<Text>().text = "Осмотреть дневник";
                    InfoItemTextUI.GetComponent<Text>().text = ulics.DiaryText;
                    value = true;
                }
                break;
            case "grenate":
                {
                    bool f = Fpresseed();
                    PickUpInfo.GetComponent<Text>().text = "Осмотреть гранату";

                    print("detected");
                    if (f)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Наступательная граната Ф-1. Добыта незаконным путем, как и большинство вещей в этой комнате";
                    }
                    
                    value = true;
                }
                break;
            case "syringe 1":
                {
                    bool f = Fpresseed();
                    PickUpInfo.GetComponent<Text>().text = "Осмотреть шприц";

                    print("detected");
                    if (f)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Шриц, 10-ти кубовый, имеются частицы крови на игле";
                    }

                    value = true;
                }
                break;
            case "player 1":
                {
                    bool f = Fpresseed();
                    PickUpInfo.GetComponent<Text>().text = "Осмотреть проигрыватель";

                    print("detected");
                    if (f)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Проигрыватель Вега 106 стерео, прямо как у меня";
                    }

                    value = true;
                }
                break;
            case "bottle":
                {
                    bool f = Fpresseed();
                    PickUpInfo.GetComponent<Text>().text = "Осмотреть бутылку";

                    print("detected");
                    if (f)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Дешевый алкоголь. Бутылка может использоваться, как резервуар для коктеля молотова";
                    }

                    value = true;
                }
                break;
            case "Kanistra":
                {
                    bool f = Fpresseed();
                    PickUpInfo.GetComponent<Text>().text = "Осмотреть канистра";

                    print("detected");
                    if (f)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Советская, слегка ржавая канистра с соляркой";
                    }

                    value = true;
                }
                break;
            case "Myxa":
                {
                    bool f = Fpresseed();
                    PickUpInfo.GetComponent<Text>().text = "Осмотреть гранaтомет";

                    print("detected");
                    if (f)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Муха или же РПГ-18" + "\n" + "Сдать на экспертизу? Расчётное время - от 5 до 10 минут\nЕ - да, F - нет";
                    }
                    if (Input.GetKeyDown(KeyCode.E) && myxa == 0)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Муха или же РПГ-18" + "\n" + "Подняв архивы штаб узнал что это РПГ со времен развала, нечайно испарилось, как и многия вооружения в то время";
                        timeScript.timeLeft -= Random.Range(300f, 600f);
                        myxa++;
                    }
                    else if (f && myxa > 0)
                    {
                        InfoItemTextUI.GetComponent<Text>().text = "Муха или же РПГ-18" + "\n" + "Подняв архивы штаб узнал что это РПГ со времен развала, нечайно испарилось, как и многия вооружения в то время";
                    }
                    value = true;
                }
                break;
        }
        return value;
    }
}


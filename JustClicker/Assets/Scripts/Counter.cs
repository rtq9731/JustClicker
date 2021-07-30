using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] Text countText = null;
    System.Int16 count = 2560;

    public bool isChanging = false;

    public System.Int16 Count { 
        get { return count; } 
        set 
        {
            if (value <= 0)
            {

                if (!isChanging)
                {
                    isChanging = true;
                    GetComponent<ImageChanger>().CallNewEgg();
                }

                return;
            }

            count = value;
            SaveData();

            if (count % 256 == 0)
            {
                GetComponent<ImageChanger>().ChangeImage((ushort)((count / 256) - 1));
            }

            SaveData();
            countText.text = count.ToString();
        }}

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
    }

    void SaveData()
    {
        PlayerPrefs.SetString("count", count.ToString());
    }

    void LoadData()
    {
        Count = System.Int16.Parse(PlayerPrefs.GetString("count", "2560"));
        GetComponent<ImageChanger>().ChangeImage((ushort)(count / 256));
    }
}

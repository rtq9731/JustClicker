using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] Sprite[] egg_Sprites;
    [SerializeField] Image egg_Image;
    [SerializeField] GameObject egg_BrokenUp;
    [SerializeField] GameObject egg_BrokenDown;

    public void ChangeImage(ushort imageNum)
    {
        if(imageNum < egg_Sprites.Length)
        {
            egg_Image.sprite = egg_Sprites[imageNum];
        }
    }

    public void CallNewEgg()
    {
        Debug.Log("전환 시작");
        DOTween.CompleteAll();
        egg_Image.rectTransform.DOScale(0,0);
        egg_BrokenUp.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        egg_BrokenDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        egg_BrokenUp.SetActive(true);
        egg_BrokenDown.SetActive(true);
        Sequence seq = DOTween.Sequence();

        seq.Play();
        seq.Append(egg_BrokenDown.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-350, 250), 0.5f).SetEase(Ease.OutQuint));
        seq.Join(egg_BrokenUp.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-350, 250), 0.5f).SetEase(Ease.OutQuint));

        seq.Append(egg_BrokenDown.GetComponent<RectTransform>().DOAnchorPosX(1400, 0.25f));
        seq.Join(egg_BrokenUp.GetComponent<RectTransform>().DOAnchorPosX(-1400, 0.25f));

        seq.Join(egg_Image.rectTransform.DOScale(1, 0.25f));
        seq.OnComplete(() =>{
            GetComponent<Counter>().Count = 2560;
            GetComponent<Counter>().isChanging = false;
            egg_BrokenUp.SetActive(false);
            egg_BrokenDown.SetActive(false);
            Debug.Log("전환 완료!");
            });

    }

    public void HitAnimAndSound()
    {
        DOTween.CompleteAll();
        egg_Image.gameObject.transform.DOScale(1.1f, 0.1f).OnComplete(() =>
       {
           egg_Image.gameObject.transform.DOScale(1f, 0.1f);
       });
    }

}

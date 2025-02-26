using UnityEngine;
using TMPro;
using System.Globalization;

public class ChapterTitle : MonoBehaviour
{
    [SerializeField] string num;
    [SerializeField] string title;
    public TextMeshProUGUI chapterNumber;
    public TextMeshProUGUI chapterTitle;

    public Animation numberAnim;
    public Animation titleAnim;

    private float animDuration = 5f;

    private void Start()
    {
        ShowTitle(num, title);
    }

    public void ShowTitle(string number, string title)
    {
        chapterNumber.text = number;
        chapterTitle.text = title;
        numberAnim.Play();
        titleAnim.Play();

        Invoke(nameof(DestroySelf), animDuration);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}

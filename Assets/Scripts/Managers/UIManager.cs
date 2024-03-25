using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text FinalScoreTxt;
    [SerializeField] private TMP_Text healthTxt;
    [SerializeField] private GameObject nukeIndicator;

    [SerializeField] Player player;

    private Image[] nukeCount;

    private void Start()
    {
        nukeIndicator = FindObjectOfType<GridLayoutGroup>().gameObject;
        nukeCount = nukeIndicator.GetComponentsInChildren<Image>();
    }

    public void UpdateScore()
    {
        scoreTxt.SetText("Score: " + GameManager.GetInstance().scoreManager.GetScore().ToString("00"));
        highScoreTxt.SetText("HighScore: " + GameManager.GetInstance().scoreManager.GetHighScore().ToString("00"));
    }

    public void UpdateHealth()
    {
        if (player.health != null)
        {
            healthTxt.SetText("Health: " + player.health.GetHealth());
        }
    }

    public void UpdateNukeCount()
    {
        for (int i = 0; i < nukeCount.Length; i++)
        {
            if (i < player.ShowNuke())
            {
                nukeCount[i].gameObject.SetActive(true);
            }
            else
            {
                nukeCount[i].gameObject.SetActive(false);
            }
        }
    }

    public void UpdateFinalScore()
    {

        FinalScoreTxt.SetText("HighScore: " + GameManager.GetInstance().scoreManager.GetHighScore().ToString("00"));
    }

    public void SetPlayer(GameObject _player)
    {
        player = _player.GetComponent<Player>();
    }
}

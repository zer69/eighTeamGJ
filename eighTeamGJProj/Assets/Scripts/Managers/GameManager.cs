using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image GameOverScreen;

    public float targetAlpha;
    public float FadeRate;

    public GameObject quitButton;
    public GameObject restartButton;

    public void GameOver(bool state)
    {
        StartCoroutine(FadeIn(GameOverScreen));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator FadeIn(Image image)
    {
        targetAlpha = 1.0f;
        Color curColor = image.color;
        while ((Mathf.Abs(1.0f - curColor.a)) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        quitButton.SetActive(true);
        restartButton.SetActive(true);
  
    }

    public void Restart()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

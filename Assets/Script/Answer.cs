using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public Player player;
    Player playerEnemy;
    public Enemy enemy;
    public GameObject DialogPanel;
    public GameObject win;
    public GameObject lose;
    bool isClickabble = true;

    public void Answers(bool answer)
    {
        if (answer)
        {
            player.PlayerAttack();
            enemy.EnemyDamage();
            player.ChangeHealth(5);
            enemy.ChangeHealth(-100);
            StartCoroutine(MovePanel());
        }

        else
        {
            enemy.EnemyAttack();
            player.PlayerDamage();
            player.ChangeHealth(-35);
            enemy.ChangeHealth(5);
        }

        //StartCoroutine(MovePanel());
        //DialogPanel.SetActive(true);
        Player winner = GetWinner();
    }

    IEnumerator MovePanel()
    {
        yield return new WaitForSeconds(2);
        DialogPanel.SetActive(true);
    }

    IEnumerator WinPanel()
    {
        yield return new WaitForSeconds(2);
        win.SetActive(true);
    }

    IEnumerator LosePanel()
    {
        yield return new WaitForSeconds(2);
        lose.SetActive(true);
    }

    private Player GetWinner()
    {
        if (player.Health == 0)
        {
            StartCoroutine(LosePanel());
            // lose.SetActive(true);
            return playerEnemy;
        }
        else if (enemy.Health == 0 && this.tag == "Boss")
        {
            StartCoroutine(WinPanel());
            // win.SetActive(true);
            return player;
        }
        else
        {
            return null;
        }
    }

    public void SetClickabble(bool value)
    {
        isClickabble = value;
    }
}

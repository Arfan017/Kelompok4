using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    public float Health;
    public float MaxHealth;
    public Transform PosAtkEnemy;
    public Transform PosDmgEnemy;
    public Transform posEnemy;
    private Tweener animationTweener;

    public void ChangeHealth(float amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health,0,100);
        healthBar.UpdateHealthBar(Health/MaxHealth);
    }

    public void EnemyAttack(){
        animationTweener = posEnemy
            .DOMove(PosAtkEnemy.position, 0.5f)
            .SetLoops(2, LoopType.Yoyo)
            .SetDelay(0.2f);
    }

    public void EnemyDamage(){
        animationTweener = posEnemy
            .DOMove(PosDmgEnemy.position, 0.5f)
            .SetLoops(2, LoopType.Yoyo)
            .SetDelay(0.2f);
    }
}

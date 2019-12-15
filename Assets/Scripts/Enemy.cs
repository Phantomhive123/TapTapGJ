using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float pushScale = 1;
    [SerializeField]
    private float moveScale = 1;
    private bool movingToward = false;
    private bool inLight = false;
    private Transform lightOrigin = null;
    private Transform movingTarget = null;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (inLight)
        {
            Vector3 direction = (transform.position - lightOrigin.position).normalized;
            transform.Translate(direction * Time.deltaTime * pushScale);
        }
        else if(movingToward)
        {
            Vector3 direction = (movingTarget.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * moveScale);
        }

        if (!inLight && !movingToward)
        {
            if (!CurrentAnimTheSame("Idle"))
                anim.Play(Animator.StringToHash("Idle"));
        }
        else if (inLight) 
        {
            if (!CurrentAnimTheSame("Push"))
                anim.Play(Animator.StringToHash("Push"));
        }
        else if(movingToward)
        {
            if (!CurrentAnimTheSame("MoveToward"))
                anim.Play(Animator.StringToHash("MoveToward"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Light"))
        {
            inLight = true;
            lightOrigin = collision.transform.parent.transform;
            return;
        }
        if(collision.gameObject.CompareTag("PlayerView"))
        {
            SoundManager.Instance.PlayPatchingSound();
            movingToward = true;
            movingTarget = collision.transform;
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            ScopeTrigger player = collision.GetComponentInParent<ScopeTrigger>();
            player.Shrink();
            SendEnemyAttackData(collision);
            anim.Play(Animator.StringToHash("Break"));
            enabled = false;//播放破碎动画
            SoundManager.Instance.PlayAttachSound();
            return;
        }
        if (collision.gameObject.CompareTag("Sprite"))
        {
            SpriteAnimController spriteAnimController = collision.GetComponent<SpriteAnimController>();
            if (spriteAnimController)
                collision.GetComponent<SpriteAnimController>().PlayDestroyAnim();
            anim.Play(Animator.StringToHash("Break"));
            EnemyAttackSprite(collision);
            enabled = false;
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light")) 
        {
            lightOrigin = null;
            inLight = false;
        }
        else if(collision.gameObject.CompareTag("PlayerView"))
        {
            if (movingTarget == null) return;
            if (collision.gameObject != movingTarget.gameObject) return;
            movingTarget = null;
            movingToward = false;
        }
    }

    private bool CurrentAnimTheSame(string name)
    {
        return anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == name;
    }

    private void AnimDestroy()
    {
        Destroy(gameObject);
    }

    private void SendEnemyAttackData(Collider2D collision)
    {
        if(GameMode.Insatance.isBattle)
        {
            if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Group1")))
            {
                BattleGameManager.Instance.NumOfPlayer1--;
            }
            else
            {
                BattleGameManager.Instance.NumOfPlayer2--;
            }
        }
        else
        {
            SingleGameManager.Instance.NumOfPlayer1--;
        }
    }

    private void EnemyAttackSprite(Collider2D collision)
    {
        if (GameMode.Insatance.isBattle)
        {
            if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Group1")))
            {
                BattleGameManager.Instance.NumOfGroup1--;
            }
            else
            {
                BattleGameManager.Instance.NumOfGroup2--;
            }
        }
        else
        {

        }
    }
}

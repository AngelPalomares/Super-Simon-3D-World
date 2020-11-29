using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static BossController instance;

    public Animator anim;

    public GameObject Victory;
    public float waitToShowExit;

    public enum BossPhase { intro, phase1, phase2, phase3, end};

    public BossPhase currentPhase = BossPhase.intro;

    public int bossMusic, bossDeath, bossDeathShout, bossHit;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        AudioManager.instance.PlayMusic(bossMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isRespawning)
        {
            currentPhase = BossPhase.intro;

            anim.SetBool("Phase1", false);
            anim.SetBool("Phase2", false);
            anim.SetBool("Phase3", false);

            AudioManager.instance.PlayMusic(AudioManager.instance.levelMusicToPlay);

            gameObject.SetActive(false);

            BossActivator.instance.gameObject.SetActive(true);
            BossActivator.instance.entrance.SetActive(true);

            GameManager.instance.isRespawning = false;

        }
    }

    public void DamaeBoss()
    {
        AudioManager.instance.PlaySFX(bossHit);
        currentPhase++;
        if (currentPhase != BossPhase.end)
        {
            anim.SetTrigger("Hurt");
        }

        switch (currentPhase)
        {
            case BossPhase.phase1:
                anim.SetBool("Phase1", true);
                break;

            case BossPhase.phase2:
                anim.SetBool("Phase2", true);
                anim.SetBool("Phase1", false);
                break;

            case BossPhase.phase3:
                anim.SetBool("Phase3", true);
                anim.SetBool("Phase2", false);
                break;

            case BossPhase.end:
                anim.SetTrigger("End");
                StartCoroutine(EndBoss());
                break;
        }
    }

    IEnumerator EndBoss()
    {
        AudioManager.instance.PlaySFX(bossDeath);
        AudioManager.instance.PlaySFX(bossDeathShout);
        AudioManager.instance.PlayMusic(AudioManager.instance.levelMusicToPlay);

        yield return new WaitForSeconds(waitToShowExit);
        Victory.SetActive(true);
    }
}

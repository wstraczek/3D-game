using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RifleScript : MonoBehaviour {
    private float damage = 30f;
    private float range = 100f;
    private int enemies = 5;

    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;
    public AudioSource dieSound;
    public Text enemiesText;

    public Camera fpsCam;
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        ShowEnemies();
    }

    void Shoot() {
        muzzleFlash.Play();
        shootSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
            if (enemy != null) {
                if (enemy.getHealth() - damage <= 0f) killEnemy();
                enemy.takedamage(damage);
            }
        }
    }

    public void killEnemy() {
        enemies--;
        dieSound.Play();
    }

    public void ShowEnemies() {
        string message = enemies.ToString();
        enemiesText.text = message;
    }

    

}


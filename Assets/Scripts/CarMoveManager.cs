using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CarMoveManager : MonoBehaviour
{
    public GameObject explosionPS;
    public int speedForce = 150;
    public int boostedForce = 200;
    public float velocity;

    public Text coinText;
    public Text lifeText;
    public Text distanceText;
    public Text fuelText;
    public Image fuelImage;

    public Text GO_DistanceCoveredTxt;
    public Text GO_CoinCollectedTxt;
    public GameObject playPanel;
    public GameObject gameOverPanel;

    private Rigidbody rb;
    private int coinCount;
    private const short moveOffset = 2;
    private short totalHitcount;
    private float distanceCovered;
    private float startPos;
    private bool boosterBool;

    private float currentTime = 10f;
    private float maxTime = 10f;
    private short maxSpeed = 15;

    // Use this for initialization
    void Start()
    {
        startPos = -7f;
        coinCount = 0;
        totalHitcount = 3;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (boosterBool)
        {
            rb.AddForce(Vector3.forward * boostedForce);
            fuelText.text = "Booster";
        }
        else if (rb.velocity.magnitude < maxSpeed && currentTime >0)
        {
            velocity = rb.velocity.magnitude;
            rb.AddForce(Vector3.forward * speedForce);
            distanceCovered = transform.position.z - startPos;
            if (currentTime >0)
            {
                currentTime -= 0.1f * Time.fixedDeltaTime;
            }
            else
            {
                gameOver();
            }
        }
    }

    private void gameOver()
    {
        gameObject.SetActive(false);
        GO_CoinCollectedTxt.text = "Coins Collected: " + coinCount;
        GO_DistanceCoveredTxt.text = "Distance Covered: " + distanceCovered;
        playPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        if (transform.tag.Equals("Player"))
        {
            if (Input.GetKeyDown("left"))
            {
                moveLeft();
            }
            if (Input.GetKeyDown("right"))
            {
                moveRight();
            }
        }
    }

    private void UpdateUI()
    {
        if (!boosterBool)
        {
            fuelImage.fillAmount = currentTime / maxTime;
            fuelText.text = "Fuel: " + (int)(currentTime / maxTime * 100);
        }
    }

    private void LateUpdate()
    {
        UpdateUI();
        coinText.text = "Coin Count: " + coinCount;
        lifeText.text = "Ramining Life: " + totalHitcount;
        distanceText.text = "Distance Covered: " + (int)distanceCovered;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Traffic"))
        {
            Debug.Log("Collision object name: " + col.gameObject.name);
            if (totalHitcount > 0)
            {
                totalHitcount--;
                Debug.Log("Hit Count: " + totalHitcount);
                GameObject exposionPs = Instantiate(explosionPS, col.gameObject.transform.position, Quaternion.identity);
                Destroy(col.gameObject);
                Destroy(exposionPs, 5f);
            }
            else
            {
                gameOver();
            }
        }

        if (col.gameObject.tag.Equals("Fuel"))
        {
            Debug.Log("Fuel collision");
            if (currentTime < 5)
            {
                currentTime = currentTime + maxTime / 2;
            }
            else
            {
                currentTime = 10f;
            }
            col.gameObject.SetActive(false);
        }

        if (col.gameObject.tag.Equals("Booster"))
        {
            Debug.Log("Booster collision");
            boosterBool = true;
            StopCoroutine(waitForBooster());
            StartCoroutine(waitForBooster());
            col.gameObject.SetActive(false);
        }

        if (col.gameObject.tag.Equals("Coins"))
        {
            Debug.Log("Coins collision");
            coinCount++;
            col.gameObject.SetActive(false);
        }
    }

    private IEnumerator waitForBooster()
    {
        yield return new WaitForSecondsRealtime(10f);
        boosterBool = false;
        rb.velocity = Vector3.forward * 10f;
    }

    public void moveRight()
    {
        if (transform.position.x <= 2)
        {
            transform.Translate(Vector3.right * moveOffset);
        }
    }

    public void moveLeft()
    {
        if (transform.position.x >= -2)
        {
            transform.Translate(Vector3.left * moveOffset);
        }
    }
}

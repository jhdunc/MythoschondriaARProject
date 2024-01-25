using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plant growth states as an enum list
public enum GrowthState
{
    Seeded, Sprout, Growing, Harvest
}

public class PlantScript : MonoBehaviour
{
    [SerializeField] GameObject harvestTime;
    private bool hasParticle;
    private ParticleSystem shinyThing;

    private int idSoil; // parent ID (soil plot, used for wet/dry communication)
    [SerializeField] ItemClass itemInfo;
    public GameObject poofPrefab;
    GameObject poofPart;

    public GrowthState currentState; // variable to hold information on plant's current state (from the enum list)

    // GameObject variables to hold the model for each growth state
    public GameObject seeded;
    public GameObject sprout;
    public GameObject growing;
    public GameObject harvest;

    [SerializeField] GameObject timerPrefab; // UI prefab for the timer bar

    private Vector3 growSproutScalar;
    [SerializeField] TimerController timer;
    [SerializeField] TomatoGrow growTomaat;

    public float growTime; // how long it takes this plant to grow per state

    public bool growthActive = false; // read whether or not the plant is currently growing, default false
    void Start()
    {
        // set all objects to inactive at start 
        // this is a safety measure in case someone forgets to manually set them inactive when in the prefabs
        seeded.SetActive(false);
        sprout.SetActive(false);
        growing.SetActive(false);
        harvest.SetActive(false);

        idSoil = transform.parent.GetComponent<SoilScript>().id;

        ChangeState(GrowthState.Seeded); // when instantiated, change growth state to Seeded

        // check to make sure a grow time is set in the inspector
        // if no grow time is set, default is 30
        if (growTime == 0)
            growTime = 30f;

        growSproutScalar = new Vector3(0.08f, 0.08f, 0.08f); // the rate at which plants scale during sprout/growing states
    }
    void ChangeState(GrowthState newState) // a method to call when changing the plant's state. When called, will use one of the enum list things as the newState
    {
        currentState = newState; // set current state to the paramater used to call the method
        Vector3 xyz = new Vector3(0, 90, 0);
        Quaternion newRotation = Quaternion.Euler(xyz);
        Vector3 offestPos = new Vector3(0, .05f, 0);
        poofPart = Instantiate(poofPrefab, this.transform.position + offestPos, newRotation);
        StartCoroutine(DestroyParticle());
        
        switch (currentState) // use switch cases to determine behavior based on state.
        {
            // each case sets the previous state as inactive and the new state as active
            // it does this by comparing the case against the parameter newState
            case GrowthState.Seeded: 
                seeded.SetActive(true);
                growthActive = false;
                break;
            case GrowthState.Sprout:
                sprout.SetActive(true);
                sprout.transform.localScale = new Vector3(.4f, .4f, .4f);
                growthActive = false;
                break;
            case GrowthState.Growing:
                sprout.SetActive(false);
                growing.SetActive(true);
                growthActive = false;
                break;
            case GrowthState.Harvest:
                growing.SetActive(false);
                harvest.SetActive(true);
                growthActive = false;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // on a collision with the soil's trigger collision box, 
        // if the game object has the tag "seed" or "Tool" 
        if (other.gameObject.tag == "seed" || other.gameObject.tag == "Tool")
        {
            // set variable for the colliding object as a local variable
            // set up a local variable to hold the colliding item's ID# to identify what the tool is
            GameObject otherObj = other.gameObject;
            int saveItemID;

            // if the colliding object's tag is Tool
            if (otherObj.CompareTag("Tool"))
            {
                // Tell the Plot what tool is being used
                // by setting the local variable saveItemID to the colliding object's ID#

                saveItemID = otherObj.GetComponent<ToolScript>().itemInfo.itemID;

                // use switch cases to determine what happens based on that tool's item ID
                switch (saveItemID)
                {
                    case 100: // if item is a Hoe:
                        Destroy(gameObject); // destroy this game object 
                        break;
                    case 101: // if item is a Trowel:
                        Destroy(gameObject); // destroy this game object
                        break;
                    case 102:
                        if (!growthActive) // if the plant is not currently growing, then start growing.
                        StartCoroutine(GrowthCycle()); // start coroutine that will change the growth state
                        break;
                }

            }
        }
    }


    private IEnumerator GrowthCycle() // a coroutine to start the growth period for the plant
    {
        if (currentState != GrowthState.Harvest)
        {
            growthActive = true; // set bool to indicate plant is now growing
            timer.ResetTimer(0f);
            timer.SetMaxTime(growTime);
            yield return new WaitForSeconds(growTime); // wait a number of seconds equal to the variable growTime

            // once timer has elapsed, check current state and advance to the next state.
            if (currentState == GrowthState.Seeded)
            {
                ChangeState(GrowthState.Sprout);
                GameEvents.current.SoilDry(idSoil);
            }
            else if (currentState == GrowthState.Sprout)
            {
                ChangeState(GrowthState.Growing);
                GameEvents.current.SoilDry(idSoil);
            }
            else if (currentState == GrowthState.Growing)
            {
                ChangeState(GrowthState.Harvest);
                GameEvents.current.SoilDry(idSoil);

            }
        }


    }
    private void Update()
    {
        if (growthActive)
        {
            switch (currentState)
            {
                case GrowthState.Sprout:
                    if (sprout.transform.localScale.x < 1)
                    {
                        sprout.transform.localScale += growSproutScalar * Time.deltaTime;
                    }
                    break;
                case GrowthState.Growing:
                    if (growing.transform.localScale.x < 1)
                    {
                        growing.transform.localScale += growSproutScalar * Time.deltaTime;
                    }
                    if (growing.transform.localScale.x >= 1 && growTomaat != null)
                    {
                        growTomaat.StartGrowing();
                    }
                    break;
            }
        }
        #region Item Ready Particle
        /*        if (currentState == GrowthState.Harvest && !hasParticle)
                {
                    GameObject newParticle = Instantiate(harvestTime, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);
                    hasParticle = true;

                    newParticle.name = "ShinyThing";
                    shinyThing = GameObject.Find("ShinyThing").GetComponent<ParticleSystem>();
                }
                if (currentState == GrowthState.Harvest && hasParticle)
                {
                    shinyThing.Play();
                }
                if (hasParticle && currentState != GrowthState.Harvest)
                {
                    shinyThing.Stop();
                }*/
        #endregion
    }
    public void StopParticle()
    { shinyThing.Stop(); }

    public IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(poofPart);
    }
    public void DestroyPlantPrefab()
    {
        Destroy(gameObject);
    }
}
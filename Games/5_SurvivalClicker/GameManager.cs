using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] Text timeText;
    [SerializeField] Text populationText;
    [SerializeField] Text workerText;
    [SerializeField] Text civiliansText;
    [SerializeField] Text soldiersText;
    [SerializeField] Text foodText;
    [SerializeField] Text woodText;
    [SerializeField] Text ironText;
    [SerializeField] Text goldText;
    [SerializeField] Text farmText;
    [SerializeField] Text ironMineText;

    [Header("Values")]
    [SerializeField] int time;
    [SerializeField] int population;
    [SerializeField] int workers;
    [SerializeField] int civilians;
    [SerializeField] int soldiers;
    [SerializeField] int food;
    [SerializeField] int wood;
    [SerializeField] int iron;
    [SerializeField] int gold;
    [SerializeField] int farm;
    [SerializeField] int ironMine;

    [Header("Buttons")]
    [SerializeField] Button woodButton;
    [SerializeField] Button ironButton;
    [SerializeField] Button exploreButton;
    [SerializeField] Button huntButton;
    [SerializeField] Button raidButton;
    [SerializeField] Button buyFoodButton;

    [Header("Animators")]
    [SerializeField] Animator raidAnimator;
    [SerializeField] Animator huntAnimator;

    [Header("Objects")]
    [SerializeField] GameObject textPrefab;

    [SerializeField] Transform textPosition;

    List<string> lists = new List<string>();
    Queue<GameObject> queses = new Queue<GameObject>();

    int day = 2;

    bool isGameOver;
    bool isPlodan;


    private void Start()
    {
        population = civilians + workers + soldiers;

        isPlodan = true;

        NewValues();
        StartCoroutine(DayIncrease());

        StartCoroutine(FoodLose());
        StartCoroutine(PopulationGain());
        StartCoroutine(FarmingFood());
        StartCoroutine(IronMine());
    }

    void NewValues()
    {
        populationText.text = population.ToString();
        workerText.text = $"{workers}";
        civiliansText.text = $"{civilians}";
        soldiersText.text = $"{soldiers}";
        goldText.text = $"{gold}";
        foodText.text = food + " Kg";
        woodText.text = $"{wood} m";
        ironText.text = $"{iron} Kg";
        farmText.text = $"{farm}";
        ironMineText.text = $"{ironMine}";
    }

    IEnumerator DayIncrease()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(day);
            time++;
            timeText.text = $"{time}. day";
        }
    }

    IEnumerator FoodLose()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(24);
            food -= (int)Random.Range((population + workers) * 0.3f, (population + workers) * 0.9f);
            foodText.text = food + "Kg";

            if (food <= 0)
            {
                population -= (int)Random.Range(population * 0.1f, population * 0.5f);
                populationText.text = population.ToString();
                //notificatonText.text += "\nWe do not have enough food and people are dying!";
                Notifications("\nWe do not have enough food and people are dying!");

            }
        }
    }

    IEnumerator PopulationGain()
    {
        while (!isGameOver)
        {

            yield return new WaitForSeconds(Random.Range(day, day * 3));

            if (population > 2 && isPlodan)
            {
                int popBoost = Random.Range(0, 21);

                population = population + popBoost;

            }

            populationText.text = population.ToString();

        }
    }

    public void HuntButton()
    {
        Invoke(nameof(HuntedFood), day);
        huntButton.gameObject.SetActive(false);

    }

    private void HuntedFood()
    {
        int foodChange = Random.Range(-2, population);
        food += foodChange;
        foodText.text = $"{food} Kg";
        exploreButton.gameObject.SetActive(true);
        exploreButton.interactable = true;
        huntAnimator.SetBool("isMove", false);
    }

    public void GatherWoodButton()
    {
        Invoke(nameof(GatherWood), day * 2);
        woodButton.interactable = false;
    }

    private void GatherWood()
    {
        int woodChange = Random.Range(5, population);
        wood += woodChange;
        woodText.text = $"{wood} m";
        woodButton.interactable = true;
    }


    public void GatherIronButton()
    {
        Invoke(nameof(GatherIron), day * 6);
        ironButton.interactable = false;
    }

    private void GatherIron()
    {
        int ironChange = Random.Range(population / 2, population);
        iron += ironChange;
        ironText.text = $"{iron} Kg";
        ironButton.interactable = true;

        Notifications($"We have gathered {ironChange} Kg of iron");
    }

    public void BuildIronMine()
    {

        if (wood >= 20 && gold > 50 && population >= 7)
        {
            wood -= 20;
            gold -= 50;
            int populationChange = 5;
            ironMine++;

            population -= populationChange;
            workers += populationChange;

            Notifications("We have built an iron mine.");
        }
        else
        {
            Notifications("Not enough resources!");
        }
        NewValues();
    }

    public void DismantleIronMine()
    {
        if (ironMine >= 1)
        {
            ironMine--;


        }

    }

    IEnumerator IronMine()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(day);
            
            int foodChange = ironMine * 15;
            int woodChange =ironMine * 5;
            wood -= woodChange;
            iron += ironMine * 20;

        NewValues();
        }
    }

    public void BuildFarm()
    {

        if (wood >= 20 && iron >= 10 && population >= 4)
        {
            wood -= 20;
            iron -= 10;
            int populationChange = 2;
            population -= populationChange;
            workers += populationChange;
            farm++;

            Notifications("We built a farm.");

        }

        else
        {
            Notifications("Not enough resources!");
        }

        NewValues();

    }

    IEnumerator FarmingFood()
    {
        while (!isGameOver)
        {

        yield return new WaitForSeconds(day);
        int foodGain = farm * Random.Range(0,25);
            gold -= 1;
        food += foodGain;

            NewValues();
        }
    }

    IEnumerator Taxes()
    {
        yield return new WaitForSeconds(day * 7);

        if (population >= 200)
        {
            TaxThePopulation();
        }
    }

    private void TaxThePopulation()
    {
        int goldIncrease = (int)(population * 0.4f);
        gold += goldIncrease;
        goldText.text = $"{gold} gold";
    }

    public void SellWoodButton()
    {
        if (wood >= 10)
        {
            int woodDecrease = 10;
            wood -= woodDecrease;
            gold += 2;
            woodText.text = $"{wood} m";
            goldText.text = $"{gold} gold";
        }

        else
        {
            //notificatonText.text += "\nGather more wood, dumbass loser";
            Notifications("\nGather more wood, dumbass loser");
        }
    }


    public void SellIronButton()
    {
        if (iron >= 10)
        {
            int ironDecrease = 10;
            iron -= ironDecrease;
            gold += 6;
            ironText.text = $"{iron} Kg";
            goldText.text = $"{gold} gold";
        }

        else
        {
           // notificatonText.text += "\nGather more iron.";
            Notifications("\nGather more iron.");
        }
    }

    public void BuyFood()
    {
        if (gold >= 10)
        {
            gold -= 10;
            food += 50;

            NewValues();
        }

        else
        {
            Notifications("Nema para");
        }
    }


    public void ExplorationButton()
    {
        StartCoroutine(Explore());
    }

    IEnumerator Explore()
    {
        exploreButton.interactable = false;
        yield return new WaitForSeconds(day);

        int coinFlip = Random.Range(0, 3);

        if (coinFlip <= 2)
        {
            huntButton.gameObject.SetActive(true);
            huntAnimator.SetBool("isMove", true);
           // notificatonText.text += "\nYou have discovered hunting ground";
            Notifications("\nYou have discovered hunting ground");
          
        }
       else if (coinFlip == 1)
        {
            raidButton.gameObject.SetActive(true);
            raidAnimator.SetBool("isStart", true);
           // notificatonText.text += "\nYou have discovered enemy town";
            Notifications("You have discovered enemy town");
        }

        else
        {
            exploreButton.interactable = true;
           // notificatonText.text += "Exploration was not succesful";
            Notifications("Exploration was not succesful");
        }
    }

    public void RaidButton()
    {
       Invoke(nameof(Raid), day * 4);
       raidButton.gameObject.SetActive(false);
        raidAnimator.SetBool("isStart", false);
    }

    private void Raid()
    {
        exploreButton.interactable = true;
        if (population >= 200)
        {
            int coinFlip = Random.Range(0, 3);

            if (coinFlip == 0)
            {
                int populationChange = Random.Range(population / 2, population);
                int goldChange = Random.Range(gold / 2, gold);
                int foodChange = Random.Range(food / 2, food);
                int woodChange = Random.Range(wood / 2, wood);
                int ironChange = Random.Range(iron / 2, iron);

                population -= populationChange;
                gold -= goldChange;
                food -= foodChange;
                wood -= woodChange;
                iron -= ironChange;

                Notifications("Git Gud");



                NewValues();


            }
            else if (coinFlip == 1)
            {
                int populationChange = Random.Range(-population / 2, population / 2);
                int goldChange = Random.Range(-gold / 2, gold / 2);
                int foodChange = Random.Range(-food / 2, food / 2);
                int woodChange = Random.Range(-wood / 2, wood / 2);
                int ironChange = Random.Range(-iron / 2, iron / 2);

                population -= populationChange;
                gold -= goldChange;
                food -= foodChange;
                wood -= woodChange;
                iron -= ironChange;

                NewValues();

               // notificatonText.text += "\nSometimes mabey good sometimes mabey shit";
                Notifications("\nSometimes mabey good sometimes mabey shit");
            }
            else
            {
                int populationChange = Random.Range(population / 2, population);
                int goldChange = Random.Range(gold / 2, gold);
                int foodChange = Random.Range(food / 2, food);
                int woodChange = Random.Range(wood / 2, wood);
                int ironChange = Random.Range(iron / 2, iron);

                population += populationChange;
                gold += goldChange;
                food += foodChange;
                wood += woodChange;
                iron += ironChange;

                NewValues();

                //notificatonText.text += "\nEverything is Cache money";
                Notifications("\nEverything is Cache money");
            }
        }
        else
        {
           // notificatonText.text += "\nMo'� ga jebat";
            Notifications("\nMo'� ga jebat");
        }
    }


    IEnumerator RandomEventGenerator()
    {
        yield return new WaitForSeconds(Random.Range(day, day * 7));
        isPlodan = true;

        int coinFlip = Random.Range(0, 101);

        if (coinFlip <= 7)
        {
            Flood();
        }

        if (coinFlip > 7 && coinFlip <= 15)
        {
            Sifilis();
        }

        if (coinFlip > 16 && coinFlip <= 25)
        {
            Festival();
        }
    }


    private void Festival()
    {
        int populationChange =(int) Random.Range(population * 0.25f, population * 0.4f);
        int goldChange =(int) Random.Range(population * 0.25f, population * 0.4f);
        int foodChange =(int) Random.Range(population * 0.1f, population * 0.25f);

        population += populationChange;
        gold += goldChange;
        food -= foodChange;

       // notificatonText.text += "\nDodji na Ultru";
        Notifications("\nDodji na Ultru");

        int coinFlip = Random.Range(0, 5);

        if (coinFlip == 1)
        {
            Sifilis();
        }

        NewValues();

    }

    private void Flood() 
    {
        int populationChange = (int)(Random.Range(population * 0.2f, population * 0.8f));
        int goldChange = (int)(Random.Range(gold * 0.3f, gold * 0.7f));
        int foodChange = (int)(Random.Range(food * 0.2f, food * 0.5f));

        population -= populationChange;
        gold -= goldChange;
        food -= foodChange;

        NewValues();

        //notificatonText.text += "\nKako se zove ovo jezero";
        Notifications("\nKako se zove ovo jezero");
    }

    private void Sifilis()
    {
        isPlodan = false;
        SifilisEffect();
    }

    private void SifilisEffect()
    {
        int populationChange = 69;
        population -= populationChange;

       // notificatonText.text += "\nBurn baby, burn!";

        Notifications("Burn baby, burn!");

        NewValues();
    }

    private void Notifications(string notification)
    {

        if (textPrefab == null || textPosition == null)
        {
            return;
        }

       Text tempText = textPrefab.GetComponent<Text>();
        tempText.text = notification;

        GameObject tempObject = Instantiate(textPrefab, textPosition);

        queses.Enqueue(tempObject);

        if (queses.Count > 5)
        {
            GameObject oldQueue = queses.Dequeue();
            Destroy(oldQueue);
        }
    }
}

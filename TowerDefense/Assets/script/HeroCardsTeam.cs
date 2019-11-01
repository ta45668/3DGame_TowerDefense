using UnityEngine;

public class HeroCardsTeam : MonoBehaviour
{
    public HeroDesign[] heroDesigns = new HeroDesign[6];
    public static HeroDesign[] HeroDesigns = new HeroDesign[6];
    public string[] heroName = new string[6];

    void Start()
    {
        GainHeroName();
        SetCardsTeam();
    }

    public void GainHeroName()
    {
        for (int i = 0; i < 6; i++)
        {
        heroName[i] = "SmallFireDragon/SmallFireDragon";

        }
    }

    public void SetCardsTeam()
    {
        for (int i = 0; i < heroDesigns.Length; i++)
        {
            heroDesigns[i].prefab = Resources.Load("Hero3D/" + heroName[i], typeof(object)) as GameObject;
            heroDesigns[i].cont = heroDesigns[i].prefab.GetComponent<HeroDesign3D>().price;
            HeroDesigns[i] = heroDesigns[i];


        }
        
    }
}

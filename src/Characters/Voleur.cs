using System;

public class Voleur
{
    // Attributs du voleur
    public int PointsDeVie { get; set; }
    public string TypeDArmure { get; set; }
    public int PuissanceDAttaquePhysique { get; set; }
    public int PuissanceDAttaqueMagique { get; set; }
    public double ChanceDesquive { get; set; }
    public double ChanceDeParade { get; set; }
    public double ChanceDeResistanceAuxSorts { get; set; }
    public int Vitesse { get; set; }
    public string Nom { get; set; }

    // Constructeur
    public Voleur(string nom)
    {
        Nom = nom;
        PointsDeVie = 80;
        TypeDArmure = "Cuir";
        PuissanceDAttaquePhysique = 55;
        PuissanceDAttaqueMagique = 0;
        ChanceDesquive = 15.0;
        ChanceDeParade = 25.0;
        ChanceDeResistanceAuxSorts = 25.0;
        Vitesse = 100;
    }

    // Compétences du voleur
    public void CoupBas(Voleur cible)
    {
        int degats;
        if (cible.PointsDeVie < 0.5 * cible.PointsDeVieInitial)
        {
            degats = (int)(PuissanceDAttaquePhysique * 1.5);
        }
        else
        {
            degats = PuissanceDAttaquePhysique;
        }
        cible.PointsDeVie -= degats;
        Console.WriteLine($"{Nom} inflige {degats} dégâts à {cible.Nom} avec Coup Bas.");
    }

    public void Evasion()
    {
        ChanceDesquive += 20;
        ChanceDeResistanceAuxSorts += 20;
        Console.WriteLine($"{Nom} utilise Evasion. Chance d'esquive et de résistance aux sorts augmentées de 20%.");
    }

    // Compétence passive
    public void PoignardsDansLeDos(Voleur attaquant)
    {
        int degats = 15;
        attaquant.PointsDeVie -= degats;
        Console.WriteLine($"{Nom} esquive et inflige {degats} dégâts à {attaquant.Nom} avec Poignards Dans Le Dos.");
    }

    // Méthode pour simuler une attaque et vérifier l'esquive
    public void Attaquer(Voleur cible)
    {
        Random rand = new Random();
        double chance = rand.NextDouble() * 100;
        if (chance < cible.ChanceDesquive)
        {
            Console.WriteLine($"{cible.Nom} esquive l'attaque de {Nom}.");
            cible.PoignardsDansLeDos(this);
        }
        else
        {
            int degats = PuissanceDAttaquePhysique;
            cible.PointsDeVie -= degats;
            Console.WriteLine($"{Nom} inflige {degats} dégâts à {cible.Nom}.");
        }
    }

    // Points de vie initiaux pour vérifier la condition de Coup Bas
    public int PointsDeVieInitial { get; set; }
}

class Program
{
    static void Main()
    {
        Voleur voleur1 = new Voleur("Arsène");
        Voleur voleur2 = new Voleur("Lupin");

        voleur1.PointsDeVieInitial = voleur1.PointsDeVie;
        voleur2.PointsDeVieInitial = voleur2.PointsDeVie;

        voleur1.CoupBas(voleur2);
        voleur1.Evasion();
        voleur1.Attaquer(voleur2);

        Console.WriteLine($"Points de vie de {voleur2.Nom} : {voleur2.PointsDeVie}");
    }
}

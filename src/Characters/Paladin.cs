using System;

public class Paladin
{
    // Attributs du paladin
    public int PointsDeVie { get; set; }
    public string TypeDArmure { get; set; }
    public int PuissanceDAttaquePhysique { get; set; }
    public int PuissanceDAttaqueMagique { get; set; }
    public double ChanceDesquive { get; set; }
    public double ChanceDeParade { get; set; }
    public double ChanceDeResistanceAuxSorts { get; set; }
    public bool Vitesse { get; set; }
    public int PointsDeMana { get; set; }

    // Compétences du paladin
    public void EclairLumineux(Paladin cible)
    {
        if (PointsDeMana >= 25)
        {
            int degats = (int)(PuissanceDAttaqueMagique * 1.25);
            cible.PointsDeVie -= degats;
            PointsDeMana -= 25;
            Console.WriteLine($"Eclair Lumineux inflige {degats} dégâts à {cible.Nom}. Mana restant: {PointsDeMana}");
        }
        else
        {
            Console.WriteLine("Pas assez de mana pour utiliser Eclair Lumineux.");
        }
    }

    public void FrappeDuCroise(Paladin cible)
    {
        if (PointsDeMana >= 5)
        {
            int degats = PuissanceDAttaquePhysique;
            cible.PointsDeVie -= degats;
            PointsDeMana -= 5;
            Console.WriteLine($"Frappe du Croisé inflige {degats} dégâts à {cible.Nom}. Mana restant: {PointsDeMana}");
        }
        else
        {
            Console.WriteLine("Pas assez de mana pour utiliser Frappe du Croisé.");
        }
    }

    public void Jugement(Paladin cible)
    {
        if (PointsDeMana >= 10)
        {
            int degats = PuissanceDAttaqueMagique;
            cible.PointsDeVie -= degats;
            PointsDeMana -= 10;
            Console.WriteLine($"Jugement inflige {degats} dégâts à {cible.Nom}. Mana restant: {PointsDeMana}");
        }
        else
        {
            Console.WriteLine("Pas assez de mana pour utiliser Jugement.");
        }
    }

    // Comportement spécial
    public void ComportementSpecial(Paladin cible)
    {
        int degatsInfliges = 50 * (PuissanceDAttaquePhysique + PuissanceDAttaqueMagique) / 100;
        cible.PointsDeVie -= degatsInfliges;
        Console.WriteLine($"Comportement spécial inflige {degatsInfliges} dégâts à {cible.Nom}.");
    }

    // Constructeur
    public Paladin(string nom)
    {
        Nom = nom;
        PointsDeVie = 95;
        TypeDArmure = "Mailles";
        PuissanceDAttaquePhysique = 40;
        PuissanceDAttaqueMagique = 40;
        ChanceDesquive = 5.0;
        ChanceDeParade = 10.0;
        ChanceDeResistanceAuxSorts = 20.0;
        Vitesse = true;
        PointsDeMana = 60;
    }

    // Nom du paladin
    public string Nom { get; set; }
}

class Program
{
    static void Main()
    {
        Paladin paladin1 = new Paladin("Arthur");
        Paladin paladin2 = new Paladin("Lancelot");

        paladin1.EclairLumineux(paladin2);
        paladin1.FrappeDuCroise(paladin2);
        paladin1.Jugement(paladin2);
        paladin1.ComportementSpecial(paladin2);

        Console.WriteLine($"Points de vie de {paladin2.Nom} : {paladin2.PointsDeVie}");
    }
}

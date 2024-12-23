namespace Characters

    public class Mage
{
    public int PointsDeVie { get; set; } = 60;
    public string TypeDArmure { get; set; } = "Tissu";
    public int PuissanceDAttaquePhysique { get; set; } = 0;
    public int PuissanceDAttaqueMagique { get; set; } = 75;
    public double ChanceDEsquive { get; set; } = 0.05;
    public double ChanceDeParade { get; set; } = 0.05;
    public double ChanceDeResistanceAuxSorts { get; set; } = 0.25;
    public int Vitesse { get; set; } = 75;
    public int Mana { get; set; } = 100;
}

   public void EclairDeGivre(Personnage cible)
    {
        const int coutMana = 15;
        const double reductionVitesse = 0.25;

        if (Mana < coutMana)
        {
            Console.WriteLine("Pas assez de mana pour lancer Éclair de givre.");
            return;
        }

        Mana -= coutMana;
        cible.RecevoirDegatsMagiques(PuissanceDAttaqueMagique);

        if (!cible.ResisteSort())
        {
            cible.Vitesse = (int)(cible.Vitesse * (1 - reductionVitesse));
            Console.WriteLine("La vitesse de la cible est réduite de 25%.");
        }
    }
}

   public class Personnage
{
    public int PointsDeVie { get; set; }
    public int Vitesse { get; set; }

    public void RecevoirDegatsMagiques(int degats)
    {
        PointsDeVie -= degats;
        Console.WriteLine($"La cible reçoit {degats} points de dégâts magiques.");
    }

    public bool ResisteSort()
    {
        // Logique pour déterminer si le sort est résisté
        return new Random().NextDouble() < 0.25; // Exemple de résistance à 25%
    }
}
}
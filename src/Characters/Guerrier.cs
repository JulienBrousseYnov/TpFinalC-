namespace Characters
{
    public class Guerrier
    {
        public int PointsDeVie { get; set; } = 100;
        public string TypeDArmure { get; set; } = "Plaques";
        public int PuissanceDAttaquePhysique { get; set; } = 50;
        public int PuissanceDAttaqueMagique { get; set; } = 0;
        public double ChanceDEsquive { get; set; } = 0.05;
        public double ChanceDeParade { get; set; } = 0.25;
        public double ChanceDeResistanceAuxSorts { get; set; } = 0.10;
        public int Vitesse { get; set; } = 50;
    }
}

public void FrappeHeroique(Personnage cible)
{
    if (cible == null)
        throw new ArgumentNullException(nameof(cible));

    cible.RecevoirDegats(PuissanceDAttaquePhysique);
}
    }

    public class Personnage
{
    public int PointsDeVie { get; set; }

    public void RecevoirDegats(int degats)
    {
        PointsDeVie -= degats;
    }
}
}

public void CriDeBataille(List<Personnage> equipe)
{
    if (equipe == null)
        throw new ArgumentNullException(nameof(equipe));

    foreach (var membre in equipe)
    {
        membre.AugmenterPuissanceDAttaquePhysique(25);
    }
}
    }

    public class Personnage
{
    public int PointsDeVie { get; set; }
    public int PuissanceDAttaquePhysique { get; set; }

    public void RecevoirDegats(int degats)
    {
        PointsDeVie -= degats;
    }

    public void AugmenterPuissanceDAttaquePhysique(int augmentation)
    {
        PuissanceDAttaquePhysique += augmentation;
    }
    public void Tourbillon(List<Personnage> equipeEnnemie)
    {
        if (equipeEnnemie == null)
            throw new ArgumentNullException(nameof(equipeEnnemie));

        int degats = (int)(PuissanceDAttaquePhysique * 0.33);
        foreach (var ennemi in equipeEnnemie)
        {
            ennemi.RecevoirDegats(degats);
        }
    }
}

public class Personnage
{
    public int PointsDeVie { get; set; }
    public int PuissanceDAttaquePhysique { get; set; }

    public void RecevoirDegats(int degats)
    {
        PointsDeVie -= degats;
    }

    public void AugmenterPuissanceDAttaquePhysique(int augmentation)
    {
        PuissanceDAttaquePhysique += augmentation;
    }
}
}
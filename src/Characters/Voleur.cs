public class voleur
{

	public int PointsDeVie { get; set; } = 80;
	public string TypeArmure { get; set; } = "Cuir";
	public int PuisAttaquePhysique { get; set; } = 55;
	public int PuisAttaqueMagique { get; set; } = 0;
	public double ChanceEsquive { get; set; } = 0.15;
	public double ChanceParade { get; set; } = 0.25;
	public double ChanceResistanceSorts { get; set; } = 0.25;

	public voleur()
	{
	}

	public void Attaquer()
	{
		// Logique d'attaque
	}

	public void Defendre()
	{
		// Logique de défense
	}
}
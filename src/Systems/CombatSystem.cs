using System;
include Systems.CombatSystem;

namespace FightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                JouerPartie();
                Console.WriteLine("Appuyez sur n'importe quelle touche pour rejouer ou 'q' pour quitter...");
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    break;
                }
                Console.Clear();
            }
        }

        static void JouerPartie()
        {
            // Initialisation des personnages
            Character joueur = ChoixPersonnage();
            Character ia = ChoixPersonnageIA();

            // Affichage des personnages
            AfficherPersonnage(joueur);
            AfficherPersonnage(ia);

            // Boucle de combat
            bool combatEnCours = true;
            int tour = 1;

            while (combatEnCours)
            {
                Console.WriteLine($"\n--- Tour {tour} ---");

                // Action du joueur
                if (joueur.Health > 0)
                {
                    SelectAction(joueur, ia);
                }

                // Vérification de la fin du combat
                if (ia.Health <= 0)
                {
                    TerminerCombat(true);
                    break;
                }

                // Action de l'IA
                if (ia.Health > 0)
                {
                    ActionIA(ia, joueur);
                }

                // Vérification de la fin du combat
                if (joueur.Health <= 0)
                {
                    TerminerCombat(false);
                    break;
                }

                // Mise à jour des temps de recharge des compétences
                MettreAJourCooldown(joueur);
                MettreAJourCooldown(ia);

                tour++;
            }
        }

        static Character ChoixPersonnage()
        {
            Console.WriteLine("Choisissez votre personnage :");
            Console.WriteLine("1. Guerrier");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Paladin");
            Console.WriteLine("4. Voleur");

            int choix = LireChoix(1, 5);
            string nom = LireNom();

            return choix switch
            {
                1 => new Guerrier(nom),
                2 => new Mage(nom),
                3 => new Paladin(nom),
                4 => new Voleur(nom),
                5 => new Pretre(nom),
                _ => throw new InvalidOperationException("Choix invalide.")
            };
        }

        static Character ChoixPersonnageIA()
        {
            Random random = new Random();
            int choix = random.Next(1, 6);
            string nom = "IA_" + choix;

            return choix switch
            {
                1 => new Guerrier(nom),
                2 => new Mage(nom),
                3 => new Paladin(nom),
                4 => new Voleur(nom),
                5 => new Pretre(nom),
                _ => throw new InvalidOperationException("Choix invalide.")
            };
        }

        static void AfficherPersonnage(Character personnage)
        {
            Console.WriteLine("\n");
            Console.WriteLine(personnage);
        }

        static void TerminerCombat(bool joueurGagne)
        {
            Console.Clear();
            Console.WriteLine(joueurGagne ? "\nVous avez gagné !" : "\nVous avez perdu !");
        }

        static void SelectAction(Character joueur, Character cible)
        {
            Console.WriteLine($"{joueur.Name}, choisissez une action :");
            Console.WriteLine("1. Attaquer");
            Console.WriteLine("2. Utiliser une compétence");
            Console.WriteLine("3. Se soigner");
            Console.WriteLine("4. Passer le tour\n");

            int choix = LireChoix(1, 4);

            switch (choix)
            {
                case 1:
                    joueur.Attack(cible);
                    break;
                case 2:
                    UseSkill(joueur, cible);
                    break;
                case 3:
                    joueur.Heal();
                    break;
                case 4:
                    Console.WriteLine($"\n{joueur.Name} passe son tour.");
                    break;
            }
        }

        static void UseSkill(Character joueur, Character cible)
        {
            Console.WriteLine("\nChoisissez une compétence :");
            joueur.ListSkills();

            int choix = LireChoix(0, joueur.Competences.Count - 1);
            Competence skill = joueur.Competences[choix];
            joueur.UseSkill(skill, cible);
        }

        static void ActionIA(Character ia, Character cible)
        {
            Random random = new Random();
            int choix = random.Next(1, 5);

            switch (choix)
            {
                case 1:
                    ia.Attack(cible);
                    break;
                case 2:
                    UseSkillIA(ia, cible);
                    break;
                case 3:
                    ia.Heal();
                    break;
                case 4:
                    Console.WriteLine($"\n{ia.Name} passe son tour.");
                    break;
            }
        }

        static void UseSkillIA(Character ia, Character cible)
        {
            List<Competence> availableSkills = ia.Competences.Where(s => s.CurrentCooldown == 0 && s.ManaCost <= ia.Mana).ToList();
            if (availableSkills.Count == 0)
            {
                Console.WriteLine($"\n{ia.Name} n'a pas de compétence disponible.");
                return;
            }

            Random random = new Random();
            Competence skill = availableSkills[random.Next(availableSkills.Count)];
            ia.UseSkill(skill, cible);
        }

        static void MettreAJourCooldown(Character personnage)
        {
            foreach (var skill in personnage.Competences)
            {
                skill.UpdateCooldown();
            }
        }

        static int LireChoix(int min, int max)
        {
            int choix;
            while (!int.TryParse(Console.ReadLine(), out choix) || choix < min || choix > max)
            {
                Console.WriteLine("\nChoix invalide. Veuillez réessayer.");
            }
            return choix;
        }

        static string LireNom()
        {
            Console.WriteLine("\nEntrez le nom de votre personnage :");
            return Console.ReadLine();
        }
    }
}

namespace ExerciceSemaine12
{
    internal class Program
    {
        static void AfficherCarte(char[,] carte)
        {
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    Console.Write(carte[i, j]);
                }
                Console.WriteLine();
            }
        }
        static bool EstCarree(int[,] grille)
        {
            return grille.GetLength(0) == grille.GetLength(1);
        }

        static bool EstMagique(int[,] grille)
        {
            if (!EstCarree(grille))
                return false;
            int n = grille.GetLength(0);
            int cible = 0, ligne, colonne, diagonalePrincipale = 0, diagonaleSecondaire = 0;
            for (int i = 0; i < n; i++)
                cible += grille[i, 0];

            for (int i = 0; i < n; i++)
            {
                ligne = 0;
                colonne = 0;
                for (int j = 0; j < n; j++)
                {
                    ligne += grille[i, j];
                    colonne += grille[j, i];
                }
                if (ligne != cible || colonne != cible)
                    return false;
                diagonalePrincipale += grille[i, i];
                diagonaleSecondaire += grille[n - 1 - i, i];
            }
            return diagonalePrincipale == cible && diagonaleSecondaire == cible;
        }

        static void ImprimerCarreMagique(int[,] grille)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    Console.Write((grille[i, j] + "").PadLeft(3));
                }
                Console.WriteLine();
            }
            if (EstMagique(grille))
            {
                Console.WriteLine("Magique");
            }
            else
            {
                Console.WriteLine("Pas magique");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            char[,] carte =
            {
                {'█', '█', '█', '█', '█', '█', '█', '█', '█', '█'},
                {'█', ' ', 'X', ' ', ' ', ' ', ' ', ' ', 'I', '█'},
                {'█', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', '█'},
                {'█', ' ', '█', '█', '█', ' ', '█', '█', '█', '█'},
                {'█', ' ', '█', ' ', '█', ' ', ' ', ' ', ' ', '█'},
                {'█', ' ', '█', ' ', '█', '█', '█', '█', ' ', '█'},
                {'█', 'D', '█', ' ', '█', 'I', ' ', ' ', ' ', '█'},
                {'█', '█', '█', ' ', '█', '█', '█', '█', '█', '█'},
            };
            AfficherCarte(carte);

            int[,] carre1 = {
                { 16,  3,  2, 13 },
                {  5, 10, 11,  8 },
                {  9,  6,  7, 12 },
                {  4, 15, 14,  1 }
            };
            ImprimerCarreMagique(carre1);

            int[,] carre2 = { { 8, 8, 8 }, { 8, 8, 8 }, { 8, 8, 8 } };
            ImprimerCarreMagique(carre2);

            ImprimerCarreMagique(new int[,] { { 4, 9, 2 }, { 3, 5, 7 }, { 8, 1, 6 } });
        }
    }
}
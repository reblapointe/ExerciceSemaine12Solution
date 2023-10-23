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
                { 16, 3, 2, 13 },
                { 5, 10, 11, 8 },
                { 9, 6, 7, 12 },
                { 4, 15, 14, 1 }
            };
            int[,] carre2 = { { 8, 8, 8 }, { 8, 8, 8 }, { 8, 8, 8 } };
            int[,] carre3 = { { 4, 9, 2 }, { 3, 5, 7 }, { 8, 1, 6 } };
            Console.WriteLine("carre 1 " + (EstMagique(carre1) ? "est" : "n'est pas") + " magique");
            Console.WriteLine("carre 2 " + (EstMagique(carre2) ? "est" : "n'est pas") + " magique");
            Console.WriteLine("carre 3 " + (EstMagique(carre3) ? "est" : "n'est pas") + " magique");
        }
    }
}
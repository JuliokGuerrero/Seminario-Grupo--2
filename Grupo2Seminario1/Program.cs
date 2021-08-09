using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo2Seminario1
{
    class Program
    {
        static List<int> originalItems;

        static void Main(string[] args)
        {
            int listSize = SetListSize();
            originalItems = FillList(listSize);
            Menu();
        }

        public static int SetListSize()
        {
            Console.Write("Digite el tamaño de la lista: ");

            string userInput;
            int listSize;

            do { userInput = Console.ReadLine(); }
            while (!int.TryParse(userInput, out listSize));

            return listSize;
        }

        public static List<int> FillList(int listSize)
        {
            Console.WriteLine("\nDigite los elementos de la lista:");
            List<int> items = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                string userInput;
                int newItem;

                do
                {
                    Console.Write(string.Format("Elemento #{0}: ", i + 1));

                    userInput = Console.ReadLine();
                }
                while (!int.TryParse(userInput, out newItem));

                items.Add(newItem);
            }

            ImprimirLista(items);

            return items;
        }


        public static void Menu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("[b] Ordenamiento burbuja [b]");
                Console.WriteLine("[s] Ordenamiento selección [s]");
                Console.WriteLine("[o] Lista original [o]");
                Console.WriteLine("[e] Salir [e]");
                Console.Write("Opción: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "b": Bubblesort(); break;
                    case "s": Selection(); break;
                    case "o": OriginalList(); break;
                    case "e":
                    default: continuar = false; break;
                }
            }
        }

        public static void Bubblesort()
        {
            Console.WriteLine("\nOrdenamiento burbuja:");

            List<int> items = new List<int>(originalItems);

            for (int x = 1; x < items.Count; x++)
            {
                for (int y = 0; y < items.Count - 1; y++)
                {
                    if (items[y] > items[y + 1])
                    {
                        int temp = items[y];
                        items[y] = items[y + 1];
                        items[y + 1] = temp;
                    }
                }
            }

            ImprimirLista(items);
        }

        public static void Selection()
        {
            Console.WriteLine("\nOrdenamiento selección:");

            List<int> items = new List<int>(originalItems);

            for (int x = 0; x < items.Count - 1; x++)
            {
                int menor = x;
                for (int y = x + 1; y < items.Count; y++)
                {
                    if (items[y] < items[menor]) menor = y;
                }
                int temp = items[menor];
                items[menor] = items[x];
                items[x] = temp;
            }

            ImprimirLista(items);
        }

        public static void OriginalList()
        {
            Console.WriteLine("\nLista original:");

            ImprimirLista(originalItems);
        }

        public static void ImprimirLista(List<int> items)
        {
            Console.WriteLine("\t" + string.Join(", ", items.Select(item => item.ToString())));
        }
    }
}

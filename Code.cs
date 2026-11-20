

using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;

class Livro {
    public string Title { get; set; }
    public int ID { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
   

    public Livro(string Title,int ID, string Author, int Year) {
         this.Title = Title;
        this.Author = Author;
        this.Year = Year;
        this.ID = ID;
    }


}

class Biblioteca
{
    private List<Livro> Aisle1 = new List<Livro>();
    private List<Livro> Aisle2 = new List<Livro>();
    private List<Livro> Aisle3 = new List<Livro>();

    public Biblioteca()
    {
        Aisle1.Add(new Livro("Dom Casmurro", 1, "Machado de Assis", 1899));
        Aisle1.Add(new Livro("O Cortiço", 2, "Aluísio Azevedo", 1890));

        Aisle2.Add(new Livro("1984", 3, "George Orwell", 1949));
        Aisle2.Add(new Livro("Animal Farm", 4, "George Orwell", 1945));

        Aisle3.Add(new Livro("The Hobbit", 5, "J.R.R. Tolkien", 1937));
    }



    private int MaxCapacity = 7;
    private bool IsFull(int AisleIndex) {

        switch (AisleIndex) {
            case 1: return (Aisle1.Count == MaxCapacity);
            case 2: return (Aisle2.Count == MaxCapacity);
            case 3: return (Aisle3.Count == MaxCapacity);
            default : return false; 

        }

    }

    public void insert() {
        Console.WriteLine("Escolha uma ala de 1 a 3");
        Console.Write("Ala: ");

        int aisleIndex = int.Parse(Console.ReadLine());
        if (aisleIndex < 1 || aisleIndex > 3) {
            Console.WriteLine("Ala inválida!");
            return;
        }
        if (IsFull(aisleIndex)){
            Console.WriteLine($"A ala {aisleIndex} está cheia!");
            return;
        }

        Console.Write("Título: ");
        string Title = Console.ReadLine();
        Console.Write("ID: ");
        int ID = int.Parse(Console.ReadLine());
        Console.Write("Autor: ");
        string Author = Console.ReadLine();
        Console.Write("Ano: ");
        int Year = int.Parse(Console.ReadLine());

        Livro NewBook = new Livro(Title,ID,Author,Year);

        if (aisleIndex == 1) {
            Aisle1.Add(NewBook);
        }
        if (aisleIndex == 2)
        {
            Aisle2.Add(NewBook);
        }
        if (aisleIndex == 3)
        {
            Aisle3.Add(NewBook);
        }
        Console.WriteLine($"-{NewBook.Title}- adicionado com sucesso...");
        Console.WriteLine($"Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }


    public void BubbleSort(List<Livro> books, int option) { 
           
    }

    public void DisplayAisle(List<Livro> aisle, int aisleNumber) {
        Console.WriteLine($"----Ala {aisleNumber}----");

        foreach (Livro l in aisle) {
            Console.WriteLine($"Autor: {l.Author} - Título: {l.Title} - Ano: {l.Year}");
           
        
        }
        Console.WriteLine("------------------------------------------------------");
    }
    public void SortBooks(int option) {
        BubbleSort(Aisle1, option);
        BubbleSort(Aisle1, option);
        BubbleSort(Aisle1, option);

    }
    public void Display() {
        Console.WriteLine("[1] - Exibir por ID \n [2]- Exibir por ano \n [3]- Exibir por autor");
        int input = int.Parse(Console.ReadLine());
        if (input < 1 || input > 3) {
            Console.WriteLine("Input inválido");
            return;
        }

        DisplayAisle(Aisle1, 1);
        DisplayAisle(Aisle2, 2);
        DisplayAisle(Aisle3, 3);
        Console.WriteLine($"Pressione qualquer tecla para continuar");
        Console.ReadKey();
    
    }


}

class Program {
    static void Main()
    {
        Biblioteca biblioteca = new Biblioteca();
        while (true) {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("[1] - Inserir Livros\n" + "[2] - Procurar Livros\n" + "[3] - Exibir Lista");
            Console.WriteLine("=========================");

            Console.Write("Input: ");

            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------\n");


            switch (input)
            {
                case 1:
                    biblioteca.insert();
                    break;
                case 2:

                    break;
                case 3:
                    biblioteca.Display();
                    break;



            }
        }
        
       

    }


}

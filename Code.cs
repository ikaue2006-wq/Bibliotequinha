using System;
using System.Collections.Generic;
using System.Linq;

class Livro {
    public string Title { get; set; }
    public int ID { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }


    public Livro(string Title, int ID, string Author, int Year) 
    {
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
    private bool IsFull(int AisleIndex) 
    {

        switch (AisleIndex) 
        {
            case 1: return (Aisle1.Count >= MaxCapacity);
            case 2: return (Aisle2.Count >= MaxCapacity);
            case 3: return (Aisle3.Count >= MaxCapacity);
            default : return false; 

        }

    }

    public bool TitleExists(string Title)
    {
        return Aisle1.Exists(x => x.Title == Title) || Aisle2.Exists(x => x.Title == Title) || Aisle3.Exists(x => x.Title == Title);

    }
    public bool IDexists(int id) { 
       return Aisle1.Exists(x =>  x.ID == id) || Aisle2.Exists(x => x.ID == id) || Aisle3.Exists(x => x.ID == id);

    }

    public void insert() 
    {
        Console.WriteLine("Escolha uma ala de 1 a 3");
        Console.Write("Ala: ");

        int aisleIndex = int.Parse(Console.ReadLine());
        if (aisleIndex < 1 || aisleIndex > 3) 
        {
            Console.WriteLine("Ala inválida!");
            return;
        }
        if (IsFull(aisleIndex))
        {
            Console.WriteLine($"A ala {aisleIndex} está cheia!");
            return;
        }

        Console.Write("Título: ");
        string? Title;
        int count = 0;
        while (true)
        {
            Title = Console.ReadLine();
            Console.WriteLine("");
            if (Title == "") {
                if (count == 0) {
                    Console.WriteLine("Ah, relaxa escreve aí, novamente, ");
                }
                if (count == 1)
                {
                    Console.WriteLine("Sério mano? que criatividade é essa? Deixar o negócio em branco já é demais...");
                    Console.WriteLine("Tenta de novo, aí!");
                }
                if (count >= 2)
                {
                    Console.WriteLine("...");
                }
                count++;
            }
            bool Exists = TitleExists(Title);
            if (!Exists && Title != "")
            {
                break;
            }
            if (Exists) {
                Console.WriteLine("Esse título já está cadastrado. Tente outro!");
            }
          
        }


        Console.Write("ID: ");
        int ID;

        while (true) {
            ID = int.Parse(Console.ReadLine());
            if (!IDexists(ID)) 
              {
                break;
            }
            Console.WriteLine("Esse ID já está cadastrado. Tente outro!");
        }


        Console.Write("Autor: ");
        string Author = Console.ReadLine();
        Console.Write("Ano: ");
        int Year = int.Parse(Console.ReadLine());

        Livro NewBook = new Livro(Title,ID,Author,Year);

        if (aisleIndex == 1) 
        {
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


    private void BubbleSort(List<Livro> books, int option) 
    {
        for (int i = 0; i < books.Count - 1; i++) 
        {
            for (int j = 0; j < books.Count - 1 - i; j++) 
            {
                bool ShouldSwap = false;

                switch (option) 
                {
                    case 1:
                        ShouldSwap = books[j].ID > books[j + 1].ID;
                        break;
                    case 2:
                        ShouldSwap = books[j].Year > books[j + 1].Year;
                        break;
                    case 3:
                        ShouldSwap = string.Compare(books[j].Author, books[j + 1].Author,StringComparison.OrdinalIgnoreCase) > 0;
                        break;
                
                
                }

                if (ShouldSwap) 
                {
                    Livro temp = books[j];
                    books[j] = books[j + 1];
                    books[j+1] = temp;  
                
                }
            
            }
        
        }
        

    }
    private void SortBooks(int option)
    {
        BubbleSort(Aisle1, option);
        BubbleSort(Aisle2, option);
        BubbleSort(Aisle3, option);

    }
    private Livro BinarySearch(List<Livro> books,int id) 
    {
        int left = 0;
        int right = books.Count - 1;

        while (left <= right) 
        { 
            int mid = left + (right - left) / 2;

            if (books[mid].ID == id) { 
              return books[mid];
            }
            if (books[mid].ID < id)
            {
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }
        return null;
    }
    public void SearchBooks(int id) {
        SortBooks(1);

        Livro WantedBook = BinarySearch(Aisle1, id);

        if (WantedBook == null) {
            WantedBook = BinarySearch(Aisle2, id);
        }

        if (WantedBook == null)
        {
            WantedBook = BinarySearch(Aisle3, id);
        }


        if (WantedBook != null)
        {
            Console.WriteLine("================================");
            Console.WriteLine($"O livro {WantedBook.Title} foi encontrado!");
            Console.WriteLine($"De {WantedBook.Author}");
            Console.WriteLine($"lançado em {WantedBook.Year}");
            Console.WriteLine($"ID: {WantedBook.ID}");
            Console.WriteLine("================================");
        }

        else {
            Console.WriteLine("Sinto-lhe informar, porém não temos esse livro!");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public void DisplayAisle(List<Livro> aisle, int aisleNumber) 
    {
        Console.WriteLine($"----Ala {aisleNumber}----");

        foreach (Livro l in aisle) 
        {
            Console.WriteLine($"Autor: {l.Author} | Título: {l.Title} - Ano: {l.Year} | ID: {l.ID}");
           
        
        }
        Console.WriteLine("===================================================");
    }
   
    public void Display() 
    {
        Console.WriteLine("[1] - Exibir por ID  ");
        Console.WriteLine("[2]- Exibir por ano ");
        Console.WriteLine("[3]- Exibir por autor");
        int input = int.Parse(Console.ReadLine());
        if (input < 1 || input > 3) {
            Console.WriteLine("Input inválido");
            return;
        }

        SortBooks(input);

        DisplayAisle(Aisle1, 1);
        DisplayAisle(Aisle2, 2);
        DisplayAisle(Aisle3, 3);
        Console.WriteLine("");
        Console.WriteLine($"Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    
    }


}

class Program {
    static void Main()
    {
        Biblioteca biblioteca = new Biblioteca();
        bool NaBibliotequinha = true;
        while (NaBibliotequinha) {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("[1] - Inserir Livros\n" + "[2] - Procurar Livros\n" + "[3] - Exibir Lista");
            Console.WriteLine("Pressione qualquer outro número para sair da simulação");
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
                    Console.Write("Digite o ID do livro: ");
                    int id = int.Parse(Console.ReadLine());
                    
                    biblioteca.SearchBooks(id);
                    break;
                case 3:
                    biblioteca.Display();
                    break;
                default:
                    NaBibliotequinha = false;
                    break;

            }
        }
        
       

    }


}

using System;
using System.Dynamic;   //Importerar system som t ex Console.WriteLine

//Skapar en klass för gästbokinlägg
class GuestbookPost
{
    //Skapar fält som lagrar den data jag vill ha i gästboken. Den är private för att skydda datan. Åtkomsten styrs i egenskaper.
    private string owner;
    private string text;

    //Egenskaper för fältet owner
    public string Owner
    {
        //Hämta värdet från fältet
        get { return owner; }
        //Sätt värdet och kontrollera att det inte är tomt
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Du måste fylla i ägare.");
            owner = value;
        }
    }

    //Egenskaper för fältet text
    public string Text
    {
        //Hämta värdet från fältet
        get { return text; }
        //Sätt värdet och kontrollera att det inte är tomt
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Du måste fylla i inlägget.");
            text = value;
        }
    }

    //Konstruktor (som bygger objektet och skapar det). Gör den publik för att andra delar av programmet ska kunna använda den.
    public GuestbookPost(string owner, string text)     //Parametrar som skickas med när objektet skapas
    {
        //Kollar parametern med egenskapen och kör kontrollen.
        Owner = owner;
        Text = text;
    }
}

//Skapar en klass för gästboken
class Guestbook
{
    //Skapar en lista med namnet posts som kan lagra GuestbookPost-objekt. Gör den privat så att jag kan styra reglerna.
    private List<GuestbookPost> posts = new List<GuestbookPost>();

    //Skapar en metod som skriver ut alla inlägg.
    public void ShowAllPosts()
    {
        //Kontrollerar om det finns några inlägg. Är den tom så skriv ut det och avbryt metoden.
        if (posts.Count == 0)
        {
            Console.WriteLine("Gästboken är tom.");
            return;
        }

        //Loopar igenom alla inlägg och skriver ut alla inlägg med index.
        for (int i = 0; i < posts.Count; i++)
        {
            Console.WriteLine($"{i} {posts[i].Owner} - {posts[i].Text}");
        }
    }

    //Skapar en metod som lägger till ett nytt inlägg i gästboken
    //Metoden behöver ta emot ett inlägg som parameter (pga kallar den i Main gb.AddPost(post1)).
    public void AddPost(GuestbookPost post)     //Parameter post av typen GuestbookPost.
    {
        //Lägg till i listan posts med inbyggd metod för listor Add()
        posts.Add(post);
    }

}


//Kör programmet
class Program
{
    static void Main()
    {
        //Skapa gästboken som inläggen ska adderas till. En instans av Guestbook.
        Guestbook gb = new Guestbook();

        //Skapa nya inlägg (objekt) av klassen GuestbookPost. Anropar konstruktorn i GuestbookPost som kör koden för att skapa ett nytt objekt.
        GuestbookPost post1 = new GuestbookPost("Frida", "Hello World!");
        GuestbookPost post2 = new GuestbookPost("Hanna", "Testmeddelande.");

        //Addera inlägg i gästboken med addera-metoden.
        gb.AddPost(post1);
        gb.AddPost(post2);

        //Skriv ut inläggen med metoden för utskrift
        gb.ShowAllPosts();
       
    }
}
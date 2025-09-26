using System;


namespace GuestbookApp
{

    class Program
    {
        static void Main()
        {
            //Skapa gästboken som inläggen ska adderas till. En instans av Guestbook.
            Guestbook gb = new Guestbook();
            string choice;      //Deklarerar en variabel(textsträng) som lagrar menyval.
            string input;       //Deklarera en variabel som lagrar index-input vid radering.

            //En loop som rensar konsollen och skriver ut alla alternativ så länge man inte väljer x - avsluta.
            do
            {
                Console.Clear();
                Console.WriteLine("F R I D A'S  G U E S T B O O K");
                Console.WriteLine();
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("x. Avsluta");
                Console.WriteLine();
                //Läs ut alla inlägg
                gb.ShowAllPosts();

                //Läser in användarens svar av choice.
                choice = Console.ReadLine();

                //De olika valen och vad dem gör, vid valt alterantiv så bryts den.
                switch (choice)
                {
                    //Lägg till nytt inlägg
                    case "1":
                        //Använder try/catch för att kontrollen sker i klassen GuestbookPost.
                        try
                        {
                            Console.Write("Ägare: ");
                            string owner = Console.ReadLine();

                            Console.Write("Inlägg: ");
                            string text = Console.ReadLine();

                            GuestbookPost post = new GuestbookPost(owner, text);
                            gb.AddPost(post);
                        }
                        //Fel vi vill fånga och variabel(ex) som refererar till felobjektet.
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();          //Pausa så att användaren kan läsa meddelandet.
                        }
                        break;

                    //Ta bort inlägg
                    case "2":

                        Console.Write("Vilket index vill du radera: ");
                        //Läser in användarens svar och sparar den i variabeln input.
                        input = Console.ReadLine();

                        //Svaret sparas i en sträng och måste därför omvandlas till ett heltal som index är (med TryParse).
                        //Vi vill omvandla input till int(heltal) och spara i variaben index. Out används för att berätta om det lyckades(bool) och ger tillbaka värdet(index).
                        if (int.TryParse(input, out int index))
                        {
                            //Om omvandlingen lyckas så raderas index.
                            gb.RemovePost(index);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt index.");
                            Console.ReadKey();
                        }
                        break;
                }
            } while (choice.ToLower() != "x");      //Case sensitive

        }
    }
}
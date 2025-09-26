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

            string file = "guestbook.json";     //Skapar en variabel file som innehåller filnamnet. Den skickas sedan som argument till LoadFromFile och SaveToFile.

            //Metoden tar emot värdet "guestbook.json" via parametern filename och läser in listan med inlägg från den filen.
            gb.LoadFromFile(file);

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

                //Läser in användarens svar av choice. Ger variabeln ett värde.
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

                            //Spara direkt efter att ett nytt inlägg lagts till
                            gb.SaveToFile(file);
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

                            // Spara direkt efter att ett inlägg tagits bort
                            gb.SaveToFile(file);
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
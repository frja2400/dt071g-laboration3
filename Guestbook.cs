using System;
using System.Collections.Generic;           //Adderar denna för <list>-funktion.
using System.Text.Json;                     //För att kunna spara mina inlägg med json.
using System.IO;                            //För att skriva/läs filer


namespace GuestbookApp
{
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
                Console.WriteLine($"[{i}] {posts[i].Owner} - {posts[i].Text}");
            }
        }

        //Skapar en metod som lägger till ett nytt inlägg i gästboken
        //Metoden behöver ta emot ett inlägg som parameter (pga kallar den i Main gb.AddPost(post1)).
        public void AddPost(GuestbookPost post)     //Parameter post av typen GuestbookPost.
        {
            //Lägg till i listan posts med inbyggd metod för listor Add()
            posts.Add(post);
        }

        //Metod som raderar inlägg baserat på index.
        public void RemovePost(int index)
        {
            //Kontrollera att index finns.
            if (index >= 0 && index < posts.Count)
            {
                posts.RemoveAt(index);      //Inbyggd funktion som tar bort index från lista.
            }
            else
            {
                Console.WriteLine("Ogiltigt index.");
                Console.ReadKey();
            }
        }

        //Metod för att spara listan posts till en fil.
        public void SaveToFile(string filename)
        {
            //Konvertera listan till JSON med inbyggd metod. WriteIndented ger JSON-strängen radbrtningar. Vi sparar det i variabeln jsonString som är en sträng.
            string jsonString = JsonSerializer.Serialize(posts, new JsonSerializerOptions { WriteIndented = true });

            //Skriver JSON-strängen till en fil filename.
            File.WriteAllText(filename, jsonString);

        }

        //Metod för att läsa in listan från filen och fylla listan posts.
        public void LoadFromFile(string filename)
        {

            if (File.Exists(filename))
            {
                //Läser innehållet i JSON-strängen som en textsträng och sparar i variabel.
                string jsonString = File.ReadAllText(filename);

                //Omvandlar JSON till listan med GuestbookPost-objekt. Om den är ogiltig skickas en tom lista istället för null. 
                posts = JsonSerializer.Deserialize<List<GuestbookPost>>(jsonString) ?? new List<GuestbookPost>();
            }
        }
    }
}
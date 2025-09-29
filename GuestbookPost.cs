using System;


namespace GuestbookApp
{
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
                    throw new ArgumentException("Du måste fylla i inlägg.");
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
}
namespace Guldkortet
{
    public class Card //Huvudklass för våra kort
    {
        public string cardNumber { get; set; } //Egenskaper som kortet behöver
        public string cardType { get; set; }

        public class Dunderkatt : Card //underklass som ärvs av Card-klassen
        {
            public Dunderkatt(string cardNumber, string cardType) //konstruktor till underklassen
            {

            }
            public override string ToString()
            {
                return cardNumber + " " + cardType; //används inte heller av samma anledning som Customer, men skulle kunna implementera det i min kod med lite ändringar
                                                    //jag använde ToString i min StartReading()-metod tidigare och det fungerade bra men jag tyckte faktiskt koden blev
            }                                       //mycket lättare att följa så som jag gjort, istället för att skapa flera konstruktorer med olika ToStrings för
                                                    //korrekt utskrift av de olika delarna i mitt program.
        }

        public class Kristallhäst : Card
        {
            public Kristallhäst(string cardNumber, string cardType)
            {

            }
            public override string ToString()
            {
                return cardNumber + " " + cardType;
            }
        }

        public class Eldtomat : Card
        {
            public Eldtomat(string cardNumber, string cardType)
            {

            }
            public override string ToString()
            {
                return cardNumber + " " + cardType;
            }
        }
        
        public class Överpanda : Card
        {
            public Överpanda(string cardNumber, string cardType)
            {

            }
            public override string ToString()
            {
                return cardNumber + " " + cardType;
            }
        }
    }
}

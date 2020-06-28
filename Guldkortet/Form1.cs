using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Guldkortet
{
    public partial class Guldkortet : Form
    {
        List<Card> cardCollection = new List<Card>(); //initialiserar en lista med klassen Card
        List<Customer> customerCollection = new List<Customer>(); //initierar en lista med klassen Customer

        public static string readCustomerNumber = ""; //initialiserar strängarna till listklassen Customer 
        public static string readCustomerName = "";
        public static string readCustomerCity = "";

        List<Customer> customer1 = new List<Customer>(); //initialiserar listan customer1 som kommer vara central för flera delar av programmet
        List<Card> card1 = new List<Card>(); //initialiserar listan card1

        private Bitmap MyImage; //deklarerar en Bitmap för ShoyMyImage()-metoden

        TcpListener server; //deklarerar en TcpListener som heter server
        TcpClient client; //deklarerar en TcpClient som heter client
        int port = 12345; // deklarerar portnumret vi använder oss av för anslutning
        IPAddress privateAddress = IPAddress.Parse("127.0.0.1"); //privat ip-address för klienten


        public Guldkortet()
        {
            InitializeComponent(); //startar Forms-komponenten
        }

        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            StartServer(); //metod för att starta anslutningen
            BtnStartServer.BackColor = Color.Green; //sätter knappen som grön när uppkoppling skett
            BtnStartServer.Text = "Connected"; //ändrar text på knappen
            BtnStartServer.Enabled = false; //stänger av knappen så man inte kan trycka på den igen efter att servern startat
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            List<string[]> vectorListCustomer = new List<string[]>(); //initialiserar en strängvektor-lista där vi temporärt lagrar den uppdelade strängen senare
            List<string> readCustomers = new List<string>();
            string[] customerVector;
            string customer;
            try
            {
                if(File.Exists("kundlista.txt")) //kollar om filen finns på angiven plats
                {
                    StreamReader customerReader = new StreamReader("kundlista.txt", Encoding.Default, true); //klass för att läsa in textfiler


                    while ((customer = customerReader.ReadLine()) != null) //läser från textfilen tills det inte finns radbryten kvar
                    {
                        readCustomers.Add(customer); //lagrar alla inlästa element temporärt
                    }

                    foreach(string a in readCustomers) //går igenom varje element i temporära listan
                    {
                        customerVector = a.Split(new string[] { "###" }, StringSplitOptions.None); //"splittar" strängen för varje "###"-tecken
                        vectorListCustomer.Add(customerVector); //lägger till de uppdelade strängarna i vår temporära strängvektor-lista

                        Customer customer1 = new Customer(); //skapar en ny instans av klassen Customer där vi lagrar en "komplett" kund
                        customerCollection.Add(customer1); //lägger till kunden 

                        customer1.customerNumber = customerVector[0]; /*eftersom första delen i kundlistan.txt är kundnumret så är det även första 
                                                                        *elementet i strängvektor-listan så vi skiljer dem åt på det här sättet*/
                        customer1.customerName = customerVector[1];
                        customer1.customerCity = customerVector[2];
                    }
                    BtnUpdateUser.Text = "Updated!";
                    BtnUpdateUser.BackColor = Color.Green;
                    BtnUpdateUser.Enabled = false;

                }
            }
            catch(Exception error) //felhantering där vi får upp ett meddelande om fel skett
            {
                MessageBox.Show(error.Message, Text);
                return;
            }
        }

        private void BtnUpdateCard_Click(object sender, EventArgs e)
        {
            List<string[]> vectorListCard = new List<string[]>();
            List<string> readCards = new List<string>();
            string[] cardVector;
            string card;
            try
            {
                if (File.Exists("kortlista.txt"))
                {
                    StreamReader cardReader = new StreamReader("kortlista.txt", Encoding.Default, true);

                    while ((card = cardReader.ReadLine()) != null)
                    {
                        readCards.Add(card);
                    }

                    foreach (string b in readCards)
                    {
                        cardVector = b.Split(new string[] { "###" }, StringSplitOptions.None);
                        vectorListCard.Add(cardVector);

                        Card card1 = new Card();
                        cardCollection.Add(card1);

                        card1.cardNumber = cardVector[0];
                        card1.cardType = cardVector[1];

                        switch (cardVector[1]) //på samma sätt här som i Customer så jämför vi nu alla cardVector[1] med en förbestämd sträng, tex "Dunderkatt" och skapar då en ny instans av den underklassen
                        {
                            case "Dunderkatt":
                                {
                                    cardCollection.Add(new Card.Dunderkatt(cardVector[0], cardVector[1]));  //en ny instans av Dunderkatt, en underklass till Card
                                    //card1.cardType = cardVector[1]; //man kan även göra på det här sättet där man lagrar korttypen "lokalt", men jag tyckte det andra sättet var bättre
                                                                      // eftersom att det blir lättare att skapa nya "vinstkort" och lägga till dessa i programmet
                                    break;
                                }
                            case "Kristallhäst":
                                {
                                    cardCollection.Add(new Card.Kristallhäst(cardVector[0], cardVector[1]));
                                    //card1.cardType = cardVector[1];
                                    break;
                                }
                            case "Överpanda":
                                {
                                    cardCollection.Add(new Card.Överpanda(cardVector[0], cardVector[1]));
                                    //card1.cardType = cardVector[1];
                                    break;
                                }
                            case "Eldtomat":
                                {
                                    cardCollection.Add(new Card.Eldtomat(cardVector[0], cardVector[1]));
                                    //card1.cardType = cardVector[1];
                                    break;
                                }
                        }  
                        
                    }
                    BtnUpdateCard.Text = "Updated!";
                    BtnUpdateCard.BackColor = Color.Green;
                    BtnUpdateCard.Enabled = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }
        }

        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, port); //startar TcpListener mot vilken ip-adress som helst och med vårt angivna portnummer
            server.Start();
            StartReception(); //anropar metoden StartReception()
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close(); //stänger ner programmet
        }

        private void PbxGuldkort_Click(object sender, EventArgs e)
        {

        }

        public async void StartReception()
        {
            try
            {
                client = await server.AcceptTcpClientAsync(); //await väntar tills den här processen är klar då den är tidskrävande
            }

            catch (SocketException error) //SocketException är fel som kan ske p.g.a. uppkopplingen mellan client-server
            {
                MessageBox.Show(error.Message, Text);
                return;
            }
            StartReading(client);
        }

        public void ShowMyImage(String fileToDisplay, int xSize, int ySize) /*hämtat från Microsoft Docs för att kunna importera en bildfil och anpassa till
                                                                             * min bildruta*/
        {
            if(MyImage != null)
            {
                MyImage.Dispose();
            }
            PbxGuldkort.SizeMode = PictureBoxSizeMode.StretchImage; //stretchar bilden så den täcker hela bildrutan
            MyImage = new Bitmap(fileToDisplay); 
            PbxGuldkort.ClientSize = new Size(xSize, ySize); //parametrar som avgör hur stor bilden ska vara
            PbxGuldkort.Image = (Image) MyImage; 
        }

        public async void StartReading(TcpClient c) //startar inläsning av det som skickas från NOSExport
        {
            string NOSMessage;
            string[] NOSVector;
            byte[] buffert = new byte[1024]; //anger en byte-size för det som ska skickas mellan klient-server
            int n;
            try
            {
                n = await c.GetStream().ReadAsync(buffert, 0, buffert.Length); //läser in det som skickats från klienten i bytes
                Thread.Sleep(100); //väntar i 100 ms för att det ska bli "tydligt" att filen lästs in från klienten
                NOSMessage = Encoding.Unicode.GetString(buffert, 0, n); //lägger till det inlästa i en sträng, NOSMessage
                NOSVector = NOSMessage.Split(new string[] { "-" }, StringSplitOptions.None); //"splittar" strängen där ett bindestreck sker

                TbxReception.AppendText(NOSVector[0] + "\r\n"); //skriver ut första strängvektorn i vår textruta
                TbxReception.AppendText(NOSVector[1] + "\r\n");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }

            try
            {
                foreach (Customer cnr in customerCollection) //går igenom alla element i vår stränglista av klassen Customer
                {
                    if (NOSVector[0].Equals(cnr.customerNumber)) //om första vektorn av NOSMessage är lika med ett kundnummer, gå vidare
                    {
                        TbxReception.AppendText("Du finns med i listan " + cnr.customerName + " med kundnumret: "
                            + cnr.customerNumber + "\r\nOm du har vunnit kan du hämta din vinst från din lokala spelbutik i " + cnr.customerCity + "\r\n"); //utmatning av hittad kund
                        break;
                    }
                }
                foreach (Card nr in cardCollection)
                {
                    if (NOSVector[1].Equals(nr.cardNumber))
                    {
                        TbxReception.AppendText("Grattis du har vunnit ett guldkort!! " + nr.cardNumber + "\r\n");
                        TbxReception.AppendText("Du vann " + nr.cardType + "\r\n");
                        switch(nr.cardType) //switch-case där vi jämför hittad cardType och lägger in tillhörande bild till guldkortet
                        {
                            case "Dunderkatt":
                                ShowMyImage("dunderkatt.png", 226, 149); //anropar metoden ShowMyImage med sökväg till bild, storlek i x-axel och y-axel
                                break;
                            case "Kristallhäst":
                                ShowMyImage("kristallhäst.png", 226, 149);
                                break;
                            case "Överpanda":
                                ShowMyImage("överpanda.png", 226, 149);
                                break;
                            case "Eldtomat":
                                ShowMyImage("eldtomat.png", 226, 149);
                                break;
                        }
                        break;
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }
            StartReading(c);
        }   
    }
}               
            
           
       

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace ÄlyTaloWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int luku = 123; //integeri kohtaan Aste, joka on määritetty Sauna.cs oliossa.
        internal Valo valot = new Valo(); //Valo.cs olio
        internal Thermostat lämpö = new Thermostat(); //Thermostat.cs Olio
        public Sauna sauna = new Sauna(); //Sauna olio
        public DispatcherTimer asteTimer = new DispatcherTimer(); // Tick 
        public DispatcherTimer asteTimer2 = new DispatcherTimer();
        public DispatcherTimer asteTimer3 = new DispatcherTimer();
        public Random random = new Random();


        #region int
        //Kaikki integerit
        int pval;
        int pläm;
        int i;
        int v;
        int a;
        int b;
        int c;
        int ab;
        int ac;
        int ad;
        int ae;
        #endregion
        public MainWindow()
        {
            InitializeComponent();

            #region saunan lämpötila tikit
            asteTimer.Tick += Lämpenee_Tick;
            asteTimer.Interval = new TimeSpan(0, 0, 1); //Tikki käy sekunnin välein

            asteTimer2.Tick += Lämpenee2_Tick;
            asteTimer2.Interval = new TimeSpan(0, 0, 1);

            asteTimer3.Tick += Lämpenee3_Tick;
            asteTimer.Interval = new TimeSpan(0, 0, 1);
            #endregion


            #region valoint
            //int kohtaan valo
            pval = 29;
            i = 29;
            v = 0;
            a = 30;
            b = 60;
            c = 100;
            #endregion

            #region lämpöint
            // int kohtaan ilmastointi
            pläm = 22;
            ab = 22;
            ac = 27;
            ad = 23;
            ae = 18;
            //Saunan sekä ilmastoinnin oletusarvot
            textBox.Text = "OFF";
            saunaBu.Text = "SAUNA SULJETTU";
            #endregion
        }
        #region lämpötilat saunalle
        private void Lämpenee3_Tick(object sender, EventArgs e)
        {
            sauna.Aste = sauna.Aste + 1.32;
            Thread.Sleep(1000);
            saunaBox.Content = sauna.Aste + "°C";

            if (sauna.Aste > 99)
            {
                saunaBu.AppendText("LÄMPÖ SAAVUTETTU");
                asteTimer3.Stop();
            }
        }
        private void Lämpenee2_Tick(object sender, EventArgs e)
        {
            sauna.Aste = sauna.Aste + 1.32;
            Thread.Sleep(1000);
            saunaBox.Content = sauna.Aste + "°C";

            if (sauna.Aste > 79)
            {
                saunaBu.Text = String.Empty;
                saunaBu.AppendText("LÄMPÖ SAAVUTETTU");
                asteTimer2.Stop();
            }
        } 
        private void Lämpenee_Tick(object sender, EventArgs e)
        {
            //Kello on määritetty tikkaamaan sekunnin välein, joka on muunnettu sleepillä, että tikki kestää 2.0sek. Myös lämpötila celsius ilmoitettu.
                sauna.Aste = sauna.Aste + 1.32;
                Thread.Sleep(1000);
                saunaBox.Content = sauna.Aste + "°C";  

                //Määrittää saunan lämpötilan pysähtymisen
               if (sauna.Aste > 59 )
               {
                saunaBu.Text = String.Empty;
                saunaBu.AppendText("LÄMPÖ SAAVUTETTU");
                asteTimer.Stop();
               }                               
        }
        #endregion


        #region Valotpäälle
        private void button_Click(object sender, RoutedEventArgs e)
        {
            valot.Start();
            MessageBox.Show("Aseta kirkkaus aste",
               "KIRKKAUS");
            Thread.Sleep(1200);
            valoTx.Text = String.Empty;
            valoTx.AppendText("\r\n" + "PÄÄLLÄ" + "\r\n");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (valot.kytkin)
            {
                valot.Stop();
                valoTx.AppendText("Sammutetaan valjoa...");
                Thread.Sleep(1200);
                valoTx.Text = String.Empty;
                valoTx.AppendText("POIS PÄÄLTÄ" + "\r\n" + "0%");
            }
            else 
            {
                MessageBox.Show("Valot ovat jo sammutettuna",
                    "VIRHE!");
            }
        }    
            
        private void himB1_Click(object sender, RoutedEventArgs e)
        {
            if (valot.kytkin)
            {
                Thread.Sleep(1200);
                valoTx.Text = string.Empty;
                pval = a;
                valoTx.Text = "KIRKKAUS: " + (pval).ToString() + "%";
            }
            else 
            {
                MessageBox.Show("Laita valot päälle säätääksesi himmeysasteita",
                    "VIRHE");
            }
        }

        private void himB2_Click(object sender, RoutedEventArgs e)
        {
            if (valot.kytkin)
            {
                Thread.Sleep(1200);
                valoTx.Text = string.Empty;
                pval = b;
                valoTx.Text = "KIRKKAUS: " + (pval).ToString() + "%";
            }
            else 
            {
                MessageBox.Show("Laita valot päälle säätääksesi himmeysasteita",
                    "VIRHE");
            }
        }

        private void himB3_Click(object sender, RoutedEventArgs e)
        {
            if (valot.kytkin)
            {
                Thread.Sleep(1200);
                valoTx.Text = string.Empty;
                pval = c;
                valoTx.Text = "KIRKKAUS: " + (pval).ToString() + "%";
            }
            else
            {
                MessageBox.Show("Laita valot päälle säätääksesi tasoja!",
                    "VIRHE");
            }
        }

        private void tasoY_Click(object sender, RoutedEventArgs e)
        {          
            if (valot.kytkin)
                
            {       
                valoTx.Text = string.Empty;
                Thread.Sleep(1000);
                valoTx.Text = "KIRKKAUS: " +  (++pval).ToString() + "%";
            }
            else
            {
                MessageBox.Show("Aseta valot päälle, säätääksesi kirkkautta!",
                    "VIRHE");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (valot.kytkin)

            {
                valoTx.Text = string.Empty;
                Thread.Sleep(1000);
                valoTx.Text = "KIRKKAUS: " + (--pval).ToString() + "%";
            }
            else
            {
                MessageBox.Show("Aseta valot päälle, säätääksesi kirkkautta!",
                    "VIRHE");
            }
        }
        #endregion


        #region lämpö
        //Lämpö kohdan koodit. 
        //start() antaa käskyn oliosta Valo.Cs käynnistää käsketyn tapahtuman
        //Sleepillä tuon pientä viivettä (eloa) teksin ilmestymiseen
        //().ToStringillä olen määrittänyt arvon tekstikenttään
        //String.Empty tyhjentää tekstikentän 
        //Stop() pysäyttää aiemmin käsketyn kohdan 
        private void activateB_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Olet käynnistämässä ilmastointia. Haluatko jatkaa?", "ILMASTOINTI", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("Ilmastointia ei kytketty päälle!", "ILMASTOINTI");
            }
            else  
            {
                textBox.Text = String.Empty;
                Thread.Sleep(1200);
                lämpö.Start();
                textBox.Text = (pläm).ToString() + "°C";
            }
        }

        private void closeB_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Olet sulkemassa ilmastointia. Haluatko varmasti sulkea järjestelmän?", "ILMASTOINTI", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("Ilmastointia ei suljettu!", "ILMASTOINTI");
            }
            else if (lämpö.asetus)
            {
                lämpö.Stop();
                Thread.Sleep(800);
                MessageBox.Show("Lämmitys suljettu!",
                   "ILMASTOINTI");
                Thread.Sleep(1200);
                textBox.Text = String.Empty;
                textBox.Text = "OFF";
            }
            else
            {
                MessageBox.Show("Ilmastointi on jo sammutettuna", "ILMASTOINTI");
            }

                   
        }

        private void heatUpB_Click(object sender, RoutedEventArgs e)
        {
            if (lämpö.asetus)

            {
                textBox.Text = string.Empty;
                Thread.Sleep(1000);
                textBox.Text = (++pläm).ToString() + "°C";

            }
            else
            {
                MessageBox.Show("Aseta ilmastointi päälle asettaaksesi lämpötila",
                    "VIRHE");
            }
        }

        private void heatDownB_Click(object sender, RoutedEventArgs e)
        {
            if (lämpö.asetus)

            {
                textBox.Text = string.Empty;
                Thread.Sleep(1000);
                textBox.Text = (--pläm).ToString() + "°C";
            }
            else
            {
                MessageBox.Show("Aseta ilmastointi päälle asettaaksesi lämpötila",
                    "VIRHE");
            }
        }

        private void vaihtoB_Click(object sender, RoutedEventArgs e)
        {
            if (lämpö.asetus)

            {
                textBox.Text = string.Empty;
                Thread.Sleep(1000);
                pläm = ac;
                textBox.Text = (pläm).ToString() + "°C";
            }
            else
            {
                MessageBox.Show("Aseta ilmastointi päälle asettaaksesi lämpötila",
                    "VIRHE");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (lämpö.asetus)

            {
                textBox.Text = string.Empty;
                Thread.Sleep(1000);
                pläm = ad;
                textBox.Text = (pläm).ToString() + "°C";

            }
            else
            {
                MessageBox.Show("Aseta ilmastointi päälle asettaaksesi lämpötila",
                    "VIRHE");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (lämpö.asetus)

            {
                textBox.Text = string.Empty;
                Thread.Sleep(1000);
                pläm = ae;
                textBox.Text = (pläm).ToString() + "°C";

            }
            else
            {
                MessageBox.Show("Aseta ilmastointi päälle asettaaksesi lämpötila",
                    "VIRHE");
            }
        }
        #endregion


        #region sauna
        //saunan koodit toimivat suurinpiirtein samoilla komennoilla kuin aikaisemmissa
        //Tälläkeraa Start sekä Stop sijaitsee kohdassa Sauna.Cs
        //Kohdissa on myös käytetty Tick ominaisuutta, joka nostaa saunan lämpötilaa. Aste on määritetty nousemaan 1 sekunnin välein
        //mutta lisäsin Lämpenee_Tick voidin alle Sleepin, joka lisää sekunttiin vielä 1.5sec lisää. Tällä voin määrittää lämmön ajan ilmeisesti ihan hyvin.
        private void saunaB1_Click(object sender, RoutedEventArgs e)
        {
            sauna.Start();
            saunaBu.Text = String.Empty;
            {
                if (sauna.running)
                {
                    saunaBu.AppendText("SAUNA PÄÄLLÄ");
                }
            }
        }
        private void saunaB2_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(2000);
            saunaBu.Text = String.Empty;
            saunaBox.Content = (v).ToString() + "°C";
            {
                if (sauna.running)
                {
                    sauna.Stop();
                    saunaBu.AppendText("SAUNA SULJETTU");
                    asteTimer.Stop();
                    asteTimer2.Stop();
                    asteTimer3.Stop();
                }
                else
                {
                    MessageBox.Show("Sauna on jo suljettu");
                }
            }          
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {

            if (sauna.running)
            {
                asteTimer.Stop();
                asteTimer3.Stop();
                asteTimer2.Start();
                MessageBox.Show("Vaihtoehtoinen lämpötila asetettu: 80°C");
                Thread.Sleep(1000);
                saunaBox.Content = sauna.Aste + "°C";
            }
            else
            {
                MessageBox.Show("Kytke sauna ensin päälle asettaaksesi lämpötilan!",
                    "VIRHE!");
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (sauna.running)
            {
                asteTimer.Stop();
                asteTimer2.Stop();
                asteTimer3.Start();
               MessageBox.Show("Vaihtoehtoinen lämpötila asetettu: 100°C");
                Thread.Sleep(1000);
                saunaBox.Content = sauna.Aste + "°C";
            }
            else
            {
                MessageBox.Show("Kytke sauna ensin päälle asettaaksesi lämpötilan!",
                    "VIRHE!");
            }
        }
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (sauna.running)
            {
                asteTimer.Start();
                asteTimer2.Stop();
                asteTimer3.Stop();
                MessageBox.Show("Vaihtoehtoinen lämpötila asetettu: 60°C");
                Thread.Sleep(1000);
                saunaBox.Content = sauna.Aste + "°C";
            }
            else
            {
                MessageBox.Show("Kytke sauna ensin päälle asettaaksesi lämpötilan!",
                    "VIRHE!");
            }
        }
        #endregion
    }
}

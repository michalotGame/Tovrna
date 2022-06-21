using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;

namespace projekt_továren.Tridy
{
    internal class Továrna
    {
        Dictionary<string, string> TeslaIndustries = new Dictionary<string, string>()
        {
            {"Model 3", "https://image.shutterstock.com/image-photo/old-rusty-wrecked-car-outback-260nw-53820886.jpg" },
            {"Model S", "https://ichef.bbci.co.uk/news/1024/branded_news/42DA/production/_119141171_p09mx4vp.jpg" },
            {"Model X", "https://www.orcad.com/sites/default/files/Googel%20car.jpg" },
            {"Model Y", "https://www.drivespark.com/images/2020-11/mini-vision-urbanaut-concept-exterior-2.jpg" },
            {"Cybertruck", "https://assets1.cbsnewsstatic.com/hub/i/r/2011/04/21/116ba444-a643-11e2-a3f0-029118418759/thumbnail/1200x630/881e24d5342415ae0aab78a3b4c8a3a5/brat.jpg" }
        };

        public string Menu()
        {
            Console.WriteLine("Vítejte v továrně Tesla");
            Console.WriteLine("V nabidce máme");

            Console.WriteLine("------------------------------");

            Console.WriteLine("Model S");
            Console.WriteLine("Model 3");
            Console.WriteLine("Model X");
            Console.WriteLine("Model Y");
            Console.WriteLine("Cybertruck");

            Console.WriteLine("------------------------------");

            Console.WriteLine("1.Chci zobrazit poslední vytvořené auto");
            Console.WriteLine("2.Chci vytvořit nové auto");

            string input = Console.ReadLine();
            return input;
        }

        public Auto VytvorAuto()
        {
            Console.Clear();

            Auto vyrabeneAuto = new Auto();
            
            while (true)
            {
                Console.WriteLine("Zadej model : (zadejte přesný název)");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Model S");
                Console.WriteLine("Model 3");
                Console.WriteLine("Model X");
                Console.WriteLine("Model Y");
                Console.WriteLine("Cybertruck");

                vyrabeneAuto.Model = Console.ReadLine();
                if (this.TeslaIndustries.ContainsKey(vyrabeneAuto.Model))
                {
                    break;
                }
                Console.WriteLine("Napsal jsi to špatně. Zkus to znovu");
            }
            

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Zadej počet sedadel");
                Console.ForegroundColor = ConsoleColor.White;
                vyrabeneAuto.PocetSedadel = Convert.ToInt32(Console.ReadLine());
                if (vyrabeneAuto.PocetSedadel >= 2 && vyrabeneAuto.PocetSedadel <= 16)
                {
                    break;
                }
                Console.WriteLine("Napsal jsi až moc velký počet sedadel. Zkus to znovu");
            }
            
            while (true)
            {

                Console.WriteLine("Zadej druh pohonu");
                Console.WriteLine("Elektrický/Hybridní");
                vyrabeneAuto.DruhPohonu = Console.ReadLine();
                if (vyrabeneAuto.DruhPohonu == "Elektrický" || vyrabeneAuto.DruhPohonu == "Hybridní")
                {
                    break;
                }
                Console.WriteLine("Napsal jsi to špatně. Zkus to znovu");

            }
            
            Console.WriteLine("Zadej Cenu:  (des. čísla = čárka");
            vyrabeneAuto.Cena = Convert.ToInt32(Console.ReadLine());

            vyrabeneAuto.Obrazek = TeslaIndustries[vyrabeneAuto.Model];

            return vyrabeneAuto;
        }


        public void VytvorStranku(Auto vyrobeneAuto)
        {
            string html = $@"
            <html>
            <body>
            <h1>Továrna na auta</h1>
            <h2 style='color:blue;'>{vyrobeneAuto.Znacka}</h2>
            <h2>{vyrobeneAuto.Model}</h2>
            <h2>Počet sedaček: {vyrobeneAuto.PocetSedadel}</h2>
            <h2>Druh pohonu: {vyrobeneAuto.DruhPohonu}</h2>
            <img  src='{vyrobeneAuto.Obrazek}'>
            <h3>Rok výroby: {vyrobeneAuto.rokvyroby}</h3>
            <hr>
            <div>
            Cena: <h4 style=' color: orange;'>{vyrobeneAuto.Cena}  </h4>
            </div>
            </body>
            </html>";
            File.WriteAllText("index.html", html);
        }



        public void ZobrazStranku(string adresaSouboru)
        {
            var process = new System.Diagnostics.ProcessStartInfo();
            process.UseShellExecute = true;
            process.FileName = adresaSouboru;
            System.Diagnostics.Process.Start(process);
        }
    }
}
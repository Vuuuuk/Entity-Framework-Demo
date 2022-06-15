using IFZA_Auto_Skola.Models;
using Microsoft.EntityFrameworkCore;
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

namespace IFZA_Auto_Skola
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AutoSkolaContext context = new AutoSkolaContext();
        private CollectionViewSource autoskolaViewSource;
        private CollectionViewSource radnikViewSource;
        private CollectionViewSource poligonViewSource;
        private CollectionViewSource rutaViewSource;
        private CollectionViewSource klijentViewSource;
        private CollectionViewSource ispitViewSource;
        private CollectionViewSource bonusNastavnikViewSource;
        private CollectionViewSource bonusInstruktorViewSource;
        private CollectionViewSource statistikaViewSource;
        private CollectionViewSource voziloViewSource;
        private CollectionViewSource teorijskaViewSource;

        public MainWindow()
        {
            InitializeComponent();
            autoskolaViewSource = (CollectionViewSource)FindResource(nameof(autoskolaViewSource));
            radnikViewSource = (CollectionViewSource)FindResource(nameof(radnikViewSource));
            poligonViewSource = (CollectionViewSource)FindResource(nameof(poligonViewSource));
            rutaViewSource = (CollectionViewSource)FindResource(nameof(rutaViewSource));
            klijentViewSource = (CollectionViewSource)FindResource(nameof(klijentViewSource));
            ispitViewSource = (CollectionViewSource)FindResource(nameof(ispitViewSource));
            bonusNastavnikViewSource = (CollectionViewSource)FindResource(nameof(bonusNastavnikViewSource));
            bonusInstruktorViewSource = (CollectionViewSource)FindResource(nameof(bonusInstruktorViewSource));
            statistikaViewSource = (CollectionViewSource)FindResource(nameof(statistikaViewSource));
            voziloViewSource = (CollectionViewSource)FindResource(nameof(voziloViewSource));
            teorijskaViewSource = (CollectionViewSource)FindResource(nameof(teorijskaViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //AUTO SKOLA
            context.AutoSkolas.Load();
            autoskolaViewSource.Source = context.AutoSkolas.Local.ToObservableCollection();

            //RADNICI
            context.Radniks.Load();
            radnikViewSource.Source = context.Radniks.Local.ToObservableCollection();
            /*using (var db = new AutoSkolaContext())
            {
                var select = from radnik in context.Radniks
                             from autoSkola in context.AutoSkolas
                             where radnik.AId == autoSkola.AId
                             select new
                             {
                                 RaId = radnik.RaId,
                                 RaIme = radnik.RaIme,
                                 RaPrezime = radnik.RaPrezime,
                                 RaPlata = radnik.RaPlata,
                                 RaTip = radnik.RaTip,
                                 AId = autoSkola.AIme
                             };

                radnikViewSource.Source = select.ToList();
            }*/

            //VOZILO
            context.Vozilos.Load();
            voziloViewSource.Source = context.Vozilos.Local.ToObservableCollection();

            //POLIGONI
            context.Poligons.Load();
            poligonViewSource.Source = context.Poligons.Local.ToObservableCollection();
            /*using (var db = new AutoSkolaContext())
            {
                var select = from poligon in context.Poligons
                             from autoSkola in context.AutoSkolas
                             where poligon.AId == autoSkola.AId
                             select new
                             {
                                 PId = poligon.PId,
                                 PAdresa = poligon.PAdresa,
                                 PVelicina = poligon.PVelicina,
                                 AId = autoSkola.AIme,
                             };

                poligonViewSource.Source = select.ToList();
            }*/

            //RUTE
            context.Ruta.Load();
            rutaViewSource.Source = context.Ruta.Local.ToObservableCollection();

            //KLIJENTI
            using (var db = new AutoSkolaContext())
            {
                var pali = from klijent in context.Klijents
                           from teorijskaObuka in context.TeorijskaObukas
                           where klijent.ToId == teorijskaObuka.ToId
                           where teorijskaObuka.ToId == 4
                           select new
                           {
                               KId = klijent.KId,
                               KIme = klijent.KIme,
                               KPrezime = klijent.KPrezime,
                               ToId = "PAO TEORIJSKU OBUKU",
                           };

                var slusaju = from klijent in context.Klijents
                              from teorijskaObuka in context.TeorijskaObukas
                              where klijent.ToId == teorijskaObuka.ToId
                              where teorijskaObuka.ToId != 4 && teorijskaObuka.ToId != 5
                              select new
                              {
                                  KId = klijent.KId,
                                  KIme = klijent.KIme,
                                  KPrezime = klijent.KPrezime,
                                  ToId = "SLUSA TEORIJSKU OBUKU",
                              };

                var polozili = from klijent in context.Klijents
                               from teorijskaObuka in context.TeorijskaObukas
                               where klijent.ToId == teorijskaObuka.ToId
                               where teorijskaObuka.ToId == 5
                               select new
                               {
                                   KId = klijent.KId,
                                   KIme = klijent.KIme,
                                   KPrezime = klijent.KPrezime,
                                   ToId = "POLOZIO TEORIJSKU OBUKU",
                               };

                klijentViewSource.Source = pali.Union(polozili).Union(slusaju).ToList();
            }

            //ISPIT
            using (var db = new AutoSkolaContext())
            {
                var select = from ispit in context.Ispits
                             from klijent in context.Klijents
                             where ispit.IId == klijent.IId
                             select new
                             {
                                 IId = ispit.IId,
                                 KIme = klijent.KIme,
                                 KPrezime = klijent.KPrezime,
                                 ITrajanje = ispit.ITrajanje,
                                 ITip = ispit.ITip,
                             };

                ispitViewSource.Source = select.ToList();
            }

            //BONUSI NASTAVNIK
            using (var db = new AutoSkolaContext())
            {
                var select = from radnik in context.Radniks
                             from autoSkola in context.AutoSkolas
                             from nastavnik in context.Nastavniks
                             from izvrsava in nastavnik.Tos
                             from teorijska in context.TeorijskaObukas
                             where radnik.RaId == nastavnik.RaId
                             where radnik.AId == autoSkola.AId
                             where teorijska.ToId == izvrsava.ToId
                             group teorijska by radnik.RaIme into r
                             where r.Sum(x => x.ToFond) >= 40
                             select new
                             {
                                 RaIme = r.Key,
                                 RaPlata = 10000,
                                 TFond = r.Sum(x => x.ToFond),
                             };

                bonusNastavnikViewSource.Source = select.ToList();
            }

            //BONUSI INSTRUKTOR
            using (var db = new AutoSkolaContext())
            {
                var select = from radnik in context.Radniks
                             from vozilo in context.Vozilos
                             from instruktor in context.Instruktors
                             where vozilo.RaId == instruktor.RaId
                             where radnik.RaId == instruktor.RaId
                             group vozilo by radnik.RaIme into r
                             where r.Sum(x => x.VKilometraza) >= 180000
                             select new
                             {
                                 RaIme = r.Key,
                                 RaPlata = 15000,
                                 TFond = r.Sum(x => x.VKilometraza),
                             };

                bonusInstruktorViewSource.Source = select.ToList();
            }

            //STATISTIKA
            using (var db = new AutoSkolaContext())
            {
                var pali = from klijent in context.Klijents
                           from teorijskaObuka in context.TeorijskaObukas
                           where klijent.ToId == teorijskaObuka.ToId
                           where teorijskaObuka.ToId == 4
                           group klijent by teorijskaObuka.ToId into r
                           select new
                           {
                               KIme = "Pali teorijsku obuku",
                               ToId = r.Count(),
                           };

                var slusaju = from klijent in context.Klijents
                              from teorijskaObuka in context.TeorijskaObukas
                              where klijent.ToId == teorijskaObuka.ToId
                              where teorijskaObuka.ToId != 4 && teorijskaObuka.ToId != 5
                              group teorijskaObuka by klijent.IId into r
                              select new
                              {
                                  KIme = "Slusaju teorijsku obuku",
                                  ToId = r.Count(),
                              };

                var polozili = from klijent in context.Klijents
                           from teorijskaObuka in context.TeorijskaObukas
                           where klijent.ToId == teorijskaObuka.ToId
                           where teorijskaObuka.ToId == 5
                           group klijent by teorijskaObuka.ToId into r
                           select new
                           {
                               KIme = "Polozili teorijsku obuku",
                               ToId = r.Count(),
                           };

                var voznja_pali = from ispit in context.Ispits
                             from klijent in context.Klijents
                             where ispit.IId == klijent.IId
                             where ispit.ITip == "PAO ISPIT VOZNJE"
                             group ispit by klijent.IId into i
                             select new
                             {
                                 KIme = "Pali ispit voznje",
                                 ToId = i.Count(),
                             };

                var voznja_polozili = from ispit in context.Ispits
                                  from klijent in context.Klijents
                                  where ispit.IId == klijent.IId
                                  where ispit.ITip == "POLOZIO ISPIT VOZNJE"
                                  group ispit by klijent.IId into i
                                  select new
                                  {
                                      KIme = "Polozili ispit voznje",
                                      ToId = i.Count(),
                                  };

                var voznja_polazu = from ispit in context.Ispits
                                      from klijent in context.Klijents
                                      where ispit.IId == klijent.IId
                                      where ispit.ITip == "KATEGORIJA A" || ispit.ITip == "KATEGORIJA B"
                                      group ispit by klijent.IId into i
                                      select new
                                      {
                                          KIme = "Polazu ispit voznje",
                                          ToId = i.Count(),
                                      };

                statistikaViewSource.Source = pali.ToList().Union(polozili).Union(slusaju).Union(voznja_pali).Union(voznja_polozili).Union(voznja_polazu);
            }

            //TEORIJSKA OBUKA
            context.TeorijskaObukas.Load();
            teorijskaViewSource.Source = context.TeorijskaObukas.Local.ToObservableCollection();

            //ISPIT
            //context.Ispits.Load();
            //ispitViewSource.Source = context.Ispits.Local.ToObservableCollection();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = context.SaveChanges();

            AutoSkolaDataGrid.Items.Refresh();
            ZaposleniDataGrid.Items.Refresh();
            PoligoniDataGrid.Items.Refresh();
            RutaDataGrid.Items.Refresh();
            klijentiDataGrid.Items.Refresh();
            ispitDataGrid.Items.Refresh();
            bonusiNastavniciDataGrid.Items.Refresh();
            bonusiInstruktoriDataGrid.Items.Refresh();
            statistikaDataGrid.Items.Refresh();
            vozilaDataGrid.Items.Refresh();
            teorijskaDataGrid.Items.Refresh();
            //ispitiDataGrid.Items.Refresh();

            MessageBox.Show("Broj izvršenih zapisa: " + n, "Snimanje");
        }
    }
}

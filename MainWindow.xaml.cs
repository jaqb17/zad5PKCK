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
using System.Xml;
using System.Xml.XPath;

using System.Xml.Xsl;
using Saxon.Api;
using System.IO;

namespace _5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Albumchart albumchart { get; set; }
        public XMLSerialization xmlSerialization { get; set; }

        public List<string> artistList { get; set; }
        public List<string> genreList { get; set; }



        public MainWindow()
        {
            InitializeComponent();

            albumchart = new Albumchart();
            xmlSerialization = new XMLSerialization(@"..\..\albumchart.xml", @"..\..\\albumchart.xsd");
            if (!xmlSerialization.xmlFile.Exists)
            {
                MessageBox.Show("File " + xmlSerialization.xmlFile.FullName.ToString() + " not found!", "XML loading");
            }
            else
            {
                albumchart = xmlSerialization.Deserialize();
                MessageBox.Show("XML file " + xmlSerialization.xmlFile.Name + " loaded!");
            }

            update();


            unitsCombobox.Items.Add("h");
            unitsCombobox.Items.Add("min");
            unitsCombobox.Items.Add("sec");

            foreach (var item in albumchart.artists.artistList)
            {
                artistCombobox.Items.Add(item.Value);
            }

            foreach (var item in albumchart.genres.genresList)
            {
                genreCombobox.Items.Add(item.Value);
            }



            if (xmlSerialization.CheckSchema(albumchart))
            {
                MessageBox.Show("git");
            }
            else
            {
                MessageBox.Show("chuj");
            }
        }

        private void update()
        {
            var artists = albumchart.artists.artistList;
            var genres = albumchart.genres.genresList;

            foreach (var item in albumchart.chart.albums)
            {
                foreach (var g in artists)
                {
                    if (g.artistID == item.artist)
                    {
                        item.ArtistValue = g.Value;
                    }
                }
            }

            foreach (var item in albumchart.chart.albums)
            {
                foreach (var g in genres)
                {
                    if (g.genreID == item.type.Genre)
                    {
                        item.type.Value = g.Value;
                    }
                }
            }
            listBox.DataContext = albumchart.chart.albums;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAlbum = (Album)listBox.SelectedItem;
            albumchart.chart.albums.Remove(selectedAlbum);
            if (xmlSerialization.CheckSchema(albumchart))
            {
                xmlSerialization.Serialize(albumchart);
            }
            else
            {
                MessageBox.Show("Schema error!", "ERROR");
                albumchart = xmlSerialization.Deserialize();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string id = albumchart.chart.albums.Last().Id;
            int newid = int.Parse(id) + 1;

            DateTime rDate = new DateTime();
            rDate = releaseDatePicker.SelectedDate.Value;

            Album album = new Album()
            {
                ArtistValue = artistCombobox.Text,
                Id = newid.ToString(),
                albumName = new AlbumName() { Value = titleTextbox.Text },
                albumReleaseDate = new AlbumReleaseDate() { Value = rDate.ToString("dd.MM.yyyy") },
                type = new Type() { Value = genreCombobox.Text },
                albumLength = new AlbumLength() { Value = lengthTextbox.Text, Units = unitsCombobox.Text },
                albumTrackCount = new AlbumTrackCount() { Value = tracksTextbox.Text },
                albumRating = new AlbumRating()
                {
                    rymRating = new RymRating() { Value = rymTextbox.Text },
                    metacriticRating = new MetacriticRating() { Value = metacriticTextbox.Text }
                }


            };

            foreach (var item in albumchart.genres.genresList)
            {
                if (item.Value == album.type.Value)
                {
                    album.type.Genre = item.genreID;
                }
            }

            foreach (var item in albumchart.artists.artistList)
            {
                if (item.Value == album.ArtistValue)
                {
                    album.artist = item.artistID;
                }
            }

            albumchart.chart.albums.Add(album);
            if (xmlSerialization.CheckSchema(albumchart))
            {
                xmlSerialization.Serialize(albumchart);
                MessageBox.Show("Album added!");
                update();
            }
            else
            {
                albumchart.chart.albums.Remove(album);
                MessageBox.Show("Schema error");
                albumchart = xmlSerialization.Deserialize();
            }

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAlbum = (Album)listBox.SelectedItem;

            selectedAlbum.albumName.Value = titleTextbox.Text;
            selectedAlbum.albumReleaseDate.Value = releaseDatePicker.SelectedDate.Value.ToString("dd.MM.yyyy");
            selectedAlbum.albumLength.Value = lengthTextbox.Text;
            selectedAlbum.albumTrackCount.Value = tracksTextbox.Text;
            selectedAlbum.albumRating.rymRating.Value = rymTextbox.Text;
            selectedAlbum.albumRating.metacriticRating.Value = metacriticTextbox.Text;

            selectedAlbum.ArtistValue = artistCombobox.SelectedItem.ToString();
            selectedAlbum.type.Value = genreCombobox.SelectedItem.ToString();
            foreach (var item in albumchart.artists.artistList)
            {
                if (item.Value == selectedAlbum.ArtistValue)
                {
                    selectedAlbum.artist = item.artistID;
                }
            }


            foreach (var item in albumchart.genres.genresList)
            {
                if (item.Value == selectedAlbum.type.Value)
                {
                    selectedAlbum.type.Genre = item.genreID;
                }
            }

            if (xmlSerialization.CheckSchema(albumchart))
            {
                xmlSerialization.Serialize(albumchart);
                MessageBox.Show("Album modified succesfully!");
                albumchart = xmlSerialization.Deserialize();
                update();
            }
            else
            {

                MessageBox.Show("Schema error");
                albumchart = xmlSerialization.Deserialize();
            }
        }

        private void listBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var selectedAlbum = (Album)listBox.SelectedItem;

            titleTextbox.Text = selectedAlbum.albumName.Value;
            artistCombobox.SelectedIndex = artistCombobox.Items.IndexOf(selectedAlbum.ArtistValue);
            genreCombobox.SelectedIndex = genreCombobox.Items.IndexOf(selectedAlbum.type.Value);
            releaseDatePicker.SelectedDate = DateTime.Parse(selectedAlbum.albumReleaseDate.Value);
            lengthTextbox.Text = selectedAlbum.albumLength.Value;
            unitsCombobox.SelectedIndex = unitsCombobox.Items.IndexOf(selectedAlbum.albumLength.Units);
            tracksTextbox.Text = selectedAlbum.albumTrackCount.Value;
            rymTextbox.Text = selectedAlbum.albumRating.rymRating.Value;
            metacriticTextbox.Text = selectedAlbum.albumRating.metacriticRating.Value;

        }

        private void reportButton_Click(object sender, RoutedEventArgs e)
        {

            string line = null;
            string line_to_delete = "<albumchart xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://www.example.org/types\">";

            using (StreamReader reader = new StreamReader(@"..\..\albumchart.xml"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\albumchartToReport.xml"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, line_to_delete) == 0)
                        {
                            writer.WriteLine("<albumchart>");
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }

                    }
                }
            }


            var xslt = new FileInfo(@"..\..\toxml.xsl");
            var input = new FileInfo(@"..\..\albumchartToReport.xml");
            var output = new FileInfo(@"..\..\report.xml");

            var processor = new Processor();
            var compiler = processor.NewXsltCompiler();
            var executable = compiler.Compile(new Uri(xslt.FullName));

            var destination = new DomDestination();
            using (var inputStream = input.OpenRead())
            {
                var transformer = executable.Load();
                transformer.SetInputStream(inputStream, new Uri(input.DirectoryName));
                transformer.Run(destination);
            }

            // Save result to a file (or whatever else you wanna do)
            destination.XmlDocument.Save(output.FullName);
        }

        private void xhtmlButton_Click(object sender, RoutedEventArgs e)
        {
            var xslt = new FileInfo(@"..\..\toxhtml.xsl");
            var input = new FileInfo(@"..\..\report.xml");
            var output = new FileInfo(@"..\..\report.xhtml");

            var processor = new Processor();
            var compiler = processor.NewXsltCompiler();
            var executable = compiler.Compile(new Uri(xslt.FullName));

            var destination = new DomDestination();
            using (var inputStream = input.OpenRead())
            {
                var transformer = executable.Load();
                transformer.SetInputStream(inputStream, new Uri(input.DirectoryName));
                transformer.Run(destination);
            }

            // Save result to a file (or whatever else you wanna do)
            destination.XmlDocument.Save(output.FullName);
        }
    }
}

using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("album", Namespace = "http://www.example.org/types")]
    public class Album
    {
        [XmlIgnore]
        public string ArtistValue { set; get; }

        [XmlAttribute("album_id")]
        public string Id { get; set; }

        [XmlAttribute("artist_id")]
        public string artist { set; get; }

        [XmlElement("album_name", Namespace = "http://www.example.org/types")]
        public AlbumName albumName { get; set; }

        [XmlElement("album_release_date", Namespace = "http://www.example.org/types")]
        public AlbumReleaseDate albumReleaseDate { get; set; }

        [XmlElement("type", Namespace = "http://www.example.org/types")]
        public Type type { get; set; }

        [XmlElement("album_length", Namespace = "http://www.example.org/types")]
        public AlbumLength albumLength { get; set; }

        [XmlElement("album_track_count", Namespace = "http://www.example.org/types")]
        public AlbumTrackCount albumTrackCount { get; set; }

        [XmlElement("album_rating", Namespace = "http://www.example.org/types")]
        public AlbumRating albumRating { get; set; }
    }
}
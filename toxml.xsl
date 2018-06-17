<xsl:stylesheet  version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="xml" version="1.0" encoding="UTF-8" media-type="text/xml" />

	<xsl:key use="@artist_id" name="album_artist" match="albumchart/artists/artist"/>
	<xsl:key use="@genre_id" name="album_genre" match="albumchart/genres/genre"/>


	<xsl:template match="/">

		<xsl:element name="chart">

			<xsl:element name="summary">
				<xsl:element name="reportdate">
					<xsl:value-of select="current-dateTime()"/>
				</xsl:element>

				<xsl:element name="albums">

					<albumcount> <xsl:value-of select="count(//chart/album)"/> </albumcount>

					<xsl:element name="averagetrackcount">
						<xsl:value-of select="sum(//chart/album/album_track_count) div count(//chart/album)"/>
					</xsl:element>

					<xsl:element name="progrockcount">
						 <xsl:value-of select="count(//chart/album/type[@genre_id = 'ProgRock'])"/> 
					</xsl:element>

					<xsl:element name="experimentalrockcount">
						 <xsl:value-of select="count(//chart/album/type[@genre_id = 'ExperimentalRock'])"/> 
					</xsl:element>

					<xsl:element name="shoegazecount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'Shoegaze'])"/> 
					</xsl:element>

					<xsl:element name="postpunkcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'PostPunk'])"/> 
					</xsl:element>

					<xsl:element name="postrockcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'PostRock'])"/> 
					</xsl:element>

					<xsl:element name="deathmetalcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'DeathMetal'])"/> 
					</xsl:element>

					<xsl:element name="poprockcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'PopRock'])"/> 
					</xsl:element>

					<xsl:element name="indierockcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'IndieRock'])"/> 
					</xsl:element>

					<xsl:element name="garagerockcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'GarageRock'])"/> 
					</xsl:element>

					<xsl:element name="industrialmetalcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'IndustrialMetal'])"/> 
					</xsl:element>

					<xsl:element name="heavymetalcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'HeavyMetal'])"/> 
					</xsl:element>

					<xsl:element name="psychedelicrockcount">
						<xsl:value-of select="count(//chart/album/type[@genre_id = 'PsychedelicRock'])"/> 
					</xsl:element>

				</xsl:element>


			</xsl:element>



 <xsl:for-each select="albumchart/chart/album">
      <xsl:sort select="album_name"/>
      
      <xsl:element name="album">
      	
      	<xsl:element name="name">
       	 <xsl:value-of select="album_name"/>
   		</xsl:element>


      	<xsl:element name="artist">
      		<xsl:variable name= "selectedArtist" select="key('album_artist',@artist_id)"/>
      		<xsl:value-of select="normalize-space($selectedArtist)"/>
       	 
   		</xsl:element>

      	
   		<xsl:element name="tracks">
   			<xsl:value-of select="album_track_count"/>
   		</xsl:element>

   		<xsl:element name="my_rating">
   			<xsl:value-of select="((album_rating/rym_rating div 5) * 100) + album_rating/metacritic_rating"/>
   		</xsl:element>

   		<xsl:element name = "year">
   			<xsl:value-of select="substring(album_release_date, 7, 10)"/>
   		</xsl:element>

	  </xsl:element>
      
      </xsl:for-each>

</xsl:element>
	</xsl:template>
</xsl:stylesheet>
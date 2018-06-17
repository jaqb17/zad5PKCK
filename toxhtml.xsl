<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml">

<xsl:output method="xml" version="1.0" indent="yes"/>

<xsl:template match="/">

<html xmlns="http://www.w3.org/1999/xhtml">

	<head>
		<title>Album Chart</title>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
	</head>

	<body>

		<h1 id="top"> Album Chart</h1>


		<div>
			<h2>Summary</h2>
				
				
				<div>
					<ul>
						<li>
							<b>Album count:</b>
							<xsl:value-of select="/chart/summary/albums/albumcount"/>
						</li>

						<li>
							<b>Average track count:</b>
							<xsl:value-of select="/chart/summary/albums/averagetrackcount"/>
						</li>

						<li>
							<b>Progrock albums count:</b>
							<xsl:value-of select="/chart/summary/albums/progrockcount"/>
						</li>

						<li>
							<b>Experimental rock albums count:</b>
							<xsl:value-of select="/chart/summary/albums/experimentalrockcount"/>
						</li>

						<li>
							<b>Shoegaze albums count:</b>
							<xsl:value-of select="/chart/summary/albums/shoegazecount"/>
						</li>

						<li>
							<b>Post-rock albums count:</b>
							<xsl:value-of select="/chart/summary/albums/postrockcount"/>
						</li>

						<li>
							<b>Post-punk albums count:</b>
							<xsl:value-of select="/chart/summary/albums/postpunkcount"/>
						</li>

						<li>
							<b>Death metal albums count:</b>
							<xsl:value-of select="/chart/summary/albums/deathmetalcount"/>
						</li>

						<li>
							<b>Pop-rock albums count:</b>
							<xsl:value-of select="/chart/summary/albums/poprockcount"/>
						</li>

						<li>
							<b>Indie rock albums count:</b>
							<xsl:value-of select="/chart/summary/albums/indierockcount"/>
						</li>

						<li>
							<b>Garage rock albums count:</b>
							<xsl:value-of select="/chart/summary/albums/garagerockcount"/>
						</li>

						<li>
							<b>Industrial metal albums count:</b>
							<xsl:value-of select="/chart/summary/albums/industrialmetalcount"/>
						</li>

						<li>
							<b>Heavy metal albums count:</b>
							<xsl:value-of select="/chart/summary/albums/heavymetalcount"/>
						</li>

						<li>
							<b>Psychedelic rock albums count:</b>
							<xsl:value-of select="/chart/summary/albums/psychedelicrockcount"/>
						</li>

					</ul>
				</div>
		</div>


<xsl:for-each select="/chart/album">
     

     <div>
     	
     	<h2><span style="color:#ff0000"><xsl:value-of select="name"/></span></h2>

     	<ul>
     		<li>
     			<b>Artist: </b>
     			<xsl:value-of select="artist"/>
     		</li>
     		<li>
     			<b>Number of tracks: </b>
     			<xsl:value-of select="tracks"/>
     		</li>
     		<li>
     			<b>My custom rating: </b>
     			<xsl:value-of select="my_rating"/>
     		</li>
     		<li>
     			<b>Release year: </b>
     			<xsl:value-of select="year"/>
     		</li>
     	</ul>

     </div>
      
    
      
      </xsl:for-each>

				




				<div>
					<h3>Report date: </h3>
					<xsl:value-of select="/chart/summary/reportdate"/>
				</div>

<a href="#top">Back to top</a>
	</body>


</html>
</xsl:template>
</xsl:stylesheet>
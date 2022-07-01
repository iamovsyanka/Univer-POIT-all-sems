<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
   <html>
   <body>
  <table border="1" align="center">
  <tr bgcolor="grey">
  <th style="text-align:center">Фамилия</th>
  <th style="text-align:center">Имя</th>
  <th style="text-align:center">Отчество</th>
  <th style="text-align:center">Дата рождения</th>
  <th style="text-align:center">Средний балл</th>
  </tr>
<xsl:for-each select="gruppa/st">
<xsl:sort select="data" data-type="number"/>    
  <tr>  
  	<xsl:choose>
  	<xsl:when test="srball > 6">    
  	<td bgcolor="green"><xsl:value-of select="fam"/></td>
     <td bgcolor="green"><xsl:value-of select="name"/></td> 
     <td bgcolor="green"><xsl:value-of select="otch"/></td>
     <td bgcolor="green" style="text-align:center"><xsl:value-of select="data"/></td>
     <td bgcolor="green" style="text-align:center"><xsl:value-of select="srball"/></td>
 </xsl:when>
  <xsl:when test="srball > 0">
  <td bgcolor="red"><xsl:value-of select="fam"/></td>
     <td bgcolor="red"><xsl:value-of select="name"/></td> 
     <td bgcolor="red"><xsl:value-of select="otch"/></td>
     <td bgcolor="red" style="text-align:center"><xsl:value-of select="data"/></td>
     <td bgcolor="red" style="text-align:center"><xsl:value-of select="srball"/></td>
       </xsl:when>
        </xsl:choose>
  </tr>
</xsl:for-each>
 </table>
   </body>
   </html>
</xsl:template>
</xsl:stylesheet> 
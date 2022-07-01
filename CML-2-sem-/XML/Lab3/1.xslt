<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
   <html>
   <body>
      <table border="1" align="center">
        <tr bgcolor="grey">
        <th style="text-align:center">Университет</th>
        <th style="text-align:center">Проходной балл</th>
        <th style="text-align:center">План набора</th>
        <th style="text-align:center">Город</th>
        </tr>
      <xsl:for-each select="poit/info">
        <tr>
           <td bgcolor="#B0E0E6"><xsl:value-of select="universe"/></td>
           <td bgcolor="#FFE4E1"><xsl:value-of select="ball"/></td>
           <td bgcolor="#E6E6FA"><xsl:value-of select="plan"/></td>
           <td bgcolor="#FFFACD"><xsl:value-of select="gorod"/></td>
        </tr>
      </xsl:for-each>
     </table>
   </body>
   </html>
</xsl:template>
</xsl:stylesheet> 

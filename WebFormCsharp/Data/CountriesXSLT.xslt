<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="Countries2">
    <Countries2>
      <xsl:apply-templates />
    </Countries2>
  </xsl:template>

    <xsl:template match="Countries2">
        <Country>
          <xsl:for-each select="*">
            <xsl:attribute name="{name()}">
              <xsl:value-of select="text()"/>
            </xsl:attribute>
          </xsl:for-each>
        </Country>
    </xsl:template>
</xsl:stylesheet>

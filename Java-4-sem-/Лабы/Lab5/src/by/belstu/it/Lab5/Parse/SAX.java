package by.belstu.it.Lab5.Parse;

import by.belstu.it.Lab5.Language;
import org.xml.sax.helpers.DefaultHandler;
import org.xml.sax.*;

public class SAX extends DefaultHandler {
    private Language language = new Language();
    private String thisElement;

    @Override
    public void startDocument() {
        System.out.println("Start parsing");
    }

    @Override
    public void startElement(String namespaceURI, String localName, String qName, Attributes atts) {
        thisElement = qName;
    }

    @Override
    public void endElement(String namespaceURI, String localName, String qName) {
        thisElement = "";
    }

    @Override
    public void endDocument() {
        System.out.println("end parsing");
    }

    public Language getResult() {
        return language;
    }

    @Override
    public void characters(char[] ch, int start, int length) {
        if (thisElement.equals("name")) {
            language.setName(new String(ch, start, length));
        }
        if (thisElement.equals("age")) {
            language.setAge(Integer.parseInt(new String(ch, start, length)));
        }
    }
}
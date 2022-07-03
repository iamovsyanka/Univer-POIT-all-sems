package by.belstu.it.Lab5.Parse;

import by.belstu.it.Lab5.Language;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.File;
import java.util.ArrayList;
import java.util.List;

public class DOM {

    public void startParser(String filePath) {
        var xmlFile = new File(filePath);
        var factory = DocumentBuilderFactory.newInstance();
        try {
            var builder = factory.newDocumentBuilder();
            var document = builder.parse(xmlFile);
            document.getDocumentElement().normalize();
            System.out.println("Корневой элемент: " + document.getDocumentElement().getNodeName());
            var nodeList = document.getElementsByTagName("Language");

            List<Language> langList = new ArrayList<>();
            for (var i = 0; i < nodeList.getLength(); i++) {
                langList.add(getLanguage(nodeList.item(i)));
            }
            langList.forEach(System.out::println);
        } catch (Exception exc) {
            exc.printStackTrace();
        }
    }

    private static Language getLanguage(Node node) {
        var lang = new Language();
        if (node.getNodeType() == Node.ELEMENT_NODE) {
            Element element = (Element) node;
            lang.setName(getTagValue("name", element));
            lang.setAge(Integer.parseInt(getTagValue("age", element)));
        }

        return lang;
    }

    private static String getTagValue(String tag, Element element) {
        NodeList nodeList = element.getElementsByTagName(tag).item(0).getChildNodes();
        Node node = (Node) nodeList.item(0);

        return node.getNodeValue();
    }
}